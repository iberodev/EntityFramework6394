using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArgumentNullSample.Model
{
    public class BusinessApp
    {
        public Guid Id { get; set; }
        public Guid BusinessId { get; set; }
        public Business Business { get; set; }
        public string AppId { get; set; }
        public App App { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DeactivatedOn { get; set; }
        public string DeactivationReason { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string ApprovedByUserId { get; set; }
        public User ApprovedByUser { get; set; }
        public List<AppAccess> AppAccess { get; set; }
    }
}
