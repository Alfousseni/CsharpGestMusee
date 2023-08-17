using MuseeApps.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MuseeApps.Forms
{
    public partial class AddOeuvre : Form
    {
        private user user;
        private oeuvre oeuvre;
        private int an;
        private MuseeContext museecontext = new MuseeContext();
        public AddOeuvre()
        {
            InitializeComponent();
            
        }
        public AddOeuvre(user utilisateur)
        {
            InitializeComponent();
            user = utilisateur;
            modifier_btn.Enabled = false;
            supprimer_btn.Enabled = false;

        }

        public AddOeuvre(user utilisateur, oeuvre oe )
        {
            InitializeComponent();
            user = utilisateur;
            oeuvre = oe;
            nom_txt.Text = oe.artiste.Nom;
            email_txt.Text = oe.artiste.email;
            prix_txt.Text = oe.Prix_estime.ToString();
            nomOeuvre_txt.Text = oe.Nom;
            biographie_txt.Text = oe.artiste.Biographie;
            descriptionOeuvre_txt.Text = oe.Description;
            naissance_date.Value = oe.artiste.Date_naissance.Value;
            anne_txt.Text = oe.Annee.ToString();
            nationalite_cbx.Enabled = false;
            nom_txt.Enabled= false;
            email_txt.Enabled= false;
             biographie_txt.Enabled = false;
            naissance_date.Enabled = false;
            addregister_btn.Enabled = false;
            panel1.BackColor = Color.Black;

            // je vais reprendre la date de l'oeuvre et la nationalite de l'objet en cour oe


        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addregister_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = nom_txt.Text;
                string email = email_txt.Text;
                float prix = float.Parse(prix_txt.Text);
                string oeuvreNom = nomOeuvre_txt.Text;
                string biographie = biographie_txt.Text;
                string description = descriptionOeuvre_txt.Text;
                string nationalite = nationalite_cbx.Text;
                DateTime dateNaissance = naissance_date.Value;
                int dateOeuvre = int.Parse(anne_txt.Text);
                artiste addA;


                if (UtilsFunction.TestFields(nom, description, email, prix_txt.Text, oeuvreNom, biographie, nationalite) || dateNaissance == null || dateOeuvre == null)
                {

                    UtilsFunction.ShowErrorMessageBox("Veuillez remplir tous les champs.");
                    return;
                }

                if (!UtilsFunction.IsValidEmail(email))
                {
                    UtilsFunction.ShowErrorMessageBox("Veuillez verifier votre mail");
                    return;
                }

                artiste artistTest = museecontext.artistes.FirstOrDefault(a => a.email == email);

                if (artistTest == null)
                {

                    var ar = new artiste
                    {
                        Nom = nom,
                        email = email,
                        Date_naissance = dateNaissance,
                        Nationalite = nationalite,
                        Biographie = biographie,
                        ID_user = user.ID

                    };
                    addA = museecontext.artistes.Add(ar);
                    museecontext.SaveChanges();
                }
                else
                {
                    addA = artistTest;
                    UtilsFunction.ShowSuccessMessageBox("Cette artiste existe deja dans notre base l'oeuvre sera aattribue a l'artiste existant.");

                }



                var oe = new oeuvre
                {
                    Nom = oeuvreNom,
                    Annee = dateOeuvre,
                    Description = description,
                    Prix_estime = prix,
                    ID_Artiste = addA.ID,
                    ID_user = user.ID

                };
                museecontext.oeuvres.Add(oe);
                museecontext.SaveChanges();
                UtilsFunction.ClearFormFields(descriptionOeuvre_txt,email_txt,prix_txt,nom_txt,nomOeuvre_txt,biographie_txt,anne_txt);
                naissance_date.Value = DateTime.Now;
               
                nationalite_cbx.SelectionStart = 0;
                UtilsFunction.ShowSuccessMessageBox("Oeuvre ajouter avec success.");

            }catch (Exception ex)
            {
                UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors de l'enregistrement de l'oeuvre : {ex.Message}");
            }
        }

        private void modifier_btn_Click(object sender, EventArgs e)
        {
            try
            {
                oeuvre o = museecontext.oeuvres.FirstOrDefault(a => a.ID == oeuvre.ID);
                string nom = nomOeuvre_txt.Text;
                float prix = float.Parse(prix_txt.Text);
                string description = descriptionOeuvre_txt.Text;
                int dateOeuvre = int.Parse(anne_txt.Text);
                if (UtilsFunction.TestFields(nom, description) || dateOeuvre == null)
                {

                    UtilsFunction.ShowErrorMessageBox("Veuillez remplir tous les champs ou specifier correctement les champs.");
                    return;
                }




                o.Nom = nom;
                o.Annee = dateOeuvre;
                o.Prix_estime = prix;
                o.Description = description;
                museecontext.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors de la mis a jour de l'oeuvre : {ex.Message}");
            }
        }

        private void ListeBtn_Click(object sender, EventArgs e)
        {
            
            new MainHeader(user).OpenChildForm(new Forms.ListOeuvre(user));

        }

        private void supprimer_btn_Click(object sender, EventArgs e)
        {
            try
            {
                oeuvre o = museecontext.oeuvres.FirstOrDefault(a => a.ID == oeuvre.ID);
                museecontext.oeuvres.Remove(o);
                museecontext.SaveChanges();
                UtilsFunction.ShowSuccessMessageBox("Suppression reussis");
                this.Close();


            }
            catch (Exception ex)
            {
                UtilsFunction.ShowErrorMessageBox($"Une erreur est survenue lors de la supression a jour de l'oeuvre : {ex.Message}");
            }
        }
    }
}
