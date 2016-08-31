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
$defaultPolicyName = "DefaultPolicy";
# Create VM instead of taking these as parameters
$vmResourceGroupName = "arpittestresourcegroup";
$vmName = "arpittestencvm1";
$vmStorageAccountName = "mkheranirmrestore";
$vmStorageAccountResourceGroup = "mkheranirmrestore";
$vmUniqueName = "iaasvmcontainerv2;" + $vmResourceGroupName + ";" + $vmName;

function Test-GetItemScenario
{
	# 1. Create / update and get vault
    $vaultLocation = get_available_location;
	$vault = New-AzureRmRecoveryServicesVault `
		-Name $resourceName -ResourceGroupName $resourceGroupName -Location $vaultLocation;
	
	# 2. Set vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	# 3. Get container
	$global:container = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType AzureVM `
		-Name $vmName `
		-ResourceGroupName $vmResourceGroupName `
		-Status Registered;

	# 4. If not already protected, enable protection
	if ($global:container -eq $null)
	{
		# 4.1 Get default policy
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name $defaultPolicyName;
	
		Enable-AzureRmRecoveryServicesBackupProtection `
			-Policy $policy -Name $vmName -ResourceGroupName $vmResourceGroupName;

		$global:container = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Name $vmName `
			-ResourceGroupName $vmResourceGroupName `
			-Status Registered;
	}

	$protectionState = if ($global:container -eq $null) { "IRPending" } else { "Protected" };
	
	# VAR-1: Get all items for container
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $global:container -WorkloadType "AzureVM";
	Assert-AreEqual $item.Name $vmUniqueName;

	# VAR-2: Get items for container with friendly name filter
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $global:container -WorkloadType "AzureVM" -Name $vmName;
	Assert-AreEqual $item.Name $vmUniqueName;

	# VAR-3: Get items for container with ProtectionStatus filter
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $global:container -WorkloadType "AzureVM" -ProtectionStatus "Healthy";
	Assert-AreEqual $item.Name $vmUniqueName;

	# VAR-4: Get items for container with Status filter
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $global:container -WorkloadType "AzureVM" -ProtectionState $protectionState;
	Assert-AreEqual $item.Name $vmUniqueName;

	# VAR-5: Get items for container with friendly name and ProtectionStatus filters
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $global:container `
		-WorkloadType "AzureVM" `
		-Name $vmName `
		-ProtectionStatus "Healthy";
	Assert-AreEqual $item.Name $vmUniqueName;

	# VAR-6: Get items for container with friendly name and Status filters
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $global:container `
		-WorkloadType "AzureVM" `
		-Name $vmName `
		-ProtectionState $protectionState;
	Assert-AreEqual $item.Name $vmUniqueName;

	# VAR-7: Get items for container with Status and ProtectionStatus filters
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $global:container `
		-WorkloadType "AzureVM" `
		-ProtectionState $protectionState `
		-ProtectionStatus "Healthy";
	Assert-AreEqual $item.Name $vmUniqueName;

	# VAR-8: Get items for container with friendly name, Status and ProtectionStatus filters
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $global:container `
		-WorkloadType "AzureVM" `
		-Name $vmName `
		-ProtectionState $protectionState `
		-ProtectionStatus "Healthy";
	Assert-AreEqual $item.Name $vmUniqueName;
}

function Test-EnableAzureVMProtectionScenario
{
	# 1. Create / update and get vault
    $vaultLocation = get_available_location;
	$vault = New-AzureRmRecoveryServicesVault `
		-Name $resourceName -ResourceGroupName $resourceGroupName -Location $vaultLocation;
	
	# 2. Set vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	# 3. Get container
	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType AzureVM `
		-Name $vmName `
		-ResourceGroupName $vmResourceGroupName `
		-Status Registered;

	# 4. If already protected, disable protection
	if (-Not ($container -eq $null))
	{
		# 4.1 Get item
		$item = Get-AzureRmRecoveryServicesBackupItem -Container $container -WorkloadType AzureVM;

		# 4.2 Disable protection
		Disable-AzureRmRecoveryServicesBackupProtection -Item $item -RemoveRecoveryPoints -Force;
	}

	# 5. Get default policy
	$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name $defaultPolicyName;
	
	# ACTION: Enable protection
	Enable-AzureRmRecoveryServicesBackupProtection `
		-Policy $policy -Name $vmName -ResourceGroupName $vmResourceGroupName;
}

function Test-DisableAzureVMProtectionScenario
{
	# 1. Create / update and get vault
    $vaultLocation = get_available_location;
	$vault = New-AzureRmRecoveryServicesVault `
		-Name $resourceName -ResourceGroupName $resourceGroupName -Location $vaultLocation;
	
	# 2. Set vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	# 3. Get container
	$global:container = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType AzureVM `
		-Name $vmName `
		-ResourceGroupName $vmResourceGroupName `
		-Status Registered;

	# 4. If not already protected, enable protection
	if ($global:container -eq $null)
	{
		# 4.1 Get default policy
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name $defaultPolicyName;
	
		Enable-AzureRmRecoveryServicesBackupProtection `
			-Policy $policy -Name $vmName -ResourceGroupName $vmResourceGroupName;

		$global:container = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Name $vmName `
			-ResourceGroupName $vmResourceGroupName `
			-Status Registered;
	}

	# 5. Get item
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $global:container -WorkloadType AzureVM;

	# ACTION: Disable protection
	Disable-AzureRmRecoveryServicesBackupProtection -Item $item -RemoveRecoveryPoints -Force;
}

