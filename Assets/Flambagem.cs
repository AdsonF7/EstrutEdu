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

        public GameObject pilar;
        public List<GameObject> vertices;
        public float CoeficienteFlambagem => 1;
        public double BaseSecao = 0.1;
        public double LarguraSecao = 0.1;
        public double Amplitude = 0.05f;
        public int numeroVertices = 50;
        public double Exagero = 1;
        public FlambagemMenu menu;
        void Start()
        {
            #region setup inputs
            FlambagemMenu menu = new FlambagemMenu();
            #endregion

        }

        void Update()
        {

            double cargaCritica = CargaCriticaEuler(
                Utils.ListaMateriais["Aço"],
                Activator.CreateInstance(Utils.ListaSecoes["Retangular"]) as Secao, 
                AlturaTotal, 
                CoeficienteFlambagem);

            List<Vertice> verticesList = SimularFlambagemFisica(
                numeroVertices, 
                AlturaTotal, 
                Amplitude, 
                menu.Carga, 
                cargaCritica, 
                menu.Exagero);

        }

        public struct Vertice
        {
            public double X, Y;
            public Vertice(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        public static double CargaCriticaEuler(
             Material material,
             Secao secao,
             float alturaTotal,
             float coeficienteFlambagem)
        {
            return (Math.Pow(Math.PI, 2) * material.ModuloElasticidade * secao.MenorMomentoInercia) /
                (Math.Pow(alturaTotal, 2) * coeficienteFlambagem);
        }

        public static List<Vertice> SimularFlambagemFisica(
            int numeroVertices,
            double alturaTotal,
            double amplitude,
            double carga, 
            double cargaCritica,
            double exagero
            )
        {
            double amplitudeMaxima = amplitude * (carga / cargaCritica) * exagero;
            var vertices = new List<Vertice>();

            for (int i = 0; i < numeroVertices; i++)
            {
                double y = i * (alturaTotal / (numeroVertices - 1));
                double x = amplitudeMaxima * Math.Sin(Math.PI * y / alturaTotal);
                vertices.Add(new Vertice(x, y));
            }

            return vertices;
        }
    }


}
