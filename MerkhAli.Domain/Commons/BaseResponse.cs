using System.Text.Json.Serialization;

namespace MerkhAli.Domain.Commons;

public class BaseResponse<T>
{
    [JsonIgnore]
    public int? Code { get; set; }
    
    public T Data { get; set; }
    
    public Error Error { get; set; }
    
}