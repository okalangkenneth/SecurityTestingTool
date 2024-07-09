using RestSharp;
using System.Threading.Tasks;

namespace SecurityTesting.DAST
{
    public class DASTService
    {
        private readonly RestClient _client;

        public DASTService(string zapUrl)
        {
            _client = new RestClient(zapUrl);
        }

        public async Task StartScan(string targetUrl)
        {
            var request = new RestRequest("JSON/ascan/action/scan", Method.Post);
            request.AddParameter("url", targetUrl);
            await _client.ExecuteAsync(request);
        }
    }
}
