namespace GameBauCua
{
    public partial class Form1 : Form
    {
        int limit = 0; // Biến toàn cục
        int[] check = { 0, 0, 0, 0, 0, 0 }; // Mảng để thực hiện check các điều kiện
        // phụ thuộc vào vị trí của các lựa chọn
        int betMoney = 0; // Mệnh giá cược
        int totalBet = 0; // Tổng tiền cược
        int totalMoney = 10000; // Tiền gốc mặc định là 1000
        int winMoney = 0; // Tổng tiền thắng cược
        public Form1()// constructor 
        {
            InitializeComponent(); // Khởi tạo các control
            // Set ảnh cho picturebox bằng code
            ptb_Bau.Image = Image.FromFile(@"C:\Users\Acer\Desktop\BCTC\Bau.jpg");
            ptb_Bau.SizeMode = PictureBoxSizeMode.StretchImage; // Fill vừa 
            lb_Money.Text = totalMoney.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            // MessageBox.Show($"{r1}, {r2}, {r3}"); // Show for Test
            // Tạo 1 mảng chứa đường dẫn đến ảnh
            string[] imgUrls = new string[]
            {
                @"C:\Users\Acer\Desktop\BCTC\Bau.jpg",
                @"C:\Users\Acer\Desktop\BCTC\cua.jpg",
                @"C:\Users\Acer\Desktop\BCTC\tom.png",
                @"C:\Users\Acer\Desktop\BCTC\ca.png",
                @"C:\Users\Acer\Desktop\BCTC\ga.jpg",
                @"C:\Users\Acer\Desktop\BCTC\huou.jpg"
            };
            // Random vị trí link ảnh trong mảng trên để gán cho pictureBox
            int r1 = r.Next(0, 5); int r2 = r.Next(0, 5); int r3 = r.Next(0, 5);
            // Gản ảnh cho pictureBox thông qua URL
            ptb_R1.Image = Image.FromFile(imgUrls[r1]);
            ptb_R2.Image = Image.FromFile(imgUrls[r2]);
            ptb_R3.Image = Image.FromFile(imgUrls[r3]);
            // Test đặt cược
            TotalBet();
            winMoney = check[r1] * betMoney + check[r2] * betMoney + check[r3] * betMoney;
            totalMoney = totalMoney = totalMoney + winMoney * 2 - totalBet;
            MessageBox.Show($"Tổng tiền cược {totalBet}\n" +
                $"Tổng tiền thắng {winMoney}, {betMoney}, {limit}");
            betMoney = 0;
            winMoney = 0;
            totalBet = 0;
            limit = 0; // Reset hết các giá trị sau mỗi lần chơi
            lb_Money.Text = totalMoney.ToString();
            check = new int[] { 0, 0, 0, 0, 0, 0 }; // reset sau khi chơi mỗi lần
            ResetComponent();
        }
        public void ResetComponent()
        {
            lb_Bau.Text = "0"; lb_Cua.Text = "0"; lb_Tom.Text = "0";
            lb_Ca.Text = "0"; lb_Ga.Text = "0"; lb_Huou.Text = "0";
            rb_1k.Checked = false; rb_2k.Checked = false; rb_10k.Checked = false;
            rb_1k.BackColor = Color.White; 
            rb_2k.BackColor = Color.White; 
            rb_1k.BackColor = Color.White;
        }

        // Tạo 1 phương thức để tính totalBet
        public void TotalBet()
        {
            if (lb_Bau.Text != "0") check[0] = Convert.ToInt32(lb_Bau.Text);
            if (lb_Cua.Text != "0") check[1] = Convert.ToInt32(lb_Cua.Text);
            if (lb_Tom.Text != "0") check[2] = Convert.ToInt32(lb_Tom.Text);
            if (lb_Ca.Text != "0") check[3] = Convert.ToInt32(lb_Ca.Text);
            if (lb_Ga.Text != "0") check[4] = Convert.ToInt32(lb_Ga.Text);
            if (lb_Huou.Text != "0") check[5] = Convert.ToInt32(lb_Huou.Text);
            // Tính tổng tiền cược
            int count = 0;
            foreach (int item in check) count += item; // Tính tổng số lượng đặt cược
            totalBet = count * betMoney;
            // Tạo Message để test


        }
        public void ptb_Click(Label lb)
        {
            lb.Text = Convert.ToInt32(lb.Text) + 1 + "";
            limit++;
            if (limit > 3)
            {
                limit -= Convert.ToInt32(lb.Text); // giảm vì update cái số về 0 mất tiu
                lb.Text = "0";
            }
        }

        private void ptb_Bau_Click(object sender, EventArgs e)
        {
            ptb_Click(lb_Bau);
            //lb_Bau.Text = Convert.ToInt32(lb_Bau.Text) + 1 + "";
            //limit++;
            //if (limit > 3)
            //{
            //    limit -= Convert.ToInt32(lb_Bau.Text); // giảm vì update cái số về 0 mất tiu
            //    lb_Bau.Text = "0"; 
            //}
        }

        private void ptb_Cua_Click(object sender, EventArgs e)
        {
            ptb_Click(lb_Cua);
        }

        private void ptb_Tom_Click(object sender, EventArgs e)
        {
            ptb_Click(lb_Tom);
        }

        private void ptb_Ca_Click(object sender, EventArgs e)
        {
            ptb_Click(lb_Ca);
        }

        private void ptb_Ga_Click(object sender, EventArgs e)
        {
            ptb_Click(lb_Ga);
        }

        private void ptb_Huou_Click(object sender, EventArgs e)
        {
            ptb_Click(lb_Huou);
        }

        private void rb_1k_CheckedChanged(object sender, EventArgs e)
        {
            if (betMoney != 1000 && rb_1k.Checked)
            {
                betMoney = 1000;
                rb_1k.BackColor = Color.OrangeRed;
                rb_2k.BackColor = Color.White;
                rb_10k.BackColor = Color.White;
            }
        }

        private void rb_2k_CheckedChanged(object sender, EventArgs e)
        {
            if (betMoney != 2000 && rb_2k.Checked)
            {
                betMoney = 2000;
                rb_2k.BackColor = Color.OrangeRed;
                rb_1k.BackColor = Color.White;
                rb_10k.BackColor = Color.White;
            }
        }

        private void rb_10k_CheckedChanged(object sender, EventArgs e)
        {
            if (betMoney != 10000 && rb_10k.Checked)
            {
                betMoney = 10000;
                rb_10k.BackColor = Color.OrangeRed;
                rb_2k.BackColor = Color.White;
                rb_1k.BackColor = Color.White;
            }
        }
    }
}