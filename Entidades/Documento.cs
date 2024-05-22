using System.Text;

namespace Entidades
{
    public abstract class Documento
    {
        // Campos //
        private int anio;
        private string autor;
        private string barcode;
        private Paso estado;       
        private string numNormalizado;
        private string titulo;


        // Constructor //
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio; // Se inicializa el estado en Inicio
        }


        // Propiedades //
        public int Anio
        {
            get { return anio; }
        }

        public string Autor
        {
            get { return autor; }
        }

        public string Barcode
        {
            get { return barcode; }
        }

        public Paso Estado
        {
            get { return estado; }
        }
        
        protected string NumNormalizado
        {
            get { return numNormalizado; }
        }

        public string Titulo
        {
            get { return titulo; }
        }


        // Metodos //
        public bool AvanzarEstado()
        {
            if (estado == Paso.Terminado) // Si el estado de libro o mapa esta terminado, entonces retorna un flase
                return false;

            estado++; // Sino va el siguiente paso
            return true;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Título: {titulo}");
            sb.AppendLine($"Autor: {autor}");
            sb.AppendLine($"Año: {anio}");
            sb.AppendLine($"NumNormalizado: {numNormalizado}");
            sb.AppendLine($"Barcode: {barcode}");
            sb.AppendLine($"Estado: {estado}");
            return sb.ToString();
        }

        // Tipos anidados //
        public enum Paso 
        {
            Inicio,
            Distribuido,
            Escanear,
            EnRevision,
            Terminado
        }
    }
}
