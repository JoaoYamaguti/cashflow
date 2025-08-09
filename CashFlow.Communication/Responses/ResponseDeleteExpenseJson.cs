namespace CashFlow.Communication.Responses;

public class ResponseDeleteExpenseJson
{
    public List<string> Message { get; } = [];
    public ResponseDeleteExpenseJson(long id)
    {
        Message.Add($"Expense with ID {id} has been successfully deleted.");
    }
}
