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
using Microsoft.Azure.Commands.Dns.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
namespace Microsoft.Azure.Commands.Dns
{
    /// <summary>
    /// Get the resource alias references
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmDnsResourceReference"), OutputType(typeof(List<DnsResourceReference>))]
    public class GetAzureDnsResourceReference : DnsBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Target Resource Id.")]
        [ValidateNotNullOrEmpty]
        public List<string> ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            List<SubResource> requestedResources = this.ResourceId.Select(id => new SubResource() { Id = id }).ToList();
            this.WriteObject(this.DnsClient.GetDnsTargetResources(requestedResources));
        }
    }
}
