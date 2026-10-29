using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_Reservation_System.Database;
using Hotel_Reservation_System.Models;

namespace Hotel_Reservation_System.Forms
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            guna2Panel1.AutoScroll = true;
            guna2Panel1.Resize += guna2Panel1_Resize;
            pictureBox1.Anchor = pictureBox2.Anchor = pictureBox3.Anchor = pictureBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LayoutReportCards();
            LoadReport();
        }

        private void guna2Panel1_Resize(object? sender, EventArgs e)
        {
            LayoutReportCards();
        }

        private void LayoutReportCards()
        {
            if (guna2Panel1.ClientSize.Width <= 0)
                return;

            const int margin = 19;
            const int gap = 12;
            const int cardTop = 112;
            const int cardHeight = 129;

            int contentWidth = Math.Max(1, guna2Panel1.ClientSize.Width - margin * 2);
            int columnCount = contentWidth >= 1000 ? 4 : 2;
            int cardWidth = Math.Max(180, (contentWidth - gap * (columnCount - 1)) / columnCount);
            Guna.UI2.WinForms.Guna2CustomGradientPanel[] cards =
            {
                guna2CustomGradientPanel1,
                guna2CustomGradientPanel2,
                guna2CustomGradientPanel3,
                guna2CustomGradientPanel4
            };

            for (int i = 0; i < cards.Length; i++)
            {
                int column = i % columnCount;
                int row = i / columnCount;
                cards[i].Location = new Point(margin + column * (cardWidth + gap), cardTop + row * (cardHeight + gap));
                cards[i].Size = new Size(cardWidth, cardHeight);
            }
        }

        private void LoadReport()
        {
            Report report = ReportDAO.GetReportData();

            lblTotalRooms.Text = report.TotalRooms.ToString();
            lblOccupiedRooms.Text = report.OccupiedRooms.ToString();
            lblAvailableRooms.Text = report.AvailableRooms.ToString();
            lblTotalRevenue.Text = "₱ " + report.TotalRevenue.ToString("N2");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
