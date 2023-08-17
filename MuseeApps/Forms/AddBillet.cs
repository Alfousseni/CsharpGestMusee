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

namespace MuseeApps.Forms
{
    public partial class AddBillet : Form
    {
        private user user;
        private billet bi;
        MuseeContext museecontext = new MuseeContext();
        public AddBillet()
        {
            InitializeComponent();
        }
        public AddBillet(user utilisateur)
        {
            InitializeComponent();
            user = utilisateur;
            LoadExposition();
            Affichage();
            montant_txt.Enabled = false;
            supprime_btn.Enabled = false;
            modifier_btn.Enabled = false;
        }

        private void LoadExposition()
        {
            try
            {
                exposition_cbx.Items.AddRange(museecontext.expositions
                .Where(expo => expo.Date_debut >= DateTime.Now)
                .Select(expo => expo.Nom)
                .ToArray());
            }
            catch (Exception ex)
            {
                UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors du chargement des expositions : {ex.Message}");
            }
        }

        private void Affichage()
        {
            billetTableau.DataSource = museecontext.billets.Select(
                e => new 
                {
                    id = e.ID,
                    Visiteur = e.visiteur.Nom,
                    Exposition = e.exposition.Nom,
                    Date = e.Date_achat,

                }).ToList();

        }

        private void nom_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void addregister_btn_Click(object sender, EventArgs e)
        {

            try
            {
                string nom = nom_txt.Text;
                string prenom = prenom_txt.Text;
                string email = email_txt.Text;
                string type = type_cbx.SelectedItem.ToString();
                string exposition = exposition_cbx.SelectedItem.ToString();
                string prix = montant_txt.Text;
                DateTime naissance = date_naissance_txt.Value;

                if (UtilsFunction.TestFields(nom, type, email, exposition,type) || naissance == null)
                {

                    UtilsFunction.ShowErrorMessageBox("Veuillez remplir tous les champs ou la taille des texte");
                    return;
                }

                if (!UtilsFunction.IsValidEmail(email))
                {
                    UtilsFunction.ShowErrorMessageBox("Veuillez verifier votre mail");
                    return;
                }

                if (naissance.Year >= DateTime.Now.Year-2)
                {
                    
                    MessageBox.Show("La date de naissance doit être antérieure à il y a deux ans.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var client = new visiteur
                {
                    Nom = nom,
                    Prenom = prenom,
                    Email = email,
                    Date_naissance = naissance,
                    ID_user = user.ID,
                };

                visiteur addVisiteur = museecontext.visiteurs.Add(client);
                museecontext.SaveChanges();

                exposition ex = museecontext.expositions.FirstOrDefault(z => z.Nom == exposition);
               
                var billet = new billet
                {
                    ID_Visiteur = addVisiteur.ID,
                    Date_achat = DateTime.Now,
                    Type_billet = type,
                    ID_Exposition = ex.ID,
                    ID_user = user.ID,
                };

                museecontext.billets.Add(billet);
                museecontext.SaveChanges();
                UtilsFunction.ShowSuccessMessageBox("Ticket valider avec success");
                UtilsFunction.ClearFormFields(nom_txt,prenom_txt,email_txt,montant_txt);
                date_naissance_txt.Value = DateTime.Now;
                type_cbx.SelectedIndex = 0;
                exposition_cbx.SelectedIndex = 0;
                Affichage();
                new billetImprimer(billet).Show();



            }
            catch (Exception ex)
            {
                UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors de l'enregistrement : {ex.Message}");

            }
        }

        private void type_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(exposition_cbx.SelectedItem != null)
            {
                exposition ex = museecontext.expositions.FirstOrDefault(z => z.Nom == exposition_cbx.SelectedItem.ToString());
                if (ex != null)
                {
                    if (type_cbx.SelectedItem.ToString() == "Classique")
                    {
                        montant_txt.Enabled = true;
                        montant_txt.Text = ex.prix_classique.ToString();
                        montant_txt.Enabled = false;

                    }
                    else if (type_cbx.SelectedItem.ToString() == "Vip")
                    {
                        montant_txt.Enabled = true;
                        montant_txt.Text = ex.prix_vip.ToString();
                        montant_txt.Enabled = false;

                    }
                    else
                    {

                    }
                }
            }


        }

        private void exposition_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type_cbx.SelectedItem != null)
            {
                exposition ex = museecontext.expositions.FirstOrDefault(z => z.Nom == exposition_cbx.SelectedItem.ToString());
                if (ex != null)
                {
                    if (type_cbx.SelectedItem.ToString() == "Classique")
                    {
                        montant_txt.Enabled = true;
                        montant_txt.Text = ex.prix_classique.ToString();
                        montant_txt.Enabled = false;
                    }
                    else if (type_cbx.SelectedItem.ToString() == "Vip")
                    {
                        montant_txt.Enabled = true;
                        montant_txt.Text = ex.prix_vip.ToString();
                        montant_txt.Enabled = false;

                    }
                    else
                    {

                    }
                }
            }
        }

