using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CaseManagementAPI.Models
{
    public partial class Comments
    {
        public int Id { get; set; }
        public int? CaseId { get; set; }
        public int? CustomerId { get; set; }
        public int? CaseWorkerId { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }

        public virtual CaseWorkers Case { get; set; }
        public virtual CaseStatus CaseWorker { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
