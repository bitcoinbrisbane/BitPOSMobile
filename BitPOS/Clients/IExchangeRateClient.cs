using System;
using System.Threading.Tasks;

namespace BitPOS
{
	public interface IExchangeRateClient
	{
		Task<Decimal> GetExchangeRateAsync(String currencyCode);
	}
}