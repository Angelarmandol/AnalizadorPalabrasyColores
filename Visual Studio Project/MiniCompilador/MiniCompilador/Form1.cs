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
        CompilerClass compiler = new CompilerClass();
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TBCode.Text == "")
            {
                TBCode.Text = "";
            }else{
                string message = "Do you want to save in another File before create another one?";
                string title = "Save File";
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //this is the code area

        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Se enviara a: "+TBCode.Text);
          WritteOnConsole("Compiled with: "+compiler.sanitize(TBCode.Text)+" errors");
        }

        public void TBCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TBCode.Text = "Inicio;\r\n";
            TBCode.Text += "Mensaje[hola];\r\n";
            TBCode.Text += "Contador[6];\r\n";
            TBCode.Text += "Fin;";
            
        }

        private void TABDebug_Click(object sender, EventArgs e)
        {

        }

        private void WritteOnConsole(string text)
        {
            richTextBox1.Text = text;
        }
    }

   
}







