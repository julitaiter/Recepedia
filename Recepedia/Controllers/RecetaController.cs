using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recepdia.Context;
using Recepedia.Models;

namespace Recepedia.Controllers
{
    public class RecetaController : Controller
    {
        private readonly RecepediaContext _context;

        public RecetaController(RecepediaContext context)
        {
            _context = context;
        }

        // GET: Receta
        public async Task<IActionResult> Index()
        {
            return _context.Receta != null ? 
                          View(await _context.Receta.ToListAsync()) :
                          Problem("Entity set 'RecepediaContext.Receta'  is null.");
        }

        // GET: Receta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Receta == null)
            {
                return NotFound();
            }

            var receta = await _context.Receta
                .FirstOrDefaultAsync(m => m.IDReceta == id);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // GET: Receta/Create
        public IActionResult Create()
        {
            var categorias = _context.Categoria.ToList();
            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Nom_Categoria");
            var dificultades = _context.Dificultad.ToList();
            ViewBag.Dificultades = new SelectList(dificultades, "IDDificultad", "NombreDificultad");
            return View();
        }

        // POST: Receta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDReceta,NombreReceta,CategoriaIdCategoria,Preparacion,TiempoPreparacion,CantidadPlatos,DificultadIdDificultad,NombreFoto,Cant_Likes,Autor")] Receta receta)
        {
            receta.Cant_Likes = 0;
            //receta.Autor = int.Parse(HttpContext.Session.GetString("Usuario")!);
            receta.Autor = 3;
            receta.NombreFoto = "";
            if (ModelState.IsValid)
            {
                _context.Add(receta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receta);
        }

        // GET: Receta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Receta == null)
            {
                return NotFound();
            }

            var receta = await _context.Receta.FindAsync(id);
            if (receta == null)
            {
                return NotFound();
            }
            var categorias = _context.Categoria.ToList();
            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Nom_Categoria");
            var dificultades = _context.Dificultad.ToList();
            ViewBag.Dificultades = new SelectList(dificultades, "IDDificultad", "NombreDificultad");
            return View(receta);
        }

        // POST: Receta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDReceta,NombreReceta,Preparacion,TiempoPreparacion,CantidadPlatos,NombreFoto,Cant_Likes,Autor")] Receta receta)
        {
            if (id != receta.IDReceta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecetaExists(receta.IDReceta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(receta);
        }

        // GET: Receta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Receta == null)
            {
                return NotFound();
            }

            var receta = await _context.Receta
                .FirstOrDefaultAsync(m => m.IDReceta == id);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // POST: Receta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Receta == null)
            {
                return Problem("Entity set 'RecepediaContext.Receta'  is null.");
            }
            var receta = await _context.Receta.FindAsync(id);
            if (receta != null)
            {
                _context.Receta.Remove(receta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecetaExists(int id)
        {
          return (_context.Receta?.Any(e => e.IDReceta == id)).GetValueOrDefault();
        }
    }
}
