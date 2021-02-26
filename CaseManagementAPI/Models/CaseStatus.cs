using System;
using System.Collections.Generic;

#nullable disable

namespace CaseManagementAPI.Models
{
    public partial class CaseStatus
    {
        public CaseStatus()
        {
            Cases = new HashSet<Case>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}
