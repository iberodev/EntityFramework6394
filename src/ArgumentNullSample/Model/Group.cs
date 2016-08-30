using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArgumentNullSample.Model
{
    public class Group
    {
        public Guid Id { get; set; }
        public Guid BusinessId { get; set; }
        public Business Business { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public byte[] RowVersion { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public List<GroupMember> Members { get; set; }
    }
}
