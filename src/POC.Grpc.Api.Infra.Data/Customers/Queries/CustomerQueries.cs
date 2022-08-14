namespace POC.Grpc.Api.Infra.Data.Customers.Queries
{
    public static class CustomerQueries
    {
        public static string Get { get; } = @"SELECT 
                                                    Id AS Id,
                                                    Name AS Name,
                                                    Age AS Age,
                                                    Active AS Active,
                                                    CashBalanceFloat AS CashBalanceFloat,
                                                    CashBalanceDouble AS CashBalanceDouble,
                                                    CashBalanceDecimal AS CashBalanceDecimal
                                              FROM Customer WITH(NOLOCK)
                                              WHERE Id = @Id";

        public static string List { get; } = @"SELECT
                                                    Id AS Id,
                                                    Name AS Name,
                                                    Age AS Age,
                                                    Active AS Active,
                                                    CashBalanceFloat AS CashBalanceFloat,
                                                    CashBalanceDouble AS CashBalanceDouble,
                                                    CashBalanceDecimal AS CashBalanceDecimal
                                               FROM Customer WITH(NOLOCK)
                                               ORDER BY Id";
    }
}