function Test-GetAzureVMRecoveryPointsScenario
{
	# 1. Create / update and get vault
    $vaultLocation = get_available_location;
    $vault = New-AzureRmRecoveryServicesVault `
		-Name $resourceName -ResourceGroupName $resourceGroupName -Location $vaultLocation;
	
	# 2. Set vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	# 3. Get container
	$global:container = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType AzureVM `
		-Name $vmName `
		-ResourceGroupName $vmResourceGroupName `
		-Status Registered;

	# 4. If not already protected, enable protection
	if ($global:container -eq $null)
	{
		# 4.1 Get default policy
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name $defaultPolicyName;
	
		Enable-AzureRmRecoveryServicesBackupProtection `
			-Policy $policy -Name $vmName -ResourceGroupName $vmResourceGroupName;

		$global:container = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Name $vmName `
			-ResourceGroupName $vmResourceGroupName `
			-Status Registered;
	}
	
	# 5. Get item
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $global:container -WorkloadType AzureVM;
	
	# 6. Trigger backup and wait for completion
	$fixedExpiryDate = Get-Date;
	$expiryDate = $fixedExpiryDate.AddDays(2).ToUniversalTime();
    $backupJob = Backup-AzureRmRecoveryServicesBackupItem `
		-Item $item -ExpiryDateTimeUTC $expiryDate;
	$backupJob = Wait-AzureRmRecoveryServicesBackupJob -Job $backupJob;
	
	# ACTION: Get latest recovery point; should be only one
	$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
	$backupEndTime = $backupJob.EndTime.AddMinutes(1);
	$recoveryPoint = Get-AzureRmRecoveryServicesBackupRecoveryPoint `
		-StartDate $backupStartTime -EndDate $backupEndTime -Item $item;
	
	Assert-NotNull $recoveryPoint;
	Assert-True { $recoveryPoint.ContainerName -match $vmUniqueName };

	#Action get Recovery point detail
	$recoveryPointDetail = Get-AzureRmRecoveryServicesBackupRecoveryPoint `
		-RecoveryPointId $recoveryPoint[0].RecoveryPointId -Item $item;
	
	Assert-NotNull $recoveryPointDetail;
	

}

function Test-RestoreAzureVMRItemScenario
{
	# 1. Create / update and get vault
    $vaultLocation = get_available_location;
	$vault = New-AzureRmRecoveryServicesVault `
		-Name $resourceName -ResourceGroupName $resourceGroupName -Location $vaultLocation;
	
	# 2. Set vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	# 3. Get container
	$global:container = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType AzureVM `
		-Name $vmName `
		-ResourceGroupName $vmResourceGroupName `
		-Status Registered;

	# 4. If not already protected, enable protection
	if ($global:container -eq $null)
	{
		# 4.1 Get default policy
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name $defaultPolicyName;
	
		Enable-AzureRmRecoveryServicesBackupProtection `
			-Policy $policy -Name $vmName -ResourceGroupName $vmResourceGroupName;

		$global:container = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Name $vmName `
			-ResourceGroupName $vmResourceGroupName `
			-Status Registered;
	}
	
	# 5. Get item
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $global:container -WorkloadType AzureVM;
	
	# 6. Trigger backup and wait for completion
	$fixedExpiryDate = Get-Date;
	$expiryDate = $fixedExpiryDate.AddDays(2).ToUniversalTime();
    $backupJob = Backup-AzureRmRecoveryServicesBackupItem `
		-Item $item -ExpiryDateTimeUTC $expiryDate;
	$backupJob = Wait-AzureRmRecoveryServicesBackupJob -Job $backupJob;
	
	# 7. Get latest recovery point
	$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
	$backupEndTime = $backupJob.EndTime.Value.AddMinutes(1);
	$recoveryPoint = Get-AzureRmRecoveryServicesBackupRecoveryPoint `
		-StartDate $backupStartTime -EndDate $backupEndTime -Item $item

	# ACTION: Trigger restore and wait for completion
	$restoreJob = Restore-AzureRMRecoveryServicesBackupItem `
		-RecoveryPoint $recoveryPoint `
		-StorageAccountName $vmStorageAccountName `
		-StorageAccountResourceGroupName $vmStorageAccountResourceGroup
	Wait-AzureRmRecoveryServicesBackupJob -Job $restoreJob;
}

function Test-BackupItemScenario
{
	# 1. Create / update and get vault
    $vaultLocation = get_available_location;
	$vault = New-AzureRmRecoveryServicesVault `
		-Name $resourceName -ResourceGroupName $resourceGroupName -Location $vaultLocation;
	
	# 2. Set vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	# 3. Get container
	$global:container = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType AzureVM `
		-Name $vmName `
		-ResourceGroupName $vmResourceGroupName `
		-Status Registered;

	# 4. If not already protected, enable protection
	if ($global:container -eq $null)
	{
		# 4.1 Get default policy
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name $defaultPolicyName;	
	
		Enable-AzureRmRecoveryServicesBackupProtection `
			-Policy $policy -Name $vmName -ResourceGroupName $vmResourceGroupName;

		$global:container = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Name $vmName `
			-ResourceGroupName $vmResourceGroupName `
			-Status Registered;
	}
	
	# 6. Get item
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $global:container -WorkloadType AzureVM;

	# ACTION: Trigger backup and wait for completion
	$fixedExpiryDate = Get-Date;
	$expiryDate = $fixedExpiryDate.AddDays(2).ToUniversalTime();
    $backupJob = Backup-AzureRmRecoveryServicesBackupItem `
		-Item $item -ExpiryDateTimeUTC $expiryDate;
	Wait-AzureRmRecoveryServicesBackupJob -Job $backupJob;
}