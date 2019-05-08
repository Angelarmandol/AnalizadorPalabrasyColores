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
        public int sanitize(string text) // this method search and verifica el lexico
        {
            errors = 4;

            if (text.Contains("inicio;") || text.Contains("Inicio"))
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
                cnt = Convert.ToInt32(words2[0]);
            }
            if (text.Contains("fin;") || text.Contains("Fin;")) // call to token ?
            {
                Console.WriteLine("Contains Fin");
                fin = true;
            }
            if (inicio)
                errors--;
            if (mensaje)
                errors--;
            if (contador)
                errors--;
            if (fin)
                errors--;


            return errors;
           

        }

     
    }
}