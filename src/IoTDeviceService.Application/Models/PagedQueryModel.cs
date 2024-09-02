namespace IoTDeviceService.Application.Models
{
    public class PagedQueryModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public SortModel? Sort { get; set; }
        public Dictionary<string,string>? Filters { get; set; }

        public PagedQueryModel()
        {
            Filters = new Dictionary<string, string>();
        }
    }

    public class SortModel
    {
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }
}
