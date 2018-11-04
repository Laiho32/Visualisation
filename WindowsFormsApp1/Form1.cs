using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private float clickPointX = 0;
        private float clickPointY = 0;
        
        private float mapPositionX = 0;
        private float mapPositionY = 0;

        private bool mouseRightDown = false;
        private float coef = 0;
        private int rotationX = 0;
        private int alpha = 0;
        private bool auxiliaire = false;
        private bool interpolation = false;
        private bool sorted = false;
        private bool topView = true;
        private float altitudeMin = -1;
        private float altitudeMax = 1;
        private string filename = "trajectoires.txt";
        Dictionary<int, List<RecordData>> dic = new Dictionary<int, List<RecordData>>();

        GLControl myGLControl;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RangeSliger.RangeChangedEvent += ValueChanged;

            //Trackbars
            AlphaTrackBar.Minimum = 0;
            AlphaTrackBar.Maximum = 255;
            AlphaTrackBar.Value = 125;
            alpha = AlphaTrackBar.Value;

            RotateTrackBar.Minimum = 0;
            RotateTrackBar.Maximum = 90;
            RotateTrackBar.Value = 0;

            //lecture des trajectoires
            //#ID;time;x;y;z;name;ID

            char[] sep = new char[] { ';' };

            using (StreamReader sc = new StreamReader(filename))
            {
                string line = "";
                line = sc.ReadLine();

                while ((line = sc.ReadLine()) != null)
                {
                    var items = line.Split(sep[0]);

                    if (items.Length == 7)
                    {
                        int index = 0;

                        var rec = new RecordData(
                            int.Parse(items[index++]),
                            DateTime.ParseExact(items[index++].Substring(0, 8), "HH:mm:ssssss", CultureInfo.InvariantCulture),
                            float.Parse(items[index++], CultureInfo.InvariantCulture),
                            float.Parse(items[index++], CultureInfo.InvariantCulture),
                            float.Parse(items[index++], CultureInfo.InvariantCulture)
                            );

                        if (!dic.ContainsKey(rec.ID))
                        {
                            dic.Add(rec.ID, new List<RecordData>());
                        }
                        dic[rec.ID].Add(rec);
                    }
                }

                bool first;
                RecordData previousPoint;
                RecordData newPoint = new RecordData();

                foreach (var item in dic)
                {
                    first = true;

                    foreach (var record in item.Value)
                    {
                        record.X = (float)GenericScaleDouble(record.X, RecordData.MaxRecord.X, 1, RecordData.MinRecord.X, -1);
                        record.Y = (float)GenericScaleDouble(record.Y, RecordData.MaxRecord.Y, 1, RecordData.MinRecord.Y, -1);
                        record.Z = (float)GenericScaleDouble(record.Z, RecordData.MaxRecord.Z, 1, RecordData.MinRecord.Z, -1);
                        record.NormalizedID = (float)GenericScaleDouble(record.ID, RecordData.MaxRecord.ID, 1, RecordData.MinRecord.ID, -1);
                        record.NormalizedDate = (float)GenericScaleDouble(record.Date.Ticks, RecordData.MaxRecord.Date.Ticks, 1, RecordData.MinRecord.Date.Ticks, -1);

                        if (first)
                        {
                            newPoint = record;
                            first = false;
                        }
                        else
                        {
                            previousPoint = newPoint;
                            newPoint = record;

                            new Segment(previousPoint, newPoint);
                        }
                    }
                }
                Segment.AllSegments.Sort();
            }

            InitOpenTK();
        }

        public static double GenericScaleDouble(double input, double i1, double o1, double i2, double o2)
        {
            if (i2 == i1) return o1; //Arbitrary choice, but wrong!!!
            double a = (o2 - o1) / (i2 - i1);
            double b = o1 - a * i1;
            return (a * input + b);
        }

        private void InitOpenTK()
        {
            OpenTK.Toolkit.Init();

            myGLControl = new GLControl
            {
                Location = new Point(350, 10),
                Size = new Size(1000, 1000)
            };
            Controls.Add(myGLControl);
            myGLControl.Paint += MyGLControl_Paint;
            myGLControl.MouseDown += MyGLControl_MouseDown;
            myGLControl.MouseUp += MyGLControl_MouseUp;
            myGLControl.MouseMove += MyGLControl_MouseMove;
            myGLControl.MouseWheel += MyGLControl_mouseWheel;
        }
        

        private void MyGLControl_Paint(object sender, PaintEventArgs e)
        {
            myGLControl.MakeCurrent();

            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Viewport(0, 0, myGLControl.Width, myGLControl.Height);
            GL.Enable(EnableCap.PointSmooth);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.Rotate(-rotationX, new Vector3(1, 0, 0));
            GL.Translate(mapPositionX, mapPositionY, 0);
            GL.PointSize(1);

            if (!interpolation)
            {
                if (sorted)
                {
                    foreach (Segment s in Segment.AllSegments)
                    {
                        if (altitudeMin < s.AltitudeMin && s.AltitudeMax < altitudeMax)
                        {
                            GL.Begin(BeginMode.Lines);

                            GL.Color4(GetColor(s.P1));
                            GL.Vertex3(s.P1.X, s.P1.Y, s.P1.Z);

                            GL.Color4(GetColor(s.P2));
                            GL.Vertex3(s.P2.X, s.P2.Y, s.P2.Z);
                            GL.End();
                        }
                    }
                }
                else
                {
                    foreach (var item in dic)
                    {
                        GL.Begin(BeginMode.LineStrip);

                        if (GetMin(item.Value) > altitudeMin && GetMax(item.Value) < altitudeMax)
                        {
                            foreach (var record in item.Value)
                            {
                                GL.Color4(GetColor(record));
                                GL.Vertex3(record.X, record.Y, record.Z);
                            }
                        }
                        GL.End();
                    }
                }
            }
            else
            {
                foreach (var item in dic)
                {
                    foreach (var record in item.Value)
                    {
                        GL.Begin(BeginMode.Points);
                        GL.Color4(GetColor(record));
                        GL.Vertex3(record.NormalizedDate * coef + (1 - coef) * record.X,
                                   record.NormalizedID * coef + (1 - coef) * record.Y,
                                   (1 - coef) * record.Z);
                        GL.End();
                    }
                }
            }
            
            GL.Translate(-mapPositionX, -mapPositionY, 0);
            GL.Rotate(rotationX, new Vector3(1, 0, 0));
            myGLControl.SwapBuffers();
        }

        private void AlphaTrackBar_ValueChanged(object sender, EventArgs e)
        {
            alpha = AlphaTrackBar.Value;

            if (alpha > 255)
                alpha = 255;

            if (alpha < 0)
                alpha = 0;

            if (myGLControl != null)
                myGLControl.Invalidate();
        }

        private void ValueChanged(object sender, int min, int max)
        {
            altitudeMin = (float)RangeSliger.Min * 2 / RangeSliger.Width - 1;
            altitudeMax = (float)RangeSliger.Max * 2 / RangeSliger.Width - 1;

            myGLControl.Invalidate();
        }

        private Color GetColor(RecordData record)
        {
            if (record.Z < -0.3)
                return Color.FromArgb(alpha, 50, 233, 0);

            if (record.Z > 0.1)
                return Color.FromArgb(alpha, 0, 6, 255);

            float delta = (record.Z + (float)0.30) / (float)0.40;

            float r = (((float)50 / 255) * (1 - delta) + ((float)0 / 255) * delta) * 255;
            float g = (((float)233 / 255) * (1 - delta) + ((float)6 / 255) * delta) * 255;
            float b = (((float)0 / 255) * (1 - delta) + ((float)255 / 255) * delta) * 255;

            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;

            if (r < 0) r = 0;
            if (g < 0) g = 0;
            if (b < 0) b = 0;

            return Color.FromArgb(alpha, (int)r, (int)g, (int)b);
        }

        private void RotateTrackBar_ValueChanged(object sender, EventArgs e)
        {
            rotationX = RotateTrackBar.Value;

            if (rotationX == 90)
            {
                topView = false;
            }

            if (rotationX == 0)
            {
                topView = true;
            }

            if (myGLControl != null)
                myGLControl.Invalidate();
        }

        private float GetMax(List<RecordData> list)
        {
            float max = float.MinValue;

            foreach (RecordData r in list)
            {
                if (r.Z > max)
                    max = r.Z;
            }

            return max;
        }

        private float GetMin(List<RecordData> list)
        {
            float min = float.MaxValue;

            foreach (RecordData r in list)
            {
                if (r.Z < min)
                    min = r.Z;
            }

            return min;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (sorted)
            {
                sorted = false;
                ValeurTrieeLabel.Text = "Non";
            }
            else
            {
                sorted = true;
                ValeurTrieeLabel.Text = "Oui";
            }
            myGLControl.Invalidate();
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            timerRotate.Start();
        }

        private void TimerRotate_Tick(object sender, EventArgs e)
        {
            if (topView)
            {
                rotationX += 2;

                if (rotationX >= 90)
                {
                    RotateTrackBar.Value = 90;
                    timerRotate.Stop();
                    topView = false;
                }
                else
                {
                    RotateTrackBar.Value = rotationX;
                }

                myGLControl.Invalidate();
            }
            else
            {
                rotationX -= 2;


                if (rotationX <= 0)
                {
                    RotateTrackBar.Value = 0;
                    timerRotate.Stop();
                    topView = true;
                }
                else
                {
                    RotateTrackBar.Value = rotationX;
                }

                myGLControl.Invalidate();
            }
        }

        private void IdDateButton_Click(object sender, EventArgs e)
        {
            auxiliaire = !auxiliaire;
            interpolation = true;

            timerInterpolation.Start();

            if (myGLControl != null)
                myGLControl.Invalidate();
        }

        private void TimerInterpolation_Tick(object sender, EventArgs e)
        {
            if (auxiliaire)
            {
                coef += (float)0.05;
            }
            else
            {
                coef -= (float)0.05;
            }

            if (coef > 1)
            {
                timerInterpolation.Stop();
                interpolation = true;
            }

            if (coef < 0)
            {
                timerInterpolation.Stop();
                interpolation = false;
            }


            if (myGLControl != null)
                myGLControl.Invalidate();
        }

        private void MyGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            float newScaledX = 0;
            float newScaledY = 0;

            if (mouseRightDown)
            {
                newScaledX = ((float) GenericScaleDouble(e.X, 1000, 1, 0, -1));
                newScaledY = ((float) GenericScaleDouble(e.Y, 1000, 1, 0, -1));

                mapPositionX += newScaledX - clickPointX;
                mapPositionY += -(newScaledY - clickPointY);

                clickPointX = newScaledX;
                clickPointY = newScaledY;

                if (myGLControl != null)
                    myGLControl.Invalidate();
            }
        }

        private void MyGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            mouseRightDown = false;

            if (myGLControl != null)
                myGLControl.Invalidate();
        }

        private void MyGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                clickPointX = (float)GenericScaleDouble(e.X, 1000, 1, 0, -1);
                clickPointY = (float)GenericScaleDouble(e.Y, 1000, 1, 0, -1);
                mouseRightDown = true;
            }
        }

        private void MyGLControl_mouseWheel(object sender, MouseEventArgs e)
        {
            // p1 = k * (p0 - c) + c
            
            if (e.Delta < 0)
            {
                GL.Scale(0.9, 0.9, 0);
            }
            else
            {
                GL.Scale(1.1, 1.1, 0);
            }

            if (myGLControl != null)
                myGLControl.Invalidate();
        }
    }
}
