using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class AzureAuditLog: PSDataSourcePropertiesBase
    {
        public string LinkedResourceId { get; set; }
    }
}
