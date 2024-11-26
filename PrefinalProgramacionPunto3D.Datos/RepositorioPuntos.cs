using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefinalProgramacionPunto3D.Datos
{
    internal class RepositorioPuntos
    {
            private List<Punto3D> puntos;

            public RepositorioPuntos()
            {
                puntos = new List<Punto3D>();
            }

            public int Cantidad => puntos.Count;

            public bool AgregarPunto(Punto3D punto)
            {
                if (puntos.Contains(punto)) return false;
                puntos.Add(punto);
                return true;
            }

            public List<Punto3D> ObtenerPuntos() => puntos;

            public bool EliminarPunto(Punto3D punto)
            {
                return puntos.Remove(punto);
            }

            public void OrdenarPorDistancia(bool ascendente)
            {
                puntos = ascendente
                    ? puntos.OrderBy(p => p.CalcularDistanciaOrigen()).ToList()
                    : puntos.OrderByDescending(p => p.CalcularDistanciaOrigen()).ToList();
            }

            public List<Punto3D> FiltrarPorColor(string color)
            {
                return puntos.Where(p => p.Color.Equals(color, System.StringComparison.OrdinalIgnoreCase)).ToList();
            }

            public void GuardarDatos(string rutaArchivo)
            {
                using var writer = new System.IO.StreamWriter(rutaArchivo);
                foreach (var punto in puntos)
                    writer.WriteLine($"{punto.X},{punto.Y},{punto.Z},{punto.Color}");
            }

            public void CargarDatos(string rutaArchivo)
            {
                puntos.Clear();
                if (!System.IO.File.Exists(rutaArchivo)) return;

                var lineas = System.IO.File.ReadAllLines(rutaArchivo);
                foreach (var linea in lineas)
                {
                    var datos = linea.Split(',');
                    puntos.Add(new Punto3D(
                        int.Parse(datos[0]),
                        int.Parse(datos[1]),
                        int.Parse(datos[2]),
                        datos[3]
                    ));
                }
            }
        }
    }