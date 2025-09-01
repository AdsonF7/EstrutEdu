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

    public class Flambagem : MonoBehaviour
    {
        #region inputs

        #endregion
        private int DIVISOES = 50;
        public class TiposFlambagem
        {
            public static float ARTICULADO_ARTICULADO = 1.0f;
            public static float ENGASTADO_LIVRE = 2.0f;
            public static float ENGASTADO_ENGASTADO = 0.5f;
            public static float ENGASTADO_ARTICULADO = 0.7f;
        }

        public float CoeficienteFlambagem => TiposFlambagem.ENGASTADO_ENGASTADO;
        public double BaseSecao = 0.1f;
        public double LarguraSecao = 0.1f;
        public double Amplitude = 0.05f;
        public int numeroVertices = 50;
        public double Exagero = 1f;
        public FlambagemMenu menu;
        public GameObject go_Engastado { get; private set; }
        public GameObject go_Articulado { get; private set; }
        public GameObject go_Pilar { get; set; }
        public GameObject go_ForcaVetor { get; set; }
        public TextMeshPro txt_CargaValor { get; set; }
        

        void Start()
        {
            go_ForcaVetor = GameObject.Find("go_VetorForca");
            txt_CargaValor = GameObject.Find("txt_CargaValor").GetComponent<TextMeshPro>();
            
            go_Articulado = GameObject.Find("go_Articulado");

            //go_Engastado.SetActive(false);
            //go_Articulado.SetActive(false);

            menu = new FlambagemMenu();
            menu.dd_Material.onValueChanged.AddListener(OnMaterialMudado);
            menu.dd_SecaoPilar.onValueChanged.AddListener(OnSecaoPilarMudado);
            menu.sld_AlturaPilar.onValueChanged.AddListener(OnAlturaPilarMudado);
            menu.sld_Carga.onValueChanged.AddListener(OnCargaMudado);
            menu.sld_Exagero.onValueChanged.AddListener(OnExageroMudado);

            go_Pilar = new GameObject("go_Pilar");
            go_Pilar.transform.parent = this.transform;
            go_Pilar.transform.localPosition = new Vector3(0, 1.5f, 0);

            MeshFilter filtroMalha = go_Pilar.AddComponent<MeshFilter>();
            MeshRenderer mr = go_Pilar.AddComponent<MeshRenderer>();
            UnityEngine.Material material = Resources.Load<UnityEngine.Material>(
                menu.MaterialPropriedades.NomeMaterialUnity);
            mr.material = material;

            var secaoObjeto = Activator.CreateInstance(
                menu.SecaoVisualizadorParametros.Forma, 
                menu.ParamA, 
                menu.ParamB,
                menu.ParamC,
                menu.ParamD,
                menu.ParamE) as Secao;

            menu.SecaoAtual = secaoObjeto;
            txt_CargaValor.text = $"{menu.Carga} N";
            secaoObjeto.Extrude(
                menu.AlturaPilar, 
                ref filtroMalha, 
                DIVISOES);

            Flambar(
                secaoObjeto,
                menu.AlturaPilar,
                menu.Carga,
                CoeficienteFlambagem,
                DIVISOES + 1,
                menu.Exagero,
                menu.MaterialPropriedades,
                ref filtroMalha);

            var cargaCritica = CargaCriticaEuler(
                menu.MaterialPropriedades,
                menu.SecaoAtual,
                menu.AlturaPilar,
                CoeficienteFlambagem);

            menu.AlterarCargaCriticaInfo(cargaCritica);

            menu.sld_Carga.maxValue = (float)cargaCritica;

            go_ForcaVetor.GetComponent<Transform>().localPosition += new Vector3(0, menu.AlturaPilar + 0.5f, 0);

            var go_Sapata = new GameObject("go_Sapata");
            var mf = go_Sapata.AddComponent<MeshFilter>();
            MeshRenderer mr2 = go_Sapata.AddComponent<MeshRenderer>();
            UnityEngine.Material material2 = Resources.Load<UnityEngine.Material>(
                menu.MaterialPropriedades.NomeMaterialUnity);
            mr2.material = material2;
            var sapata = new SapataModel();
            sapata.Altura = 0.2f;
            sapata.Base = 0.2f;
            sapata.Malha(ref mf);

        }

        void Update()
        {

        }

        public void Flambar(
            Secao secao,
            float comprimento,
            float carga,
            float coeficienteFlambagem,
            int divisoes,
            float exagero,
            MaterialPropriedades materialPropriedades,
            ref MeshFilter filtroMalha)
        {

            for (var i = 0; i < divisoes; i++)
            {
                var deslocamentoMaximo = DeslocamentoMaximo(
                    carga,
                    comprimento,
                    secao,
                    coeficienteFlambagem,
                    materialPropriedades);

                var deslocamento = Deslocamento(
                    i,
                    deslocamentoMaximo,
                    coeficienteFlambagem,
                    comprimento,
                    DIVISOES + 1);

                Debug.Log($"Deslocamento: {deslocamento}");
                Debug.Log($"Deslocamento Maximo: {deslocamentoMaximo}");
                secao.MoverDivisao(
                    i, 
                    (float)deslocamento * exagero,
                    (float)deslocamento * exagero,
                    0, 
                    ref filtroMalha);
            }
        }

        void OnMaterialMudado(int index)
        {
            var material = menu.dd_Material.options[index].text;

            var materialPropriedades = Utils.ListaMateriais[material];
            
            UnityEngine.Material mat = Resources.Load<UnityEngine.Material>(
                materialPropriedades.NomeMaterialUnity);

            menu.MaterialPropriedades = materialPropriedades;
          
            var b = go_Pilar.GetComponent<MeshRenderer>();
            b.material = mat;

            var cargaCritica = CargaCriticaEuler(
                menu.MaterialPropriedades,
                menu.SecaoAtual,
                menu.AlturaPilar,
                CoeficienteFlambagem);

            menu.AlterarCargaCriticaInfo(cargaCritica);

            menu.sld_Carga.maxValue = (float)cargaCritica;

            MeshFilter filtroMalha = go_Pilar.GetComponent<MeshFilter>();

            Flambar(
                menu.SecaoAtual,
                menu.AlturaPilar,
                menu.Carga,
                CoeficienteFlambagem,
                DIVISOES + 1,
                menu.Exagero,
                menu.MaterialPropriedades,
                ref filtroMalha);
        }

        void OnSecaoPilarMudado(int index)
        {
            var secaoPilar = menu.dd_SecaoPilar.options[index].text;
            var filtro = Utils.ListaSecoes[secaoPilar].Menu;
            Utils.SeletorMenuLateral(menu.ListaObjetos, filtro);
            var filtroMalha = go_Pilar.GetComponent<MeshFilter>();

            menu.SecaoVisualizadorParametros = Utils.ListaSecoes[secaoPilar];

            var secaoObjeto = Activator.CreateInstance(
                menu.SecaoVisualizadorParametros.Forma,
                menu.ParamA, 
                menu.ParamB,
                menu.ParamC,
                menu.ParamD,
                menu.ParamE) as Secao;

            menu.SecaoAtual = secaoObjeto;

            var cargaCritica = CargaCriticaEuler(
                menu.MaterialPropriedades,
                menu.SecaoAtual,
                menu.AlturaPilar,
                CoeficienteFlambagem);

            menu.AlterarCargaCriticaInfo(cargaCritica);

            menu.sld_Carga.maxValue = (float)cargaCritica;


            menu.SecaoAtual.Extrude(
                menu.AlturaPilar, 
                ref filtroMalha,
                DIVISOES);

            Flambar(
                menu.SecaoAtual,
                menu.AlturaPilar,
                menu.Carga,
                CoeficienteFlambagem,
                DIVISOES + 1,
                menu.Exagero,
                menu.MaterialPropriedades,
                ref filtroMalha);

            
        }

        void OnAlturaPilarMudado(float value)
        {
            menu.AlturaPilar = value;
            go_ForcaVetor.GetComponent<Transform>().localPosition = new Vector3(0, menu.AlturaPilar + 0.5f, 0);
            MeshFilter filtroMalha = go_Pilar.GetComponent<MeshFilter>();
            menu.SecaoAtual.Extrude(
                menu.AlturaPilar, 
                ref filtroMalha,
                DIVISOES);

            var cargaCritica = CargaCriticaEuler(
                menu.MaterialPropriedades,
                menu.SecaoAtual,
                menu.AlturaPilar,
                CoeficienteFlambagem);

            menu.AlterarCargaCriticaInfo(cargaCritica);

            menu.sld_Carga.maxValue = (float)cargaCritica;

        }

        void OnCargaMudado(float value)
        {
            menu.Carga = value;
            MeshFilter filtroMalha = go_Pilar.GetComponent<MeshFilter>();
            Flambar(
                menu.SecaoAtual,
                menu.AlturaPilar,
                menu.Carga,
                CoeficienteFlambagem,
                DIVISOES + 1,
                menu.Exagero,
                menu.MaterialPropriedades,
                ref filtroMalha);
                
            txt_CargaValor.text = $"{menu.Carga} N";
        }

        void OnExageroMudado(float value)
        {
            menu.Exagero = value;
            MeshFilter filtroMalha = go_Pilar.GetComponent<MeshFilter>();
            Flambar(
                menu.SecaoAtual,
                menu.AlturaPilar,
                menu.Carga,
                CoeficienteFlambagem,
                DIVISOES + 1,
                menu.Exagero,
                menu.MaterialPropriedades,
                ref filtroMalha);

        }

        public static double Deslocamento(
            int pos,
            double deslocamentoMaximo,
            float coeficienteFlambagem,
            float comprimento,
            int divisoes)
        {
            var alturaPasso = comprimento / divisoes;
            var y = alturaPasso * pos;
            //var x = deslocamentoMaximo * Math.Sin(
            //    (Math.PI * y)
            //    /(coeficienteFlambagem * comprimento));
            //var deslocamento = deslocamentoMaximo * Math.Sin((Math.PI * y) / comprimento);
            var deslocamento = 0.0;
            if (coeficienteFlambagem == TiposFlambagem.ENGASTADO_ENGASTADO)
            {
                deslocamento = deslocamentoMaximo * (1 - Math.Cos(2 * Math.PI * y / comprimento));
            }
            else if (coeficienteFlambagem == TiposFlambagem.ENGASTADO_LIVRE)
            {
                deslocamento = deslocamentoMaximo * (1 - Math.Cos(Math.PI * y / (2 * comprimento)));
            }
            else if (coeficienteFlambagem == TiposFlambagem.ENGASTADO_ARTICULADO)
            {
                deslocamento = deslocamentoMaximo * (1 - Math.Cos(Math.PI * y / comprimento));
            }
            return deslocamento;
        }

        public static double DeslocamentoMaximo(
            float carga,
            float comprimento,
            Secao secao,
            float coeficienteFlambagem,
            MaterialPropriedades materialPropriedades)
        {
            var imperfeicaoInicial = comprimento / 1000;
            var cargaCritica = CargaCriticaEuler(
                materialPropriedades,
                secao,
                comprimento,
                coeficienteFlambagem);

            var raizTermo = Math.Sqrt(carga / (materialPropriedades.ModuloElasticidade * secao.Area));

            var termoSecante = (coeficienteFlambagem * comprimento / (2 * secao.RaioGiracao)) * raizTermo;

            Debug.Log($"Carga Critica: {cargaCritica}");
            //var deslocamentoMaximo = imperfeicaoInicial
            //    /(1 - (carga / cargaCritica));
            var deslocamentoMaximo = imperfeicaoInicial * ((1 / Math.Cos(termoSecante)) - 1);
            return deslocamentoMaximo;
        }

        public static double CargaCriticaEuler(
             MaterialPropriedades materialPropriedades,
             Secao secao,
             float comprimento,
             float coeficienteFlambagem)
        {
            var comprimentoEficaz = comprimento * coeficienteFlambagem;
            return (
                (Math.Pow(Math.PI, 2) 
                *materialPropriedades.ModuloElasticidade 
                *secao.MenorMomentoInercia)) 
                /(Math.Pow(comprimentoEficaz, 2));
        }

        public static double EncurtamentoAxial(
            float carga,
            Secao secao,
            float comprimento,
            MaterialPropriedades materialPropriedades)
        {
            var variacao = (carga * comprimento) 
                /(secao.Area * materialPropriedades.ModuloElasticidade);
            return variacao;
        }

    }


}
