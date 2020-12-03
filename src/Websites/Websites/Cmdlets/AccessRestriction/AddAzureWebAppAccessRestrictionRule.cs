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


using Microsoft.Azure.Commands.WebApps.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;
using System;
using Microsoft.Azure.Commands.WebApps.Validations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you get a new Azure Websites using ARM APIs
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppAccessRestrictionRule", DefaultParameterSetName = IpAddressParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSAccessRestrictionConfig))]
    public class AddAzureWebAppAccessRestrictionRuleCmdlet : WebAppBaseClientCmdLet
    {   
        // Parameter sets
        private const string IpAddressParameterSet = "IpAddressParameterSet";
        private const string ServiceTagParameterSet = "ServiceTagParameterSet";
        private const string SubnetNameParameterSet = "SubnetNameParameterSet";
        private const string SubnetIdParameterSet = "SubnetIdParameterSet";

        // Help messages
        private const string ResourceGroupNameHelpMessage = "The name of the resource group.";
        private const string WebAppNameHelpMessage = "The name of the web app.";
        private const string NameHelpMessage = "Access Restriction rule name. E.g.: DeveloperWorkstation.";
        private const string DescriptionHelpMessage = "Access Restriction description.";
        private const string PriorityHelpMessage = "Access Restriction priority. E.g.: 500.";
        private const string ActionHelpMessage = "Allow or Deny rule.";
        private const string SlotNameHelpMessage = "Deployment Slot name.";
        private const string TargetScmSiteHelpMessage = "Rule is aimed for Main site or Scm site.";
        private const string IgnoreMissingServiceEndpointHelpMessage = "Specify if Service Endpoint registration at Subnet should be validated.";
        private const string IpAddressHelpMessage = "Ip Address v4 or v6 CIDR range. E.g.: 192.168.0.0/24 or 2002::1234:abcd:ffff:c0a8:101/64";
        private const string SubnetNameHelpMessage = "Name of Subnet.";
        private const string VirtualNetworkNameHelpMessage = "Name of Virtual Network (must be in same resource group as Web App).";
        private const string SubnetIdHelpMessage = "ResourceId of Subnet.";
        private const string ServiceTagHelpMessage = "Name of Service Tag";
        private const string PassThruHelpMessage = "Return the access restriction config object.";
        private const string HeaderHelpMessage = "Http header restrictions. Example: -HttpHeader @{'x-azure-fdid' = '7acacb02-47ea-4cd4-b568-5e880e72582e'; 'x-forwarded-host' = 'www.contoso.com', 'app.contoso.com'}";

        [Parameter(ParameterSetName = ServiceTagParameterSet, Position = 0, Mandatory = true, HelpMessage = ResourceGroupNameHelpMessage, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = IpAddressParameterSet, Position = 0, Mandatory = true, HelpMessage = ResourceGroupNameHelpMessage, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Position = 0, Mandatory = true, HelpMessage = ResourceGroupNameHelpMessage, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Position = 0, Mandatory = true, HelpMessage = ResourceGroupNameHelpMessage, ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ServiceTagParameterSet, Position = 1, Mandatory = true, HelpMessage = WebAppNameHelpMessage, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = IpAddressParameterSet, Position = 1, Mandatory = true, HelpMessage = WebAppNameHelpMessage, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Position = 1, Mandatory = true, HelpMessage = WebAppNameHelpMessage, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Position = 1, Mandatory = true, HelpMessage = WebAppNameHelpMessage, ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Web/sites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string WebAppName { get; set; }

        [Parameter(ParameterSetName = ServiceTagParameterSet, Mandatory = false, HelpMessage = NameHelpMessage)]
        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = false, HelpMessage = NameHelpMessage)]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = false, HelpMessage = NameHelpMessage)]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = false, HelpMessage = NameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ServiceTagParameterSet, Mandatory = false, HelpMessage = DescriptionHelpMessage)]
        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = false, HelpMessage = DescriptionHelpMessage)]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = false, HelpMessage = DescriptionHelpMessage)]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = false, HelpMessage = DescriptionHelpMessage)]
        public string Description { get; set; }

        [Parameter(ParameterSetName = ServiceTagParameterSet, Mandatory = true, HelpMessage = PriorityHelpMessage)]
        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = true, HelpMessage = PriorityHelpMessage)]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = true, HelpMessage = PriorityHelpMessage)]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = true, HelpMessage = PriorityHelpMessage)]
        [ValidateNotNullOrEmpty]
        public uint Priority { get; set; }

        [Parameter(ParameterSetName = ServiceTagParameterSet, Mandatory = false, HelpMessage = ActionHelpMessage)]
        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = false, HelpMessage = ActionHelpMessage)]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = false, HelpMessage = ActionHelpMessage)]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = false, HelpMessage = ActionHelpMessage)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Allow", "Deny")]
        public string Action { get; set; } = "Allow";

        [Parameter(ParameterSetName = ServiceTagParameterSet, Mandatory = false, HelpMessage = SlotNameHelpMessage)]
        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = false, HelpMessage = SlotNameHelpMessage)]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = false, HelpMessage = SlotNameHelpMessage)]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = false, HelpMessage = SlotNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string SlotName { get; set; }

        [Parameter(ParameterSetName = ServiceTagParameterSet, Mandatory = false, HelpMessage = TargetScmSiteHelpMessage)]
        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = false, HelpMessage = TargetScmSiteHelpMessage)]
        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = false, HelpMessage = TargetScmSiteHelpMessage)]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = false, HelpMessage = TargetScmSiteHelpMessage)]
        [ValidateNotNullOrEmpty]        
        public SwitchParameter TargetScmSite { get; set; }

        [Parameter(ParameterSetName = IpAddressParameterSet, Mandatory = true, HelpMessage = IpAddressHelpMessage)]
        [ValidateIpAddress]
        [ValidateNotNullOrEmpty]
        public string IpAddress { get; set; }

        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = true, HelpMessage = SubnetNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = true, HelpMessage = VirtualNetworkNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = true, HelpMessage = SubnetIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = false, HelpMessage = IgnoreMissingServiceEndpointHelpMessage)]
        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = false, HelpMessage = IgnoreMissingServiceEndpointHelpMessage)]
        public SwitchParameter IgnoreMissingServiceEndpoint { get; set; }

        [Parameter(Mandatory = false, HelpMessage = PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(ParameterSetName = ServiceTagParameterSet, Mandatory = true, HelpMessage = ServiceTagHelpMessage)]
        [ValidateServiceTag]
        [ValidateNotNullOrEmpty]
        public string ServiceTag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HeaderHelpMessage)]
        [ValidateNotNullOrEmpty]
        [ValidateHttpHeader]
        public Hashtable HttpHeader { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(WebAppName))
            {
                var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, SlotName));
                SiteConfig siteConfig = webApp.SiteConfig;
                var accessRestrictionList = TargetScmSite ? siteConfig.ScmIpSecurityRestrictions : siteConfig.IpSecurityRestrictions;
                IpSecurityRestriction ipSecurityRestriction = null;
                IDictionary<string, IList<string>> httpHeader = null;
                if (HttpHeader != null)
                    httpHeader = ConvertHeaderHashtable(HttpHeader);

                int intPriority = checked((int)Priority);
                switch (ParameterSetName)
                {
                    case IpAddressParameterSet:                    
                        ipSecurityRestriction = new IpSecurityRestriction(IpAddress, null, null, null, null, Action, null, intPriority, Name, Description, httpHeader);
                        accessRestrictionList.Add(ipSecurityRestriction);                        
                        break;

                    case ServiceTagParameterSet:
                        ipSecurityRestriction = new IpSecurityRestriction(ServiceTag, null, null, null, null, Action, "ServiceTag", intPriority, Name, Description, httpHeader);
                        accessRestrictionList.Add(ipSecurityRestriction);
                        break;

                    case SubnetNameParameterSet:
                    case SubnetIdParameterSet:
                        var Subnet = ParameterSetName == SubnetNameParameterSet ? SubnetName : SubnetId;
                        //Fetch RG of given SubNet
                        var subNetResourceGroupName = CmdletHelpers.GetSubnetResourceGroupName(DefaultContext, Subnet, VirtualNetworkName);
                        //If unble to fetch SubNet rg from above step, use the input RG to get validation error from api call.
                        subNetResourceGroupName = !String.IsNullOrEmpty(subNetResourceGroupName) ? subNetResourceGroupName : ResourceGroupName;
                        var subnetResourceId = CmdletHelpers.ValidateSubnet(Subnet, VirtualNetworkName, subNetResourceGroupName, DefaultContext.Subscription.Id);
                        if (!IgnoreMissingServiceEndpoint)
                        {
                            CmdletHelpers.VerifySubnetDelegation(subnetResourceId);
                        }
                        
                        ipSecurityRestriction = new IpSecurityRestriction(null, null, subnetResourceId, null, null, Action, null, intPriority, Name, Description, httpHeader);
                        accessRestrictionList.Add(ipSecurityRestriction);                                           
                        break;
                }

                if (ShouldProcess(WebAppName, $"Adding Access Restriction Rule for Web App '{WebAppName}'"))
                {
                    // Update web app configuration
                    WebsitesClient.UpdateWebAppConfiguration(ResourceGroupName, webApp.Location, WebAppName, SlotName, siteConfig);

                    if (PassThru)
                    {
                        // Refresh object to get the final state
                        webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, SlotName));
                        var accessRestrictionSettings = new PSAccessRestrictionConfig(ResourceGroupName, WebAppName, webApp.SiteConfig, SlotName);
                        WriteObject(accessRestrictionSettings);
                    }
                }
            }
        }

        private IDictionary<string, IList<string>> ConvertHeaderHashtable(Hashtable headers)
        {
            IDictionary<string, IList<string>> headerResult = new Dictionary<string, IList<string>>();
            foreach (string key in headers.Keys)
            {
                var value = headers[key];
                if (value is string)
                {
                    var headerValues = new List<string>() { (string)value };
                    headerResult.Add(key, headerValues);
                }
                
                else if (value is object[])
                {
                    var headerValues = new List<string>();
                    foreach (var item in (object[])value)
                    {
                        headerValues.Add(item.ToString());
                    }
                    headerResult.Add(key, headerValues);
                }
            }
            return headerResult;
        }
    }
}
