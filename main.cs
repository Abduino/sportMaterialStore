using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

using System.Text.RegularExpressions;
namespace sportScienceAcademySoftware
{
    public partial class main : Form
    {

        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=sportScienceAcademyDB;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int IDmat = 0;
        int IDspo = 0;
        int chkQuantityI = 0;
        int chkQuantityS = 0;
        int IDbrand = 0;
        int IDsize = 0;
        int IDcolor = 0;
        int IDitemTable = 0;
        int manualId = 0;
       
        int borrowCode = 0;

        public main()
        {
            try
            {
                InitializeComponent();
                DisplayMatData();
                DisplaySpoData();
                DisplayBrandData();
                DisplaySizeData();
                DisplayColorData();
                DisplayBorrowedData();
                DisplayIssuerBorrowedData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void btnDeleteM_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want to Delete This Record?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    if (IDmat != 0 && txtMat.Text!="")
                    {
                        cmd = new SqlCommand("delete materialTable where materialCode=@id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", IDmat);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Material Record Deleted Successfully!");
                        DisplayMatData();
                        ClearMatData();
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Material Record to Delete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            
            
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMat.Text != "")
                {
                    SqlCommand cmd;
                    string materialName = txtMat.Text;
                    cmd = new SqlCommand("insert into materialTable(materialName) values(@name)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", txtMat.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Material Record Inserted Successfully");

                    con.Close();
                    DisplayMatData();
                    ClearMatData();
                
                }
                else
                {
                    MessageBox.Show("Please Provide Material Details!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }

        private void AppendHeader(string p1, string p2)
        {
            throw new NotImplementedException();
        }

        private void btnUpdateM_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMat.Text != "")
                {
                    cmd = new SqlCommand("update materialTable set materialName=@name where materialCode=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", IDmat);
                    cmd.Parameters.AddWithValue("@name", txtMat.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                    con.Close();
                    DisplayMatData();
                    ClearMatData();
                }
                else
                {
                    MessageBox.Show("Please Select Record to Update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }

        private void btnAddS_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSpo.Text != "")
                {
                    SqlCommand cmd;
                    string materialName = txtSpo.Text;
                    cmd = new SqlCommand("insert into sportTable(sportName) values(@name)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", txtSpo.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted Successfully");

                    con.Close();
                    DisplaySpoData();
                    ClearSpoData();
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }

        private void btnUpdateS_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSpo.Text != "")
                {
                    cmd = new SqlCommand("update sportTable set sportName=@name where sportCode=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", IDspo);
                    cmd.Parameters.AddWithValue("@name", txtSpo.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                    con.Close();
                    DisplaySpoData();
                    ClearSpoData();
                }
                else
                {
                    MessageBox.Show("Please Select Record to Update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }

        private void btnDeleteS_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want to Delete This Record?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    if (IDspo != 0 && txtSpo.Text != "")
                    {
                        cmd = new SqlCommand("delete sportTable where sportCode=@id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", IDspo);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record Deleted Successfully!");
                        DisplaySpoData();
                        ClearSpoData();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record to Delete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
          
        }

        private void DisplayMatData()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select * from materialTable", con);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }
        private void ClearMatData()
        {
            txtMat.Text = "";
            IDmat = 0;
        }

        private void DisplaySpoData()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select * from sportTable", con);
                adapt.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
          
        }

        private void ClearSpoData()
        {
            txtSpo.Text = "";
            IDspo = 0;
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                IDmat = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtMat.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
         
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                IDspo = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtSpo.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }

        private void main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet3.PSelectAllBorrowedItem' table. You can move, or remove it, as needed.
            this.pSelectAllBorrowedItemTableAdapter1.Fill(this.sportScienceAcademyDBDataSet3.PSelectAllBorrowedItem);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet2.PSelectAllBorrowedItem' table. You can move, or remove it, as needed.
            this.pSelectAllBorrowedItemTableAdapter.Fill(this.sportScienceAcademyDBDataSet2.PSelectAllBorrowedItem);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet1.itemTable' table. You can move, or remove it, as needed.
            this.itemTableTableAdapter.Fill(this.sportScienceAcademyDBDataSet1.itemTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet.manualBorrowing' table. You can move, or remove it, as needed.
            this.manualBorrowingTableAdapter.Fill(this.sportScienceAcademyDBDataSet.manualBorrowing);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBallDataSetSP.PSelectAllBorrowedItem' table. You can move, or remove it, as needed.
            this.pSelectAllBorrowedItemTableAdapter2.Fill(this.sportScienceAcademyDBallDataSetSP.PSelectAllBorrowedItem);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBallDataSet.borrowedItemTable' table. You can move, or remove it, as needed.
            this.borrowedItemTableTableAdapter.Fill(this.sportScienceAcademyDBallDataSet.borrowedItemTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBallDataSet.itemTable' table. You can move, or remove it, as needed.
            this.itemTableTableAdapter1.Fill(this.sportScienceAcademyDBallDataSet.itemTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBallDataSet.sportTable' table. You can move, or remove it, as needed.
            this.sportTableTableAdapter4.Fill(this.sportScienceAcademyDBallDataSet.sportTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBallDataSet.materialTable' table. You can move, or remove it, as needed.
            this.materialTableTableAdapter4.Fill(this.sportScienceAcademyDBallDataSet.materialTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBallDataSet.colorTable' table. You can move, or remove it, as needed.
            this.colorTableTableAdapter1.Fill(this.sportScienceAcademyDBallDataSet.colorTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBallDataSet.sizeTable' table. You can move, or remove it, as needed.
            this.sizeTableTableAdapter1.Fill(this.sportScienceAcademyDBallDataSet.sizeTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBallDataSet.brandTable' table. You can move, or remove it, as needed.
            this.brandTableTableAdapter1.Fill(this.sportScienceAcademyDBallDataSet.brandTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet14.sportTable' table. You can move, or remove it, as needed.
           // this.sportTableTableAdapter3.Fill(this.sportScienceAcademyDBDataSet14.sportTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet13.PSelectAllBorrowedItem' table. You can move, or remove it, as needed.
            //this.pSelectAllBorrowedItemTableAdapter1.Fill(this.sportScienceAcademyDBDataSet13.PSelectAllBorrowedItem);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet9.colorTable' table. You can move, or remove it, as needed.
           // this.colorTableTableAdapter.Fill(this.sportScienceAcademyDBDataSet9.colorTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet8.sizeTable' table. You can move, or remove it, as needed.
           // this.sizeTableTableAdapter.Fill(this.sportScienceAcademyDBDataSet8.sizeTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet7.brandTable' table. You can move, or remove it, as needed.
          //  this.brandTableTableAdapter.Fill(this.sportScienceAcademyDBDataSet7.brandTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet6.sportTable' table. You can move, or remove it, as needed.
          //  this.sportTableTableAdapter2.Fill(this.sportScienceAcademyDBDataSet6.sportTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet5.materialTable' table. You can move, or remove it, as needed.
          //  this.materialTableTableAdapter3.Fill(this.sportScienceAcademyDBDataSet5.materialTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet4.materialTable' table. You can move, or remove it, as needed.
          //  this.materialTableTableAdapter2.Fill(this.sportScienceAcademyDBDataSet4.materialTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet1.itemTable' table. You can move, or remove it, as needed.
           // this.itemTableTableAdapter.Fill(this.sportScienceAcademyDBDataSet1.itemTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet1.materialTable' table. You can move, or remove it, as needed.
           // this.materialTableTableAdapter1.Fill(this.sportScienceAcademyDBDataSet1.materialTable);
            // TODO: This line of code loads data into the 'sportScienceAcademyDBDataSet1.sportTable' table. You can move, or remove it, as needed.
         //   this.sportTableTableAdapter1.Fill(this.sportScienceAcademyDBDataSet1.sportTable);

        }


        private void dataGridView7_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                IDbrand = Convert.ToInt32(dataGridView7.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtBrand.Text = dataGridView7.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void dataGridView8_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                IDsize = Convert.ToInt32(dataGridView8.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtSize.Text = dataGridView8.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void dataGridView9_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                IDcolor = Convert.ToInt32(dataGridView9.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtColor.Text = dataGridView9.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void btnAddBrand_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtBrand.Text != "")
                {
                    SqlCommand cmd;
                    string materialName = txtBrand.Text;
                    cmd = new SqlCommand("insert into brandTable(brandName) values(@name)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", txtBrand.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted Successfully");

                    con.Close();
                    DisplayBrandData();
                    ClearBrandData();
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnDeleteBrand_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want to Delete This Record?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    if (IDbrand != 0 && txtBrand.Text != "")
                    {
                        cmd = new SqlCommand("delete brandTable where brandCode=@id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", IDbrand);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Material Record Deleted Successfully!");
                        DisplayBrandData();
                        ClearBrandData();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Material Record to Delete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void btnAddSize_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtSize.Text != "")
                {
                    SqlCommand cmd;
                    string materialName = txtSize.Text;
                    cmd = new SqlCommand("insert into sizeTable(sizeName) values(@name)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", txtSize.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted Successfully");

                    con.Close();
                    DisplaySizeData();
                    ClearSizeData();
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void btnDeleteSize_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want to Delete This Record?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    if (IDsize != 0 && txtSize.Text != "")
                    {
                        cmd = new SqlCommand("delete sizeTable where sizeCode=@id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", IDsize);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Material Record Deleted Successfully!");
                        DisplaySizeData();
                        ClearSizeData();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Material Record to Delete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void btnAddColor_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtColor.Text != "")
                {
                    SqlCommand cmd;
                    string materialName = txtColor.Text;
                    cmd = new SqlCommand("insert into colorTable(colorName) values(@name)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", txtColor.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted Successfully");

                    con.Close();
                    DisplayColorData();
                    ClearColorData();
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnDeleteColor_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want to Delete This Record?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    if (IDcolor != 0 && txtColor.Text != "")
                    {
                        cmd = new SqlCommand("delete colorTable where colorCode=@id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", IDcolor);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Material Record Deleted Successfully!");
                        DisplayColorData();
                        ClearColorData();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Material Record to Delete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void DisplayBrandData()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select * from brandTable", con);
                adapt.Fill(dt);
                dataGridView7.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

          
        }
        private void ClearBrandData()
        {
            txtBrand.Text = "";
            IDbrand = 0;
        }

        private void DisplaySizeData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from sizeTable", con);
            adapt.Fill(dt);
            dataGridView8.DataSource = dt;
            con.Close();
        }
        private void ClearSizeData()
        {
            txtSize.Text = "";
            IDsize = 0;
        }

        private void DisplayColorData()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select * from colorTable", con);
                adapt.Fill(dt);
                dataGridView9.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void ClearColorData()
        {
            txtColor.Text = "";
            IDcolor = 0;
        }

        private void DisplayItemData()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select * from itemTable", con);
                adapt.Fill(dt);
                dataGridView4.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void ClearItemData()
        {
            cbBrand.SelectedItem = "";
            cbSize.SelectedItem = "";
            cbColor.SelectedItem = "";
            cbName.SelectedItem = "";
            cbType.SelectedItem = "";
            txtItemQuantity.Text = "";
            txtItemDiscription.Text = "";
            IDitemTable = 0;
        }
        private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                IDitemTable = Convert.ToInt32(dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString());

                cbName.SelectedValue = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbType.SelectedValue = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbBrand.SelectedValue = dataGridView4.Rows[e.RowIndex].Cells[5].Value.ToString();
                cbSize.SelectedValue = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbColor.SelectedValue = dataGridView4.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtItemQuantity.Text = dataGridView4.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtItemDiscription.Text = dataGridView4.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            


        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemQuantity.Text != "")
                {
                    SqlCommand cmd;
                    string materialName = txtItemQuantity.Text;
                    cmd = new SqlCommand("insert into itemTable(itemName,itemSize,itemType,itemColor,itemBrand,quantity,itemDiscription) values(@name,@size,@type,@color,@brand,@quantity,@itemDiscription)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", cbName.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@size", cbSize.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@type", cbType.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@color", cbColor.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@brand", cbBrand.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtItemQuantity.Text));
                    cmd.Parameters.AddWithValue("@itemDiscription", txtItemDiscription.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted Successfully");

                    con.Close();
                    DisplayItemData();
                    DisplayBorrowedData();
                    ClearItemData();
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }
        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemQuantity.Text != "" && IDitemTable != 0)
                {
                    cmd = new SqlCommand("update itemTable set itemName=@name,itemSize=@size,itemType=@type,itemColor=@color,itemBrand=@brand,quantity=@quantity,itemDiscription=@itemDiscription where itemCode=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", IDitemTable);
                    cmd.Parameters.AddWithValue("@name", cbName.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@size", cbSize.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@type", cbType.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@color", cbColor.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@brand", cbBrand.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtItemQuantity.Text));
                    cmd.Parameters.AddWithValue("@itemDiscription", txtItemDiscription.Text);
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                    con.Close();
                    DisplayItemData();
                    DisplayBorrowedData();
                    ClearItemData();
                }
                else
                {
                    MessageBox.Show("Please Select Record to Update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want to Delete This Record?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    if (IDitemTable != 0 && txtItemQuantity.Text != "")
                    {
                        cmd = new SqlCommand("delete itemTable where itemCode=@id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", IDitemTable);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record Deleted Successfully!");
                        DisplayItemData();
                        DisplayBorrowedData();
                        ClearItemData();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record to Delete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
           
        }

        private void btnAddBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemCode.Text != "" && txtIssuerItemQuantity.Text != "")
                {
                    chkQuantityI = Convert.ToInt32(txtIssuerItemQuantity.Text);
                    if (chkQuantityI <= chkQuantityS)
                    {
                        SqlCommand cmd;
                        cmd = new SqlCommand("insert into borrowedItemTable(issuerId,fName,lName,itemCode,issueDate,returnDate,quantity) values(@iissuerId,@ifName,@ilName,@iitemCode,@iissueDate,@ireturnDate,@iquantity)", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@iissuerId", Convert.ToInt32(txtIdNumber.Text));
                        cmd.Parameters.AddWithValue("@ifName", txtIssuerFname.Text);
                        cmd.Parameters.AddWithValue("@ilName", txtIssuerLname.Text);
                        cmd.Parameters.AddWithValue("@iitemCode", Convert.ToInt32(txtItemCode.Text));
                        cmd.Parameters.AddWithValue("@iissueDate", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue("@ireturnDate", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue("@iquantity", Convert.ToInt32(txtIssuerItemQuantity.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted Successfully");
                        con.Close();
                        DisplayIssuerBorrowedData();
                    }
                    else
                    {
                        MessageBox.Show("check the quantity !");
                    }


                }
                else
                {
                    MessageBox.Show("Please Provide Details check quantity!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }
        private void dataGridView5_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtItemCode.Text = dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtIssuerItemQuantity.Text = dataGridView5.Rows[e.RowIndex].Cells[6].Value.ToString();
                chkQuantityS = Convert.ToInt32(dataGridView5.Rows[e.RowIndex].Cells[6].Value.ToString());
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
       
          
        }
        private void DisplayBorrowedData()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select * from itemTable", con);
                adapt.Fill(dt);
                dataGridView5.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void ClearBorrowedData()
        {
            txtIdNumber.Text = "";
            txtIssuerFname.Text = "";
            txtIssuerLname.Text = "";
            txtItemCode.Text = "";
            txtIssuerItemQuantity.Text = "";
        }

        private void dataGridView6_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                borrowCode = Convert.ToInt32(dataGridView6.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtSearchedFname.Text = dataGridView6.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSearchedLname.Text = dataGridView6.Rows[e.RowIndex].Cells[3].Value.ToString();

                txtSearchedItemIssueCode.Text = dataGridView6.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtSearchedItemName.Text = dataGridView6.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtSearchedItemType.Text = dataGridView6.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSearchedItemColor.Text = dataGridView6.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtSearchedItemSize.Text = dataGridView6.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtSearchedItemBrand.Text = dataGridView6.Rows[e.RowIndex].Cells[9].Value.ToString();

                txtSearchedItemQuantity.Text = dataGridView6.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtSearchedItemIssueDate.Text = dataGridView6.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtSearchedItemReturnDate.Text = dataGridView6.Rows[e.RowIndex].Cells[12].Value.ToString();
                txtBorrowDiscription.Text = dataGridView6.Rows[e.RowIndex].Cells[13].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }
        private void DisplayIssuerBorrowedData()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select borrowCode,issuerId,fName,lName,borrowedItemTable.itemCode, itemName, itemType, itemColor, itemSize, itemBrand,borrowedItemTable.quantity,issueDate,returnDate,itemDiscription from borrowedItemTable INNER JOIN itemTable ON borrowedItemTable.itemCode = itemTable.itemCode", con);
                adapt.Fill(dt);
                dataGridView6.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }
        private void DisplayIssuerBorrowedDataSearch()
        {
            try
            {
                int a = Convert.ToInt32(txtIsuuerIdSearch.Text);
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select borrowCode,issuerId,fName,lName,borrowedItemTable.itemCode, itemName, itemType, itemColor, itemSize, itemBrand,borrowedItemTable.quantity,issueDate,returnDate,itemDiscription from borrowedItemTable INNER JOIN itemTable ON borrowedItemTable.itemCode = itemTable.itemCode where issuerId=" + a + "", con);
                adapt.Fill(dt);
                dataGridView6.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }
        private void ClearIssuerBorrowedData()
        {
            txtItemCode.Text = "";
            txtItemQuantity.Text = "";

            txtIdNumber.Text = "";
            txtIssuerFname.Text = "";
            txtIssuerLname.Text = "";
            txtItemCode.Text = "";
            txtIssuerItemQuantity.Text = "";
        }
 
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayIssuerBorrowedDataSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchedItemQuantity.Text != "")
                {
                    cmd = new SqlCommand("update borrowedItemTable set quantity=@quantity where borrowCode=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", borrowCode);
                    cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtSearchedItemQuantity.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    cmd = new SqlCommand("update itemTable set itemDiscription=@itemDiscription where itemCode=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtSearchedItemIssueCode.Text));
                    cmd.Parameters.AddWithValue("@itemDiscription", txtBorrowDiscription.Text );
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Borrowed Item Record Updated Successfully");
                    con.Close();
                    DisplayIssuerBorrowedData();
                }
                else
                {
                    MessageBox.Show("Please Select Record to Update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }
        private void btnDeleteBorrowedItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want to Delete This Record?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    if (borrowCode != 0)
                    {
                        cmd = new SqlCommand("delete borrowedItemTable where borrowCode=@id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", borrowCode);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Borrowed Item Record Deleted Successfully!");
                        DisplayIssuerBorrowedData();
                        ClearItemData();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record to Delete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
        private void btnSearchBorrowingItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayIssuerBorroweingDataSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void DisplayIssuerBorroweingDataSearch()
        {
            
            try
            {
               
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select itemName,itemSize,itemType,itemColor,itemBrand,quantity,itemDiscription from itemTable where itemName LIKE" + txtSearchBorrowingItem.Text + "%"+"", con);
                adapt.Fill(dt);
                dataGridView5.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }



        private void btnAddManual_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtUserIdManual.Text != "" && txtItemNameManual.Text != "")
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("insert into manualBorrowing (issuerId,fName,lName,issueDate,quantity,itemName,itemDiscription) values(@iissuerId,@ifName,@ilName,@iissueDate,@iquantity,@iitemName,@iitemDiscription)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@iissuerId", Convert.ToInt32(txtUserIdManual.Text));

                    cmd.Parameters.AddWithValue("@ifName", txtFnameManual.Text);

                    cmd.Parameters.AddWithValue("@ilName", txtLnameManual.Text);

                    cmd.Parameters.AddWithValue("@iissueDate", DateTime.Now.ToString());

                    cmd.Parameters.AddWithValue("@iquantity", Convert.ToInt32(txtQuantityManual.Text));

                    cmd.Parameters.AddWithValue("@iitemName", txtItemNameManual.Text);
                    cmd.Parameters.AddWithValue("@iitemDiscription", txtDiscriptionManual.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted Successfully");
                    con.Close();
                    DisplayManualBorrowedData();
                    ClearManualyBorrowedDataTextbox();
                }
                else
                {
                    MessageBox.Show("Please Provide Details check quantity!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnSearchManual_Click_1(object sender, EventArgs e)
        {
            try
            {
                DisplayIssuerBorroweingManualDataSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnUpdateManual_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtUserIdManual.Text != "" && txtItemNameManual.Text != "")
                {

                    cmd = new SqlCommand("update manualBorrowing set issuerId=@iissuerId,fName=@ifName,lName=@ilName,issueDate=@iissueDate,quantity=@iquantity,itemName=@iitemName,itemDiscription=@iitemDiscription where borrowCode=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", manualId);
                    cmd.Parameters.AddWithValue("@iissuerId", Convert.ToInt32(txtUserIdManual.Text));
                    cmd.Parameters.AddWithValue("@ifName", txtFnameManual.Text);
                    cmd.Parameters.AddWithValue("@ilName", txtLnameManual.Text);
                    cmd.Parameters.AddWithValue("@iissueDate", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@iquantity", Convert.ToInt32(txtQuantityManual.Text));
                    cmd.Parameters.AddWithValue("@iitemName", txtItemNameManual.Text);
                    cmd.Parameters.AddWithValue("@iitemDiscription", txtDiscriptionManual.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Borrowed Item Record Updated Successfully");
                    con.Close();
                    DisplayManualBorrowedData();
                    ClearManualyBorrowedDataTextbox();

                }
                else
                {
                    MessageBox.Show("Please Select Record to Update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnDeleteManual_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want to Delete This Record?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    if (manualId != 0 && txtUserIdManual.Text != "")
                    {
                        cmd = new SqlCommand("delete manualBorrowing where borrowCode=@id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", manualId);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Borrowed Item Record Deleted Successfully!");
                        DisplayManualBorrowedData();
                        ClearManualyBorrowedDataTextbox();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record to Delete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
        private void dataGridView3_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                manualId = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtUserIdManual.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtFnameManual.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtLnameManual.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtQuantityManual.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtItemNameManual.Text = dataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtDiscriptionManual.Text = dataGridView3.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void ClearManualyBorrowedDataTextbox()
        {
            txtUserIdManual.Text = "";
            txtFnameManual.Text = "";
            txtLnameManual.Text = "";
            txtQuantityManual.Text = "";
            txtItemNameManual.Text = "";
            txtDiscriptionManual.Text = "";
            manualId = 0;

        }
        private void DisplayIssuerBorroweingManualDataSearch()
        {

            try
            {

                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select borrowCode,issuerId,fName,lName,issueDate,quantity,itemName,itemDiscription from manualBorrowing where issuerId=" + txtUserIdManual.Text + "", con);
                adapt.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void DisplayManualBorrowedData()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select borrowCode,issuerId,fName,lName,issueDate,quantity,itemName,itemDiscription from manualBorrowing", con);
                adapt.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
       


        private void txtUserIdManual_TextChanged(object sender, EventArgs e)
        {
            DisplayManualBorrowedData();
        }
        private void txtFnameManual_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.Match(txtFnameManual.Text, @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
            {
                // first name was incorrect
                MessageBox.Show("Invalid first name", "Message");
                txtFnameManual.Text = "";
                txtFnameManual.Focus();
                return;
            } // e
        }
        private void txtLnameManual_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.Match(txtLnameManual.Text, @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
            {
                // first name was incorrect
                MessageBox.Show("Invalid first name", "Message");
                txtLnameManual.Text = "";
                txtLnameManual.Focus();
                return;
            } // e
        }
        private void txtItemNameManual_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.Match(txtItemNameManual.Text, @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
            {
                // first name was incorrect
                MessageBox.Show("Invalid first name", "Message");
                txtItemNameManual.Text = "";
                txtItemNameManual.Focus();
                return;
            } // e
        }
        private void txtDiscriptionManual_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.Match(txtDiscriptionManual.Text, @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
            {
                // first name was incorrect
                MessageBox.Show("Invalid first name", "Message");
                txtDiscriptionManual.Text = "";
                txtDiscriptionManual.Focus();
                return;
            } // e
        }

        private void txtSearchBorrowingItem_TextChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select itemName,itemSize,itemType,itemColor,itemBrand,quantity,itemDiscription from itemTable where itemName =" + txtSearchBorrowingItem.Text + "", con);
                adapt.Fill(dt);
                dataGridView5.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
