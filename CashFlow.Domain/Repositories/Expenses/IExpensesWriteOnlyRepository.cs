using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;
public interface IExpensesWriteOnlyRepository
{
    Task Add(Expense expense);
    /// <summary>
    /// This function returns a List<string> with "Expense with ID {id} has been successfully deleted." if the deletion was successful, outherwise returns null.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ResponseDeleteExpenseJson?> DeleteById(long id);
}
