using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DtoModels.Filters
{
    public class PhysicalMetricsFilterDto
    {
            public DateTime? DateFrom { get; set; } // Фильтр по дате начиная с определенной даты
            public DateTime? DateTo { get; set; } // Фильтр по дате до определенной даты
        
    }
}
