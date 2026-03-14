using API_Teste_Tecnico.DTO;

namespace API_Teste_Tecnico.Service.UsuarioService
{
    public interface IUsuarioInterface
    {
        Task<List<UsuarioDTO>> GetUsuarios();
    }
}
