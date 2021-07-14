using MemoryCache.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemoryCache.Services
{
    public interface IKBBHttpService
    {
        Task<BaseResponseModel<IList<YearResponseModel>>> GetAllYears();
    }
}
