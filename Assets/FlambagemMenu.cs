using EstrutEdu;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class FlambagemMenu : MonoBehaviour
{
    public float Exagero { get; private set; } = 1f;
    public float Carga { get; private set; } = 1f;
    public float BaseSecao { get; private set; } = 0.2f;
    public float AlturaSecao { get; private set; } = 0.2f;
    public float AlturaTotal { get; private set; } = 3f;

    public Secao Secao { get; private set; }
    public MaterialPropriedades MaterialPropriedades { get; private set; }

    public TMP_Dropdown dd_SecaoPilar;
    public TMP_Dropdown dd_Material;
    public Slider sld_BaseSecao;
    public Slider sld_AlturaSecao;
    public Slider sld_Exagero;
    public Slider sld_RaioSecao;
    public Slider sld_Carga;
    public TextMeshProUGUI txt_Secao;
    public TextMeshProUGUI txt_Carga;
    public TextMeshProUGUI txt_BaseSecao;
    public TextMeshProUGUI txt_AlturaSecao;
    public TextMeshProUGUI txt_RaioSecao;
    public List<GameObject> ListaObjetos;

    public FlambagemMenu()
    {
        txt_BaseSecao = GameObject.Find("txt_BaseSecao").GetComponent<TextMeshProUGUI>();
        txt_AlturaSecao = GameObject.Find("txt_AlturaSecao").GetComponent<TextMeshProUGUI>();
        txt_RaioSecao = GameObject.Find("txt_RaioSecao").GetComponent<TextMeshProUGUI>();
        txt_Secao = GameObject.Find("txt_Secao").GetComponent<TextMeshProUGUI>();
        txt_Carga = GameObject.Find("txt_Carga").GetComponent<TextMeshProUGUI>();
        dd_SecaoPilar = GameObject.Find("dd_SecaoPilar").GetComponent<TMP_Dropdown>();
        sld_BaseSecao = GameObject.Find("sld_BaseSecao").GetComponent<Slider>();
        sld_AlturaSecao = GameObject.Find("sld_AlturaSecao").GetComponent<Slider>();
        sld_RaioSecao = GameObject.Find("sld_RaioSecao").GetComponent<Slider>();
        sld_Exagero = GameObject.Find("sld_Exagero").GetComponent<Slider>();
        sld_Carga = GameObject.Find("sld_Carga").GetComponent<Slider>();
        
        dd_Material = GameObject.Find("dd_Material").GetComponent<TMP_Dropdown>();

        ListaObjetos = new List<GameObject>() {
            sld_BaseSecao.gameObject,
            sld_AlturaSecao.gameObject,
            sld_RaioSecao.gameObject,
            txt_BaseSecao.gameObject, 
            txt_AlturaSecao.gameObject,
            txt_RaioSecao.gameObject
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

        var secaoPilarInicial = dd_SecaoPilar.options[0].text;
        var secaoVisualizador = Utils.ListaSecoes[secaoPilarInicial];
        Utils.SeletorMenuLateral(ListaObjetos, secaoVisualizador.Menu);
        
    }

    

    public void AlterarTxts()
    {
        txt_Secao.text = $"Seção: {AlturaSecao:F2}m x {BaseSecao:F2}m";
        txt_Carga.text = $"Carga: {Carga:F2}N";
    }
}