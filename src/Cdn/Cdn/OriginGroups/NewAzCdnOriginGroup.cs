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
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System;
using Microsoft.Azure.Commands.Cdn.Models.OriginGroup;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Commands.Cdn.Helpers;

namespace Microsoft.Azure.Commands.Cdn.OriginGroups
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnOriginGroup", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSOriginGroup))]
    public class NewAzCdnOriginGroup : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Azure CDN endpoint name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN origin group name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN origin group ids.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<string> OriginId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The number of seconds between health probes.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public int ProbeIntervalInSeconds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The path relative to the origin that is used to determine the health of the origin.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProbePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Protocol to use for health probe.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Http", "Https")]
        public string ProbeProtocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The type of health probe request that is made.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("GET", "HEAD")]
        public string ProbeRequestType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN profile name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group of the Azure CDN profile.", ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The CDN origin group object.", ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSOriginGroup CdnOriginGroup { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                EndpointName = CdnOriginGroup.EndpointName;
                OriginGroupName = CdnOriginGroup.Name;
                ProfileName = CdnOriginGroup.ProfileName;
                ResourceGroupName = CdnOriginGroup.ResourceGroupName;

                ProbeIntervalInSeconds = CdnOriginGroup.ProbeIntervalInSeconds;
                ProbePath = CdnOriginGroup.ProbePath;
                ProbeProtocol = CdnOriginGroup.ProbeProtocol;
                ProbeRequestType = CdnOriginGroup.ProbeRequestType;     
            }

            ConfirmAction(MyInvocation.InvocationName, OriginGroupName, CreateOriginGroup);
        }

        public void CreateOriginGroup()
        {
            Management.Cdn.Models.OriginGroup originGroup = new Management.Cdn.Models.OriginGroup();

            if (ParameterSetName == ObjectParameterSet)
            {
                originGroup.Origins = CdnOriginGroup.Origins;
            }
            else
            {
                originGroup.Origins = new List<Management.Cdn.Models.ResourceReference>();

                // OriginId refers to the list of origin ids, needed to be singular name per PS guidelines
                foreach (string originId in OriginId)
                {
                    Management.Cdn.Models.ResourceReference originIdResourceReference = new Management.Cdn.Models.ResourceReference(originId);
                    originGroup.Origins.Add(originIdResourceReference);
                }
            }

            bool isProbeIntervalInSecondsNotZero = ProbeIntervalInSeconds != 0 ? true : false;

            if (isProbeIntervalInSecondsNotZero || !String.IsNullOrWhiteSpace(ProbePath) || !String.IsNullOrWhiteSpace(ProbeProtocol) || !String.IsNullOrWhiteSpace(ProbeRequestType))
            {
                int probeIntervalCopy = ProbeIntervalInSeconds;

                // when probe interval is 0 or not specified, set the probe interval to the default value
                if (!isProbeIntervalInSecondsNotZero)
                {
                    probeIntervalCopy = 240;
                }

                originGroup.HealthProbeSettings = new Management.Cdn.Models.HealthProbeParameters
                {
                    ProbeIntervalInSeconds = probeIntervalCopy,
                    ProbePath = ProbePath,
                    ProbeProtocol = OriginGroupUtilities.NormalizeProbeProtocol(ProbeProtocol),
                    ProbeRequestType = OriginGroupUtilities.NormalizeProbeRequestType(ProbeRequestType)
                };
            }

            try
            {
                var createdOriginGroup = CdnManagementClient.OriginGroups.Create(
                    ResourceGroupName,
                    ProfileName,
                    EndpointName,
                    OriginGroupName,
                    originGroup);

                WriteVerbose(Resources.Success);
                WriteObject(createdOriginGroup.ToPsOriginGroup());
            }
            catch (Management.Cdn.Models.ErrorResponseException e)
            {
                throw new PSArgumentException(string.Format("Error response received.Error Message: '{0}'",
                                     e.Response.Content));
            }
        }
    }
}
