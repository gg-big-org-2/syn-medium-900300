// detector: stripe
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaymentService.Stripe
{
    public class StripePaymentClient
    {
        private readonly HttpClient _httpClient;

        public StripePaymentClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ChargeResponse> CreateChargeAsync(decimal amount, string currency, string source)
        {
            var authHeader = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", stripeApiKey);
            _httpClient.DefaultRequestHeaders.Authorization = authHeader;

            var content = new StringContent(
                JsonSerializer.Serialize(new { amount, currency, source }),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("https://api.stripe.com/v1/charges", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ChargeResponse>(responseBody);
        }
    }
}
