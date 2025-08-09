﻿using CashFlow.Application.UseCases.Expense;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommontestUtilities.Requests;
using Shouldly;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestExpenseJsonBuilder.Build();
        //Act
        var result = validator.Validate(request);

        //Assert
        result.ShouldNotBeNull();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("       ")]
    public void Error_Title_Empty(string title)
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestExpenseJsonBuilder.Build();
        request.Title = title;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBe(false);
        result.Errors.ShouldSatisfyAllConditions(
            () => result.Errors.Count().ShouldBe(1),
            () => result.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceErrormessages.TITLE_REQUIRED))
        );
    }

    [Fact]
    public void Error_Date_Future()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestExpenseJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBe(false);
        result.Errors.ShouldSatisfyAllConditions(
            () => result.Errors.Count().ShouldBe(1),
            () => result.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceErrormessages.EXPENSES_CANNOT_FOR_THE_FUTURE))
        );
    }

    [Fact]
    public void Error_PaymentType_Invalid()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestExpenseJsonBuilder.Build();
        request.PaymentType = (PaymentType)700;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBe(false);
        result.Errors.ShouldSatisfyAllConditions(
            () => result.Errors.Count().ShouldBe(1),
            () => result.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceErrormessages.PAYMENT_TYPE_INVALID))
        );
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-7)]
    public void Error_Amount_Invalid(decimal amount)
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestExpenseJsonBuilder.Build();
        request.Amount = amount;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBe(false);
        result.Errors.ShouldSatisfyAllConditions(
            () => result.Errors.Count().ShouldBe(1),
            () => result.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceErrormessages.AMOUNT_MUST_BE_GREATER_THAN_0))
        );
    }
}
