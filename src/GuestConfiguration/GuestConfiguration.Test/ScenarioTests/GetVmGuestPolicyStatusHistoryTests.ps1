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
<<<<<<< HEAD
	$rgName = "aashishGoodPolicy"
	$vmName = "aashishvm1"
=======
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
	$rgName = "aashishCustomrole7ux"
	$vmName = "aashishCustomrole7ux"
=======
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
	$rgName = "aashishGoodPolicy"
	$vmName = "aashishvm1"
	$initiativeId = "/providers/Microsoft.Authorization/policySetDefinitions/8bc55e6b-e9d5-4266-8dac-f688d151ec9c"
=======
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeId = "/subscriptions/f66367e1-cf7d-407b-ba39-53230cc79071/providers/Microsoft.Authorization/policySetDefinitions/92e09915-8806-493c-baac-4858b0eeea7b"
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
	$rgName = "aashishCustomrole7ux"
	$vmName = "aashishCustomrole7ux"
	$initiativeId = "/subscriptions/b5e4748c-f69a-467c-8749-e2f9c8cd3db0/providers/Microsoft.Authorization/policySetDefinitions/60062d3c-3282-4a3d-9bc4-3557dded22ca"
=======
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeId = "/subscriptions/f66367e1-cf7d-407b-ba39-53230cc79071/providers/Microsoft.Authorization/policySetDefinitions/92e09915-8806-493c-baac-4858b0eeea7b"
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
	$rgName = "aashishGoodPolicy"
	$vmName = "aashishvm1"
	$initiativeName = "8bc55e6b-e9d5-4266-8dac-f688d151ec9c"
=======
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeName = "92e09915-8806-493c-baac-4858b0eeea7b"
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
	$rgName = "aashishCustomrole7ux"
	$vmName = "aashishCustomrole7ux"
	$initiativeName = "60062d3c-3282-4a3d-9bc4-3557dded22ca"
=======
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
	$initiativeName = "92e09915-8806-493c-baac-4858b0eeea7b"
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
	$rgName = "aashishGoodPolicy"
	$vmName = "aashishvm1"
=======
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
	$rgName = "aashishCustomrole7ux"
	$vmName = "aashishCustomrole7ux"
=======
	$rgName = "PolicyE2ETest_58_20_10_06-08-2020"
	$vmName = "pol-2016corsml"
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

    $historicalStatuses = Get-AzVMGuestPolicyStatusHistory -ResourceGroupName $rgName -VMName $vmName -ShowOnlyChange
	Assert-NotNull $historicalStatuses
	Assert-True { $historicalStatuses.Count -gt 0 }
}