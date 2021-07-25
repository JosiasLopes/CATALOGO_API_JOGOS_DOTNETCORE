using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_de_jogos_dotnet_core.Entities
{
    public class Jogo
    {
        //possui os mesmos atributos da viewModel com a diferença que a viewModel trabalha com a parte de 
        //visualização podendo trazer informações sobre varias entidades como se fosse um relatorio
        //onde podemos fazer os mapeamentos de acordo com nossa necessidade
        //por isso é importante deixa-las separdas
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Produtora { get; set; }

        public double Preco { get; set; }
    }
}
