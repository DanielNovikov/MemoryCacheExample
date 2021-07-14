using MemoryCache.Models;
using MemoryCache.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemoryCache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KBBController : ControllerBase
    {
        private IKBBHttpService _kbbHttpService;

        public KBBController(IKBBHttpService kbbHttpService)
        {
            _kbbHttpService = kbbHttpService;
        }

        [HttpGet("GetAllYears")]
        public async Task<IList<YearResponseModel>> GetAllYears()
        {
            var yearsResponse = await _kbbHttpService.GetAllYears();

            return yearsResponse.Response;
        }
    }
}
