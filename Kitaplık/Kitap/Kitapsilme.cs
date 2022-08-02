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
    public partial class Kitapsilme : Form
    {
        public Kitapsilme()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        static string conString = "Data Source=DESKTOP-8MU62OL\\SQLEXPRESS;Initial Catalog=kitaplik;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(conString);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string kayitsilme = "delete from kitapbilgileri where kitapadi=@kitapismi and yazaradi=@yazarismi";
                SqlCommand komut = new SqlCommand(kayitsilme, baglanti);
                komut.Parameters.AddWithValue("@kitapismi", textBox1.Text);
                komut.Parameters.AddWithValue("@yazarismi", textBox2.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayit Silme Gerçekleşti");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayit Silme Basarisiz " + hata.Message);
                baglanti.Close();
            }
            ClearAll(this);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa ansyf = new Anasayfa();
            ansyf.Show();
            Hide();
        }
    }
}

