using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Affichage
{
    
    public partial class Carte : Form
    {

        public Carte()
        {
            InitializeComponent();
            
            timer1.Start();
        }

        private void Carte_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Carte_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
            timer1.Stop();
        }

        private void Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
