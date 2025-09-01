using EstrutEdu;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class FlambagemMenu : MonoBehaviour
{
    public float Exagero { get; set; } = 1f;
    public float Carga { get; set; } = 1f;
    public float AlturaPilar { get; set; } = 3f;
    public float ParamA { get; private set; } = 0.2f;
    public float ParamB { get; private set; } = 0.2f;
    public float ParamC { get; private set; } = 3f;
    public float ParamD { get; private set; } = 3f;
    public float ParamE { get; private set; } = 3f;
    public MaterialPropriedades MaterialPropriedades { get; set; }
    public SecaoVisualizadorParametros SecaoVisualizadorParametros { get; set; }
    public Secao SecaoAtual { get; set; }
    public TMP_Dropdown dd_SecaoPilar;
    public TMP_Dropdown dd_Material;
    public Slider sld_ParamA;
    public Slider sld_ParamB;
    public Slider sld_ParamC;
    public Slider sld_ParamD;
    public Slider sld_ParamE;
    public Slider sld_AlturaPilar;
    public Slider sld_Exagero;
    public Slider sld_Carga;

    public TextMeshProUGUI txt_SecaoInfo;
    public TextMeshProUGUI txt_CargaInfo;
    public TextMeshProUGUI txt_CargaCriticaInfo;
    public TextMeshProUGUI txt_ModElasticidadeInfo;
    public TextMeshProUGUI txt_SecaoPilarInfo;

    public TextMeshProUGUI txt_ParamA;
    public TextMeshProUGUI txt_ParamB;
    public TextMeshProUGUI txt_ParamC;
    public TextMeshProUGUI txt_ParamD;
    public TextMeshProUGUI txt_ParamE;

    public List<GameObject> ListaObjetos;

    public FlambagemMenu()
    {
        txt_ParamA = GameObject.Find("txt_ParamA").GetComponent<TextMeshProUGUI>();
        txt_ParamB = GameObject.Find("txt_ParamB").GetComponent<TextMeshProUGUI>();
        txt_ParamC = GameObject.Find("txt_ParamC").GetComponent<TextMeshProUGUI>();
        txt_ParamD = GameObject.Find("txt_ParamD").GetComponent<TextMeshProUGUI>();
        txt_ParamE = GameObject.Find("txt_ParamE").GetComponent<TextMeshProUGUI>();

        txt_SecaoInfo = GameObject.Find("txt_SecaoInfo").GetComponent<TextMeshProUGUI>();
        txt_CargaInfo = GameObject.Find("txt_CargaInfo").GetComponent<TextMeshProUGUI>();
        txt_CargaCriticaInfo = GameObject.Find("txt_CargaCriticaInfo").GetComponent<TextMeshProUGUI>();
        
        sld_ParamA = GameObject.Find("sld_ParamA").GetComponent<Slider>();
        sld_ParamB = GameObject.Find("sld_ParamB").GetComponent<Slider>();
        sld_ParamC = GameObject.Find("sld_ParamC").GetComponent<Slider>();
        sld_ParamD = GameObject.Find("sld_ParamD").GetComponent<Slider>();
        sld_ParamE = GameObject.Find("sld_ParamE").GetComponent<Slider>();

        sld_AlturaPilar = GameObject.Find("sld_AlturaPilar").GetComponent<Slider>();
        dd_SecaoPilar = GameObject.Find("dd_SecaoPilar").GetComponent<TMP_Dropdown>();
        sld_Exagero = GameObject.Find("sld_Exagero").GetComponent<Slider>();
        sld_Carga = GameObject.Find("sld_Carga").GetComponent<Slider>();

        AlturaPilar = sld_AlturaPilar.value;
        Carga = sld_Carga.value;
        Exagero = sld_Exagero.value;
        
        dd_Material = GameObject.Find("dd_Material").GetComponent<TMP_Dropdown>();

        ListaObjetos = new List<GameObject>() {
            sld_ParamA.gameObject,
            sld_ParamB.gameObject,
            sld_ParamC.gameObject,
            sld_ParamD.gameObject,
            sld_ParamE.gameObject,
            txt_ParamA.gameObject,
            txt_ParamB.gameObject,
            txt_ParamC.gameObject,
            txt_ParamD.gameObject,
            txt_ParamE.gameObject,
        };

        foreach (var kvp in Utils.ListaMateriais)
        {
            dd_Material.options.Add(
                new TMP_Dropdown.OptionData() { text = kvp.Key });
        }

        foreach (var kvp in Utils.ListaSecoes)
        {
            dd_SecaoPilar.options.Add(
                new TMP_Dropdown.OptionData() { text = kvp.Key });
        }

        

        dd_SecaoPilar.RefreshShownValue();
        dd_Material.RefreshShownValue();

        var secaoPilarInicial = dd_SecaoPilar.options[dd_SecaoPilar.value].text;
        var materialPropriedadesIncial = dd_Material.options[dd_Material.value].text;

        MaterialPropriedades = Utils.ListaMateriais[materialPropriedadesIncial];
        SecaoVisualizadorParametros = Utils.ListaSecoes[secaoPilarInicial];
        Debug.Log(MaterialPropriedades);
        Utils.SeletorMenuLateral(ListaObjetos, SecaoVisualizadorParametros.Menu);

        //AlterarTxts(SecaoVisualizadorParametros.Forma.);
    }

    

    public void AlterarTxts(string info)
    {
        txt_SecaoInfo.text = info;
        txt_CargaInfo.text = $"Carga: {Carga:F2}N";
    }

    public void AlterarCargaCriticaInfo(double cargaCritica)
    {
        txt_CargaCriticaInfo.text = $"Carga Critica: {cargaCritica.ToString("E")}N";
    }
}