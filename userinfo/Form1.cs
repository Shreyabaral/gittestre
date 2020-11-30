using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace userinfo
{
    public partial class Form1 : Form
    {
        string name,phone,address;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btndisplay_Click(object sender, EventArgs e)
        {
            name = txtName.Text;
            address = txtAddress.Text;
            phone = txtPhone.Text;
            
            
            MessageBox.Show(" Full Name:" + name + "\r\n" + "\r\n"
                + "Address:" + address + "\r\n" + "\r\n"
                + "Phone Number :" + phone, "Your Info") ;
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
