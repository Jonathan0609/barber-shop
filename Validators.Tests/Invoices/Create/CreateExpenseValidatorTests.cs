using barber_shop.Application.UseCases.Invoicing.Create;
using barber_shop.Exception;
using CommonTestUtilities.Invoice.Requests;
using Shouldly;
using Xunit;

namespace Validators.Tests.Invoices.Create;

public class CreateExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange

        var validator = new InvoicingCreateValidate();

        var request = CreateInvoiceRequestBuilder.Build();

        //Act
        
        var result = validator.Validate(request);

        //Assert 
        
        result.IsValid.ShouldBeTrue();
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void ErrorTitleEmpty(string title)
    {
        //Arrange
        var validator = new InvoicingCreateValidate();
        var request = CreateInvoiceRequestBuilder.Build();
        
        request.Title = title;

        //Act
        var result = validator.Validate(request);

        //Asserts
        result.IsValid.ShouldBeFalse();
        
        result.Errors.ShouldSatisfyAllConditions(
            () => result.Errors.ShouldHaveSingleItem(), 
            () => result.Errors.ShouldContain(error => error.ErrorMessage == ResourceErrorMessages.TITLE_NOT_EMPTY));
    }
}