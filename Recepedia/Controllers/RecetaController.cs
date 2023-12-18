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
            Usuario autor = await _context.Usuario.FindAsync(receta.Autor);
            ViewBag.NombreAutor = autor.Nombre_Usuario;

            List<IngPorRec> ingXRec = _context.IngPorRec.Where(i => i.IdReceta == id).ToList();
            List<Ingrediente> ingredientes = new List<Ingrediente>();

            foreach (IngPorRec ing in ingXRec)
            {
                Ingrediente i = _context.Ingrediente.Find(ing.IdIngrediente);
                ingredientes.Add(i);
            }

            ViewBag.Ingredientes = ingredientes;
            ViewBag.Cantidad = ingXRec;

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
        public async Task<IActionResult> Create([Bind("IDReceta,NombreReceta,CategoriaIdCategoria,Preparacion,TiempoPreparacion,CantidadPlatos,DificultadIdDificultad,Cant_Likes,Autor,Ingredientes")] Receta receta)
        {
            receta.Cant_Likes = 0;
            //receta.Autor = int.Parse(HttpContext.Session.GetString("Usuario")!);
            receta.Autor = 3;
            if (ModelState.IsValid)
            {
                _context.Add(receta);
                await _context.SaveChangesAsync();
                return RedirectToAction("AgregarIngredientesAReceta", new { IDReceta = receta.IDReceta });
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
        
        public async Task<IActionResult> BuscarIngredientes()
        {
            return View();
        }

        public async Task<IActionResult> BusqXIng(string Buscar, string Eliminar, List<String> ListaActual, List<Receta> RecetasActuales)
        {
            ViewBag.IngredientesBuscados = "";
            ViewBag.MisRecetasEncontradas = "";
            ViewBag.CantRecetasEncontradas = 0;

            List<string> Lista;
            if (ListaActual == null)
            {
                Lista = new List<string>();
            }
            else
            {
                Lista = (List<string>)ListaActual;
            }

            if (Buscar != null)
            {
                if (!Lista.Contains(Buscar))
                {
                    Lista.Add(Buscar);
                }
            }

            if (Eliminar != null)
            {
                Lista.Remove(Eliminar);
            }

            ListaActual = Lista;
            ViewBag.IngredientesBuscados = Lista;

            List<Receta> LasRecetasEncontradas = new List<Receta>();
            RecetasActuales = new List<Receta>();

            ViewBag.CantRecetasEncontradas = LasRecetasEncontradas.Count();

            List<List<Receta>> TodasLasRecetas = new List<List<Receta>>();
            List<Receta> RecetasAMostrar = new List<Receta>();
            bool Repetido = false;
            int i = 0;
            int Coincidencias = 0;

            foreach (string ElIngrediente in Lista)
            {
                var ingrediente = await _context.Ingrediente.FirstOrDefaultAsync(i => i.NombreIngrediente.ToLower() == Buscar.ToLower());
                List<IngPorRec> lista = _context.IngPorRec.Where(i => i.IdReceta == ingrediente.IDIngrediente).ToList();
                List<Receta> recetaXIng = new List<Receta>();

                foreach (var ing in lista)
                {
                    var receta = await _context.Receta.FirstOrDefaultAsync(r => r.IDReceta == ing.IdReceta);
                    recetaXIng.Add(receta);
                }
                TodasLasRecetas.Add(recetaXIng);
              
            }

            foreach (List<Receta> ListaRecetas in TodasLasRecetas)
            {
                foreach (Receta UnaReceta in ListaRecetas)
                {
                    Coincidencias = 0;
                    Repetido = false;

                    foreach (Ingrediente UnIngrediente in UnaReceta.Ingredientes(_context))
                    {
                        i = 0;
                        if (Coincidencias != Lista.Count() && Lista.Count() != 0)
                        {
                            do
                            {
                                if (UnIngrediente.NombreIngrediente.ToLower() == Lista[i].ToLower())
                                {
                                    Coincidencias++;
                                }
                                i++;

                            } while (i - 1 != Lista.Count() - 1);
                        }

                       
                    }

                    if (Coincidencias == Lista.Count() && Lista.Count() != 0)
                    {
                        foreach (Receta LaReceta in RecetasAMostrar)
                        {
                            if (LaReceta.NombreReceta.ToLower() == UnaReceta.NombreReceta.ToLower())
                            {
                                Repetido = true;
                            }

                        } //Busqueda de repeticiones en las recetas (Descarte de recetas repetidas)

                        if (Repetido == false)
                        {
                            RecetasAMostrar.Add(UnaReceta);
                            Coincidencias = 0;
                        }
                    }
                }
            }

            if (RecetasAMostrar.Count != 0)
            {
                foreach (Receta UnaReceta in RecetasAMostrar)
                {
                    LasRecetasEncontradas.Add(UnaReceta);
                }
            }

            
            ViewBag.MisRecetasEncontradas = LasRecetasEncontradas;
            ViewBag.CantRecetasEncontradas = LasRecetasEncontradas.Count();

            return View("BuscarIngredientes");
        }
        public async Task<IActionResult> VaciarLista(List<string> lista)
        {
            lista = null;
            ViewBag.IngredientesBuscados = lista;
            return View("BuscarIngredientes");
        }

        public ActionResult AgregarIngredientesAReceta(int IDReceta)
        {
            ViewBag.IDReceta = IDReceta;

            return View();

        }

        public async Task<IActionResult> AgregarIngredientes(int IDReceta, [Bind("NombreIngrediente, Cantidad")] Ingrediente ing)
        {
            bool existeIng = false;
            List<Ingrediente> ingredientes = _context.Ingrediente.ToList();
            int i = 0;

            while (!existeIng && i < ingredientes.Count)
            {
                existeIng = ingredientes[i].NombreIngrediente.ToLower().Equals(ing.NombreIngrediente.ToLower());
                i++;
            }

            if (!existeIng)
            {
                _context.Add(ing);
                await _context.SaveChangesAsync();
            }

            var ingNuevo = await _context.Ingrediente.FirstOrDefaultAsync(i => i.NombreIngrediente == ing.NombreIngrediente);

            IngPorRec ingXReceta = new IngPorRec(IDReceta, ingNuevo.IDIngrediente, ingNuevo.Cantidad);

            _context.Add(ingXReceta);
            await _context.SaveChangesAsync();



            return RedirectToAction("AgregarIngredientesAReceta", new {IDReceta = IDReceta});

        }
    }

}
