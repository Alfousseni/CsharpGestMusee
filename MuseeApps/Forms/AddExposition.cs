using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuseeApps.Entities;
using System.Windows.Forms;
using Bunifu.Json;
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Diagnostics;

namespace MuseeApps.Forms
{
    public partial class AddExposition : Form
    {
        private user user;
        private exposition ex;
        private MuseeContext museecontext = new MuseeContext();

        public AddExposition()
        {
            InitializeComponent();
        }
        public AddExposition(user utilisateur)
        {
            InitializeComponent();
            user = utilisateur;
            Affichage();
            modifier_btn.Enabled = false;
            supprimer_btn.Enabled = false;
            addregister_btn.Enabled = true;
        }
        private void Affichage()
        {
            expositionTable.DataSource = museecontext.expositions.Select(
                e => new
                {
                   id = e.ID,
                   Nom = e.Nom,    
                   Date = e.Date_fin,
                   Heure = e.heurDebut,
                   Description = e.Description,
                    
                }).ToList();

            
        }

        private void addregister_btn_Click(object sender, EventArgs e)
        {
            string nom = nom_txt.Text;
            string description = description_txt.Text;
            DateTime debut = debut_txt.Value;
            string Debut = debut.ToString("yyyy-MM-dd");
            DateTime fin = fin_txt.Value;
           
            string prixVipText = prix_vip_txt.Text;
            
            string prixClassiqueTexte = prix_classique_txt.Text;
           
            DateTime heurdebut = heurDebut_txt.Value;
            string Heurdebut = heurdebut.ToString("HH:mm");
            DateTime heurfin = heurFin_txt.Value;
            string Heurfin = heurfin.ToString("HH:mm");
            float prixClassique = float.Parse(prixClassiqueTexte);
            float  prixVip = float.Parse(prixVipText);

            if (UtilsFunction.TestFields(nom, description, Debut, Heurdebut, prixVipText, prixClassiqueTexte, Heurfin))
            {
                
                    UtilsFunction.ShowErrorMessageBox("Veuillez remplir tous les champs.");
                    return;              
            }

            if (debut.Date == fin.Date && heurdebut.TimeOfDay >= heurfin.TimeOfDay)
            {
                UtilsFunction.ShowErrorMessageBox("L'heure de début doit être inférieure à l'heure de fin.");
                return;
            }
            if (debut < DateTime.Now || fin < debut)
            {
                MessageBox.Show("Incohérence de date", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vérifier que la date de début est antérieure à la date de fin
            if (debut > fin)
            {
                UtilsFunction.ShowErrorMessageBox("La date de début doit être antérieure à la date de fin.");
                return;
            }

                try
                {
                
                var exposition = new exposition
                {
                    Nom = nom,
                    Description = description,
                    Date_debut = debut,
                    Date_fin = fin,
                    prix_classique = prixClassique,
                    prix_vip = prixVip,
                    heurDebut = Heurdebut,
                    heurFin = Heurfin,
                    ID_user = user.ID
                };

                museecontext.expositions.Add(exposition);
                museecontext.SaveChanges();
                UtilsFunction.ShowSuccessMessageBox("Exposition ajouter avec success.");
                UtilsFunction.ClearFormFields(nom_txt,description_txt,prix_classique_txt,prix_vip_txt);
                debut_txt = null; fin_txt=null;heurDebut_txt= null;heurFin_txt=null;
                Affichage();




            }
            catch (Exception ex)
            {
                UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors de l'enregistrement  : {ex.Message}");
            }
            


        }

        private void expositionTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = expositionTable.Rows[e.RowIndex];
                    int id = int.Parse(selectedRow.Cells["id"].Value.ToString());
                    exposition exposition = museecontext.expositions.FirstOrDefault(a => a.ID == id);
                    ex = exposition;
                    nom_txt.Text = exposition.Nom;
                    debut_txt.Value = (DateTime)exposition.Date_debut;
                    fin_txt.Value = exposition.Date_fin;
                    heurDebut_txt.Text= exposition.heurDebut;
                    heurFin_txt.Text= exposition.heurFin;
                    description_txt.Text = exposition.Description;
                    prix_classique_txt.Text = exposition.prix_classique.ToString();
                    modifier_btn.Enabled = true;
                    supprimer_btn.Enabled = true;
                    addregister_btn.Enabled = false;



                }
                catch (Exception ex)
                {
                    UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors du chargement : {ex.Message}");

                }
            }
        }

