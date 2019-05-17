using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace MiniCompilador
{

    
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
        }
        CompilerClass compiler = new CompilerClass();

        ///////////////////////////////////////////MENU NEVO////////////////////////////////////////////////////////
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
                        guardararchivo(TBCode.Text);
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

            EraseConsole();
            WritteOnConsole("\r\n");

            Console.WriteLine("Se enviara a: "+TBCode.Text);
            WritteOnConsole("Compiled with: "+compiler.sanitize(TBCode.Text)+ " errors \r\n");
            WritteOnConsole(compiler.getErrorCompilatorText()+ "\r\n");
           
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
            richTextBox1.Text = (richTextBox1.Text)+text;
        }
        private void EraseConsole()
        {
            richTextBox1.Text = null;
        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        public void genericMessageBox(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ///////////////// change to CompilerClass
            string text = TBCode.Text;
            text += text.Replace("\r\n", "");
            Console.WriteLine("-**-**-*-"+text);

            if (text.Equals(""))
            {
                genericMessageBox("El texto esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Console.WriteLine("Hay texto en la caja");
                
            }
        }



        ///////////////////////////////////////////MENU GUARDAR////////////////////////////////////////////////////////
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardararchivo(TBCode.Text);
        }

        ///////////////////////////////////////////MENU OPEN////////////////////////////////////////////////////////
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.xkz)|*.xkz";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                TBCode.Text = File.ReadAllText(sFileName);
                //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
            }
         
    }

    private void guardararchivo(string texto)
    {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
    saveFileDialog1.Filter = "All Files (*.xkz)|*.xkz";
            saveFileDialog1.Title = "Guarda tu Codigo";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                StreamWriter escrito = File.AppendText(saveFileDialog1.FileName);
    escrito.Write(texto.ToString());
                escrito.Flush();
                escrito.Close();
            }
        }



    private string quitarEspacios(string texto)
    {
        string textoSinEspacios = texto.Replace(" ", "").Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
        return textoSinEspacios;
    }

    private void splitSentencias(string texto)
    {
        string[] separators = { ";", "%" };
        string[] sentencias = texto.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    }

    private bool validarSentencias(string[] sentencias)
    {
        bool compila = false;
        // Regex rx = new Regex;
        string inicio = @"\A([iI][nN][iI][cC][iI][oO])\Z";
        string fin = @"\A([fF][iI][nN])\Z";
        string mensage = @"\A([fF][iI][nN])\Z";
        string contador = @"\A([fF][iI][nN])\Z";

        foreach (var sentencia in sentencias)
        {
            //if (rx.Matches(sentencia, inicio))
            {

            }
        }

        return compila;
    }

}

}






