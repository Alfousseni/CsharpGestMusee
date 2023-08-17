using MuseeApps.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace MuseeApps
{
    public partial class MainHeader : Form
    {
        private Form activeForm;
        private user user;

        public MainHeader()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel1);
            bunifuFormDock1.SubscribeControlToDragEvents(panel1);
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel2);
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel2);
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel3);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            OpenChildForm(new Forms.Home());


        }
        public MainHeader(user utilisiteur)
        {
            InitializeComponent();
            this.user = utilisiteur;
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel1);
            bunifuFormDock1.SubscribeControlToDragEvents(panel1);
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel2);
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel2);
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel3);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            OpenChildForm(new Forms.Homeee());


        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Header.Controls.Add(childForm);
            this.Header.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            bunifuGradientPanel2.Text = childForm.Text;
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            Auth loginForm = new Auth();
            this.Hide();
            loginForm.ShowDialog();


        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Homeee());
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.AddEmploye(user));
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.AddExposition(user));
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.AddOeuvre(user));
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.AddBillet(user));
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.AddUser());
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ListVisiteur());
        }

        private void MainHeader_Load(object sender, EventArgs e)
        {

        }

        private void x1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton9_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ListArticle(user));
        }

        private void listeOeuvre_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ListOeuvre(user));

        }
    }
}
