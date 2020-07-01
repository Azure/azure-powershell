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
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"

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
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"

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
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeId = "/subscriptions/f66367e1-cf7d-407b-ba39-53230cc79071/providers/Microsoft.Authorization/policySetDefinitions/92e09915-8806-493c-baac-4858b0eeea7b"

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
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeId = "/subscriptions/f66367e1-cf7d-407b-ba39-53230cc79071/providers/Microsoft.Authorization/policySetDefinitions/92e09915-8806-493c-baac-4858b0eeea7b"

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
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeName = "92e09915-8806-493c-baac-4858b0eeea7b"

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
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeName = "92e09915-8806-493c-baac-4858b0eeea7b"

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
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeName = "92e09915-8806-493c-baac-4858b0eeea7b"
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
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeName = "92e09915-8806-493c-baac-4858b0eeea7b"
	$reports = Get-AzVMGuestPolicyStatus -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }

	$Id= $reports[0].ReportId;

    $report = Get-AzVMGuestPolicyStatus -ReportId $Id
	Assert-NotNull $report
}
