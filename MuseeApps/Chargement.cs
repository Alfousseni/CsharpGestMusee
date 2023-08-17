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

namespace MuseeApps
{
    public partial class Chargement : Form
    {
        private user user;

        public Chargement(user utilisateur)
        {
            InitializeComponent();
            this.user = utilisateur;
            StartLoading();
        }
        private void StartLoading()
        {
            // Créez et exécutez un travail asynchrone (Task) pour le chargement
            Task.Run(() =>
            {
                for (int progress = 0; progress <= 100; progress++)
                {
                    // Simulez le chargement en utilisant Task.Delay (à remplacer par votre véritable chargement)
                    Task.Delay(50).Wait(); // Pause de 50 millisecondes pour l'exemple

                    // Mettez à jour la barre de chargement
                    UpdateProgressBar(progress);
                }

                // Une fois le chargement terminé, ouvrez le formulaire principal (ou toute autre forme souhaitée)
                ShowMainForm();
            });
        }

        private void UpdateProgressBar(int value)
        {
            // Assurez-vous d'appeler Invoke pour mettre à jour la barre de chargement dans le thread de l'interface utilisateur
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(() => { progressBar.Value = value; }));
            }
            else
            {
                progressBar.Value = value;
            }
        }

        private void ShowMainForm()
        {
            // Assurez-vous d'appeler Invoke pour afficher le formulaire principal dans le thread de l'interface utilisateur
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    new MainHeader(user).Show();
                    this.Hide();

                }));
            }
            else
            {
                new MainHeader(user).Show();
                this.Hide();

            }
        }
    }
}
