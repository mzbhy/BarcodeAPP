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
using System.Data.SqlClient;

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

            string name = null;
            string price = null;

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

                string connStr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + @"C:\Users\lxalxy\Documents\visual studio 2015\Projects\BarcodeApp\BarcodeApp\BarcodeDatabase.mdf" + @";Integrated Security=True;Connect Timeout=30";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    MessageBox.Show("数据库打开成功！");
                    //创建sql 查询语句  
                    string sql_name = "select NAME from Item where ISBN ='" + builder.ToString() + "'";
                    string sql_price = "select PRICE from Item where ISBN ='" + builder.ToString() + "'";
                    //创建 SqlCommand 执行指令
                    using (SqlCommand cmd = new SqlCommand(sql_name, conn))
                    {
                        //使用 SqlDataReader 来 读取数据库  
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            //SqlDataReader 在数据库中为 从第1条数据开始 一条一条往下读 
                            if (sdr.Read())  //如果读取账户成功(文本框中的用户名在数据库中存在)
                            {
                                //则将第1条 密码 赋给 字符串pwd  ,并且依次往后读取 所有的密码
                                //Trim()方法为移除字符串前后的空白
                                name = sdr.GetString(0).Trim();
                            }
                            else
                            {
                                //如果读取账户数据失败, 则用户名不存在
                                MessageBox.Show("ISBN不存在,请重新输入!");
                            }
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand(sql_price, conn))
                    {
                        //使用 SqlDataReader 来 读取数据库  
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            //SqlDataReader 在数据库中为 从第1条数据开始 一条一条往下读 
                            if (sdr.Read())  //如果读取账户成功(文本框中的用户名在数据库中存在)
                            {
                                //此处需要注意：SQL中的float对应C#里的double，所以需要用GetDouble方法
                                price = sdr.GetDouble(0).ToString();
                            }
                            else
                            {
                                //如果读取账户数据失败, 则用户名不存在
                                MessageBox.Show("ISBN不存在,请重新输入!");
                            }
                        }
                    }
                }

                //将上面三个变量合成一个数组
                string[] row = { name, builder.ToString(), price};
                //给dataGridView1控件添加数据
                dataGridView1.Rows.Add(row);

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
