using barber_shop.Communication.Enums;
using barber_shop.Communication.Requests.Invoincing;
using Bogus;

namespace CommonTestUtilities.Invoice.Requests;

public class CreateInvoiceRequestBuilder
{
    public static InvoicingCreateRequest Build()
    {
        return new Faker<InvoicingCreateRequest>()
            .RuleFor(request => request.Title, faker => faker.Commerce.ProductName())
            .RuleFor(request => request.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(request => request.Date, faker => faker.Date.Past())
            .RuleFor(request => request.PaymentType, faker => faker.PickRandom<PaymentType>())
            .RuleFor(request => request.Value, faker => faker.Random.Decimal(min: 1, max: 1000));
    }
}