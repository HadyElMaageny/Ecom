namespace Ecom.API.Helper;

public class Pagination<T>(int pageNumber, int pageSize, int totalCount, IEnumerable<T> data)
    where T : class
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int TotalCount { get; set; } = totalCount;
    public IEnumerable<T> Data { get; set; } = data;
}