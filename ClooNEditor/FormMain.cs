using Cloo;
using ClooN;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClooNEditor
{
    public partial class FormMain : Form
    {
        private Modifier modifier;

        private ModuleCompiler compiler = new ModuleCompiler();
        private NoiseProgram program;

        private Stopwatch overheadWatch = new Stopwatch();

        private Single3[] explicitQuery;
        private ImplicitCube implicitQuery;
        private bool needRefresh;

        private int currentSeed;
        private float[] result;

        private float shiftLeftRight = 0;
        private float shiftUpDown = 0;
        private float zoomFactor = 1.0f;
        private float layerZ = 0.0f;
        private float contrast = 1.0f;


        public FormMain()
        {
            InitializeComponent();
            CreateResultQuery();
            textBoxSeed.Text = new Random().Next().ToString();

            FixCoordLabel(labelCoordTL);
            FixCoordLabel(labelCoordTR);
            FixCoordLabel(labelCoordBL);
            FixCoordLabel(labelCoordBR);
            FixCoordLabel(labelCoordsZ);
        }

        private void FixCoordLabel(Label label)
        {
            var pos = this.PointToScreen(label.Location);
            pos = pictureBoxResult.PointToClient(pos);
            label.Parent = pictureBoxResult;
            label.Location = pos;
            label.BackColor = Color.Transparent;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            // Load devices
            foreach (var platform in ComputePlatform.Platforms)
            {
                comboBoxDevice.Items.Add(platform);
                comboBoxDevice.DisplayMember = "Name";
            }
            // Initialize start values
            comboBoxDevice.SelectedIndex = 0;
            currentSeed = int.Parse(textBoxSeed.Text);
            FormMain_Resize(null, null);
            FormMain_ResizeEnd(null, null);
        }

        private void FillDeviceInfo(ComputePlatform platform)
        {
            labelVendor.Text = platform.Vendor;
            labelProfile.Text = platform.Profile;
            labelVersion.Text = platform.Version;
            listBoxExtensions.DataSource = platform.Extensions;
        }

        private void comboBoxDevice_SelectedValueChanged(object sender, EventArgs e)
        {
            FillDeviceInfo((ComputePlatform)comboBoxDevice.SelectedItem);
            CreateResultQuery();
            needRefresh = true;
        }

        #region Module Buttons
        private void buttonFBM_Click(object sender, EventArgs e)
        {
            Insert("fbm(6, 1.0, 2.13727, 0.507123)");
        }

        private void buttonRMF_Click(object sender, EventArgs e)
        {
            Insert("rmf(6, 1.0, 2.13727, 0.607123, 1.0)");
        }

        private void buttonTurbulence_Click(object sender, EventArgs e)
        {
            Insert("turbu(6, 1.0, 2.13727, 0.507123)");
        }

        private void buttonVoronoi_Click(object sender, EventArgs e)
        {
            Insert("voro(1.0, F1)");
        }

        private void buttonAbs_Click(object sender, EventArgs e)
        {
            Insert("abs(  )");
        }

        private void buttonLerp_Click(object sender, EventArgs e)
        {
            Insert("lerp(  )");
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            Insert("min(  )");
        }

        private void buttonMax_Click(object sender, EventArgs e)
        {
            Insert("max(  )");
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            Insert("pow(  )");
        }

        private void buttonRound_Click(object sender, EventArgs e)
        {
            Insert("rnd(  )");
        }

        private void buttonStep_Click(object sender, EventArgs e)
        {
            Insert("step(  )");
        }

        private void Insert(string code)
        {
            if (boxCode.SelectionLength > 0) // Replace
            {
                int start = boxCode.SelectionStart;
                boxCode.Text = boxCode.Text.Remove(start, boxCode.SelectionLength);
                boxCode.SelectionLength = 0;
                boxCode.Text = boxCode.Text.Insert(start, code);
                boxCode.SelectionLength = code.Length;
            }
            else // Insert
            {
                boxCode.Text = boxCode.Text.Insert(boxCode.SelectionStart, code);
                boxCode.SelectionStart += code.Length;
            }
        }
        #endregion

        #region Compute
        private void CreateResultQuery()
        {
            overheadWatch.Reset();
            overheadWatch.Start();

            int width = pictureBoxResult.Width;
            int height = pictureBoxResult.Height;

            implicitQuery = new ImplicitCube(shiftLeftRight - (zoomFactor / 2.0f), 1.0f / width * zoomFactor, width, shiftUpDown - (zoomFactor / 2.0f), 1.0f / height * zoomFactor, height, layerZ, 1, 1);

            string precision = "0.0000000";
            labelCoordTL.Text = implicitQuery.StartX.ToString(precision) + "/" + implicitQuery.StartY.ToString(precision);
            labelCoordTR.Text = (implicitQuery.StartX + (implicitQuery.OffsetX * implicitQuery.LengthX)).ToString(precision) + "/" + implicitQuery.StartY.ToString(precision);
            labelCoordBL.Text = implicitQuery.StartX.ToString(precision) + "/" + (implicitQuery.StartY + +(implicitQuery.OffsetY * implicitQuery.LengthY)).ToString(precision);
            labelCoordBR.Text = (implicitQuery.StartX + (implicitQuery.OffsetX * implicitQuery.LengthX)).ToString(precision) + "/" + (implicitQuery.StartY + +(implicitQuery.OffsetY * implicitQuery.LengthY)).ToString(precision);
            labelCoordsZ.Text = "Z: " + implicitQuery.StartZ.ToString(precision);


            if (radioButtonExplicit.Checked)
            {
                explicitQuery = new Single3[pictureBoxResult.Width * pictureBoxResult.Height];
                Parallel.For(0, pictureBoxResult.Height, y =>
                {
                    for (int x = 0; x < pictureBoxResult.Width; x++)
                    {
                        explicitQuery[x + pictureBoxResult.Width * y] = new Single3(((float)x / (float)width * zoomFactor) + shiftLeftRight - (zoomFactor / 2.0f), ((float)y / (float)height * zoomFactor) + shiftUpDown - (zoomFactor / 2.0f), layerZ);
                    }
                });
            }

            overheadWatch.Stop();
        }

        public void RunResult()
        {
            if (program == null) return;
            if (result.Length !=  pictureBoxResult.Width * pictureBoxResult.Height)
            {
                result = new float[pictureBoxResult.Width * pictureBoxResult.Height];
            }

            var watch = Stopwatch.StartNew();
            
            if (radioButtonImplicit.Checked)
            {
                program.GetValues(ref implicitQuery, ref result);
            } 
            else 
            {
                program.GetValues(explicitQuery, ref result);
            }
            watch.Stop();
            overheadWatch.Start();
            statusLabelCloonTime.Text = watch.ElapsedMilliseconds.ToString() + "ms";

            pictureBoxResult.Image = CreateNoiseBitmap(pictureBoxResult.Width, pictureBoxResult.Height, result); ;
  
            overheadWatch.Stop();
            statusLabelOverhead.Text = overheadWatch.ElapsedMilliseconds.ToString() + "ms";
            overheadWatch.Reset();
        }

        private Bitmap CreateNoiseBitmap(int width, int height, float[] noise)
        {
            unsafe
            {
                Bitmap result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                BitmapData bitmapData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, result.PixelFormat);

                int BytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(result.PixelFormat) / 8;
                int WidthInBytes = bitmapData.Width * BytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, height, y =>
                {
                    byte* CurrentLine = PtrFirstPixel + (y * bitmapData.Stride);
                    int xPixel = 0;
                    for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                    {
                        var value = (byte)((Clamp(-1.0f, 1.0f, noise[xPixel + width * y] * contrast) + 1) / 2 * 255);
                        CurrentLine[x] = value; // Blue
                        CurrentLine[x + 1] = value; // Green
                        CurrentLine[x + 2] = value; // Red
                        xPixel++;
                    }
                });
                result.UnlockBits(bitmapData);

                return result;
            }
        }

        private float Clamp(float min, float max, float value)
        {
            return Math.Max(Math.Min(max, value), min);
        }

        private void timerRefresher_Tick(object sender, EventArgs e)
        {
            if (!needRefresh) return;

            needRefresh = false;

            if (compiler.Compile(boxCode.Text))
            {
                labelParseMessage.Text = string.Empty;
                labelParseMessage.Visible = false;

                if (program != null) program.Dispose();
                program = new NoiseProgram(compiler.LastSuccessful);
                program.Seed = currentSeed;
                program.Compile((ComputePlatform)comboBoxDevice.SelectedItem);
                RunResult();
            }
            else
            {
                labelParseMessage.Text = compiler.ErrorMessage;
                labelParseMessage.Visible = true;
            }
        }
        #endregion Compute

        #region Resize
        private void FormMain_Resize(object sender, EventArgs e)
        {
            statusLabelResolution.Text = string.Format("Res: {0}x{1} ({2}MP)", pictureBoxResult.Width, pictureBoxResult.Height, ((float)(pictureBoxResult.Width * pictureBoxResult.Height) / 1000000).ToString("0.0"));
        }

        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {         
            CreateResultQuery();
            result = new float[implicitQuery.ValueCount];
            needRefresh = true;
        }
        #endregion

        private void boxCode_TextChanged(object sender, EventArgs e)
        {
            needRefresh = true;
        }

        private void textBoxSeed_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(textBoxSeed.Text, out value))
            {
                if (!string.IsNullOrEmpty(textBoxSeed.Text.Trim()))
                {
                    currentSeed = value;
                    needRefresh = true;
                }
            }
        }

        #region Modifier Buttons
        private void buttonResetPosition_Click(object sender, EventArgs e)
        {
            shiftUpDown = 0.0f;
            shiftLeftRight = 0.0f;
            layerZ = 0f;
            zoomFactor = 1.0f;
            contrast = 1.0f;
            CreateResultQuery();
            RunResult();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RunResult();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(compiler.LastValidCode);
        }

        private void buttonShowCoords_Click(object sender, EventArgs e)
        {
            labelCoordTL.Visible = !labelCoordTL.Visible;
            labelCoordTR.Visible = !labelCoordTR.Visible;
            labelCoordBL.Visible = !labelCoordBL.Visible;
            labelCoordBR.Visible = !labelCoordBR.Visible;
            labelCoordsZ.Visible = !labelCoordsZ.Visible;
        }

        private void buttonShiftLeft_MouseDown(object sender, MouseEventArgs e)
        {
            modifier = Modifier.Left;
            timerButtonDown.Enabled = true;
        }

        private void buttonShiftRight_MouseDown(object sender, MouseEventArgs e)
        {
            modifier = Modifier.Right;
            timerButtonDown.Enabled = true;
        }

        private void buttonShiftUp_MouseDown(object sender, MouseEventArgs e)
        {
            modifier = Modifier.Up;
            timerButtonDown.Enabled = true;
        }

        private void buttonShiftDown_MouseDown(object sender, MouseEventArgs e)
        {
            modifier = Modifier.Down;
            timerButtonDown.Enabled = true;
        }

        private void buttonZUp_MouseDown(object sender, MouseEventArgs e)
        {
            modifier = Modifier.ZUp;
            timerButtonDown.Enabled = true;
        }

        private void buttonZDown_MouseDown(object sender, MouseEventArgs e)
        {
            modifier = Modifier.ZDown;
            timerButtonDown.Enabled = true;
        }

        private void buttonZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            modifier = Modifier.ZoomIn;
            timerButtonDown.Enabled = true;
        }

        private void buttonZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            modifier = Modifier.ZoomOut;
            timerButtonDown.Enabled = true;
        }

        private void buttonContrastAdd_MouseDown(object sender, MouseEventArgs e)
        {
            modifier = Modifier.ContrastAdd;
            timerButtonDown.Enabled = true;
        }

        private void buttonContrastSub_MouseDown(object sender, MouseEventArgs e)
        {
            modifier = Modifier.ContrastSub;
            timerButtonDown.Enabled = true;
        }

        private void timerButtonDown_Tick(object sender, EventArgs e)
        {
            switch (modifier)
            {
                case Modifier.Up:
                    shiftUpDown -= (0.1f * zoomFactor);
                    break;
                case Modifier.Down:
                    shiftUpDown += (0.1f * zoomFactor);
                    break;
                case Modifier.Left:
                    shiftLeftRight -= (0.1f * zoomFactor);
                    break;
                case Modifier.Right:
                    shiftLeftRight += (0.1f * zoomFactor);
                    break;
                case Modifier.ZUp:
                    layerZ += 0.03f;
                    break;
                case Modifier.ZDown:
                    layerZ -= 0.03f;
                    break;
                case Modifier.ZoomIn:
                    zoomFactor *= 0.9f;
                    break;
                case Modifier.ZoomOut:
                    zoomFactor *= 1.1f;
                    break;
                case Modifier.ContrastAdd:
                    contrast *= 1.1f;
                    break;
                case Modifier.ContrastSub:
                    contrast *= 0.9f;
                    break;
                default:
                    break;
            }

            CreateResultQuery();
            RunResult();
        }

        private void modifierButton_MouseUp(object sender, MouseEventArgs e)
        {
            timerButtonDown.Enabled = false;
        }
        #endregion

        private void radioButtonImplicit_CheckedChanged(object sender, EventArgs e)
        {
            CreateResultQuery();
            needRefresh = true;
        }

        private void radioButtonExplicit_CheckedChanged(object sender, EventArgs e)
        {
            CreateResultQuery();
            needRefresh = true;
        }

        private void statusLabelAbout_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://codedrain.net/");
        }
    }
}
