using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClooN
{
    /// <summary>
    /// Represents an implicit cube of points
    /// </summary>
    public struct ImplicitCube
    {
        public float StartX;
        public float OffsetX;
        public int LengthX;
        public float StartY;
        public float OffsetY;
        public int LengthY;
        public float StartZ;
        public float OffsetZ;
        public int LengthZ;

        /// <summary>
        /// The number of values the cube represents
        /// </summary>
        public int ValueCount
        {
            get { return LengthX * LengthY * LengthZ; }
        }

        /// <summary>
        /// Initializes a implicit cube
        /// </summary>        
        public ImplicitCube(float startX, float offsetX, int lengthX, float startY, float offsetY, int lengthY, float startZ, float offsetZ, int lengthZ)
        {
            this.StartX = startX;
            this.OffsetX = offsetX;
            this.LengthX = lengthX;
            this.StartY = startY;
            this.OffsetY = offsetY;
            this.LengthY = lengthY;
            this.StartZ = startZ;
            this.OffsetZ = offsetZ;
            this.LengthZ = lengthZ;
        }
    }
}
