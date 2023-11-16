using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recepdia.Context;
using Recepedia.Models;

namespace Recepedia.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly RecepediaContext _context;

        public UsuarioController(RecepediaContext context)
        {
            _context = context;
        }
        public ActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> LoginOK(string email, string pass)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(m => m.Contraseña == pass && m.Mail == email);
            if (usuario == null)
            {
                return RedirectToAction("Login");
            }

            //Session["Usuario"] = usuario;
            //System.Web.HttpContext.Current.Session["Usuario"] = usuario;
            HttpContext.Session.SetString("Usuario", usuario.IDUsuario.ToString());
            return RedirectToAction("Details", new { id = usuario.IDUsuario });
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
              return _context.Usuario != null ? 
                          View(await _context.Usuario.ToListAsync()) :
                          Problem("Entity set 'RecepediaContext.Usuario'  is null.");
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (_context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.IDUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDUsuario,Nombre_Usuario,Nombre,Apellido,Mail,Contraseña,RepetirContraseña,Admin,NombreFoto")] Usuario usuario)
        {
            if (ValidarContrasena(usuario.Contraseña, usuario.RepetirContraseña))
            {
                if (ModelState.IsValid)
                {
                    usuario.Contraseña = EncriptarContrasena(usuario.Contraseña);
                    usuario.RepetirContraseña = EncriptarContrasena(usuario.RepetirContraseña);
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDUsuario,Nombre_Usuario,Nombre,Apellido,Mail,Contraseña,RepetirContraseña,Admin,NombreFoto")] Usuario usuario)
        {
            if (id != usuario.IDUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Contraseña = EncriptarContrasena(usuario.Contraseña);
                    usuario.RepetirContraseña = EncriptarContrasena(usuario.RepetirContraseña);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IDUsuario))
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
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.IDUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'RecepediaContext.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuario?.Any(e => e.IDUsuario == id)).GetValueOrDefault();
        }

        private bool ValidarContrasena(string contra1, string contra2)
        {
            return contra1 == contra2;
        }
        private static string EncriptarContrasena(string contra)
        {
            // Generar una sal aleatoria para añadir seguridad
            byte[] salt = GenerateSalt();

            // Concatenar la contraseña y la sal
            byte[] passwordBytes = Encoding.UTF8.GetBytes(contra);
            byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];
            Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

            // Calcular el hash SHA-256
            using SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(saltedPassword);

            // Convertir el hash a una cadena hexadecimal
            string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            return hashedPassword;
        }

        // Función para generar una sal aleatoria
        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16]; // Puedes ajustar la longitud de la sal
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
