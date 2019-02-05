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

using System.Management.Automation;
using Microsoft.Azure.Commands.Kusto.Models;

namespace Microsoft.Azure.Commands.Kusto
{
    [Cmdlet("Test", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KustoClusterName", DefaultParameterSetName = ParameterSet),
        OutputType(typeof(PSKustoClusterNameAvailability))]
    public class TestAzureRmKustoClusterName : KustoCmdletBase
    {
        protected const string ParameterSet = "ByClusterOrResourceGroupOrSubscription";

        [Parameter(
            ParameterSetName = ParameterSet,
            Mandatory = true,
            HelpMessage = "The location where to check.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            ParameterSetName = ParameterSet,
            Mandatory = true,
            HelpMessage = "Name of a specific cluster.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
           string location = Location;
           string clusterName = Name;
           EnsureClusterSpecified(clusterName);

            var result = KustoClient.CheckClusterNameAvailability(clusterName, location);
            WriteObject(result);
        }
    }
}