using MemoryCache.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemoryCache.Services
{
    public class KBBHttpServiceCache : IKBBHttpService
    {
        private readonly IMemoryCache _cache;
        private readonly IKBBHttpService _httpService;

        private const string GetAllYearsKey = "GetAllYears";

        public KBBHttpServiceCache(
            IMemoryCache cache,
            IKBBHttpService httpService)
        {
            _cache = cache;
            _httpService = httpService;
        }

        public Task<BaseResponseModel<IList<YearResponseModel>>> GetAllYears()
        {
            return _cache.GetOrCreateAsync(GetAllYearsKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

                return _httpService.GetAllYears();
            });
        }
    }
}
