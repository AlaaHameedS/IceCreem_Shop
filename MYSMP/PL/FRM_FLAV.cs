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
    public partial class FRM_FLAV : Form
    {
        ICE_DBEntities db = new ICE_DBEntities();
        TBL_FLAV tbl_flav = new TBL_FLAV();
        public FRM_FLAV()
        {
            InitializeComponent();
        }

        private void FRM_CUS_Activated(object sender, EventArgs e)
        {
            DGV.DataSource = db.TBL_FLAV.ToList();
            db.SaveChanges();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PL.FRM_Main main = new FRM_Main();
            main.Show();
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           tbl_flav.FName = txt_name.Text;
            tbl_flav.FDescription = txt_desc.Text;
            
            db.TBL_FLAV.Add(tbl_flav);
            db.SaveChanges();
            MessageBox.Show("Flavoers Added!!");
            Clear();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value);
            tbl_flav = db.TBL_FLAV.Where(x => x.FID == id).FirstOrDefault();
            txt_name.Text = tbl_flav.FName;
            txt_desc.Text = tbl_flav.FDescription;
            
        }

        private void btn_edite_Click(object sender, EventArgs e)
        {
            tbl_flav.FName = txt_name.Text;
            tbl_flav.FDescription = txt_desc.Text;
            
            db.Entry(tbl_flav).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("Flavores Edited!!");
            Clear();
        }


        public void Clear()
        {
            txt_name.Text = "";
            txt_desc.Text = "";
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value);
            tbl_flav = db.TBL_FLAV.Where(x => x.FID == id).FirstOrDefault();
            db.Entry(tbl_flav).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            MessageBox.Show("Flavores Deleted!!");
            Clear();
            }
        }
    }

