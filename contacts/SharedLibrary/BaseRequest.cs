namespace SharedLibrary
{
    public class BaseRequest
    {
        public BaseRequest() { }
        public BaseRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
