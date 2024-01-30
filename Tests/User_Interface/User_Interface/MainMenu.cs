namespace User_Interface
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            //Form1.BackColor= SystemColors.Window;
            //#9FC5D6
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newForm = new PrepareMenu();
            newForm.Show();
            //this.Hide();
        }



        private void Images(object sender, EventArgs e)
        {
            PictureBox pb1 = new PictureBox();
            pb1.Image = Image.FromFile("../Resources/Easy_Save.png");
            pb1.Location = new Point(100, 100);
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(pb1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var newForm = new SaveMenu();
            newForm.Show();
            //this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var newForm = new SettingsMenu();
            newForm.Show();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var newForm = new ShowSaveInfo();
            newForm.Show();
            //this.Hide();
        }
    }
}