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
    public partial class billetImprimer : Form
    {
        private billet billet;
        private PrintDocument printDocument = new PrintDocument();

        public billetImprimer(billet b)
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            billet = b;
            exposition_label.Text = billet.exposition.Nom;
            nom_label.Text = billet.visiteur.Nom+" "+billet.visiteur.Prenom;
            type_label.Text = billet.Type_billet;
            fin_label.Text = billet.exposition.Date_fin.ToString();
            debu_label.Text = billet.exposition.Date_debut.ToString();
            debutH_label.Text = billet.exposition.heurDebut.ToString();
            finh_label.Text = billet.exposition.heurFin.ToString();

        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(facture_pn.Width, facture_pn.Height);
            facture_pn.DrawToBitmap(bmp, facture_pn.ClientRectangle);
            // Dessiner l'image du panneau sur la page à imprimer
            e.Graphics.DrawImage(bmp, new Point(100, 100));  // Position de l'image sur la page
            bmp.Dispose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
    }
}
