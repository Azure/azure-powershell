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
	$rgName = "vivga"
	$vmName = "Viv1809SDDC"

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
	$rgName = "vivga"
	$vmName = "Viv1809SDDC"
	$initiativeId = "/providers/Microsoft.Authorization/policySetDefinitions/25ef9b72-4af2-4501-acd1-fc814e73dde1"

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
	$rgName = "vivga"
	$vmName = "Viv1809SDDC"
	$initiativeName = "25ef9b72-4af2-4501-acd1-fc814e73dde1"

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
	$rgName = "vivga"
	$vmName = "Viv1809SDDC"

    $historicalStatuses = Get-AzVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName -ShowOnlyChange
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}