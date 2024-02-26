
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
            var clientId = this._configuration["AzureProcessOrderFunctionApp:clientId"];
            var tenantId = this._configuration["AzureProcessOrderFunctionApp:tenantId"];
            var clientSecret = this._configuration["AzureProcessOrderFunctionApp:clientSecret"];
            var scopes = new string[] { "api://fb9c0219-9a33-4479-9c90-b2a17385413c/.default" }; //this._configuration["AzureProcessOrderFunctionApp:scopes"];
            _confidentialClientApplication = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithTenantId(tenantId)
                .WithClientSecret(clientSecret)
                .Build();
            AuthenticationResult result = await _confidentialClientApplication.AcquireTokenForClient(scopes).ExecuteAsync();
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("x-functions-key", functionKey);
            request.Headers.Add("Authorization", result.AccessToken);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(content));
            request.Content = httpContent;
            var response = await httpClient.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
