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
    public partial class Kitapekleme : Form
    {
        public Kitapekleme()
        {
            InitializeComponent();
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

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        static string conString = "Data Source=DESKTOP-8MU62OL\\SQLEXPRESS;Initial Catalog=kitaplik;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(conString);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string kayit = "INSERT INTO kitapbilgileri(kitapadi,yazaradi,kitapturu,sayfasayisi) values(@kitapadi,@yazaradi,@kitapturu,@sayfasayisi)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@kitapadi", textBox1.Text);
                komut.Parameters.AddWithValue("@yazaradi", textBox2.Text);
                komut.Parameters.AddWithValue("@kitapturu",comboBox1.SelectedItem.ToString());
                int sayfasayisialma = Convert.ToInt32(textBox3.Text);
                komut.Parameters.AddWithValue("@sayfasayisi", sayfasayisialma);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayit Gerçekleşti");
            }
            catch(Exception hata)
            {
                MessageBox.Show("Kayit Basarisiz " + hata.Message);
                baglanti.Close();
            }
            ClearAll(this);
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ClearAll(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.Controls.Count > 0)
                {
                    ClearAll(c);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa ansyf = new Anasayfa();
            ansyf.Show();
            Hide();
        }
    }
}
