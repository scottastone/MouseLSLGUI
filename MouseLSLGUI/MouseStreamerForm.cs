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
        // Create the LSL stream
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
            // Check if we want to include a LSL-derived timestamp or not
            if (timestampCheckbox.Checked == true) {numDataPoints = 3;}
            else {numDataPoints = 2;}

            // Instantiate the stream
            info = new liblsl.StreamInfo("Mouse", "MousePos", numDataPoints, 500, liblsl.channel_format_t.cf_double64);
            outlet = new liblsl.StreamOutlet(info);
        }
        private void startLSLStream_CheckedChanged(object sender, EventArgs e)
        { 
            // Initialize the main thread
            if (startLSLStream.Checked == true)
            {
                timestampCheckbox.Enabled = false;
                handleLabel.ForeColor = System.Drawing.Color.Green;
                typeLabel.ForeColor = System.Drawing.Color.Green;

                killThread = false;
                createStreams();
                Thread thread = new Thread(() => { PushData(); });
                thread.Start();
            }

            // Kill the stream / main thread
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
        
        // Main method for pushing data to the LSL stream
        private static void PushData()
        {
            double[] data = new double[numDataPoints];
            double timestamp;
            while (killThread == false)
            {
                // Get the current cursor position from the Windows API
                Point pos = System.Windows.Forms.Cursor.Position;
                switch (numDataPoints)
                {
                    case 2:
                        data[0] = pos.X; data[1] = pos.Y;
                        break;
                    case 3:
                        timestamp = liblsl.local_clock();
                        data[0] = pos.X; data[1] = pos.Y; data[2] = timestamp;
                        break;
                }

                // Push the data to the LSL stream
                outlet.push_sample(data);

                // TODO: fix this so we can reliably push data at a particular frequency. Until then, we can only 
                Thread.Sleep(1);
            }
            return;
        }
    }
}
