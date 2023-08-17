using MuseeApps.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MuseeApps.Forms
{
    public partial class AddEmploye : Form
    {
        private user user;
        private employe em;
        MuseeContext museecontext = new MuseeContext();
        public AddEmploye()
        {
            InitializeComponent();
            Affichage();

        }
        public AddEmploye(user utilisateur)
        {
            InitializeComponent();
            user = utilisateur;
            Affichage();
            modifier_btn.Enabled = false;
            supprimer_btn.Enabled = false;
        }
        private void Affichage()
        {
            employeTableau.DataSource = museecontext.employes.Select(
                e => new
                {
                    id = e.ID,
                    Nom = e.Nom,
                    Prenom = e.Prenom,
                    Position = e.Position,
                    telephone = e.telephone,

                }).ToList();


        }

        private void addregister_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = nom_txt.Text;
                string prenom = prenom_txt.Text;
                string position = poste_txt.Text;
                string adresse = adresse_txt.Text;
                string telephone = telephone_txt.Text;
                float salaire = float.Parse(salaire_txt.Text);
                if (UtilsFunction.TestFields(nom, prenom, position, adresse, telephone, salaire_txt.Text))
                {

                    UtilsFunction.ShowErrorMessageBox("Veuillez remplir tous les champs ou verifier la taille des texte");
                    return;
                }


                if (!UtilsFunction.IsValidPhoneNumber(telephone))
                {
                    UtilsFunction.ShowErrorMessageBox($"format {telephone} n'est pas correcte");
                    return;
                }

                employe emplo = museecontext.employes.FirstOrDefault(a => a.telephone == telephone) ;

                if (emplo != null)
                {
                    UtilsFunction.ShowErrorMessageBox("Ce numero de telephone existe deja");
                    return;
                }


                var employe = new employe
                {
                    Nom = nom,
                    Prenom = prenom,
                    Position = position,
                    Salaire = salaire,
                    adresse = adresse,
                    telephone = telephone,


                };
                museecontext.employes.Add(employe);
                museecontext.SaveChanges();
                UtilsFunction.ClearFormFields(telephone_txt, salaire_txt, adresse_txt, prenom_txt, poste_txt, nom_txt);
                Affichage();
                UtilsFunction.ShowSuccessMessageBox("Employer ajouter avec succes");




            }
            catch (Exception ex)
            {
                UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors de l'enregistrement : {ex.Message}");
            }

        }

        private void employeTableau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = employeTableau.Rows[e.RowIndex];
                    int id = int.Parse(selectedRow.Cells["id"].Value.ToString());
                    employe employe = museecontext.employes.FirstOrDefault(a => a.ID == id);
                    em = employe;
                    nom_txt.Text = employe.Nom;
                    prenom_txt.Text = employe.Prenom;
                    telephone_txt.Text = employe.telephone;
                    adresse_txt.Text = employe.adresse;
                    salaire_txt.Text = employe.Salaire.ToString();
                    poste_txt.Text = employe.Position;
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
            try
            {

                string nom = nom_txt.Text;
                string prenom = prenom_txt.Text;
                string position = poste_txt.Text;
                string adresse = adresse_txt.Text;
                string telephone = telephone_txt.Text;
                float salaire = float.Parse(salaire_txt.Text);
                if (UtilsFunction.TestFields(nom, prenom, position, adresse, telephone, salaire_txt.Text))
                {

                    UtilsFunction.ShowErrorMessageBox("Veuillez remplir tous les champs ou verifier la taille des texte");
                    return;
                }
                if (!UtilsFunction.IsValidPhoneNumber(telephone))
                {
                    UtilsFunction.ShowErrorMessageBox($"format {telephone} n'est pas correcte");
                    return;
                }


                employe ep = museecontext.employes.FirstOrDefault(z => z.ID == em.ID);

                ep.telephone = telephone;
                ep.adresse = adresse;
                ep.Salaire = salaire;
                ep.Nom = nom;
                ep.Prenom = prenom;
                ep.Position = position;

                museecontext.SaveChanges();
                UtilsFunction.ClearFormFields(telephone_txt, salaire_txt, adresse_txt, prenom_txt, poste_txt, nom_txt);
                modifier_btn.Enabled = false;
                supprimer_btn.Enabled = false;
                addregister_btn.Enabled = true;
                UtilsFunction.ShowSuccessMessageBox("mis a jour reussis");
                Affichage();


            }
            catch (Exception ex)
            {
                UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors du chargement : {ex.Message}");

            }
        }

        private void supprimer_btn_Click(object sender, EventArgs e)
        {

            employe ep = museecontext.employes.FirstOrDefault(z => z.ID == em.ID);
            museecontext.employes.Remove(ep);
            museecontext.SaveChanges();
            UtilsFunction.ShowSuccessMessageBox("Suppression reussis");
            UtilsFunction.ClearFormFields(telephone_txt, salaire_txt, adresse_txt, prenom_txt, poste_txt, nom_txt);
            modifier_btn.Enabled = false;
            supprimer_btn.Enabled = false;
            addregister_btn.Enabled = true;
            Affichage();

        }
    }
}
