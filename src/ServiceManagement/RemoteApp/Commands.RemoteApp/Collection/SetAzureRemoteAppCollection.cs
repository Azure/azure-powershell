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

using Microsoft.WindowsAzure.Commands.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Management.Automation;
using System.Net;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "AzureRemoteAppCollection", DefaultParameterSetName = DescriptionOnly), OutputType(typeof(TrackingResult))]
    public class SetAzureRemoteAppCollection : RdsCmdlet
    {
        private const string DomainJoined = "DomainJoined";
        private const string RdpPropertyOnly = "RdpPropertyOnly";
        private const string DescriptionOnly = "DescriptionOnly";
        private const string PlanOnly = "PlanOnly";
        private const string AclLevelOnly = "AclLevelOnly";

        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   ParameterSetName = PlanOnly,
                   HelpMessage = "Plan to use for this collection. Use Get-AzureRemoteAppPlan to see the plans available.")]
        [ValidateNotNullOrEmpty]
        public string Plan { get; set; }

        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   ParameterSetName = DomainJoined,
                   HelpMessage = "Credentials of a user that has permission to add computers to the domain.")]
        [ValidateNotNull]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   ParameterSetName = DescriptionOnly,
                   HelpMessage = "Description of what this collection is used for.")]
        [ValidateNotNull]
        public string Description { get; set; }

        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   ParameterSetName = RdpPropertyOnly,
                   HelpMessage = "Used to allow RDP redirection.")]
        [ValidateNotNull]
        public string CustomRdpProperty { get; set; }

        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   ParameterSetName = AclLevelOnly,
                   HelpMessage = "Specifies at which level ACLs are set. Possible values: Collection, Application.")]
        [ValidateNotNullOrEmpty]
        public LocalModels.CollectionAclLevel AclLevel { get; set; }

        public override void ExecuteCmdlet()
        {
            NetworkCredential creds = null;
            CollectionUpdateDetails details = null;
            OperationResultWithTrackingId response = null;
            Collection collection = null;
            bool forceRedeploy = false;

            collection = FindCollection(CollectionName);
            if (collection == null)
            {
                return;
            }

            details = new CollectionUpdateDetails();

            if (Credential != null)
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

                creds = Credential.GetNetworkCredential();
                details.AdInfo.UserName = Credential.UserName;
                details.AdInfo.Password = creds.Password;
                details.AdInfo.DomainName = collection.AdInfo.DomainName;
                details.AdInfo.OrganizationalUnit = collection.AdInfo.OrganizationalUnit;

                if (String.Equals("Inactive", collection.Status, StringComparison.OrdinalIgnoreCase))
                {
                    // the collection may have failed due to bad domain join information before,
                    // re-trying with the new information
                    forceRedeploy = true;
                }
            }
            else if (Plan != null)
            {
                details.PlanName = Plan;
            }
            else if (Description != null)
            {
                details.Description = Description;
            }
            else if (CustomRdpProperty != null)
            {
                details.CustomRdpProperty = CustomRdpProperty;
            }
            else if (this.ParameterSetName == AclLevelOnly)
            {
                CollectionAclLevel newAclLevel = CollectionAclLevel.Unknown;

                switch(AclLevel)
                {
                    case LocalModels.CollectionAclLevel.Application:
                        newAclLevel = CollectionAclLevel.Application;
                        break;

                    case LocalModels.CollectionAclLevel.Collection:
                        newAclLevel = CollectionAclLevel.Collection;
                        break;

                    default:
                        ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                            "Invalid value for AclLevel parameter.",
                            String.Empty,
                            Client.Collections,
                            ErrorCategory.InvalidArgument);
                        ThrowTerminatingError(er);
                        break;
                }

                if(collection.AclLevel == newAclLevel)
                {
                    ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                        String.Format("Collection is already in desired ACL level: {0}.", newAclLevel.ToString()),
                        String.Empty,
                        Client.Collections,
                        ErrorCategory.InvalidArgument);
                    ThrowTerminatingError(er);
                }

                details.AclLevel = newAclLevel;
            }
            else
            {
                ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                    "At least one parameter must be set with this cmdlet",
                    String.Empty,
                    Client.Collections,
                    ErrorCategory.InvalidArgument);
                ThrowTerminatingError(er);
            }

            response = CallClient(() => Client.Collections.Set(CollectionName, forceRedeploy, false, details), Client.Collections);
            if (response != null)
            {
                WriteTrackingId(response);
            }
        }
    }
}
