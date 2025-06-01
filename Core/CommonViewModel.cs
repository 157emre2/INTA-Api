namespace INTA_Api.Core;

public class CommonViewModel<T> where T : class
{
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
}
