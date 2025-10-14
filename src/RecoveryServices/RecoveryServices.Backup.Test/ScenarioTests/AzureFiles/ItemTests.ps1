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

$location = "eastasia" #"southeastasia"
$resourceGroupName = "afs-pstest-rg" #"pstestrg8895"
$vaultName = "afs-pstest-vault" # "pstestrsv8895"
$fileShareFriendlyName = "fs1"
$skuName="Standard_LRS"
$saName = "afspstestsa" # "pstestsa8895"
$saRgName = "afs-pstest-rg" # "pstestrg8895"
$fileShareName = "azurefileshare;d10" # "AzureFileShare;fs1"
$targetSaName = "afspstesttargetsa" #"pstesttargetsa8896"
$targetFileShareName = "fs1"
$targetFolder = "pstestfolder3rty7d7s"
$folderPath = "pstestfolder1bca8f8e"
$filePath = "pstestfolder1bca8f8e/pstestfile1bca8f8e.txt"
$file1 = "file1.txt"
$file2 = "file2.txt"
$policyName = "afspolicy1"
$newPolicyName = "NewAFSBackupPolicy"

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

function Test-AzureFSStopAndResumeProtection
{
    $resourceGroupName = "afs-pstest-rg"
    $vaultName = "afs-pstest-vault"
    $policyName = "afspolicy1"
    $storageAccountName = "afspstestsa"
    $fileShareFriendlyName = "donotuse-powershell-fileshare"

    try
    {
        # Get the Recovery Services vault
        $vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
        Assert-NotNull $vault

        # Get the backup protection policy
        $policy = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $policyName
        Assert-NotNull $policy

        # Get the backup container
        $container = Get-AzRecoveryServicesBackupContainer -ContainerType AzureStorage -FriendlyName $storageAccountName -VaultId $vault.ID
        Assert-NotNull $container

        # Get the backup item
        $backupItem = Get-AzRecoveryServicesBackupItem -Container $container -WorkloadType AzureFiles -VaultId $vault.ID -FriendlyName $fileShareFriendlyName
        Assert-NotNull $backupItem
		Assert-True { $backupItem.ProtectionState -eq "ProtectionStopped" }

        # Enable protection
        Enable-AzRecoveryServicesBackupProtection -Item $backupItem -Policy $policy -VaultId $vault.ID

        # Refresh backup item to get updated state
        $backupItem = Get-AzRecoveryServicesBackupItem -Container $container -WorkloadType AzureFiles -VaultId $vault.ID -FriendlyName $fileShareFriendlyName

        Assert-True { $backupItem.ProtectionState -eq "IRPending" -or $backupItem.ProtectionState -eq "Protected" }
    }
    finally
    {
        # Disable protection and assert state
        Disable-AzRecoveryServicesBackupProtection -Item $backupItem -VaultId $vault.ID -Force

        # Refresh backup item to get updated state
        $backupItem = Get-AzRecoveryServicesBackupItem -Container $container -WorkloadType AzureFiles -VaultId $vault.ID -FriendlyName $fileShareFriendlyName

        Assert-True { $backupItem.ProtectionState -eq "ProtectionStopped" }
    }
}


function Test-AzureFSRestoreToAnotherRegion
{
	# testing AFS restore to different region and resource group than the source
	$targetFileShareName = "drfs"
	$targetSaName = "afsrestorediffregion2"

	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		Enable-Protection $vault $fileShareFriendlyName $saName

		$items = Get-AzRecoveryServicesBackupItem -VaultId $vault.ID -BackupManagementType AzureStorage -WorkloadType AzureFiles

		$backupJob = Backup-Item $vault $items[0]

		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);

		$rp = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $items[0];
			
		$restoreJob = Restore-AzRecoveryServicesBackupItem -RecoveryPoint $rp[0] -ResolveConflict Overwrite -VaultId $vault.ID -VaultLocation $vault.Location -TargetStorageAccountName $targetSaName -TargetFileShareName $targetFileShareName
		$restoreJob = $restoreJob | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob.Status -eq "Completed" }
	}
	finally
	{
		Cleanup-Vault $vault $items $container
	}
}

