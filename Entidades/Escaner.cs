
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
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
        Departamento locacion;
        string marca;
        TipoDoc tipo;
        List<Documento> listaDocumentos;



        // Propiedades  //

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

        // Metodos  //
     
        public bool CambiarEstadoDocumento(Documento d)
        {
            return d.AvanzarEstado();
        }

        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>(); // Intanciamos una lista

            switch (this.tipo) // Hacemos un switch para elegir el tipo
            {
                case TipoDoc.libro:
                    locacion = Departamento.procesosTecnicos;
                    break;
                case TipoDoc.mapa:
                    locacion = Departamento.mapoteca;
                    break;
                default:
                    locacion = Departamento.nulo;
                    break;
            }
        }



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
            return !(e == d); // Retorna un false
        }

        

        public static bool operator +(Escaner e, Documento d)
        {
            if (e.tipo == TipoDoc.libro && d is Libro || e.tipo == TipoDoc.mapa && d is Mapa)
            {
                if (e != d && d.Estado == Documento.Paso.Inicio)
                {
                    e.CambiarEstadoDocumento(d); // Avanza un estado
                    e.listaDocumentos.Add(d); // Adhiere el documento en la lista
                    return true;
                }
            }
            return false;
        }
    }
}

