using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Entidades
{
    public class Libro : Documento // Libro hereda de Documento
    {
        // Campos //
        private int numPaginas;


        //  Constructor  //
        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, codebar) // Llamamos a base
        {
            this.numPaginas = numPaginas;
        }

        //  Metodos  //
        public static bool operator ==(Libro l1, Libro l2)
        {
            return l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN || (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor);
            // Si hay una equivalencia retorna un true
        }

        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

        public override string ToString()// Usando StringBuilder unimos la informacion del libro en un string
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Titulo : {Titulo}");
            sb.AppendLine($"Autor: {Autor}");
            sb.AppendLine($"Año: {Anio}");       // Datos del mapa
            sb.AppendLine($"ISBN :{ISBN}");
            sb.AppendLine($"Cod de barra : {Barcode}");
            sb.AppendLine($"Numero de pagina: {NumPaginas}");
            return sb.ToString();
        }


        //  Propiedades  //
        public int NumPaginas
        {
            get { return numPaginas; }
        }

        public string ISBN
        {
            get { return NumNormalizado; }
        }

       
    }
}
