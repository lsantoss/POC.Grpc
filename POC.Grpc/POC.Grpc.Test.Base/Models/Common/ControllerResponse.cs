namespace POC.Grpc.Test.Base.Models.Common
{
    public class ControllerResponse<T> where T : class
    {
        public int StatusCode { get; init; }
        public T Value { get; init; }
    }
}