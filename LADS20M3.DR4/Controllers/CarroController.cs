using LADS20M3.DR4.HttpService;
using LADS20M3.DR4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LADS20M3.DR4.Controllers
{
    [Authorize]
    public class CarroController : Controller
    {
        private readonly IMarcaHttpClient _marcahttpClient;
        private readonly ICarroHttpClient _carroHttpClient;

        public CarroController(
            IMarcaHttpClient marcahttpClient,
            ICarroHttpClient carroHttpClient)
        {
            _marcahttpClient = marcahttpClient;
            _carroHttpClient = carroHttpClient;
        }

        // GET: Carro
        public async Task<IActionResult> Index(string buscaTexto)
        {
            var carros = await _carroHttpClient.GetAllAsync(buscaTexto);

            ViewBag.BuscaTexto = buscaTexto;

            return View(carros.ToList());
        }

        // GET: Carro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carroModel = await _carroHttpClient.GetByIdAsync(id.Value);
            if (carroModel == null)
            {
                return NotFound();
            }

            return View(carroModel);
        }

        // GET: Carro/Create
        public async Task<IActionResult> Create(string? buscaTexto)
        {
            var marcas = await _marcahttpClient.GetAllAsync(buscaTexto);
            ViewData["MarcaId"] = new SelectList(
                marcas,
                nameof(MarcaViewModel.Id),
                nameof(MarcaViewModel.Nome));
            return View();
        }

        // POST: Carro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MarcaCarroCreateViewModel marcaCarroCreateViewModel, string? buscaTexto)
        {
            if (ModelState.IsValid)
            {
                var marcaCarroAggViewModel = new MarcaCarroAggRequest(marcaCarroCreateViewModel);

                await _carroHttpClient.CreateAsync(marcaCarroAggViewModel);
                return RedirectToAction(nameof(Index));
            }
            var marcas = await _marcahttpClient.GetAllAsync(buscaTexto);
            ViewData["MarcaId"] = new SelectList(marcas, nameof(MarcaViewModel.Id), nameof(MarcaViewModel.Nome), marcaCarroCreateViewModel.MarcaId);
            return View(marcaCarroCreateViewModel);
        }

        // GET: Carro/Edit/5
        public async Task<IActionResult> Edit(int? id, string? buscaTexto)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carroModel = await _carroHttpClient.GetByIdAsync(id.Value);
            if (carroModel == null)
            {
                return NotFound();
            }
            var marcas = await _marcahttpClient.GetAllAsync(buscaTexto);
            ViewData["MarcaId"] = new SelectList(marcas, nameof(MarcaViewModel.Id), nameof(MarcaViewModel.Nome), carroModel.MarcaId);
            return View(carroModel);
        }

        // POST: Carro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Ano,Portas,Cambio,Direcao,Lancamento,MarcaId")] CarroViewModel carroModel, string? buscaTexto)
        {
            if (id != carroModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _carroHttpClient.UpdateAsync(carroModel);

                return RedirectToAction(nameof(Index));
            }
            var marcas = await _marcahttpClient.GetAllAsync(buscaTexto);
            ViewData["MarcaId"] = new SelectList(marcas, nameof(MarcaViewModel.Id), nameof(MarcaViewModel.Nome), carroModel.MarcaId);
            return View(carroModel);
        }

        // GET: Carro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carroModel = await _carroHttpClient.GetByIdAsync(id.Value);
            if (carroModel == null)
            {
                return NotFound();
            }

            return View(carroModel);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _carroHttpClient.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CarroModelExists(int id)
        {
            return await _carroHttpClient.GetByIdAsync(id) != null;
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> CheckModelo(string modelo, int id)
        {
            if (!await _carroHttpClient.CheckModelo(modelo, id))
            {
                return Json($"Modelo {modelo} já está sendo usado.");
            }

            return Json(true);
        }
    }
}
