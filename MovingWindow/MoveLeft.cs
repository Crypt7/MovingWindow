using System;
namespace MovingWindow
{
    internal class MoveLeft: ICommand
    {
        Point leftTop;
        int shift;
        public MoveLeft(Point leftTop, int shift)
        {
            this.leftTop = leftTop;
            this.shift = shift;
        }
        public void Execute()
        {
            leftTop.X -= shift;
        }
    }
}
