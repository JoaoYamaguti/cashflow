namespace CashFlow.Application.UseCases.Expense.Reports.Pdf;
public interface IGenerateExpensesReportPdfUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
