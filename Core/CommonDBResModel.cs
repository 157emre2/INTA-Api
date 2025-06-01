namespace INTA_Api.Core;

public class CommonDBResModel<T>  where T : class
{
    public bool isSuccess { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
}
