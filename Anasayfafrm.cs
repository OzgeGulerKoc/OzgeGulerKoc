using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzgeKoc
{
    public partial class Anasayfafrm : Form
    {
        public Anasayfafrm()
        {
            InitializeComponent();
        }

        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            UyeEklefrm uyeekle = new UyeEklefrm();
            uyeekle.ShowDialog();
        }

        private void btnUyeListele_Click(object sender, EventArgs e)
        {
            UyeListelemefrm uyeliste = new UyeListelemefrm();
            uyeliste.ShowDialog();
        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            KitapEklemefrm kitapekle = new KitapEklemefrm();
            kitapekle.ShowDialog();
        }

        private void btnKitapListele_Click(object sender, EventArgs e)
        {
            KitapListelefrm kitapliste = new KitapListelefrm();
            kitapliste.ShowDialog();
        }

        private void btnEmanetVerme_Click(object sender, EventArgs e)
        {
            EmanetKitapVermefrm emanetver = new EmanetKitapVermefrm();
            emanetver.ShowDialog();
        }

        private void btnEmanetListele_Click(object sender, EventArgs e)
        {
            EmanetKitapListelefrm emanetlistele = new EmanetKitapListelefrm();
            emanetlistele.ShowDialog();
        }

        private void btnEmanetİade_Click(object sender, EventArgs e)
        {
            EmanetIadefrm emanetiade = new EmanetIadefrm();
            emanetiade.ShowDialog();
        }
    }
}
