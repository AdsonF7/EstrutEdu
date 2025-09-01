using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrutEdu
{
    public class MaterialPropriedades
    {
        public string Nome { get; private set; }
        public float ModuloElasticidade { get; private set; }
        public float ResistenciaCompressao { get; private set; }
        public float CoeficientePoisson { get; private set; }
        public string NomeMaterialUnity { get; private set; } 
        public MaterialPropriedades(
            string nome, 
            float moduloElasticidade, 
            float resistenciaCompressao, 
            float coeficientePoisson, 
            string nomeMaterialUnity)
        {
            Nome = nome;
            ModuloElasticidade = moduloElasticidade;
            ResistenciaCompressao = resistenciaCompressao;
            CoeficientePoisson = coeficientePoisson;
            NomeMaterialUnity = nomeMaterialUnity;
        }
    }
}
