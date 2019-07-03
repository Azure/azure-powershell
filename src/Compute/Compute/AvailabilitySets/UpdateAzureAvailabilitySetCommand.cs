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

using System.Collections;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AvailabilitySet", SupportsShouldProcess = true)]
    [OutputType(typeof(PSAvailabilitySet))]
    public class UpdateAzureAvailabilitySetCommand : AvailabilitySetBaseCmdlet
    {
        private const string SkuParameterSetName = "SkuParameterSet";

        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public PSAvailabilitySet AvailabilitySet { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = SkuParameterSetName,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The Name of Sku")]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Key-value pairs in the form of a hash table."
            )]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(AvailabilitySet.Name, VerbsData.Update))
            {
                base.ExecuteCmdlet();

                ExecuteClientAction(() =>
                {
                    var avSetParams = new AvailabilitySet
                    {
                        Location = this.AvailabilitySet.Location,
                        PlatformUpdateDomainCount = this.AvailabilitySet.PlatformUpdateDomainCount,
                        PlatformFaultDomainCount = this.AvailabilitySet.PlatformFaultDomainCount,
                        Tags = Tag == null ? null : Tag.Cast<DictionaryEntry>().ToDictionary(d => (string)d.Key, d => (string)d.Value),
                        Sku = new Sku(this.Sku, null, null)
                    };

                    var result = this.AvailabilitySetClient.CreateOrUpdateWithHttpMessagesAsync(
                        this.AvailabilitySet.ResourceGroupName,
                        this.AvailabilitySet.Name,
                        avSetParams).GetAwaiter().GetResult();

                    var psResult = ComputeAutoMapperProfile.Mapper.Map<PSAvailabilitySet>(result);
                    if (result.Body != null)
                    {
                        psResult = ComputeAutoMapperProfile.Mapper.Map(result.Body, psResult);
                    }
                    WriteObject(psResult);
                });
            }
        }
    }
}
