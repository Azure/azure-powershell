using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.WebApps.Models.WebApp
{
    class PSAppServicePlan
    {
        [Obsolete("This property is deprecated and will be removed in a future releases.")]
        public string AppServicePlanName { get; set; }
    }
}
