
# Backup Schedule helper
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

# Retention helpers
function ValidateDaysOfTheWeek {
	[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $DatasourceType,

		[Parameter(Mandatory=$false)]
        [string[]]
        ${WeeklyRetentionDaysOfTheWeek},   

        [Parameter(Mandatory=$false)]
        [string[]]
        ${MonthlyRetentionDaysOfTheWeek},
        
        [Parameter(Mandatory=$false)]
        [string[]]
        ${YearlyRetentionDaysOfTheWeek} 

	)

	process
	{
        Write-Debug "Validating Days of the week Options"
        Write-Debug -Message $DatasourceType
        Write-Debug -Message ($WeeklyRetentionDaysOfTheWeek -join ', ')
        Write-Debug -Message ($MonthlyRetentionDaysOfTheWeek -join ', ')
        Write-Debug -Message ($YearlyRetentionDaysOfTheWeek -join ', ')

        $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
        $allowedValues = [System.String]::Join(', ', $manifest.allowedDaysOfTheWeek)

        foreach ($day in $WeeklyRetentionDaysOfTheWeek) 
        {
            if ($day -notin $manifest.allowedDaysOfTheWeek) 
            {
                $errormsg = "Specified WeekDay is not supported: $day. Allowed values are: $allowedValues"
                throw $errormsg
            }
        }

        foreach ($day in $MonthlyRetentionDaysOfTheWeek) {
            if ($day -notin $manifest.allowedDaysOfTheWeek) {
                $errormsg = "Specified WeekDay is not supported: $day. Allowed values are: $allowedValues"
                throw $errormsg
            }
        }

        foreach ($day in $YearlyRetentionDaysOfTheWeek) 
        {
            if ($day -notin $manifest.allowedDaysOfTheWeek) 
            {
                $errormsg = "Specified WeekDay is not supported: $day. Allowed values are: $allowedValues"
                throw $errormsg
            }
        }  
	}
}

function ValidateMonthsOfTheYear {
	[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $DatasourceType,

		[Parameter(Mandatory=$false)]
        [string[]]
        ${YearlyRetentionMonthsOfTheYear}

	)

	process
	{
        Write-Debug "Validating Months of the year Options"
        Write-Debug -Message $DatasourceType
        Write-Debug -Message ($YearlyRetentionMonthsOfTheYear -join ', ')
        

        $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
        $allowedValues = [System.String]::Join(', ', $manifest.allowedMonthsOfTheYear)

        foreach ($month in $YearlyRetentionMonthsOfTheYear) 
        {
            if ($month -notin $manifest.allowedMonthsOfTheYear) 
            {
                $errormsg = "Specified month is not supported: $month. Allowed values are: $allowedValues"
                throw $errormsg
            }
        }
        
	}
}

function ValidateWeeksOfTheMonth {
	[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $DatasourceType,

        [Parameter(Mandatory=$false)]
        [string[]]
        ${MonthlyRetentionWeeksOfTheMonth},

		[Parameter(Mandatory=$false)]
        [string[]]
        ${YearlyRetentionWeeksOfTheMonth}

	)

	process
	{
        Write-Debug "Validating Months of the year Options"
        Write-Debug -Message $DatasourceType
        Write-Debug -Message ($MonthlyRetentionWeeksOfTheMonth -join ', ')
        Write-Debug -Message ($YearlyRetentionWeeksOfTheMonth -join ', ')
        

        $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
        $allowedValues = [System.String]::Join(', ', $manifest.allowedWeeksOfTheMonth)

        foreach ($week in $MonthlyRetentionWeeksOfTheMonth) {
            if ($week -notin $manifest.allowedWeeksOfTheMonth) {
                $errormsg = "Specified weekOfMonth is not supported: $week. Allowed values are: $allowedValues"
                throw $errormsg
            }
        }

        foreach ($week in $YearlyRetentionWeeksOfTheMonth) {
            if ($week -notin $manifest.allowedWeeksOfTheMonth) {
                $errormsg = "Specified weekOfMonth is not supported: $week. Allowed values are: $allowedValues"
                throw $errormsg
            }
        } 
	}
}

