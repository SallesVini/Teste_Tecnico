using API_Teste_Tecnico.DTO;
using API_Teste_Tecnico.Models;

namespace API_Teste_Tecnico.Service.UsuarioService
{
    public class UsuarioService : IUsuarioInterface
    {

        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UsuarioDTO>> GetUsuarios()
        {
            try
            {
                var usuarios = await _httpClient.GetFromJsonAsync<List<UsuarioModel>>("https://jsonplaceholder.typicode.com/users");

                return usuarios.Select(u => new UsuarioDTO
                {
                    Id = u.Id,
                    Nome = u.Name,
                    Email = u.Email,
                    Cidade = u.Address.City,
                    Empresa = u.Company.Name
                }).ToList();
            }
            catch (Exception) 
            {
                throw new Exception("Erro ao consumir API de usuários");
            }
        }
    }
}
