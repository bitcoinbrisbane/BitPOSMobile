using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;

namespace BitPOS
{
	public class BitPOSClient : IExchangeRateClient
	{
		private readonly String _baseUrl;
		private readonly HttpClient _httpClient;
		private readonly String _key;
		private readonly String _password;
		private readonly Boolean _testNet;

		public BitPOSClient (String key, String password, Boolean testNet = false)
		{
			_testNet = testNet;
			_key = key;
			_password = password;
			_httpClient = new HttpClient ();
		}

		public async Task<Models.BitPOS.OrderResponse> CreateOrder(Int32 amountInCents)
		{
			try
			{
				String authorization = String.Format("{0}:{1}", _key, _password);
				Byte[] base64credentials = System.Text.Encoding.UTF8.GetBytes(authorization);

				//Note fields mandatory otherwise 500 error
				Models.BitPOS.OrderRequest request = new Models.BitPOS.OrderRequest() { amount = amountInCents, currency = "AUD", reference = "BitcoinBrisbane", description = "Test Ticket", failureURL="https://www.bitcoinbrisbane.com.au/fail/1", successURL="https://www.bitcoinbrisbane.com.au/greatsuccess/1" };
				String json = JsonConvert.SerializeObject(request);
					
				_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(base64credentials));

				if (_testNet == true)
				{
					//TODO REMOVE HTTPS
					//Use this for test because of SSL issues
					//System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
				}

				var response = await _httpClient.PostAsync ("http://rest.test.bitpos.me/services/webpay/order/create", new StringContent (json, Encoding.UTF8, "application/json"));

				response.EnsureSuccessStatusCode();
				String responseBody = await response.Content.ReadAsStringAsync();

				if (!String.IsNullOrEmpty(responseBody))
				{
					Models.BitPOS.OrderResponse orderResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.BitPOS.OrderResponse>(responseBody);
					return orderResponse;
				}
				else
				{
					throw new ArgumentNullException();
				}
			}
			catch (Exception ex) 
			{
				//Xamarin.Insights.Report (ex);
				throw ex;
			}
		}

		public async Task<Decimal> GetExchangeRateAsync (String currencyCode)
		{
			String baseUrl = "http://rest.test.bitpos.me/services";
			String url = String.Format ("{0}/currency/rate/{1}", baseUrl, currencyCode);
			Task<String> jsonTask = _httpClient.GetStringAsync(url);

			String json = await jsonTask;

			Decimal rate = Newtonsoft.Json.JsonConvert.DeserializeObject<Decimal> (json);
			return rate;
		}

		public async Task<String> GetOrderStatus(String encodedOrderId)
		{
			var response = await _httpClient.GetStringAsync ("http://rest.test.bitpos.me/services/webpay/order/status/" + encodedOrderId);
			return "";
		} 
	}
}