namespace POC.Grpc.Api.Domain.Customers.Queries.Result
{
    public class CustomerQueryResult
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public int Age { get; init; }
        public bool Active { get; init; }
        public float CashBalanceFloat { get; init; }
        public double CashBalanceDouble { get; init; }
        public decimal CashBalanceDecimal { get; init; }
    }
}