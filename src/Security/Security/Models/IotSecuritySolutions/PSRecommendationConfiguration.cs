using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions
{
    public class PSRecommendationConfiguration
    {
        public string RecommendationType { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }
    }
}
