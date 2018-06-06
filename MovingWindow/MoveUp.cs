namespace MovingWindow
{
    internal class MoveUp: ICommand
    {
        Point leftTop;
        int shift;
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