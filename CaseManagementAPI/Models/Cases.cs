using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CaseManagementAPI.Models
{
    public partial class Cases
    {
        public int Id { get; set; }
        public int? CaseWorkerId { get; set; }
        public int? CustomerId { get; set; }
        public int? CaseStatusId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual CaseStatus CaseStatus { get; set; }
        public virtual CaseWorkers CaseWorker { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
