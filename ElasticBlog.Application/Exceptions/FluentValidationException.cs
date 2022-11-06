namespace ElasticBlog.Application.Exceptions
{
    public class FluentValidationException : Exception
    {
        public List<string> Errors { get; private set; }

        public FluentValidationException(List<ValidationFailure> errors)
        {
            Errors = errors.Select(f => f.ErrorMessage).ToList();
        }
    }
}
