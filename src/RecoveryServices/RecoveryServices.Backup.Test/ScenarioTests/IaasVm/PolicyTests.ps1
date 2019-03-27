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

$resourceGroupName = "RecoveryServicesBackupTestRg";
$resourceName = "PsTestRsVault";
$policyName = "PsTestPolicy";
$DefaultSnapshotDays = 2;
$UpdatedSnapShotDays = 5;

function Test-AzureVMPolicy
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		
		# Get default policy objects
		$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureVM
		Assert-NotNull $schedulePolicy
		$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureVM
		Assert-NotNull $retentionPolicy

		# Create policy
		$policyName = "newPolicy"
		$policy = New-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName `
			-WorkloadType AzureVM `
			-RetentionPolicy $retentionPolicy `
			-SchedulePolicy $schedulePolicy
		Assert-NotNull $policy
		Assert-AreEqual $policy.Name $policyName
		Assert-AreEqual $policy.SnapshotRetentionInDays $DefaultSnapshotDays

		# Get policy
	    $policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName
		Assert-NotNull $policy
		Assert-AreEqual $policy.Name $policyName

		# Get default policy objects (this data is generated partially at random. So, running this again gives different values)
		$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureVM
		Assert-NotNull $schedulePolicy
		$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureVM
		Assert-NotNull $retentionPolicy

		#update snapshot days
		$policy.SnapshotRetentionInDays = $UpdatedSnapShotDays;

		# Update policy
		Set-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-RetentionPolicy $retentionPolicy `
			-SchedulePolicy $schedulePolicy `
			-Policy $policy

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName
		Assert-AreEqual $policy.SnapshotRetentionInDays $UpdatedSnapShotDays

		# Delete policy
		Remove-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Policy $policy `
			-Force
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}