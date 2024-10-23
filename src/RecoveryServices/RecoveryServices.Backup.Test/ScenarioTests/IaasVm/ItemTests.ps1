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

function Test-AzureVaultSoftDelete
{	
	$resourceGroupName = "hiagarg"
	$vaultName = "hiagaSecurityVault"
	$location = "eastus2euap"
	$tag= @{"MABUsed"="Yes";"Owner"="hiaga";"Purpose"="Testing";"DeleteBy"="01-2099"}
	
	try
	{			
		# new vault
		$vault = New-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName -Location $location -Tag $tag
		$vault = Get-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName
		Assert-True {  $vault -ne $null }
		
		# Disable soft delete 
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState Disable
		$vaultProperty = Get-AzRecoveryServicesVaultProperty -VaultId $vault.ID
		Assert-True { $vaultProperty.SoftDeleteFeatureState -eq "Disabled" }

		# Enable soft delete 
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState Enable
		$vaultProperty = Get-AzRecoveryServicesVaultProperty -VaultId $vault.ID
		Assert-True { $vaultProperty.SoftDeleteFeatureState -eq "Enabled" }

		# Enable disable hybrid security setting 
		Set-AzRecoveryServicesVaultProperty   -VaultId  $vault.ID -DisableHybridBackupSecurityFeature $false
		$vaultProperty = Get-AzRecoveryServicesVaultProperty -VaultId $vault.ID
		Assert-True { $vaultProperty.EnhancedSecurityState -eq "Enabled" }

		# Disable hybrid security setting
		Set-AzRecoveryServicesVaultProperty   -VaultId  $vault.ID -DisableHybridBackupSecurityFeature $true
		$vaultProperty = Get-AzRecoveryServicesVaultProperty -VaultId $vault.ID
		Assert-True { $vaultProperty.EnhancedSecurityState -eq "Disabled" }		
	}
	finally
	{
		# remove vault
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName		
		Remove-AzRecoveryServicesVault -Vault $vault
	}
}

function Test-AzureVaultPublicNetworkAccess
{	
	$resourceGroupName = "hiagaCZR-rg"
	$vaultName = "hiagaPNAVault"
	$location = "eastus2euap"
	$tag= @{"MABUsed"="Yes";"Owner"="hiaga";"Purpose"="Testing";"DeleteBy"="01-2099"}
	
	try
	{			
		# new vault
		# Public Network Access is by default enabled for this vault and can be updated using Update-AzRecoveryServicesVault cmdlet
		$vault = New-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName -Location $location -Tag $tag
		$vault = Get-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName
		
		Assert-True {  $vault.Properties.PublicNetworkAccess -eq "Enabled"}
		
		$vault = Update-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName -PublicNetworkAccess "Disabled"
		Assert-True {  $vault.Properties.PublicNetworkAccess -eq "Disabled"}
	}
	finally
	{
		# remove vault
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName		
		Remove-AzRecoveryServicesVault -Vault $vault
	}
}

