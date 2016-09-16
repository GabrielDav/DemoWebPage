namespace BusinessLogic
{

    /// <summary>
    /// Major error result types, should only contain general errors
    /// </summary>
    public enum Result
    {
        Success = 1,
        BadRequest = 2,
        NotFound = 3,
        InternalError = 4
    }

    public class ServiceResponse
    {
        public Result Result { get; }

        public string Error { get; }

        public ServiceResponse(Result result, string error = null)
        {
            Result = result;
            Error = error;
        }
    }

    /// <summary>
    /// This is a discriminated union to contain either an error or response model.
    /// See <seealso ref="https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/discriminated-unions"/> for more details
    /// </summary>
    public class ServiceResponse<T> : ServiceResponse
    {
        

        public T Model { get; }

        public ServiceResponse(T model) : base(Result.Success)
        {
            Model = model;
        }

        public ServiceResponse(Result result, string error = null) : base(result, error)
        {
            
        }
    }
}
