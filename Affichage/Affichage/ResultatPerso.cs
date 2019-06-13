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
using System.Net.Http;
using Newtonsoft.Json;

namespace Affichage
{
    public partial class ResultatPerso : Form
    {
        private static string url = "http://10.3.242.56/Service1.svc/SelectAffichage"; //url du service web
        public List<CInfoVetetiste> info;

        public ResultatPerso()
        {
            InitializeComponent();
            timer2.Start();
            timer1.Start();
            

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericMonospace, 20); //premières colonnes
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(20); // premières colonnes
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke; //lignes
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Navy; // lignes une sur deux
                                                                                       // this.dataGridView1.DefaultCellStyle.ForeColor = Color.GhostWhite; // lignes vides
            this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical; // bordures des lignes
            this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken; // premières colonnes
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
        }

        private void AffichageVetetiste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
        private int i = 0;
        private async void Affiche()
        {
            dataGridView1.ClearSelection();

            info = JsonConvert.DeserializeObject<List<CInfoVetetiste>>(await DownloadLibraryAsync()); //récupère les infos json

            if (i != info.Count)
            {
                dataGridView1.Rows.Add(info[i].Nom, info[i].Prenom, info[i].Club, info[i].temps); // affiche les infos json dans les colonnes correspondantes
                label1.Text = (i + 1).ToString();
                i++;
            }
            else i = 0;
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
                        // récupère la réponse, il ne resterait plus qu'à désérialiser
                        return await content.ReadAsStringAsync();
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
            timer1.Stop();
        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Affiche();
            Thread.Sleep(2000);
        }
    }
}
