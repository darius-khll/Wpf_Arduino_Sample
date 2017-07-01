using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SerialPort mySerialPort;
        public MainWindow()
        {
            InitializeComponent();
            Initial();
        }

        void Initial()
        {
            networkStream = new TcpItem().Initial("192.168.1.116");
            mySerialPort = new SerialItem().Serial(Port.Text);
        }
        
        private void Temperature_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {
                    mySerialPort.Close();
                }
                catch (Exception) { }

                Initial();
                SendData("temp");
                GetData();

                System.Threading.Thread.Sleep(1000);
                MessageBox.Show(dataReceiver);
                dataReceiver = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        private void Humidity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {
                    mySerialPort.Close();
                }
                catch (Exception) { }

                Initial();
                SendData("hum");
                GetData();

                System.Threading.Thread.Sleep(1000);
                MessageBox.Show(dataReceiver);
                dataReceiver = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        public int index = 0;
        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //try
                //{
                //    mySerialPort.Close();
                //}
                //catch (Exception) { }

                //Initial();
                string dataSend = "H";
                if (index % 2 == 0)
                    dataSend = "H";
                else
                    dataSend = "L";

                SendData(dataSend);
                GetData();

                index++;

            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        void GetData()
        {
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        public string dataReceiver = "";
        void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            dataReceiver += indata.ToString();
        }

        void SendData(string data)
        {
            SerialPort sp = mySerialPort;
            sp.Write(data);
        }


        private NetworkStream networkStream;
        public void write(string message)
        {
            networkStream.WriteAsync(Encoding.ASCII.GetBytes(message), 0, message.Length, new System.Threading.CancellationToken());
        }

        int i1 = 0;
        private void Led1_Click(object sender, RoutedEventArgs e)
        {
            if (i1 % 2 == 0)
            {
                write("led1on\r");
            }
            else
                write("led1off\r");

            i1++;
        }

        int i2 = 0;
        private void Led2_Click(object sender, RoutedEventArgs e)
        {
            if (i2 % 2 == 0)
            {
                write("led2on\r");
            }
            else
                write("led2off\r");

            i2++;
        }

        int i3 = 0;
        private void Led3_Click(object sender, RoutedEventArgs e)
        {
            if (i3 % 2 == 0)
            {
                write("led3on\r");
            }
            else
                write("led3off\r");

            i3++;
        }


        int i4 = 0;
        private void Led4_Click(object sender, RoutedEventArgs e)
        {
            if (i4 % 2 == 0)
            {
                write("led4on\r");
            }
            else
                write("led4off\r");

            i4++;
        }

        int i5 = 0;
        private void Led5_Click(object sender, RoutedEventArgs e)
        {
            if (i5 % 2 == 0)
            {
                write("led5on\r");
            }
            else
                write("led5off\r");

            i5++;
        }

    }
}
