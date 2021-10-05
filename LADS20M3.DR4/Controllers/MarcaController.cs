using LADS20M3.DR4.HttpService;
using LADS20M3.DR4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LADS20M3.DR4.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarcaHttpClient _marcaHttpClient;

        public MarcaController(IMarcaHttpClient marcaHttpService)
        {
            _marcaHttpClient = marcaHttpService;
        }

        // GET: Marca
        public async Task<IActionResult> Index(string buscaTexto)
        {
            var marcas = await _marcaHttpClient.GetAllAsync(buscaTexto);

            ViewBag.BuscaTexto = buscaTexto;

            return View(marcas);
        }

        // GET: Marca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var marcaViewModel = await _marcaHttpClient.GetByIdAsync(id.Value);

                return View(marcaViewModel);
            }
            catch (HttpRequestException e) //Quando vem um status code diferente de "Successful" (200 Ok)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
            catch (NotSupportedException e) // When content type is not valid
            {
                Console.WriteLine(e);
                return NotFound(e);
            }
            catch (JsonException e) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
                return NotFound(e);
            }

        }

        // GET: Marca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MarcaViewModel marcaViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var marca = await _marcaHttpClient.CreateAsync(marcaViewModel);
                    return RedirectToAction(nameof(Details), new { id = marca.Id });
                }
                catch (JsonException)
                {
                    return View("Error");
                }
            }
            return View(marcaViewModel);
        }

        // GET: Marca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaViewModel = await _marcaHttpClient.GetByIdAsync(id.Value);
            if (marcaViewModel == null)
            {
                return NotFound();
            }
            return View(marcaViewModel);
        }

        // POST: Marca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,PaisFundacao,NomeFundador,DiaFundacao")] MarcaViewModel marcaViewModel)
        {
            if (id != marcaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _marcaHttpClient.UpdateAsync(marcaViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(marcaViewModel);
        }

        // GET: Marca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaViewModel = await _marcaHttpClient.GetByIdAsync(id.Value);
            if (marcaViewModel == null)
            {
                return NotFound();
            }

            return View(marcaViewModel);
        }

        // POST: Marca/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _marcaHttpClient.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MarcaViewModelExists(int id)
        {
            var marcaEncontrada = await _marcaHttpClient.GetByIdAsync(id);
            return marcaEncontrada != null;
        }
    }
}
