namespace MerkhAli.Domain.Commons;

public class Error
{
    public Error(int? code = null,string message = null)
    {
        Code = code;
        Message = message;
    }
    public int? Code { get; set; }
    public string Message { get; set; }
}