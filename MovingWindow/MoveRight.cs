namespace MovingWindow
{
    internal class MoveRight: ICommand
    {
        Point leftTop;
        int shift;
        public MoveRight(Point leftTop, int shift)
        {
            this.leftTop = leftTop;
            this.shift = shift;
        }
        public void Execute()
        {
            leftTop.X += shift;
        }
    }
}

