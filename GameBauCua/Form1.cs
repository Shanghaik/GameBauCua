namespace GameBauCua
{
    public partial class Form1 : Form
    {
        int limit = 0;
        public Form1()// constructor 
        {
            InitializeComponent(); // Khởi tạo các control
            // Set ảnh cho picturebox bằng code
            ptb_Bau.Image = Image.FromFile(@"C:\Users\Acer\Desktop\BCTC\Bau.jpg");
            ptb_Bau.SizeMode = PictureBoxSizeMode.StretchImage; // Fill vừa 
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
                @"C:\Users\Acer\Desktop\BCTC\ca.png",
                @"C:\Users\Acer\Desktop\BCTC\cua.jpg",
                @"C:\Users\Acer\Desktop\BCTC\huou.jpg",
                @"C:\Users\Acer\Desktop\BCTC\tom.png",
                @"C:\Users\Acer\Desktop\BCTC\ga.jpg"
            };
            // Random vị trí link ảnh trong mảng trên để gán cho pictureBox
            int r1 = r.Next(0, 5); int r2 = r.Next(0, 5); int r3 = r.Next(0, 5);
            // Gản ảnh cho pictureBox thông qua URL
            ptb_R1.Image = Image.FromFile(imgUrls[r1]);
            ptb_R2.Image = Image.FromFile(imgUrls[r2]);
            ptb_R3.Image = Image.FromFile(imgUrls[r3]);

        }
        public void ptb_Click(PictureBox ptb, Label lb)
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
            ptb_Click(ptb_Bau, lb_Bau);
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
            ptb_Click(ptb_Cua, lb_Cua);
        }

        private void ptb_Tom_Click(object sender, EventArgs e)
        {
            ptb_Click(ptb_Tom, lb_Tom);
        }

        private void ptb_Ca_Click(object sender, EventArgs e)
        {
            ptb_Click(ptb_Ca, lb_Ca);
        }

        private void ptb_Ga_Click(object sender, EventArgs e)
        {
            ptb_Click(ptb_Ga, lb_Ga);
        }

        private void ptb_Huou_Click(object sender, EventArgs e)
        {
            ptb_Click(ptb_Huou, lb_Huou);
        }
    }
}