using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Fixer___OND
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String unname = "";
        bool DevActive = false;
        String DevLog = "The app started.\n";

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unname = "";
            OpenFileDialog unfixed = new OpenFileDialog();
            unfixed.Filter = "APP ONLY ALLOWS .txt|*.txt";

            if (unfixed.ShowDialog().Equals(DialogResult.OK))
            {
                unname = unfixed.FileName;
                DevLog = DevLog + "User added file: " + unname;
                refreshDevLog();
                textBox1.Text = File.ReadAllText(unname, Encoding.UTF8);
                button1.Enabled = true;
            }
            else
            {
                DevLog = DevLog + "User failed to find a file.";
                refreshDevLog();
                MessageBox.Show("Failed to find a file.");
                button1.Enabled = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DevLog = DevLog + "User started fixing the file...";
            String AttemptFix = File.ReadAllText(unname, Encoding.UTF8);
            refreshDevLog();
            string CleanGo = getBetween(AttemptFix, "g", "o");
            textBox1.Text = CleanGo;
            DevLog = DevLog + "Did it fix?";
        }

        public static string getBetween(string AttemptFix, string strStart, string strEnd)
        {
            int Start, End;
            if (AttemptFix.Contains(strStart) && AttemptFix.Contains(strEnd))
            {
                Start = AttemptFix.IndexOf(strStart, 0) + strStart.Length;
                End = AttemptFix.IndexOf(strEnd, Start);
                return AttemptFix.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }

        }

        private void devmodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DevActive == true)
            {
                DevActive = false;
                textBox2.Visible = false;
            }
            else
            {
                DevActive = true;
                textBox2.Visible = true;
            }
        }

        public void refreshDevLog()
        {
            textBox2.Text = DevLog;
        }
    }
}