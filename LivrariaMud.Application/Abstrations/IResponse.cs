namespace LivrariaMud.Application.Abstrations;

public interface IResponse<T>
{
    public bool Status { get; }
    public T Data { get; set; }
}
