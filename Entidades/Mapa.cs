using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        // Campos //
        private int alto;
        private int ancho;


        //  Constructor  //
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.ancho = ancho;
            this.alto = alto;
        }
       

        //  Propiedades  //
        public int Alto
        {
            get { return alto; } // Con get solo se obtiene el valor pero no se puede editar
        }
        public int Ancho
        {
            get { return ancho; }
        }
        public int Superficie
        {
            get { return ancho * alto; }
        }

        //  Metodos  //

        public static bool operator ==(Mapa m1, Mapa m2) // Si entre los dos libros hay una equvalencia de abajo retorna un true 
        {
            return m1.Barcode == m2.Barcode || (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie);
        }

        public static bool operator !=(Mapa m1, Mapa m2) // Sino retorna un flase
        {
            return !(m1 == m2);
        }

        public override string ToString() // Usando StringBuilder unimos la informacion del libro en un string
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Titulo : {Titulo}");
            sb.AppendLine($"Autor: {Autor}");
            sb.AppendLine($"Año: {Anio}");
            sb.AppendLine($"Cod de barra : {Barcode}");
            sb.AppendLine($"Superficie: {alto} * {ancho} = {Superficie} cm2");
            return sb.ToString();
        }
    }
}
