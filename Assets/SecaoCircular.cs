using EstrutEdu;
using UnityEngine;

public class SecaoCircular : Secao
{
    const int DIVISIONS = 16;
    public float Raio { get; set; }
    public override float MenorMomentoInercia => 1/4 * Mathf.PI * Mathf.Pow(Raio, 4);

    public override Vector2[] Pontos
    {
        get
        {
            var pontos = new Vector2[DIVISIONS];
            var angulo = Mathf.PI * 2 / DIVISIONS;
            for (var i = 0; i < DIVISIONS; i++) {
                var x = Mathf.Cos(angulo * i) * Raio;
                var y = Mathf.Sin(angulo * i) * Raio;
                pontos[i] = new Vector2(x, y);
            }
            return pontos;
        }
    }

    public SecaoCircular(float raio, float f)
    {
        Raio = raio;
    }
}