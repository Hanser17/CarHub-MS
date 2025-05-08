
namespace DomainLayer.OperationResult
{
    public class Result
    {
        public bool IsSucceeded { get; set; }
        public string? Message { get; set; }
        public dynamic? Data { get; set; }

    }
}
