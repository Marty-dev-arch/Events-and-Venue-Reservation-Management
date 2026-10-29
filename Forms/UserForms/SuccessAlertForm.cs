using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hotel_Reservation_System.Forms.UserForms
{
    public partial class SuccessAlertForm : Form
    {
        public SuccessAlertForm(string title, string message)
        {
            InitializeComponent();

            lblTitle.Text = title;
            lblMessage.Text = message;
        }

        private void SuccessAlertForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
