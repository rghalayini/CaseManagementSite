using System;
using System.Collections.Generic;

#nullable disable

namespace CaseManagementAPI_server.Models
{
    public partial class CaseStatus
    {
        public CaseStatus()
        {
            Cases = new HashSet<Case>();
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
