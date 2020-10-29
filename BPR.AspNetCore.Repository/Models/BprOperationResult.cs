using System;
using System.Collections.Generic;
using System.Text;

namespace BPR.AspNetCore.Repository
{
    public class BprOperationResult
    {
        public BprOperationResult()
        {
            Exception = null;
            IsSucceeded = true;
        }

        public BprOperationResult(Exception exception)
        {
            Exception = exception;
            IsSucceeded = false;
        }

        public Exception Exception { get; private set; }
        public bool IsSucceeded { get; private set; }

        public static BprOperationResult Success() => new BprOperationResult();
        public static BprOperationResult Fail(Exception exception) => new BprOperationResult(exception);
    }

    public class BprOperationResult<TData> : BprOperationResult
    {
        public BprOperationResult(TData data) : base()
        {
            Data = data;
        }

        public BprOperationResult(Exception exception) : base(exception)
        {
            
        }

        public TData Data { get; set; }

        public static BprOperationResult<TData> Success(TData data) => new BprOperationResult<TData>(data);
        public new static BprOperationResult<TData> Fail(Exception exception) => new BprOperationResult<TData>(exception);
    }
}