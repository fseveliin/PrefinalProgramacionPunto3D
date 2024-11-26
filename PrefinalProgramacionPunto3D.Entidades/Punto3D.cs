using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefinalProgramacionPunto3D.Entidades
{
    internal class Punto3D
    {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
            public string Color { get; set; }

            public Punto3D(int x, int y, int z, string color)
            {
                X = x;
                Y = y;
                Z = z;
                Color = color;
            }

            public double CalcularDistanciaOrigen()
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }

            public override string ToString()
            {
                return $"Punto3D(X: {X}, Y: {Y}, Z: {Z}, Color: {Color})";
            }

            public override bool Equals(object obj)
            {
                if (obj is Punto3D otroPunto)
                    return X == otroPunto.X && Y == otroPunto.Y && Z == otroPunto.Z;
                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y, Z);
            }
        }
    }


