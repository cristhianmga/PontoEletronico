using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models.DTO
{
    public class StatusSalvarLoginFuncionario
    {
        public IdentityUser user { get; set; }
        public IdentityResult result { get; set; }
    }
}
