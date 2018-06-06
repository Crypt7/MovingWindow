namespace MovingWindow
{
    internal class MoveUp: ICommand
    {
        private Point leftTop;
        private int shift;

        public MoveUp(Point leftTop, int shift)
        {
            this.leftTop = leftTop;
            this.shift = shift;
        }

        public void Execute()
        {
            leftTop.Y -= shift;
        }
    }
}