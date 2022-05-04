namespace Numus.Web.Pages;

using EthScanNet.Lib;
using EthScanNet.Lib.Models.EScan;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

public class IndexModel : PageModel
{
    private readonly EScanClient _client;

    [BindProperty]
    public string WalletAddress { get; set; }

    public WalletStats? WalletStats { get; private set; }

    public IndexModel(EScanClient client)
    {
        _client = client;
    }


    private async Task<WalletStats> GetWalletData(string ethAddr)
    {

        var ethAddress = new EScanAddress(ethAddr);
        var balanceWei = (await _client.Accounts.GetBalanceAsync(ethAddress)).Balance;
        var transactions = (await _client.Accounts.GetNormalTransactionsAsync(ethAddress)).Transactions;
        var internalTransactions = (await _client.Accounts.GetInternalTransactionsAsync(ethAddress)).Transactions;
        var tokens = (await _client.Accounts.GetTokenEvents(ethAddress)).TokenTransferEvents;
        var erc20tokens = (await _client.Accounts.GetERC20TokenEvents(ethAddress)).ERC20TokenTransferEvents;

        return new StatCalc(ethAddr,
            balanceWei,
            transactions,
            internalTransactions,
            tokens,
            erc20tokens).GetStats();
    }

    public async Task<IActionResult> OnGetAsync(string? ethAddr)
    {
        if (!string.IsNullOrWhiteSpace(ethAddr))
        {
            WalletAddress = ethAddr;
            WalletStats = await GetWalletData(WalletAddress);
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        return LocalRedirect($"~/?ethAddr={WalletAddress}");
    }
}