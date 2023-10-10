using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBauCua
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = tbt_Password.Text;
            string username = tbt_Username.Text;
            Account ac = AccountServices.CheckAccount(username, password);
            if (ac == null)
            {
                MessageBox.Show("Tài khoản không tồn tại hoặc thông tin sai lệch");
            }
            else
            {
                int money = ac.Money;
                Form1 fm = new Form1(username, money);
                // File.WriteAllText("account.txt", ""); // Tạo file txt
                fm.ShowDialog();
            }    
        }
    }
}
