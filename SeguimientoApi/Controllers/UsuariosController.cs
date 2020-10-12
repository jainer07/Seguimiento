using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using SeguimientoApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace SeguimientoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly SegimientoDbContext _context;

        public UsuariosController(SegimientoDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public IEnumerable<Usuario> GetUsuario()
        {
            return _context.Usuario.ToList();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public Usuario GetUsuario(Guid id)
        {
            var usuario = _context.Usuario.Find(id);
            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public ActionResult PutUsuario(Guid id, [FromBody] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            try
            {
                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult PostUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                return Ok();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public Usuario DeleteUsuario(Guid id)
        {
            var usuario = _context.Usuario.Find(id);

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();

            return usuario;
        }

        private bool UsuarioExists(Guid id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
