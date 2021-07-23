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
        public async Task<ActionResult<List<Object>>> Obter()
        {

        }
    }
}
