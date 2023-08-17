using MuseeApps.Entities;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MuseeApps
{
    public partial class Auth : Form
    {

        private MuseeContext museecontext = new MuseeContext();
        public Auth()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel1);
            bunifuFormDock1.SubscribeControlToDragEvents(tabPage1);
            bunifuFormDock1.SubscribeControlToDragEvents(tabPage2);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void bunifuMaterialTextbox1_Enter(object sender, EventArgs e)
        {
            if (login_txt.Text == "Login")
            {
                login_txt.Text = "";
                login_txt.ForeColor = Color.Black;
            }
        }

        private void bunifuMaterialTextbox1_Leave(object sender, EventArgs e)
        {
            if (login_txt.Text == "")
            {
                login_txt.Text = "Login";
                login_txt.ForeColor = Color.DarkGray;
            }
        }

        private void bunifuMaterialTextbox2_Enter_1(object sender, EventArgs e)
        {
            if (password_txt.Text == "Password")
            {
                password_txt.Text = "";
                password_txt.ForeColor = Color.Black;
            }
        }

        private void bunifuMaterialTextbox2_Leave_1(object sender, EventArgs e)
        {
            if (password_txt.Text == "")
            {
                password_txt.Text = "Password";
                password_txt.ForeColor = Color.DarkGray;
            }
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (!bunifuCheckbox1.Checked)
            {
                password_txt.isPassword = false;
            }
            else
            {
                password_txt.isPassword = true;
            }
        }

        private void bunifuMaterialTextbox6_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_Enter(object sender, EventArgs e)
        {
            if (passwordRegister_txt.Text == "Password")
            {
                passwordRegister_txt.Text = "";
                passwordRegister_txt.ForeColor = Color.Black;
            }
        }

        private void bunifuMaterialTextbox3_Leave(object sender, EventArgs e)
        {
            if (passwordRegister_txt.Text == "")
            {
                passwordRegister_txt.Text = "Password";
                passwordRegister_txt.ForeColor = Color.DarkGray;
            }
        }

        private void bunifuMaterialTextbox5_Leave(object sender, EventArgs e)
        {
            if (confirmRegister_txt.Text == "")
            {
                confirmRegister_txt.Text = "Confirm Password ";
                confirmRegister_txt.ForeColor = Color.DarkGray;
            }
        }

        private void bunifuMaterialTextbox5_Enter(object sender, EventArgs e)
        {
            if (confirmRegister_txt.Text == "Confirm Password ")
            {
                confirmRegister_txt.Text = "";
                confirmRegister_txt.ForeColor = Color.Black;
            }
        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (!bunifuCheckbox2.Checked)
            {
                confirmRegister_txt.isPassword = false;
                passwordRegister_txt.isPassword = false;
            }
            else
            {
                confirmRegister_txt.isPassword = true;
                passwordRegister_txt.isPassword = true;
            }


        }

        private void bunifuMaterialTextbox4_Enter(object sender, EventArgs e)
        {
            if (loginRegister_txt.Text == "Login")
            {
                loginRegister_txt.Text = "";
                loginRegister_txt.ForeColor = Color.Black;
            }
        }

        private void bunifuMaterialTextbox4_Leave(object sender, EventArgs e)
        {
            if (loginRegister_txt.Text == "")
            {
                loginRegister_txt.Text = "Login";
                loginRegister_txt.ForeColor = Color.DarkGray;
            }
        }

        private void bunifuMaterialTextbox6_Leave(object sender, EventArgs e)
        {
            if (emailRegister_txt.Text == "")
            {
                emailRegister_txt.Text = "Email";
                emailRegister_txt.ForeColor = Color.DarkGray;
            }
        }

        private void bunifuMaterialTextbox6_Enter(object sender, EventArgs e)
        {
            if (emailRegister_txt.Text == "Email")
            {
                emailRegister_txt.Text = "";
                emailRegister_txt.ForeColor = Color.Black;
            }
        }

        private void addregister_btn_Click(object sender, EventArgs e)
        {
            //Register
            string login = loginRegister_txt.Text;
            string email = emailRegister_txt.Text;
            string password = passwordRegister_txt.Text;
            string confirmpassword = confirmRegister_txt.Text;
            string role = role_cbx.Text;
           

            if (UtilsFunction.TestFields(login,email,password,role))
            {
                UtilsFunction.ShowErrorMessageBox("Veuillez remplir tous les champs.");
                return;

            }
            if (!UtilsFunction.IsValidName(login))
            {
                UtilsFunction.ShowErrorMessageBox("Veuillez verifier le format du login");
                return;
            }

            if (!UtilsFunction.IsValidEmail(email))
            {
                UtilsFunction.ShowErrorMessageBox("Veuillez verifier votre mail");
                return;
            }

            if (!UtilsFunction.ValidatePassword(password))
            {
                UtilsFunction.ShowErrorMessageBox("Veuillez verifier votre mots de paasse");
                return;
            }



            if (UtilsFunction.ConfirmPassword(password,confirmpassword))
            {
                UtilsFunction.ShowErrorMessageBox("les mot de passe ne sont pas identique.");
                return;

            }

            var utilisaateur = new user
            {
                Username = login,
                Email = email,
                Password = UtilsFunction.Encrypt(password),
                Role = role,
                etat = "ACTIVER"

            };

            museecontext.users.Add(utilisaateur);
            museecontext.SaveChanges();
            UtilsFunction.ShowSuccessMessageBox("Utilisateur ajouter avec success.");


        }

        private void connexion_btn_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void addlogin_btn_Click(object sender, EventArgs e)
        {
            // authentification

            string login = login_txt.Text;
            string password = password_txt.Text;


            if (IsFieldEmpty(login) || IsFieldEmpty(password))
            {
                UtilsFunction.ShowErrorMessageBox("Veuillez remplir tous les champs");
                return;
            }

            var user = museecontext.users.FirstOrDefault(u=>u.Username==login);
            if (user == null || !UtilsFunction.Decrypt(user.Password).Equals(password))
            {
                UtilsFunction.ShowErrorMessageBox("Login ou password incorrect");
                return;
            }

            museecontext.SaveChanges();
            this.Hide();
            //new MainHeader(user).Show();
            new Chargement(user).Show();

        }

        private void x1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void x2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool IsFieldEmpty(string field) => string.IsNullOrWhiteSpace(field);

    }
}
