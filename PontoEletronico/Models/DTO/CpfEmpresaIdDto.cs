using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models.DTO
{
    public class CpfEmpresaIdDto
    {
        public int EmpresaId { get; set; }
        [StringLength(11)]
        [Remote("ValidaCpf", "Funcionario")]
        public string Cpf { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
