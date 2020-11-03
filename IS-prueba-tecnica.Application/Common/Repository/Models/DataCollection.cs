using System.Collections.Generic;

namespace IS_prueba_tecnica.Application.Common.Repository.Models
{
    public class DataCollection<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
        public string NextUrl { get; set; }
        public string PrevUrl { get; set; }
        public string Search { get; set; }
    }
}
