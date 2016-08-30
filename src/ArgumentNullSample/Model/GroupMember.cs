using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArgumentNullSample.Model
{
    public class GroupMember
    {
        public Guid Id { get; set; }
        public Guid UserBusinessId { get; set; }
        public UserBusiness UserBusiness { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
