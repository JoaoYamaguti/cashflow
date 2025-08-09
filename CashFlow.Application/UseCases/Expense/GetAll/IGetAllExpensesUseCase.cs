using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expense.GetAll;
public interface IGetAllExpensesUseCase
{
    Task<ResponseExpensesJson> Execute();
}
