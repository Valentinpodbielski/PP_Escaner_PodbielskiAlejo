using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    public static class Informes
    {
        // Este metodo muestra los documentos que han sido distribuidos.
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            // Llama al metodo MostrarDocumentosPorEstado con el estado "Distribuido".
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        // Este metodo muestra los documentos por su estado.
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            var resumenBuilder = new StringBuilder();

            foreach (var doc in e.ListaDocumentos) // Va recorriendo los documentos de la lista de documentos
            {
                if (doc.Estado == estado)
                {
                    cantidad++;

                    if (doc is Libro libro) // si es libro suma las hojas
                    {
                        extension += libro.NumPaginas;
                    }
                    if (doc is Mapa mapa) // Si es mapa suma las superficies
                    {
                        extension += mapa.Superficie;
                    }
                    resumenBuilder.AppendLine(doc.ToString()); // Va uniendo las lineas
                }
            }
            // Informacion //
            resumenBuilder.AppendLine($"en la fila de: {estado}");
            resumenBuilder.AppendLine($"Cantidad total de documentos: {cantidad}");
            resumenBuilder.AppendLine($"Extensión total: {extension}");

            resumen = resumenBuilder.ToString();
        }

        // Este metodo muestra los documentos que estan en el escaner.
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            // Llama al metodo MostrarDocumentosPorEstado con el estado "Escanear".
            MostrarDocumentosPorEstado(e, Documento.Paso.Escanear, out extension, out cantidad, out resumen);
        }

        // Este metodo muestra los documentos que estan en revision.
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            // Llama al metodo MostrarDocumentosPorEstado con el estado "EnRevision".
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        // Este metodo muestra los documentos que han sido terminados.
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            // Llama al metodo MostrarDocumentosPorEstado con el estado "Terminado".
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}


