

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        //  Campos  //
        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;


        // Constructor //
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>(); // Inicializa la lista de documentos

            // Inicializa la locacion según el tipo de documento a escanear
            this.locacion = (tipo == TipoDoc.mapa) ? Departamento.mapoteca : Departamento.procesosTecnicos;
        }


        //  Propiedades  //
        public List<Documento> ListaDocumentos
        {
            get { return listaDocumentos; }
        }
        public Departamento Locacion
        {
            get { return locacion; }
        }
        public string Marca
        {
            get { return marca; }
        }
        public TipoDoc Tipo
        {
            get { return tipo; }
        }


        //  Metodos  //
        public static bool operator ==(Escaner e, Documento d) // averigua si el documento esta en el escaner
        {
            bool retorno;
            retorno = false;
            if (e.tipo == TipoDoc.libro)
            {
                try
                {
                    foreach (Libro doc in e.listaDocumentos)
                    {
                        if (doc == (Libro)d)
                        {
                            retorno = true;
                        }
                    }
                }
                catch (InvalidCastException excepcion)
                {
                    Console.WriteLine(excepcion.Message);
                }
            }
            else
            {
                try
                {
                    foreach (Mapa doc in e.listaDocumentos)
                    {
                        if (doc == (Mapa)d)
                        {
                            retorno = true;
                        }
                    }
                }
                catch (InvalidCastException excepcion)
                {
                    Console.WriteLine(excepcion.Message);
                }
            }
            return retorno;
        }

        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        public static bool operator +(Escaner e, Documento d)
        {

            if (e.Tipo == TipoDoc.libro && d is Libro || e.Tipo == TipoDoc.mapa && d is Mapa)
            {
                if (e != d && d.Estado == Documento.Paso.Inicio)
                {
                    d.AvanzarEstado();
                    e.listaDocumentos.Add(d);
                    return true;
                }
            }
            return false;
        }

        public bool CambiarEstadoDocumento(Documento d)
        {
            if (listaDocumentos.Contains(d))
            {
                return d.AvanzarEstado();
            }
            return false;
        }


        //  Propiedades  //
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }
        public enum TipoDoc
        {
            libro,
            mapa
        }

    }
}
