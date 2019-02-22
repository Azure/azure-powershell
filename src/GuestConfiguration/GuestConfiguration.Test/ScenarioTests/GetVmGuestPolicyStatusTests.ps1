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
function Get-AzVMGuestPolicyStatus-VmNameScope
{
	$rgName = "vivga"
	$vmName = "Viv1809SDDC"

    $reports = Get-AzVMGuestPolicyStatus -ResourceGroupName $rgName -VMName $vmName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Vm name scope for custom policy
#>
function Get-AzVMGuestPolicyStatus-VmNameScope_Custom
{
	$rgName = "amits-test"
	$vmName = "amits-winser6"

    $reports = Get-AzVMGuestPolicyStatus -ResourceGroupName $rgName -VMName $vmName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Initiative id scope
#>
function Get-AzVMGuestPolicyStatus-InitiativeIdScope
{
	$rgName = "vivga"
	$vmName = "Viv1809SDDC"
	$initiativeId = "/providers/Microsoft.Authorization/policySetDefinitions/25ef9b72-4af2-4501-acd1-fc814e73dde1"

    $reports = Get-AzVMGuestPolicyStatus -ResourceGroupName $rgName -VMName $vmName -InitiativeId $initiativeId
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration custom policy report by Initiative id scope
#>
function Get-AzVMGuestPolicyStatus-InitiativeIdScope_Custom
{
	$rgName = "amits-test"
	$vmName = "amits-winser6"
	$initiativeId = "/subscriptions/b5e4748c-f69a-467c-8749-e2f9c8cd3db0/providers/Microsoft.Authorization/policySetDefinitions/8174929b-2752-46af-9167-89d2d6780439"

    $reports = Get-AzVMGuestPolicyStatus -ResourceGroupName $rgName -VMName $vmName -InitiativeId $initiativeId
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Initiative name scope
#>
function Get-AzVMGuestPolicyStatus-InitiativeNameScope
{
	$rgName = "vivga"
	$vmName = "Viv1809SDDC"
	$initiativeName = "25ef9b72-4af2-4501-acd1-fc814e73dde1"

    $reports = Get-AzVMGuestPolicyStatus -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration custom policy report by Initiative name scope
#>
function Get-AzVMGuestPolicyStatus-InitiativeNameScope_Custom
{
	$rgName = "amits-test"
	$vmName = "amits-winser6"
	$initiativeName = "8174929b-2752-46af-9167-89d2d6780439"

    $reports = Get-AzVMGuestPolicyStatus -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy by ReportId scope
#>
function Get-AzVMGuestPolicyStatus-ReportIdScope
{
	$rgName = "vivga"
	$vmName = "Viv1809SDDC"
	$initiativeName = "25ef9b72-4af2-4501-acd1-fc814e73dde1"
	$reports = Get-AzVMGuestPolicyStatus -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }

	$Id= $reports[0].ReportId;

    $report = Get-AzVMGuestPolicyStatus -ReportId $Id
	Assert-NotNull $report
}

<#
.SYNOPSIS
Get guest configuration custom policy by ReportId scope
#>
function Get-AzVMGuestPolicyStatus-ReportIdScope_Custom
{
	$rgName = "amits-test"
	$vmName = "amits-winser6"
	$initiativeName = "8174929b-2752-46af-9167-89d2d6780439"
	$reports = Get-AzVMGuestPolicyStatus -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }

	$Id= $reports[0].ReportId;

    $report = Get-AzVMGuestPolicyStatus -ReportId $Id
	Assert-NotNull $report
}
