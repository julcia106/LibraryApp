using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool HasNewsletterSubscribed { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}