function Test-AzureVaultImmutability
{	
	$resourceGroupName = "hiagaCZR-rg"
	$vaultName = "hiagaImmutableVault3"
	$location = "eastus2euap"
	$tag= @{"MABUsed"="Yes";"Owner"="hiaga";"Purpose"="Testing";"DeleteBy"="01-2099"}

	$suspendVaultName = "hiaga-adhoc-vault"
	$suspendResourceGroupName = "hiagarg"

	try
	{			
		# new vault		
		$vault = New-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName -Location $location -Tag $tag -ImmutabilityState "Disabled"
		$vault = Get-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName
		
		Assert-True { $vault.Properties.ImmutabilitySettings.ImmutabilityState -eq "Disabled"}

		Assert-ThrowsContains { $vault = Update-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName -ImmutabilityState Locked } `
		"Immutability can only be locked when it is Unlocked(Enabled)";

		$vault = Update-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName -ImmutabilityState "Unlocked"
		$vault = Get-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName

		Assert-True { $vault.Properties.ImmutabilitySettings.ImmutabilityState -eq "Unlocked"}

		# get suspend vault
		$suspendVault = Update-AzRecoveryServicesVault -Name $suspendVaultName -ResourceGroupName $suspendResourceGroupName -ImmutabilityState "Unlocked"
		$suspendVault = Get-AzRecoveryServicesVault -Name $suspendVaultName -ResourceGroupName $suspendResourceGroupName
		
		$item = Get-AzRecoveryServicesBackupItem -VaultId $suspendVault.ID -BackupManagementType AzureVM -WorkloadType AzureVM
		Assert-True { $item[0].ProtectionState -eq  "Protected" }

		# suspend backup 
		Disable-AzRecoveryServicesBackupProtection -Item $item[0] -RetainRecoveryPointsAsPerPolicy -VaultId $suspendVault.ID -Force
		$item = Get-AzRecoveryServicesBackupItem -VaultId $suspendVault.ID -BackupManagementType AzureVM -WorkloadType AzureVM
		Assert-True { $item[0].ProtectionState -eq "BackupsSuspended" }

		# resume backup 
		$pol = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $suspendVault.ID -Name "DefaultPolicy"
		Enable-AzRecoveryServicesBackupProtection -Item $item[0] -Policy $pol -VaultId $suspendVault.ID

		$item = Get-AzRecoveryServicesBackupItem -VaultId $suspendVault.ID -BackupManagementType AzureVM -WorkloadType AzureVM
		Assert-True { $item[0].ProtectionState -eq  "Protected" }
	}
	finally
	{
		# revert immutability
		$suspendVault = Update-AzRecoveryServicesVault -Name $suspendVaultName -ResourceGroupName $suspendResourceGroupName -ImmutabilityState "Disabled"

		# remove new vault
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		Remove-AzRecoveryServicesVault -Vault $vault
	}
}

function Test-AzureVMCRRWithDES
{
	$resourceGroupName = "hiagarg"
	$vaultName = "hiagaCRRDES-testvault"
	$saName = "hiagawestussa"
	$desId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/hiagarg/providers/Microsoft.Compute/diskEncryptionSets/hiagaDES-wus"
	$restoredDiskName = "hiagacrrdesvm"
	$recoveryPointId = "923327220026724684" # latest vaultStandard recovery point

	try
	{	
		# Setup
		$vault = Get-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName  
		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType "AzureVM" -WorkloadType "AzureVM" -VaultId $vault.ID   

		$rp = Get-AzRecoveryServicesBackupRecoveryPoint -Item $item[0] -VaultId $vault.ID  -RecoveryPointId $recoveryPointId

		$crrDESJob = Restore-AzRecoveryServicesBackupItem -VaultId $vault.ID -VaultLocation $vault.Location -RecoveryPoint $rp[0] -StorageAccountName $saName -StorageAccountResourceGroupName $resourceGroupName -TargetResourceGroupName $resourceGroupName -RestoreToSecondaryRegion -DiskEncryptionSetId $desId

		$crrDESJob | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID
		
		# get job
		$crrDESJob = Get-AzRecoveryServicesBackupJob -VaultId $vault.ID  | where { $_.Operation -eq "CrossRegionRestore"  }
		Assert-True { $crrDESJob[0].Status -eq "Completed" }
	}
	finally
	{
		# remove disk
		Delete-AllDisks $resourceGroupName $restoredDiskName
	}
}

function Test-AzureCrossZonalRestore
{
	$location = "eastus"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiaga-zrs-vault"
	$vmName = "VM;iaasvmcontainerv2;hiagarg;hiagaNZP"
	$saName = "hiagaeussa"
	$targetVMName = "czr-pstest-vm"
	$targetVNetName = "hiagaNZPVNet"
	$targetVNetRG = "hiagarg"
	$targetSubnetName = "custom"
	$recoveryPointId = "175504659649163" # latest vaultStandard recovery point
	$snapshotRecoveryPointId = "171196026959443" # latest Snapshot (older than 4 hrs) recovery point
	try
	{	
		# Setup
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM `
			-VaultId $vault.ID -Name $vmName

		$rp = Get-AzRecoveryServicesBackupRecoveryPoint -Item $item[0] -VaultId $vault.ID -RecoveryPointId $recoveryPointId
		
		$restoreJobCZR = Restore-AzRecoveryServicesBackupItem -VaultId $vault.ID -VaultLocation $vault.Location `
			-RecoveryPoint $rp[0] -StorageAccountName $saName -StorageAccountResourceGroupName $vault.ResourceGroupName -TargetResourceGroupName $vault.ResourceGroupName -TargetVMName $targetVMName -TargetVNetName $targetVNetName -TargetVNetResourceGroup $targetVNetRG -TargetSubnetName $targetSubnetName -TargetZoneNumber 2 | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJobCZR.Status -eq "Completed" }

		# Snapshot CZR
		# $rp = Get-AzRecoveryServicesBackupRecoveryPoint -Item $item[0] -VaultId $vault.ID  -RecoveryPointId $recoveryPointId
		
		# $restoreJobCZR = Restore-AzRecoveryServicesBackupItem -VaultId $vault.ID -VaultLocation $vault.Location -RecoveryPoint $rp[0] -StorageAccountName $saName -StorageAccountResourceGroupName $vault.ResourceGroupName -TargetResourceGroupName $vault.ResourceGroupName -TargetVMName $targetVMName -TargetVNetName $targetVNetName -TargetVNetResourceGroup $targetVNetRG -TargetSubnetName $targetSubnetName -TargetZoneNumber 2 | Wait-#AzRecoveryServicesBackupJob -VaultId $vault.ID
		
		#Assert-True { $restoreJobCZR.Status -eq "Completed" }
	}
	finally
	{
		Delete-VM $resourceGroupName $targetVMName
	}
}

function Test-AzureMonitorAlerts
{
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg" # "vijami-alertrg"  
	$vaultName1 = "Backupalerts-pstest-vault1"
	$vaultName2 = "Backupalerts-pstest-vault2"

	try
	{	
		# create a vault without Alert settings
		$tag= @{"MABUsed"="Yes";"Owner"="hiaga";"Purpose"="Testing";"DeleteBy"="06-2099"}
		$vault1 = New-AzRecoveryServicesVault -Name $vaultName1 -ResourceGroupName $resourceGroupName -Location "centraluseuap" -Tag $tag
		
		Assert-True { $vault1.Properties.AlertSettings -eq $null }

		# create a vault with Alert settings 
		$vault2 = New-AzRecoveryServicesVault -Name $vaultName2 -ResourceGroupName $resourceGroupName -Location "centraluseuap" `
			-DisableAzureMonitorAlertsForJobFailure $false `
            -DisableAzureMonitorAlertsForAllReplicationIssue $false `
            -DisableAzureMonitorAlertsForAllFailoverIssue $true `
            -DisableEmailNotificationsForSiteRecovery $false `
			-DisableClassicAlerts $true
		
		Assert-True { $vault2.Properties.AlertSettings -ne $null }
		Assert-True { $vault2.Properties.AlertSettings.AzureMonitorAlertsForAllJobFailure -eq "Enabled" }
		Assert-True { $vault2.Properties.AlertSettings.ClassicAlertsForCriticalOperations -eq "Disabled" }

		$vault = Update-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName  -Name $vaultName1 -DisableClassicAlerts $false

		# update alert settings 
		$vault1 = Update-AzRecoveryServicesVault -Name $vaultName1 -ResourceGroupName $resourceGroupName `
			-DisableAzureMonitorAlertsForJobFailure $false `
			-DisableClassicAlerts $true

		Assert-True { $vault1.Properties.AlertSettings -ne $null }
		Assert-True { $vault1.Properties.AlertSettings.AzureMonitorAlertsForAllJobFailure -eq "Enabled" }
		Assert-True { $vault1.Properties.AlertSettings.ClassicAlertsForCriticalOperations -eq "Disabled" }
		
		$vault2 = Update-AzRecoveryServicesVault -Name $vaultName2 -ResourceGroupName $resourceGroupName `
			-DisableAzureMonitorAlertsForJobFailure $true `
			-DisableClassicAlerts $false

		Assert-True { $vault2.Properties.AlertSettings -ne $null }
		Assert-True { $vault2.Properties.AlertSettings.AzureMonitorAlertsForAllJobFailure -eq "Disabled" }
		Assert-True { $vault2.Properties.AlertSettings.ClassicAlertsForCriticalOperations -eq "Enabled" }

	}
	finally
	{
		# Cleanup
		Remove-AzRecoveryServicesVault -Vault $vault1
		Remove-AzRecoveryServicesVault -Vault $vault2
	}
}

