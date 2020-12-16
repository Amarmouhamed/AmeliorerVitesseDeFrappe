using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmeliorerVitesseDeFrappe
{
    public partial class Form1 : Form
    {

        System.Windows.Forms.Timer t = null;
        int compteurTotal = 0;
        int compteur = 3;
        String[] lesLettres = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
            "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        Random probablite = new Random();
        int nombrePoint = 0;
        int nombreTotal = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (button1.Text.Equals("Stop"))
            {
                StopTimer();
                button1.Text = "Demarrer";
            }
            else
            {
                StartTimer();
                button1.Text = "Stop";
                label1.Text = lesLettres[probablite.Next(0, 25)];
            }
            
        }
        public void StopTimer()
        {
            t.Enabled = false;
        }
        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }
        void t_Tick(object sender, EventArgs e)
        {
            compteurTotal++;
            compteur--;
            label3.Text = ""+compteurTotal;
            label5.Text = "0" + compteur;
            if (compteur == 0 || !textBox1.Text.Equals(""))
            {
                compteur = 3;

                nombreTotal++;
                raffraichirScore();
                label1.Text = lesLettres[probablite.Next(0,25)];
                this.BackgroundImage = null;
                textBox1.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))// ignorer le cas ou j'efface le champ de text
            {
                if (label1.Text.ToLower().Equals(textBox1.Text.ToLower()))
                {
                    nombrePoint++;
                    raffraichirScore();
                    this.BackgroundImage = Properties.Resources.check_ok_accept_apply_1582;
                }
                else
                {
                    this.BackgroundImage = Properties.Resources.crosshd_106070;

                }
            }
            

        }
        public void raffraichirScore()
        {
            label8.Text = nombrePoint + "/" + nombreTotal;
        }
    }
}
