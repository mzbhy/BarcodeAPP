using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BarcodeApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Debug\") || dataDir.EndsWith(@"\bin\Release\"))
            {
                dataDir = System.IO.Directory.GetParent(dataDir).Parent.Parent.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }

            using (SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + @"C:\Users\lxalxy\Documents\visual studio 2013\Projects\BarcodeApp\BarcodeApp\BarcodeDatabase.mdf" + @";Integrated Security=True;Connect Timeout=30"))
            {
                sqlcon.Open();
                MessageBox.Show("Open Database Connect Success");
                //写入一条数据
                string strUserName = "作业本";
                string strPWD = "Ab123456";
                using (SqlCommand sqlCmd = sqlcon.CreateCommand())
                {
                    sqlCmd.CommandText = "insert into ACCOUNT(Username,Password) values (@UserName,@PWD) ";//连接字符串进行参数化
                    SqlParameter[] sqlPara = new SqlParameter[] { 
                    new SqlParameter("UserName",strUserName),
                    new SqlParameter("PWD",strPWD)
                    };
                    sqlCmd.Parameters.AddRange(sqlPara); //把Paramerter 数组参数添加到sqlCmd中
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Insert OK");
                }
            }
        }
    }
}
