namespace Numus.Web.Helpers;

using System.Numerics;
using EthScanNet.Lib.Models.ApiResponses.Accounts.Models;

public static class EthHelpers
{
    /// <summary>
    /// Wei in one ETH.
    /// </summary>
    private const ulong WeiToEth = 1000000000000000000;

    /// <summary>
    /// Convert Wei value to Eth.
    /// </summary>
    /// <param name="valueInWei">Wei.</param>
    /// <returns>Total ETH.</returns>
    public static decimal ToEth(this BigInteger valueInWei)
    {
        return (decimal) valueInWei / WeiToEth;
    }

    /// <summary>
    /// Convert Wei value to Eth.
    /// </summary>
    /// <param name="valueInWei">Wei.</param>
    /// <returns>Total ETH.</returns>
    public static decimal ToEth(this decimal valueInWei)
    {
        return new BigInteger(valueInWei).ToEth();
    }

    /// <summary>
    /// Get token UID based on it ContractAddress and Id.
    /// </summary>
    /// <param name="token">Token info.</param>
    /// <returns>Token UID.</returns>
    public static string GetTokenUid(this EScanTokenTransferEvent token)
    {
        return token.ContractAddress + "_" + token.TokenId;
    }

    /// <summary>
    /// Convert Unix TimeStamp to DateTime.
    /// </summary>
    /// <param name="unixTimeStamp">Unix TimeStamp in string.</param>
    /// <returns><see cref="DateTime"/></returns>
    public static DateTime ToDateTime(this string unixTimeStamp)
    {
        DateTime dateTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddSeconds(long.Parse(unixTimeStamp)).ToLocalTime();
        return dateTime;
    }

}