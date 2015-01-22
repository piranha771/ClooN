namespace ClooN
{
    /// <summary>
    /// Stores 3d coordinate 
    /// </summary>
    public struct Single3
    {
        public float X, Y, Z;

        public Single3(float xyz)
        {
            X = Y = Z = xyz;
        }

        public Single3(float x, float y, float z)
        {
            X = x; Y = y; Z = z;
        }
    }
}
