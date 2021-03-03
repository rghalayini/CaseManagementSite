using System;
using System.Collections.Generic;

#nullable disable

namespace CaseManagementAPI_server.Models
{
    public partial class CaseWorker
    {
        public CaseWorker()
        {
            Cases = new HashSet<Case>();
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
