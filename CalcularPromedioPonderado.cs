using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Kasandra Diaz, 17-SIIN-1-040

namespace ProyectoF
{
    public class CalcularPromedioPonderado
    {

        #region Propiedades
        public int Credito { get; set; }
        public decimal NotaFinal { get; set; }
        public String Asignatura { get; set; }
        #endregion

        private static CalcularPromedioPonderado Instance;
        public static CalcularPromedioPonderado GetInstance()
        {
            if (Instance == null)
                Instance = new CalcularPromedioPonderado();
            return Instance;
        }

        public void SetPromedioPonderado()
        {
            int valor;

            Console.WriteLine("¿Introduce la cantidad de asignaturas que inscribió en el cuatrimestre?");
            int a = Convert.ToInt32(Console.ReadLine());

            var esNumero = int.TryParse(a.ToString(), out valor);
            


            var items = new List<CalcularPromedioPonderado>();
            int contador = 1;
            for (int i = 1; i <= a; i++)
            {
                Console.WriteLine($"¿Introduce el nombre de la asignatura {contador}?");
                Asignatura = Console.ReadLine();

                Console.WriteLine($"¿Introduce el credito de la asignatura {contador}?");
                Credito = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"¿Introduce la nota final de la asignatura {contador}?");
                NotaFinal = Convert.ToDecimal(Console.ReadLine());

                items.Add(new CalcularPromedioPonderado
                {
                    Asignatura = Asignatura,
                    Credito = Credito,
                    NotaFinal = NotaFinal
                });

                contador = contador + 1;

            }

            if (items.Any())
            {
                var totalCalificacion = 0.0M;
                Console.WriteLine("---------------------------------------------------------------");
                contador = 1;
                foreach (var p in items)
                {
                    Console.WriteLine($"{contador}). Asignatura:\t{p.Asignatura}\t\tCredito:\t{p.Credito}\tNota Final:\t{p.NotaFinal}");
                    totalCalificacion += (p.Credito * p.NotaFinal);
                    contador++;
                }

                Console.WriteLine("---------------------------------------------------------------");

                var totalCredito = items.Sum(x => x.Credito);
                var promedioPonderado = totalCalificacion / totalCredito;
               
                Console.WriteLine("Promedio ponderado: " + promedioPonderado);
                Console.WriteLine("---------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("Debe introducir al menos una materia en el cuatrimestre?");
            }


        }


    }
}
