using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models.DTO
{
    public class FuncionarioNaoCadastradoDto
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TimeSpan CargaHoraria { get; set; }
        public string Cargo { get; set; }
        public DateTime DataInicio { get; set; }
        public Empresa Empresa { get; set; }

    }
}
