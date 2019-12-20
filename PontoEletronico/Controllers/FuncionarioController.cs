using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PontoEletronico.Data;
using PontoEletronico.Models;
using PontoEletronico.Models.DTO;
using PontoEletronico.Servico.Base;
using PontoEletronico.Servico.Interface;
using PontoEletronico.Servico.Util;

namespace PontoEletronico.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly BaseServico servico;
        private readonly IMapper _mapper;
        private readonly IFuncionarioServico _funcionarioServico;
        public FuncionarioController(ApplicationDbContext ctx, IMapper mapper, IFuncionarioServico funcionarioServico)
        {
            servico = new BaseServico(ctx);
            _mapper = mapper;
            _funcionarioServico = funcionarioServico;
        }
            
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddFuncionarioEmpresa(int EmpresaId)
        {
            return View(new CpfEmpresaIdDto{EmpresaId = EmpresaId});
        }

        [HttpPost]
        public async Task<IActionResult> AddFuncionarioEmpresa(CpfEmpresaIdDto dto)
        {
            var funcionario = servico.ObterTodos<Funcionario>().Where(x => x.Cpf == dto.Cpf);
            var empresa = servico.Obter<Empresa>(dto.EmpresaId);
            if (funcionario.Count() == 0)
            {
                var ident = await _funcionarioServico.GetIdentityUserByEmail(dto.Email);
                if(ident == null)
                {
                    return View("AddFuncionarioNaoCadastrado", new FuncionarioNaoCadastradoDto { Empresa = empresa, Cpf = dto.Cpf });
                }
                else
                {
                    return View("AddFuncionarioNaoCadastrado", new FuncionarioNaoCadastradoDto { Empresa = empresa, Cpf = dto.Cpf,Email = ident.Email });
                }
            }
            else
            {
                return View("AddFuncionarioCadastrado",funcionario);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFuncionarioNaoCadastrado(FuncionarioNaoCadastradoDto funcionario)
        {
            StatusSalvarLoginFuncionario retorno = new StatusSalvarLoginFuncionario();
            if(funcionario.Senha == null)
            {
                retorno.user = await _funcionarioServico.GetIdentityUserByEmail(funcionario.Email);
            }
            else
            {
                retorno = await _funcionarioServico.SalvarUsuarioLogin(funcionario.Email, funcionario.Senha);
                if (retorno.result.Errors.Any())
                {
                    foreach (var error in retorno.result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(funcionario);
                }
            }

            var dados = await _funcionarioServico.SalvarFuncionarioNaoCadastrado(funcionario, retorno.user);
            servico.Salvar<DadosContratacaoFuncionario>(dados);

            return RedirectToAction("MinhaEmpresa","Empresa",new { EmpresaId = dados.Empresa.Id });
        }

        [HttpGet]
        public IActionResult AddFuncionarioCadastrado(Funcionario funcionario)
        {
            return View(funcionario);
        }

        //[HttpPost]
        //public IActionResult AddFuncionarioCadastrado(Funcionario funcionario)
        //{
        //    return View();
        //}
        public IActionResult ValidaCpf(string Cpf)
        {
            var resultado = Validacao.IsCpf(Cpf);
            if (resultado)
            {
                return Json(true);
            }
            else
            {
                return Json("CPF Inválido");
            }
        }
    }
}