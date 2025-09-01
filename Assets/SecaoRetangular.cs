using EstrutEdu;
using System;
using UnityEngine;

public class SecaoRetangular : Secao
{
    public float Base { get; set; }
    public float Altura { get; set; }
    public override double Area => Base * Altura;
    public override double RaioGiracao => Math.Sqrt(MenorMomentoInercia / Area);
    public override double MenorMomentoInercia => (Base > Altura) 
        ? (Base * Math.Pow(Altura, 3)) / 12.0
        : (Altura * Math.Pow(Base, 3)) / 12.0;

    public override Vector2[] Pontos {
        get
        {
            return new Vector2[4]
            {
                new Vector2(-Base/2, -Altura/2),
                new Vector2(Base/2, -Altura/2),
                new Vector2(Base/2, Altura/2),
                new Vector2(-Base/2, Altura/2),
            };
        }
    }

    public override Vector2 Direcao => (Base > Altura) 
        ? new Vector2(1, 0) 
        : new Vector2(0, 1);

    public override string Info => $"Base: {Base}; Altura: {Altura}";

    public SecaoRetangular(
        float paramA,
        float paramB,
        float paramC,
        float paramD,
        float paramE)
    {
        Base = paramA;
        Altura = paramB;
    }

}