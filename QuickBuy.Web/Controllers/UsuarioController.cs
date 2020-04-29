using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("VerificarUsuario")]
        public ActionResult VerificarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioRepositorio = _usuarioRepositorio.Obter(usuario.Email, usuario.Senha);

                if (usuarioRepositorio != null)
                    return Ok(usuarioRepositorio);
            
                return BadRequest("Usuário ou senha inválidos!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioCadastroado = _usuarioRepositorio.Obter(usuario.Email);
                if (usuarioCadastroado != null)
                    return BadRequest("Usuario já cadastrado");

                _usuarioRepositorio.Adicionar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