function Test-AzureVMMUA
{
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "mua-pstest-vault"
	$vmName = "VM;iaasvmcontainerv2;hiagarg;hiaganewvm2"
	$vmFriendlyName = "hiaganewvm2"
	# $resGuardId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/iaasvm-pstest-rg/providers/Microsoft.DataProtection/resourceGuards/mua-pstest-rguard"
	$resGuardId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/hiagarg/providers/Microsoft.DataProtection/ResourceGuards/test1-rGuard"
	$lowerRetentionPolicy = "mua-vm-lowerDailyRet"
	
	try
	{	
		# Setup
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

		# Enable protection on hiaganewVM2 with default policy 
		$pol = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name "DefaultPolicy"
		Enable-AzRecoveryServicesBackupProtection -Policy $pol -ResourceGroupName $resourceGroupName -Name $vmFriendlyName -VaultId $vault.ID

		# create resource guard mapping 
		$resGuardMapping = Set-AzRecoveryServicesResourceGuardMapping -ResourceGuardId $resGuardId -VaultId $vault.ID
		$mapping = Get-AzRecoveryServicesResourceGuardMapping -VaultId $vault.ID
		Assert-True { $mapping.name -eq "VaultProxy" }  

		# modify policy
		# modify policy with reduce retention count 
		$pol = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -WorkloadType AzureVM -BackupManagementType AzureVM
		$pol[1].RetentionPolicy.DailySchedule.DurationCountInDays = $pol[1].RetentionPolicy.DailySchedule.DurationCountInDays - 1
		Set-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $pol[1] -RetentionPolicy $pol[1].RetentionPolicy

		# modify policy with increase retention count 
		$pol = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -WorkloadType AzureVM -BackupManagementType AzureVM
		$pol[1].RetentionPolicy.DailySchedule.DurationCountInDays = $pol[1].RetentionPolicy.DailySchedule.DurationCountInDays + 2
		Set-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $pol[1] -RetentionPolicy $pol[1].RetentionPolicy

		# modify protection 
		$pol = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $lowerRetentionPolicy
		$item = Get-AzRecoveryServicesBackupItem -VaultId $vault.ID -BackupManagementType AzureVM -WorkloadType AzureVM

		# modify protection with lower retention policy 
		Enable-AzRecoveryServicesBackupProtection -Item $item  -Policy $pol -VaultId $vault.ID 

		# modify protection with regular policy 
		$pol = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name "DefaultPolicy"
		$item = Get-AzRecoveryServicesBackupItem -VaultId $vault.ID -BackupManagementType AzureVM -WorkloadType AzureVM
		Enable-AzRecoveryServicesBackupProtection -Item $item -Policy $pol -VaultId $vault.ID 

	}
	finally
	{		
		# dsiable softDelete 
		Set-AzRecoveryServicesVaultProperty -SoftDeleteFeatureState Disable -VaultId $vault.ID

		#disable protection with RemoveRecoveryPoints
		Disable-AzRecoveryServicesBackupProtection -Item $item -RemoveRecoveryPoints -VaultId $vault.ID -Force

		# remove mapping 
		Remove-AzRecoveryServicesResourceGuardMapping -VaultId $vault.ID

		# enable soft delete 
		Set-AzRecoveryServicesVaultProperty -SoftDeleteFeatureState Enable -VaultId $vault.ID
	}
}

