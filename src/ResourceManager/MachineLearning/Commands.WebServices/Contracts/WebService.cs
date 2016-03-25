using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.MachineLearning.Contracts
{
    public class WebService
    {
        public string Id;
        public string Name;
        public string Type;
        public string Location;
        public List<string> Tags;
        public WebServiceProperties Properties;
    }

    public class WebServiceProperties
    {
        public string ProvisioningState; // Should be an enum?
        public DateTime CreatedOn;
        public DateTime ModifiedOn;
        public WebServiceKeys Keys;
        public RealTimeConfigrationProperties RealTimeConfigration;
        public bool ReadOnly;
        public DiagnosticsProperties Diagnostics;
        public SupportedLanguages Runtime;
    }
}
