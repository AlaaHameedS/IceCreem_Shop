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
    public partial class FRM_ITEM: Form
    {
        ICE_DBEntities db = new ICE_DBEntities();
        TBL_ITEM tbl_item = new TBL_ITEM();
        TBL_FLAV tbl_flav = new TBL_FLAV();
        public FRM_ITEM()
        {
            InitializeComponent();
        }

        private void FRM_CUS_Activated(object sender, EventArgs e)
        {
            
            cbo_flav.DataSource = db.TBL_FLAV.Select(x => x.FName).ToList();
            DGV.DataSource = db.TBL_ITEM.ToList();
            cbo_flav.SelectedIndex = -1;
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
            tbl_item.Name = txt_name.Text;
            tbl_item.Decsription = txt_desc.Text;
            tbl_item.Price =Convert.ToInt32( txt_price.Text);
            tbl_item.ExpDate = ExpDate.Value;
            tbl_item.Flavor = cbo_flav.Text;
            tbl_item.Size = txt_size.Text;
            db.TBL_ITEM.Add(tbl_item);
            db.SaveChanges();
            MessageBox.Show("Item Added!!");
            Clear();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value);
            tbl_item = db.TBL_ITEM.Where(x => x.itCod == id).FirstOrDefault();
            txt_name.Text = tbl_item.Name ;
            txt_desc.Text = tbl_item.Decsription ;
            txt_price.Text = tbl_item.Price.ToString() ;
            ExpDate.Value =  Convert.ToDateTime( tbl_item.ExpDate);
            cbo_flav.Text = tbl_item.Flavor ;
           txt_size.Text = tbl_item.Size ;
        }

        private void btn_edite_Click(object sender, EventArgs e)
        {
            tbl_item.Name = txt_name.Text;
            tbl_item.Decsription = txt_desc.Text;
            tbl_item.Price = Convert.ToInt32(txt_price.Text);
            tbl_item.ExpDate = ExpDate.Value;
            tbl_item.Flavor = cbo_flav.Text;
            tbl_item.Size = txt_size.Text;
            db.Entry(tbl_item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("Item Edited!!");
            Clear();
        }


        public void Clear()
        {
            txt_name.Text = "";
            txt_desc.Text = "";
            txt_price.Text = "";
            txt_size.Text = "";
            cbo_flav.SelectedIndex = -1;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value);
            tbl_item = db.TBL_ITEM.Where(x => x.itCod == id).FirstOrDefault();
            db.Entry(tbl_item).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            MessageBox.Show("Items Deleted!!");
            Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    }

