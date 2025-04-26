using System.Net;

namespace barber_shop.Exception;

public class NotFoundException: BarberShopException
{
    public NotFoundException(string message): base(message)
    {
        
    }
    
    public override int StatusCode => (int)HttpStatusCode.NotFound;
    
    public override List<string> GetErrors()
    {
        return [Message];
    }
}