using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Affichage
{
    public partial class Resultat : Form
    {
        private static string url = "http://10.3.242.56/Service1.svc/SelectAffichage"; //url du service web
        
        public TimeSpan ts;
        public string elapsedTime;


        public List<CInfoVetetiste> info;
        public Resultat()
        {
            InitializeComponent();
            timer1.Start();
            Affiche();
            
            
            //stopWatch.Stop();
        }

        private void TestAffichage_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericMonospace, 20); //premières colonnes
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(20); // premières colonnes
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke; //lignes
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Navy; // lignes une sur deux
                                                                                       // this.dataGridView1.DefaultCellStyle.ForeColor = Color.GhostWhite; // lignes vides
            this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical; // bordures des lignes
            this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken; // premières colonnes

            this.dataGridView1.Columns[0].Width = 200;
            this.dataGridView1.Columns[1].Width = 200;
            this.dataGridView1.Columns[2].Width = 200;
            this.dataGridView1.Columns[3].Width = 200;
            this.dataGridView1.Columns[4].Width = 200;
        }

        private void TestAffichage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void TestAffichage_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ts = AffichageMain.stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);

            label1.Text = elapsedTime;
        }

        private async void Affiche()
        {
            dataGridView1.ClearSelection();

            info = JsonConvert.DeserializeObject<List<CInfoVetetiste>>(await DownloadLibraryAsync()); //récupère les infos json

            for (int i = 0; i < info.Count; i++)
            {
                dataGridView1.Rows.Add(i + 1, info[i].Nom, info[i].Prenom, info[i].Club, info[i].temps); // affiche les infos json dans les colonnes correspondantes
            }

            timer2.Start();
        }

        private static async Task<String> DownloadLibraryAsync()
        {
            // notre cible
            using (HttpClient client = new HttpClient())
            {
                // la requête
                using (HttpResponseMessage response = await client.GetAsync(url))
                {

                    using (HttpContent content = response.Content)
                    {
                        // récupère la réponse, il ne resterai plus qu'à désérialiser
                        return await content.ReadAsStringAsync();
                    }
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Close();
            timer1.Stop();
            timer2.Stop();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
