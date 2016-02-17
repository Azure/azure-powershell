using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.MachineLearning.Contracts
{
    public class PatchWebServiceRequest
    {
        public List<string> Tags;
        public PatchWebServiceRequestProperties Properties;
        public SkuProperties Sku;
    }

    public class PatchWebServiceRequestProperties
    {
        public string Description;
        public WebServiceKeys Keys;
        public RealTimeConfigrationProperties RealTimeConfigration;
        public DiagnosticsProperties Diagnostics;
    }

    public class WebServiceKeys
    {
        public string Primary;
        public string Secondary;
    }
}
