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

namespace Kitap
{
    public partial class KitapGoruntule : Form
    {
        public KitapGoruntule()
        {
            InitializeComponent();

            comboBox1.Items.Add("Hepsi");
            comboBox1.Items.Add("Dram");
            comboBox1.Items.Add("Gerilim");
            comboBox1.Items.Add("Polisiye");
            comboBox1.Items.Add("Bilgisel");
            comboBox1.Items.Add("Biyografi/Otobiyografi/Anı");
            comboBox1.Items.Add("Romantizm");
            comboBox1.Items.Add("Bilim-Kurgu");
            comboBox1.Items.Add("Felsefi");
            comboBox1.Items.Add("Kişisel Gelişim");
            comboBox1.Items.Add("Kurgu");   
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        static string conString = "Data Source=DESKTOP-8MU62OL\\SQLEXPRESS;Initial Catalog=kitaplik;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(conString);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    listBox1.Items.Clear();
                    baglanti.Open();

                    if (comboBox1.Text == "Hepsi")
                    {
                        SqlCommand veriokuma = new SqlCommand("select * from kitapbilgileri", baglanti);
                        veriokuma.Parameters.AddWithValue("@kitapturu", comboBox1.Text);
                        //veriokuma.ExecuteNonQuery();
                        SqlDataReader oku = veriokuma.ExecuteReader();
                        listBox1.Items.Add("Tüm Kitaplar");
                        listBox1.Items.Add("");
                        while (oku.Read())
                        {
                            listBox1.Items.Add("Kitap Adı      : " + oku["kitapadi"].ToString());
                            listBox1.Items.Add("Yazar Adı     : " + oku["yazaradi"].ToString());
                            listBox1.Items.Add("Kitap Turu    : " + oku["kitapturu"].ToString());
                            listBox1.Items.Add("Sayfa Sayısı : " + oku["sayfasayisi"].ToString());
                            listBox1.Items.Add("\n");
                        }
                        baglanti.Close();
                        oku.Close();
                    }
                    else
                    {
                        SqlCommand veriokuma = new SqlCommand("select * from kitapbilgileri where kitapturu=@kitapturu", baglanti);
                        veriokuma.Parameters.AddWithValue("@kitapturu", comboBox1.Text);
                        //veriokuma.ExecuteNonQuery();
                        SqlDataReader oku = veriokuma.ExecuteReader();
                        listBox1.Items.Add(comboBox1.Text + " Türündeki Kitaplar");
                        listBox1.Items.Add("");
                        while (oku.Read())
                        {
                            listBox1.Items.Add("Kitap Adı      : " + oku["kitapadi"].ToString());
                            listBox1.Items.Add("Yazar Adı     : " + oku["yazaradi"].ToString());
                            //listBox1.Items.Add("Kitap Turu   : " + oku["kitapturu"].ToString());
                            listBox1.Items.Add("Sayfa Sayısı : " + oku["sayfasayisi"].ToString());
                            listBox1.Items.Add("\n");
                        }
                        baglanti.Close();
                        oku.Close();
                    }
                }
                else
                {
                    listBox1.Items.Clear();
                    baglanti.Open();
                    if (comboBox1.Text == "Hepsi")
                    {
                        SqlCommand veriokuma = new SqlCommand("select * from kitapbilgileri where yazaradi=@yazaradi", baglanti);
                        veriokuma.Parameters.AddWithValue("@kitapturu", comboBox1.Text);
                        veriokuma.Parameters.AddWithValue("@yazaradi",textBox1.Text);
                        //veriokuma.ExecuteNonQuery();
                        SqlDataReader oku = veriokuma.ExecuteReader();
                        listBox1.Items.Add("Tüm "+ textBox1.Text +" Kitapları");
                        listBox1.Items.Add("");
                        while (oku.Read())
                        {
                            listBox1.Items.Add("Kitap Adı      : " + oku["kitapadi"].ToString());
                            listBox1.Items.Add("Yazar Adı     : " + oku["yazaradi"].ToString());
                            listBox1.Items.Add("Kitap Turu    : " + oku["kitapturu"].ToString());
                            listBox1.Items.Add("Sayfa Sayısı : " + oku["sayfasayisi"].ToString());
                            listBox1.Items.Add("\n");
                        }
                        baglanti.Close();
                        oku.Close();
                    }
                    else
                    {
                        SqlCommand veriokuma = new SqlCommand("select * from kitapbilgileri where kitapturu=@kitapturu and yazaradi=@yazaradi", baglanti);
                        veriokuma.Parameters.AddWithValue("@kitapturu", comboBox1.Text);
                        veriokuma.Parameters.AddWithValue("@yazaradi", textBox1.Text);
                        //veriokuma.ExecuteNonQuery();
                        SqlDataReader oku = veriokuma.ExecuteReader();
                        listBox1.Items.Add(comboBox1.Text + " Türündeki " + textBox1.Text + " Kitapları");
                        listBox1.Items.Add("");
                        while (oku.Read())
                        {
                            listBox1.Items.Add("Kitap Adı      : " + oku["kitapadi"].ToString());
                            listBox1.Items.Add("Yazar Adı     : " + oku["yazaradi"].ToString());
                            //listBox1.Items.Add("Kitap Turu   : " + oku["kitapturu"].ToString());
                            listBox1.Items.Add("Sayfa Sayısı : " + oku["sayfasayisi"].ToString());
                            listBox1.Items.Add("\n");
                        }
                    }
                    baglanti.Close();
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show("Goruntuleme basarisiz ! " + hata.Message);
                baglanti.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void KitapGoruntule_Load(object sender, EventArgs e)
        {
        }

        private void KitapGoruntule_Load_1(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa ansyf = new Anasayfa();
            ansyf.Show();
            Hide();
        }
    }
}
