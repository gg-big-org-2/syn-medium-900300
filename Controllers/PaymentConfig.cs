using Microsoft.Extensions.Configuration;
using System;

namespace PaymentService.Stripe
{
    public class PaymentConfig
    {
        public string StripePublishableKey { get; set; }
        public string StripeWebhookSecret { get; set; }
        public int TimeoutSeconds { get; set; }

        public static PaymentConfig FromConfiguration(IConfiguration config)
        {
            var section = config.GetSection("Payment:Stripe");
            return new PaymentConfig
            {
                StripePublishableKey = section["PublishableKey"] ?? throw new InvalidOperationException("Missing Stripe publishable key"),
                StripeWebhookSecret = section["WebhookSecret"] ?? throw new InvalidOperationException("Missing Stripe webhook secret"),
                TimeoutSeconds = int.TryParse(section["TimeoutSeconds"], out var timeout) ? timeout : 30
            };
        }
    }
}
