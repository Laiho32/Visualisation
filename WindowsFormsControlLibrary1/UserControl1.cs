using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class UserControl1: UserControl
    {
        private int _min;
        private int _max;
        private int cursorWidth = 10;

        Point clicPosition;

        [Category("Configuration")]
        [Description("Minimum range")]
        public int Min
        {
            get { return _min; }
            set { _min = value; this.Invalidate(); }
        }

        [Category("Configuration")]
        [Description("Maximum range")]
        public int Max
        {
            get { return _max; }
            set { _max = value; this.Invalidate(); }
        }

        public delegate void RangeChanged(object sender, int min, int max);
        public event RangeChanged RangeChangedEvent;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            _min = 0;
            _max = Width - cursorWidth;

            //bind mouseWheel
            MouseWheel += UserControl_MouseWheel;
        }

        private void UserControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                _min += 1;
                _max += 1;
            }
            else
            {
                _min -= 1;
                _max -= 1;
            }

            if (_min < 0)
                _min = 0;

            if (_max + cursorWidth > Width)
                _max = Width - cursorWidth;

            if (_min > _max)
                _min = _max - cursorWidth;

            Invalidate();

            if (RangeChangedEvent != null)
                RangeChangedEvent.Invoke(this, _min, _max);
        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            this.DoubleBuffered = true;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.FillRectangle(Brushes.Green, new Rectangle(Min, 0, cursorWidth, this.Height));
            g.FillRectangle(Brushes.Red, new Rectangle(Max, 0, cursorWidth, this.Height));
        }

        private void UserControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                clicPosition = e.Location;

                if (Math.Abs(_min - clicPosition.X) < Math.Abs(_max + cursorWidth - clicPosition.X))
                {
                    TheMouseStateMachine = MouseStateMachine.LeftMove;
                }
                else if (Math.Abs(_min - clicPosition.X) > Math.Abs(_max + cursorWidth - clicPosition.X))
                {
                    TheMouseStateMachine = MouseStateMachine.RightMove;
                }
                else
                {
                    TheMouseStateMachine = MouseStateMachine.None;
                }    
            }
        }

        private void UserControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TheMouseStateMachine == MouseStateMachine.LeftMove)
            {
                Min += e.Location.X - clicPosition.X;
                clicPosition = e.Location;

                if (Min < 0) Min = 0;

                if (Min + cursorWidth > Width)
                {
                    Min = Width - cursorWidth;
                }

                if (Min + cursorWidth > Max)
                {
                    Min = Max - cursorWidth;
                }
            }
            else if (TheMouseStateMachine == MouseStateMachine.RightMove)
            {
                Max += e.Location.X - clicPosition.X;
                clicPosition = e.Location;

                if (Max < 0) Max = 0;

                if (Max + cursorWidth > Width) Max = Width - cursorWidth;

                if (Max < Min + cursorWidth) Max = Min + cursorWidth;
            }

            if (RangeChangedEvent != null)
                RangeChangedEvent.Invoke(this, _min, _max + cursorWidth);
        }

        private MouseStateMachine TheMouseStateMachine = MouseStateMachine.None;

        enum MouseStateMachine
        {
            None, LeftMove, RightMove
        }

        private void UserControl1_MouseUp(object sender, MouseEventArgs e)
        {
            TheMouseStateMachine = MouseStateMachine.None;
        }
    }
}
