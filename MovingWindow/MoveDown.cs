using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingWindow
{
    class MoveDown:ICommand
    {
        Point leftTop;
        int shift;
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

