using System;
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

            // Inicializa la locacion segun el tipo de documento a escanear
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
        public static bool operator ==(Escaner e, Documento d)
        {
            return e.listaDocumentos.Any(doc => doc == d);
        }

        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        public static bool operator +(Escaner e, Documento d)
        {
            // Para que no haya error el escaner y el documento tienen que ser iguales, para no guardar un libro en mapas
            if (e.Tipo == TipoDoc.libro && d is Libro || e.Tipo == TipoDoc.mapa && d is Mapa)
            {
                if (e != d && d.Estado == Documento.Paso.Inicio) // Si el documento no se encuentra en el escaner y esta en el inicio
                {
                    e.CambiarEstadoDocumento(d); // Avanza un estado
                    e.listaDocumentos.Add(d); // Y lo mete en la lista de documentos
                    return true;
                }
            }
            return false;
        }

        public bool CambiarEstadoDocumento(Documento d)
        {
            if (listaDocumentos.Contains(d)) // Si el documento se encuentra en la lista continua
            {
                return d.AvanzarEstado(); // Llama al metodo AvanzarEstado para pasar al siguiente estado
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

