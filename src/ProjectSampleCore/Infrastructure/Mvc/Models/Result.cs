namespace ProjectSampleCore.Infrastructure.Mvc.Models
{
    public class Result
    {
        protected Result(bool isValid, string message)
        {
            Message = message;
            IsValid = isValid;
        }

        public bool IsValid { get; }
        public string Message { get; }

        public static Result<TEntity, TFields> Valid<TEntity, TFields>(TEntity entity, TFields fields, string message)
        {
            return new Result<TEntity, TFields>(entity, fields, true, message);
        }

        public static Result<TEntity, TFields> Invalid<TEntity, TFields>(TEntity entity, TFields fields, string message)
        {
            return new Result<TEntity, TFields>(entity, fields, false, message);
        }
    }

    public class Result<TEntity, TFields> : Result
    {
        public Result(TEntity entity, TFields fields, bool isValid, string message) : base(isValid, message)
        {
            Entity = entity;
            Fields = fields;
        }

        public TEntity Entity { get; }
        public TFields Fields { get; }
    }
}