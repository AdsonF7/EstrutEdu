//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ColunaRetangularModel : MonoBehaviour
//{
//    public int Divisoes = 50;
//    private MeshFilter FiltroMalha = new MeshFilter();
//    public Secao Secao { get; set; }
//    public float BaseSecao { get; set; } = 0.2f;
//    public float AlturaSecao { get; set; } = 0.2f;
//    public float Comprimento { get; set; } = 3f;

//    public ColunaRetangularModel()
//    {
//        Secao = new SecaoRetangular(
//            BaseSecao, 
//            AlturaSecao);

//        Secao.Extrude(
//            AlturaSecao,
//            ref FiltroMalha,
//            Divisoes);
//    }
//}