
using System.Net.Http.Headers;


namespace AiRTIST.Service.OpenAIService
{
    public class OpenAIService
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _apiKey;

        public OpenAIService(IConfiguration configuration)
        {
            _apiKey = configuration["OpenAIService:ApiKey"];

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<string> MakeChatRequestAsync(string prompt)
        {
            var jsonString = $"{{\"model\": \"gpt-3.5-turbo\",\"messages\": [{{\"role\": \"system\",\"content\": \"{prompt}\"}}]}}";

            var content = new StringContent(jsonString, null, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            request.Headers.Add("Cookie", "__cf_bm=cONhIBlkQC2P9kOL7VqkOM09pOBBXYWmwf0iOfa7bPc-1707902180-1-AXlfNaur6i2c2Ri0PSKDSwRPqX1nvp/bBvcNVvgdYkNTHhbfHEXWForlcTCWcE4F2kfuwkLeFTrDC7HbDQBbOPI=; _cfuvid=ejWKrljmfEti3pD3gqVC8qBF0OtcETsWwgrY6BXBAco-1707902180071-0-604800000");
            request.Content = content;

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}