using System;
using System.Collections.Generic;

#nullable disable

namespace CaseManagementAPI.Models
{
    public partial class Case
    {
        public Case()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int? CaseWorkerId { get; set; }
        public int? CustomerId { get; set; }
        public int? CaseStatusId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual CaseStatus CaseStatus { get; set; }
        public virtual CaseWorker CaseWorker { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
