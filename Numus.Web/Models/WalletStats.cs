namespace Numus.Web.Models;

public class WalletStats
{
    public bool NoData { get; init; }

    public decimal Balance { get; init; }

    public int WalletAge { get; init; }

    public int TotalTransactions { get; init; }

    public double AverageTransactionTime { get; init; }

    public double MaxTransactionTime { get; init; }

    public double MinTransactionTime { get; init; }

    public decimal WalletTurnover { get; init; }

    public int NftHolding { get; init; }

    public int TimeFromLastTransaction { get; init; }

    public decimal NftTrading { get; init; }

    public decimal NftWorth { get; init; }

    public double TransactionsPerMonth => WalletAge / (double) TotalTransactions;

    public int LastMonthTransactions { get; init; }

    public int DeployedContracts { get; init; }

    public int TokensHolding { get; init; }

}