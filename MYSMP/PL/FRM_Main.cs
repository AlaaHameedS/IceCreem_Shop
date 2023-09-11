using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYSMP.PL
{
    public partial class FRM_Main : Form
    {
        PL.FRM_CUS cus = new FRM_CUS();
        public FRM_Main()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            cus.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            PL.FRM_FLAV flav = new FRM_FLAV();
            flav.Show();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            PL.FRM_ITEM item = new FRM_ITEM();
            item.Show();
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            PL.FRM_ORDER order = new FRM_ORDER();
            order.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void P_LOGIN_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            PL.FRM_ORDER order = new FRM_ORDER();
            order.Show();
            this.Hide();

        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        {
            cus.Show();
            this.Hide();
        }

        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {

            PL.FRM_FLAV flav = new FRM_FLAV();
            flav.Show();
            this.Hide();
        }

        private void bunifuImageButton4_Click_1(object sender, EventArgs e)
        {

            PL.FRM_ITEM item = new FRM_ITEM();
            item.Show();
            this.Hide();
        }

        private void bunifuImageButton5_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
