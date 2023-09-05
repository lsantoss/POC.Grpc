namespace POC.Grpc.App.Domain.Customers.Models
{
    public class CustomerViewModel
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