using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingWindow
{
    class MoveCenter:ICommand
    {
        Point leftTop;
        Point centerLeftTop;
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

