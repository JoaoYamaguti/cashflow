using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Extensions;

public static class PaymentsTypeExtension
{
    public static string PaymentTypeToString (this PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.Cash => "Cash",
            PaymentType.CreditCard => "Credit Card",
            PaymentType.DebitCard => "Debit Card",
            PaymentType.EletronicTransfer => "Eletronic Transfer",
            _ => string.Empty
        };
    }
}
