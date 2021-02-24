using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DivisionPorGrupos;

namespace UnitTestReparticion
{
    [TestClass]
    public class UnitTest1
    {
        private string[] pathStudents = { "Juan", "Pedro", "Maria" };
        private string[] pathTemas = { "Matematicas", "Quimica", "Fisica" };
        private double Grupos = 2;

        [TestMethod]
        public void ProbabilityStudents()
        {
            Reparticion reparticion = new Reparticion(pathStudents, pathTemas, Convert.ToInt32(Grupos));
            reparticion.ReparticionRandom();

            int i = 0;
            foreach (string x in reparticion.ContenedorEstudiantes)
            {
                if (x == "Maria") { i++; } 
            }
            double prob = i / Grupos;

            Assert.AreEqual(1 / Grupos, prob);
        }

        [TestMethod]
        public void ProbabilityTemas()
        {
            Reparticion reparticion = new Reparticion(pathStudents, pathTemas, Convert.ToInt32(Grupos));
            reparticion.ReparticionRandom();

            int i = 0;
            foreach (string x in reparticion.ContenedorTemas)
            {
                if (x == "Quimica") { i++; }
            }
            double prob = i / Grupos;

            Assert.AreEqual(1 / Grupos, prob);
        }

        [TestMethod]
        public void Temas_ArgumentOutOfRange()
        {
            if (pathTemas.Length < Grupos)
            {
                throw new ArgumentOutOfRangeException("Temas", "La cantidad de temas debe ser >= a la cantidad de grupos");
            }
        }

        [TestMethod]
        public void Grupos_ArgumentOutOfRange()
        {
            if (pathStudents.Length < Grupos)
            {
                throw new ArgumentOutOfRangeException("Grupos", "La cantidad de grupos debe ser <= a la cantidad de estudiantes");
            }
        }
    }
}
