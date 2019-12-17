using System.Linq;
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
            var empresa = servico.Obter<Empresa>(dto.EmpresaId);
            if (funcionario.Count() == 0)
            {
                return View("AddFuncionarioNaoCadastrado",new FuncionarioNaoCadastradoDto{ Empresa = empresa,Cpf = dto.Cpf });
            }
            else
            {
                return View("AddFuncionarioCadastrado",funcionario);
            }
        }


        [HttpGet]
        public IActionResult AddFuncionarioNaoCadastrado(FuncionarioNaoCadastradoDto dto)
        {

            return View(dto);
        }

        //[HttpPost]
        //public IActionResult AddFuncionarioNaoCadastrado(FuncionarioNaoCadastradoDto funcionario)
        //{
        //    return View();
        //}

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