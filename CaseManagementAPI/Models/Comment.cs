using System;
using System.Collections.Generic;

#nullable disable

namespace CaseManagementAPI.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int? CaseId { get; set; }
        public int? CustomerId { get; set; }
        public int? CaseWorkerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }

        public virtual Case Case { get; set; }
        public virtual CaseWorker CaseWorker { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
