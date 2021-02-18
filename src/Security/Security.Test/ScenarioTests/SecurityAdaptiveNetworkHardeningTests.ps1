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
Gets a list of Adaptive Network Hardenings resources in scope of an extended resource.
#>
function Get-AzSecurityAdaptiveNetworkHardening-ResourceGroupLevelResource
{
    $anh = Get-AzSecurityAdaptiveNetworkHardening -ResourceGroupName MSI-GLStandard_A1 -ResourceName MSI-22122 -ResourceNamespace Microsoft.Compute -ResourceType virtualMachines -SubscriptionId 3eeab341-f466-499c-a8be-85427e154baf
	Validate-SecurityAdaptiveNetworkHardeningsList $anh
}

<#
.SYNOPSIS
Gets a single Adaptive Network Hardening resource
#>
function Get-AzSecurityAdaptiveNetworkHardening-ResourceGroupLevelResource
{
	$anh = Get-AzSecurityAdaptiveNetworkHardening -AdaptiveNetworkHardeningResourceName default -ResourceGroupName MSI-GLStandard_A1 -ResourceName MSI-22122 -ResourceNamespace Microsoft.Compute -ResourceType virtualMachines -SubscriptionId 3eeab341-f466-499c-a8be-85427e154baf
	Validate-SecurityAdaptiveNetworkHardenings $anh
}

<#
.SYNOPSIS
Enforces the given rules on the NSG(s) listed in the request
#>
function Add-AzSecurityAdaptiveNetworkHardening-ResourceGroupLevelResource
{
	$anh = Get-AzSecurityAdaptiveNetworkHardening -AdaptiveNetworkHardeningResourceName default -ResourceGroupName MSI-GLStandard_A1 -ResourceName MSI-22122 -ResourceNamespace Microsoft.Compute -ResourceType virtualMachines -SubscriptionId 3eeab341-f466-499c-a8be-85427e154baf
	
	Assert-True { Add-AzSecurityAdaptiveNetworkHardening -AdaptiveNetworkHardeningResourceName default -ResourceGroupName MSI-GLStandard_A1 -ResourceName MSI-22122 -ResourceNamespace Microsoft.Compute -ResourceType virtualMachines -SubscriptionId 3eeab341-f466-499c-a8be-85427e154baf -Rules $anh.Properties.Rules -NetworkSecurityGroups $anh.Properties.EffectiveNetworkSecurityGroups[0].NetworkSecurityGroups -PassThru }
}

<#
.SYNOPSIS
Validates a list of Adaptive Network Hardenings
#>
function Validate-SecurityAdaptiveNetworkHardeningsList
{
	param($SecurityTopologies)

    Assert-True { $securityTopologies.Count -gt 0 }

	Foreach($SecurityTopologies in $securityTopologies)
	{
		Validate-SecurityAdaptiveNetworkHardenings $SecurityTopologies
	}
}

<#
.SYNOPSIS
Validates a single Adaptive Network Hardenings
#>
function Validate-SecurityAdaptiveNetworkHardenings
{
	param($SecurityTopologies)

	Assert-NotNull $SecurityTopologies
}