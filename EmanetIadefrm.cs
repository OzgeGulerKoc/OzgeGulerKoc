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

namespace OzgeKoc
{
    public partial class EmanetIadefrm : Form
    {
        public EmanetIadefrm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-CG2IUJ7;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();
        private void EmanetIadefrm_Load(object sender, EventArgs e)
        {
            EmanetListele();
        }
        private void EmanetListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from EmanetKitaplar", baglanti);
            adtr.Fill(daset, "EmanetKitaplar");
            dataGridView1.DataSource = daset.Tables["EmanetKitaplar"];
            baglanti.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["EmanetKitaplar"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from EmanetKitaplar where tc like'%"+txtTcAra.Text+"%'", baglanti);
            adtr.Fill(daset,"EmanetKitaplar");
            baglanti.Close();
            if (txtTcAra.Text=="")
            {
                daset.Tables["EmanetKitaplar"].Clear();
                EmanetListele();
            }
        }

        private void txtBarkodAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["EmanetKitaplar"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from EmanetKitaplar where barkodno like'%" + txtBarkodAra.Text + "%'", baglanti);
            adtr.Fill(daset, "EmanetKitaplar");
            baglanti.Close();
            if (txtBarkodAra.Text == "")
            {
                daset.Tables["EmanetKitaplar"].Clear();
                EmanetListele();
            }
        }

        private void btnTeslimAl_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from EmanetKitaplar where tc=@tc and barkodno=@barkodno", baglanti);
            komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
            komut.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand("update Kitap set stoksayisi = stoksayisi+'"+dataGridView1.CurrentRow.Cells["kitapsayisi"].Value.ToString()+"' where barkodno=@barkodno ", baglanti);
            komut2.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitaplar iade edildi.");
            daset.Tables["EmanetKitaplar"].Clear();
            EmanetListele();

        }
    }
}
