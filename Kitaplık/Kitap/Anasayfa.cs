using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitap
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kitapekleme ktpekl = new Kitapekleme();
            ktpekl.Show();
            Hide(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kitapsilme ktpslm = new Kitapsilme(); 
            ktpslm.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KitapGoruntule ktpgrntl = new KitapGoruntule();
            ktpgrntl.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
