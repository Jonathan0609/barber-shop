using barber_shop.Communication.Errors;
using barber_shop.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace barber_shop.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BarberShopException)
            HandleProjectException(context);
        else
            ThrowUnknownError(context);
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var cashFlowException = context.Exception as BarberShopException;
        var errorResponse = new ErrorResponse(cashFlowException!.GetErrors());
        
        context.HttpContext.Response.StatusCode = cashFlowException!.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    } 
    
    private void ThrowUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        
        context.Result = new ObjectResult(new ErrorResponse(ResourceErrorMessages.UNKNOWN_ERROR));
    }
}