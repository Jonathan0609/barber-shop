using barber_shop.Communication.Requests.Invoincing;
using barber_shop.Communication.Responses.Invoicing;
using barber_shop.Domain.Enums;
using barber_shop.Domain.Repositories;
using barber_shop.Domain.Repositories.Invoicings;
using barber_shop.Exception;

namespace barber_shop.Application.UseCases.Invoicing.Create;

internal class InvoicingCreateUseCase: IInvoicingCreateUseCase
{
    private readonly IInvoicingWriteOnlyRepository _invoicingWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InvoicingCreateUseCase(
        IInvoicingWriteOnlyRepository invoicingWriteOnlyRepository,
        IUnitOfWork unitOfWork)
    {
        _invoicingWriteOnlyRepository = invoicingWriteOnlyRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<InvoicingCreateResponse> Execute(InvoicingCreateRequest request)
    {
        Validate(request);

        var entity = new Domain.Entities.Invoicing
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Date = request.Date,
            Description = request.Description,
            Value = request.Value,
            PaymentType = (PaymentType)request.PaymentType,
        };

        await _invoicingWriteOnlyRepository.Add(entity);

        await _unitOfWork.SaveAsync();

        return new InvoicingCreateResponse(entity.Id);
    }

    private static void Validate(InvoicingCreateRequest request)
    {
        var validator = new InvoicingCreateValidate();
        
        var result = validator.Validate(request);

        if (result.IsValid) return;
        
        var errorMessages = result.Errors
            .Select(error => error.ErrorMessage)
            .ToList();
            
        throw new ErrorOnValidationException(errorMessages);
    }
}