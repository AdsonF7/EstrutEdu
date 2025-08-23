using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EstrutEdu
{
    public class Utils
    {
        public static Dictionary<string, MaterialPropriedades> ListaMateriais
        {
            get
            {
                return new Dictionary<string, MaterialPropriedades>()
                {
                    { "Aço Estrutural (Carbono)", new MaterialPropriedades(
                        "Aço Estrutural",
                        200000f,
                        250f,
                        0.30f,
                        "Aco") },
                    { "Aço Inoxidável 304", new MaterialPropriedades(
                        "Aço Inox 304",
                        193000f,
                        290f,
                        0.30f,
                        "Aco") },
                    { "Aço Inoxidável 440A", new MaterialPropriedades(
                        "Aço Inox 440A",
                        200000f,
                        290f,
                        0.30f,
                        "Aco") },
                    { "Aço Ferramenta H13", new MaterialPropriedades(
                        "Aço H13",
                        215000f,
                        450f,
                        0.30f,
                        "Aco") },
                    { "Concreto", new MaterialPropriedades(
                        "Concreto",
                        30000,
                        30,
                        0.2f,
                        "Concreto") },
                    { "Alumínio", new MaterialPropriedades(
                        "Alumínio (Genérico)",
                        69000,
                        100,
                        0.33f,
                        "Aluminio") },
                    { "Madeira", new MaterialPropriedades(
                        "Madeira",
                        12000,
                        5,
                        0.4f,
                        "Madeira") },
                    { "Ipê", new MaterialPropriedades(
                        "Ipê",
                        18000f,
                        100f,
                        0.40f,
                        "Madeira") },
                    { "Jatobá", new MaterialPropriedades(
                        "Jatobá",
                        23600f,
                        120f,
                        0.40f,
                        "Madeira") },
                    { "Freijó (seco)", new MaterialPropriedades(
                        "Freijó",
                        11101f,
                        95f,
                        0.40f,
                        "Madeira") },
                    { "Pinus elliottii (seco)", new MaterialPropriedades(
                        "Pinus elliottii",
                        8846f,
                        70f,
                        0.40f,
                        "Madeira") }
                };
            }
        }
        public static Dictionary<string, SecaoVisualizadorParametros> ListaSecoes
        {
            get
            {
                return new Dictionary<string, SecaoVisualizadorParametros>()
                {
                    { "Seção Circular", new SecaoVisualizadorParametros(
                        typeof(SecaoCircular),
                        new List<string> {
                            "sld_RaioSecao",
                            "txt_RaioSecao" }) },
                    { "Seção Retangular", new SecaoVisualizadorParametros(
                        typeof(SecaoRetangular),
                        new List<string> {
                            "sld_BaseSecao",
                            "sld_AlturaSecao",
                            "txt_BaseSecao",
                            "txt_AlturaSecao" }) },
                    
                    //{ "Viga T", typeof(SecaoVigaT) },
                    //{ "Viga H", typeof(SecaoVigaH) }
                };
            }
        }
        public static void SeletorMenuLateral(List<GameObject> objetos, List<string> filtro)
        {
            foreach (GameObject objeto in objetos)
            {
                objeto.SetActive(false);
                if (filtro.Contains(objeto.name))
                {
                    objeto.SetActive(true);
                }
            }
        }
    }

    public struct SecaoVisualizadorParametros
    {
        public Type Forma { get; set; }
        public List<string> Menu { get; set; }

        public SecaoVisualizadorParametros(Type forma, List<string> menu)
        {
            Forma = forma;
            Menu = menu;
        }
    }

    
}