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
    public partial class FRM_LOGIN : Form
    {

        ICE_DBEntities db = new ICE_DBEntities();
        TBL_LOGIN tbl_login = new TBL_LOGIN();
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            tbl_login = db.TBL_LOGIN.Where(x => x.Username == txt_user.Text && x.Password == txt_pass.Text).FirstOrDefault();
            if(tbl_login != null)
            {
                PL.FRM_Main main = new FRM_Main();
                main.Show();
                this.Close();
            }
        }
    }
}
