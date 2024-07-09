
using SecurityTestingBlazor.Models;
using System.Net.Http.Json;

namespace SecurityTestingBlazor.Services
{
    public class SecurityTestingService
    {
        private readonly HttpClient _httpClient;

        public SecurityTestingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task StartSAST(string codeBasePath)
        {
            var response = await _httpClient.PostAsJsonAsync("api/securityTests/start-sast", codeBasePath);
            response.EnsureSuccessStatusCode();
        }

        public async Task StartDAST(string targetUrl)
        {
            var response = await _httpClient.PostAsJsonAsync("api/securityTests/start-dast", targetUrl);
            response.EnsureSuccessStatusCode();
        }

        public async Task StartPenTest(PenTestRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/securityTests/start-pen-test", request);
            response.EnsureSuccessStatusCode();
        }

        public async Task GenerateReport(List<Vulnerability> vulnerabilities, string filePath)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/securityTests/generate-report?filePath={filePath}", vulnerabilities);
            response.EnsureSuccessStatusCode();
        }
    }
}
