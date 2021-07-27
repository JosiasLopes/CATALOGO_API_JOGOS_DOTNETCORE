using catalogo_de_jogos_dotnet_core.DTO.InputModel;
using catalogo_de_jogos_dotnet_core.DTO.ViewModel;
using catalogo_de_jogos_dotnet_core.Exceptions;
using catalogo_de_jogos_dotnet_core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_de_jogos_dotnet_core.Controllers.V1
{
    //inicio...
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Jogos : ControllerBase
    {
        //o readonly permite que não seja nossa responsabilidade de criar um instancia e sim o aspnet
        private readonly IjogoService jogoServ;

        public Jogos(IjogoService jogoservice)
        {
            jogoServ = jogoservice;
        }

        //Action result diz quais são os retornos, status e etc
        //como o service retorna uma task o resulta vai esperar o service
        //o IEnumerable funcona como uma lista
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> listarJogos([FromQuery,Range(1,int.MaxValue)] int pagina=1,
           [FromQuery, Range(1, 50)] int qtd = 5 )
        {
            //como usamos o await o result se torna uma lista com os resultados ja que ela espera prencher
            var result = await jogoServ.Obter(pagina,qtd);
            if (result.Count() == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("(idjogo:guid)")]
        public async Task<ActionResult<JogoViewModel>> getJogoById([FromRoute] Guid idjogo)
        {
            var result = await jogoServ.Obter(idjogo);

            if (result.Equals(null))
                return NoContent();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> postJogo([FromBody] JogoInputModel jogo)
        {
            try
            {
                var result = await jogoServ.Inserir(jogo);
                return Ok(result); //retorn o status da requisição
            }
            catch (JogoCadastroException e)
            {
                return UnprocessableEntity("Já existe um registro com essas carateristicas");
            }
            
        }

        [HttpPut("(idjogo:guid)")]  //o put atualiza todo o recurso
        public async Task<ActionResult<JogoViewModel>> updateJogo([FromRoute] Guid idjogo, [FromBody] JogoInputModel jogo)
        {
            try
            {
                var result = jogoServ.Update(idjogo, jogo);

                return Ok(result);    //retorn o 
            }
            catch (JogoCadastroException e)
            {
                return NotFound("Não foi possivel processar, ou esse registro ainda não existe");
            }
        }

        [HttpPut("(idjogo:guid)/preco/(preco:double)")] //atualiza um campo especifico
        public async Task<ActionResult<JogoViewModel>> patchJogo([FromRoute] Guid idjogo, [FromRoute] double preco)
        {
            try {
                var result = jogoServ.Update(idjogo, preco);
                return Ok(result);
            }
            catch (JogoCadastroException e)
            {
                return NotFound ("Não foi possivel processar, ou esse registro ainda não existe");
            }

        }

        [HttpDelete("(idjogo:guid)")]  //o put atualiza todo o recurso
        public async Task<ActionResult<JogoViewModel>> deleteJogo([FromRoute] Guid idjogo)
        {
            try {
                var result = jogoServ.Remove(idjogo);
                return Ok(result);
            }
            catch (JogoCadastroException e)
            {
                return NotFound("Não foi possivel processar, ou esse registro ainda não existe");
            }


        }
    }
}
