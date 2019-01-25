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
function Get-AzVMGuestPolicyReport-VmNameScope
{
	$rgName = "vivga"
	$vmName = "vivga0"

    $reports = Get-AzVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Initiative id scope
#>
function Get-AzVMGuestPolicyReport-InitiativeIdScope
{
	$rgName = "vivga"
	$vmName = "vivga0"
	$initiativeId = "/providers/Microsoft.Authorization/policySetDefinitions/25ef9b72-4af2-4501-acd1-fc814e73dde1"

    $reports = Get-AzVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -InitiativeId $initiativeId
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Initiative name scope
#>
function Get-AzVMGuestPolicyReport-InitiativeNameScope
{
	$rgName = "vivga"
	$vmName = "vivga0"
	$initiativeName = "25ef9b72-4af2-4501-acd1-fc814e73dde1"

    $reports = Get-AzVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy by reportId scope
#>
function Get-AzVMGuestPolicyReport-ReportIdScope
{
	$rgName = "vivga"
	$vmName = "vivga0"
	$initiativeName = "25ef9b72-4af2-4501-acd1-fc814e73dde1"
	$reports = Get-AzVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }

	$reportId= $reports[0].LatestReportId;

    $report = Get-AzVMGuestPolicyReport -ReportId $reportId
	Assert-NotNull $report
}
