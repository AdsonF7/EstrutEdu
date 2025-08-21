using EstrutEdu;

public class SecaoCircular : Secao
{
    public double Raio {  get; set; }
    public override float MenorMomentoInercia => throw new System.NotImplementedException();

    public override Point2D[] Pontos => throw new System.NotImplementedException();

    SecaoCircular(double raio)
    {
        Raio = raio;
    }
}