function Test-AzureManagedVMRestore
{
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiagaVault"
	$vmName = "VM;iaasvmcontainerv2;hiagarg;hiaganewVM2" # hiagavm"
	$saName = "hiagasa"
	$targetVMName = "alr-pstest-vm"
	$targetVNetName = "hiagarg-vnet"
	$targetVNetRG = "hiagarg"
	$targetSubnetName = "default"

	try
	{	
		# Setup
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM `
			-VaultId $vault.ID -Name $vmName

		$backupJob = Backup-Item $vault $item
		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);
		
		$rp = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item; 		

		$restoreJobALR = Restore-AzRecoveryServicesBackupItem -VaultId $vault.ID -VaultLocation $vault.Location `
			-RecoveryPoint $rp[0] -StorageAccountName $saName -StorageAccountResourceGroupName $vault.ResourceGroupName -TargetResourceGroupName $vault.ResourceGroupName -TargetVMName $targetVMName -TargetVNetName $targetVNetName -TargetVNetResourceGroup $targetVNetRG -TargetSubnetName $targetSubnetName | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJobALR.Status -eq "Completed" }

		$restoreJobOLR = Restore-AzRecoveryServicesBackupItem -VaultId $vault.ID -VaultLocation $vault.Location `
			-RecoveryPoint $rp[0] -StorageAccountName $saName -StorageAccountResourceGroupName $vault.ResourceGroupName | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJobOLR.Status -eq "Completed" }  
	}
	finally
	{
		Delete-VM $resourceGroupName $targetVMName
	}
}

function Test-AzureRSVaultCMK
{
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "cmk-pstest-vault"
	$keyVault = "cmk-pstest-keyvault"
	$encryptionKeyId = "https://cmk-pstest-keyvault.vault.azure.net/keys/cmk-pstest-key/5569d5a163ee474cad2da4ac334af9d7"
	$encryptionKeyId2 = "https://oss-pstest-keyvault.vault.azure.net/keys/cmk-pstest-key2"

	try
	{	
		# Setup
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

		# error scenario
		Assert-ThrowsContains { Set-AzRecoveryServicesVaultProperty -EncryptionKeyId $encryptionKeyId2 -VaultId $vault.ID -InfrastructureEncryption -UseSystemAssignedIdentity $false } `
		"Please input a valid UserAssignedIdentity";	

		# set and verify - CMK encryption property to UAI 
		Set-AzRecoveryServicesVaultProperty -EncryptionKeyId $encryptionKeyId2 -VaultId $vault.ID -InfrastructureEncryption -UseSystemAssignedIdentity $false  -UserAssignedIdentity $vault.Identity.UserAssignedIdentities.Keys[0]
		$prop = Get-AzRecoveryServicesVaultProperty -VaultId $vault.ID
		Assert-True { $prop.encryptionProperties.UserAssignedIdentity -eq $vault.Identity.UserAssignedIdentities.Keys[0] }

		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		Assert-True { $vault.Properties.EncryptionProperty.KekIdentity.UserAssignedIdentity -eq $vault.Identity.UserAssignedIdentities.Keys[0] }
		Assert-True { $vault.Properties.EncryptionProperty.KeyVaultProperties.KeyUri -eq $encryptionKeyId2 }

		Start-TestSleep -Seconds 10

		# set and verify - CMK encryption property to system identity 	
		Set-AzRecoveryServicesVaultProperty -EncryptionKeyId $encryptionKeyId -VaultId $vault.ID -UseSystemAssignedIdentity $true
		$prop = Get-AzRecoveryServicesVaultProperty -VaultId $vault.ID
		Assert-True { $prop.encryptionProperties.UseSystemAssignedIdentity }
	}
	finally
	{
		# no Cleanup		
	}
}

function Test-AzureVMRestoreWithMSI
{
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiagaVault"
	$vmName = "VM;iaasvmcontainerv2;hiagarg;hiaganewvm2"
	$saName = "hiagasa"

	try
	{
		# Setup
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM `
			-VaultId $vault.ID -Name $vmName

		$backupJob = Backup-Item $vault $item
		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);
		
		$rp = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item; 		
		
		$restoreJob1 = Restore-AzRecoveryServicesBackupItem -VaultId $vault.ID -VaultLocation $vault.Location `
			-RecoveryPoint $rp[0] -StorageAccountName $saName -StorageAccountResourceGroupName `
			$vault.ResourceGroupName -RestoreOnlyOSDisk -TargetResourceGroupName $vault.ResourceGroupName `
			-UseSystemAssignedIdentity | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob1.Status -eq "Completed" }   
	}
	finally
	{
		# no Cleanup		
	}
}

