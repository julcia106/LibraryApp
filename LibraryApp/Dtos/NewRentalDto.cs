using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> BookIds { get; set; }
    }
}
