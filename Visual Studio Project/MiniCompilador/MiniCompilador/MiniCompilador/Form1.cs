using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

 
namespace MiniCompilador
{

 

    public partial class Form1 : Form
    {

        Boolean viewTest = false;
        public Form1()
        {
            
            InitializeComponent();
            button1.Visible = false;
        }

        ///////////////////////////////////////////MENU GUARDAR////////////////////////////////////////////////////////
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardararchivo(TBCode.Text);
        }

        ///////////////////////////////////////////MENU NEVO////////////////////////////////////////////////////////
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TBCode.Text == "")
            {
                TBCode.Text = "";
            }
            else
            {
                string message = "¿Deseas salvarlo en un archivo nuevo antes de crear uno nuevo?";
                string title = "Salvar Archivo";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No)
                {
                    TBCode.Text = "";
                    tbConsola.Text = "";
                    tbDebug.Text = "";
                }
                else
                {
                    if (result == DialogResult.Yes)
                    {
                        guardararchivo(TBCode.Text);
                    }
                }
            }
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

        ///////////////////////////////////////////MENU COMPILAR////////////////////////////////////////////////////////
        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            validarSentencias(splitSentencias(quitarEspacios(TBCode.Text)));
        }

        ///////////////////////////////////////////MENU RUN////////////////////////////////////////////////////////
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] cnt = null, msg;
            string msgs=null;
            int cntMsgs = 0;

            Console.WriteLine("----------");

            foreach(var texto in splitSentencias(quitarEspacios(TBCode.Text)))
            {
               

                if (texto.Contains("Contador"))
                {
                    cnt = texto.Split('[');
                    cnt = cnt[1].Split(']');
                    Console.WriteLine("1111:" + cnt[0]);
                }
                if (texto.Contains("Mensaje"))
                {
                    msg = texto.Split('[');
                    msg = msg[1].Split(']');
                    Console.WriteLine("00000:" + msg[0]);
                    msgs += " "+msg[0];
                    cntMsgs++;
                }
            }
            tbDebug.Text = null;
            for (int x=0; x< Int32.Parse(cnt[0]); x++)
            {
                Console.WriteLine("woc:" + msgs);
                tbDebug.Text += msgs+ "\r\n";
            }
            cnt = null;

        }

        ///////////////////////////////////////////MENU HELP////////////////////////////////////////////////////////
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help1 help2 = new Help1();
            help2.Show();
        }

        ///////////////////////////////////////////MENU PRINT////////////////////////////////////////////////////////
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        ///////////////////////////////////////////METODOS////////////////////////////////////////////////////////
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

                tbDebug.Text += "--Archivo Guardado-- \r\n";
                tbDebug.Text += saveFileDialog1.FileName + "\r\n \r\n";
            }
        }

        private string quitarEspacios(string texto)
        {
            string textoSinEspacios = texto.Replace(" ", "").Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            return textoSinEspacios;
        }

        private string[] splitSentencias(string texto)
        {
            string[] separators = { ";", "%" };
            string[] sentencias = texto.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return sentencias;
        }

        private bool validarSentencias(string[] sentencias)
        {
            bool compila = true;
            string inicio = @"\A([iI][nN][iI][cC][iI][oO])\Z";
            string mensage = @"\A([mM][eE][nN][sS][aA][jJ][eE])\u005B[a-zA-Z0-9]+\u005D\Z";
            string contador = @"\A([cC][oO][nN][tT][aA][dD][oO][rR])\u005B[0-9]+\u005D\Z";
            string fin = @"\A([fF][iI][nN])\Z";

            Match m;

            try
            {
                foreach (var sentencia in sentencias)
                {

                    m = Regex.Match(sentencia, inicio,
                                    RegexOptions.IgnoreCase | RegexOptions.Compiled,
                                    TimeSpan.FromSeconds(1));
                    if (m.Success)
                    {
                        tbDebug.Text += "Sentencia Correcta de Inicio \r\n";
                    }
                    else
                    {
                        m = Regex.Match(sentencia, mensage,
                                   RegexOptions.IgnoreCase | RegexOptions.Compiled,
                                   TimeSpan.FromSeconds(1));
                        if (m.Success)
                        {
                            tbDebug.Text += "Sentencia Correcta de Mensaje \r\n";
                        }
                        else
                        {
                            m = Regex.Match(sentencia, contador,
                                   RegexOptions.IgnoreCase | RegexOptions.Compiled,
                                   TimeSpan.FromSeconds(1));
                            if (m.Success)
                            {
                                tbDebug.Text += "Sentencia Correcta de Contador \r\n";
                            }
                            else
                            {
                                m = Regex.Match(sentencia, fin,
                                   RegexOptions.IgnoreCase | RegexOptions.Compiled,
                                   TimeSpan.FromSeconds(1));
                                if (m.Success)
                                {
                                    tbDebug.Text += "Sentencia Correcta de Fin \r\n";
                                }
                                else
                                {
                                    tbDebug.Text += "--Error de compilacion--\r\nNo se reconoce la sentencia [" + sentencia + "] \r\n \r\n";
                                    compila = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (RegexMatchTimeoutException)
            {
                tbDebug.Text +=  "The matching operation timed out.";
            }
            if (compila)
            {
                tbDebug.Text += " --Compilacion correcta-- \r\n \r\n";
            }
            return compila;
        }



        ///////////////////////////////////////////COLOREAR TEXTO////////////////////////////////////////////////////////
        private void TBCode_TextChanged(object sender, EventArgs e)
        {
            string[] palabrasReservadas = { "Inicio", "Fin", "Mensaje", "Contador" };
            try
            {
                TBCode.SelectionStart = 0;
                TBCode.SelectionLength = TBCode.TextLength;
                TBCode.SelectionColor = TBCode.ForeColor;


                foreach (var palabraReservada in palabrasReservadas)
                {
                    int index = 0;
                    while (index <= TBCode.Text.LastIndexOf(palabraReservada))
                    {
                        TBCode.Find(palabraReservada, index, TBCode.TextLength, RichTextBoxFinds.WholeWord);
                        switch (palabraReservada)
                        {
                            case "Inicio":
                                TBCode.SelectionColor = Color.Red;
                                break;
                            case "Mensaje":
                                TBCode.SelectionColor = Color.Green;
                                break;
                            case "Contador":
                                TBCode.SelectionColor = Color.Blue;
                                break;
                            case "Fin":
                                TBCode.SelectionColor = Color.Red;
                                break;
                            default:
                                break;
                        }
                        index = TBCode.Text.IndexOf(palabraReservada, index) + 1;
                    }
                }
                TBCode.SelectionStart = TBCode.TextLength;
                TBCode.SelectionColor = TBCode.ForeColor;
            }
            catch (Exception ex)
            {
                tbDebug.Text += ex.Message;
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TBCode.Text = "Inicio;\r\n";
            TBCode.Text += "Mensaje[hola];\r\n";
            TBCode.Text += "Contador[6];\r\n";
            TBCode.Text += "Fin;";
        }

        private void tbDebug_TextChanged(object sender, EventArgs e)
        {

        }

        private void viewTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewTest)
            {
                button1.Visible = false;
                viewTest = false;
            }else
            {
                button1.Visible = true;
                viewTest = true;
            }
        }
    }
}
