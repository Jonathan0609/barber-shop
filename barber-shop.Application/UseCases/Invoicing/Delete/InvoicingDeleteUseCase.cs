using barber_shop.Domain.Repositories;
using barber_shop.Domain.Repositories.Invoicings;
using barber_shop.Exception;

namespace barber_shop.Application.UseCases.Invoicing.Delete;

public class InvoicingDeleteUseCase: IInvoicingDeleteUseCase
{
    private readonly IInvoicingWriteOnlyRepository _invoicingWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public InvoicingDeleteUseCase(IInvoicingWriteOnlyRepository invoicingWriteOnlyRepository, IUnitOfWork unitOfWork)
    {
        _invoicingWriteOnlyRepository = invoicingWriteOnlyRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Execute(Guid id)
    {
        var result = await _invoicingWriteOnlyRepository.Delete(id);

        if (!result)
            throw new NotFoundException(ResourceErrorMessages.INVOICING_NOT_FOUND);
        
        await _unitOfWork.SaveAsync();
    }
}