using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult _dlgResult;
            Form2 _frm = new Form2();
            _dlgResult = _frm.ShowDialog();
            if (_dlgResult == DialogResult.OK)
                Application.Run(new Form1());
        }
    }
}
