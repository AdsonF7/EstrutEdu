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
                        200e9f,
                        250f,
                        0.30f,
                        "Aco") },
                    { "Aço Inoxidável 304", new MaterialPropriedades(
                        "Aço Inox 304",
                        193e9f,
                        290f,
                        0.30f,
                        "Aco") },
                    { "Aço Inoxidável 440A", new MaterialPropriedades(
                        "Aço Inox 440A",
                        200e9f,
                        290f,
                        0.30f,
                        "Aco") },
                    { "Aço Ferramenta H13", new MaterialPropriedades(
                        "Aço H13",
                        215e9f,
                        450f,
                        0.30f,
                        "Aco") },
                    { "Concreto", new MaterialPropriedades(
                        "Concreto",
                        30e9f,
                        30,
                        0.2f,
                        "Concreto") },
                    { "Alumínio", new MaterialPropriedades(
                        "Alumínio (Genérico)",
                        69e9f,
                        100,
                        0.33f,
                        "Aluminio") },
                    { "Madeira", new MaterialPropriedades(
                        "Madeira",
                        12e9f,
                        5,
                        0.4f,
                        "Madeira") },
                    { "Ipê", new MaterialPropriedades(
                        "Ipê",
                        18e9f,
                        100f,
                        0.40f,
                        "Madeira") },
                    { "Jatobá", new MaterialPropriedades(
                        "Jatobá",
                        23.6e9f,
                        120f,
                        0.40f,
                        "Madeira") },
                    { "Freijó (seco)", new MaterialPropriedades(
                        "Freijó",
                        11.101e9f,
                        95f,
                        0.40f,
                        "Madeira") },
                    { "Pinus elliottii (seco)", new MaterialPropriedades(
                        "Pinus elliottii",
                        8.846e9f,
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
                        new List<Tuple<string, string>> {
                            new Tuple<string, string>("sld_ParamA", "" ),
                            new Tuple<string, string>("txt_ParamA", "Raio da Seção")}) },
                    { "Seção Retangular", new SecaoVisualizadorParametros(
                        typeof(SecaoRetangular),
                        new List<Tuple<string, string>> {
                            new Tuple<string, string>("sld_ParamA", ""),
                            new Tuple<string, string>("txt_ParamA", "Base da Seção"),
                            new Tuple<string, string>("sld_ParamB", ""),
                            new Tuple<string, string>("txt_ParamB", "Altura da Seção")}) },
                    
                    //{ "Viga T", typeof(SecaoVigaT) },
                    //{ "Viga H", typeof(SecaoVigaH) }
                };
            }
        }

        public static Dictionary<string, Apoio> ListaApoios
        {
            get
            {
                return new Dictionary<string, Apoio>
                {

                };
            }
        }

        public static void SeletorMenuLateral(List<GameObject> objetos, List<Tuple<string, string>> filtro)
        {
            objetos.ForEach(x => x.SetActive(false));

            foreach (var parametros in filtro)
            {
                objetos.Find(x => x.name == parametros.Item1)?
                    .SetActive(true);
            }
        }
    }

    public struct SecaoVisualizadorParametros
    {
        public Type Forma { get; set; }
        public List<Tuple<string, string>> Menu { get; set; }

        public SecaoVisualizadorParametros(Type forma, List<Tuple<string, string>> menu)
        {
            Forma = forma;
            Menu = menu;
        }
    }

    
}