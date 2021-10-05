using Domain.Model.Interfaces.Services;
using Domain.Model.Interfaces.UoW;
using Domain.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroService _carroService;
        private readonly IUnitOfWork _unitOfWork;

        public CarroController(ICarroService carroService, IUnitOfWork unitOfWork)
        {
            _carroService = carroService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{buscaTexto?}")]
        public IActionResult OnGet(string buscaTexto)
        {
            var todosCarros = _carroService.GetAll(buscaTexto);
    
            return Ok(todosCarros);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carroModel = _carroService.GetById(id.Value);
            if (carroModel == null)
            {
                return NotFound();
            }

            return Ok(carroModel);
        }

        [HttpPost]
        public IActionResult OnPost([FromBody] MarcaCarroAggViewModel carroAggregateModel)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BeginTransaction();
                var carroCriado = _carroService.Create(carroAggregateModel);
                _unitOfWork.Commit();

                return Ok(carroCriado);
            }
            return BadRequest("Existe algum valor inválido passado.");
        }

        [HttpPut("{id}")]
        public IActionResult OnPut(int id, CarroModel carroModel)
        {
            if (id != carroModel.Id)
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
                var updatedModel = _carroService.Update(carroModel);
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
            _carroService.Delete(id);
            _unitOfWork.Commit();

            return Ok();
        }

        [HttpGet("CheckModelo/{modelo}/{id}")]
        public IActionResult OnGet(string modelo, int id)
        {
            if (string.IsNullOrWhiteSpace(modelo))
                return BadRequest("Modelo inválido.");

            return Ok(_carroService.CheckModelo(modelo, id));
        }
    }
}