# which parameter can be used under which other params
function ValidateRetentionParameters {                                                              
	[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]
    param (
        [Parameter(Mandatory=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy]
        $Policy,
        
        [Parameter(Mandatory=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
        $DatasourceType,
        
        [Parameter(Mandatory=$true)]
        [hashtable]
        $parametersToTest
    )

	process
	{
        Write-Debug "Validating parameter combinations"
        Write-Debug -Message $DatasourceType
        
        $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
        if($manifest.allowedSubProtectionPolicyTypes.Count -gt 2)
        {
            if(-not($ModifyFullBackup -or $ModifyDifferentialBackup -or $ModifyIncrementalBackup -or $ModifyLogBackup) )
            {
                $errormsg="Retention policy for SAPHANA/MSSQL workloads can only be modified on switching to ModifyFullBackup/ModifyDifferentialBackup/ModifyIncrementalBackup/ModifyLogBackup"
                throw $errormsg
            }
        }
        $Index=1
       
        if($ModifyFullBackup)
        {
            $FullBackupPolicy =  $Policy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
            $Index = $Policy.SubProtectionPolicy.IndexOf($FullBackupPolicy)
        }

        # Validate Daily Retention Parameters

		if ($DailyRetentionDurationInDays -ne $null) 
        { 
            $parametersEntered = [System.Collections.ArrayList]::new()
			if ($DailyRetentionDurationInDays -ne $null) 
            { 
				$parametersEntered.Add("DailyRetentionDurationInDays") > $null
			}
            if ($EnableDailyRetention -ne $true) 
            { 
				$errormsg = $parametersEntered + " can only be used when Daily retention is enabled"
				throw $errormsg
			}
		}
        # Validate Weekly Retention Parameters
        
        if ($WeeklyRetentionDurationInWeeks -or $WeeklyRetentionDaysOfTheWeek) 
        {
			$parametersEntered = [System.Collections.ArrayList]::new()
			if ($WeeklyRetentionDurationInWeeks) 
            {
				$parametersEntered.Add("WeeklyRetentionDurationInWeeks") > $null
			}
            if ($WeeklyRetentionDaysOfTheWeek) 
            {
				$parametersEntered.Add("WeeklyRetentionDaysOfTheWeek") > $null
			}
            if ($EnableWeeklyRetention -ne $true) 
            {
				$errormsg = $parametersEntered + " can only be used when Weekly retention is enabled"
				throw $errormsg
			}
		}

        # Validate Monthly Retention Parameters
        if($MonthlyRetentionScheduleType -or $MonthlyRetentionDurationInMonths -or $MonthlyRetentionDaysOfTheWeek -or $MonthlyRetentionWeeksOfTheMonth -or $MonthlyRetentionDaysOfTheMonth ) 
        {
            $parametersEntered = [System.Collections.ArrayList]::new()
			if ($MonthlyRetentionScheduleType) 
            {
				$parametersEntered.Add("MonthlyRetentionScheduleType") > $null
			}
            if ($MonthlyRetentionDurationInMonths) 
            {
				$parametersEntered.Add("MonthlyRetentionDurationInMonths") > $null
			}
            if ($EnableMonthlyRetention -ne $true) 
            {
				$errormsg = $parametersEntered + " can only be used when Monthly retention is enabled"
				throw $errormsg
			}
            if($MonthlyRetentionScheduleType -ne "")
            {
                if($DatasourceType -eq "AzureVM")
                {
                    $Policy.RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType=$MonthlyRetentionScheduleType
                }
                else
                {
                    if(-not($ModifyFullBackup))
                    {
                        $errormsg="Monthly retention policy for SAPHANA/MSSQL workloads can only be modified on switching to ModifyFullBackup"
                        throw $errormsg
                    }                    
                    $Policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType=$MonthlyRetentionScheduleType
                }
            }
            if(($MonthlyRetentionScheduleType -eq "Weekly") -or ($DatasourceType -eq "AzureVM" -and $Policy.RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Weekly") -or ((($DatasourceType -eq "SAPHANA") -or ($DatasourceType -eq "MSSQL")) -and ($Policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Weekly")))
            {
                $parametersEntered = [System.Collections.ArrayList]::new()
                if ($MonthlyRetentionDaysOfTheMonth) 
                {
			    	$parametersEntered.Add("MonthlyRetentionDaysOfTheMonth") > $null
                    $errormsg = $parametersEntered + " can only be used when day based Monthly retention is enabled"
			    	throw $errormsg
			    }
                if ($MonthlyRetentionIsLastDayIncluded)
                {
                    $parametersEntered.Add("MonthlyRetentionIsLastDayIncluded") > $null
                    $errormsg = $parametersEntered + " can only be used when day based Monthly retention is enabled"
			    	throw $errormsg
                }
                if ($EnableMonthlyRetention -ne $true) 
                {
			    	$errormsg = $parametersEntered + " can only be used when day based Monthly retention is enabled"
			    	throw $errormsg
			    }  
            }
            elseif( ($MonthlyRetentionScheduleType -eq "Daily") -or ($DatasourceType -eq "AzureVM" -and $Policy.RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Daily") -or ((($DatasourceType -eq "SAPHANA") -or ($DatasourceType -eq "MSSQL")) -and ($Policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Daily")))
            {
                $parametersEntered = [System.Collections.ArrayList]::new()
                if ($MonthlyRetentionDaysOfTheWeek) 
                {
			    	$parametersEntered.Add("MonthlyRetentionDaysOfTheWeek") > $null
                    $errormsg = $parametersEntered + " can only be used when week based Monthly retention is enabled"
			    	throw $errormsg
			    }
                if ($MonthlyRetentionWeeksOfTheMonth)
                {
                    $parametersEntered.Add("MonthlyRetentionWeeksOfTheMonth") > $null
                    $errormsg = $parametersEntered + " can only be used when week based Monthly retention is enabled"
			    	throw $errormsg
                }
                if ($EnableMonthlyRetention -ne $true ) 
                {
			    	$errormsg = $parametersEntered + " can only be used when week based Monthly retention is enabled"
			    	throw $errormsg
			    }
            }
            else
            {
                $errormsg= "Please specify Retention Schedule format type for monthly retention: weekly/daily"
                throw $errormsg
            }
        }
        
        # Validate Yearly Retention Parameters
        
        if( $YearlyRetentionScheduleType -or $YearlyRetentionDurationInYears -or $YearlyRetentionMonthsOfTheYear -or $YearlyRetentionDaysOfTheWeek -or $YearlyRetentionWeeksOfTheMonth -or $YearlyRetentionDaysOfTheMonth -or $YearlyRetentionIsLastDayIncluded) 
        {
            $parametersEntered = [System.Collections.ArrayList]::new()
			if ($YearlyRetentionScheduleType) 
            {
				$parametersEntered.Add("YearlyRetentionScheduleType") > $null
			}
            if ($YearlyRetentionDurationInYears) 
            {
				$parametersEntered.Add("YearlyRetentionDurationInYears") > $null
			}
            if ($YearlyRetentionMonthsOfTheYear) 
            {
				$parametersEntered.Add("YearlyRetentionMonthsOfTheYear") > $null
			}
            if ($EnableYearlyRetention -ne $true) 
            {
				$errormsg = $parametersEntered + " can only be used when Yearly retention is enabled"
				throw $errormsg
			}
            if($YearlyRetentionScheduleType -ne "")
            {
                if($DatasourceType -eq "AzureVM")
                {
                    $Policy.RetentionPolicy.YearlySchedule.RetentionScheduleFormatType = $YearlyRetentionScheduleType
                }
                else
                {
                    if(-not($ModifyFullBackup))
                    {
                        $errormsg="Yearly retention policy for SAPHANA/MSSQL workloads can only be modified on switching to ModifyFullBackup"
                        throw $errormsg
                    }
         
                    $Policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleFormatType = $YearlyRetentionScheduleType
                }
                
            }
            if( ($YearlyRetentionScheduleType -eq "Weekly") -or ($DatasourceType -eq "AzureVM" -and $Policy.RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Weekly" ) -or ((($DatasourceType -eq "SAPHANA") -or ($DatasourceType -eq "MSSQL")) -and ($Policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Weekly")))
            {
                $parametersEntered = [System.Collections.ArrayList]::new()
                if ($YearlyRetentionDaysOfTheMonth) 
                {
			    	$parametersEntered.Add("YearlyRetentionDaysOfTheMonth") > $null
                    $errormsg = $parametersEntered + " can only be used when day based Yearly retention is enabled"
			    	throw $errormsg
			    }
                if ($YearlyRetentionIsLastDayIncluded)
                {
                    $parametersEntered.Add("YearlyRetentionIsLastDayIncluded") > $null
                    $errormsg = $parametersEntered + " can only be used when day based Yearly retention is enabled"
			    	throw $errormsg
                }
			    if ($EnableYearlyRetention -ne $true) 
                {
			    	$errormsg = $parametersEntered + " can only be used when day based Yearly retention is enabled"
			    	throw $errormsg
			    }                
            }
            elseif(($YearlyRetentionScheduleType -eq "Daily") -or ($DatasourceType -eq "AzureVM" -and $Policy.RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Daily") -or ((($DatasourceType -eq "SAPHANA") -or ($DatasourceType -eq "MSSQL")) -and ($Policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Daily")))
            {
                $parametersEntered = [System.Collections.ArrayList]::new()
                if ($YearlyRetentionDaysOfTheWeek) 
                {
			    	$parametersEntered.Add("YearlyRetentionDaysOfTheWeek") > $null
                    $errormsg = $parametersEntered + " can only be used when week based Yearly retention is enabled"
			    	throw $errormsg
			    }
                if ($YearlyRetentionWeeksOfTheMonth)
                {
                    $parametersEntered.Add("YearlyRetentionWeeksOfTheMonth") > $null
                    $errormsg = $parametersEntered + " can only be used when week based Yearly retention is enabled"
			    	throw $errormsg
                }
                if ($EnableYearlyRetention -ne $true) 
                {
			    	$errormsg = $parametersEntered + " can only be used when week based Yearly retention is enabled"
			    	throw $errormsg
			    }               
            }
            else
            {
                $errormsg= "Please specify Retention Schedule format type for yearly retention: weekly/daily"
                throw $errormsg
            }
        }       
        
        if ($DifferentialRetentionPeriodInDays) 
        {
			$parametersEntered = [System.Collections.ArrayList]::new()
			if ($DifferentialRetentionPeriodInDays) 
            {
				$parametersEntered.Add("DifferentialRetentionPeriodInDays") > $null
			}
            # check whether differential backup is supported for given DatasourceType
            $unsupportedParams = $parametersEntered | Where-Object { $param = $_; $param -notin $manifest.allowedDifferentialParams }
            if ($unsupportedParams.Count -gt 0) {
                $unsupportedParamsString = $unsupportedParams -join ', '
                $errormsg = " $DatasourceType 'dosen't support the following parameters:' $unsupportedParamsString"
                throw $errormsg
            }
            # check whether differential backup is enabled
            if(-not($ModifyDifferentialBackup))
            {
                $errormsg = $parametersEntered + " can only be used for modifying differential backup after switching to -ModifyDifferentialBackup"
				throw $errormsg
            }
		}
        
        if ($IncrementalRetentionPeriodInDays) 
        {
            $parametersEntered = [System.Collections.ArrayList]::new()
			if ($IncrementalRetentionPeriodInDays) 
            {
				$parametersEntered.Add("IncrementalRetentionPeriodInDays") > $null
			}
            $unsupportedParams = $parametersEntered | Where-Object { $param = $_; $param -notin $manifest.allowedIncrementalParams }
            if ($unsupportedParams.Count -gt 0) {
                $unsupportedParamsString = $unsupportedParams -join ', '
                $errormsg = " $DatasourceType 'dosen't support the following parameters:' $unsupportedParamsString"
                throw $errormsg
            }
            if(-not($ModifyIncrementalBackup))
            {
                $errormsg = $parametersEntered + " can only be used for modifying incremental backup after switching to -ModifyIncrementalBackup"
				throw $errormsg
            }
        }

        if ( $LogRetentionPeriodInDays) 
        {
            $parametersEntered = [System.Collections.ArrayList]::new()
            
			if ($LogRetentionPeriodInDays) 
            {
				$parametersEntered.Add("LogRetentionPeriodInDays") > $null
			}
            $unsupportedParams = $parametersEntered | Where-Object { $param = $_; $param -notin $manifest.allowedLogParams }
            if ($unsupportedParams.Count -gt 0) {
                $unsupportedParamsString = $unsupportedParams -join ', '
                $errormsg = " $DatasourceType 'dosen't support the following parameters:' $unsupportedParamsString"
                throw $errormsg
            }
            if(-not($ModifyLogBackup))
            {
                $errormsg = $parametersEntered + " can only be used after switching to -ModifyLogBackup "
				throw $errormsg
            }
        }
    }
}
 
