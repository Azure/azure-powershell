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
function Get-AzureRmVMGuestPolicyStatusHistory-VmNameScope
{
	$rgName = "VivsGL"
	$vmName = "VivsGL0"

    $historicalStatuses = Get-AzureRmVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy status history by Initiative id scope
#>
function Get-AzureRmVMGuestPolicyStatusHistory-InitiativeIdScope
{
	$rgName = "VivsGL"
	$vmName = "VivsGL0"
	$initiativeId = "/providers/Microsoft.Authorization/policySetDefinitions/3fa7cbf5-c0a4-4a59-85a5-cca4d996d5a6"

    $historicalStatuses = Get-AzureRmVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName -InitiativeId $initiativeId
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy status history by Initiative name scope
#>
function Get-AzureRmVMGuestPolicyStatusHistory-InitiativeNameScope
{
	$rgName = "VivsGL"
	$vmName = "VivsGL0"
	$initiativeName = "3fa7cbf5-c0a4-4a59-85a5-cca4d996d5a6"

    $historicalStatuses = Get-AzureRmVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy by vmName scope, using ShowOnlyChange switch
#>
function Get-AzureRmVMGuestPolicyStatusHistory-ShowOnlyChangeSwitch-VmNameScope
{
	$rgName = "VivsGL"
	$vmName = "VivsGL0"

    $historicalStatuses = Get-AzureRmVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName -ShowOnlyChange
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}