using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models.DTO
{
    public class FuncionarioNaoCadastradoDto
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan CargaHoraria { get; set; }
        public string Cargo { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }
        public Empresa Empresa { get; set; }

    }
}
