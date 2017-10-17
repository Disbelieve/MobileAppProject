using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.Models
{
    public sealed class IncrementalLoadingResponse<T>
    {
        public int NextId { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
