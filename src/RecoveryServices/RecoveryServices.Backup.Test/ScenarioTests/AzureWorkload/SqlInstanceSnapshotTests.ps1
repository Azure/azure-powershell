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

# SQL (MSSQL) Instance snapshot backup/restore scenario tests.
#
# To record: set these to a live environment that supports SQL Instance snapshot
# (api-version 2026-10-01) before running the tests in Record mode.
$resourceGroupName = "AzureBackupRG_SQLInstSnapshotGABB"
$vaultName         = "SQLSnapGABBVault1"
$vmFriendlyName    = "SQLInstTestVM1"          # the SQL-in-VM that hosts the instance
$instanceName      = "mssqlserver"             # SQL instance friendly name
$instanceItemName  = "sqlinstance;$instanceName"
$snapshotRG        = "AzureBackupRG_SQLInstSnapshotGABB"
$uamiId            = "/subscriptions/0ffd0773-90c5-472c-807d-0c0a10605b9d/resourceGroups/$resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testmi"
$snapLogPolicyName = "SqlInst-SnapLog-PS-Scenario"
$snapOnlyPolicyName = "SqlInst-SnapOnly-PS-Scenario"

# -------------------------------------------------------------------------------------
# Policy: create a SQL Instance snapshot policy (SnapshotFull + Log) and a snapshot-only policy.
# Validates: workLoadType=SQLInstance, vmWorkloadPolicyType=SnapshotV2, SnapshotFull sub-policy,
# and the snapshotBackupAdditionalDetails (RG, instant-RP retention, UAMI).
# -------------------------------------------------------------------------------------
function Test-AzureVmWorkloadSqlInstanceSnapshotPolicy
{
	$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	$existingPolicies = @(Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID)
	Assert-True { $existingPolicies.Name -notcontains $snapLogPolicyName }
	Assert-True { $existingPolicies.Name -notcontains $snapOnlyPolicyName }
	$createdPolicies = @()

	try
	{
		$sch = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType MSSQLInstance -BackupManagementType AzureWorkload
		$ret = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType MSSQLInstance -BackupManagementType AzureWorkload

		Assert-True { $sch.IsLogBackupEnabled -eq $true }

		$snapLog = New-AzRecoveryServicesBackupProtectionPolicy -Name $snapLogPolicyName -WorkloadType MSSQLInstance `
			-SchedulePolicy $sch -RetentionPolicy $ret `
			-BackupSnapshotResourceGroup $snapshotRG `
			-InstantRPRetentionRangeInDays 5 `
			-UserAssignedIdentityId $uamiId `
			-VaultId $vault.ID
		$createdPolicies += $snapLogPolicyName

		Assert-True { $snapLog.WorkloadType -eq "MSSQLInstance" }
		Assert-AreEqual "SnapshotV2" $snapLog.VMWorkloadPolicyType
		Assert-AreEqual $snapshotRG $snapLog.SnapshotBackupAdditionalDetails.InstantRpDetails
		Assert-AreEqual 5 $snapLog.SnapshotBackupAdditionalDetails.InstantRpRetentionRangeInDays
		Assert-AreEqual $uamiId $snapLog.SnapshotBackupAdditionalDetails.UserAssignedManagedIdentityDetails.IdentityArmId
		Assert-True { $snapLog.IsLogBackupEnabled }

		# snapshot-only (log disabled)
		$sch.IsLogBackupEnabled = $false
		$snapOnly = New-AzRecoveryServicesBackupProtectionPolicy -Name $snapOnlyPolicyName -WorkloadType MSSQLInstance `
			-SchedulePolicy $sch -RetentionPolicy $ret `
			-BackupSnapshotResourceGroup $snapshotRG `
			-InstantRPRetentionRangeInDays 5 `
			-UserAssignedIdentityId $uamiId `
			-VaultId $vault.ID
		$createdPolicies += $snapOnlyPolicyName

		Assert-True { $snapOnly.WorkloadType -eq "MSSQLInstance" }
		Assert-AreEqual "SnapshotV2" $snapOnly.VMWorkloadPolicyType
		Assert-AreEqual $snapshotRG $snapOnly.SnapshotBackupAdditionalDetails.InstantRpDetails
		Assert-AreEqual 5 $snapOnly.SnapshotBackupAdditionalDetails.InstantRpRetentionRangeInDays
		Assert-AreEqual $uamiId $snapOnly.SnapshotBackupAdditionalDetails.UserAssignedManagedIdentityDetails.IdentityArmId
		Assert-True { $snapOnly.IsLogBackupEnabled -eq $false }
	}
	finally
	{
		foreach ($policyName in $createdPolicies)
		{
			Remove-AzRecoveryServicesBackupProtectionPolicy -Name $policyName -VaultId $vault.ID -Force -ErrorAction Stop
		}
	}
}

