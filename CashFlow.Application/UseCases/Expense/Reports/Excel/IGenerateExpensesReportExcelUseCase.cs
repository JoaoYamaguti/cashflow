namespace CashFlow.Application.UseCases.Expense.Reports.Excel;
public interface IGenerateExpensesReportExcelUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
