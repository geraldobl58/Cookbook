using Cookbook.Communication.Requests;
using Cookbook.Communication.Responses;
using System.ComponentModel.DataAnnotations;

namespace Cookbook.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
        {
            // Validar request
            Validate(request);
            // Mapear a request em uma entidade
            // Criptograr senha
            // Salvar no banco de dados

            return new ResponseRegisterUserJson
            { 
                Name = request.Name
            };
        }
        private void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage);

                throw new Exception();
            }
        }
    }
}
