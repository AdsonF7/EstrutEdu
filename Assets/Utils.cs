using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrutEdu
{
    public class Utils
    {
        public static Dictionary<string, Material> ListaMateriais
        {
            get
            {
                return new Dictionary<string, Material>()
                {

                    { "Aço", new Material(
                        "Aço",
                        210000,
                        250,
                        0.3f) },
                    { "Concreto", new Material(
                        "Concreto",
                        30000,
                        30,
                        0.2f) },
                    { "Alumínio", new Material(
                        "Alumínio",
                        70000,
                        100,
                        0.33f) },
                    { "Madeira", new Material(
                        "Madeira",
                        12000,
                        5,
                        0.4f) }
                };
            }
        }
        public static Dictionary<string, Type> ListaSecoes
        {
            get { 
                return new Dictionary<string, Type>()
                {
                    { "Retangular", typeof(SecaoRetangular) },
                    { "Circular", typeof(SecaoCircular) }
                };
            }
        }
    }
}
