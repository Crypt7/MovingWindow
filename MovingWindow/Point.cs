namespace MovingWindow
{
    internal class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        internal int X
        {
            get { return x; }
            set { x = value; }
        }
        internal int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}