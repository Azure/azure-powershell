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
Get guest configuration policy report by Vm name scope
#>
function Get-AzureRmVMGuestPolicyReport-VmNameScope
{
	$rgName = "VivsCmdlet"
	$vmName = "VivsCmdlet0"

    $reports = Get-AzureRmVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Vm name scope, detailed
#>
function Get-AzureRmVMGuestPolicyReport-VmNameScope-Detailed
{
	$rgName = "VivsCmdlet"
	$vmName = "VivsCmdlet0"

    $reports = Get-AzureRmVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -Detailed
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Vm name scope, detailed and latest
#>
function Get-AzureRmVMGuestPolicyReport-VmNameScope-Detailed-Latest
{
	$rgName = "VivsCmdlet"
	$vmName = "VivsCmdlet0"

    $reports = Get-AzureRmVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -Detailed -Latest
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Initiative id scope
#>
function Get-AzureRmVMGuestPolicyReport-InitiativeIdScope
{
	$rgName = "VivsCmdlet"
	$vmName = "VivsCmdlet0"
	$initiativeId = "/providers/Microsoft.Authorization/policySetDefinitions/3fa7cbf5-c0a4-4a59-85a5-cca4d996d5a6"

    $reports = Get-AzureRmVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -InitiativeId $initiativeId
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Initiative id scope, detailed
#>
function Get-AzureRmVMGuestPolicyReport-InitiativeIdScope-Detailed
{
	$rgName = "VivsCmdlet"
	$vmName = "VivsCmdlet0"
	$initiativeId = "/providers/Microsoft.Authorization/policySetDefinitions/3fa7cbf5-c0a4-4a59-85a5-cca4d996d5a6"

    $reports = Get-AzureRmVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -InitiativeId $initiativeId -Detailed
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Initiative id scope, detailed and latest
#>
function Get-AzureRmVMGuestPolicyReport-InitiativeIdScope-Detailed-Latest
{
	$rgName = "VivsCmdlet"
	$vmName = "VivsCmdlet0"
	$initiativeId = "/providers/Microsoft.Authorization/policySetDefinitions/3fa7cbf5-c0a4-4a59-85a5-cca4d996d5a6"

    $reports = Get-AzureRmVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -InitiativeId $initiativeId -Detailed -Latest
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Initiative id scope
#>
function Get-AzureRmVMGuestPolicyReport-InitiativeNameScope
{
	$rgName = "VivsCmdlet"
	$vmName = "VivsCmdlet0"
	$initiativeName = "3fa7cbf5-c0a4-4a59-85a5-cca4d996d5a6"

    $reports = Get-AzureRmVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Initiative id scope, detailed
#>
function Get-AzureRmVMGuestPolicyReport-InitiativeNameScope-Detailed
{
	$rgName = "VivsCmdlet"
	$vmName = "VivsCmdlet0"
	$initiativeName = "3fa7cbf5-c0a4-4a59-85a5-cca4d996d5a6"

    $reports = Get-AzureRmVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName -Detailed
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Initiative id scope, detailed and latest
#>
function Get-AzureRmVMGuestPolicyReport-InitiativeNameScope-Detailed-Latest
{
	$rgName = "VivsCmdlet"
	$vmName = "VivsCmdlet0"
	$initiativeName = "3fa7cbf5-c0a4-4a59-85a5-cca4d996d5a6"

    $reports = Get-AzureRmVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName -Detailed -Latest
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}