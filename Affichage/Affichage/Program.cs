using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Affichage
{
    static class AffichageMain
    {
        static Thread boucle = new Thread(ThreadBoucle);
        public static Stopwatch stopWatch = new Stopwatch();
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            stopWatch.Start();
            boucle.Start();
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        static void ThreadBoucle()
        {
            while (true)
            {    
                Presentation presentation = new Presentation();
                Application.Run(presentation);

                Carte carte = new Carte();
                Application.Run(carte);
                
                Resultat resultat = new Resultat();
                Application.Run(resultat);
                  
                ResultatPerso resultatperso = new ResultatPerso();
                Application.Run(resultatperso);   
            }
        }
    }
}
