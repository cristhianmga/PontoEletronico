using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PontoEletronico.Data;
using PontoEletronico.Models;
using PontoEletronico.Models.DTO;
using PontoEletronico.Servico.Base;

namespace PontoEletronico.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly BaseServico servico;
        private readonly IMapper _mapper;
        public EmpresaController(ApplicationDbContext ctx, IMapper mapper)
        {
            servico = new BaseServico(ctx);
            _mapper = mapper;
        }

        #region GetMethods
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var query = servico.ObterTodos<Empresa>();
            var dto = _mapper.Map<List<EmpresaDto>>(query);

            return View(dto);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(int Id)
        {
            var query = servico.Obter<Empresa>(Id);
            var dto = _mapper.Map<EmpresaDto>(query);
            return View(dto);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult Edit(int Id)
        {
            var query = servico.Obter<Empresa>(Id);
            var entidade = _mapper.Map<EmpresaDto>(query);
            return View(entidade);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Delete(int Id)
        {
            var query = servico.Obter<Empresa>(Id);
            var empresa = _mapper.Map<EmpresaDto>(query);
            return View(empresa);
        }
        [HttpGet]
        [Authorize]
        public IActionResult MinhaEmpresa(int id)
        {
            var empresa = servico.ObterTodos<Empresa>().Where(x => x.Id == id).Include(y => y.DadosContratacaoFuncionarios).ThenInclude(z => z.Funcionario).FirstOrDefault();
            var minhaEmpresa = _mapper.Map<MinhaEmpresaDto>(empresa);

            return View("MinhaEmpresa",minhaEmpresa);
        }
        #endregion

        [HttpPost]
        [Authorize]
        public IActionResult Create(Empresa empresa)
        {
            servico.Salvar(empresa);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(EmpresaDto dto)
        {
            var empresa = _mapper.Map<Empresa>(dto);
            servico.Atualizar<Empresa>(empresa);
            return RedirectToAction("Details", new { Id = empresa.Id });
        }
    }
}