using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArgumentNullSample.Model
{
    public class AppAccess
    {
        public Guid Id { get; set; }
        public Guid UserBusinessId { get; set; }
        public UserBusiness UserBusiness { get; set; }
        public Guid BusinessAppId { get; set; }
        public BusinessApp BusinessApp { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
