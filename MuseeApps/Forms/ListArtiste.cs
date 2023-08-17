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
    public partial class ListArticle : Form
    {
        private MuseeContext museecontext = new MuseeContext();
        private user user;
        private PrintDocument printDocument = new PrintDocument();

        public ListArticle(user utilisateur)
        {
            InitializeComponent();
            user = utilisateur;
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            Affichage();

        }
        private void Affichage()
        {
            tableauArtiste.DataSource = museecontext.artistes.Select(
                e => new
                {
                     e.ID,
                     e.Nom,
                     e.email,
                     e.Nationalite,

                }).ToList();

        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Capturer le contenu du tableau sous forme d'image
            Bitmap bmp = new Bitmap(tableauArtiste.Width, tableauArtiste.Height);
            tableauArtiste.DrawToBitmap(bmp, tableauArtiste.ClientRectangle);

            // Dessiner l'image du tableau sur la page à imprimer
            e.Graphics.DrawImage(bmp, new Point(100, 100));  // Position de l'image sur la page

            bmp.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
