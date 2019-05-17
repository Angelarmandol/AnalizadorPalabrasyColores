using System;

namespace MiniCompilador
{
    internal class CompilerClass
    {
       
        string fullText; //this contain all unclean text
        string msg; //user message
        bool inicio, mensaje, contador, fin; //flags
        int cnt; //counter
        int errors=4; // 
        String errorCompilatorText;
        public int sanitize(string text) // this method search and verifica el lexico
        {

            ///////////////////////////////////////////////////////Restar values
            Console.WriteLine("texto a tratar: "+text);
            errorCompilatorText = null;
            errors = 4;
            inicio = false;
            mensaje = false;
            contador = false;
            fin =false;
            /////////////////////////////////////////////////////////

            if (text.Contains("inicio;") || text.Contains("Inicio;"))
            { // call to token ?
                Console.WriteLine("Contains inicio");
                inicio = true;
            }
            if (text.Contains("mensaje[") || text.Contains("Mensaje[")) // call to token ?
            {
                Console.WriteLine("Contains mensage");
                mensaje = true;
                msg = text.Substring(17);

                string[] words = msg.Split(']');
                msg = words[0];
            }
            if (text.Contains("contador[") || text.Contains("Contador[")) // call to token ?
            {
                Console.WriteLine("Contains Contador");
                contador = true;
                string counterSubString = text.Substring(34);
                string[] words2 = counterSubString.Split(']');

                try
                {
                    cnt = Convert.ToInt32(words2[0]);
                }
                catch
                {
                    setErrorCompilatorText("Word position exception  \r\n");
                }


            }
            if (text.Contains("fin;") || text.Contains("Fin;")) // call to token ?
            {
                Console.WriteLine("Contains Fin");
                fin = true;
            }


            if (inicio) {
                errors--;
            }
            else
            {
                setErrorCompilatorText("No se encuenta inicio \r\n");
            }
            if (mensaje)
            {
                errors--;
            }
            else
            {
                setErrorCompilatorText("No se encuenta Mensaje[] \r\n");
            }
            if (contador) { 
            errors--;
            }
            else
            {
                setErrorCompilatorText("No se encuenta contador[] \r\n");            }
            if (fin)
            {
                errors--;
            }
            else
            {
                setErrorCompilatorText("No se encuenta fin; \r\n");
            }


            Console.WriteLine("errores: "+errors);
            return errors;
            
        }

     
        public string getErrorCompilatorText()
        {
            return errorCompilatorText;
        }
        
        private void setErrorCompilatorText(string text)
        {
            errorCompilatorText += text; 
           
        }


        
    }// class end
}