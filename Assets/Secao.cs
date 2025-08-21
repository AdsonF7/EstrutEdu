using EstrutEdu;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Secao
{
	public abstract float MenorMomentoInercia { get; }
	public abstract Point2D[] Pontos { get; }

    public Mesh Extrude(double altura, Point2D[] pontos)
	{
		var mesh = new Mesh();
		
		for (var i = 0; i <= pontos.Length; i++)
		{
			var p1 = pontos[i % pontos.Length];
			var p2 = pontos[(i + 1) % pontos.Length];
			
			mesh.vertices = new Vector3[]
			{
				new Vector3((float)p1.X, 0, (float)p1.Y),
				new Vector3((float)p2.X, 0, (float)p2.Y),
				new Vector3((float)p1.X, (float)altura, (float)p1.Y),
				new Vector3((float)p2.X, (float)altura, (float)p2.Y)
			};

			mesh.triangles = new int[]
			{
				i * 4, i * 4 + 1, i * 4 + 2,
				i * 4 + 1, i * 4 + 3, i * 4 + 2
			};
        }
        return mesh;
    }
}