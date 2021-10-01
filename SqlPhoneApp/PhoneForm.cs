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
    public partial class PhoneForm : Form
    {
        public PhoneForm()
        {
            InitializeComponent();
        }
        DirectoryItem aDirectoryItem = null;
        string flag = "Add";
        bool oKtoDelete = false;
        private void PhoneForm_Load(object sender, EventArgs e)
        {

        }

        public DirectoryItem Add()
        {
            this.ShowDialog();

            return aDirectoryItem;
        }

        public void Edit(DirectoryItem directoryItem)
        {
            this.Text = "Edit Phone Entry";
            btnAction.Text = "Modify";
            flag = "Edit";
            aDirectoryItem = directoryItem;

            txtFirstName.Text = directoryItem.FirstName;
            txtLastname.Text = directoryItem.LastName;
            txtPhoneNumber.Text = directoryItem.PhoneNumber;
            txtDepartment.Text = directoryItem.Dept;
            cboActive.Checked = directoryItem.Active;


            this.ShowDialog();

        }
        private void btnAction_Click(object sender, EventArgs e)
        {
            string fName;
            string lName;
            string phone;
            string dept;
            bool active;

            try
            {
                fName = txtFirstName.Text;
                lName = txtLastname.Text;
                phone = txtPhoneNumber.Text;
                dept = txtDepartment.Text;
                active = cboActive.Checked;

                if (flag == "Add")
                {
                    aDirectoryItem = new DirectoryItem(fName, lName, phone, dept);
                    aDirectoryItem.Active = active;
                }
                else if (flag == "Edit")
                {
                    aDirectoryItem.FirstName = fName;
                    aDirectoryItem.LastName = lName;
                    aDirectoryItem.PhoneNumber = phone;
                    aDirectoryItem.Dept = dept;
                    aDirectoryItem.Active = active;

                }
                else
                {
                    DialogResult = MessageBox.Show("Is Ok to Delete ", "Delete Entry?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (DialogResult == DialogResult.Yes)
                    {
                        oKtoDelete = true;
                    }
                }

                this.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("SQL Error");
            }
            catch(FieldAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (PhoneNumberException ex)
            {
                MessageBox.Show(ex.Message);
                txtPhoneNumber.Focus();
                txtPhoneNumber.SelectAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal bool Delete(DirectoryItem directoryItem)
        {
           this.Text = "Delete Phone Entry";
            btnAction.Text = "Delete";

            flag = "Delete";
            aDirectoryItem = directoryItem;

            txtFirstName.Text = directoryItem.FirstName;
            txtLastname.Text = directoryItem.LastName;
            txtPhoneNumber.Text = directoryItem.PhoneNumber;
            txtDepartment.Text = directoryItem.Dept;

            this.ShowDialog();

            return oKtoDelete;
        }
    }
}