function ValidateMandatoryFields {
	[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]
	param(
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy]
        $Policy,

		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
        ${DatasourceType},  

        [Parameter(Mandatory=$false)]
        [Nullable[Boolean]]
        ${EnableDailyRetention},
        
        [Parameter(Mandatory=$false)]
        [Nullable[Boolean]]
        ${EnableWeeklyRetention},
        
        [Parameter(Mandatory=$false)]
        [Nullable[Boolean]]
        ${EnableMonthlyRetention},
    
        [Parameter(Mandatory=$false)]
        [Nullable[Boolean]]
        ${EnableYearlyRetention},

        [Parameter(Mandatory=$false)]
        [Nullable[int]]
        ${DailyRetentionDurationInDays},

        [Parameter(Mandatory=$false)]
        [Nullable[int]]
        ${WeeklyRetentionDurationInWeeks},
    
        [Parameter(Mandatory=$false)]
        [string[]]
        ${WeeklyRetentionDaysOfTheWeek},      

        [Parameter(Mandatory=$false)]
        [Nullable[int]]
        ${MonthlyRetentionDurationInMonths},   

        [Parameter(Mandatory=$false)]
        [int[]]
        ${MonthlyRetentionDaysOfTheMonth},             

        [Parameter(Mandatory=$false)]
        [string[]]
        ${MonthlyRetentionDaysOfTheWeek},          
    
        [Parameter(Mandatory=$false)]
        [string[]]
        ${MonthlyRetentionWeeksOfTheMonth},        

        [Parameter(Mandatory=$false)]
        [Nullable[int]]
        ${YearlyRetentionDurationInYears},          

        [Parameter(Mandatory=$false)]
        [string[]]
        ${YearlyRetentionMonthsOfTheYear},         

        [Parameter(Mandatory=$false)]
        [string[]]
        ${YearlyRetentionDaysOfTheWeek},       

        [Parameter(Mandatory=$false)]
        [int[]]
        ${YearlyRetentionDaysOfTheMonth},       

        [Parameter(Mandatory=$false)]
        [string[]]
        ${YearlyRetentionWeeksOfTheMonth}      
	)

	process
	{
        Write-Debug "Validating mandatory parameters"
        Write-Debug -Message $DatasourceType
        
        $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
        
        $Index=1
        if($ModifyFullBackup)
        {
            $FullBackupPolicy =  $Policy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
            $Index = $Policy.SubProtectionPolicy.IndexOf($FullBackupPolicy)
        }

        # Validate Daily Retention Parameters

        if ($EnableDailyRetention -eq $true ) 
        {
             if($manifest.allowedSubProtectionPolicyTypes.Count -gt 2 -and $policy.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -ne "Weekly")   #SAPHANA/MSSQL
			 {
                  if(($Policy.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count -eq $null) -or ($Policy.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count -eq 0) ) 
                  {
			          $errormsg = "Daily retention duration in days must not be empty "
			          throw $errormsg
                  }
                  #Write-Host "Daily retention duration in days: $($Policy.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count)"
			 }
             elseif($manifest.allowedSubProtectionPolicyTypes.Count -lt 2 -and $policy.SchedulePolicy.ScheduleRunFrequency -ne "Weekly")    #AzureVM
             {
                 if(($Policy.RetentionPolicy.DailySchedule.RetentionDuration.Count -eq $null) -or ($Policy.RetentionPolicy.DailySchedule.RetentionDuration.Count -eq 0)) 
                 {
			         $errormsg = "Daily retention duration in days must not be empty "
			         throw $errormsg
                 }
             }
		}

        # Validate Weekly Retention Parameters

        if ($EnableWeeklyRetention -eq $true) 
        {
             if($manifest.allowedSubProtectionPolicyTypes.Count -gt 2)   #SAPHANA/MSSQL
			 {
                  if(($Policy.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.DaysOfTheWeek.Count -eq 0) -or ($Policy.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.DaysOfTheWeek.Count -eq $null) )
                  {
			          $errormsg = "Weekly retention days of the week must not be empty "
			          throw $errormsg
                  }
                  if(($Policy.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration.Count -eq $null) -or ($Policy.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration.Count -eq 0)) 
                  {
			          $errormsg = "Weekly retention duration in weeks must not be empty "
			          throw $errormsg
                  }
                  #Write-Host "Weekly retention duration in weeks: $($Policy.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration.Count)"
                  #Write-Host "Weekly retention days of the week: $($Policy.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.DaysOfTheWeek)"
			 }
             else    #AzureVM
             {
                 if($Policy.RetentionPolicy.WeeklySchedule.DaysOfTheWeek.Count -eq 0) 
                 {
			         $errormsg = "Weekly retention days of the week must not be empty"
			         throw $errormsg
                 }
                 if(($Policy.RetentionPolicy.WeeklySchedule.RetentionDuration.Count -eq 0) -or ($Policy.RetentionPolicy.WeeklySchedule.RetentionDuration.Count -eq $null))
                 {
			          $errormsg = "Weekly retention duration in weeks must not be empty "
			          throw $errormsg
                 }
             }
		}
		
        # Validate Monthly Retention Parameters
        if ($EnableMonthlyRetention -eq $true) 
        { 

            if($manifest.allowedSubProtectionPolicyTypes.Count -gt 2)   #SAPHANA/MSSQL
			{
                if(($Policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -eq $null) -or ($Policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -eq 0)) 
                {
			        $errormsg = "Monthly retention duration in months must not be empty "
			        throw $errormsg
                }
                if($Policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Weekly")
                {
                    if($Policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly.DaysOfTheWeek.Count -eq 0)
                    {
                        $errormsg = "Days of the week must not be empty for week based monthly retention."
				        throw $errormsg
                    }
                    if($Policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly.weeksOfTheMonth.Count -eq 0)
                    {
                        $errormsg = "Weeks of the month must not be empty for week based monthly retention."
				        throw $errormsg
                    }
                }
                elseif($Policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Daily")
                {
                    if($Policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth.Count -eq 0)
                    {
                        $errormsg = "Days of the month must not be empty for day based monthly retention."
				        throw $errormsg
                    }
                }  
                else
                {
                    $errormsg="RetentionScheduleFormatType cannot be null. Please specify the type: daily/weekly"
                    throw $errormsg
                }
			}
            else    #AzureVM
            {
                if(($Policy.RetentionPolicy.MonthlySchedule.RetentionDuration.Count -eq $null) -or ($Policy.RetentionPolicy.MonthlySchedule.RetentionDuration.Count -eq 0 )) 
                {
			         $errormsg = "Monthly retention duration in months must not be empty "
			         throw $errormsg
                }
                if($Policy.RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Weekly")
                {
                    if($Policy.RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly.DaysOfTheWeek.Count -eq 0)
                    {
                        $errormsg = "Days of the week must not be empty for week based monthly retention."
				        throw $errormsg
                    }
                    if($Policy.RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly.weeksOfTheMonth.Count -eq 0)
                    {
                        $errormsg = "Weeks of the month must not be empty for week based monthly retention."
				        throw $errormsg
                    }
                }
                elseif($Policy.RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Daily")
                {
                    if($Policy.RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth.Count -eq 0)
                    {
                        $errormsg = "Days of the month must not be empty for day based monthly retention."
				        throw $errormsg
                    }
                }  
                else
                {
                    $errormsg="RetentionScheduleFormatType cannot be null. Please specify the type: daily/weekly"
                    throw $errormsg
                }
            }
		}

        # Validate Yearly Retention Parameters

        if ($EnableYearlyRetention -eq $true) 
        {
            if($manifest.allowedSubProtectionPolicyTypes.Count -gt 2)   #SAPHANA/MSSQL
			{
                if(($Policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration.Count -eq $null) -or ($Policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration.Count -eq 0)) 
                {
			        $errormsg = "Yearly retention duration in years must not be empty "
			        throw $errormsg
                }
                if($Policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Weekly")
                {
                    if($Policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek.Count -eq 0)
                    {
                        $errormsg = "Days of the week must not be empty for week based Yearly retention."
				        throw $errormsg
                    }
                    if($Policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.weeksOfTheMonth.Count -eq 0)
                    {
                        $errormsg = "Weeks of the month must not be empty for week based Yearly retention."
				        throw $errormsg
                    }
                    if($Policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.monthsOfYear.Count -eq 0)
                    {
                        $errormsg = "Months of the year must not be empty for week based Yearly retention."
				        throw $errormsg
                    }                  
                }
                elseif($Policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Daily")
                {
                    if($Policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.monthsOfYear.Count -eq 0)
                    {
                        $errormsg = "Months of the year must not be empty for day based Yearly retention."
				        throw $errormsg
                    }
                    if($Policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth.Count -eq 0)
                    {
                        $errormsg = "Days of the month must not be empty for day based Yearly retention."
				        throw $errormsg
                    }  
                }  
                else
                {
                    $errormsg="RetentionScheduleFormatType cannot be null. Please specify the type: daily/weekly"
                    throw $errormsg
                }

			}
            else    #AzureVM
            {
                if(($Policy.RetentionPolicy.YearlySchedule.RetentionDuration.Count -eq $null) -or ($Policy.RetentionPolicy.YearlySchedule.RetentionDuration.Count -eq 0)) 
                {
			         $errormsg = "Yearly retention duration in years must not be empty "
			         throw $errormsg
                }
                if($Policy.RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Weekly")
                {
                    if($Policy.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek.Count -eq 0)
                    {
                        $errormsg = "Days of the week must not be empty for week based Yearly retention."
				        throw $errormsg
                    }
                    if($Policy.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.weeksOfTheMonth.Count -eq 0)
                    {
                        $errormsg = "Weeks of the month must not be empty for week based Yearly retention."
				        throw $errormsg
                    }
                    if($Policy.RetentionPolicy.YearlySchedule.monthsOfYear.Count -eq 0)
                    {
                        $errormsg = "Months of the year must not be empty for week based Yearly retention."
				        throw $errormsg
                    }
                }
                elseif($Policy.RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Daily")
                {
                    if($Policy.RetentionPolicy.YearlySchedule.monthsOfYear.Count -eq 0)
                    {
                        $errormsg = "Months of the year must not be empty for day based Yearly retention."
				        throw $errormsg
                    }
                    if($Policy.RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth.Count -eq 0 )
                    {
                        $errormsg = "Days of the month must not be empty for day based Yearly retention."
				        throw $errormsg
                    }
                }  
                else
                {
                    $errormsg="RetentionScheduleFormatType cannot be null. Please specify the type: daily/weekly"
                    throw $errormsg
                }
            }
        }
    }
}

function ValidateTieringPolicy
{
    if($tieringdetails.TieringMode -eq "")
    {
        $errormsg="Please specify the tiering mode"
        throw $errormsg
    }
    if( ($tieringdetails.TieringMode -eq "DoNotTier") -or ($tieringdetails.TieringMode -eq "TierRecommended"))
    {
        if(($tieringdetails.Duration -ne $null -or $tieringdetails.DurationType -ne $null) -and ($tieringdetails.Duration -gt 0 -and $tieringdetails.durationType -ne "Invalid"))
        {
            $errormsg="Invalid parameters TierAfterDuration, TierAfterDurationType for the given TieringMode"
            throw $errormsg
        }
    }
    elseif($tieringdetails.TieringMode -eq "TierAfter")
    {
        if( ($tieringdetails.Duration -eq $null) -or ($tieringdetails.Duration -eq 0) -or ($tieringdetails.DurationType -eq "") -or ($tieringdetails.DurationType -eq $null) )
        {
            $errormsg="Missing parameter values for TierAfter Mode"
            throw $errormsg
        }
    }
    # To enable Archive(either TierRecommended or TierAfter), Monthly or Yearly retention needs to be set
    if($tieringdetails.TieringMode -ne "" -and $tieringdetails.TieringMode -ne "DoNotTier" -and $manifest.allowedSubProtectionPolicyTypes.Count -lt 2)
    {
        if ( (($policy.RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -eq $null) -or ($policy.RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -eq 0)) -and (($policy.RetentionPolicy.YearlySchedule.RetentionDuration.Count -eq $null) -or ($policy.RetentionPolicy.YearlySchedule.RetentionDuration.Count -eq 0)) )
        {
             $errormsg="Monthly or Yearly retention needs to be set to enable Archive smart tiering. Please modify retention or disable smart tiering. Please note that disabling smart tiering may involve additional costs."
             throw $errormsg                
        }
     
        # For TierRecommended policy:  At least one of monthly or yearly retention should be >= 9 months.
        if ($tieringdetails.TieringMode -eq "TierRecommend")
        {        
            if ( ( (($policy.RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -eq $null) -or ($policy.RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -eq 0)) -or ($policy.RetentionPolicy.MonthlySchedule.RetentionDuration.Count -lt 9)) -and ( (($policy.RetentionPolicy.YearlySchedule.RetentionDuration.Count -eq $null) -or ($policy.RetentionPolicy.YearlySchedule.RetentionDuration.Count -eq 0)) -or ($policy.RetentionPolicy.YearlySchedule.RetentionDuration.Count * 12) -lt 9) )
            {
                $errormsg="At least one of monthly or yearly retention should be >= 9 months for enabling TierRecommended mode for smart tiering. Please modify retention or disable smart tiering. Please note that disabling smart tiering may involve additional costs."
                throw $errormsg
            }
        }
        #For TierAfter policy:   TierAfter duration needs to be >= 3 months,  At least one of monthly or yearly retention should be >= (TierAfter + 6) months.
        # e.g. if TierAfter is specified as 6 months, at least one of monthly or yearly retention should be at least 12 months.
        if($tieringdetails.TieringMode -eq "TierAfter")
        {   
            if($tieringdetails.duration -lt 3  -or (( (($policy.RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -eq $null) -or ($policy.RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -eq 0)) -or $policy.RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -lt $tieringdetails.duration + 6) -and ( (($policy.RetentionPolicy.YearlySchedule.RetentionDuration.Count -eq $null) -or ($policy.RetentionPolicy.YearlySchedule.RetentionDuration.Count -eq 0)) -or ($policy.RetentionPolicy.YearlySchedule.RetentionDuration.Count * 12) -lt $tieringdetails.duration + 6)))
            {
                $errormsg="TierAfterDuration needs to be >= 3 months, at least one of monthly or yearly retention should be >= (TierAfterDuration + 6) months for smart tiering. Please modify retention or disable smart tiering. Please note that disabling smart tiering may involve additional costs."
                throw $errormsg
            }
        }
    }
            
    if($tieringdetails.TieringMode -ne "" -and $tieringdetails.TieringMode -ne "DoNotTier" -and $manifest.allowedSubProtectionPolicyTypes.Count -gt 2)
    {
        # To enable Archive, Full Backup Policy needs to be set.
        if ($policy.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "" -and $MoveToArchiveTier -eq $true)
        {
            $errormsg="FullBackupRetentionPolicy can't be null while enabling Archive smart tiering for BackupManagementType AzureWorkload"
            throw $errormsg
        }
        
        # For TierAfter policy: TierAfter duration needs to be >= 45 days, at least one retention policy for full backup (daily / weekly / monthly / yearly) should be >= (TierAfter + 180) days.
        #  e.g. if TierAfter is specified as 100 days, at least one retention policy for Full Backup needs to be greater than or equal to 280 days.
        $daily=$true
        if(($policy.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count -eq $null) -or ($policy.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count -eq 0))
        {
            $daily=$false
        }
        $weekly=$true
        if(($policy.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration.Count -eq $null) -or ($policy.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration.Count -eq 0))
        {
            $weekly=$false
        }
        $monthly=$true
        if(($policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -eq $null) -or ($policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -eq 0))
        {
            $monthly=$false
        }
        $yearly=$true
        if(($policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration.Count -eq $null) -or ($policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration.Count -eq 0))
        {
            $yearly=$false
        }
        if ($tieringdetails.TieringMode -eq "TierAfter")
        {
            if(
                $tieringdetails.duration -lt 45 -or
                (
                ($daily -eq $false -or ($policy.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count) -lt ($tieringdetails.duration + 180)) -and (($weekly -eq $false) -or (($policy.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration[0].Count * 7) -lt ($tieringdetails.duration + 180))) -and (($monthly -eq $false) -or (($policy.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count * 30) -lt ($tieringdetails.duration + 180))) -and (($yearly -eq $false -or ($policy.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration.Count * 365) -lt ($tieringdetails.duration + 180)))
                ))
            {
                $errormsg= "TierAfterDuration needs to be >= 45 Days, at least one retention policy for full backup (daily / weekly / monthly / yearly) should be >= (TierAfter + 180) days for smart tiering. Please modify retention or disable smart tiering. Please note that disabling smart tiering may involve additional costs."
                throw $errormsg
            }
        }
    }
    
}  
    