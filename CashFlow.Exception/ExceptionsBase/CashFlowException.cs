﻿namespace CashFlow.Exception.ExceptionsBase;

public abstract class CashFlowException : SystemException
{
    public abstract int StatusCode { get; }
    public abstract List<string> GetErros();
    protected CashFlowException(string message) : base(message)
    {

    }
}
