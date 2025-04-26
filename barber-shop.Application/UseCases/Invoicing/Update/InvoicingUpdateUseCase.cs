using barber_shop.Communication.Requests.Invoincing;
using barber_shop.Domain.Enums;
using barber_shop.Domain.Repositories;
using barber_shop.Domain.Repositories.Invoicings;
using barber_shop.Exception;

namespace barber_shop.Application.UseCases.Invoicing.Update;

public class InvoicingUpdateUseCase: IInvoicingUpdateUseCase
{
    private readonly IInvoicingWriteOnlyRepository _invoicingWriteOnlyRepository;
    private readonly IInvoicingReadOnlyRepository _invoicingReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public InvoicingUpdateUseCase(
        IInvoicingWriteOnlyRepository invoicingWriteOnlyRepository,
        IInvoicingReadOnlyRepository invoicingReadOnlyRepository,
        IUnitOfWork unitOfWork)
    {
        _invoicingWriteOnlyRepository = invoicingWriteOnlyRepository;
        _invoicingReadOnlyRepository = invoicingReadOnlyRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Execute(Guid id, InvoicingUpdateRequest request)
    {
        Validate(request);

        var invoice = await _invoicingReadOnlyRepository.GetById(id);

        if (invoice == null)
            throw new NotFoundException(ResourceErrorMessages.INVOICING_NOT_FOUND);
        
        SetInvoiceValues(request, invoice);

        _invoicingWriteOnlyRepository.Update(invoice);

        await _unitOfWork.SaveAsync();
    }

    private static void SetInvoiceValues(
        InvoicingUpdateRequest request,
        Domain.Entities.Invoicing invoice)
    {
        invoice.Title = request.Title;
        invoice.Description = request.Description;
        invoice.Date = request.Date;
        invoice.PaymentType = (PaymentType)request.PaymentType;
        invoice.Value = request.Value;
    }

    private static void Validate(InvoicingUpdateRequest request)
    {
        var validator = new InvoicingUpdateValidate();
        
        var result = validator.Validate(request);

        if (result.IsValid) return;
        
        var errorMessages = result.Errors
            .Select(error => error.ErrorMessage)
            .ToList();
            
        throw new ErrorOnValidationException(errorMessages);
    }
}