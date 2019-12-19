using Microsoft.AspNetCore.Identity;
using PontoEletronico.Models;
using PontoEletronico.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Servico.Interface
{
    public interface IFuncionarioServico
    {
        Task<DadosContratacaoFuncionario> SalvarFuncionarioNaoCadastrado(FuncionarioNaoCadastradoDto funcionario,IdentityUser user);
        Task<StatusSalvarLoginFuncionario> SalvarUsuarioLogin(string email, string senha);
    }
}
