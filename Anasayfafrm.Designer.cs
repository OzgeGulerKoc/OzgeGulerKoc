
namespace OzgeKoc
{
    partial class Anasayfafrm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.UyeBox = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.KitapBox = new System.Windows.Forms.GroupBox();
            this.EmanetBox = new System.Windows.Forms.GroupBox();
            this.btnUyeEkle = new System.Windows.Forms.Button();
            this.btnUyeListele = new System.Windows.Forms.Button();
            this.btnKitapEkle = new System.Windows.Forms.Button();
            this.btnKitapListele = new System.Windows.Forms.Button();
            this.btnEmanetVerme = new System.Windows.Forms.Button();
            this.btnEmanetListele = new System.Windows.Forms.Button();
            this.btnEmanetİade = new System.Windows.Forms.Button();
            this.UyeBox.SuspendLayout();
            this.KitapBox.SuspendLayout();
            this.EmanetBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UyeBox
            // 
            this.UyeBox.Controls.Add(this.btnUyeListele);
            this.UyeBox.Controls.Add(this.btnUyeEkle);
            this.UyeBox.Location = new System.Drawing.Point(91, 79);
            this.UyeBox.Name = "UyeBox";
            this.UyeBox.Size = new System.Drawing.Size(275, 173);
            this.UyeBox.TabIndex = 0;
            this.UyeBox.TabStop = false;
            this.UyeBox.Text = "Üyelik İşlemleri";
            // 
            // KitapBox
            // 
            this.KitapBox.Controls.Add(this.btnKitapListele);
            this.KitapBox.Controls.Add(this.btnKitapEkle);
            this.KitapBox.Location = new System.Drawing.Point(546, 79);
            this.KitapBox.Name = "KitapBox";
            this.KitapBox.Size = new System.Drawing.Size(275, 173);
            this.KitapBox.TabIndex = 1;
            this.KitapBox.TabStop = false;
            this.KitapBox.Text = "Kitap İşlemleri";
            // 
            // EmanetBox
            // 
            this.EmanetBox.Controls.Add(this.btnEmanetİade);
            this.EmanetBox.Controls.Add(this.btnEmanetListele);
            this.EmanetBox.Controls.Add(this.btnEmanetVerme);
            this.EmanetBox.Location = new System.Drawing.Point(309, 314);
            this.EmanetBox.Name = "EmanetBox";
            this.EmanetBox.Size = new System.Drawing.Size(275, 173);
            this.EmanetBox.TabIndex = 1;
            this.EmanetBox.TabStop = false;
            this.EmanetBox.Text = "Emanet İşlemleri";
            // 
            // btnUyeEkle
            // 
            this.btnUyeEkle.Location = new System.Drawing.Point(30, 45);
            this.btnUyeEkle.Name = "btnUyeEkle";
            this.btnUyeEkle.Size = new System.Drawing.Size(212, 27);
            this.btnUyeEkle.TabIndex = 0;
            this.btnUyeEkle.Text = "Üye Ekleme İşlemleri";
            this.btnUyeEkle.UseVisualStyleBackColor = true;
            this.btnUyeEkle.Click += new System.EventHandler(this.btnUyeEkle_Click);
            // 
            // btnUyeListele
            // 
            this.btnUyeListele.Location = new System.Drawing.Point(30, 96);
            this.btnUyeListele.Name = "btnUyeListele";
            this.btnUyeListele.Size = new System.Drawing.Size(212, 27);
            this.btnUyeListele.TabIndex = 1;
            this.btnUyeListele.Text = "Üye Listeleme İşlemleri";
            this.btnUyeListele.UseVisualStyleBackColor = true;
            this.btnUyeListele.Click += new System.EventHandler(this.btnUyeListele_Click);
            // 
            // btnKitapEkle
            // 
            this.btnKitapEkle.Location = new System.Drawing.Point(32, 45);
            this.btnKitapEkle.Name = "btnKitapEkle";
            this.btnKitapEkle.Size = new System.Drawing.Size(212, 27);
            this.btnKitapEkle.TabIndex = 1;
            this.btnKitapEkle.Text = "Kitap Ekleme İşlemleri";
            this.btnKitapEkle.UseVisualStyleBackColor = true;
            this.btnKitapEkle.Click += new System.EventHandler(this.btnKitapEkle_Click);
            // 
            // btnKitapListele
            // 
            this.btnKitapListele.Location = new System.Drawing.Point(32, 96);
            this.btnKitapListele.Name = "btnKitapListele";
            this.btnKitapListele.Size = new System.Drawing.Size(212, 27);
            this.btnKitapListele.TabIndex = 2;
            this.btnKitapListele.Text = "Kitap Listeleme İşlemleri";
            this.btnKitapListele.UseVisualStyleBackColor = true;
            this.btnKitapListele.Click += new System.EventHandler(this.btnKitapListele_Click);
            // 
            // btnEmanetVerme
            // 
            this.btnEmanetVerme.Location = new System.Drawing.Point(30, 35);
            this.btnEmanetVerme.Name = "btnEmanetVerme";
            this.btnEmanetVerme.Size = new System.Drawing.Size(212, 27);
            this.btnEmanetVerme.TabIndex = 2;
            this.btnEmanetVerme.Text = "Emanet Kitap Verme İşlemleri";
            this.btnEmanetVerme.UseVisualStyleBackColor = true;
            this.btnEmanetVerme.Click += new System.EventHandler(this.btnEmanetVerme_Click);
            // 
            // btnEmanetListele
            // 
            this.btnEmanetListele.Location = new System.Drawing.Point(31, 73);
            this.btnEmanetListele.Name = "btnEmanetListele";
            this.btnEmanetListele.Size = new System.Drawing.Size(212, 27);
            this.btnEmanetListele.TabIndex = 3;
            this.btnEmanetListele.Text = "Emanet Kitap Listeleme İşlemleri";
            this.btnEmanetListele.UseVisualStyleBackColor = true;
            this.btnEmanetListele.Click += new System.EventHandler(this.btnEmanetListele_Click);
            // 
            // btnEmanetİade
            // 
            this.btnEmanetİade.Location = new System.Drawing.Point(31, 115);
            this.btnEmanetİade.Name = "btnEmanetİade";
            this.btnEmanetİade.Size = new System.Drawing.Size(212, 27);
            this.btnEmanetİade.TabIndex = 4;
            this.btnEmanetİade.Text = "Emanet Kitap İade İşlemleri";
            this.btnEmanetİade.UseVisualStyleBackColor = true;
            this.btnEmanetİade.Click += new System.EventHandler(this.btnEmanetİade_Click);
            // 
            // Anasayfafrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(921, 559);
            this.Controls.Add(this.EmanetBox);
            this.Controls.Add(this.KitapBox);
            this.Controls.Add(this.UyeBox);
            this.Name = "Anasayfafrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anasayfa";
            this.UyeBox.ResumeLayout(false);
            this.KitapBox.ResumeLayout(false);
            this.EmanetBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox UyeBox;
        private System.Windows.Forms.Button btnUyeListele;
        private System.Windows.Forms.Button btnUyeEkle;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox KitapBox;
        private System.Windows.Forms.Button btnKitapListele;
        private System.Windows.Forms.Button btnKitapEkle;
        private System.Windows.Forms.GroupBox EmanetBox;
        private System.Windows.Forms.Button btnEmanetİade;
        private System.Windows.Forms.Button btnEmanetListele;
        private System.Windows.Forms.Button btnEmanetVerme;
    }
}

