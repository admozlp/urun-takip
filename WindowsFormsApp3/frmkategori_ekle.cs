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
    public partial class frmkategori_ekle : Form
    {
        public frmkategori_ekle()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-1MBBQE4\\SQLEXPRESS;Initial Catalog=urun_takip;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_kategoriler (kategoriad) values (@p1)", baglan);
            komut.Parameters.AddWithValue("@p1",txtkategori.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Kategori Eklendi");
        }
    }
}
