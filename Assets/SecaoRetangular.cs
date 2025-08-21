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

    public override Point2D[] Pontos {
        get
        {
            return new Point2D[4]
            {
                new Point2D(-Base/2, -Altura/2),
                new Point2D(Base/2, -Altura/2),
                new Point2D(Base/2, Altura/2),
                new Point2D(-Base/2, Altura/2),
            };
        }
    }

    public SecaoRetangular(float b, float h)
    {
        Base = b;
        Altura = h;
    }

}