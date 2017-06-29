using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class SerialItem
    {
        public SerialPort Serial(string portTxt)
        {
            SerialPort mySerialPort = null;
            int count = 0;
            Line:
            try
            {
                string port = portTxt;
                mySerialPort = new SerialPort(port);

                mySerialPort.BaudRate = 9600;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;

                mySerialPort.Open();

            }
            catch (Exception e)
            {
                if (count == 5)
                {
                    throw new Exception("Error");
                }
                count++;
                goto Line;
            }
            return mySerialPort;
        }
    }
}
