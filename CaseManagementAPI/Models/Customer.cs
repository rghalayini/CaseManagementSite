using System;
using System.Collections.Generic;

#nullable disable

namespace CaseManagementAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cases = new HashSet<Case>();
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