        private void modifier_btn_Click(object sender, EventArgs e)
        {
            string nom = nom_txt.Text;
            string description = description_txt.Text;
            DateTime debut = debut_txt.Value;
            string Debut = debut.ToString("yyyy-MM-dd");
            DateTime fin = fin_txt.Value;
            string prixVipText = prix_vip_txt.Text;
            string prixClassiqueTexte = prix_classique_txt.Text;
            DateTime heurdebut = heurDebut_txt.Value;
            string Heurdebut = heurdebut.ToString("HH:mm");
            DateTime heurfin = heurFin_txt.Value;
            string Heurfin = heurfin.ToString("HH:mm");
            float prixClassique = float.Parse(prixClassiqueTexte);
            float prixVip = float.Parse(prixVipText);


            if (UtilsFunction.TestFields(nom, description, Debut, Heurdebut, prixVipText, prixClassiqueTexte, Heurfin))
            {

                UtilsFunction.ShowErrorMessageBox("Veuillez remplir tous les champs.");
                return;
            }

            if (debut.Date == fin.Date && heurdebut.TimeOfDay >= heurfin.TimeOfDay)
            {
                UtilsFunction.ShowErrorMessageBox("L'heure de début doit être inférieure à l'heure de fin.");
                return;
            }
            if (debut < DateTime.Now || fin < debut)
            {
                MessageBox.Show("Incohérence de date", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vérifier que la date de début est antérieure à la date de fin
            if (debut > fin)
            {
                UtilsFunction.ShowErrorMessageBox("La date de début doit être antérieure à la date de fin.");
                return;
            }

            try
            {

                exposition expo = museecontext.expositions.FirstOrDefault(z => z.ID == ex.ID);

                expo.Nom = nom;
                expo.Description = description;
                expo.Date_debut = debut;
                expo.Date_fin = fin;
                expo.heurDebut = Heurdebut;
                expo.heurFin = Heurfin;
                expo.heurDebut = Heurdebut;
                expo.prix_classique = prixClassique;
                expo.prix_vip = prixVip;

                museecontext.SaveChanges();
                UtilsFunction.ShowSuccessMessageBox("Exposition modifier avec success.");
                UtilsFunction.ClearFormFields(nom_txt, description_txt, prix_classique_txt, prix_vip_txt);
                debut_txt = null; fin_txt = null; heurDebut_txt = null; heurFin_txt = null;
                modifier_btn.Enabled = false;
                supprimer_btn.Enabled = false;
                addregister_btn.Enabled = true;
                Affichage();

            }
            catch (Exception ex)
            {
                UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors de laa modificaation  : {ex.Message}");
            }



              


        }

        private void supprimer_btn_Click(object sender, EventArgs e)
        {

            try
            {

                exposition expo = museecontext.expositions.FirstOrDefault(z => z.ID == ex.ID);

                museecontext.expositions.Remove(expo);
                museecontext.SaveChanges();
                UtilsFunction.ShowSuccessMessageBox("Exposition supprimer avec success.");
                UtilsFunction.ClearFormFields(nom_txt, description_txt, prix_classique_txt, prix_vip_txt);
                debut_txt = null; fin_txt = null; heurDebut_txt = null; heurFin_txt = null;
                modifier_btn.Enabled = false;
                supprimer_btn.Enabled = false;
                addregister_btn.Enabled = true;
                Affichage();

            }
            catch (Exception ex)
            {
                UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors de la suppression  : {ex.Message}");
            }

        }
    }
}