        private void billetTableau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                try
                {
                    DataGridViewRow selectedRow = billetTableau.Rows[e.RowIndex];
                    int id = int.Parse(selectedRow.Cells["id"].Value.ToString());
                    billet billet = museecontext.billets.FirstOrDefault(a => a.ID == id);
                    bi =billet;
                    nom_txt.Text = billet.visiteur.Nom;
                    prenom_txt.Text = billet.visiteur.Prenom;
                    email_txt.Text = billet.visiteur.Email;
                    type_cbx.SelectedItem = billet.Type_billet;
                    exposition_cbx.SelectedItem = billet.exposition.Nom;
                    date_naissance_txt.Value = (DateTime)billet.visiteur.Date_naissance;
                    addregister_btn.Enabled = false;
                    supprime_btn.Enabled = true;
                    modifier_btn.Enabled = true;


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
                billet billet = museecontext.billets.FirstOrDefault(a => a.ID == bi.ID);

                string nom = nom_txt.Text;
                string prenom = prenom_txt.Text;
                string email = email_txt.Text;
                string type = type_cbx.SelectedItem.ToString();
                string exposition = exposition_cbx.SelectedItem.ToString();
                string prix = montant_txt.Text;
                DateTime naissance = date_naissance_txt.Value;

                if (UtilsFunction.TestFields(nom, type, email, exposition, type) || naissance == null)
                {

                    UtilsFunction.ShowErrorMessageBox("Veuillez remplir tous les champs ou la taille des texte");
                    return;
                }

                if (!UtilsFunction.IsValidEmail(email))
                {
                    UtilsFunction.ShowErrorMessageBox("Veuillez verifier votre mail");
                    return;
                }

                if (naissance.Year >= DateTime.Now.Year - 2)
                {

                    MessageBox.Show("La date de naissance doit être antérieure à il y a deux ans.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                exposition ex = museecontext.expositions.FirstOrDefault(z => z.Nom == exposition);

                billet.visiteur.Nom = nom;
                billet.visiteur.Prenom = prenom;
                billet.visiteur.Email = email;
                billet.visiteur.Date_naissance = naissance;
                billet.Type_billet = type;
                billet.ID_Exposition = ex.ID;

                museecontext.SaveChanges();
                UtilsFunction.ShowSuccessMessageBox("Modification reussis");
                UtilsFunction.ClearFormFields(nom_txt, prenom_txt, email_txt, montant_txt);
                date_naissance_txt.Value = DateTime.Now;
                type_cbx.SelectedIndex = 0;
                exposition_cbx.SelectedIndex = 0;
                modifier_btn.Enabled = false;
                supprime_btn.Enabled = false;
                addregister_btn.Enabled = true;
                Affichage();

            }
            catch (Exception ex)
            {
                UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors de la modification : {ex.Message}");

            }
        }

        private void supprime_btn_Click(object sender, EventArgs e)
        {

            try
            {
                billet b = museecontext.billets.FirstOrDefault(a => a.ID == bi.ID);
                museecontext.billets.Remove(b);
                museecontext.SaveChanges();
                UtilsFunction.ShowSuccessMessageBox("Suppression reussis");
                UtilsFunction.ClearFormFields(nom_txt, prenom_txt, email_txt, montant_txt);
                date_naissance_txt.Value = DateTime.Now;
                type_cbx.SelectedIndex = 0;
                exposition_cbx.SelectedIndex = 0;
                modifier_btn.Enabled = false;
                supprime_btn.Enabled = false;
                addregister_btn.Enabled = true;
                Affichage();

            }
            catch (Exception ex)
            {
                UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors de la supression : {ex.Message}");
            }
        }
    }
}
