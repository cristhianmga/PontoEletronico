using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PontoEletronico.Data;
using PontoEletronico.Models;
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
            ViewBag.CpfEncontrado = false;
            return View();
        }
        [HttpGet]
        public IActionResult AddFuncionarioNaoCadastrado(string cpf)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFuncionarioEmpresa(string cpf)
        {
            var funcionario = servico.ObterTodos<Funcionario>().Where(x => x.Cpf == cpf);
            if (funcionario.Count() > 1)
            {
                return View("AddFuncionarioNaoCadastrado");
            }
            else
            {
                return View("AddFuncionarioCadastrado");
            }
        }

        [HttpPost]
        public IActionResult AddFuncionarioNaoCadastrado()
        {
            return View();
        }
    }
}