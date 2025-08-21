using EstrutEdu;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FlambagemMenu : MonoBehaviour
{
    public double Exagero { get; private set; }
    public double Carga { get; private set; }
    public double BaseSecao { get; private set; }
    public double AlturaSecao { get; private set; }
    public Secao SecaoPilar { get; private set; }

    public Dropdown dd_SecaoPilar;
    public Dropdown dd_Material;
    public Slider sld_BaseSecao;
    public Slider sld_AlturaSecao;
    public Slider sld_Exagero;
    public Slider sld_Carga;
    public TextMeshProUGUI txt_Secao;
    public TextMeshProUGUI txt_Carga;

    public void Start()
    {
        foreach (var kvp in Utils.ListaMateriais)
        {
            dd_Material.options.Add(new Dropdown.OptionData() { text = kvp.Key });
        }

        foreach (var kvp in Utils.ListaSecoes)
        {
            dd_SecaoPilar.options.Add(new Dropdown.OptionData() { text = kvp.Key });
        }
        txt_Secao = GameObject.Find("txt_Secao").GetComponent<TextMeshProUGUI>();
        txt_Carga = GameObject.Find("txt_Carga").GetComponent<TextMeshProUGUI>();
        dd_SecaoPilar = GameObject.Find("dd_SecaoPilar").GetComponent<Dropdown>();
        sld_BaseSecao = GameObject.Find("sld_BaseSecao").GetComponent<Slider>();
        sld_AlturaSecao = GameObject.Find("sld_AlturaSecao").GetComponent<Slider>();
        sld_Exagero = GameObject.Find("sld_Exagero").GetComponent<Slider>();
        sld_Carga = GameObject.Find("sld_Carga").GetComponent<Slider>();

    }

    public void AlterarTxts(float alturaSecao, float baseSecao, float carga)
    {
        txt_Secao.text = $"Seção: {alturaSecao:F2}m x {baseSecao:F2}m";
        txt_Carga.text = $"Carga: {carga:F2}N";
    }
}