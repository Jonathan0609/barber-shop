using System.Net;

namespace barber_shop.Exception;

public class ErrorOnValidationException: BarberShopException
{
    private readonly List<string> _errors;

    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    
    public ErrorOnValidationException(List<string> messages): base(string.Empty)
    {
        _errors = messages;
    }
    
    public override List<string> GetErrors()
    {
        return _errors;
    }
}