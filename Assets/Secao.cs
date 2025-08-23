using EstrutEdu;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Secao
{
	public abstract float MenorMomentoInercia { get; }
	public abstract Vector2[] Pontos { get; }

    public Mesh Extrude(
        float alturaTotal, 
        ref MeshFilter filtroMalha, 
        int divisoes = 1)
	{
		var alturaPasso = alturaTotal/divisoes;
		var mesh = new Mesh();
		List<Vector3> vertices = new List<Vector3>();
        List<int> triangulos = new List<int>();

		for (var i = 0; i <= divisoes; i++)
		{
            foreach(var p in Pontos)
            {
                var x = p.x;
                var y = alturaPasso * i;
                var z = p.y;
                vertices.Add(new Vector3(x, y, z));
            }
        }

        int quantidadePontos = Pontos.Count();

        for (var i = 0; i < divisoes; i++)
		{
            int pIncialCamada = i * quantidadePontos;
            for (int j = 0; j < quantidadePontos; j++)
            {
                int pProximo = (j + 1) % quantidadePontos;
                int a = pIncialCamada + j;
                int b = pIncialCamada + pProximo;
                int c = pIncialCamada + j + quantidadePontos;
                int d = pIncialCamada + pProximo + quantidadePontos;

                triangulos.Add(a);
                triangulos.Add(c);
                triangulos.Add(b);

                triangulos.Add(b);
                triangulos.Add(c);
                triangulos.Add(d);
            }
            filtroMalha.mesh.Clear();
            filtroMalha.mesh.vertices = vertices.ToArray();
            filtroMalha.mesh.triangles = triangulos.ToArray();
            filtroMalha.mesh.RecalculateNormals();
        }
        return mesh;
    }
}