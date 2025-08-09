using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expense.DeleteExpense;
public interface IDeleteExpenseUseCase
{
    Task<ResponseDeleteExpenseJson> Execute(long id);
}
