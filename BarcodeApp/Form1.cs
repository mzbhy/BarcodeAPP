using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace BarcodeApp
{
    public partial class Form1 : Form
    {
        private StringBuilder builder = new StringBuilder();
        public Form1()
        {
            InitializeComponent(); 
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comboBoxPortSelect.Items.AddRange(ports);

            //默认选中项
            comboBoxPortSelect.SelectedIndex = 0;
            comboBoxBaudSelect.SelectedIndex = 3;

            //打开本计算机的串口        
            if (mycomm.IsOpen)
            {
                mycomm.Close();
            }

            mycomm.PortName = comboBoxPortSelect.Text;
            mycomm.ReadTimeout = 32;
            mycomm.BaudRate = int.Parse(comboBoxBaudSelect.Text);
            lblToolStripStatus.Text = "串口已关闭";
            //添加事件注册
            mycomm.DataReceived += comm_DataReceived;         
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (mycomm.IsOpen)
            {
                mycomm.Close();
                btnOpen.Text = "打开串口";
                lblToolStripStatus.Text = "串口已关闭";
            }
            else
            {
                try
                {
                    mycomm.Open();
                    btnOpen.Text = "关闭串口";
                    lblToolStripStatus.Text = "串口打开成功！";
                }
                catch
                {
                    btnOpen.Text = "打开串口";
                    MessageBox.Show("没有发现串口或串口已被占用！");
                    lblToolStripStatus.Text = "串口打开失败！";
                }
            }   
        }

        private void btnTx_Click(object sender, EventArgs e)
        {
            string MessageTx = textBoxTx.Text;
            if (MessageTx.Length == 0)
            {
                MessageBox.Show("没有可发送的数据！");
                return;
            }
            byte[] package = Encoding.Default.GetBytes(MessageTx);
            int MessageTxLength = MessageTx.Length;
            if (!mycomm.IsOpen)
            {
                MessageBox.Show("串口没有打开，请打开串口！");
                return;
            }
            mycomm.Write(package, 0, MessageTxLength);
        }

        private void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n = mycomm.BytesToRead;
            byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据      

            mycomm.Read(buf, 0, n);//读取缓冲数据
            builder.Clear();//清除字符串构造器的内容

            //因为要访问ui资源，所以需要使用invoke方式同步ui。
            this.Invoke(new EventHandler(delegate //调用匿名函数
            {    
                //按16进制接收
                if (radioBtnHEX.Checked)
                {
                    foreach (byte b in buf)
                    {
                        builder.Append(b.ToString("X2") + " ");
                    }
                    builder.Append(Environment.NewLine);//换行 "\r\n"
                }
                //按字符串接收
                else if (radioBtnString.Checked)
                {
                    builder.Append(Encoding.ASCII.GetString(buf));
                }

                int lines = textBoxRx.GetLineFromCharIndex(textBoxRx.Text.Length) + 1;
                if (lines > 30)
                    textBoxRx.Text = "";
                this.textBoxRx.AppendText(builder.ToString());
            }));
        }

        private void comboBoxPortSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mycomm.IsOpen)
            {
                mycomm.Close();
                btnOpen.Text = "打开串口";
                lblToolStripStatus.Text = "串口已关闭";
            }
            mycomm.PortName = comboBoxPortSelect.Text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("你确定关闭吗?", "是否要关闭", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (dr == DialogResult.OK)
            {
                if (mycomm.IsOpen)
                {
                    mycomm.Close();
                }
            }
        }

        private void comboBoxBaudSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mycomm.IsOpen)
            {
                mycomm.Close();
                btnOpen.Text = "打开串口";
                lblToolStripStatus.Text = "串口已关闭";
            }
            mycomm.BaudRate = int.Parse(comboBoxBaudSelect.Text);
        }
    }
}
