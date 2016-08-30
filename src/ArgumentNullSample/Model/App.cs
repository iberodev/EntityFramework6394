using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArgumentNullSample.Model
{
    public class App
    {
        public string Id { get; set; }
        public string AppName { get; set; }
        public string Description { get; set; }
        public List<BusinessApp> BusinessApps { get; set; }
    }
}
