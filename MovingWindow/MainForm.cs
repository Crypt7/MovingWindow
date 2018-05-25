using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovingWindow
{
    enum Directions
    {
        moveStartPosition,
        moveLeft,
        moveRight,
        moveUp,
        moveDown
    }
    public partial class MainForm : Form
    {
        Directions direction;
        Rectangle workingArea;
        int defaultLeft;
        int defaultTop;
        public MainForm()

        {
            InitializeComponent();
            Timer.Start();
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                direction = Directions.moveLeft;
            }
            if (e.KeyCode == Keys.Right)
            {
                direction = Directions.moveRight;
            }
            if (e.KeyCode == Keys.Up)
            {
                direction = Directions.moveUp;
            }
            if (e.KeyCode == Keys.Down)
            {
                direction = Directions.moveDown;
            }
            if (e.KeyCode == Keys.Enter)
            {
                direction = Directions.moveStartPosition;
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
            if (direction == Directions.moveLeft && isMovePossible(shiftStep))
            {
                Left -= shiftStep;
            }
            if (direction == Directions.moveRight && isMovePossible(shiftStep))
            {
                Left += shiftStep;
            }
            if (direction == Directions.moveUp && isMovePossible(shiftStep))
            {
                Top -= shiftStep;
            }
            if (direction == Directions.moveDown && isMovePossible(shiftStep))
            {
                Top += shiftStep;
            }
            if (direction == Directions.moveStartPosition)
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
                case Directions.moveStartPosition:
                    movePossibility = true;
                    break;
                case Directions.moveLeft:
                    if (Left - shiftStep <= 0)
                    {
                        movePossibility = false;
                        direction = Directions.moveRight;
                    }
                    else
                    {
                        movePossibility = true;
                    }
                    break;
                case Directions.moveRight:
                    if (Left + Width + shiftStep >= workingArea.Width)
                    {
                        movePossibility = false;
                        direction = Directions.moveLeft;
                    }
                    else
                    {
                        movePossibility = true;
                    }
                    break;
                case Directions.moveUp:
                    if (Top - shiftStep <= 0)
                    {
                        movePossibility = false;
                        direction = Directions.moveDown;
                    }
                    else
                    {
                        movePossibility = true;
                    }
                    break;
                case Directions.moveDown:
                    if (Top + Height + shiftStep >= workingArea.Height)
                    {
                        movePossibility = false;
                        direction = Directions.moveUp;
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