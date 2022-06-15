using System.Text.Json;

namespace UserMicroService.EntitiesProvider.ModelEntities.Response
{
    public class ResponseBase
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        protected ResponseBase(string message)
        {
            Message = message;
        }

        protected ResponseBase(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static ResponseBase FromFailure(string message)
        {
            return new ResponseBase(false, message);
        }
        public static ResponseBase FromSuccess(string message)
        {
            return new ResponseBase(true, message);
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public class ResponseBase<T> : ResponseBase
    {
        public T Data { get; protected set; }

        protected ResponseBase(string message, T data) : base(message)
        {
            Success = true;
            Data = data;
        }

        public static ResponseBase<T> FromSuccess(string message, T data)
        {
            return new ResponseBase<T>(message, data);
        }
    }
}
