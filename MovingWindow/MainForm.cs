using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
namespace MovingWindow
{
    public partial class MainForm : Form
    {
        private Point centerLeftTop;
        private Point leftTop;
        private Keys pressedKey = Keys.Enter;
        private Rectangle workingArea;
        //private Dictionary<Keys, ICommand> _command = new Dictionary<Keys, ICommand>();
        SortedList<Keys, ICommand> _command = new SortedList<Keys, ICommand>();
        public MainForm()
        {
            InitializeComponent();
            Timer.Start();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_command.ContainsKey(e.KeyCode))
                pressedKey = e.KeyCode;
        }

        private void TimerMoving_Tick(object sender, EventArgs e)
        {
            MoveForm();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            centerLeftTop = new Point(Left, Top);
            leftTop = new Point(Left, Top);
            workingArea = Screen.GetWorkingArea(this);
            int shiftStep = 6;
            _command.Add(Keys.Left, new MoveLeft(leftTop, shiftStep));
            _command.Add(Keys.Right, new MoveRight(leftTop, shiftStep));
            _command.Add(Keys.Up, new MoveUp(leftTop, shiftStep));
            _command.Add(Keys.Down, new MoveDown(leftTop, shiftStep));
            _command.Add(Keys.Enter, new MoveCenter(leftTop, centerLeftTop));
        }
        private void MoveForm()
        {
            _command[pressedKey].Execute();
            if (leftTop.X < 0)
            {
                pressedKey = Keys.Right;
                leftTop.X = 0;
            }
            if (leftTop.X + Width > workingArea.Width)
            {
                pressedKey = Keys.Left;
                leftTop.X = workingArea.Width - Width;
            }
            if (leftTop.Y < 0)
            {
                pressedKey = Keys.Down;
                leftTop.Y = 0;
            }
            if (leftTop.Y > workingArea.Height - Height)
            {
                pressedKey = Keys.Up;
                leftTop.Y = workingArea.Height - Height;
            }
            Left = leftTop.X;
            Top = leftTop.Y;
        }
    }  
}