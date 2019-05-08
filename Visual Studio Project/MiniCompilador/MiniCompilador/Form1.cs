using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniCompilador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TBCode.Text == "")
            {
                TBCode.Text = "";
            }else{
                string message = "¿Deseas salvarlo en un archivo nuevo antes de crear uno nuevo?";
                string title = "Salvar Archivo";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No){
                    TBCode.Text = "";
                }else{
                    if (result == DialogResult.Yes)
                    {
                        // Do nothing  
                    }
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help1 help2 = new Help1();
            help2.Show();
        }
    }
}
