// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions
{
    public class PSIotSecuritySolution : PSResource
    {
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
