using System;
using System.Windows.Forms;


namespace sportScienceAcademySoftware
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(2);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                this.Hide();
                //Form1 fm = new Form1();
                login fm = new login();
             // Form1 fm = new Form1();
                fm.Show();
            }
               
        }
    }
}
