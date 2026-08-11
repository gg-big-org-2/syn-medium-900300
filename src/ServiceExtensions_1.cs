using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;

namespace PaymentService.Stripe
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddStripePaymentService(this IServiceCollection services, IConfiguration config)
        {
            var paymentConfig = PaymentConfig.FromConfiguration(config);
            services.AddSingleton(paymentConfig);

            services.AddHttpClient<StripePaymentClient>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri("https://api.stripe.com/v1/");
                    client.Timeout = TimeSpan.FromSeconds(paymentConfig.TimeoutSeconds);
                });

            return services;
        }
    }
}
