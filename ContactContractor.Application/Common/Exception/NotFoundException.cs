namespace ContactContractor.Application.Common.Exception
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) not found.")
        { }
    }
}
