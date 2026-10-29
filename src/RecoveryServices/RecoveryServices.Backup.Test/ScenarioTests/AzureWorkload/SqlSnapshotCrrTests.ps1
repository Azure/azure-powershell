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

# SQL snapshot CRR fixture.
# SourceContainerName/TargetContainerName are native AzureVMAppContainer names, not VM friendly names.
# The source needs replicated instance snapshots and database logs. The target Windows SQL VM must
# already be registered with its vault in SecondaryRegion, with snapshot-restore UAMI permissions.
# Run Command's LocalSystem account needs SQL permission to read sys.databases. No SQL password is used.
# Restore tests run serially, fail on existing destination names, and leave restored databases for inspection.
$script:SqlSnapshotCrrSettings = @{
	SourceResourceGroup = "abhinksql3ccy"
	SourceVaultName = "abhinksql3ccy"
	SourceContainerName = "VMAppContainer;compute;abhinksql3ccy;abhinksql3ccy"
	SourceInstanceItemName = "SQLInstance;mssqlserver"
	SourceDatabaseItemName = "SQLDataBase;mssqlserver;newdb"
	TargetVaultResourceGroup = "abhinksqlRg"
	TargetVaultName = "abhinksql"
	TargetContainerName = "VMAppContainer;Compute;abhinksqlRg;abhinksql"
	TargetInstanceName = "mssqlserver"
	TargetResourceGroup = "abhinksqlrg"
	TargetVmName = "abhinksql"
	SecondaryRegion = "eastus2euap"
	UserAssignedIdentityId = "/subscriptions/935cff54-7d3c-49cc-a1e0-a9aa8bf006f5/resourcegroups/abhinksqlRg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sqlmi"
	# Map every SourceFilesystemInfo.AccessPaths entry to a safe destination volume path.
	TargetPathBySourcePath = @{ "F:\" = "J:\"; "G:\" = "K:\" }
	DatabaseTargetPathBySourcePath = @{ "F:\" = "L:\"; "G:\" = "M:\" }
	InstanceRestoreSuffix = "crr_instance_pit"
	DatabaseRestoreName = "sql_snapshot_crr_restore"
	JobTimeoutSeconds = 7200
}

function Get-SqlSnapshotCrrSource
{
	param([switch] $IncludeDatabase)

	foreach ($key in @("SourceResourceGroup", "SourceVaultName", "SourceContainerName", "SourceInstanceItemName"))
	{
		if ([string]::IsNullOrWhiteSpace($script:SqlSnapshotCrrSettings[$key]))
		{
			throw "SQL snapshot CRR fixture setting '$key' must be populated before recording."
		}
	}

	$vault = Get-AzRecoveryServicesVault -ResourceGroupName $script:SqlSnapshotCrrSettings.SourceResourceGroup `
		-Name $script:SqlSnapshotCrrSettings.SourceVaultName -ErrorAction Stop
	$null = Assert-NotNullOrEmpty $vault.ID
	$items = @(Get-AzRecoveryServicesBackupItem -BackupManagementType AzureWorkload -WorkloadType MSSQLInstance `
		-Name $script:SqlSnapshotCrrSettings.SourceInstanceItemName -VaultId $vault.ID -UseSecondaryRegion -ErrorAction Stop |
		Where-Object { $_.ContainerName -eq $script:SqlSnapshotCrrSettings.SourceContainerName -and
			$_.Name -eq $script:SqlSnapshotCrrSettings.SourceInstanceItemName })
	$null = Assert-AreEqual 1 $items.Count
	$null = Assert-NotNullOrEmpty $items[0].ProtectedItemDataSourceId
	$source = @{ Vault = $vault; Instance = $items[0] }

	if ($IncludeDatabase)
	{
		if ([string]::IsNullOrWhiteSpace($script:SqlSnapshotCrrSettings.SourceDatabaseItemName))
		{
			throw "SQL snapshot CRR fixture setting 'SourceDatabaseItemName' must be populated before recording."
		}
		$databases = @(Get-AzRecoveryServicesBackupItem -BackupManagementType AzureWorkload -WorkloadType MSSQL `
			-Name $script:SqlSnapshotCrrSettings.SourceDatabaseItemName -VaultId $vault.ID -UseSecondaryRegion -ErrorAction Stop |
			Where-Object { $_.ContainerName -eq $script:SqlSnapshotCrrSettings.SourceContainerName -and
				$_.Name -eq $script:SqlSnapshotCrrSettings.SourceDatabaseItemName })
		$null = Assert-AreEqual 1 $databases.Count
		$null = Assert-True { $databases[0].ProtectionLevel -eq "DatabaseUnderInstance" -or
			-not [string]::IsNullOrEmpty($databases[0].ParentProtectedItem) }
		$source.Database = $databases[0]
	}
	return $source
}

function Get-SqlSnapshotCrrRecoveryPoint
{
	param($Vault, $Item)

	$null = Assert-NotNull $Item.LastBackupTime
	$points = @(Get-AzRecoveryServicesBackupRecoveryPoint -Item $Item -VaultId $Vault.ID `
		-StartDate $Item.LastBackupTime.AddDays(-30) -EndDate $Item.LastBackupTime.AddDays(1) `
		-RestorePointQueryType Snapshot -UseSecondaryRegion -ErrorAction Stop |
		Sort-Object RecoveryPointTime -Descending)
	$null = Assert-True { $points.Count -gt 0 }
	$point = Get-AzRecoveryServicesBackupRecoveryPoint -Item $Item -VaultId $Vault.ID `
		-RecoveryPointId $points[0].RecoveryPointId -UseSecondaryRegion -ErrorAction Stop
	$null = Assert-AreEqual $points[0].RecoveryPointId $point.RecoveryPointId
	$null = Assert-NotNull $point.SnapshotRecoveryPointInfo
	$null = Assert-True { $point.SnapshotRecoveryPointInfo.SourceFilesystemInfo.Count -gt 0 }
	foreach ($filesystem in $point.SnapshotRecoveryPointInfo.SourceFilesystemInfo)
	{
		$null = Assert-True { $filesystem.AccessPaths.Count -gt 0 }
		foreach ($path in $filesystem.AccessPaths)
		{
			$null = Assert-NotNullOrEmpty $path
		}
	}
	return $point
}

function Get-SqlSnapshotCrrLogPointInTime
{
	param($Source, $Snapshot, [object[]] $DatabaseItems = @($Source.Database))

	$null = Assert-True { $DatabaseItems.Count -gt 0 }
	$startDate = $Snapshot.RecoveryPointTime.ToUniversalTime()
	$rangesPerDatabase = @()
	foreach ($database in $DatabaseItems)
	{
		$null = Assert-NotNull $database.LastBackupTime
		$endDate = $database.LastBackupTime.ToUniversalTime()
		$null = Assert-True { $endDate -ge $startDate }
		$ranges = @(Get-AzRecoveryServicesBackupRecoveryLogChain -Item $database -VaultId $Source.Vault.ID `
			-StartDate $startDate -EndDate $endDate `
			-UseSecondaryRegion -RecoveryMode SnapshotAttachAndRecover `
			-BaseSnapshotRecoveryPointId $Snapshot.RecoveryPointId `
			-BaseRecoveryPointDatasourceId $Source.Instance.ProtectedItemDataSourceId -ErrorAction Stop)
		$null = Assert-True { $ranges.Count -gt 0 }
		foreach ($range in $ranges)
		{
			$null = Assert-NotNull $range.StartTime
			$null = Assert-NotNull $range.EndTime
			$null = Assert-True { $range.StartTime -le $range.EndTime }
		}
		$rangesPerDatabase += @{ Ranges = $ranges }
	}
	# The latest common time must be a range end; check each candidate against every database.
	$candidates = @($rangesPerDatabase | ForEach-Object { $_.Ranges } |
		ForEach-Object { $_.EndTime.ToUniversalTime() } | Sort-Object -Descending -Unique)
	foreach ($pointInTime in $candidates)
	{
		if ($pointInTime -lt $startDate)
		{
			continue
		}
		$uncoveredDatabases = @($rangesPerDatabase | Where-Object {
			$coveringRanges = @($_.Ranges | Where-Object {
				$_.StartTime.ToUniversalTime() -le $pointInTime -and
					$_.EndTime.ToUniversalTime() -ge $pointInTime
			})
			$coveringRanges.Count -eq 0
		})
		if ($uncoveredDatabases.Count -eq 0)
		{
			return $pointInTime
		}
	}
	throw "No common secondary-region log recovery time exists for all included databases on or after the selected snapshot."
}

function Get-SqlSnapshotCrrTarget
{
	param($SourceVault)

	foreach ($key in @("TargetVaultResourceGroup", "TargetVaultName", "TargetContainerName", "TargetInstanceName",
		"TargetResourceGroup", "TargetVmName", "SecondaryRegion", "UserAssignedIdentityId"))
	{
		if ([string]::IsNullOrWhiteSpace($script:SqlSnapshotCrrSettings[$key]))
		{
			throw "SQL snapshot CRR fixture setting '$key' must be populated before recording."
		}
	}
	$vault = Get-AzRecoveryServicesVault -ResourceGroupName $script:SqlSnapshotCrrSettings.TargetVaultResourceGroup `
		-Name $script:SqlSnapshotCrrSettings.TargetVaultName -ErrorAction Stop
	$vm = Get-AzVM -ResourceGroupName $script:SqlSnapshotCrrSettings.TargetResourceGroup `
		-Name $script:SqlSnapshotCrrSettings.TargetVmName -ErrorAction Stop
	$null = Assert-AreEqual $script:SqlSnapshotCrrSettings.SecondaryRegion $vm.Location
	$null = Assert-AreEqual $vm.Location $vault.Location
	$null = Assert-AreNotEqual $SourceVault.Location $vm.Location
	$containers = @(Get-AzRecoveryServicesBackupContainer -ContainerType AzureVMAppContainer `
		-BackupManagementType AzureWorkload -VaultId $vault.ID -ErrorAction Stop |
		Where-Object { $_.Name -eq $script:SqlSnapshotCrrSettings.TargetContainerName })
	$null = Assert-AreEqual 1 $containers.Count
	$null = Assert-AreEqual $vm.ID $containers[0].SourceResourceId
	$instances = @(Get-AzRecoveryServicesBackupProtectableItem -Container $containers[0] -WorkloadType MSSQL `
		-ItemType SQLInstance -VaultId $vault.ID -ErrorAction Stop |
		Where-Object { $_.FriendlyName -eq $script:SqlSnapshotCrrSettings.TargetInstanceName })
	$null = Assert-AreEqual 1 $instances.Count
	return @{ Container = $containers[0]; Instance = $instances[0]; VM = $vm }
}

function Set-SqlSnapshotCrrRestorePaths
{
	param($Config, [string] $MappingType, [switch] $NoRecoveryMode,
		[hashtable] $TargetPathBySourcePath = $script:SqlSnapshotCrrSettings.TargetPathBySourcePath)

	$null = Assert-AreEqual "SnapshotAttachAndRecover" $Config.RecoveryMode
	$null = Assert-AreEqual "No" $Config.OverwriteWLIfpresent
	$expectedMode = if ($NoRecoveryMode) { "Enabled" } else { "Disabled" }
	$null = Assert-AreEqual $expectedMode $Config.NoRecoveryMode
	$null = Assert-AreEqual $script:SqlSnapshotCrrSettings.TargetResourceGroup $Config.TargetResourceGroupName
	$null = Assert-AreEqual $script:SqlSnapshotCrrSettings.UserAssignedIdentityId $Config.UserAssignedIdentityId
	$null = Assert-True { $Config.targetPhysicalPath.Count -gt 0 }
	foreach ($mapping in $Config.targetPhysicalPath)
	{
		$null = Assert-AreEqual $MappingType $mapping.MappingType
		if (-not $TargetPathBySourcePath.ContainsKey($mapping.SourcePath) -or
			[string]::IsNullOrWhiteSpace($TargetPathBySourcePath[$mapping.SourcePath]))
		{
			throw "A destination volume path must be configured for source path '$($mapping.SourcePath)'."
		}
		$mapping.TargetPath = $TargetPathBySourcePath[$mapping.SourcePath]
	}
}

function Get-SqlSnapshotCrrDatabaseState
{
	param([string[]] $DatabaseNames, [string[]] $UnusedVolumePaths)

	$null = Assert-True { $DatabaseNames.Count -gt 0 }
	$sqlInstance = "."
	if ($script:SqlSnapshotCrrSettings.TargetInstanceName -ne "mssqlserver")
	{
		$sqlInstance = ".\$($script:SqlSnapshotCrrSettings.TargetInstanceName)"
	}
	$arguments = @{ Instance = $sqlInstance; Databases = $DatabaseNames; UnusedVolumePaths = $UnusedVolumePaths } |
		ConvertTo-Json -Compress
	$encodedArguments = [Convert]::ToBase64String([Text.Encoding]::UTF8.GetBytes($arguments))
	# Query only the expected database names; use parameters rather than interpolating SQL identifiers.
	$queryScript = @'
$ErrorActionPreference = "Stop"
$arguments = [Text.Encoding]::UTF8.GetString([Convert]::FromBase64String("__ARGUMENTS__")) | ConvertFrom-Json
foreach ($path in $arguments.UnusedVolumePaths)
{
	if (Test-Path -LiteralPath $path)
	{
		throw "Restore destination volume path '$path' is already in use."
	}
}
$connectionString = New-Object System.Data.SqlClient.SqlConnectionStringBuilder
$connectionString["Data Source"] = $arguments.Instance
$connectionString["Initial Catalog"] = "master"
$connectionString["Integrated Security"] = $true
$connectionString["Encrypt"] = $true
$connectionString["TrustServerCertificate"] = $true
$connection = New-Object System.Data.SqlClient.SqlConnection($connectionString.ConnectionString)
try
{
	$connection.Open()
	$command = $connection.CreateCommand()
	$command.CommandTimeout = 120
	$parameters = @()
	foreach ($name in $arguments.Databases)
	{
		$parameterName = "@db" + $parameters.Count
		$parameters += $parameterName
		$parameter = $command.Parameters.Add($parameterName, [System.Data.SqlDbType]::NVarChar, 128)
		$parameter.Value = $name
	}
	$command.CommandText = "SELECT name, state_desc FROM sys.databases WHERE name IN (" + ($parameters -join ",") + ")"
	$table = New-Object System.Data.DataTable
	$table.Load($command.ExecuteReader())
	$states = @($table.Rows | ForEach-Object { @{ Name = $_.name; State = $_.state_desc } })
	"SQL_SNAPSHOT_CRR_RESULT:" + (ConvertTo-Json -InputObject $states -Compress)
}
finally
{
	$connection.Dispose()
}
'@
	$result = Invoke-AzVMRunCommand -ResourceGroupName $script:SqlSnapshotCrrSettings.TargetResourceGroup `
		-VMName $script:SqlSnapshotCrrSettings.TargetVmName -CommandId RunPowerShellScript `
		-ScriptString $queryScript.Replace("__ARGUMENTS__", $encodedArguments) -ErrorAction Stop
	$lines = @($result.Value | ForEach-Object { $_.Message -split "\r?\n" } |
		Where-Object { $_.StartsWith("SQL_SNAPSHOT_CRR_RESULT:") })
	if ($lines.Count -ne 1)
	{
		throw "SQL database verification did not return one result. Run Command output: $($result.Value.Message -join '; ')"
	}
	return ($lines[0].Substring("SQL_SNAPSHOT_CRR_RESULT:".Length) | ConvertFrom-Json)
}

function Invoke-SqlSnapshotCrrRestore
{
	param($Vault, $Config, [string[]] $ExpectedDatabaseNames,
		[ValidateSet("ONLINE", "RESTORING")] [string] $ExpectedDatabaseState = "ONLINE")

	$targetPaths = @($Config.targetPhysicalPath | ForEach-Object { $_.TargetPath })
	Assert-AreEqual 0 @(Get-SqlSnapshotCrrDatabaseState -DatabaseNames $ExpectedDatabaseNames -UnusedVolumePaths $targetPaths).Count
	$job = Restore-AzRecoveryServicesBackupItem -WLRecoveryConfig $Config -VaultId $Vault.ID `
		-VaultLocation $Vault.Location -RestoreToSecondaryRegion -ErrorAction Stop
	Assert-NotNullOrEmpty $job.JobId
	Wait-SqlSnapshotCrrRestore -Vault $Vault -JobId $job.JobId -ExpectedDatabaseNames $ExpectedDatabaseNames `
		-ExpectedDatabaseState $ExpectedDatabaseState
}

function Wait-SqlSnapshotCrrRestore
{
	param($Vault, [string] $JobId, [string[]] $ExpectedDatabaseNames,
		[ValidateSet("ONLINE", "RESTORING")] [string] $ExpectedDatabaseState = "ONLINE")

	$pollIntervalSeconds = 30
	$maxPolls = [int][Math]::Ceiling($script:SqlSnapshotCrrSettings.JobTimeoutSeconds / $pollIntervalSeconds)
	for ($attempt = 0; $attempt -lt $maxPolls; $attempt++)
	{
		$job = Get-AzRecoveryServicesBackupJobDetail -JobId $JobId -VaultId $Vault.ID `
			-VaultLocation $Vault.Location -UseSecondaryRegion -ErrorAction Stop
		if ($job.Status -notin @("InProgress", "Queued", "NotStarted"))
		{
			break
		}
		Start-TestSleep -Seconds $pollIntervalSeconds
	}
	if ($job.Status -ne "Completed")
	{
		throw "SQL snapshot CRR job '$($job.JobId)' did not complete successfully within $($script:SqlSnapshotCrrSettings.JobTimeoutSeconds) seconds. Details: $($job | ConvertTo-Json -Depth 10 -Compress)"
	}
	$states = @(Get-SqlSnapshotCrrDatabaseState -DatabaseNames $ExpectedDatabaseNames)
	Assert-AreEqual $ExpectedDatabaseNames.Count $states.Count
	foreach ($name in $ExpectedDatabaseNames)
	{
		$state = @($states | Where-Object { $_.Name -eq $name })
		Assert-AreEqual 1 $state.Count
		Assert-AreEqual $ExpectedDatabaseState $state[0].State
	}
}

function Test-SqlInstanceSnapshotCrrGetItem
{
	$source = Get-SqlSnapshotCrrSource
	$instances = @(Get-AzRecoveryServicesBackupItem -BackupManagementType AzureWorkload -WorkloadType MSSQLInstance `
		-VaultId $source.Vault.ID -UseSecondaryRegion -ErrorAction Stop |
		Where-Object { $_.ID -eq $source.Instance.ID })
	Assert-AreEqual 1 $instances.Count
	foreach ($item in @($instances[0], $source.Instance))
	{
		Assert-AreEqual "AzureWorkloadSQLInstanceProtectedItem" $item.GetType().Name
		Assert-AreEqual "MSSQL" $item.WorkloadType
		Assert-AreEqual $script:SqlSnapshotCrrSettings.SourceInstanceItemName $item.Name
		Assert-NotNullOrEmpty $item.ProtectedItemDataSourceId
		Assert-True { $item.PSObject.Properties.Name -contains "ChildDatabaseNameList" }
		Assert-True { $item.ChildDatabaseNameList.Count -gt 0 }
		Assert-NotNull $item.InstanceProtectionReadiness
	}
	Assert-AreEqual $source.Instance.ProtectedItemDataSourceId $instances[0].ProtectedItemDataSourceId
}

function Test-SqlSnapshotCrrGetRecoveryPoints
{
	$source = Get-SqlSnapshotCrrSource
	$snapshot = Get-SqlSnapshotCrrRecoveryPoint -Vault $source.Vault -Item $source.Instance
	Assert-True { $snapshot.IncludedDatabases.Count -gt 0 }
	foreach ($database in $snapshot.IncludedDatabases)
	{
		Assert-NotNullOrEmpty $database.DatasourceName
		Assert-NotNullOrEmpty $database.DatasourceId
	}
}

function Test-SqlSnapshotCrrGetRecoveryLogChain
{
	$source = Get-SqlSnapshotCrrSource -IncludeDatabase
	$snapshot = Get-SqlSnapshotCrrRecoveryPoint -Vault $source.Vault -Item $source.Instance
	$pointInTime = Get-SqlSnapshotCrrLogPointInTime -Source $source -Snapshot $snapshot
	Assert-NotNull $pointInTime
}

function Test-SqlInstanceSnapshotCrrPointInTimeRestore
{
	$source = Get-SqlSnapshotCrrSource
	$snapshot = Get-SqlSnapshotCrrRecoveryPoint -Vault $source.Vault -Item $source.Instance
	$target = Get-SqlSnapshotCrrTarget -SourceVault $source.Vault
	Assert-True { $snapshot.IncludedDatabases.Count -gt 0 }
	Assert-NotNullOrEmpty $script:SqlSnapshotCrrSettings.InstanceRestoreSuffix
	$databases = @($snapshot.IncludedDatabases | ForEach-Object {
		$databaseName = "SQLDataBase;" + $_.DatasourceName
		$items = @(Get-AzRecoveryServicesBackupItem -BackupManagementType AzureWorkload -WorkloadType MSSQL `
			-Name $databaseName -VaultId $source.Vault.ID -UseSecondaryRegion -ErrorAction Stop |
			Where-Object { $_.ContainerName -eq $source.Instance.ContainerName -and $_.Name -eq $databaseName })
		$null = Assert-AreEqual 1 $items.Count
		$items[0]
	})
	$pointInTime = Get-SqlSnapshotCrrLogPointInTime -Source $source -Snapshot $snapshot -DatabaseItems $databases
	Assert-True { $pointInTime -gt $snapshot.RecoveryPointTime.ToUniversalTime() }
	$expectedNames = @($snapshot.IncludedDatabases | ForEach-Object {
		($_.DatasourceName -split ";")[-1] + $script:SqlSnapshotCrrSettings.InstanceRestoreSuffix
	})
	$targetName = $target.Instance.FriendlyName + "/*_" + $script:SqlSnapshotCrrSettings.InstanceRestoreSuffix
	$config = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig -RecoveryPoint $snapshot -PointInTime $pointInTime `
		-AlternateWorkloadRestore -TargetItem $target.Instance -TargetContainer $target.Container `
		-TargetResourceGroupName $script:SqlSnapshotCrrSettings.TargetResourceGroup `
		-UserAssignedIdentityId $script:SqlSnapshotCrrSettings.UserAssignedIdentityId `
		-TargetInstanceDatabaseName $targetName -RecoveryMode SnapshotAttachAndRecover -NoRecoveryMode `
		-VaultId $source.Vault.ID -UseSecondaryRegion -ErrorAction Stop
	Assert-AreEqual $target.VM.ID $config.TargetVirtualMachineId
	Assert-AreEqual $targetName $config.TargetInstanceDatabaseName
	Assert-AreEqual $pointInTime $config.PointInTime
	Set-SqlSnapshotCrrRestorePaths -Config $config -MappingType DiskDrives -NoRecoveryMode
	Invoke-SqlSnapshotCrrRestore -Vault $source.Vault -Config $config -ExpectedDatabaseNames $expectedNames `
		-ExpectedDatabaseState RESTORING
}

function Test-SqlDatabaseSnapshotCrrRestore
{
	$source = Get-SqlSnapshotCrrSource -IncludeDatabase
	$snapshot = Get-SqlSnapshotCrrRecoveryPoint -Vault $source.Vault -Item $source.Database
	$target = Get-SqlSnapshotCrrTarget -SourceVault $source.Vault
	$config = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig -RecoveryPoint $snapshot `
		-AlternateWorkloadRestore -TargetItem $target.Instance -TargetContainer $target.Container `
		-TargetResourceGroupName $script:SqlSnapshotCrrSettings.TargetResourceGroup `
		-UserAssignedIdentityId $script:SqlSnapshotCrrSettings.UserAssignedIdentityId `
		-RecoveryMode SnapshotAttachAndRecover -VaultId $source.Vault.ID -UseSecondaryRegion -ErrorAction Stop
	Assert-NotNullOrEmpty $script:SqlSnapshotCrrSettings.DatabaseRestoreName
	$config.RestoredDBName = $script:SqlSnapshotCrrSettings.DatabaseRestoreName
	Assert-AreEqual $target.VM.ID $config.TargetVirtualMachineId
	Assert-AreEqual ([DateTime]::MinValue) $config.PointInTime
	Set-SqlSnapshotCrrRestorePaths -Config $config -MappingType Data `
		-TargetPathBySourcePath $script:SqlSnapshotCrrSettings.DatabaseTargetPathBySourcePath
	Invoke-SqlSnapshotCrrRestore -Vault $source.Vault -Config $config `
		-ExpectedDatabaseNames @($script:SqlSnapshotCrrSettings.DatabaseRestoreName)
}
