
using Newtonsoft.Json;
using System.Security.Policy;

namespace SnigdhaBeautyStudio.Services
{
    public class ProcessOrderFunctionService : IProcessOrderFunctionService
    {
        private IConfiguration _configuration;

        public ProcessOrderFunctionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CallProcessOrderFunctionAsync()
        {
            dynamic content = new
            {
                Email = "pqr@gmail.com",
                Password = "Pqr123@abcP"
            };

            string url = this._configuration["AzureFunctionURL"];
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("x-functions-key", "-u2xEOXEKOjU1uS8l00jDN0y46yNyId9okQnVIoRHHsqAzFuOddBJw==");
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(content));
            request.Content = httpContent;
            var response = await httpClient.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