# -------------------------------------------------------------------------------------
# Item: list SQL Instance protected items and inspect the new model fields.
# Validates: -WorkloadType MSSQLInstance returns instance items with ChildDatabaseNameList
# and InstanceProtectionReadiness populated.
# -------------------------------------------------------------------------------------
function Test-AzureVmWorkloadSqlInstanceItem
{
	$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	$container = Get-AzRecoveryServicesBackupContainer -ContainerType AzureVMAppContainer `
		-BackupManagementType AzureWorkload -VaultId $vault.ID -FriendlyName $vmFriendlyName

	$item = Get-AzRecoveryServicesBackupItem -Container $container `
		-WorkloadType MSSQLInstance -Name $instanceItemName -VaultId $vault.ID

	Assert-NotNull $item
	Assert-True { $item.ProtectedItemDataSourceId -ne $null }
	Assert-True { $item.PSObject.Properties.Name -contains "ChildDatabaseNameList" }
	# ChildDatabaseNameList and InstanceProtectionReadiness are new instance-model fields.
	Assert-True { $item.InstanceProtectionReadiness -ne $null }
}

# -------------------------------------------------------------------------------------
# Recovery points: list snapshot recovery points and read IncludedDatabases + SnapshotRecoveryPointInfo.
# -------------------------------------------------------------------------------------
function Test-AzureVmWorkloadSqlInstanceSnapshotRecoveryPoint
{
	$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	$container = Get-AzRecoveryServicesBackupContainer -ContainerType AzureVMAppContainer `
		-BackupManagementType AzureWorkload -VaultId $vault.ID -FriendlyName $vmFriendlyName
	$item = Get-AzRecoveryServicesBackupItem -Container $container `
		-WorkloadType MSSQLInstance -Name $instanceItemName -VaultId $vault.ID

	$snapRps = Get-AzRecoveryServicesBackupRecoveryPoint -Item $item `
		-StartDate $item.LastBackupTime.AddDays(-30) -EndDate $item.LastBackupTime.AddDays(1) `
		-RestorePointQueryType Snapshot -VaultId $vault.ID |
		Sort-Object RecoveryPointTime -Descending
	Assert-True { $snapRps.Count -gt 0 }

	# Fetch by id to get the populated extended info (IncludedDatabases + SnapshotRecoveryPointInfo).
	$rp = Get-AzRecoveryServicesBackupRecoveryPoint -Item $item `
		-RecoveryPointId $snapRps[0].RecoveryPointId -VaultId $vault.ID
	Assert-NotNull $rp.IncludedDatabases
	Assert-NotNull $rp.SnapshotRecoveryPointInfo
}

# -------------------------------------------------------------------------------------
# On-demand backup: trigger a SnapshotFull backup of the SQL Instance.
# -------------------------------------------------------------------------------------
function Test-AzureVmWorkloadSqlInstanceSnapshotBackup
{
	$resourceGroupName = "chandrikarg"
	$vaultName = "olrrsv"
	$vmFriendlyName = "testovm"
	$instanceItemName = "SQLInstance;mssqlserver"

	$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	$container = Get-AzRecoveryServicesBackupContainer -ContainerType AzureVMAppContainer `
		-BackupManagementType AzureWorkload -VaultId $vault.ID -FriendlyName $vmFriendlyName
	$item = Get-AzRecoveryServicesBackupItem -Container $container `
		-WorkloadType MSSQLInstance -Name $instanceItemName -VaultId $vault.ID

	Assert-NotNull $item
	Assert-AreEqual "Protected" $item.ProtectionState
	$endDate = $item.LastBackupTime.AddDays(45).ToUniversalTime()
	$job = Backup-AzRecoveryServicesBackupItem -Item $item -BackupType SnapshotFull `
		-VaultId $vault.ID -ExpiryDateTimeUTC $endDate |
		Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID
	Assert-NotNull $job
	Assert-AreEqual "Completed" $job.Status
}

# -------------------------------------------------------------------------------------
# Restore config: build a SQL Instance snapshot OLR config and validate the surfaced
# source volume paths (customer-supplied target paths) and required params.
# -------------------------------------------------------------------------------------
function Test-AzureVmWorkloadSqlInstanceSnapshotRestoreConfig
{
	$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	$container = Get-AzRecoveryServicesBackupContainer -ContainerType AzureVMAppContainer `
		-BackupManagementType AzureWorkload -VaultId $vault.ID -FriendlyName $vmFriendlyName
	$item = Get-AzRecoveryServicesBackupItem -Container $container `
		-WorkloadType MSSQLInstance -Name $instanceItemName -VaultId $vault.ID

	$snapRps = Get-AzRecoveryServicesBackupRecoveryPoint -Item $item `
		-StartDate $item.LastBackupTime.AddDays(-30) -EndDate $item.LastBackupTime.AddDays(1) `
		-RestorePointQueryType Snapshot -VaultId $vault.ID |
		Sort-Object RecoveryPointTime -Descending
	Assert-True { $snapRps.Count -gt 0 }
	$snapRp = Get-AzRecoveryServicesBackupRecoveryPoint -Item $item `
		-RecoveryPointId $snapRps[0].RecoveryPointId -VaultId $vault.ID

	$cfg = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig `
		-RecoveryPoint $snapRp -OriginalWorkloadRestore `
		-TargetResourceGroupName $snapshotRG `
		-UserAssignedIdentityId $uamiId `
		-VaultId $vault.ID

	Assert-NotNull $cfg
	# Source volume paths surface with blank target paths for the customer to fill.
	Assert-True { $cfg.targetPhysicalPath.Count -gt 0 }
}
