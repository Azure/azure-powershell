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
$saName = "afspstestsa"
$saRgName = "afs-pstest-rg" # "pstestrg8895"
$fileShareName = "azurefileshare;7f34af6cfe2f3f3204cfd4d18cd6b37f7dec2c84a2d759ffab3d1367f9e17356" #"AzureFileShare;fs1"
$newPolicyName = "newFilePolicy"
$newHourlyPolicyName = "afsHourlyPolicy"
$scheduleWindowStartTime = "2021-12-22T06:00:00.00+00:00"
$windowStartTime = "6:00:00"

# Setup Instructions:
# 1. Create a resource group
# New-AzResourceGroup -Name $resourceGroupName -Location $location

# 2. Create a storage account and a recovery services vault
# New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $saName -Location $location -SkuName $skuName
# New-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName -Location $Location

# 3. Create a file share in the storage account
# $storageAcct = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $saName
# New-AzureStorageShare -Name $fileShareFriendlyName -Context $storageAcct.Context
function Test-AzureFSVaultPolicy
{
	$resourceGroupName = "iannea-rg"
	$vaultName = "iannea-rsv"
	$policyName = "newFilePolicy"

    $vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

    # Get default policy objects
    $schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles
    Assert-NotNull $schedulePolicy
    $retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject `
		-WorkloadType AzureFiles `
		-BackupTier VaultStandard 
    Assert-NotNull $retentionPolicy
	Assert-True { $retentionPolicy.SnapshotRetentionInDays -eq 5}	

    # Create policy with default backup tier (VaultStandard)
    $policy = New-AzRecoveryServicesBackupProtectionPolicy `
        -VaultId $vault.ID `
        -Name $policyName `
        -WorkloadType AzureFiles `
        -RetentionPolicy $retentionPolicy `
        -SchedulePolicy $schedulePolicy
    Assert-NotNull $policy
    Assert-AreEqual $policy.Name $policyName

    Assert-NotNull $policy
	Assert-NotNull $policy.RetentionPolicy
    Assert-True { $policy.RetentionPolicy.SnapshotRetentionInDays -eq 5}
	

	# Modify VaultStandard Policy
    $retentionPolicy.SnapshotRetentionInDays = 15  # Valid value between 1 and 30
    Set-AzRecoveryServicesBackupProtectionPolicy `
        -VaultId $vault.ID `
        -RetentionPolicy $retentionPolicy `
        -SchedulePolicy $schedulePolicy `
        -Policy $policy
	
    # Validate the updated policy
    $policy = Get-AzRecoveryServicesBackupProtectionPolicy `
         -VaultId $vault.ID `
         -Name $policyName
    Assert-NotNull $policy
	Assert-NotNull $policy.RetentionPolicy
    Assert-True { $policy.RetentionPolicy.SnapshotRetentionInDays -eq 15}

	# Change back to Snapshot tier
	$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject `
		-WorkloadType AzureFiles `
		-BackupTier Snapshot
	Assert-NotNull $retentionPolicy

	Assert-ThrowsContains { Set-AzRecoveryServicesBackupProtectionPolicy `
             -VaultId $vault.ID `
             -RetentionPolicy $retentionPolicy `
             -SchedulePolicy $schedulePolicy `
             -Policy $policy } `
	"Switching the backup tier from vaulted backup to snapshot is not possible. Please create a new policy for snapshot-only backups."

    # Delete policy
    Remove-AzRecoveryServicesBackupProtectionPolicy `
        -VaultId $vault.ID `
        -Policy $policy `
        -Force
    $policy = Get-AzRecoveryServicesBackupProtectionPolicy `
        -VaultId $vault.ID `
        -WorkloadType AzureFiles
    Assert-False { $policy.Name -contains $policyName }
}

function Test-AzureFSPolicy
{
	$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
	# Get default policy objects
	$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles
	Assert-NotNull $schedulePolicy
	$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureFiles
	Assert-NotNull $retentionPolicy

	# Create policy
	$policy = New-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name $newPolicyName `
		-WorkloadType AzureFiles `
		-RetentionPolicy $retentionPolicy `
		-SchedulePolicy $schedulePolicy
	Assert-NotNull $policy
	Assert-AreEqual $policy.Name $newPolicyName

	# Get policy
	$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name $newPolicyName
	Assert-NotNull $policy
	Assert-AreEqual $policy.Name $newPolicyName

	# Get default policy objects (this data is generated partially at random. So, running this again gives different values)
	Assert-NotNull $schedulePolicy
	$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureFiles
	$retentionPolicy.DailySchedule.DurationCountInDays = 31
	Assert-NotNull $retentionPolicy

	# Update policy
	Set-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-RetentionPolicy $retentionPolicy `
		-SchedulePolicy $schedulePolicy `
		-Policy $policy
	$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name $newPolicyName
	Assert-AreEqual $policy.RetentionPolicy.DailySchedule.DurationCountInDays $retentionPolicy.DailySchedule.DurationCountInDays

	# Delete policy
	Remove-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Policy $policy `
		-Force
	$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-WorkloadType AzureFiles
	Assert-False { $policy.Name -contains $newPolicyName }
}

function Test-AzureFSHourlyPolicy
{
	$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
	# Get default policy objects	
	$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles -BackupManagementType AzureStorage -ScheduleRunFrequency Hourly
	$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureFiles -BackupManagementType AzureStorage  -ScheduleRunFrequency Hourly

	# Create hourly policy
	$policy = New-AzRecoveryServicesBackupProtectionPolicy `
		-Name $newHourlyPolicyName -WorkloadType AzureFiles `
		-BackupManagementType AzureStorage -RetentionPolicy $retentionPolicy `
		-SchedulePolicy $schedulePolicy -VaultId $vault.ID

	Assert-NotNull $policy
	Assert-AreEqual $policy.Name $newHourlyPolicyName

	# Modify policy to IST policy
	$timeZone = Get-TimeZone -ListAvailable | Where-Object { $_.Id -match "India" }
	$schedulePolicy.ScheduleRunTimeZone = $timeZone.Id

	$startTime = Get-Date -Date $scheduleWindowStartTime
	$schedulePolicy.ScheduleWindowStartTime = $startTime.ToUniversalTime()

	Set-AzRecoveryServicesBackupProtectionPolicy -Policy $policy -VaultId $vault.ID -SchedulePolicy $schedulePolicy 

	$policy = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $newHourlyPolicyName

	Assert-True { $policy.SchedulePolicy.ScheduleRunTimeZone -match "India" }	

	Assert-True { $policy.SchedulePolicy.ScheduleWindowStartTime.ToString() -match $windowStartTime }
	
	# Modify policy to Russian Standard Time
	$retentionPolicy.DailySchedule.DurationCountInDays = 6
	$schedulePolicy.ScheduleWindowDuration = 14
	$timeZone = Get-TimeZone -ListAvailable | Where-Object { $_.Id -match "Russian Standard Time" }
	$schedulePolicy.ScheduleRunTimeZone = $timeZone.Id

	Set-AzRecoveryServicesBackupProtectionPolicy -Policy $policy -VaultId $vault.ID -SchedulePolicy $schedulePolicy -RetentionPolicy $retentionPolicy
	$policy = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $newHourlyPolicyName

	Assert-True { $policy.SchedulePolicy.ScheduleRunTimeZone -match "Russia" }

	# Delete policy
	Remove-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Policy $policy `
		-Force
	$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-WorkloadType AzureFiles
	Assert-False { $policy.Name -contains $newHourlyPolicyName }
}