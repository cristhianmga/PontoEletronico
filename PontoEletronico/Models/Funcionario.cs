using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models
{
    public class Funcionario
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        public Empresa Empresa { get; set; }
        [Required]
        public IdentityUser IdentityUser { get; set; }
    }
}
