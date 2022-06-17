namespace POC.Grpc.Test.Tools.Models.Common
{
    public class ControllerResponse<T> where T : class
    {
        public int StatusCode { get; init; }
        public T Value { get; init; }
    }
}