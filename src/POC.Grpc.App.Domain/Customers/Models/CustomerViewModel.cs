namespace POC.Grpc.App.Domain.Customers.Models
{
    public class CustomerViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }
        public float CashBalanceFloat { get; set; }
        public double CashBalanceDouble { get; set; }
        public decimal CashBalanceDecimal { get; set; }
    }
}