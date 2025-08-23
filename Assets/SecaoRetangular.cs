using EstrutEdu;
using UnityEngine;

public class SecaoRetangular : Secao
{
    public float Base { get; set; }
    public float Altura { get; set; }
    public float Area => Base * Altura;
    public override float MenorMomentoInercia
    {
        get
        {
            if (Base > Altura)
                return (Base * Mathf.Pow(Altura, 3)) / 12f;
            return (Altura * Mathf.Pow(Base, 3)) / 12f;
        }
    }

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

    public SecaoRetangular(float b, float h)
    {
        Base = b;
        Altura = h;
    }

}