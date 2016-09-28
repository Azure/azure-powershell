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

$resourceGroupName = "labRG1";
$resourceName = "pstestrsvault";
$policyName = "pwtest1";

function Test-PolicyScenario
{
	# 1. Create / update and get vault
    $vaultLocation = get_available_location;
	$vault = New-AzureRmRecoveryServicesVault `
		-Name $resourceName -ResourceGroupName $resourceGroupName -Location $vaultLocation;
	
	# 2. Set vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	# get default objects
	$schedulePolicy = Get-AzureRmRecoveryServicesBackupSchedulePolicyObject -WorkloadType "AzureVM"
	Assert-NotNull $schedulePolicy
	$retPolicy = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType "AzureVM"
	Assert-NotNull $retPolicy

	# now create new policy
	$policy = New-AzureRmRecoveryServicesBackupProtectionPolicy `
		-Name $policyName `
		-WorkloadType "AzureVM" `
		-RetentionPolicy $retPolicy `
		-SchedulePolicy $schedulePolicy
	Assert-NotNull $policy
	Assert-AreEqual $policy.Name $policyName
		
	# now get policy and update it with new schedule/retention
	$schedulePolicy = Get-AzureRmRecoveryServicesBackupSchedulePolicyObject -WorkloadType "AzureVM"
	Assert-NotNull $schedulePolicy
	$retPolicy = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType "AzureVM"
	Assert-NotNull $retPolicy

    $temp = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name $policyName	
	Assert-NotNull $temp
	Assert-AreEqual $temp.Name $policyName

	Set-AzureRmRecoveryServicesBackupProtectionPolicy `
		-RetentionPolicy $retPolicy -SchedulePolicy $schedulePolicy -Policy $temp	

	#cleanup 
	Remove-AzureRmRecoveryServicesBackupProtectionPolicy -Policy $temp -Force
}