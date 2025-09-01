using UnityEngine;
using System.Collections.Generic;

public class RoleteModel : MonoBehaviour
{
    public float raio = 1f;
    [Range(3, 100)]
    public int passosHorizontais = 24; // Longitude
    [Range(3, 100)]
    public int passosVerticais = 12;   // Latitude

    private Mesh mesh;
    private List<Vector3> vertices;
    private List<int> triangulos;
    private List<Vector3> normais;
    private List<Vector2> uvs;

    void Start()
    {
        GenerateSphere();
    }

    public void GenerateSphere()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        vertices = new List<Vector3>();
        triangulos = new List<int>();
        normais = new List<Vector3>();
        uvs = new List<Vector2>();

        CreateVertices();
        CreateTriangles();
        UpdateMesh();
    }

    void CreateVertices()
    {
        // Pólos
        Vector3 topPole = new Vector3(0, raio, 0);
        Vector3 bottomPole = new Vector3(0, -raio, 0);
        vertices.Add(topPole);
        uvs.Add(new Vector2(0.5f, 1));
        normais.Add(topPole.normalized);

        // Círculos de latitude
        for (int i = 1; i < passosVerticais; i++)
        {
            float phi = (float)i / passosVerticais * Mathf.PI; // Ângulo vertical
            float y = raio * Mathf.Cos(phi);
            float currentRadius = raio * Mathf.Sin(phi);

            // Pontos de longitude em cada círculo
            for (int j = 0; j < passosHorizontais; j++)
            {
                float theta = (float)j / passosHorizontais * 2 * Mathf.PI; // Ângulo horizontal
                float x = currentRadius * Mathf.Sin(theta);
                float z = currentRadius * Mathf.Cos(theta);

                Vector3 vertice = new Vector3(x, y, z);
                vertices.Add(vertice);
                normais.Add(vertice.normalized);
                uvs.Add(new Vector2((float)j / passosHorizontais, 1f - (float)i / passosVerticais));
            }
        }

        // Adiciona o pólo inferior
        vertices.Add(bottomPole);
        uvs.Add(new Vector2(0.5f, 0));
        normais.Add(bottomPole.normalized);
    }

    void CreateTriangles()
    {
        // Triângulos do pólo superior
        for (int i = 0; i < passosHorizontais; i++)
        {
            int p0 = 0; // Pólo superior
            int p1 = i + 1;
            int p2 = (i + 1) % passosHorizontais + 1;

            triangulos.Add(p0);
            triangulos.Add(p2);
            triangulos.Add(p1);
        }

        // Triângulos do corpo da esfera
        int linhaDeCimaInicio = 1;
        int linhaDeBaixoInicio = 1 + passosHorizontais;

        for (int i = 0; i < passosVerticais - 2; i++)
        {
            for (int j = 0; j < passosHorizontais; j++)
            {
                int p1 = linhaDeCimaInicio + j;
                int p2 = linhaDeCimaInicio + (j + 1) % passosHorizontais;
                int p3 = linhaDeBaixoInicio + j;
                int p4 = linhaDeBaixoInicio + (j + 1) % passosHorizontais;

                // Primeiro triângulo do quadrilátero
                triangulos.Add(p1);
                triangulos.Add(p4);
                triangulos.Add(p2);

                // Segundo triângulo do quadrilátero
                triangulos.Add(p1);
                triangulos.Add(p3);
                triangulos.Add(p4);
            }
            linhaDeCimaInicio = linhaDeBaixoInicio;
            linhaDeBaixoInicio += passosHorizontais;
        }

        // Triângulos do pólo inferior
        int ultimoVertice = vertices.Count - 1; // Pólo inferior
        int primeiraLinhaDeBaixo = ultimoVertice - passosHorizontais;

        for (int i = 0; i < passosHorizontais; i++)
        {
            int p0 = ultimoVertice;
            int p1 = primeiraLinhaDeBaixo + (i + 1) % passosHorizontais;
            int p2 = primeiraLinhaDeBaixo + i;

            triangulos.Add(p0);
            triangulos.Add(p2);
            triangulos.Add(p1);
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangulos.ToArray();
        mesh.normals = normais.ToArray();
        mesh.uv = uvs.ToArray();
        mesh.RecalculateBounds(); // Calcula os limites para a renderização
    }
}