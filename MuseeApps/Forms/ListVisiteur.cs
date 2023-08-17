using MuseeApps.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseeApps.Forms
{
    public partial class ListVisiteur : Form

    {
        private PrintDocument printDocument = new PrintDocument();


        private MuseeContext museecontext = new MuseeContext();
        public ListVisiteur()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

            Affichage();
        }

        private void Affichage()
        {
            visiteurTableau.DataSource = museecontext.visiteurs.Select(
                e => new
                {
                    e.ID,
                    e.Nom,
                    e.Prenom,
                    e.Date_naissance,

                }).ToList();

        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Capturer le contenu du tableau sous forme d'image
            Bitmap bmp = new Bitmap(visiteurTableau.Width, visiteurTableau.Height);
            visiteurTableau.DrawToBitmap(bmp, visiteurTableau.ClientRectangle);

            // Dessiner l'image du tableau sur la page à imprimer
            e.Graphics.DrawImage(bmp, new Point(100, 100));  // Position de l'image sur la page

            bmp.Dispose();
        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }

        }
    }
}
