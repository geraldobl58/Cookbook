using Cookbook.Communication.Requests;
using Cookbook.Communication.Responses;

namespace Cookbook.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
        {
            // Validar request
            // Mapear a request em uma entidade
            // Criptograr senha
            // Salvar no banco de dados

            return new ResponseRegisterUserJson
            { 
                Name = request.Name
            };
        }
    }
}
