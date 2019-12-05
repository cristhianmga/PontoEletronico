using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models.DTO
{
    public class MinhaEmpresaDto
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public List<FuncionarioDto> Funcionarios { get; set; }
    }
}
