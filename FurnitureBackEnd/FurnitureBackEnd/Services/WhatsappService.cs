using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace FurnitureBackEnd.Services
{
    public class WhatsappService
    {
        private readonly WhatsappSettings _settings;

        public WhatsappService(IOptions<WhatsappSettings> settings)
        {
            _settings = settings.Value;
        }
        public async Task Send(string phone, string message)
        {
            if (!phone.StartsWith("+"))
            {
                phone = "+91" + phone;
            }

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.AccessToken);

            var data = new
            {
                messaging_product = "whatsapp",
                to = phone,
                type = "text",
                text = new { body = message }
            };

            var url = $"https://graph.facebook.com/v19.0/{_settings.PhoneNumberId}/messages";
            var response = await client.PostAsJsonAsync(url, data);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("❌ WhatsApp message send failed:");
                Console.WriteLine($"Status: {response.StatusCode}");
                Console.WriteLine($"Response: {responseContent}");
            }
            else
            {
                Console.WriteLine("✅ WhatsApp message sent successfully:");
                Console.WriteLine(responseContent);
            }
        }
    }
}