function Test-AzureFSItem
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		Enable-Protection $vault $fileShareFriendlyName $saName

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName

		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName
		
		# VARIATION-1: Get all items for container
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-2: Get items for container with ProtectionStatus filter
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-ProtectionStatus Healthy;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-3: Get items for container with Status filter
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-ProtectionState IRPending;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-4: Get items for container with friendly name and ProtectionStatus filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-Name $fileShareFriendlyName `
			-ProtectionStatus Healthy;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-5: Get items for container with friendly name and Status filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-Name $fileShareFriendlyName `
			-ProtectionState IRPending;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-6: Get items for container with Status and ProtectionStatus filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-ProtectionState IRPending `
			-ProtectionStatus Healthy;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-7: Get items for Vault Id and Policy
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Policy $policy;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-8: Get items for container with friendly name, Status and ProtectionStatus filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-Name $fileShareFriendlyName `
			-ProtectionState IRPending `
			-ProtectionStatus Healthy;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }
	}
	finally
	{
		Cleanup-Vault $vault $items $container
	}
}

function Test-AzureFSBackup
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Enable-Protection $vault $fileShareFriendlyName $saName
		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName

		# Trigger backup and wait for completion
		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $backupJob.Status -eq "Completed" }
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}

function Test-AzureFSProtection
{
	try
	{
		$resourceGroupName = "iannea-rg"
		$vaultName = "iannea-rsv"
		$policyName = "afspolicy4"
		$newPolicyName = "afspolicy3"
		$fileShareFriendlyName = "afs0"
		$saName = "iannafstest1"
		$targetSaName = "iannafstest2"
		$targetFileShareName = "afs0"

		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName

		$enableJob = Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $Policy `
			-Name $fileShareFriendlyName `
			-StorageAccountName $saName

		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles
		Assert-True { $item.FriendlyName -contains $fileShareFriendlyName }
		Assert-True { $item.LastBackupStatus -eq "IRPending" }
		Assert-True { $item.ProtectionPolicyName -eq $policyName }
		
		# Modify Policy
		$newPolicy = Get-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name $newPolicyName

		# todo ianna: to fix this command to be able to skip the confirmation prompt when given a Force SwitchParameter to enable test recording and runnable via Script. Currently this command will force user interaction to confirm the operation.
		<# 
		$enableJob =  Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $newPolicy `
			-Item $item -Confirm:$false 
		#>
		
		$item = Get-AzRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles

		Assert-True { $item.FriendlyName -contains $fileShareFriendlyName }
		Assert-True { $item.LastBackupStatus -eq "IRPending" }
		# Assert-True { $item.ProtectionPolicyName -eq $newPolicyName }
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}

