using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace sportScienceAcademySoftware
{
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=sportScienceAcademyDB;Integrated Security=True");

        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("Select * from Account where userName=@username and userPassword=@password", con);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtPass.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    this.Hide();
                   main fm = new main();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPass.Text = "";
            txtUserName.Focus();
            
        }
    }
}
