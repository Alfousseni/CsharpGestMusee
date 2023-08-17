using MuseeApps.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace MuseeApps.Forms
{
    public partial class Homeee : Form
    {
        private MuseeContext museecontext = new MuseeContext();
        //decimal sommePrixTotal = museecontext.oeuvres.Sum(oeuvre => oeuvre.Prix);
    //    decimal sommePrixTotal = museecontext.billets
    //.Where(billet => billet.Type == typeBillet && billet.ExpositionId == expositionId)
    //.Sum(billet => billet.exposition.Prix);

        public Homeee()
        {
            InitializeComponent();
            gain();
            Affichage();
            NbrArtiste.Text = nbrArtiste().ToString();
            NbrOeuvre.Text = nbrOeuvre().ToString();
        }
        private void Affichage()
        {
            DateTime today = DateTime.Now.Date; // Obtenir la date actuelle sans l'heure

            tableauGains.DataSource = museecontext.billets
                .Where(b => DbFunctions.TruncateTime(b.Date_achat) == today)
                .Select(e => new
                {
                    e.Type_billet,
                    Visiteur = e.visiteur.Nom,
                    Exposition = e.exposition.Nom,
                    Date = e.Date_achat,
                })
                .ToList();
        }

        public int nbrOeuvre()
        {
            return museecontext.oeuvres.Count();
        }

        public int nbrArtiste()
        {
            return museecontext.artistes.Count();
        }
        public void gain()
        {
            DateTime dateAchat = DateTime.Now.Date;
            List<billet> billetVip = new List<billet>();
            List<billet> billetClassique = new List<billet>();
            double gainVip = 0;
            double gainClassique = 0;

            billetVip = museecontext.billets.Where(billet => billet.Date_achat == dateAchat && billet.Type_billet == "Vip").ToList();/*.Sum(billet => billet.exposition.prix_vip)*/
            billetClassique = museecontext.billets.Where(billet => billet.Date_achat == dateAchat && billet.Type_billet == "Classique").ToList();/*.Sum(billet => billet.exposition.prix_classique)*/

            foreach(billet billet1 in billetVip) {
                gainVip = gainVip + billet1.exposition.prix_vip;
            }

            foreach(billet billet2 in billetClassique)
            {
                gainClassique = gainClassique + billet2.exposition.prix_classique;
            }
            double gainF = gainClassique + gainVip;
            Gains.Text = gainF.ToString();

        }
    }
}
