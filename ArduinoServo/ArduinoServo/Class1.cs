using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoServo
{
    public class Servo
    {
        System.IO.Ports.SerialPort sp;
        public Servo(string portname)
        {
            sp = new System.IO.Ports.SerialPort();
            sp.PortName = portname;
            sp.BaudRate = 9600;
            sp.Open();
            Task k = Task.Factory.StartNew(MainLoop);
        }

        private void MainLoop()
        {
            while (true)
            {
                byte[] b = { _angle };
                sp.Write(b, 0, 1);
                System.Threading.Thread.Sleep(50);
            }
        }

        private byte _angle;

        public byte Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
            }
        }
        public void Open()
        {
            _angle = 180;
        }

        public void Close()
        {
            _angle = 0;
        }

    }
}
