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

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    using Microsoft.WindowsAzure.Commands.RemoteApp;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Microsoft.WindowsAzure.Management.RemoteApp;
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using System;
    using System.Management.Automation;
    using System.Net;
    using System.Threading.Tasks;

    [Cmdlet(VerbsCommon.New, "AzureRemoteAppCollection", DefaultParameterSetName = NoDomain), OutputType(typeof(TrackingResult))]
    public class NewAzureRemoteAppCollection : RdsCmdlet
    {
        private const string DomainJoined = "DomainJoined";
        private const string NoDomain = "NoDomain";
        private const string AzureVNet = "AzureVNet";

        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the RemoteApp template image."
        )]
        public string ImageName { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Plan to use for this collection. Use Get-AzureRemoteAppPlan to see the plans available."
        )]
        public string Plan { get; set; }

        [Parameter(Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NoDomain,
            HelpMessage = "Location in which this collection will be created. Use Get-AzureRemoteAppLocation to see the locations available."
        )]
        public string Location { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the RemoteApp or Azure VNet to create the collection in."
        )]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = DomainJoined)]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = AzureVNet)]
        public string VNetName { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureVNet,
            HelpMessage = "For Azure VNets only, a comma-separated list of DNS servers for the VNet."
        )]
        [ValidateNotNullOrEmpty]
        public string DnsServers { get; set; }

        [Parameter(Mandatory = true,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureVNet,
            HelpMessage = "For Azure VNets only, the name of the subnet."
        )]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the on-premise domain to join the RD Session Host servers to."
        )]
        [Parameter(Mandatory = true, Position = 4, ParameterSetName = DomainJoined)]
        [Parameter(Mandatory = true, Position = 4, ParameterSetName = AzureVNet)]
        [ValidatePattern(DomainNameValidatorString)]
        public string Domain { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The users credentials that has permission to add computers to the domain."
        )]
        [Parameter(Mandatory = true, Position = 5, ParameterSetName = DomainJoined)]
        [Parameter(Mandatory = true, Position = 5, ParameterSetName = AzureVNet)]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of your organizational unit to join the RD Session Host servers, e.g. OU=MyOu,DC=MyDomain,DC=ParentDomain,DC=com. Attributes such as OU, DC, etc. must be in uppercase."
        )]
        [Parameter(ParameterSetName = DomainJoined)]
        [Parameter(ParameterSetName = AzureVNet)]
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

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Sets the resource type of the collection."
        )]
        public CollectionMode? ResourceType { get; set; }

        public override void ExecuteCmdlet()
        {
            // register the subscription for this service if it has not been before
            // sebsequent call to register is redundent
            RegisterSubscriptionWithRdfeForRemoteApp();

            NetworkCredential creds = null;
            CollectionCreationDetails details = new CollectionCreationDetails()
            {
                Name = CollectionName,
                TemplateImageName = ImageName,
                Region = Location,
                PlanName = Plan,
                Description = Description,
                CustomRdpProperty = CustomRdpProperty,
                Mode = (ResourceType == null || ResourceType == CollectionMode.Unassigned) ? CollectionMode.Apps : ResourceType.Value
            };
            OperationResultWithTrackingId response = null;


            switch (ParameterSetName)
            {
                case DomainJoined:
                case AzureVNet:
                {
                    creds = Credential.GetNetworkCredential();
                    details.VNetName = VNetName;

                    if (SubnetName != null)
                    {
                        if (!IsFeatureEnabled(EnabledFeatures.azureVNet))
                        {
                            ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                     string.Format(Commands_RemoteApp.LinkAzureVNetFeatureNotEnabledMessage),
                                     String.Empty,
                                     Client.Account,
                                     ErrorCategory.InvalidOperation
                                     );

                            ThrowTerminatingError(er);
                        }

                        details.SubnetName = SubnetName;
                        ValidateCustomerVNetParams(details.VNetName, details.SubnetName);

                        if (DnsServers != null)
                        {
                            details.DnsServers = DnsServers.Split(new char[] { ',' });
                        }

                        details.Region = Location;
                    }

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
                default:
                {
                    details.Region = Location;
                    break;
                }
            }

            response = CallClient(() => Client.Collections.Create(false, details), Client.Collections);

            if (response != null)
            {
                TrackingResult trackingId = new TrackingResult(response);
                WriteObject(trackingId);
            }
        }

        private bool ValidateCustomerVNetParams(string name, string subnet)
        {
            NetworkListResponse.VirtualNetworkSite azureVNet = GetAzureVNet(name);
            bool isValidSubnetName = false;

            if (azureVNet == null)
            {
                ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                        String.Format(Commands_RemoteApp.InvalidArgumentVNetNameNotFoundMessageFormat, name),
                                        String.Empty,
                                        Client.Collections,
                                        ErrorCategory.InvalidArgument
                                        );

                ThrowTerminatingError(er);
            }

            foreach (NetworkListResponse.Subnet azureSubnet in azureVNet.Subnets)
            {
                if (string.Compare(azureSubnet.Name, subnet, true) == 0)
                {
                    isValidSubnetName = true;

                    Location = azureVNet.Location;
                    break;
                }
            }

            if (!isValidSubnetName)
            {
                ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                        String.Format(Commands_RemoteApp.InvalidArgumentSubNetNameNotFoundMessageFormat, subnet),
                                        String.Empty,
                                        Client.Collections,
                                        ErrorCategory.InvalidArgument
                                        );

                ThrowTerminatingError(er);
            }

            return isValidSubnetName;
        }

        private NetworkListResponse.VirtualNetworkSite GetAzureVNet(string name)
        {
            NetworkManagementClient networkClient = new NetworkManagementClient(this.Client.Credentials, this.Client.BaseUri);
            Task<NetworkListResponse> listNetworkTask = networkClient.Networks.ListAsync();

            listNetworkTask.Wait();

            if (listNetworkTask.Status == TaskStatus.RanToCompletion)
            {
                NetworkListResponse networkList = listNetworkTask.Result;

                foreach (NetworkListResponse.VirtualNetworkSite network in networkList.VirtualNetworkSites)
                {
                    if (network.Name == name)
                    {
                        return network;
                    }
                }
            }

            return null;
        }
    }
}
