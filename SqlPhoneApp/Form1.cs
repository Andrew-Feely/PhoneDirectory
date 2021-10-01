using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlPhoneApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<DirectoryItem> allItems = new List<DirectoryItem>();
        PhoneItems phoneItems = new PhoneItems();
        DirectoryItem selectedItem = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            allItems = phoneItems.GetAll();

            DisplayPhoneItems();
        }

        private void DisplayPhoneItems()
        {
            lstPhoneItems.Items.Clear();

            foreach(DirectoryItem d in allItems)
            {
                lstPhoneItems.Items.Add(d);
            }
        }

        private void btnAddListing_Click(object sender, EventArgs e)
        {
            PhoneForm frmAddPhoneEntry = new PhoneForm();

            try
            {
                DirectoryItem directoryItem = frmAddPhoneEntry.Add();

                if (directoryItem != null)
                {
                    // add to the collection Class
                    phoneItems.Add(directoryItem);
                    // update the view
                    DisplayPhoneItems();
                }
                else
                {
                    MessageBox.Show("No item added", "Alert!");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + "Came from the da class");
            }
            catch (FieldAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PhoneForm frmEditPhoneEntry = new PhoneForm();

            frmEditPhoneEntry.Edit(selectedItem);
            //update the database
            phoneItems.Edit(selectedItem);  // modify the collection class and updates the database

            DisplayPhoneItems();

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }

        private void lstPhoneItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = (DirectoryItem)lstPhoneItems.SelectedItem;

            if(selectedItem != null)
            {
                //enable the button
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PhoneForm frmDeletePhoneEntry = new PhoneForm();
            bool oKtoDelete;

            // todo: needs work
            oKtoDelete = frmDeletePhoneEntry.Delete(selectedItem); // Calls the for to shows the item to delete

            if (oKtoDelete)
            {
                phoneItems.Delete(selectedItem);

                DisplayPhoneItems();
            }

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
