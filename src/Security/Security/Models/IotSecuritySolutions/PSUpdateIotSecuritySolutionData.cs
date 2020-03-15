using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions
{
    public class PSUpdateIotSecuritySolutionData
    {
        public IDictionary<string, string> Tags { get; set; }

        public PSUserDefinedResources UserDefinedResources { get; set; }

        public IList<PSRecommendationConfiguration> RecommendationsConfiguration { get; set; }
    }
}
