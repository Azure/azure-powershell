# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Test creating new Inbound Security Rule
#>
function Test-InboundSecurityRule
{
    $rgname = "AshuSneaky"

    # The commands are not supported in all regions yet.
    $location = "eastus2euap"
    $nvaname = "sneaky4"
    $applieson = "slbip"
    $rulecollectionname = "PermanentRuleCollection"
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliances/inboundSecurityRules"
    $rulename1 = "InboundRule1"
    $protocol = "TCP"
    $sourceaddressprefix = "*"
    $destinationportranges = "80-120","121-124"
    $ruletype = "Permanent"
    try{
        $rule = New-AzVirtualApplianceInboundSecurityRulesProperty -Name $rulename1 -Protocol $protocol -SourceAddressPrefix $sourceaddressprefix -DestinationPortRangeList $destinationportranges -AppliesOn $applieson
        Assert-NotNull $rule

        $updateresult = Update-AzVirtualApplianceInboundSecurityRule -ResourceGroupName $rgname -VirtualApplianceName $nvaname -Name $rulecollectionname -RuleType $ruletype -Rule $rule
        Assert-True { $updateresult }
   	}   
    finally{
        
	}
}


