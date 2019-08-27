using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaVelocidad
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Random number = new Random();
            int columns = 300;
            int rows = 5000;
            String word;
            String line = "";
            String final = "";
            int[] sizes = new int[columns];
            int length;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    length = (sizes[j] == 0) ? number.Next(5, 20) : sizes[j];
                    word = p.GetWord(length, number);
                    line += (j != columns - 1) ? word + "," : word;
                    if (i == 0) sizes[j] = length;
                }
                final += (i + 1 == rows) ? line : line + "\n";
                line = "";
            }
         String path = @"D:\Usuarios\Registros.csv"; //Colocar la ruta en donde desea generar el archivo,  la extensión no se debe de modificar
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(final);
                }
            }
            else if (File.Exists(path))
            {
                File.Delete(path);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(final);
                }
            }

            Console.WriteLine("Archivo generado");

        }

        public string GetWord(int length, Random random)
        {
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }

        public string[] lines(string path)
        {
            return File.ReadAllLines(path);
        }

    }
}
