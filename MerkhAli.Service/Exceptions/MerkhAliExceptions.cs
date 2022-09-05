namespace MerkhAli.Service.Exceptions;

public class MerkhAliExceptions : Exception
{
    public int Code { get; set; }
    public MerkhAliExceptions(int code, string message)
        : base(message)
    {
        this.Code = code;
    }
}