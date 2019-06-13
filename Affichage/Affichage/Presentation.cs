using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Affichage
{
    public partial class Presentation : Form
    {
        public Presentation()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
            timer1.Stop();
        }

        private void Presentation_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void Presentation_Load(object sender, EventArgs e)
        {

        }
    }
}
