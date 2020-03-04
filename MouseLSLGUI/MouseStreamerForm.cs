using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using LSL;
using System.Diagnostics;

namespace MouseLSLGUI
{
    public partial class MouseStreamerForm : Form
    {

        static liblsl.StreamInfo info;
        static liblsl.StreamOutlet outlet;
        static int numDataPoints;
        static bool killThread = false;
        public MouseStreamerForm()
        {
            InitializeComponent();
        }

        private void createStreams()
        {
            if (timestampCheckbox.Checked == true)
            {
                numDataPoints = 3;
            }
            else
            {
                numDataPoints = 2;
            }

            info = new liblsl.StreamInfo("Mouse", "MousePos", numDataPoints, 500, liblsl.channel_format_t.cf_double64);
            outlet = new liblsl.StreamOutlet(info);
        }

        private void startLSLStream_CheckedChanged(object sender, EventArgs e)
        {
            if (startLSLStream.Checked == true)
            {
                timestampCheckbox.Enabled = false;
                handleLabel.ForeColor = System.Drawing.Color.Green;
                typeLabel.ForeColor = System.Drawing.Color.Green;

                killThread = false;
                createStreams();
                Thread thread = new Thread(() =>
                {
                    PushData();
                });
                thread.Start();
            }
            else if (startLSLStream.Checked == false)
            {
                timestampCheckbox.Enabled = true;
                handleLabel.ForeColor = System.Drawing.Color.Crimson;
                typeLabel.ForeColor = System.Drawing.Color.Crimson;

                killThread = true;
                info = null;
                outlet = null;
                System.GC.Collect();
            }
        }
        private static void PushData()
        {
            double[] data = new double[numDataPoints];
            double timestamp;
            Stopwatch sw = new Stopwatch();
            while (killThread == false)
            {
                
                Point pos = System.Windows.Forms.Cursor.Position;
                switch (numDataPoints)
                {
                    case 2:
                        data[0] = pos.X; data[1] = pos.Y;
                        break;
                    case 3:
                        timestamp = liblsl.local_clock();
                        data[0] = timestamp; data[1] = pos.X; data[2] = pos.Y;
                        break;
                }
                outlet.push_sample(data);
                Thread.Sleep(1);
            }
            return;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
