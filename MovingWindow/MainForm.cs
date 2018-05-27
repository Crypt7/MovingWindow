using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovingWindow
{
    internal enum Direction
    {
        moveStartPosition,
        moveLeft,
        moveRight,
        moveUp,
        moveDown
    }
    public partial class MainForm : Form
    {
        private int defaultLeft;
        private int defaultTop;
        private Direction direction;
        private Rectangle workingArea;
        
        public MainForm()
        {
            InitializeComponent();
            Timer.Start();
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                direction = Direction.moveLeft;
            }
            if (e.KeyCode == Keys.Right)
            {
                direction = Direction.moveRight;
            }
            if (e.KeyCode == Keys.Up)
            {
                direction = Direction.moveUp;
            }
            if (e.KeyCode == Keys.Down)
            {
                direction = Direction.moveDown;
            }
            if (e.KeyCode == Keys.Enter)
            {
                direction = Direction.moveStartPosition;
            }
        }
        private void TimerMoving_Tick(object sender, EventArgs e)
        {
            int shiftStep = 6;
            MoveWindow(shiftStep);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            defaultLeft = Left;
            defaultTop = Top;
            workingArea = Screen.GetWorkingArea(this);
        }

        private void MoveWindow(int shiftStep)
        {
            if (direction == Direction.moveLeft && isMovePossible(shiftStep))
            {
                Left -= shiftStep;
            }
            if (direction == Direction.moveRight && isMovePossible(shiftStep))
            {
                Left += shiftStep;
            }
            if (direction == Direction.moveUp && isMovePossible(shiftStep))
            {
                Top -= shiftStep;
            }
            if (direction == Direction.moveDown && isMovePossible(shiftStep))
            {
                Top += shiftStep;
            }
            if (direction == Direction.moveStartPosition)
            {
                Top = defaultTop;
                Left = defaultLeft;
            }
        }
        private bool isMovePossible(int shiftStep = 6)
        {
            bool movePossibility = false;
            switch (direction)
            {
                case Direction.moveStartPosition:
                    movePossibility = true;
                    break;
                case Direction.moveLeft:
                    if (Left - shiftStep <= 0)
                    {
                        movePossibility = false;
                        direction = Direction.moveRight;
                    }
                    else
                    {
                        movePossibility = true;
                    }
                    break;
                case Direction.moveRight:
                    if (Left + Width + shiftStep >= workingArea.Width)
                    {
                        movePossibility = false;
                        direction = Direction.moveLeft;
                    }
                    else
                    {
                        movePossibility = true;
                    }
                    break;
                case Direction.moveUp:
                    if (Top - shiftStep <= 0)
                    {
                        movePossibility = false;
                        direction = Direction.moveDown;
                    }
                    else
                    {
                        movePossibility = true;
                    }
                    break;
                case Direction.moveDown:
                    if (Top + Height + shiftStep >= workingArea.Height)
                    {
                        movePossibility = false;
                        direction = Direction.moveUp;
                    }
                    else
                    {
                        movePossibility = true;
                    }
                    break;
                default:
                    break;
            }
            return movePossibility;
        }
    }
}