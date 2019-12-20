using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models.DTO
{
    public class FuncionarioNaoCadastradoDto
    {
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan CargaHoraria { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }
        public Empresa Empresa { get; set; }

    }
}
