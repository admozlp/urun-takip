using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            frmurun_ekle fr = new frmurun_ekle();
            fr.Show();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-1MBBQE4\\SQLEXPRESS;Initial Catalog=urun_takip;Integrated Security=True");
        
        private void button3_Click(object sender, EventArgs e)
        {
            frmkategori_ekle fr = new frmkategori_ekle();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblsonuc.Text = "";
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select ürünad From tbl_urunler where ürünad=@p1",baglan);
            komut.Parameters.AddWithValue("@p1", txturunad.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                lblsonuc.Text = "Ürün Mevcut";
            }
            else
                lblsonuc.Text = "Ürün Mevcut Değil";

            baglan.Close();
        }
    }
}
