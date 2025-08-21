using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Plano detalhado:
// 1. Adicionar campos para armazenar os valores anteriores de baseSecao e alturaSecao.
// 2. No Update, verificar se baseSecao ou alturaSecao mudaram.
// 3. Se mudaram, atualizar todos os Meshes das boxMeshFilters com a nova largura/altura.
// 4. Para cada box, recriar o mesh usando CriarMeshBox com os novos valores.
// 5. Garantir que a profundidade (alturaSecao) e largura (baseSecao) sejam atualizados dinamicamente.

public class ColunaRetangularModel : MonoBehaviour
{
    public float BaseSecao => 0.1f;
    public int quantidadeBox = 50;

    private List<MeshFilter> boxMeshFilters = new List<MeshFilter>();

    // Campos para armazenar valores anteriores
    private float baseSecaoAnterior;
    private float alturaSecaoAnterior;

    public Secao Secao { get; set; }
    public float AlturaSecao{ get; set; }
    public float Comprimento { get; set; }
    void Start()
    {
        CriarBoxs();
    }

    void Update()
    {
        // Exemplo: deformar o topo da primeira box
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DeformarTopoBox(0, 1f, 1f);
        }

        // Verifica se largura ou altura mudaram
        //if (baseSecao != sliderBaseSecao.value || alturaSecao != sliderAlturaSecao.value)
        //{
        //    AtualizarBoxs();
        //    baseSecaoAnterior = baseSecao;
        //    alturaSecaoAnterior = alturaSecao;
        //}
    }

    void CriarBoxs()
    {
        float boxHeight = Comprimento / quantidadeBox;
        for (int i = 0; i < quantidadeBox; i++)
        {
            GameObject sect = new GameObject("Box_" + i);
            box.transform.parent = this.transform;
            box.transform.localPosition = new Vector3(0, i * boxHeight, 0);

            MeshFilter mf = box.AddComponent<MeshFilter>();
            MeshRenderer mr = box.AddComponent<MeshRenderer>();
            Material mat = Resources.Load<Material>("Crate - URP");
            mr.material = mat;

            //mf.mesh = CriarMeshBox(baseSecao, boxHeight, alturaSecao);
            //boxMeshFilters.Add(mf);
        }
    }

    // Atualiza todos os meshes das boxs com nova largura/altura
    void AtualizarBoxs()
    {
        float boxHeight = Comprimento / quantidadeBox;
        for (int i = 0; i < boxMeshFilters.Count; i++)
        {
            //Mesh mesh = Box.CriarMeshBox(sliderBaseSecao.value, boxHeight, sliderAlturaSecao.value);
            //boxMeshFilters[i].mesh = mesh;
        }
    }


    public void DeformarTopoBox(int index, float deltaX, float deltaZ)
    {
        if (index < 0 || index >= boxMeshFilters.Count) return;
        Mesh mesh = boxMeshFilters[index].mesh;
        Vector3[] vertices = mesh.vertices;
        // Vértices do topo: 4,5,6,7
        for (int i = 4; i <= 7; i++)
        {
            vertices[i].x += deltaX;
            vertices[i].z += deltaZ;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        boxMeshFilters[index].mesh = mesh;
    }

    // Deforma a base da box (índice) alterando x e y dos vértices inferiores
    public void DeformarBaseBox(int index, float deltaX, float deltaZ)
    {
        if (index < 0 || index >= boxMeshFilters.Count) return;
        Mesh mesh = boxMeshFilters[index].mesh;
        Vector3[] vertices = mesh.vertices;
        // Vértices da base: 0,1,2,3
        for (int i = 0; i <= 3; i++)
        {
            vertices[i].x += deltaX;
            vertices[i].z += deltaZ;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        boxMeshFilters[index].mesh = mesh;
    }
}