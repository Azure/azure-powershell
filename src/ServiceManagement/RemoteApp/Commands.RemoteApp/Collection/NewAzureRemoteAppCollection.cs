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

using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AzureRemoteAppCollection", DefaultParameterSetName = NoDomain), OutputType(typeof(TrackingResult))]
    public class NewAzureRemoteAppCollection : CmdletWithCollection
    {
        private const string DomainJoined = "DomainJoined";
        private const string NoDomain = "NoDomain";

        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the RemoteApp template image."
        )]
        public string ImageName { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Billing Plan to use for this collection. Use Get-AzureRemoteAppBillingPlans to see the plans available."
        )]
        public string BillingPlan { get; set; }

        [Parameter(Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NoDomain,
            HelpMessage = "Region in which this collection will be created. Use Get-AzureRemoteAppRegionList to see the regions available."
        )]
        public string Region { get; set; }

        [Parameter(Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DomainJoined,
            HelpMessage = "The name of the RemoteApp or Azure VNet to create the collection in."
        )]
        public string VNetName { get; set; }

        [Parameter(Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DomainJoined,
            HelpMessage = "The name of the on-premise domain to join the RD Session Host servers to."
        )]
        [ValidatePattern(DomainNameValidatorString)]
        public string Domain { get; set; }

        [Parameter(Mandatory = true,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DomainJoined,
            HelpMessage = "The users credentials that has permission to add computers to the domain."
        )]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DomainJoined,
            HelpMessage = "The name of your organizational unit to join the RD Session Host servers, e.g. OU=MyOu,DC=MyDomain,DC=ParentDomain,DC=com. Attributes such as OU, DC, etc. must be in uppercase."
        )]
        [ValidatePattern(OrgIDValidatorString)]
        public string OrganizationalUnit { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description of what this collection is used for."
        )]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Used to allow RDP redirection."
        )]
        [ValidateNotNullOrEmpty]
        public string CustomRdpProperty { get; set; }

        public override void ExecuteCmdlet()
        {
            NetworkCredential creds = null;
            CollectionCreationDetails details = new CollectionCreationDetails()
            {
                Name = CollectionName,
                TemplateImageName = ImageName,
                Region = Region,
                BillingPlanName = BillingPlan,
                Description = Description,
                CustomRdpProperty = CustomRdpProperty,
                Mode = CollectionMode.Apps
            };
            OperationResultWithTrackingId response = null;

            switch (ParameterSetName)
            {
                case DomainJoined:
                    {
                        creds = Credential.GetNetworkCredential();
                        details.VnetName = VNetName;

                        details.AdInfo = new ActiveDirectoryConfig()
                        {
                            DomainName = Domain,
                            OrganizationalUnit = OrganizationalUnit,
                            UserName = creds.UserName,
                            Password = creds.Password,
                        };
                        break;
                    }
                case NoDomain:
                    {
                        details.Region = Region;
                        break;
                    }
            }

            // register the subscription for this service if it has not been before
            // sebsequent call to register is redundent

            RegisterSubscriptionWithRdfeForRemoteApp();

            response = CallClient(() => Client.Collections.Create(false, details), Client.Collections);

            if (response != null)
            {
                TrackingResult trackingId = new TrackingResult(response);
                WriteObject(trackingId);
            }

        }
    }
}
