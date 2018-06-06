namespace MovingWindow
{
    internal class MoveDown:ICommand
    {
        private Point leftTop;
        private int shift;
        public MoveDown(Point leftTop, int shift)
        {
            this.leftTop = leftTop;
            this.shift = shift;
        }
        public void Execute()
        {
            leftTop.Y += shift;
        }
    }
}