using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Expense.DeleteExpense;
using CashFlow.Application.UseCases.Expense.GetAll;
using CashFlow.Application.UseCases.Expense.GetById;
using CashFlow.Application.UseCases.Expense.Register;
using CashFlow.Application.UseCases.Expense.Reports.Excel;
using CashFlow.Application.UseCases.Expense.Reports.Pdf;
using CashFlow.Application.UseCases.Expense.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        AddAutoMapper(services);
    }
   
    private static void AddAutoMapper(IServiceCollection services)
    {
        // Fix: Use the correct overload of AddAutoMapper that accepts a type parameter
        services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapping>());
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
        services.AddScoped<IGenerateExpensesReportExcelUseCase, GenerateExpensesReportExcelUseCase>();
        services.AddScoped<IGenerateExpensesReportPdfUseCase, GenerateExpensesReportPdfUseCase>();
    }
}
