using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_de_jogos_dotnet_core.Repository
{
    public interface IJogoRepository
    {
        Task<List<Jogo>> Obter(int pagina, int qtd);

        Task<List<Jogo>> Obter(Guid id);

        Task<Jogo> Obter(string nome ,string produtora);

        Task Inserir(Jogo jogo);

        Task Update(Jogo jogo);

        Task Remover(Jogo jogo)
    }
}
