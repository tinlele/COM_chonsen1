
using System;
using System.IO.Ports;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Serilog;
using System.Management;
using System.Xml.Linq;
using System.Threading.Tasks;

// Cấu hình Serilog

namespace COM_chonsen1
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort1; // Khai báo serialPort1
        private SerialPort serialPort2; // Khai báo serialPort2
        private string receivedData;

        public Form1()
        {
            Log.Logger = new LoggerConfiguration()
              .WriteTo.Console()
              .CreateLogger();
            InitializeComponent();
            serialPort1 = new SerialPort();
            serialPort2 = new SerialPort();
            getAvailablePorts();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Xử lý sự kiện TextChanged cho textBox1
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện Click cho label2
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện Click cho label3
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Xử lý sự kiện Load cho Form1
        }
        void getAvailablePorts()
        {
            getAvailableUSBDevices();
            // Lấy danh sách các cổng COM có sẵn
            string[] ports = SerialPort.GetPortNames();
            // Thêm các cổng vào comboBox1
            //
            //comboBox1.Items.AddRange(ports);
            if (ports != null && ports.Length > 0)
            {
                // Thêm các cổng vào comboBox1
                comboBox1.Items.AddRange(ports);
            }
            else
            {
                // Thêm một mục thông báo không có cổng nào
                comboBox1.Items.Add("No COM ports available");
            }
        }
        void getAvailableUSBDevices()
        {
            var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub");

            foreach (var device in searcher.Get())
            {
                string deviceDescription = device["Description"].ToString();
                comboBox1.Items.Add(deviceDescription);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(comboBox3.Text))
                {
                    textBox2.Text = "Please select port settings";
                }
                else
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBox3.Text);

                    serialPort2.PortName = "COM2"; // Ensure this matches your virtual port setup
                    serialPort2.BaudRate = Convert.ToInt32(comboBox3.Text); // Assuming same baud rate

                    if (!serialPort1.IsOpen)
                        serialPort1.Open();

                    if (!serialPort2.IsOpen)
                        serialPort2.Open();

                    progressBar1.Value = 100;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    textBox1.Enabled = true;
                    button3.Enabled = false;
                    button4.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                textBox2.Text = $"Error: {ex.Message}";
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }

            if (serialPort2.IsOpen)
            {
                serialPort2.Close();
            }

            progressBar1.Value = 0;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = true;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    MessageBox.Show("Serial port is not open. Please open the port before sending data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("TextBox1 is empty. Please enter some text to send.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                serialPort1.WriteLine(textBox1.Text);
               
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while writing to the serial port.");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void button2_Click_2 (object sender, EventArgs e)
        {
            try
            {
                // Sử dụng Task.Run để đọc dữ liệu không đồng bộ
                receivedData = await Task.Run(() =>
                {
                    if (!serialPort2.IsOpen)
                    {
                        throw new InvalidOperationException("Serial port is not open. Please open the port before reading data.");
                    }

                    return serialPort2.ReadLine(); // Read from serialPort2
                });

                // Hiển thị dữ liệu đã lưu
                textBox2.Text = receivedData ?? "No data received";
            }
            catch (TimeoutException)
            {
                textBox2.Text = "Timeout";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while displaying the data.");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
