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
	$rgName = "VivsGL"
	$vmName = "VivsGL0"

    $reports = Get-AzureRmVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Initiative id scope
#>
function Get-AzureRmVMGuestPolicyReport-InitiativeIdScope
{
	$rgName = "VivsGL"
	$vmName = "VivsGL0"
	$initiativeId = "/providers/Microsoft.Authorization/policySetDefinitions/3fa7cbf5-c0a4-4a59-85a5-cca4d996d5a6"

    $reports = Get-AzureRmVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -InitiativeId $initiativeId
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy report by Initiative name scope
#>
function Get-AzureRmVMGuestPolicyReport-InitiativeNameScope
{
	$rgName = "VivsGL"
	$vmName = "VivsGL0"
	$initiativeName = "3fa7cbf5-c0a4-4a59-85a5-cca4d996d5a6"

    $reports = Get-AzureRmVMGuestPolicyReport -ResourceGroupName $rgName -VMName $vmName -InitiativeName $initiativeName
	Assert-NotNull $reports
	Assert-True { $reports.Count -gt 0 }
}

<#
.SYNOPSIS
Get guest configuration policy by reportId scope
#>
function Get-AzureRmVMGuestPolicyReport-ReportIdScope
{
	$rgName = "VivsGL"
	$vmName = "VivsGL0"
	$reportId= "/subscriptions/b5e4748c-f69a-467c-8749-e2f9c8cd3db0/resourceGroups/VivsGL/providers/Microsoft.Compute/virtualMachines/VivsGL0/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/PasswordMustMeetComplexityRequirements/reports/7421bae4-60f0-4712-a45f-c9c960ffc75c"

    $report = Get-AzureRmVMGuestPolicyReport -ReportId $reportId
	Assert-NotNull $report
}