function Test-AzureVMCrossRegionRestore
{
	$location = "centraluseuap"
	$resourceGroupName = Create-ResourceGroup $location 24			
	
	try
	{
		# Setup
		$vault = Create-RecoveryServicesVault $resourceGroupName $location 25

		# waiting for service to reflect
		Start-TestSleep -Seconds 20

		# Enable CRR
		Set-AzRecoveryServicesBackupProperty -Vault $vault -EnableCrossRegionRestore

		# waiting for service to reflect
		Start-TestSleep -Seconds 30

		# Assert that the vault is now CRR enabled
		$crr = Get-AzRecoveryServicesBackupProperty -Vault $vault
		Assert-True { $crr.CrossRegionRestore -eq $true }
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureRSVaultMSI
{
	$location = "centraluseuap"
	$resourceGroupName = "msi-pstest-rg"
	$vaultName = "msi-pstest-vault"

	$identityId1 = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/msi-pstest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/pstest-msi1"
	$identityId2 = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/msi-pstest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/pstest-msi2"
	$identityId3 = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/msi-pstest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/pstest-msi3"

	try
	{	
		# get Identity - verify Empty 
		$vault = Get-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName
		
		# set Identity - verify System assigned
		$updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -IdentityType "None"
		$updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -IdentityType "SystemAssigned"
		Assert-True { $updatedVault.Identity.Type -eq "SystemAssigned" }

		# add UAI 1, 2 and 3 to the vault 
		$updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -IdentityType UserAssigned -IdentityId $identityId1, $identityId2, $identityId3
		
		# verify that UAI 1, 2 and 3 are added to vault 
		Assert-True { $updatedVault.Identity.UserAssignedIdentities.Keys.Contains($identityId1) }
		Assert-True { $updatedVault.Identity.UserAssignedIdentities.Keys.Contains($identityId2) }
		Assert-True { $updatedVault.Identity.UserAssignedIdentities.Keys.Contains($identityId3) }

		# remove UAI 1 and 214 (should throw error)
		$identityId = $identityId2 + "14"
		
		Assert-ThrowsContains { $updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -RemoveUserAssigned -IdentityId $identityId1, $identityId } `
		"IdentityId '" + $identityId +  "' is invalid";
		
		# remove UAI 1 from vault
		$updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -RemoveUserAssigned -IdentityId $identityId1
		
		# Remove both SystemAssigned and UserAssigned identities simultaneously (would throw error)	
		Assert-ThrowsContains { $updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -RemoveUserAssigned -IdentityId $identityId2 -RemoveSystemAssigned } `
		"UserAssigned and SystemAssigned identities can't be removed together";		
		
		# remove all present UAI from vault 
		$updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -RemoveUserAssigned -IdentityId $identityId2, $identityId3
		Assert-True { $updatedVault.Identity.Type -eq "SystemAssigned" }
		
		# remove SystemAssigned identity from the vault 
		$updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -RemoveSystemAssigned
		Assert-True { $updatedVault.Identity.Type -eq "None" }
		
		# add UAI 3 to the vault
		$updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -IdentityType UserAssigned -IdentityId $identityId3
		
		# remove Identity - verify empty again 
		$updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -IdentityType "None"
		Assert-True { $updatedVault.Identity.Type -eq "None" }
	}
	finally
	{
		# no cleanup		
	}
}

function Test-AzureBackupDataMove
{
	$sourceLocation = "eastus2euap"
	$sourceResourceGroup = Create-ResourceGroup $sourceLocation 21

	$targetLocation = "centraluseuap"
	$targetResourceGroup = Create-ResourceGroup $targetLocation 23
		
	$vm = Create-VM $sourceResourceGroup $sourceLocation 3
	$vault1 = Create-RecoveryServicesVault $sourceResourceGroup $sourceLocation
	$vault2 = Create-RecoveryServicesVault $targetResourceGroup $targetLocation
	Enable-Protection $vault1 $vm
		
	# disable soft delete for successful cleanup
	Set-AzRecoveryServicesVaultProperty -VaultId $vault1.ID -SoftDeleteFeatureState "Disable"
	Set-AzRecoveryServicesVaultProperty -VaultId $vault2.ID -SoftDeleteFeatureState "Disable"

	# data move v2 to v1 fails due to TargetVaultNotEmpty
	Assert-ThrowsContains { Copy-AzRecoveryServicesVault -SourceVault $vault2 -TargetVault $vault1 -Force } `
		"Please provide an empty target vault. The target vault should not have any backup items or backup containers";			

	# data move from v1 to v2 succeeds
	$dataMove = Copy-AzRecoveryServicesVault -SourceVault $vault1 -TargetVault $vault2 -Force;
	Assert-True { $dataMove -contains "Please monitor the operation using Az-RecoveryServicesBackupJob cmdlet" }			
}

function Test-AzureVMGetItems
{
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiaga-adhoc-vault"
	$vmName1 = "VM;iaasvmcontainerv2;hiagarg;hiaga-adhoc-vm"
	$vmName2 = "VM;iaasvmcontainerv2;hiagarg;hiaganewvm3"	
	$vmFriendlyName1 = "hiaga-adhoc-vm"
	$vmFriendlyName2 = "hiaganewvm3"
	$protectionState = "IRPending"
	#$location = "southeastasia"
	#$resourceGroupName = Create-ResourceGroup $location
	
	try
	{
		# Setup
		$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmFriendlyName1
		$vm2 = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmFriendlyName2
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName 

		# disable soft delete for successful cleanup
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"

		# Enable-Protection $vault $vm
		# Enable-Protection $vault $vm2
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "DefaultPolicy"

		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureVM `
			-FriendlyName $vm.Name
		
		# VARIATION-1: Get all items for container
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-2: Get items for container with friendly name filter.
		# Here we will be testing a case when two VMs with overlapping names are protected.
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-Name $vm.Name;
		Assert-True { $items.Count -eq 1 }
		Assert-True { $items.VirtualMachineId -contains $vm.Id }
		Assert-NotNull $items[0].LastBackupTime

		# VARIATION-3: Get items for container with ProtectionStatus filter
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-ProtectionStatus Healthy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-4: Get items for container with Status filter
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-ProtectionState Protected;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-5: Get items for container with friendly name and ProtectionStatus filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-Name $vm.Name `
			-ProtectionStatus Healthy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-6: Get items for container with friendly name and Status filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-Name $vm.Name `
			-ProtectionState Protected;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-7: Get items for container with Status and ProtectionStatus filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-ProtectionState Protected `
			-ProtectionStatus Healthy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-8: Get items for container with friendly name, Status and ProtectionStatus filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-Name $vm.Name `
			-ProtectionState Protected `
			-ProtectionStatus Healthy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-9: Get items for Vault Id and Policy
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Policy $policy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }
	}
	finally
	{
		# Cleanup				
	}
}

function Test-AzureVMProtection
{
	# $location = "southeastasia"
	# $resourceGroupName = Create-ResourceGroup $location

	$location = "centraluseuap"
	$resourceGroupName = "iaasvm-pstest-rg"
	$vaultName = "iaasvm-pstest-vault"
	$vmName = "iaasvm-pstest-vm"

	try
	{
		# Setup
		$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmName
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"

		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID

		Disable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Item $item `
			-RemoveRecoveryPoints `
			-Force;

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "DefaultPolicy";

		Assert-True {$policy.ProtectedItemsCount -eq 0};

		# $vm = Create-VM $resourceGroupName $location
		# $vault = Create-RecoveryServicesVault $resourceGroupName $location
		
		# Sleep to give the service time to add the default policy to the vault
        Start-TestSleep -Seconds 5

		# Enable protection
		Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-Name $vm.Name `
			-ResourceGroupName $vm.ResourceGroupName;

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "DefaultPolicy";

		Assert-True {$policy.ProtectedItemsCount -eq 1};

		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID
		
		Assert-True { $item.SourceResourceId -match $vm.Name };
	}
	finally
	{
		# Cleanup
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Enable"
	}
}

function Test-AzureVMGetRPs
{	
	$location = "centraluseuap"
	$resourceGroupName = "iaasvm-pstest-rg"
	$vaultName = "iaasvm-pstest-vault"
	$vmName = "iaasvm-pstest-vm"

	# $location = "southeastasia"
	# $resourceGroupName = Create-ResourceGroup $location

	try
	{
  		# Setup
		$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmName #Create-VM $resourceGroupName $location
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName # Create-RecoveryServicesVault $resourceGroupName $location
		
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"

		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID # Enable-Protection $vault $vm
		$backupJob = Backup-Item $vault $item

		# Test 1: Get latest recovery point; should be only one
		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);
		$recoveryPoint = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item;
	
		Assert-NotNull $recoveryPoint;
		Assert-True { $recoveryPoint.SourceResourceId -match $vm.Id };

		# Test 2: Get Recovery point detail
		$recoveryPointDetail = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-RecoveryPointId $recoveryPoint[0].RecoveryPointId `
			-Item $item;
	
		Assert-NotNull $recoveryPointDetail;

		# Negative test cases
		# 1. StartDate < EndDate
		Assert-ThrowsContains { Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupEndTime `
			-EndDate $backupStartTime `
			-Item $item } `
			"End date should be greater than start date";
		
		# 2. rangeStart > DateTime.UtcNow
		$backupStartTime1 = Get-QueryDateInUtc $((Get-Date).AddYears(100)) "BackupStartTime1"
        Assert-ThrowsContains { Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime1 `
			-Item $item } `
			"Start date\time should be less than current UTC date\time";

		# 3. rangeStart.Kind != DateTimeKind.Utc
		$backupStartTime2 = Get-QueryDateLocal $((Get-Date).AddDays(-20)) "BackupStartTime2"
        Assert-ThrowsContains { Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime2 `
			-Item $item } `
			"Please specify startdate and enddate in UTC format";
	}
	finally
	{
		# Cleanup
		# Cleanup-ResourceGroup $resourceGroupName
		
		# disable protection with RemoveRecoveryPoints
		# Disable-AzRecoveryServicesBackupProtection -Item $item -RemoveRecoveryPoints -VaultId $vault.ID -Force

		# enable soft delete 
		Set-AzRecoveryServicesVaultProperty -SoftDeleteFeatureState Enable -VaultId $vault.ID
	}
}

function Test-AzureVMFullRestore
{
	# $location = "southeastasia"
	# $resourceGroupName = Create-ResourceGroup $location
	# $targetResourceGroupName = Create-ResourceGroup $location 1

	$location = "centraluseuap"
	$resourceGroupName = "iaasvm-pstest-rg"
	$targetResourceGroupName = "hiagarg"

	$vaultName = "iaasvm-pstest-vault"
	$vmName = "iaasvm-pstest-vm"

	$saName = "pstestsa2"

	try
	{
		# Setup
		# $saName = Create-SA $resourceGroupName $location

		$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmName # Create-VM $resourceGroupName $location
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName # Create-RecoveryServicesVault $resourceGroupName $location
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"

		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID # Enable-Protection $vault $vm
		$backupJob = Backup-Item $vault $item
		$rp = Get-RecoveryPoint $vault $item $backupJob

		Assert-ThrowsContains { Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $resourceGroupName `
			-UseOriginalStorageAccount } `
			"This recovery point doesn’t have the capability to restore disks to their original storage account. Re-run the restore command without the UseOriginalStorageAccountForDisks parameter.";

		$restoreJob1 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-StorageAccountName $saName `
			-RestoreAsUnmanagedDisks `
			-StorageAccountResourceGroupName $resourceGroupName | `
				Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob1.Status -eq "Completed" }   

		$restoreJob2 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $resourceGroupName `
			-TargetResourceGroupName $targetResourceGroupName | `
				Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob2.Status -eq "Completed" }
	}
	finally
	{
		# Cleanup
		# Cleanup-ResourceGroup $resourceGroupName
		# Cleanup-ResourceGroup $targetResourceGroupName
	}
}

function Test-AzureUnmanagedVMFullRestore
{
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location
	
	try
	{
		$saName = Create-SA $resourceGroupName $location
		$vm = Create-UnmanagedVM $resourceGroupName $location $saName
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"
		$VaultProperty = Get-AzRecoveryServicesVaultProperty -VaultId $vault.ID
		Assert-True { $VaultProperty.SoftDeleteFeatureState -eq "Disabled" }

		$item = Enable-Protection $vault $vm $resourceGroupName
		$backupJob = Backup-Item $vault $item
		$rp = Get-RecoveryPoint $vault $item $backupJob

		$restoreJob = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $resourceGroupName `
			-UseOriginalStorageAccount | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob.Status -eq "Completed" }

		$restoreJob2 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $resourceGroupName `
			-RestoreAsManagedDisk -TargetResourceGroupName $resourceGroupName
	}
	finally
	{
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMRPMountScript
{
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vm = Create-VM $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"
		$item = Enable-Protection $vault $vm
		$backupJob = Backup-Item $vault $item
		$rp = Get-RecoveryPoint $vault $item $backupJob

		# Get details of mount script of recovery point
		$mountScriptDetails = Get-AzRecoveryServicesBackupRPMountScript `
			-VaultId $vault.ID `
			-RecoveryPoint $rp

		Assert-NotNull $mountScriptDetails.OsType
		Assert-NotNull $mountScriptDetails.Password
		Assert-NotNull $mountScriptDetails.Filename
		Assert-NotNull $mountScriptDetails.FilePath

		Write-Output $mountScriptDetails

		# Disable the mount script of recovery point
		Disable-AzRecoveryServicesBackupRPMountScript -VaultId $vault.ID -RecoveryPoint $rp
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMBackup
{
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiaga-adhoc-vault"
	$vmName1 = "VM;iaasvmcontainerv2;hiagarg;hiaga-adhoc-vm"
	$vmName2 = "VM;iaasvmcontainerv2;hiagarg;hiaganevm4"
	$vmFriendlyName1 = "hiaga-adhoc-vm"
	$vmFriendlyName2 = "hiaganevm4"
	
	try
	{
		# Setup
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
				
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"
		
		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID		
		
		# Trigger backup and wait for completion
		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item[0] | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $backupJob.Status -eq "Completed" }
	}
	finally
	{
		# no Cleanup
	}
}

function Test-AzureVMSetVaultContext
{
	# $location = "eastasia"
	# $resourceGroupName = Create-ResourceGroup $location

	$location = "centraluseuap"
	$resourceGroupName = "iaasvm-pstest-rg"
	$vaultName = "iaasvm-pstest-vault"
	$vmName = "iaasvm-pstest-vm"

	try
	{
		# Setup
		$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmName # Create-VM $resourceGroupName $location
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName # Create-RecoveryServicesVault $resourceGroupName $location

		# disable soft delete for successful cleanup
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"

		# Sleep to give the service time to add the default policy to the vault
        Start-TestSleep -Seconds 5

		Set-AzRecoveryServicesVaultContext -Vault $vault | Out-Null

		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID

		Disable-AzRecoveryServicesBackupProtection -Item $item -RemoveRecoveryPoints -Force

		# Get default policy
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-Name "DefaultPolicy";
	
		# Enable protection
		Enable-AzRecoveryServicesBackupProtection `
			-Policy $policy `
			-Name $vm.Name `
			-ResourceGroupName $vm.ResourceGroupName;

		# $container = Get-AzRecoveryServicesBackupContainer `
		# 	-ContainerType AzureVM;
		# 
		# $item = Get-AzRecoveryServicesBackupItem `
		# 	-Container $container `
		# 	-WorkloadType AzureVM

		# $item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID

		# Disable protection
		# Disable-AzRecoveryServicesBackupProtection `
		# 	-Item $item `
		# 	-RemoveRecoveryPoints `
		# 	-Force;
	}
	finally
	{
		# Cleanup
		# Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMSoftDelete
{
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location

	try
	{	
		#Setup
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		$vm = Create-VM $resourceGroupName $location
		
		
		$item = Enable-Protection $vault $vm
		$backupJob = Backup-Item $vault $item
		
		#SoftDelete
		
		Disable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Item $item `
			-RemoveRecoveryPoints `
			-Force;

		#Check if the item is in a softdeleted state

		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType "AzureVM" `
			-FriendlyName $vm.Name;

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "AzureVM";

		#rehydrate the softdeleted item

		Undo-AzRecoveryServicesBackupItemDeletion `
			-VaultId $vault.ID `
			-Item $item;

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "AzureVM";

		#check if item is in a rehydrated state
		Assert-True { $item.ProtectionState -eq "ProtectionStopped" }

	}
	finally
	{
		#write cleanup for softdeleted state
	}
}

function Test-AzureVMSetVaultProperty
{
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location
	try
	{
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		$VaultProperty = Get-AzRecoveryServicesVaultProperty -VaultId $vault.ID

		Assert-True { $VaultProperty.SoftDeleteFeatureState -eq "Enabled" }

		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"
		$VaultProperty = Get-AzRecoveryServicesVaultProperty -VaultId $vault.ID
		Assert-True { $VaultProperty.SoftDeleteFeatureState -eq "Disabled" }
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMDiskExclusion
{
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location
	$storageType = 'Standard_LRS'
	try
	{
		$saName = Create-SA $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"

		$vm = Create-VM $resourceGroupName $location
		$diskConfig = New-AzDiskConfig -SkuName $storageType -Location $location -CreateOption "Empty" -DiskSizeGB 32
		$dataDisk1 = New-AzDisk -DiskName "disk1" -Disk $diskConfig -ResourceGroupName $resourceGroupName
		$dataDisk2 = New-AzDisk -DiskName "disk2" -Disk $diskConfig -ResourceGroupName $resourceGroupName
		$dataDisk3 = New-AzDisk -DiskName "disk3" -Disk $diskConfig -ResourceGroupName $resourceGroupName

		$vm = Get-AzVM -Name $vm.Name -ResourceGroupName $resourceGroupName 
		$vm = Add-AzVMDataDisk -VM $vm -Name "disk1" -CreateOption "Attach" -ManagedDiskId $dataDisk1.Id -Lun 0
		$vm = Add-AzVMDataDisk -VM $vm -Name "disk2" -CreateOption "Attach" -ManagedDiskId $dataDisk2.Id -Lun 1
		$vm = Add-AzVMDataDisk -VM $vm -Name "disk3" -CreateOption "Attach" -ManagedDiskId $dataDisk3.Id -Lun 2

		Update-AzVM -VM $vm -ResourceGroupName $resourceGroupName

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID -Name "DefaultPolicy";

		$arr = ("0", "1")

		Enable-AzRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Name $vm.Name `
		-Policy $policy `
		-InclusionDisksList $arr `
		-ResourceGroupName	$resourceGroupName;

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-BackupManagementType "AzureVM" `
			-WorkloadType "AzureVM";

		$arr = ("1", "2")

		Enable-AzRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $item `
		-ExclusionDisksList $arr;

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-BackupManagementType "AzureVM" `
			-WorkloadType "AzureVM";

		Assert-True { $item.DiskLunList.Count -eq 2}
		Assert-True { $item.DiskLunList[0] -eq 1}
		Assert-True { $item.DiskLunList[1] -eq 2}
		Assert-True { $item.IsInclusionList -eq $false}

		$backupJob = Backup-Item $vault $item
		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);
		$rp = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-Item $item `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime;

		$arr = ("0")

		$restoreJob = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-RestoreAsUnmanagedDisks `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $resourceGroupName `
			-RestoreDiskList $arr | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob.Status -eq "Completed" }

		Disable-AzRecoveryServicesBackupProtection `
			-Item $item `
			-VaultId $vault.ID `
			-RemoveRecoveryPoints `
			-Force;

	}
	finally
	{
		cleanup-ResourceGroup $resourceGroupName
	}
}
