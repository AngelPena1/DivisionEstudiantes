using System;
using System.Collections.Generic;
using System.Threading;

namespace DivisionPorGrupos
{ 
    public class Reparticion
    {
        public List<string> ContenedorEstudiantes = new List<string>();
        public List<string> ContenedorTemas = new List<string>();
        Random rdm = new Random();
        private DateTime dateTime = new DateTime();
        private string[] pathStudents { get; set; }
        private string[] pathTemas { get; set; }
        private int Grupos { get; set; }

        public Reparticion(string[] pathStudents, string[] pathTemas, int Grupos)
        {
            this.pathStudents = pathStudents;
            this.pathTemas = pathTemas;
            this.Grupos = Grupos;
        }

        public void RandomStudents(string[] path)
        {
            int number;

            number = rdm.Next(path.Length);
            while (ContenedorEstudiantes.Contains(path[number]))
            {
                number = rdm.Next(path.Length);
            }
            ContenedorEstudiantes.Add(path[number]);
            Console.WriteLine("  {0}", path[number]);
        }
        public void RandomTemas(string[] path)
        {
            int number;

            number = rdm.Next(path.Length);
            while (ContenedorTemas.Contains(path[number]))
            {
                number = rdm.Next(path.Length);
            }

            ContenedorTemas.Add(path[number]);
            Console.WriteLine("  {0}", path[number]);
        }

        public void ReparticionRandom()
        {
            int EstAsignados, TemasAsignados, remanenteE, remanenteT, R1 = 0, R2 = 0;
            EstAsignados = this.pathStudents.Length / this.Grupos;
            TemasAsignados = this.pathTemas.Length / this.Grupos;
            remanenteE = this.pathStudents.Length % this.Grupos;
            remanenteT = this.pathTemas.Length % this.Grupos;

            for (int i = 0; i < Grupos; i++)
            {
                Console.WriteLine("Grupos {0}: ", i+1);

                //Reparticion de estudiantes
                for (int y = 0; y < EstAsignados; y++)
                {
                    RandomStudents(this.pathStudents);
                }
                Thread.Sleep(dateTime.Millisecond);
                if (remanenteE != 0 && (rdm.Next(2)==1)|| remanenteE != 0 && R1 == remanenteE)
                {
                    RandomStudents(this.pathStudents);
                    remanenteE--;
                }
                else
                {
                    R1++;
                }
                
                Thread.Sleep(dateTime.Millisecond);
                //Reparticion de temas.
                Console.WriteLine("Temas asignados: ");
                for (int y = 0; y < EstAsignados; y++)
                {
                    RandomTemas(this.pathTemas);
                }

                Thread.Sleep(dateTime.Millisecond);
                if (remanenteT != 0 && (rdm.Next(2) == 1) || remanenteT != 0 && R2 == remanenteT)
                {
                    RandomTemas(this.pathTemas);
                    remanenteT--;
                }
                else
                {
                    R2++;
                }
                Console.WriteLine();
            }


        }
    }
}
