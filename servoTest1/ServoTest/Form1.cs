using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServoTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var s = System.IO.Ports.SerialPort.GetPortNames();
            comboBox1.Items.AddRange(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            MoveServo(byte.Parse(b.Text));


        }
        private void MoveServo(byte position)
        {
            byte[] pos = { position};
            using (var sp = new System.IO.Ports.SerialPort())
            {
                sp.PortName = comboBox1.SelectedItem.ToString();
                sp.BaudRate = 9600;
                sp.Open();
                sp.Write(pos, 0, 1);

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            TrackBar t = (TrackBar)sender;
            MoveServo((byte)t.Value);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            trackBar1.Enabled = true;
        }
    }
}
