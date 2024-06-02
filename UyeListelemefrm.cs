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
    public partial class UyeListelemefrm : Form
    {
        public UyeListelemefrm()
        {
            InitializeComponent();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UyeListelemefrm_Load(object sender, EventArgs e)
        {
            uyelistele();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-CG2IUJ7;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True");
        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from uye where tc like'" + txtTc.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while(read.Read())
            {
                txtAdSoyad.Text = read["adsoyad"].ToString();
                txtYas.Text = read["yas"].ToString();
                comboCinsiyet.Text = read["cinsiyet"].ToString();
                txtTelefon.Text = read["telefon"].ToString();
                txtAdres.Text = read["adres"].ToString();
                txtEmail.Text = read["email"].ToString();
                txtOkunanKitap.Text = read["okukitapsayisi"].ToString();
            }
            baglanti.Close();
        }
        DataSet daset = new DataSet();
        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["uye"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from uye where tc like'%" + txtTcAra.Text + "%'",baglanti);
            adtr.Fill(daset,"uye");
            dataGridView1.DataSource = daset.Tables["uye"];
            baglanti.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from uye where tc=@tc", baglanti);
            komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi başarılı!");
            daset.Tables["uye"].Clear();
            uyelistele();
            foreach (Control item in Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void uyelistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from uye", baglanti);
            adtr.Fill(daset, "uye");
            dataGridView1.DataSource = daset.Tables["uye"];
            baglanti.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update uye set adsoyad=@adsoyad,yas=@yas,cinsiyet=@cinsiyet,telefon=@telefon,adres=@adres,email=@email,okukitapsayisi=@okukitapsayisi where tc=@tc", baglanti);
            komut.Parameters.AddWithValue("@tc", txtTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@yas", txtYas.Text);
            komut.Parameters.AddWithValue("@cinsiyet", comboCinsiyet.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@email", txtEmail.Text);
            komut.Parameters.AddWithValue("@okukitapsayisi", int.Parse(txtOkunanKitap.Text));
            komut.ExecuteNonQuery(); 
            baglanti.Close();
            daset.Tables["uye"].Clear();
            uyelistele();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
    }
}
