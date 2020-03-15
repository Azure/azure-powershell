using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions
{
    public class PSIotSecuritySolution
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public string Location { get; set; }

        public string Workspace { get; set; }

        public string DisplayName { get; set; }

        public string Status { get; set; }

        public IList<string> Export { get; set; }

        public IList<string> DisabledDataSources { get; set; }

        public IList<string> IotHubs { get; set; }

        public PSUserDefinedResources UserDefinedResources { get; set; }

        public IList<string> AutoDiscoveredResources { get; set; }

        public IList<PSRecommendationConfiguration> RecommendationsConfiguration { get; set; }

        public string UnmaskedIpLoggingStatus { get; set; }
    }
}
