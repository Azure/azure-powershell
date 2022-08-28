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
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.NetworkruleSet
{
    /// <summary>
    /// 'Set-AzEventHubNamespace' Cmdlet updates the specified Eventhub Namespace
    /// </summary>
    [GenericBreakingChange(message: BreakingChangeNotification + "\n- Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.INetworkRuleSet'", deprecateByVersion: DeprecateByVersion, changeInEfectByDate: ChangeInEffectByDate)]
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubNetworkRuleSet", SupportsShouldProcess = true, DefaultParameterSetName = NetwrokruleSetPropertiesParameterSet), OutputType(typeof(PSNetworkRuleSetAttributes))]
    public class SetAzureEventHubNetworkrule : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NetwrokruleSetInputObjectParameterSet,  Position = 0, HelpMessage = "Resource Group Name.")]
        [Parameter(Mandatory = true, ParameterSetName = NetwrokruleSetPropertiesParameterSet,  Position = 0, HelpMessage = "Resource Group Name.")]
        [Parameter(Mandatory = true, ParameterSetName = NetworkRuleSetResourceIdParameterSet,  Position = 0, HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NetwrokruleSetInputObjectParameterSet,  Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [Parameter(Mandatory = true, ParameterSetName = NetwrokruleSetPropertiesParameterSet,  Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [Parameter(Mandatory = true, ParameterSetName = NetworkRuleSetResourceIdParameterSet,  Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Name { get; set; }       

        [Parameter(Mandatory = false, ParameterSetName = NetwrokruleSetPropertiesParameterSet,   HelpMessage = "Default Action for NetworkRuleSet")]
        [PSArgumentCompleter("Allow", "Deny")]
        [PSDefaultValue(Value ="Deny")]
        public string DefaultAction { get; set; }
        
        [Parameter(Mandatory = false, ParameterSetName = NetwrokruleSetPropertiesParameterSet, HelpMessage = "Indicates whether TrustedServiceAccessEnabled is enabled")]
        public SwitchParameter TrustedServiceAccessEnabled { get; set; }

        [CmdletParameterBreakingChange("IPRule", OldParamaterType = typeof(PSNWRuleSetIpRulesAttributes[]), NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.INwRuleSetIPRules[]")]
        [Parameter(Mandatory = false, ParameterSetName = NetwrokruleSetPropertiesParameterSet,  Position = 2, HelpMessage = "List of IPRuleSet")]
        [ValidateNotNullOrEmpty]
        public PSNWRuleSetIpRulesAttributes[] IPRule { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NetwrokruleSetPropertiesParameterSet, HelpMessage = "Public Network Access for NetwrokeuleSet")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        [PSDefaultValue(Value = "Enabled")]
        public string PublicNetworkAccess { get; set; }

        [CmdletParameterBreakingChange("VirtualNetworkRule", OldParamaterType = typeof(PSNWRuleSetVirtualNetworkRulesAttributes[]), NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.INwRuleSetVirtualNetworkRules[]")]
        [Parameter(Mandatory = false, ParameterSetName = NetwrokruleSetPropertiesParameterSet,  Position = 3, HelpMessage = "List of VirtualNetworkRules")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasVirtualNetworkRule)]
        public PSNWRuleSetVirtualNetworkRulesAttributes[] VirtualNetworkRule { get; set; }

        [CmdletParameterBreakingChange("InputObject", OldParamaterType = typeof(PSNetworkRuleSetAttributes), NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.INetworkRuleSet", ChangeDescription = NetwrokruleSetInputObjectParameterSet + " parameter set is changing. Please refer the migration guide for examples.")]
        [Parameter(Mandatory = true, ParameterSetName = NetwrokruleSetInputObjectParameterSet, ValueFromPipeline = true, Position = 2, HelpMessage = "NetworkruleSet Configuration Object")]
        [ValidateNotNullOrEmpty]
        public PSNetworkRuleSetAttributes InputObject { get; set; }

        [CmdletParameterBreakingChange("ResourceId", ReplaceMentCmdletParameterName = "InputObject")]
        [Parameter(Mandatory = true, ParameterSetName = NetworkRuleSetResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Resource ID of Namespace")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }


        public override void ExecuteCmdlet()
        {
            // Update the NetworlruleSet 
            
            if (ShouldProcess(target: Name, action: string.Format("Update NetworkruleSet for {0} Namespace in {1} ResourceGroup", Name, ResourceGroupName)))
            {
                try
                {
                    if (ParameterSetName.Equals(NetwrokruleSetPropertiesParameterSet))
                    {
                        bool? trustedServiceAccessEnabled = null;
                            
                        if(this.IsParameterBound(c => c.TrustedServiceAccessEnabled) == true)
                        {
                            trustedServiceAccessEnabled = TrustedServiceAccessEnabled.IsPresent;
                        }

                        WriteObject(UtilityClient.UpdateNetworkRuleSet(resourceGroupName: ResourceGroupName,
                                                                namespaceName: Name,
                                                                publicNetworkAccess: PublicNetworkAccess,
                                                                trustedServiceAccessEnabled: trustedServiceAccessEnabled,
                                                                defaultAction: DefaultAction,
                                                                iPRule: IPRule,
                                                                virtualNetworkRule: VirtualNetworkRule));
                    }

                    if (ParameterSetName.Equals(NetwrokruleSetInputObjectParameterSet))
                    {
                        WriteObject(UtilityClient.CreateOrUpdateNetworkRuleSet(ResourceGroupName, Name, InputObject));
                    }

                    if (ParameterSetName.Equals("NetworkRuleSetResourceIdParameterSet"))
                    {
                        ResourceIdentifier getParamGeoDR = GetResourceDetailsFromId(ResourceId);

                        PSNetworkRuleSetAttributes getNWRuleSet = UtilityClient.GetNetworkRuleSet(getParamGeoDR.ResourceGroupName, getParamGeoDR.ParentResource);

                        if (ResourceGroupName != null && getParamGeoDR.ResourceName != null)
                        {
                            if (ShouldProcess(target: Name, action: string.Format("updating NetwrokruleSet", Name, ResourceGroupName)))
                            {
                                WriteObject(UtilityClient.CreateOrUpdateNetworkRuleSet(ResourceGroupName, Name, getNWRuleSet));
                            }
                        }
                    }
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }
        }
    }
}
