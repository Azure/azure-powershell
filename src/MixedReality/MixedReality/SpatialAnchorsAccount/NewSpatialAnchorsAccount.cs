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

namespace Microsoft.Azure.Commands.MixedReality.SpatialAnchorsAccount
{
    using ResourceManager.Common;
    using ResourceManager.Common.ArgumentCompleters;
    using Management.MixedReality;
    using Management.MixedReality.Models;

    [Cmdlet("New", AzureRMConstants.AzureRMPrefix + ResourceType, DefaultParameterSetName = DefaultParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSpatialAnchorsAccount))]
    public sealed class NewSpatialAnchorsAccount : SpatialAnchorsAccountCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, HelpMessage = "Spatial Anchors Account Name.")]
        [ResourceNameCompleter(FullQualifiedResourceType, nameof(ResourceGroupName))]
        [Alias("SpatialAnchorsAccountName", "AccountName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, HelpMessage = "Spatial Anchors Account Location.")]
        [LocationCompleter(FullQualifiedResourceType)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(ResourceType, MyInvocation.InvocationName))
            {
                var account = new SpatialAnchorsAccount(location: Location, name: Name, type: FullQualifiedResourceType);
                account = Client.SpatialAnchorsAccounts.Create(this.ResourceGroupName, this.Name, account);

                WriteObject(new PSSpatialAnchorsAccount(account));
            }
        }
    }
}
