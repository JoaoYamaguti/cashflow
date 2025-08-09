using CashFlow.Application.UseCases.Expense.DeleteExpense;
using CashFlow.Application.UseCases.Expense.GetAll;
using CashFlow.Application.UseCases.Expense.GetById;
using CashFlow.Application.UseCases.Expense.Register;
using CashFlow.Application.UseCases.Expense.Update;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredExpenseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterExpenseUseCase useCase,
        [FromBody] RequestExpenseJson request
    )
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseExpensesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpensesUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Expenses.Count == 0) return NoContent();

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseExpenseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetExpenseByIdUseCase useCase,
        [FromRoute] long id
    )
    {
        var result = await useCase.Execute(id);

        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseDeleteExpenseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteById(
        [FromServices]IDeleteExpenseUseCase useCase,
        [FromRoute] long id)
    {
        var result = await useCase.Execute(id);

        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateExpenseUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestExpenseJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }
}
