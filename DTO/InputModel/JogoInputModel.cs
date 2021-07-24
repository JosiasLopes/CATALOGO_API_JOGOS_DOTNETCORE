using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_de_jogos_dotnet_core.DTO.InputModel
{
    public class JogoInputModel
    {
        //Essa classe usa o conceito de Fast Fail onde caso a requisição detecte o erro ela nem entrara no controller
        //dessa forma se poupa recursos computacionais
       
        [Required]  //essa anotatio diz que o atribto é obrigatorio
        [StringLength(100,MinimumLength =3,ErrorMessage ="O nome deve ter entre 3 e 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "A Produtora deve ter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }

        [Required]
        [Range(1,100,ErrorMessage ="O preço deve estar entre 1 e 1000 Reais")]
        public double Preco { get; set; }
    }
}
