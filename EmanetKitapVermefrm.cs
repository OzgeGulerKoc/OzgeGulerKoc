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
    public partial class EmanetKitapVermefrm : Form
    {
        public EmanetKitapVermefrm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-CG2IUJ7;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void sepetListele() 
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from sepet", baglanti);
            adtr.Fill(daset, "sepet");
            dataGridView1.DataSource = daset.Tables["sepet"];
            baglanti.Close();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into sepet(barkodno,kitapadi,yazari,yayinevi,sayfasayisi,kitapsayisi,teslimtarihi,iadetarihi) values(@barkodno,@kitapadi,@yazari,@yayinevi,@sayfasayisi,@kitapsayisi,@teslimtarihi,@iadetarihi) ", baglanti);
            komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
            komut.Parameters.AddWithValue("@kitapadi", txtKitapAdi.Text);
            komut.Parameters.AddWithValue("@yazari", txtYazari.Text);
            komut.Parameters.AddWithValue("@yayinevi", txtYayinEvi.Text);
            komut.Parameters.AddWithValue("@sayfasayisi", txtSayfaSayisi.Text);
            komut.Parameters.AddWithValue("@kitapsayisi", int.Parse(txtKitapSayisi.Text));
            komut.Parameters.AddWithValue("@teslimtarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@iadetarihi", dateTimePicker2.Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap(lar) sepete eklendi.", "Ekleme işlemi");
            daset.Tables["sepet"].Clear();
            sepetListele();
            lblkitapsayi.Text = "";
            kitapsayisi();
            foreach (Control item in grpKitapBilgi.Controls)
            {
                if (item is TextBox)
                {
                    if (item!=txtKitapSayisi)
                    {
                        item.Text = "";
                    }
                }
            }
        }

        private void EmanetKitapVermefrm_Load(object sender, EventArgs e)
        {
            sepetListele();
        }

        private void kitapsayisi() 
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(kitapsayisi) from sepet", baglanti);
            lblkitapsayi.Text = komut.ExecuteScalar().ToString();
            baglanti.Close();
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from uye where tc like '" + txtTcAra.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtAdSoyad.Text = read["adsoyad"].ToString();
                txtYas.Text = read["yas"].ToString();
                txtTelefon.Text = read["telefon"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(kitapsayisi) from emanetkitaplar where tc='"+txtTcAra.Text+"'", baglanti);
            lblKayitliKitapSayisi.Text = komut2.ExecuteScalar().ToString();
            baglanti.Close();
            if (txtTcAra.Text=="")
            {
                foreach (Control item in grpUyeBilgileri.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                        lblKayitliKitapSayisi.Text = "";
                    }
                }
            }
        }

        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from kitap where barkodno like '" + txtBarkodNo.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtKitapAdi.Text = read["kitapadi"].ToString();
                txtYazari.Text = read["yazari"].ToString();
                txtYayinEvi.Text = read["yayinevi"].ToString();
                txtSayfaSayisi.Text = read["sayfasayisi"].ToString();               
            }
            baglanti.Close();
            if (txtBarkodNo.Text=="")
            {
                foreach (Control item in grpKitapBilgi.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtKitapSayisi)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from sepet where barkodno='"+dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString()+"'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi yapıldı.", "Silme İşlemi");
            daset.Tables["sepet"].Clear();
            sepetListele();
            lblkitapsayi.Text = "";
            kitapsayisi();
        }

        private void btnTeslimEt_Click(object sender, EventArgs e)
        {
            if (lblkitapsayi.Text != "") 
            {
                if(lblKayitliKitapSayisi.Text=="" && int.Parse(lblkitapsayi.Text) <= 3 || lblKayitliKitapSayisi.Text != "" && int.Parse(lblKayitliKitapSayisi.Text)+int.Parse(lblkitapsayi.Text)<=3) 
                {
                    if (txtTcAra.Text!="" && txtAdSoyad.Text!="" && txtYas.Text!="" && txtTelefon.Text!="")
                    {

                        for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                        {
                            baglanti.Open();
                            SqlCommand komut = new SqlCommand("insert into emanetkitaplar(tc,adsoyad,yas,telefon,barkodno,kitapadi,yazari,yayinevi,sayfasayisi,kitapsayisi,teslimtarihi,iadetarihi) values(@tc,@adsoyad,@yas,@telefon,@barkodno,@kitapadi,@yazari,@yayinevi,@sayfasayisi,@kitapsayisi,@teslimtarihi,@iadetarihi)", baglanti);
                            komut.Parameters.AddWithValue("@tc", txtTcAra.Text);
                            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                            komut.Parameters.AddWithValue("yas", txtYas.Text);
                            komut.Parameters.AddWithValue("telefon", txtTelefon.Text);
                            komut.Parameters.AddWithValue("@barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                            komut.Parameters.AddWithValue("@kitapadi", dataGridView1.Rows[i].Cells["kitapadi"].Value.ToString());
                            komut.Parameters.AddWithValue("@yazari", dataGridView1.Rows[i].Cells["yazari"].Value.ToString());
                            komut.Parameters.AddWithValue("@yayinevi", dataGridView1.Rows[i].Cells["yayinevi"].Value.ToString());
                            komut.Parameters.AddWithValue("@sayfasayisi", dataGridView1.Rows[i].Cells["sayfasayisi"].Value.ToString());
                            komut.Parameters.AddWithValue("@kitapsayisi", dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString());
                            komut.Parameters.AddWithValue("@teslimtarihi", dataGridView1.Rows[i].Cells["teslimtarihi"].Value.ToString());
                            komut.Parameters.AddWithValue("@iadetarihi", dataGridView1.Rows[i].Cells["iadetarihi"].Value.ToString());
                            komut.ExecuteNonQuery();
                            SqlCommand komut2 = new SqlCommand("update uye set okukitapsayisi=okukitapsayisi+'"+int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString())+"'where tc='"+txtTcAra.Text+"' ",baglanti);
                            komut2.ExecuteNonQuery();
                            SqlCommand komut3 = new SqlCommand("update kitap set stoksayisi=stoksayisi-'" + int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()) + "'where barkodno='" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "' ", baglanti);
                            komut3.ExecuteNonQuery();
                            baglanti.Close();
                        }
                        baglanti.Open();
                        SqlCommand komut4 = new SqlCommand("delete from sepet", baglanti);
                        komut4.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Kitap(lar) emanet edildi.");
                        daset.Tables["sepet"].Clear();
                        sepetListele();
                        txtTcAra.Text = "";
                        lblkitapsayi.Text = "";
                        kitapsayisi();
                        lblKayitliKitapSayisi.Text = "";
                    }
                    else 
                    {
                        MessageBox.Show("Önce üye ismi seçmeniz gerekir!", "Uyarı");
                    }
                    
                }
                else 
                {
                    MessageBox.Show("Emanet Kitap sayısı 3 ten fazla olamaz!", "Uyarı");
                }
            }
        }
    }
}
