using catalogo_de_jogos_dotnet_core.DTO.InputModel;
using catalogo_de_jogos_dotnet_core.DTO.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_de_jogos_dotnet_core.Controllers.V1
{
    //inicio...
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Jogos : ControllerBase
    {
        //Action result diz quais são os retornos, status e etc
        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> listarJogos()
        {

            return Ok();
        }

        [HttpGet("(idjogo:guid)")]
        public async Task<ActionResult<JogoViewModel>> getJogoById(Guid idjogo)
        {

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> postJogo(JogoInputModel jogo)
        {

            return Ok();
        }

        [HttpPut("(idjogo:guid)")]  //o put atualiza todo o recurso
        public async Task<ActionResult<JogoViewModel>> updateJogo(Guid idjogo, JogoInputModel jogo)
        {

            return Ok();
        }

        [HttpPut("(idjogo:guid)/preco/(preco:double)")] //atualiza um campo especifico
        public async Task<ActionResult<JogoViewModel>> patchJogo(Guid idjogo, double jogo)
        {
            
            return Ok();
        }

        [HttpDelete("(idjogo:guid)")]  //o put atualiza todo o recurso
        public async Task<ActionResult<JogoViewModel>> deleteJogo(Guid idjogo)
        {

            return Ok();
        }
    }
}
