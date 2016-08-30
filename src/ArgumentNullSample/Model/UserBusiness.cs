using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArgumentNullSample.Model
{
    public class UserBusiness
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid BusinessId { get; set; }
        public Business Business { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public byte[] RowVersion { get; set; }
        public string DeclarantCode { get; set; }
        public byte[] DeclarantPin { get; set; }
        public List<AppAccess> AppAccesses { get; set; }
        public List<GroupMember> GroupMemberships { get; set; }
    }
}
