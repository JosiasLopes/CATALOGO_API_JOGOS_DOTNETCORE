using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_de_jogos_dotnet_core.Exceptions
{
    public class JogoCadastroException:Exception
    {
       


        public JogoCadastroException() 
            : base("Jogo já cadastrado")
        {
           
        }
    }
}
