using barber_shop.Application.UseCases.Invoicing.Create;
using barber_shop.Application.UseCases.Invoicing.Delete;
using barber_shop.Application.UseCases.Invoicing.Details;
using barber_shop.Application.UseCases.Invoicing.List;
using barber_shop.Application.UseCases.Invoicing.Update;
using barber_shop.Communication.Errors;
using barber_shop.Communication.List;
using barber_shop.Communication.Requests.Invoincing;
using barber_shop.Communication.Responses.Invoicing;
using Microsoft.AspNetCore.Mvc;

namespace barber_shop.API.Controllers.Invoicing;

[ApiController]
[Route("api/invoices")]
public class InvoicingController: Controller
{
    [HttpPost]
    [ProducesResponseType(typeof(InvoicingCreateResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromServices] IInvoicingCreateUseCase useCase, [FromBody] InvoicingCreateRequest request)
    {
        var result = await useCase.Execute(request);
        
        return Created(string.Empty, result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(InvoicingDetailResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create([FromServices] IInvoicingDetailUseCase useCase, [FromRoute] Guid id)
    {
        var result = await useCase.Execute(id);
        
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IInvoicingUpdateUseCase useCase,
        [FromRoute] Guid id,
        [FromBody] InvoicingUpdateRequest request)
    {
        await useCase.Execute(id, request);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromServices] IInvoicingDeleteUseCase useCase, [FromRoute] Guid id)
    {
        await useCase.Execute(id);
        
        return NoContent();
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(ListReturn<InvoicingDetailResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> List(
        [FromServices] IInvoicingListUseCase useCase,
        [FromQuery] InvoicingListRequest request)
    {
        var result = await useCase.Execute(request);
        
        return Ok(result);
    }
}