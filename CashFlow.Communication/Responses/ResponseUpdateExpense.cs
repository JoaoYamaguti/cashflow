namespace CashFlow.Communication.Responses;

public class ResponseUpdateExpense
{
    public List<string> Message = [];
    public ResponseUpdateExpense(long id)
    {
        Message.Add($"Expense with ID {id} has been successfully updated.");
    }
}
