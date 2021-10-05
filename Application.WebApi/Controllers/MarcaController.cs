using Domain.Model.Interfaces.Services;
using Domain.Model.Interfaces.UoW;
using Domain.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;
        private readonly IUnitOfWork _unitOfWork;

        public MarcaController(IMarcaService marcaService, IUnitOfWork unitOfWork)
        {
            _marcaService = marcaService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{buscaTexto?}")]
        public IActionResult OnGet(string buscaTexto)
        {
            var todasMarcas = _marcaService.GetAll(buscaTexto);
            
            return Ok(todasMarcas);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaModel = _marcaService.GetById(id.Value);
            if (marcaModel == null)
            {
                return NotFound();
            }

            return Ok(marcaModel);
        }

        [HttpPost]
        public IActionResult OnPost([FromBody] MarcaModel marcaModel)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BeginTransaction();
                var marcaCriada = _marcaService.Create(marcaModel);
                _unitOfWork.Commit();

                return Ok(marcaCriada);
            }
            return BadRequest("Existe algum valor inválido passado.");
        }

        [HttpPut("{id}")]
        public IActionResult OnPut(int id, MarcaModel marcaModel)
        {
            if (id != marcaModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Existe algum valor inválido passado.");
            }

            try
            {
                _unitOfWork.BeginTransaction();
                var updatedModel = _marcaService.Update(marcaModel);
                _unitOfWork.Commit();

                return Ok(updatedModel);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult OnDelete(int id)
        {
            _unitOfWork.BeginTransaction();
            _marcaService.Delete(id);
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