function Test-AzureFSGetRPs
{
	try
	{
		# Test 1: Get latest recovery point; should be only one
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Enable-Protection $vault $fileShareFriendlyName $saName
		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName
		$backupJob = Backup-Item $vault $item

		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);

		$recoveryPoint = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item;
	
		Assert-NotNull $recoveryPoint[0];
		Assert-True { $recoveryPoint[0].Id -match $item.Id };

		# Test 2: Get Recovery point detail
		$recoveryPointDetail = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-RecoveryPointId $recoveryPoint[0].RecoveryPointId `
			-Item $item;
	
		Assert-NotNull $recoveryPointDetail;
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}

function Test-AzureFSFullRestore
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Enable-Protection $vault $fileShareFriendlyName $saName
		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName
		$backupJob = Backup-Item $vault $item

		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);

		$recoveryPoint = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item;

		Assert-ThrowsContains { Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-TargetStorageAccountName $targetSaName `
			-TargetFolder $targetFolder } `
			"Provide TargetFileShareName for Alternate Location restore or remove TargetStorageAccountName for Original Location restore"

		Assert-ThrowsContains { Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-TargetFileShareName $targetFileShareName `
			-TargetFolder $targetFolder } `
			"Provide TargetStorageAccountName for Alternate Location restore or remove TargetFileShareName for Original Location restore"

		Assert-ThrowsContains { Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
		  	-VaultLocation $vault.Location `
		  	-RecoveryPoint $recoveryPoint[0] `
		  	-ResolveConflict Overwrite `
		  	-SourceFileType File } `
		  	"Provide SourceFilePath for File restore or remove SourceFileType for file share restore"

		Assert-ThrowsContains { Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-SourceFilePath $filePath } `
			"Provide SourceFileType for File restore or remove SourceFilePath for file share restore"
			
		# Multiple Files Restore
		$files = ($file1, $file2)
		$restoreJob = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-MultipleSourceFilePath $files `
			-SourceFileType File `
			-ResolveConflict Overwrite 
			
		$restoreJob =  $restoreJob	| Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob.Status -eq "Completed" }
    
		# Test without storage account dependency
		# Item level restore at alternate location
		$restoreJob1 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-SourceFilePath $folderPath `
			-SourceFileType Directory `
			-TargetStorageAccountName $targetSaName `
			-TargetFileShareName $targetFileShareName `
			-TargetFolder $targetFolder 
		
		$restoreJob1 = $restoreJob1 | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob1.Status -eq "Completed" }
    
		# Test without storage account dependency
		# Full share restore at alternate location
		$restoreJob2 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-TargetStorageAccountName $targetSaName `
			-TargetFileShareName $targetFileShareName `
			-TargetFolder $targetFolder

		$restoreJob2 = $restoreJob2 | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID
		Assert-True { $restoreJob2.Status -eq "Completed" }

		# Test without storage account dependency
		# Item level restore at original location
		$restoreJob3 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-SourceFilePath $filePath `
			-SourceFileType File 

		$restoreJob3 | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob3.Status -eq "Completed" }

		# Test without storage account dependency
		# Full share restore at original location
		$restoreJob4 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite
		
		$restoreJob4= $restoreJob4 | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob4.Status -eq "Completed" }
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}

function Test-AzureFSVaultRestore
{
	# todo ianna: to resolve recording this test case.
	try
	{
		$subscriptionId = "59e574f1-e278-4b66-875b-e3e4fe74ad88"
		$resourceGroupName = "iannea-rg"
		$vaultName = "iannea-rsv"
		$policyName = "afspolicypstest"
		$newPolicyName = "afsvaultpstest"
		$fileShareFriendlyName = "afs0"
		$saName = "iannafstest4"
		$targetSaName = "iannafstest1"
		$targetFileShareName = "afs0"

		# Get Vault
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

		# Get default schedule policy object
		$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles
		Assert-NotNull $schedulePolicy

		# Create retention policy with VaultStandard backup tier 
		$vaultRetentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject `
			-WorkloadType AzureFiles `
			-BackupTier VaultStandard 

		# Create retention policy with Snapshot backup tier 
		$snapshotRetentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject `
			-WorkloadType AzureFiles `
			-BackupTier Snapshot

		# Create policy 
		$snapshotPolicy = New-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName `
			-WorkloadType AzureFiles `
			-RetentionPolicy $snapshotRetentionPolicy `
			-SchedulePolicy $schedulePolicy
		
		$vaultPolicy = New-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $newPolicyName `
			-WorkloadType AzureFiles `
			-RetentionPolicy $vaultRetentionPolicy `
			-SchedulePolicy $schedulePolicy
		
		# Enable protection with VaultStandard policy
		Enable-AzRecoveryServicesBackupProtection `
									-VaultId $vault.ID `
									-Policy $vaultPolicy `
									-Name $fileShareFriendlyName `
									-storageAccountName $saName | Out-Null

		# Modify protection with Snapshot policy
		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName | Where-Object { $_.FriendlyName -eq $saName }

		$item = Get-AzRecoveryServicesBackupItem `
					-VaultId $vault.ID `
					-Container $container `
					-WorkloadType AzureFiles | Where-Object { $_.FriendlyName -eq $fileShareFriendlyName }

		Assert-ThrowsContains { Enable-AzRecoveryServicesBackupProtection `
									-VaultId $vault.ID `
									-Policy $snapshotPolicy `
									-Item $item
		} "Switching the backup tier from vaulted backup to snapshot is not possible. Please create a new policy for snapshot-only backups."

		$item = Get-AzRecoveryServicesBackupItem -VaultId $vault.ID -BackupManagementType AzureStorage -WorkloadType AzureFiles | Where-Object { $_.ContainerName -match $saName + "$"  -and $_.FriendlyName -eq $fileShareFriendlyName}
		
		# Adhoc Backup
		$backupJob = Backup-Item $vault $item

		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);

		# Perform restore with VaultStandard RP	
		$rp = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item;
		
		$restoreJob = Restore-AzRecoveryServicesBackupItem -RecoveryPoint $rp[0] -ResolveConflict Overwrite -VaultId $vault.ID -VaultLocation $vault.Location -TargetStorageAccountName $targetSaName -TargetFileShareName $targetFileShareName | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob.Status -eq "Completed" }
	}
	finally
	{		
		<# Cleanup-Vault $vault $item $container

		# Delete policy
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
         -VaultId $vault.ID `
         -Name $policyName
		
		Remove-AzRecoveryServicesBackupProtectionPolicy `
        -VaultId $vault.ID `
        -Policy $policy `
        -Force

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
         -VaultId $vault.ID `
         -Name $newPolicyName
		
		Remove-AzRecoveryServicesBackupProtectionPolicy `
        -VaultId $vault.ID `
        -Policy $policy `
        -Force
		#>
	}
}

function Test-AzureFSRestoreWithDeletedStorageAccount
	{
		# # Pre-requisites: run these commands in Azure Cloud Shell
		# # SubscriptionId MUST MATCH the one defined in testcredentials.json
		# Set-AzContext -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c"
		# # Resources MUST MATCH the ones defined below in order for the tests to work
		# $testResourceGroupName = "iannafs-pstest-sa-rg-0" 
		# $testVaultName = "ianna-afs-vault-0" 
		# $testSaName = "iannafssa0" 
		# $testTargetSaName = "iannafstarget0" 
		# $testFileShareName = "testshare"
		# $testPolicyName = "vaultstandardpolicy"
		# $testLocation = "eastus"
		# $skuName = "Standard_LRS"
		# $tags = @{                                                                    
		# 	"ManagerAlias" = "nilsha"
		# 	"Workload" = "AFS"
		# 	"TestType" = "Powershell Test"
		# 	"Owner" = "nilsha"
		# 	"Purpose" = "Powershell Test"
		# 	"DeleteBy" = "12-2025"
		# }
		# Write-Host "Creating resource group: $testResourceGroupName"
		# $rg = New-AzResourceGroup -Name $testResourceGroupName -Location $testLocation -Tag $tags
		
		# Write-Host "Creating source storage account: $testSaName"
		# $sourceStorageAccount = New-AzStorageAccount `
		# 	-ResourceGroupName $testResourceGroupName `
		# 	-Name $testSaName `
		# 	-Location $testLocation `
		# 	-AllowBlobPublicAccess $false `
		# 	-SkuName $skuName
		
		# Write-Host "Creating file share: $testFileShareName"
		# $storageContext = $sourceStorageAccount.Context
		# $fileShare = New-AzStorageShare -Name $testFileShareName -Context $storageContext
		
		# Write-Host "Creating target storage account: $testTargetSaName"
		# $targetStorageAccount = New-AzStorageAccount `
		# 	-ResourceGroupName $testResourceGroupName `
		# 	-Name $testTargetSaName `
		# 	-Location $testLocation `
		# 	-AllowBlobPublicAccess $false `
		# 	-SkuName $skuName

		# Write-Host "Creating Recovery Services vault: $testVaultName"
		# $vault = New-AzRecoveryServicesVault `
		#     -Name $testVaultName `
		#     -ResourceGroupName $testResourceGroupName `
		#     -Location $testLocation
		# Assert-NotNull $vault
		# Assert-True { $vault.Name -eq $testVaultName }

		# Write-Host "Creating backup policy with VaultStandard tier"
		# $schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles
		# Assert-NotNull $schedulePolicy

		# $retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject `
		#     -WorkloadType AzureFiles `
		#     -BackupTier VaultStandard
		# Assert-NotNull $retentionPolicy

		# $policy = New-AzRecoveryServicesBackupProtectionPolicy `
		#     -VaultId $vault.ID `
		#     -Name $testPolicyName `
		#     -WorkloadType AzureFiles `
		#     -RetentionPolicy $retentionPolicy `
		#     -SchedulePolicy $schedulePolicy
		# Assert-NotNull $policy
		# Assert-True { $policy.Name -eq $testPolicyName }

		# Write-Host "Enabling protection for file share"
		# $enableJob = Enable-AzRecoveryServicesBackupProtection `
		#     -VaultId $vault.ID `
		#     -Policy $policy `
		#     -Name $testFileShareName `
		#     -StorageAccountName $testSaName 

		# $enableJob = Wait-AzRecoveryServicesBackupJob -Job $enableJob -VaultId $vault.ID
		# Assert-True { $enableJob.Status -eq "Completed" }

		# Write-Host "Getting protected item"
		# $container = Get-AzRecoveryServicesBackupContainer `
		#     -VaultId $vault.ID `
		#     -ContainerType AzureStorage `
		#     -FriendlyName $testSaName
		# Assert-NotNull $container

		# $item = Get-AzRecoveryServicesBackupItem `
		#     -VaultId $vault.ID `
		#     -Container $container `
		#     -WorkloadType AzureFiles `
		#     -Name $testFileShareName
		# Assert-NotNull $item
		# Assert-True { $item.ProtectionState -eq "Protected" -or $item.ProtectionState -eq "IRPending" }

		# Write-Host "Triggering on-demand backup"
		# $backupJob = Backup-AzRecoveryServicesBackupItem `
		#     -VaultId $vault.ID `
		#     -Item $item

		# $backupJob = Wait-AzRecoveryServicesBackupJob -Job $backupJob -VaultId $vault.ID
		# Assert-True { $backupJob.Status -eq "Completed" }
		# Write-Host "Backup completed successfully"

		# Write-Host "Getting recovery point"
		# $backupStartTime = $backupJob.StartTime.AddMinutes(-1)
		# $backupEndTime = $backupJob.EndTime.AddMinutes(1)

		# $recoveryPoints = Get-AzRecoveryServicesBackupRecoveryPoint `
		#     -VaultId $vault.ID `
		#     -Item $item `
		#     -StartDate $backupStartTime `
		#     -EndDate $backupEndTime

		# Assert-NotNull $recoveryPoints
		# Assert-True { $recoveryPoints.Count -gt 0 }
		# $recoveryPoint = $recoveryPoints[0]
		# Write-Host "Recovery point obtained: $($recoveryPoint.RecoveryPointId)"

		# Get-AzResourceLock -ResourceGroupName $testResourceGroupName -ResourceType Microsoft.Storage/storageAccounts -ResourceName $testSaName |
		#     ForEach-Object { Remove-AzResourceLock -LockId $_.LockId -Force }

		# Write-Host "Deleting source storage account: $testSaName"
		# Remove-AzStorageAccount `
		#     -ResourceGroupName $testResourceGroupName `
		#     -Name $testSaName 

		# $deletedAccount = Get-AzStorageAccount `
		#     -ResourceGroupName $testResourceGroupName `
		#     -Name $testSaName `
		#     -ErrorAction SilentlyContinue
		# Assert-Null $deletedAccount
		# Write-Host "Source storage account deleted successfully"
		# Test-specific variables for isolation
		$testResourceGroupName = "iannafs-pstest-sa-rg-1" 
		$testVaultName = "ianna-afs-vault-1" 
		$testSaName = "iannafssa1" 
		$testTargetSaName = "iannafstarget1" 
		$testFileShareName = "testshare"
		$testPolicyName = "vaultstandardpolicy"
		$testLocation = "eastus"
		$tags = @{                                                                    
			"ManagerAlias" = "nilsha"
			"Workload" = "AFS"
			"TestType" = "Powershell Test"
			"Owner" = "nilsha"
			"Purpose" = "Powershell Test"
			"DeleteBy" = "12-2025"
		}
	
		try
		{	
			$vault = Get-AzRecoveryServicesVault -ResourceGroupName $testResourceGroupName -Name $testVaultName
			$container = Get-AzRecoveryServicesBackupContainer `
			  -VaultId $vault.ID `
			  -ContainerType AzureStorage `
			  -FriendlyName $testSaName
			Assert-NotNull $container

			$item = Get-AzRecoveryServicesBackupItem `
			  -VaultId $vault.ID `
			  -Container $container `
			  -WorkloadType AzureFiles `
			  -Name $testFileShareName
			Assert-NotNull $item

			$backupStartTime = (Get-Date).AddDays(-7).ToUniversalTime()
			$backupEndTime = (Get-Date).ToUniversalTime()

			$recoveryPoints = Get-AzRecoveryServicesBackupRecoveryPoint `
			  -VaultId $vault.ID `
			  -Item $item `
			  -StartDate $backupStartTime `
			  -EndDate $backupEndTime

			Assert-NotNull $recoveryPoints
			Assert-True { $recoveryPoints.Count -gt 0 }
			$recoveryPoint = $recoveryPoints[0]

			$restoreJob = Restore-AzRecoveryServicesBackupItem `
			  -VaultId $vault.ID `
			  -VaultLocation $vault.Location `
			  -RecoveryPoint $recoveryPoint `
			  -TargetStorageAccountName $testTargetSaName `
			  -TargetFileShareName $testFileShareName `
			  -ResolveConflict Overwrite 

			$restoreJob = Wait-AzRecoveryServicesBackupJob -Job $restoreJob -VaultId $vault.ID

			Assert-True { $restoreJob.Status -eq "Completed" }
		}
		finally
		{
			# # Cleanup
			# Write-Host "Cleaning up test resources"

			# # Disable protection if item exists
			# if ($null -ne $item)
			# {
			# 	try
			# 	{
			# 		Cleanup-Vault $vault $item $container
			# 	}
			# 	catch
			# 	{
			# 		Write-Host "Warning: Failed to disable protection - may already be disabled"
			# 	}
			# }

			# # Delete resource group (will delete all contained resources)
			# if ($null -ne $testResourceGroupName)
			# {
			# 	try
			# 	{
			# 		Remove-AzResourceGroup `
			# 			-Name $testResourceGroupName `
			# 			-Force `
			# 			-ErrorAction SilentlyContinue
			# 		Write-Host "Test resource group deleted"
			# 	}
			# 	catch
			# 	{
			# 		Write-Host "Warning: Failed to delete resource group"
			# 	}
			# }
		}
	}