using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;



//Data Source = LAPTOP - KPNR185M\SQLEXPRESS; Initial Catalog = Ornek; Integrated Security = True

namespace sifremi_unuttum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            sqlbaglantisi bgln=new sqlbaglantisi();
            SqlCommand komut=new SqlCommand("Select * From Kullanici_Bilgi='"+textBox1.Text.ToString()
                +"'and eposta='"+textBox2.Text.ToString()+"'",bgln.baglanti());
            SqlDataReader oku =komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if (bgln.baglanti().State == ConnectionState.Closed)
                    {
                        bgln.baglanti().Open();
                    }
                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    String tarih = DateTime.Now.ToLongDateString();
                    String mailadresin = ("gulcinisidogru06@gmail.com");
                    String sifre = ("121255");
                    String smptsrvr = "smtp.gmail.com";
                    String kime = (oku["eposta"].ToString());
                    String konu = ("Şifre Hatırlatma Maili");
                    String yaz = ("Sayın," + oku["ad_soyad"].ToString() + "\n" + "Bizden" + tarih + "Tarihinde Şifre Hatırlatma Talebinde Bulundunuz" + "\n" + "Parolanız:" + oku["şifre"].ToString() + "\nİYİ GÜNLER");
                    smtpserver.Credentials = new NetworkCredential(mailadresin, sifre);
                    smtpserver.Port = 587;
                    smtpserver.Host = smptsrvr;
                    smtpserver.EnableSsl= true;
                    mail.From = new MailAddress(mailadresin);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smtpserver.Send(mail);
                    DialogResult bilgi=new DialogResult();
                    bilgi = MessageBox.Show("Girmiş Olduğunuz Bilgiler Uyuşuyor.Şifreniz Mail Adresinize Gönderilmiştir.");
                    this.Hide();



                }
                catch(Exception Hata)
                {
                    MessageBox.Show("Mail Gönderme Hatası!", Hata.Message);
                }
            }








        }
    }
}
