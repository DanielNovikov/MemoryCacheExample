using MemoryCache.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MemoryCache.Services
{
    public class KBBHttpService : IKBBHttpService
    {
        private HttpClient _httpClient;
        private KBBHttpOptions _options;

        private const string GetAllYearsEndpoint = "GetAllYears";

        public KBBHttpService(
            HttpClient httpClient,
            IOptionsSnapshot<KBBHttpOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<BaseResponseModel<IList<YearResponseModel>>> GetAllYears()
        {
            var response = await _httpClient.GetAsync($"{GetAllYearsEndpoint}?{GetSecurityTokenParam()}");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BaseResponseModel<IList<YearResponseModel>>>(json);
        }

        private string GetSecurityTokenParam()
        {
            return $"securityToken={_options.SecurityToken}";
        }
    }
}
