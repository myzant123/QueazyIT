namespace QueazyIT.Application.Common.Exceptions;

internal class NotFoundException : Exception
{
    private Guid Id { get; }
    private string Element { get; }

    public NotFoundException(Guid id, string element) : base($"{element} with id: '{id}' not found.")
    {
        Id = id;
        Element = element;
    }
}