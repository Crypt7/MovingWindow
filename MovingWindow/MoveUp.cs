using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingWindow
{
    class MoveUp: ICommand
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

