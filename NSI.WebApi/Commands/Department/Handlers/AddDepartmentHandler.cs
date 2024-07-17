using FluentValidation;
using MediatR;
using NSI.BusinessLayer.Abstract;
using NSI.BusinessLayer.Concrete;
using NSI.DataTransferObject;
using NSI.Shared.ResponseData.Abstract;
using NSI.Shared.ResponseData.Concrete;
using NSI.Validation;
using NSI.WebApi.Commands.Department.Requests;
using System.Text;

namespace NSI.WebApi.Commands.Department.Handlers
{
    public class AddDepartmentHandler : IRequestHandler<AddDepartmentRequest, IBaseResponseData>
    {
        private readonly IDepartmentBL _departmentBL = new DepartmentBL();
        private readonly IValidator<DepartmentDTO> _validator = new DepartmentValidator();

        public async Task<IBaseResponseData> Handle(AddDepartmentRequest request, CancellationToken cancellationToken)
        {
            using IBaseResponseData responseData = new BaseResponseData();
            try
            {
                var validationResult = await _validator.ValidateAsync(request.Department, cancellationToken);

                if (!validationResult.IsValid)
                {
                    var validationFailures = validationResult.Errors
                        .Select(x => $"Hata Kodu: {x.ErrorCode}, Hata Mesajı: {x.ErrorMessage}")
                        .Aggregate((x, y) => $"{x} | {y}");

                    throw new ValidationException(validationFailures);
                }

                responseData.Data = await _departmentBL.AddAsync(request.Department, cancellationToken);
            }
            catch (Exception ex)
            {
                responseData.IsError = true;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
    }
}
