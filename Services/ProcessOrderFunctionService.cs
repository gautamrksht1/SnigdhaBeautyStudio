
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Security.Policy;

namespace SnigdhaBeautyStudio.Services
{
    public class ProcessOrderFunctionService : IProcessOrderFunctionService
    {
        private IConfiguration _configuration;
        private IConfidentialClientApplication _confidentialClientApplication;
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

            var url = this._configuration["AzureProcessOrderFunctionApp:azureFunctionURL"];
            var functionKey = this._configuration["AzureProcessOrderFunctionApp:functionKey"];

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("x-functions-key", functionKey);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(content));
            request.Content = httpContent;
            var response = await httpClient.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
