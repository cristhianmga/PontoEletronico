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
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Display(Name = "Identity")]
        [Required]
        public IdentityUser IdentityUser { get; set; }
    }
}
