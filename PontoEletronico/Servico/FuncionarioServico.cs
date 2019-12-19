using Microsoft.AspNetCore.Identity;
using PontoEletronico.Models;
using PontoEletronico.Models.DTO;
using PontoEletronico.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Servico
{
    public class FuncionarioServico : IFuncionarioServico
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public FuncionarioServico(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<DadosContratacaoFuncionario> SalvarFuncionarioNaoCadastrado(FuncionarioNaoCadastradoDto funcionario,IdentityUser user)
        {
                return await CriarDadosContratacaoFuncionario(funcionario, user);
        }

        public async Task<StatusSalvarLoginFuncionario> SalvarUsuarioLogin(string email,string senha)
        {

            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, senha);
            return new StatusSalvarLoginFuncionario 
            {
                user = user,
                result = result
            };
    }

        private async Task<DadosContratacaoFuncionario> CriarDadosContratacaoFuncionario(FuncionarioNaoCadastradoDto func,IdentityUser user)
        {
            var dados = new DadosContratacaoFuncionario
            {
                Empresa = func.Empresa,
                CargaHoraria = func.CargaHoraria,
                Cargo = func.Cargo,
                DataInicio = func.DataInicio,
                Funcionario = new Funcionario
                {
                    IdentityUser = user,
                    Cpf = func.Cpf,
                    Nome = func.Nome
                }
            };
            return dados;
        }
    }
}
