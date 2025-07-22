namespace PocketTrack.Services.API
{
    public class Result<T>
    {
        public bool Success => Code == OK;
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static Result<T> Ok(T data, string message = "Success")
        {
            return new Result<T> { Code = OK, Data = data, Message = message };
        }

        public static Result<T> Fail(string message, int code = SERVER_ERROR)
        {
            return new Result<T> { Code = code, Message = message };
        }

        //Codes
        public const int OK = 200;
        public const int CREATED = 201;
        public const int BAD_REQUEST = 400;
        public const int UNAUTHORIZED = 401;
        public const int NOT_FOUND = 404;
        public const int UNPROCESSABLE_ENTITY = 422;
        public const int SERVER_ERROR = 500;
    }
}
