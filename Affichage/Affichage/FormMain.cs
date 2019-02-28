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
        public Random aleatoire = new Random(); // Génère un nombre aléatoire

        public int compteur = 1; //compteur pour l'affichage dynamique des vététistes de la base de données 1 par 1
        public string[] msg = {"message 1","message 2","message 3","message 4","message 5","message 6"}; // message aléatoire dans la textbox1
        
        public FormMain()
        {
            InitializeComponent();

            ws = new WebService();
            dataGridView1.DataSource = ws.LoadData("select pseudo, message, date from livre order by date desc", null, null, "livre"); // Affichage de tous les vététistes
            dataGridView2.DataSource = ws.LoadData("select pseudo, message, date from livre where pseudo = 'azerty'", null, null, "livre"); // Affichage vététistes 1 par 1

            timer1.Start(); // timer affichage vététiste 1 par 1
            timer2.Start(); // timer messages aléatoires
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

            // Affichage des vététistes 1 par 1
            if (compteur <= ligne)
            {
                dataGridView2.DataSource = ws.LoadData("select pseudo, message, date from livre where id = '" + compteur + "'", null, null, "livre");
                dataGridView2.ClearSelection();
                compteur++;
            }

            else compteur = 1; // remise à 0 du compteur pour faire une boucle
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int entier = aleatoire.Next(msg.Length); // Génère un entier de la longueur du tableau msg
            label1.Text = msg[entier];
        }
    }
}

