using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SapataModel
{
    public float Base { get; set; }
    public float Altura { get; set; }
    public void Malha(ref MeshFilter filtroMalha)
    {
        var malha = new Mesh();
        malha.vertices = new Vector3[12];
        var vertices = new Vector3[12];
        vertices[0] = new Vector3(-Base * 5 / 2f, 0, -Altura * 5 / 2f);
        vertices[1] = new Vector3(Base * 5 / 2f, 0, -Altura * 5 / 2f);
        vertices[2] = new Vector3(Base * 5 / 2f, 0, Altura * 5 / 2f);
        vertices[3] = new Vector3(-Base * 5 / 2f, 0, Altura * 5 / 2f);
        vertices[4] = new Vector3(-Base * 5 / 2f, 0.25f, -Altura * 5 / 2f);
        vertices[5] = new Vector3(Base * 5 / 2f, 0.25f, -Altura * 5 / 2f);
        vertices[6] = new Vector3(Base * 5 / 2f, 0.25f, Altura * 5 / 2f);
        vertices[7] = new Vector3(-Base * 5 / 2f, 0.25f, Altura * 5 / 2f);
        vertices[8] = new Vector3(-Base / 2f, 0.5f, -Altura / 2f);
        vertices[9] = new Vector3(Base / 2f, 0.5f, -Altura / 2f);
        vertices[10] = new Vector3(Base / 2f, 0.5f, Altura / 2f);
        vertices[11] = new Vector3(-Base / 2f, 0.5f, Altura / 2f);
        var triangles = new int[54] {
            0, 5, 1, 0, 4, 5,
            1, 6, 2, 1, 5, 6,
            2, 7, 3, 2, 6, 7,
            3, 4, 0, 3, 7, 4,
            4, 9, 5, 4, 8, 9,
            5, 10, 6, 5, 9, 10,
            6, 11, 7, 6, 10, 11,
            7, 8, 4, 7, 11, 8,
            8, 10, 9, 8, 11, 10};

        filtroMalha.mesh.Clear();
        filtroMalha.mesh.MarkDynamic();
        filtroMalha.mesh.vertices = vertices;
        filtroMalha.mesh.triangles = triangles;
        filtroMalha.mesh.RecalculateNormals();
    }
}