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

$location = "eastasia" 
$resourceGroupName = "afs-pstest-rg" 
$vaultName = "afs-pstest-vault" 
$fileShareFriendlyName = "fs1"
$fileShareName = "azurefileshare;7f34af6cfe2f3f3204cfd4d18cd6b37f7dec2c84a2d759ffab3d1367f9e17356" 
$saName = "afspstestsa"
$saRgName = "afs-pstest-rg" 
$skuName="Standard_LRS"
$policyName = "afspolicy1"

# Setup Instructions:
# 1. Create a resource group
# New-AzResourceGroup -Name $resourceGroupName -Location $location

# 2. Create a storage account and a recovery services vault
# New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $saName -Location $location -SkuName $skuName
# New-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName -Location $Location

# 3. Create a file share in the storage account
# $storageAcct = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $saName
# New-AzureStorageShare -Name $fileShareFriendlyName -Context $storageAcct.Context

# 4. Create a backup policy for file shares
# $vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
# $schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles
# $retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureFiles
# $policy = New-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID `
#		-Name $policyName `
#		-WorkloadType AzureFiles `
#		-RetentionPolicy $retentionPolicy `
#		-SchedulePolicy $schedulePolicy

function Test-AzureFSContainer
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Enable-Protection $vault $fileShareFriendlyName $saName
		
		# VARIATION-1: Get All Containers with only mandatory parameters
		$containers = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage;
		Assert-True { $containers.FriendlyName -contains $saName }

		# VARIATION-2: Get Containers with friendly name filter
		$containers = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName;
		Assert-True { $containers.FriendlyName -contains $saName }

		# VARIATION-3: Get Containers with resource group filter
		$containers = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-ResourceGroupName $resourceGroupName;
		Assert-True { $containers.FriendlyName -contains $saName }
	
		# VARIATION-4: Get Containers with friendly name and resource group filters
		$containers = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName `
			-ResourceGroupName $resourceGroupName;
		Assert-True { $containers.FriendlyName -contains $saName }
	}
	finally
	{
		Disable-AzRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $item `
		-RemoveRecoveryPoints `
		-Force;

		# Cleanup-Vault $vault $item $containers
	}
}

function Test-AzureFSUnregisterContainer
{
	$subId = "38304e13-357e-405e-9e9a-220351dcce8c"
	$fileShareFriendlyName = "donotuse-powershell-fileshare"

	$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	
	$container = Get-AzRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-FriendlyName $saName

	$item = Get-AzRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles `
		-Name $fileShareFriendlyName

	# Disable Protection
	Disable-AzRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $item `
		-RemoveRecoveryPoints `
		-Force;
	Unregister-AzRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-Container $container `
		-Force;

	$container = Get-AzRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-FriendlyName $saName
	Assert-NotNull $container
	Assert-AreEqual $container.Status "SoftDeleted"
}

function Test-AzureFSRegisterParameterValidation
{
	$resourceGroupName = Get-AzureFSMsiTestValue `
		-Name "AZURE_TEST_AFS_MSI_RESOURCE_GROUP" `
		-PlaybackValue "afs-msi-test-rg"
	$vaultName = Get-AzureFSMsiTestValue `
		-Name "AZURE_TEST_AFS_MSI_VAULT_NAME" `
		-PlaybackValue "afs-msi-test-vault"
	$vault = Get-AzRecoveryServicesVault `
		-ResourceGroupName $resourceGroupName `
		-Name $vaultName
	$resourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm"
	$uamiId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/afs-msi-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/afs-msi-test-uami"

	Assert-ThrowsContains {
		Register-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ResourceId $resourceId `
			-BackupManagementType AzureStorage `
			-WorkloadType AzureFiles `
			-Confirm:$false `
			-ErrorAction Stop
	} "Azure Files registration requires -StorageAccountName"

	Assert-ThrowsContains {
		Register-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-StorageAccountName $saName `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL `
			-Confirm:$false `
			-ErrorAction Stop
	} "-StorageAccountName supports Azure Files registration only"

	Assert-ThrowsContains {
		Register-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-StorageAccountName $saName `
			-BackupManagementType AzureStorage `
			-WorkloadType AzureFiles `
			-AccessType IdentityBased `
			-IsSystemAssignedIdentity `
			-UserAssignedIdentityArmUrl $uamiId `
			-Confirm:$false `
			-ErrorAction Stop
	} "Both -IsSystemAssignedIdentity and -UserAssignedIdentityArmUrl"

	Assert-ThrowsContains {
		Register-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-StorageAccountName $saName `
			-BackupManagementType AzureStorage `
			-WorkloadType AzureFiles `
			-IsSystemAssignedIdentity `
			-Confirm:$false `
			-ErrorAction Stop
	} "An identity was specified without -AccessType"

	Assert-ThrowsContains {
		Register-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-StorageAccountName $saName `
			-BackupManagementType AzureStorage `
			-WorkloadType AzureFiles `
			-AccessType IdentityBased `
			-Confirm:$false `
			-ErrorAction Stop
	} "-AccessType 'IdentityBased' requires an identity"

	Assert-ThrowsContains {
		Register-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-StorageAccountName $saName `
			-BackupManagementType AzureStorage `
			-WorkloadType AzureFiles `
			-AccessType KeyBased `
			-IsSystemAssignedIdentity `
			-Confirm:$false `
			-ErrorAction Stop
	} "-AccessType 'KeyBased' cannot be combined with an identity"
}

function Test-AzureFSManagedIdentityRegisterAndReregister
{
	$resourceGroupName = Get-AzureFSMsiTestValue `
		-Name "AZURE_TEST_AFS_MSI_RESOURCE_GROUP" `
		-PlaybackValue "afs-msi-test-rg"
	$vaultName = Get-AzureFSMsiTestValue `
		-Name "AZURE_TEST_AFS_MSI_VAULT_NAME" `
		-PlaybackValue "afs-msi-test-vault"
	$storageAccountName = Get-AzureFSMsiTestValue `
		-Name "AZURE_TEST_AFS_MSI_REGISTER_STORAGE_ACCOUNT" `
		-PlaybackValue "afsmsiregistersa"
	$uamiId = Get-AzureFSMsiTestValue `
		-Name "AZURE_TEST_AFS_MSI_UAMI_ID" `
		-PlaybackValue "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/afs-msi-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/afs-msi-test-uami"

	$vault = Get-AzRecoveryServicesVault `
		-ResourceGroupName $resourceGroupName `
		-Name $vaultName

	$uamiContainer = Register-AzRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-BackupManagementType AzureStorage `
		-WorkloadType AzureFiles `
		-StorageAccountName $storageAccountName `
		-AccessType IdentityBased `
		-UserAssignedIdentityArmUrl $uamiId `
		-Force `
		-Confirm:$false
	Assert-AreEqual "IdentityBased" $uamiContainer.AccessType
	Assert-AreEqual $uamiId $uamiContainer.IdentityInfo.ManagedIdentityResourceId

	$samiContainer = Register-AzRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-BackupManagementType AzureStorage `
		-WorkloadType AzureFiles `
		-StorageAccountName $storageAccountName `
		-AccessType IdentityBased `
		-IsSystemAssignedIdentity `
		-Force `
		-Confirm:$false
	Assert-AreEqual "IdentityBased" $samiContainer.AccessType
	Assert-True { $samiContainer.IdentityInfo.IsSystemAssignedIdentity }

	$uamiContainer = Register-AzRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-BackupManagementType AzureStorage `
		-WorkloadType AzureFiles `
		-StorageAccountName $storageAccountName `
		-AccessType IdentityBased `
		-UserAssignedIdentityArmUrl $uamiId `
		-Force `
		-Confirm:$false
	Assert-AreEqual "IdentityBased" $uamiContainer.AccessType
	Assert-AreEqual $uamiId $uamiContainer.IdentityInfo.ManagedIdentityResourceId
}
