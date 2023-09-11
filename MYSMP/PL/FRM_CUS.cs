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
    public partial class FRM_CUS : Form
    {
        ICE_DBEntities db = new ICE_DBEntities();
        TBL_CUS tbl_cus = new TBL_CUS();
        public FRM_CUS()
        {
            InitializeComponent();
        }

        private void FRM_CUS_Activated(object sender, EventArgs e)
        {
            DGV.DataSource = db.TBL_CUS.ToList();
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
            tbl_cus.Name = txt_name.Text;
            tbl_cus.Email = txt_email.Text;
            tbl_cus.Address = txt_address.Text;
            tbl_cus.Phone = txt_phone.Text;
            tbl_cus.Gender = cbo_gender.Text;
            db.TBL_CUS.Add(tbl_cus);
            db.SaveChanges();
            MessageBox.Show("Customer Added!!");
            Clear();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value);
            tbl_cus = db.TBL_CUS.Where(x => x.ID == id).FirstOrDefault();
            txt_name.Text = tbl_cus.Name;
            txt_email.Text = tbl_cus.Email;
            txt_phone.Text = tbl_cus.Phone;
            txt_address.Text = tbl_cus.Address;
            cbo_gender.Text = tbl_cus.Gender;
        }

        private void btn_edite_Click(object sender, EventArgs e)
        {
            tbl_cus.Name = txt_name.Text;
            tbl_cus.Email = txt_email.Text;
            tbl_cus.Phone = txt_phone.Text;
            tbl_cus.Address = txt_address.Text;
            tbl_cus.Gender = cbo_gender.Text;
            db.Entry(tbl_cus).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("Customer Edited!!");
            Clear();
        }


        public void Clear()
        {
            txt_name.Text = "";
            txt_email.Text = "";
            txt_phone.Text = "";
            txt_address.Text = "";
            cbo_gender.Text = "";
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value);
            tbl_cus = db.TBL_CUS.Where(x => x.ID == id).FirstOrDefault();
            db.Entry(tbl_cus).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            MessageBox.Show("Customer Deleted!!");
            Clear();
            }
        }
    }

