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

using System;
using System.Management.Automation;
using Microsoft.Azure.Management.ManagementPartner;
using PartnerResources = Microsoft.Azure.Commands.ManagementPartner.Properties.Resources;


namespace Microsoft.Azure.Commands.ManagementPartner
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagementPartner", SupportsShouldProcess = true),OutputType(typeof(PSManagementPartner))]
    public class UpdateManagementPartner : AzureManagementPartnerCmdletsBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The management partner id")]
        [ValidateNotNull]
        public string PartnerId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(string.Format(PartnerResources.UpdateManagementParnterTarget, PartnerId),
                string.Format(PartnerResources.UpdateManagementParnterAction, PartnerId)))
            {
                try
                {
                    var response = new PSManagementPartner(AceProvisioningManagementPartnerApiClient.Partner
                        .Update(PartnerId));
                    WriteObject(response);
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }
            }
        }
    }
}
