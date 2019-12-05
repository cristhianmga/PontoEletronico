using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models
{
    public class Empresa
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        [Required]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }
        public IEnumerable<Funcionario> funcionarios { get; set; }
    }
}
