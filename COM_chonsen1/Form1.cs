
using System;
using System.IO.Ports;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Serilog;
using System.Management;
// Cấu hình Serilog

namespace COM_chonsen1
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort1; // Khai báo serialPort1
        public Form1()
        {
            Log.Logger = new LoggerConfiguration()
              .WriteTo.Console()
              .CreateLogger();
            InitializeComponent();
            serialPort1 = new SerialPort();
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

                    serialPort1.Open();

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
                textBox2.Text= $"Error: {ex.Message}";
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Đóng cổng nối tiếp
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }

            // Đặt giá trị thanh tiến trình về 0
            progressBar1.Value = 0;

            // Vô hiệu hóa các nút
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;

            // Kích hoạt lại các nút cần thiết
            button3.Enabled = true;
            textBox1.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine(textBox1.Text);
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while writing to the serial port.");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = serialPort1.ReadLine();
            }
            catch (TimeoutException)
            {
                textBox2.Text = "Timeout";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while reading from the serial port.");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
