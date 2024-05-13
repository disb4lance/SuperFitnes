using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DtoModels.Filters
{
    public sealed record ExerciseFiilterDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
