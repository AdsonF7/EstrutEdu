using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EstrutEdu
{

    enum TipoFlambagem
    {
        Euler,
        Timoshenko,
        NonLinear
    }

   
    enum CoeficienteFlambagem
    {
        K1, K2, K3, K4, K5
    }

    public class Flambagem : MonoBehaviour
    {
        #region inputs
        
        #endregion

        public float CoeficienteFlambagem => 1;
        public double BaseSecao = 0.1;
        public double LarguraSecao = 0.1;
        public double Amplitude = 0.05f;
        public int numeroVertices = 50;
        public double Exagero = 1;
        public FlambagemMenu menu;
        public GameObject Objeto { get; set; }

        void Start()
        {
            menu = new FlambagemMenu();
            menu.dd_Material.onValueChanged.AddListener(OnMaterialMudado);
            menu.dd_SecaoPilar.onValueChanged.AddListener(OnSecaoPilarMudado);

            Objeto = new GameObject("Box_");
            Objeto.transform.parent = this.transform;
            Objeto.transform.localPosition = new Vector3(0, 0, 0);

            MeshFilter mf = Objeto.AddComponent<MeshFilter>();
            MeshRenderer mr = Objeto.AddComponent<MeshRenderer>();
            UnityEngine.Material mat = Resources.Load<UnityEngine.Material>("Aco");
            mr.material = mat;

            var secaoPilarInicial = menu.dd_SecaoPilar.options[0].text;
            var secaoVisualizador = Utils.ListaSecoes[secaoPilarInicial];
            var secaoObjeto = Activator.CreateInstance(secaoVisualizador.Forma, menu.BaseSecao, menu.AlturaSecao) as Secao;
            secaoObjeto.Extrude(menu.AlturaTotal, ref mf);

            
        }

        void Update()
        {

        }

        void OnMaterialMudado(int index)
        {
            var material = menu.dd_Material.options[index].text;

            var materialPropriedades = Utils.ListaMateriais[material];
            
            UnityEngine.Material mat = Resources.Load<UnityEngine.Material>(materialPropriedades.NomeMaterialUnity);
            var b = Objeto.GetComponent<MeshRenderer>();
            b.material = mat;
        }

        void OnSecaoPilarMudado(int index)
        {
            var secaoPilar = menu.dd_SecaoPilar.options[index].text;
            var filtro = Utils.ListaSecoes[secaoPilar].Menu;
            Utils.SeletorMenuLateral(menu.ListaObjetos, filtro);
            var a = Objeto.GetComponent<MeshFilter>();
            var secaoVisualizador = Utils.ListaSecoes[secaoPilar];
            var secaoObjeto = Activator.CreateInstance(secaoVisualizador.Forma, menu.BaseSecao, menu.AlturaSecao) as Secao;
            secaoObjeto.Extrude(menu.AlturaTotal, ref a);
        }

        public struct Vertice
        {
            public double X, Y;
            public Vertice(
                double x, 
                double y)
            {
                X = x;
                Y = y;
            }
        }

        public static double CargaCriticaEuler(
             MaterialPropriedades material,
             Secao secao,
             float alturaTotal,
             float coeficienteFlambagem)
        {
            return (
                Math.Pow(
                    Math.PI, 
                    2) 
                *material.ModuloElasticidade 
                *secao.MenorMomentoInercia) 
                /(Math.Pow(
                    alturaTotal, 
                    2) 
                *coeficienteFlambagem);
        }
    }


}
