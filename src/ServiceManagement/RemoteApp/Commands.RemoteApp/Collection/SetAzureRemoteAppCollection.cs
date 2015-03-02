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

using Microsoft.Azure.Commands.RemoteApp;
using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using System;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "AzureRemoteAppCollection"), OutputType(typeof(TrackingResult))]
    public class SetAzureRemoteAppCollection : RdsCmdlet
    {
        private const string DomainJoined = "DomainJoined";
        private const string NoDomain = "NoDomain";

        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = false,
                   Position = 1,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Plan to use for this collection. Use Get-AzureRemoteAppPlan to see the plans available.")]
        [ValidateNotNullOrEmpty]
        public string Plan { get; set; }

        [Parameter(Mandatory = false,
                   Position = 2,
                   ValueFromPipelineByPropertyName = true,
                   ParameterSetName = DomainJoined,
                   HelpMessage = "Credentials of a user that has permission to add computers to the domain.")]
        [ValidateNotNull]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Description of what this collection is used for.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Used to allow RDP redirection.")]
        [ValidateNotNullOrEmpty]
        public string CustomRdpProperty { get; set; }

        public override void ExecuteCmdlet()
        {
            NetworkCredential creds = null;
            CollectionCreationDetails details = null;
            OperationResultWithTrackingId response = null;
            Collection collection = null;

            collection = FindCollection(CollectionName);
            if (collection == null)
            {
                return;
            }

            details = new CollectionCreationDetails()
            {
                Name = CollectionName,
                BillingPlanName = String.IsNullOrWhiteSpace(Plan) ? collection.BillingPlanName : Plan,
                Description = String.IsNullOrWhiteSpace(Description) ? collection.Description : Description,
                CustomRdpProperty = String.IsNullOrWhiteSpace(CustomRdpProperty) ? collection.CustomRdpProperty : CustomRdpProperty,
                TemplateImageName = collection.TemplateImageName
            };

            switch (ParameterSetName)
            {
                case DomainJoined:
                    {
                        if (collection.AdInfo == null)
                        {
                            ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                Commands_RemoteApp.AadInfoCanNotBeAddedToCloudOnlyCollectionMessage,
                                String.Empty,
                                Client.Collections,
                                ErrorCategory.InvalidArgument);
                            ThrowTerminatingError(er);
                        }

                        details.AdInfo = new ActiveDirectoryConfig();
                        details.VnetName = collection.VnetName;
                        details.AdInfo.DomainName = collection.AdInfo.DomainName;
                        details.AdInfo.OrganizationalUnit = collection.AdInfo.OrganizationalUnit;

                        if (Credential != null)
                        {
                            creds = Credential.GetNetworkCredential();
                            details.AdInfo.UserName = creds.UserName;
                            details.AdInfo.Password = creds.Password;
                        }
                        break;
                    }
            }

            response = CallClient(() => Client.Collections.Set(CollectionName, false, false, details), Client.Collections);
            if (response != null)
            {
                TrackingResult trackingId = new TrackingResult(response);
                WriteObject(trackingId);
            }
        }
    }
}
