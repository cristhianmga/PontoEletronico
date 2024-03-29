﻿
using System.Collections.Generic;

namespace PontoEletronico.Models.DTO
{
    public class FuncionarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public IEnumerable<DadosContratacaoFuncionarioDto> DadosContratacaoFuncionario { get; set; }
    }
}
