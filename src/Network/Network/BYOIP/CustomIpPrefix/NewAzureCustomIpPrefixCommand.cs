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

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using System.Collections;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CustomIpPrefix", SupportsShouldProcess = true), OutputType(typeof(PSCustomIpPrefix))]
    public class NewAzureCustomIpPrefixCommand : CustomIpPrefixBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The customIpPrefix location.")]
        [LocationCompleter("Microsoft.Network/customIpPrefix")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The customIpPrefix CIDR.")]
        [ValidateNotNullOrEmpty]
        public string Cidr { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The customIpPrefix ASN code.")]
        public string Asn { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The customIpPrefix GEO code.")]
        [ValidateSet(
            MNM.Geo.AFRI,
            MNM.Geo.APAC,
            MNM.Geo.AQ,
            MNM.Geo.EURO,
            MNM.Geo.LATAM,
            MNM.Geo.ME,
            MNM.Geo.NAM,
            MNM.Geo.OCEANIA,
            IgnoreCase = true)]
        public string Geo { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Signed message for WAN validation.",
            ValueFromPipelineByPropertyName = true)]
        public string SignedMessage { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Authorization message for WAN validation.",
            ValueFromPipelineByPropertyName = true)]
        public string AuthorizationMessage { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Using expressRoute advertise.",
            ValueFromPipelineByPropertyName = true)]
        public SwitchParameter ExpressRouteAdvertise { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Parent CustomIpPrefix for Child CustomIpPrefix",
            ValueFromPipelineByPropertyName = true)]
        public PSCustomIpPrefix CustomIpPrefixParent { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Denotes that resource is being created as a Parent CustomIpPrefix")]
        public SwitchParameter IsParent { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A list of availability zones denoting the IP allocated for the resource needs to come from.",
            ValueFromPipelineByPropertyName = true)]
        public string[] Zone { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var resourceExists = IsResourcePresent(() => GetCustomIpPrefix(this.ResourceGroupName, this.Name));

            if (resourceExists)
            {
                throw new System.Exception(string.Format("A CustomIpPrefix with name '{0}' in resource group '{1}' already exists. Please use Set-AzCustomIpPrefix to update an existing CustomIpPrefix.", this.Name, this.ResourceGroupName));
            }

            var psModel = CreateCustomIpPrefix();
            if (psModel != null)
            {
                WriteObject(psModel);
            }
        }

        private PSCustomIpPrefix CreateCustomIpPrefix()
        {
            var psModel = new PSCustomIpPrefix()
            {
                Name = this.Name,
                ResourceGroupName = this.ResourceGroupName,
                Location = this.Location,
                Cidr = this.Cidr,
                Zones = this.Zone?.ToList(),
                SignedMessage = this.SignedMessage,
                AuthorizationMessage = this.AuthorizationMessage,
                CustomIpPrefixParent = this.CustomIpPrefixParent,
                Geo = this.Geo,
                Asn = this.Asn,
                ExpressRouteAdvertise = this.ExpressRouteAdvertise
            };

            if (IsIPv4CIDR())
            {
                if (this.IsParent)
                {
                    psModel.PrefixType = "Parent";
                }
                else if (this.CustomIpPrefixParent != null)
                {
                    psModel.PrefixType = "Child";
                }
            }

            var sdkModel = NetworkResourceManagerProfile.Mapper.Map<MNM.CustomIpPrefix>(psModel);

            sdkModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            if (this.ShouldProcess($"Name: {this.Name} ResourceGroup: {this.ResourceGroupName}", "Create new MasterCustomIpPrefix"))
            {
                this.CustomIpPrefixClient.CreateOrUpdate(this.ResourceGroupName, this.Name, sdkModel);

                var customIpPrefix = this.GetCustomIpPrefix(this.ResourceGroupName, this.Name);

                return customIpPrefix;
            }

            return null;
        }

        private bool IsIPv4CIDR()
        {
            if (this.Cidr != null)
            {
                return Regex.IsMatch(this.Cidr, @"^\d+\.\d+\.\d+\.\d+/\d+$");
            }
            else
            {
                return false;
            }
        }
    }
}