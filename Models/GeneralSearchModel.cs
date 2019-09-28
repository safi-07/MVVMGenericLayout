using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GenralSearchModel
    {
        public int RecordsPerPage { get; set; } = 20;
        public bool CalculateTotal { get; set; } = true;
        public int CurrentPage { get; set; } = 1;
        public bool ForExcel { get; set; } = false;
    }
}
