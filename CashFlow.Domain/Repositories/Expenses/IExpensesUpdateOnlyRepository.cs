using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;
public interface IExpensesUpdateOnlyRepository
{
    /// <summary>
    /// Returns a Expense by its ID without AsNoTracking() function.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Expense?> GetById(long id);

    /// <summary>
    /// This function updates an expense and returns a ResponseUpdateExpense message.
    /// </summary>
    /// <param name="expense"></param>
    /// <returns></returns>
    void Update(Expense updatedExpense);
}
