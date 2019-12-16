using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PontoEletronico.Data;
using PontoEletronico.Models;
using PontoEletronico.Models.DTO;
using PontoEletronico.Servico.Base;

namespace PontoEletronico.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly BaseServico servico;
        private readonly IMapper _mapper;
        public FuncionarioController(ApplicationDbContext ctx, IMapper mapper)
        {
            servico = new BaseServico(ctx);
            _mapper = mapper;
        }
            
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("funcionario-empresa")]
        public IActionResult AddFuncionarioEmpresa(int EmpresaId)
        {
            return View(new CpfEmpresaIdDto{EmpresaId = EmpresaId});
        }

        [HttpPost]
        [Route("funcionario-empresa")]
        public IActionResult AddFuncionarioEmpresa(CpfEmpresaIdDto dto)
        {
            var funcionario = servico.ObterTodos<Funcionario>().Where(x => x.Cpf == dto.Cpf);
            if (funcionario.Count() == 0)
            {
                return View("AddFuncionarioNaoCadastrado",new {EmpresaId = dto.EmpresaId,Cpf = dto.Cpf });
            }
            else
            {
                return View("AddFuncionarioCadastrado",funcionario);
            }
        }


        [HttpGet]
        public IActionResult AddFuncionarioNaoCadastrado(int EmpresaId,string cpf)
        {
            var empresa = servico.Obter<Empresa>(EmpresaId);
            Funcionario funcionario = new Funcionario
            {
                Empresa = empresa,
                Cpf = cpf
            };
            return View(funcionario);
        }

        [HttpPost]
        public IActionResult AddFuncionarioNaoCadastrado(Funcionario funcionario)
        {
            return View();
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
    }
}