using catalogo_de_jogos_dotnet_core.DTO.InputModel;
using catalogo_de_jogos_dotnet_core.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_de_jogos_dotnet_core.Services
{
    public interface IjogoService
    {
        //fetito por paginação pois se houverem muitos registros
        //pode ocasionar lentidão
        Task<List<JogoViewModel>> Obter(int pagina, int qtd);   

        Task<JogoViewModel> Obter(Guid id);

        Task<JogoViewModel> Inserir(JogoInputModel jogo);

        Task Update(Guid id,JogoInputModel jogo);

        Task Update(Guid id, double preco);

        Task Remove(Guid id);
    }
}
