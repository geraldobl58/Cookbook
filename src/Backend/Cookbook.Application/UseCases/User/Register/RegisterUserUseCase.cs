using Cookbook.Application.Services.AutoMapper;
using Cookbook.Communication.Requests;
using Cookbook.Communication.Responses;
using Cookbook.Exceptions.ExceptionBase;

namespace Cookbook.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
        {
            Validate(request);

            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            var user = autoMapper.Map<Domain.Entities.User>(request);

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
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidateException(errorMessages);
            }
        }
    }
}
