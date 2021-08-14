using GokhanKoktenBlog.Shared.Utilities.Results.Abstract;
using GokhanKoktenBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GokhanKoktenBlog.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {

        public DataResult(ResultStatus resultStatus, T data)
        {
            Data = data;
            ResultStatus = resultStatus;
        }
        public DataResult(ResultStatus resultStatus, T data, string message)
        {
            Data = data;
            ResultStatus = resultStatus;
            Message = message;
        }
        public DataResult(ResultStatus resultStatus, T data, string message, Exception exception)
        {
            Data = data;
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }


        public T Data { get; }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
