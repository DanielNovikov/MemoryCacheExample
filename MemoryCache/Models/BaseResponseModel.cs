namespace MemoryCache.Models
{
    public class BaseResponseModel<T>
    {
        public int ResponseStatus { get; set; }

        public T Response { get; set; }
    }
}
