using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDeviceService.Application.Models
{
    public class PagedResultModel<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecords { get; set; }

        public PagedResultModel(List<T> items, int totalRecords)
        {
            Items = items;
            TotalRecords = totalRecords;
        }
    }
}
