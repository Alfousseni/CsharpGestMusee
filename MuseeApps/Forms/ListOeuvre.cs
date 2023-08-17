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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MuseeApps.Forms
{
    public partial class ListOeuvre : Form
    {
        private MuseeContext museecontext = new MuseeContext();
        private user user;
        private PrintDocument printDocument = new PrintDocument();

        public ListOeuvre()
        {
            InitializeComponent();
            Affichage();
        }

        public ListOeuvre(user utilisateur)
        {
            InitializeComponent();
            user = utilisateur;
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage); 
            Affichage();
        }
        private void Affichage()
        {
            oeuvreTableau.DataSource = museecontext.oeuvres.Select(
                e => new
                {     
                    id =  e.ID,
                    Nom =  e.Nom,
                    Annee =  e.Annee,
                    Artiste = e.artiste.Nom,

                }).ToList();

        }


        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void oeuvreTableau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Vérifie si une ligne est réellement sélectionnée (évite les en-têtes de colonne)
            {
                DataGridViewRow selectedRow = oeuvreTableau.Rows[e.RowIndex];

                // Récupérez les données de la ligne sélectionnée
                int id = int.Parse(selectedRow.Cells["id"].Value.ToString());
                oeuvre oeuvre = museecontext.oeuvres.FirstOrDefault(a => a.ID == id);
                new AddOeuvre(user,oeuvre).Show();


            }
        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Capturer le contenu du tableau sous forme d'image
            Bitmap bmp = new Bitmap(oeuvreTableau.Width, oeuvreTableau.Height);
            oeuvreTableau.DrawToBitmap(bmp, oeuvreTableau.ClientRectangle);

            // Dessiner l'image du tableau sur la page à imprimer
            e.Graphics.DrawImage(bmp, new Point(100, 100));  // Position de l'image sur la page

            bmp.Dispose();
        }

        private void actualiser_btn_Click(object sender, EventArgs e)
        {
            Affichage();
        }

        private void imprimerOeuvre_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
    }
}
