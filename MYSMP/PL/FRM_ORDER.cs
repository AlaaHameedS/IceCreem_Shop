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
    public partial class FRM_ORDER: Form
    {
        ICE_DBEntities db = new ICE_DBEntities();
        TBL_CUS tbl_cus = new TBL_CUS();
        TBL_ITEM tbl_item = new TBL_ITEM();
        TBL_BILL tbl_bill = new TBL_BILL();
        
        public static int n = 1;
        
        public FRM_ORDER()
        {
            InitializeComponent();
        }

        private void FRM_CUS_Activated(object sender, EventArgs e)
        {
            cbo_cus.DataSource = db.TBL_CUS.Select(x => x.Name).ToList();
            DGVIce.DataSource = db.TBL_ITEM.ToList();
            cbo_cus.SelectedIndex = -1;
       
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
            //tbl_cus.Name = txt_name.Text;
            //tbl_cus.Email = txt_email.Text;
            //tbl_cus.Address = txt_address.Text;
            //tbl_cus.Phone = txt_phone.Text;
            //tbl_cus.Gender = cbo_gender.Text;
            //db.TBL_CUS.Add(tbl_cus);
            //db.SaveChanges();
            //MessageBox.Show("Customer Added!!");
            //Clear();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //var id = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value);
            //tbl_cus = db.TBL_CUS.Where(x => x.ID == id).FirstOrDefault();
            //txt_name.Text = tbl_cus.Name;
            //txt_email.Text = tbl_cus.Email;
            //txt_phone.Text = tbl_cus.Phone;
            //txt_address.Text = tbl_cus.Address;
            //cbo_gender.Text = tbl_cus.Gender;
        }

        private void btn_edite_Click(object sender, EventArgs e)
        {
            //tbl_cus.Name = txt_name.Text;
            //tbl_cus.Email = txt_email.Text;
            //tbl_cus.Phone = txt_phone.Text;
            //tbl_cus.Address = txt_address.Text;
            //tbl_cus.Gender = cbo_gender.Text;
            //db.Entry(tbl_cus).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            //MessageBox.Show("Customer Edited!!");
            //Clear();
        }


        public void Clear()
        {
            //txt_name.Text = "";
            //txt_email.Text = "";
            //txt_phone.Text = "";
            //txt_address.Text = "";
            //cbo_gender.Text = "";
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //var id = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value);
            //tbl_cus = db.TBL_CUS.Where(x => x.ID == id).FirstOrDefault();
            //db.Entry(tbl_cus).State = System.Data.Entity.EntityState.Deleted;
            //db.SaveChanges();
            //MessageBox.Show("Customer Deleted!!");
            //Clear();
            }

        private void DGVIce_DoubleClick(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(DGVIce.CurrentRow.Cells[0].Value);
            tbl_item = db.TBL_ITEM.Where(x => x.itCod == id).FirstOrDefault();
            txt_item.Text = tbl_item.Name;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            
             double total = Convert.ToDouble( DGVIce.CurrentRow.Cells[3].Value);
              

            double qu = Convert.ToDouble(txt_quant.Text);
            double totalPrice =0;

            this.DGVBill.Rows.Add(n++, txt_item.Text, total, txt_quant.Text, total * qu);

            
            for (int i = 0; i<DGVBill.Rows.Count; i++)
            {

                totalPrice  +=  Convert.ToInt32 ( DGVBill.Rows[i].Cells[4].Value);


            }
            lbl_amount.Text = totalPrice.ToString();







        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < DGVBill.Rows.Count; i++)
            {
                tbl_bill.Item = DGVBill.Rows[i].Cells[1].Value.ToString();
                tbl_bill.Price = Convert.ToInt32(DGVBill.Rows[i].Cells[2].Value);
                tbl_bill.Quantity = Convert.ToInt32(DGVBill.Rows[i].Cells[3].Value);
                tbl_bill.Total = Convert.ToInt32(DGVBill.Rows[i].Cells[4].Value);
                db.TBL_BILL.Add(tbl_bill);
                db.SaveChanges();
                MessageBox.Show("Bill Save!!");


            }

        }
    }
    }

