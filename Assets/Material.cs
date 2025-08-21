using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrutEdu
{
    public class Material
    {
        public string Nome;
        public float ModuloElasticidade;
        public float ResistenciaCompressao;
        public float CoeficientePoisson;

        public Material(string nome, float moduloElasticidade, float resistenciaCompressao, float coeficientePoisson)
        {
            Nome = nome;
            ModuloElasticidade = moduloElasticidade;
            ResistenciaCompressao = resistenciaCompressao;
            CoeficientePoisson = coeficientePoisson;
        }
    }
}
