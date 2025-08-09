using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expense.Reports.Excel;

public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
{
    private const string CURRENCY_SYMBOL = "$";
    private readonly IExpensesReadOnlyRepository _repository;
    public GenerateExpensesReportExcelUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<byte[]> Execute(DateOnly month)
    {
        var expenses = await _repository.FilterByMonth(month);

        if (expenses.Count == 0) return [];

        using var workbook = new XLWorkbook();

        workbook.Author = "CashFlow";
        workbook.Style.Font.FontSize = 12;
        workbook.Style.Font.FontName = "Times New Roman";

        var worksheet = workbook.AddWorksheet(month.ToString("Y"));

        InsertHeader(worksheet);

        var row = 2;

        foreach (var expense in expenses)
        {
            worksheet.Cell(row, 1).Value = expense.Title;
            worksheet.Cell(row, 2).Value = expense.Date;
            worksheet.Cell(row, 3).Value = ConvertPaymentType(expense.PaymentType);

            worksheet.Cell(row, 4).Value = expense.Amount;
            worksheet.Cell(row, 4).Style.NumberFormat.Format = $"- {CURRENCY_SYMBOL} #,##0.00";

            worksheet.Cell(row, 5).Value = expense.Description;

            row++;
        }

        worksheet.Columns().AdjustToContents();

        var file = new MemoryStream();

        workbook.SaveAs(file);

        return file.ToArray();
    }

    private string ConvertPaymentType(PaymentType payment)
    {
        return payment switch
        {
            PaymentType.Cash => "Cash",
            PaymentType.CreditCard => "Credit Card",
            PaymentType.DebitCard => "Debit Card",
            PaymentType.EletronicTransfer => "Eletronic Transfer",
            _ => string.Empty
        };
    }

    private void InsertHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell(1, 1).Value = ResourceReportGenerationMessages.TITLE;
        worksheet.Cell(1, 2).Value = ResourceReportGenerationMessages.DATE;
        worksheet.Cell(1, 3).Value = ResourceReportGenerationMessages.PAYMENT_TYPE;
        worksheet.Cell(1, 4).Value = ResourceReportGenerationMessages.AMOUNT;
        worksheet.Cell(1, 5).Value = ResourceReportGenerationMessages.DESCRIPTION;

        worksheet.Cells("A1:E1").Style.Font.Bold = true;
        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");

        worksheet.Cell(1, 1). Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Cell(1, 2). Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Cell(1, 3). Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Cell(1, 5). Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        worksheet.Cell(1, 4). Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

    }
}
