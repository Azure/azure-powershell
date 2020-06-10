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
Get guest configuration policy status history by Vm name scope
#>
function Get-AzVMGuestPolicyStatusHistory-VmNameScope
{
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"

    $historicalStatuses = Get-AzVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy status history by Vm name scope
#>
function Get-AzVMGuestPolicyStatusHistory-VmNameScope_Custom
{
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"

    $historicalStatuses = Get-AzVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy status history by Initiative id scope
#>
function Get-AzVMGuestPolicyStatusHistory-InitiativeIdScope
{
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeId = "/subscriptions/f66367e1-cf7d-407b-ba39-53230cc79071/providers/Microsoft.Authorization/policySetDefinitions/92e09915-8806-493c-baac-4858b0eeea7b"

    $historicalStatuses = Get-AzVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName -InitiativeId $initiativeId
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy status history by Initiative id scope
#>
function Get-AzVMGuestPolicyStatusHistory-InitiativeIdScope_Custom
{
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeId = "/subscriptions/f66367e1-cf7d-407b-ba39-53230cc79071/providers/Microsoft.Authorization/policySetDefinitions/92e09915-8806-493c-baac-4858b0eeea7b"

    $historicalStatuses = Get-AzVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName -InitiativeId $initiativeId
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy status history by Initiative name scope
#>
function Get-AzVMGuestPolicyStatusHistory-InitiativeNameScope
{
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeName = "92e09915-8806-493c-baac-4858b0eeea7b"

    $historicalStatuses = Get-AzVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy status history by Initiative name scope
#>
function Get-AzVMGuestPolicyStatusHistory-InitiativeNameScope_Custom
{
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeName = "92e09915-8806-493c-baac-4858b0eeea7b"

    $historicalStatuses = Get-AzVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy by vmName scope, using ShowOnlyChange switch
#>
function Get-AzVMGuestPolicyStatusHistory-ShowOnlyChangeSwitch-VmNameScope
{
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"

    $historicalStatuses = Get-AzVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName -ShowOnlyChange
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy by vmName scope, using ShowOnlyChange switch
#>
function Get-AzVMGuestPolicyStatusHistory-ShowOnlyChangeSwitch-VmNameScope_Custom
{
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"

    $historicalStatuses = Get-AzVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName -ShowOnlyChange
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}