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

#Setup Instructions:
#1. Create a resource group
#2. Create a storage account and a recovery services vault
#3. Create a file share in the storage account
#4. Fill the below global variables accordingly

$location = "westus"
$resourceGroupName = "sisi-RSV"
$vaultName = "sisi-RSV-29-6"
$fileShareName = "pstestfileshare"
$fileShareFullName = "AzureFileShare;pstestfileshare"
$saName = "pstestsaa"

function Test-AzureFilePolicy
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
	# Get default policy objects
	$schedulePolicy = Get-AzureRmRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles
	Assert-NotNull $schedulePolicy
	$retentionPolicy = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureFiles
	Assert-NotNull $retentionPolicy

	# Create policy
	$policyName = "newFilePolicy"
	$policy = New-AzureRmRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name $policyName `
		-WorkloadType AzureFiles `
		-RetentionPolicy $retentionPolicy `
		-SchedulePolicy $schedulePolicy
	Assert-NotNull $policy
	Assert-AreEqual $policy.Name $policyName

	# Get policy
	$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name $policyName
	Assert-NotNull $policy
	Assert-AreEqual $policy.Name $policyName

	# Get default policy objects (this data is generated partially at random. So, running this again gives different values)
	$schedulePolicy = Get-AzureRmRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles
	Assert-NotNull $schedulePolicy
	$retentionPolicy = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureFiles
	Assert-NotNull $retentionPolicy

	# Update policy
	Set-AzureRmRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-RetentionPolicy $retentionPolicy `
		-SchedulePolicy $schedulePolicy `
		-Policy $policy

	# Delete policy
	Remove-AzureRmRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Policy $policy `
		-Force
}