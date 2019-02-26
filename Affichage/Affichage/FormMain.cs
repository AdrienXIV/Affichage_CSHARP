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
using WS;

namespace Affichage
{
    public partial class FormMain : Form
    {
        public static WebService ws;
        public FormMain()
        {
            InitializeComponent();

            ws = new WebService();
            dataGridView1.DataSource = ws.LoadData("select pseudo, message, date from livre order by date desc", null, null, "livre");
            dataGridView2.DataSource = ws.LoadData("select pseudo, message, date from livre where pseudo = 'azerty'", null, null, "livre");
            timer1.Start();
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
          
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int ligne = dataGridView1.RowCount;
            //MessageBox.Show(Convert.ToString(ligne));
            for (int i = 0; i <= ligne; i++)
            {
                dataGridView2.DataSource = ws.LoadData("select pseudo, message, date from livre where id = '" +i +"'", null, null, "livre");
                //dataGridView2.ClearSelection();
            }

        }
    }
}

