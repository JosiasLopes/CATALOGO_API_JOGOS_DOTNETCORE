using catalogo_de_jogos_dotnet_core.DTO.InputModel;
using catalogo_de_jogos_dotnet_core.DTO.ViewModel;
using catalogo_de_jogos_dotnet_core.Entities;
using catalogo_de_jogos_dotnet_core.Exceptions;
using catalogo_de_jogos_dotnet_core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_de_jogos_dotnet_core.Services
{
    public class JogoService : IjogoService
    {
        private readonly IJogoRepository jogoRepo;

        public JogoService(IJogoRepository jRepo)
        {
            jogoRepo = jRepo;
        }

        public void Dispose()
        {
            jogoRepo?.Dispose();
        }

        public async Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            var entidade = await jogoRepo.Obter(jogo.Nome, jogo.Produtora);
            if (entidade.Count==0)
            {
                var jogopSave = new Jogo
                {
                    Id = Guid.NewGuid(),
                    Nome = jogo.Nome,
                    Produtora = jogo.Produtora,
                    Preco = jogo.Preco
                };
                await jogoRepo.Inserir(jogopSave);

                return new JogoViewModel
                {
                    Id = jogopSave.Id,
                    Nome = jogopSave.Nome,
                    Produtora = jogopSave.Produtora,
                    Preco = jogopSave.Preco
                };
            }
            else
            {
                throw new JogoCadastroException();
            }
            
        }

        public async Task<List<JogoViewModel>> Obter(int pagina, int quantidade)
        {
            var jogos = await jogoRepo.Obter(pagina, quantidade);

            return jogos.Select(jogo => new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            }).ToList();
        }

        public async Task<JogoViewModel> Obter(Guid id)
        {
            var jogo = await jogoRepo.Obter(id);
           
            if (jogo == null)
                return null;

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task Remove(Guid id)
        {
            var entidade = await jogoRepo.Obter(id);
            if(entidade==null)
                throw new JogoCadastroException();
            await jogoRepo.Remover(entidade.Id);
        }

        public async Task Update(Guid id, JogoInputModel jogo)
        {
            var entidade = await jogoRepo.Obter(id);
            if (entidade == null)
                throw new JogoCadastroException();
            entidade.Nome = jogo.Nome;
            entidade.Preco = jogo.Preco;
            entidade.Produtora = jogo.Produtora;

            await jogoRepo.Atualizar(entidade);
        }

        public async Task Update(Guid id, double preco)
        {
            var entidade = await jogoRepo.Obter(id);
            if (entidade == null)
                throw new JogoCadastroException();
            
            entidade.Preco = preco;
        
            await jogoRepo.Atualizar(entidade);
        }
    }
}
