using UnityEngine;
using System.Collections;
using System;

public class Result
{
    private string errorMessage;
    private Exception exception;

    public string ErrosMessage
    {
        get
        {
            return errorMessage;
        }
        set
        {
            errorMessage = value;
            if (value != String.Empty)
            {
                HasError = true;
            }
            else
            {
                HasError = false;
            }
        }
    }

    public Exception Exception
    {
        get
        {
            return exception;
        }
        set
        {
            exception = value;
            if (value != null)
            {
                HasError = true;
                ErrosMessage = value.Message;
            }
            else
            {
                HasError = false;
            }
        }
    }

    public bool HasError { get; private set; }

    public Result(string errorMessage = "", Exception exception = null)
    {
        ErrosMessage = errorMessage;
        Exception = exception;
    }
}