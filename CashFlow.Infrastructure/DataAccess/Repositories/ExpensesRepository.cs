using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository : IExpensesReadOnlyRepository, IExpensesWriteOnlyRepository, IExpensesUpdateOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpensesRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Expense expense)
    {
        // Implementation for adding an expense to the database

        await _dbContext.Expenses.AddAsync(expense);
    }

    public async Task<List<Expense>> GetAll()
    {
        // Implementation for retrieving all expenses from the database
        return await _dbContext.Expenses.AsNoTracking().ToListAsync();
        // AsNoTracking is used to improve performance when tracking is not needed
    }

    async Task<Expense?> IExpensesReadOnlyRepository.GetById(long id)
    {
        // Implementation for retrieving an expense by its ID from the database
        return await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(expense => expense.Id == id);
    }
    async Task<Expense?> IExpensesUpdateOnlyRepository.GetById(long id)
    {
        // Implementation for retrieving an expense by its ID from the database
        return await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);
    }

    public async Task<ResponseDeleteExpenseJson?> DeleteById(long id)
    {
        // Implementation for deleting an expense by its ID from the database
        var expense = await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);

        if (expense is null) return null;

        _dbContext.Expenses.Remove(expense);

        return new ResponseDeleteExpenseJson(id);
    }

    public void Update(Expense updatedExpense)
    {
        _dbContext.Expenses.Update(updatedExpense);
    }

    public async Task<List<Expense>> FilterByMonth(DateOnly date)
    {
        var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

        var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
        var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

        return await _dbContext
            .Expenses
            .AsNoTracking()
            .Where(expense => expense.Date >= startDate && expense.Date <= endDate)
            .OrderBy(expense => expense.Date)
            .ThenBy(expense => expense.Title)
            .ToListAsync();
    }
}
