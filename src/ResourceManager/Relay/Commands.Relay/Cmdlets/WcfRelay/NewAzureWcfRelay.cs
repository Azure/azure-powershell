﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Relay.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Relay.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Relay.Commands.WcfRelay
{
    /// <summary>
    /// 'New-AzureRmWcfRelay' Cmdlet creates a new WcfRelay
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WcfRelay", SupportsShouldProcess = true), OutputType(typeof(PSWcfRelayAttributes))]
    public class NewAzureRmWcfRelay : AzureRelayCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }        

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "WcfRelay Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
           ParameterSetName = WcfRelayInputObjectParameterSet,
           ValueFromPipelineByPropertyName = true,           
           HelpMessage = "WcfRelay object.")]
        [ValidateNotNullOrEmpty]
        public PSWcfRelayAttributes InputObject { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = WcfRelayPropertiesParameterSet,
           HelpMessage = "WcfRelay Type. Possible values include: 'NetTcp' or 'Http'")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("NetTcp", "Http", IgnoreCase = false)]
        public string WcfRelayType { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = WcfRelayPropertiesParameterSet,
           HelpMessage = "true if client authorization is needed for this relay; otherwise, false")]
        [ValidateNotNullOrEmpty]
        public bool? RequiresClientAuthorization { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = WcfRelayPropertiesParameterSet,
           HelpMessage = "true if transport security is needed for this relay; otherwise, false")]
        [ValidateNotNullOrEmpty]
        public bool? RequiresTransportSecurity { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = WcfRelayPropertiesParameterSet,
           HelpMessage = "Gets or sets usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store  descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored.")]
        [ValidateNotNullOrEmpty]
        public string UserMetadata { get; set; }

        public override void ExecuteCmdlet()
        {
            PSWcfRelayAttributes wcfRelay = new PSWcfRelayAttributes();

            if (InputObject != null)
            {
                wcfRelay = InputObject;
            }
            else
            {
                if (!string.IsNullOrEmpty(WcfRelayType))
                    wcfRelay.RelayType = WcfRelayType;

                if (RequiresClientAuthorization.HasValue)
                    wcfRelay.RequiresClientAuthorization = RequiresClientAuthorization;

                if (RequiresTransportSecurity.HasValue)
                    wcfRelay.RequiresTransportSecurity = RequiresTransportSecurity;

                if (!string.IsNullOrEmpty(UserMetadata))
                    wcfRelay.UserMetadata = UserMetadata;

            }

            if(ShouldProcess(target: Name, action:string.Format("Creating new WcfRelay:{0} under NameSpace:{1} ", Name, Namespace)))
            {
                WriteObject(Client.CreateOrUpdateWcfRelay(ResourceGroupName, Namespace, Name, wcfRelay));
            }
                        
        }
    }
}
