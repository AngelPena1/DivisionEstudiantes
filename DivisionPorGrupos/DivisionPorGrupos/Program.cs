using System;
using System.IO;
namespace DivisionPorGrupos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pathStudents = File.ReadAllLines(args[0]);
            string[] pathTemas = File.ReadAllLines(args[1]);
            int Grupos = Convert.ToInt32(args[2]);

            if (pathStudents.Length >= Grupos && pathTemas.Length >= Grupos)
            {
                Reparticion reparticion = new Reparticion(pathStudents, pathTemas, Grupos);
                reparticion.ReparticionRandom();
            }

            else
            {
                Console.WriteLine("Parametro No valido");
            }
           
          
        }
    }
}
