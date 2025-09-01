using EstrutEdu;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SecaoCircular : Secao
{
    const int DIVISOES = 16;
    public float Raio { get; set; }
    public override double MenorMomentoInercia => 0.25 * Math.PI * Math.Pow(Raio, 4);
    public override double Area => Math.PI * Math.Pow(Raio, 2);
    public override double RaioGiracao => Math.Sqrt(MenorMomentoInercia / Area);
    public override Vector2[] Pontos
    {
        get
        {
            var pontos = new Vector2[DIVISOES];
            var angulo = Mathf.PI * 2 / DIVISOES;
            for (var i = 0; i < DIVISOES; i++) {
                var x = Mathf.Cos(angulo * i) * Raio;
                var y = Mathf.Sin(angulo * i) * Raio;
                pontos[i] = new Vector2(x, y);
            }
            return pontos;
        }
    }

    public override Vector2 Direcao {
        get
        {
            var r1 = Random.Range(-1f, 1f);
            var r2 = Random.Range(-1f, 1f);
            var direcao = new Vector2(r1, r2);
            return direcao.normalized;
        }
    }

    public override string Info => $"Raio: {Raio}";

    public SecaoCircular(
        float paramA, 
        float paramB, 
        float paramC, 
        float paramD, 
        float paramE)
    {
        Raio = paramA;
    }
}