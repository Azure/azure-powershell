

function ValidateBackupScheduleOptions {
	[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory)]
		[ValidateNotNullOrEmpty()]
		[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy]
		${Policy},

		[Parameter(Mandatory)]
		[ValidateNotNullOrEmpty()]
		[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
		${DatasourceType},

		[Parameter(Mandatory)]
		[ref]
		${PolicySubType},

		[Parameter(Mandatory)]
		[ref]
		${HourlyInterval},

		[Parameter(Mandatory)]
		[ref]
		${HourlyScheduleWindowDuration},

		[Parameter(Mandatory)]
		[ref]
		${EnableLogBackup},

		[Parameter(Mandatory)]
		[ref]
		${LogBackupFrequencyInMin},

		[Parameter(Mandatory)]
		[ref]
		${EnableDifferentialBackup},

		[Parameter(Mandatory)]
		[ref]
		${DifferentialRunDay},

		[Parameter(Mandatory)]
		[ref]
		${DifferentialScheduleTime},

		[Parameter(Mandatory)]
		[ref]
		${EnableIncrementalBackup},

		[Parameter(Mandatory)]
		[ref]
		${IncrementalRunDay},

		[Parameter(Mandatory)]
		[ref]
		${IncrementalScheduleTime},

		[Parameter(Mandatory)]
		[ref]
		${BackupFrequency},

		[Parameter(Mandatory)]
		[ref]
		${ScheduleRunDay},

		[Parameter(Mandatory)]
		[ref]
		${ScheduleTime}
	)

	process
	{
		Write-Debug "Validating Backup Schedule Options"
		Write-Debug -Message $DatasourceType
		
		# Log all the parameters
		Write-Debug -Message "Policy: $Policy"
		Write-Debug -Message "DatasourceType: $DatasourceType"
		Write-Debug -Message "PolicySubType: $PolicySubType.Value"
		Write-Debug -Message "HourlyInterval: $HourlyInterval.Value"
		Write-Debug -Message "HourlyScheduleWindowDuration: $HourlyScheduleWindowDuration.Value"
		Write-Debug -Message "EnableLogBackup: $EnableLogBackup.Value"
		Write-Debug -Message "LogBackupFrequencyInMin: $LogBackupFrequencyInMin.Value"
		Write-Debug -Message "EnableDifferentialBackup: $EnableDifferentialBackup.Value"
		Write-Debug -Message "DifferentialRunDay: $DifferentialRunDay.Value"
		Write-Debug -Message "DifferentialScheduleTime: $DifferentialScheduleTime.Value"
		Write-Debug -Message "EnableIncrementalBackup: $EnableIncrementalBackup.Value"
		Write-Debug -Message "IncrementalRunDay: $IncrementalRunDay.Value"
		Write-Debug -Message "IncrementalScheduleTime: $IncrementalScheduleTime.Value"
		Write-Debug -Message "BackupFrequency: $BackupFrequency.Value"
		Write-Debug -Message "ScheduleRunDay: $ScheduleRunDay.Value"
		Write-Debug -Message "ScheduleTime: $ScheduleTime.Value"
		
		$manifest = LoadManifest -DatasourceType $DatasourceType
		
		Write-Debug -Message "Manifest: $manifest" 
		
		$FullBackupPolicy = $Policy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
		$LogBackupPolicy = $Policy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Log" }
		$DifferentialPolicy = $Policy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Differential" }
		$IncrementalPolicy = $Policy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Incremental" }
		
		# Validate BackupFrequency
		
		if(-not $BackupFrequency.Value) {
			Write-Debug "BackupFrequency is empty"
			if ($manifest.allowedSubProtectionPolicyTypes.Count -gt 2) {
				# SAPHANA case				
				if(-not $FullBackupPolicy.SchedulePolicy.ScheduleRunFrequency) {
					$errormsg = "BackupFrequency cannot be empty for FullBackup"
					throw $errormsg
				}
				else {
					$BackupFrequency.Value = $FullBackupPolicy.SchedulePolicy.ScheduleRunFrequency
				}
			}
			else {
				# AzureVM case
				Write-Debug "AzureVM case"
				if(-not $Policy.SchedulePolicy.ScheduleRunFrequency) {
					$errormsg = "BackupFrequency cannot be empty for FullBackup"
					throw $errormsg
				}
				else {
					Write-Debug "assigning BackupFrequency"
					$BackupFrequency.Value = $Policy.SchedulePolicy.ScheduleRunFrequency
				}
			}
		}
		
		Write-Debug -Message $BackupFrequency.Value
		
		if (-not $manifest.allowedBackupFrequencies.Contains($BackupFrequency.Value)) {
			$allowedValues = [System.String]::Join(', ', $manifest.allowedBackupFrequencies)
			$errormsg = "Specified BackupFrequency " + $BackupFrequency.Value + " is not supported for DatasourceType " + $DatasourceType + "`nAllowed values are: " + $allowedValues
			throw $errormsg
		}
		
		# Validate ScheduleTime
		
		if(-not $ScheduleTime.Value) {
			if ($manifest.allowedSubProtectionPolicyTypes.Count -gt 2) {
				# SAPHANA case
				Write-Debug "SAPHANA case"
				if($FullBackupPolicy.SchedulePolicy.ScheduleRunTime.Count -lt 1) {
					$errormsg = "ScheduleTime cannot be empty for FullBackup"
					throw $errormsg
				}
				else {
					Write-Debug "$FullBackupPolicy.SchedulePolicy.ScheduleRunTime[0]"
					$ScheduleTime.Value = ($FullBackupPolicy.SchedulePolicy.ScheduleRunTime[0]).toString("h:mm tt")
				}
			}
			else {
				# AzureVM case
				if($Policy.SchedulePolicy.ScheduleRunTime.Count -lt 1) {
					$errormsg = "ScheduleTime cannot be empty for FullBackup"
					throw $errormsg
				}
				else {
					Write-Debug "$Policy.SchedulePolicy.ScheduleRunTime[0]"
					$ScheduleTime.Value = ($Policy.SchedulePolicy.ScheduleRunTime[0]).ToString("h:mm tt")
				}
			}
		}
		
		# Validate ScheduleRunDay
		
		if( (-not $ScheduleRunDay.Value) -and ($BackupFrequency.Value -eq "Weekly") ) {
			if ($manifest.allowedSubProtectionPolicyTypes.Count -gt 2) {
				# SAPHANA case
				if(-not $FullBackupPolicy.SchedulePolicy.ScheduleRunDays) {
					$errormsg = "ScheduleRunDay cannot be empty for Weekly FullBackup"
					throw $errormsg
				}
				else {
					$ScheduleRunDay.Value = $FullBackupPolicy.SchedulePolicy.ScheduleRunDays
				}
			}
			else {
				# AzureVM case
				if(-not $Policy.SchedulePolicy.ScheduleRunDay) {
					$errormsg = "ScheduleRunDay cannot be empty for Weekly FullBackup"
					throw $errormsg
				}
				else {
					$ScheduleRunDay.Value = $Policy.SchedulePolicy.ScheduleRunDays
				}
			}
		}
		
		# Validate PolicySubType
		
		if($PolicySubType.Value -eq "Enhanced") {
			if(-not $manifest.supportsEnhanced) {
				$errormsg = "Enhanced backup policies are not supported by " + $DatasourceType
				throw $errormsg
			}
		}
		
		# Validate Hourly specific parameters
		
		if ($HourlyInterval.Value -or $HourlyScheduleWindowDuration.Value) {
			Write-Debug "Checking Hourly"
			Write-Debug -Message "BackupFrequency is $BackupFrequency.Value and PolicySubType is $PolicySubType.Value"
			if (-not ( ($BackupFrequency.Value -eq "Hourly") -and ($PolicySubType.Value -eq "Enhanced") )) {
				$errormsg = "Hourly parameters can only be set for Enhanced Hourly backups"
				throw $errormsg
			}
		}
		
		if ($BackupFrequency.Value -eq "Hourly") {
			if(-not $HourlyInterval.Value) {
				if(-not $Policy.SchedulePolicy.HourlySchedule.Interval) {
					$errormsg = "HourlyInterval cannot be empty for Hourly backups"
				}
				else {
					$HourlyInterval.Value = $policyObject.SchedulePolicy.HourlySchedule.Interval
				}
			}
		
			if(-not $HourlyScheduleWindowDuration.Value) {
				if(-not $Policy.SchedulePolicy.HourlySchedule.ScheduleWindowDuration) {
					$errormsg = "HourlyScheduleWindowDuration cannot be empty for Hourly backups"
				}
				else {
					$HourlyScheduleWindowDuration.Value = $policyObject.SchedulePolicy.HourlySchedule.ScheduleWindowDuration
				}
			}

			if($HourlyScheduleWindowDuration.Value % $HourlyInterval.Value -ne 0) {
				$errormsg = "HourlyScheduleWindowDuration must be greater than and a multiple of HourlyInterval"
				throw $errormsg
			}

		}
		
		
		# Validate Log Backup parameters
		
		if($EnableLogBackup.Value) {
			if (-not $manifest.allowedSubProtectionPolicyTypes.Contains("Log")) {
				$errormsg = "LogBackup is not supported for DatasourceType " + $DatasourceType
				throw $errormsg
			}
		
			if (-not $LogBackupFrequencyInMin.Value) {
				if($LogBackupPolicy.SchedulePolicy.ScheduleFrequencyInMin) {
					$LogBackupFrequencyInMin.Value = $LogBackupPolicy.SchedulePolicy.ScheduleFrequencyInMin
				}
				else {
					$errormsg = "LogBackupFrequencyInMin cannot be empty for LogBackup"
					throw $errormsg	
				}
			}
		}
		
		# Validate Differential parameters	
		
		if ($EnableDifferentialBackup.Value -or ($DifferentialRunDay.Value) -or ($DifferentialScheduleTime.Value)) {
			if(-not $EnableDifferentialBackup.Value) {
				$errormsg = "Differential backup parameters cannot be set when EnableDifferentialBackup is not set to True, please pass EnableDifferentialBackup as True to enable it."
				throw $errormsg
			}

			if( ( -not $manifest.allowedSubProtectionPolicyTypes.Contains("Differential") ) -or ( ($BackupFrequency.Value -ne "Weekly") ) ) {
				$errormsg = "Differential backups are not supported for " + $BackupFrequency.Value + " " + $DatasourceType + " backups"
				throw $errormsg
			}
		
			if (($IncrementalPolicy -ne $null) -and ($EnableIncrementalBackup.Value -ne "False") ) {
				$errormsg = "Differential backup cannot be enabled when Incremental backup is enabled, pass EnableIncrementalBackup as False to disable it"
				throw $errormsg
			}
		}
		 
		if ($EnableDifferentialBackup.Value) {
			if (-not $DifferentialRunDay.Value) {
				if (-not $DifferentialPolicy.SchedulePolicy.ScheduleRunDay) {
					$errormsg = "DifferentialRunDay cannot be empty for Differential backups"
					throw $errormsg
				}
				else {
					$DifferentialRunDay.Value = $DifferentialPolicy.SchedulePolicy.ScheduleRunDays
				}
			}

			$commonDays = Compare-Object -ReferenceObject $ScheduleRunDay.Value -DifferenceObject $DifferentialRunDay.Value -IncludeEqual -ExcludeDifferent

			if ($commonDays.Count -gt 0) {
				$errormsg = "Differential backups cannot be scheduled on same days as Full backups."
				throw $errormsg	
			}
		
			if (-not $DifferentialScheduleTime.Value) {
				if (-not $DifferentialPolicy.SchedulePolicy.ScheduleRunTime) {
					$errormsg = "DifferentialScheduleTime cannot be empty for Differential backups"
					throw $errormsg
				}
				else {
					$DifferentialScheduleTime.Value = $DifferentialPolicy.SchedulePolicy.ScheduleRunTime[0]
				}
			}
		}				
		
		# Validate Incremental parameters
		
		if ($EnableIncrementalBackup.Value -or ($IncrementalRunDay.Value) -or ($IncrementalScheduleTime.Value)) {

			if (-not $EnableIncrementalBackup.Value) {
				$errormsg = "Incremental backup parameters cannot be set when EnableIncrementalBackup is not set to True, please pass EnableIncrementalBackup as True to enable it."
				throw $errormsg
			}

			if( ( -not $manifest.allowedSubProtectionPolicyTypes.Contains("Incremental") ) -or ( ($BackupFrequency.Value -ne "Weekly") ) ) {
				$errormsg = "Incremental backups are not supported for " + $BackupFrequency.Value + " " + $DatasourceType + " backups"
				throw $errormsg
			}
		
			if (($DifferentialPolicy -ne $null) -and ($EnableDifferentialBackup.Value -ne "False") ) {
				$errormsg = "Incremental backup cannot be enabled when Differential backup is enabled, pass EnableDifferentialBackup as False to disable it"
				throw $errormsg
			}
		}
		
		if ($EnableIncrementalBackup.Value) {
			if (-not $IncrementalRunDay.Value) {
				if (-not $IncrementalPolicy.SchedulePolicy.ScheduleRunDay) {
					$errormsg = "IncrementalRunDay cannot be empty for Incremental backups"
					throw $errormsg
				}
				else {
					$IncrementalRunDay.Value = $IncrementalPolicy.SchedulePolicy.ScheduleRunDays
				}
			}

			$commonDays = Compare-Object -ReferenceObject $ScheduleRunDay.Value -DifferenceObject $IncrementalRunDay.Value -IncludeEqual -ExcludeDifferent

			if ($commonDays.Count -gt 0) {
				$errormsg = "Incremental backups cannot be scheduled on same days as Full backups."
				throw $errormsg	
			}

			if (-not $IncrementalScheduleTime.Value) {
				if (-not $IncrementalPolicy.SchedulePolicy.ScheduleRunTime) {
					$errormsg = "IncrementalScheduleTime cannot be empty for Incremental backups"
					throw $errormsg
				}
				else {
					$IncrementalScheduleTime.Value = $IncrementalPolicy.SchedulePolicy.ScheduleRunTime[0]
				}
			}
		}
		
		Write-Debug "Validating parameters completed"
		
		# Print all parameters to be returned
		Write-Debug -Message "Policy: $Policy"
		Write-Debug -Message "DatasourceType: $DatasourceType"
		Write-Debug -Message "PolicySubType: $PolicySubType.Value"
		Write-Debug -Message "HourlyInterval: $HourlyInterval.Value"
		Write-Debug -Message "HourlyScheduleWindowDuration: $HourlyScheduleWindowDuration.Value"
		Write-Debug -Message "EnableLogBackup: $EnableLogBackup.Value"
		Write-Debug -Message "LogBackupFrequencyInMin: $LogBackupFrequencyInMin.Value"
		Write-Debug -Message "EnableDifferentialBackup: $EnableDifferentialBackup.Value"
		Write-Debug -Message "DifferentialRunDay: $DifferentialRunDay.Value"
		Write-Debug -Message "DifferentialScheduleTime: $DifferentialScheduleTime.Value"
		Write-Debug -Message "EnableIncrementalBackup: $EnableIncrementalBackup.Value"
		Write-Debug -Message "IncrementalRunDay: $IncrementalRunDay.Value"
		Write-Debug -Message "IncrementalScheduleTime: $IncrementalScheduleTime.Value"
		Write-Debug -Message "BackupFrequency: $BackupFrequency.Value"
		Write-Debug -Message "ScheduleRunDay: $ScheduleRunDay.Value"
		Write-Debug -Message "ScheduleTime: $ScheduleTime.Value"
	}
}