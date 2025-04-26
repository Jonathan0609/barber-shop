namespace barber_shop.Communication.List;

public class ListReturn<T>
{
    public int? NextToken { get; set; }
    
    public List<T> Data { get; set; } = [];
}