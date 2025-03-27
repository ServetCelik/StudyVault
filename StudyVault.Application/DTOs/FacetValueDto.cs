using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyVault.Application.DTOs
{
    public class FacetValueDto
    {
        public string Value { get; set; } = default!;
        public long Count { get; set; }
    }
}
