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
    public partial class frmurun_ekle : Form
    {
        public frmurun_ekle()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-1MBBQE4\\SQLEXPRESS;Initial Catalog=urun_takip;Integrated Security=True");
        private void frmurun_ekle_Load(object sender, EventArgs e)
        {
            baglan.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_kategoriler", baglan);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_urunler (ürünad,katid) values (@p1,@p2)",baglan);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtkatid.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Ürün Kaydı Yapıldı");
        }
    }
}
