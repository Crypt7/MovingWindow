namespace MovingWindow
{
    internal class MoveCenter : ICommand
    {
        private Point leftTop;
        private Point centerLeftTop;

        public MoveCenter(Point leftTop, Point centerLeftTop)
        {
            this.leftTop = leftTop;
            this.centerLeftTop = centerLeftTop;
        }

        public void Execute()
        {
            leftTop.X = centerLeftTop.X;
            leftTop.Y = centerLeftTop.Y;
        }
    }
}