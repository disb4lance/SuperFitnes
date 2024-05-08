using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DtoModels.Filters
{
    public sealed record UserFilterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
