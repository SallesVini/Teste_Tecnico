using API_Teste_Tecnico.DTO;
using API_Teste_Tecnico.Service.UsuarioService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Teste_Tecnico.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        // Criando injeção de dependencia para utilizar o metodo do servico UsuarioService
        private readonly IUsuarioInterface _usuarioService;

        public UsuarioController(IUsuarioInterface usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]   
        public async Task<ActionResult> GetListUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuarios();
                return Ok(usuarios);
            }
            catch
            {
                return StatusCode(500, "Erro ao buscar usuários");
            }
        }
    }
}
