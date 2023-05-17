function Edit-AzRecoveryServicesBackupSchedulePolicyClientObject {
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy')]
    [CmdletBinding(PositionalBinding=$false)]
    # RsvRef: should we call it workload type
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('Edits the schedule policy in the specified backup policy object.')]

	param (
        [Parameter(ParameterSetName='ModifySchedulePolicy', Mandatory, HelpMessage='Specifies the policy to be edited.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy]
        ${Policy},
      
        # AzureVM specific parameters

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies the policy sub type for AzureVM.')]
        [ValidateSet("Standard", "Enhanced", ErrorMessage = "Invalid value for PolicySubType. Please provide a valid policy sub type. Valid values are 'Standard' and 'Enhanced'.")]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.PolicySubTypes]
        ${PolicySubType} = "Standard",

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies the interval between backups in hours.')]
        [ValidateSet(4, 6, 8, 12, ErrorMessage = "Invalid value for HourlyInterval. Please provide a valid interval. Valid values are 4, 6, 8, and 12.")]
        [AllowNull()]
        [System.Nullable[int]]
        ${HourlyInterval} = $null,

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies the duration over which backup is taken in hours.')]
        [ValidateSet(4, 8, 12, 16, 20, 24, ErrorMessage = "Invalid value for HourlyScheduleWindowDuration. Please provide a valid duration. Valid values are 4, 8, 12, 16, 20, and 24.")]
        [AllowNull()]
        [System.Nullable[int]]
        ${HourlyScheduleWindowDuration} = $null,

        # SAPHANA specific parameters

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies whether the user needs to make a log backup')]
        [AllowNull()]
        [Nullable[Boolean]]
        ${EnableLogBackup},

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies the frequency of log backups in minutes')]
        [ValidateSet(15, 30, 60, 120, 240, 480, 720, 1440, ErrorMessage = "Invalid value for LogBackupFrequencyInMin. Please provide a valid frequency. Valid values are 15, 30, 60, 120, 240, 480, 720, and 1440.")]
        [AllowNull()]
        [System.Nullable[int]]
        ${LogBackupFrequencyInMin} = $null,

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies whether the user wants to enable differential backup.')]
        [AllowNull()]
        [Nullable[Boolean]]
        ${EnableDifferentialBackup} = 0,

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies the days of the week for differential backup.')]
        [ValidateScript({
            if ($_ -ne $null) {
                $allowedDays = "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
                foreach ($day in $_) {
                    if (-not ($day -in $allowedDays)) {
                        throw "Invalid day of the week: $day. Please provide a valid day of the week."
                    }
                }
            }

            return $true
        })]
        [AllowNull()]
        [string[]]
        ${DifferentialRunDay} = $null,

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies the time at which differential backup must be taken.')]
        [ValidatePattern("^[string]::Empty$|^([1-9]|1[0-2]):(00|30) (AM|PM)$", ErrorMessage = "Invalid value for DifferentialScheduleTime. Please provide a valid time in the format HH:00 or HH:30 AM/PM.")]
        [AllowEmptyString()]
        [string]
        ${DifferentialScheduleTime} = [string]::Empty,

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies whether the user wants to enable incremental backup.')]
        [AllowNull()]
        [Nullable[Boolean]]
        ${EnableIncrementalBackup} = 0,

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies the days of the week for incremental backup.')]
        [ValidateScript({
            if ($_ -ne $null) {
                $allowedDays = "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
                foreach ($day in $_) {
                    if (-not ($day -in $allowedDays)) {
                        throw "Invalid day of the week: $day. Please provide a valid day of the week."
                    }
                }
            }

            return $true
        })]
        [AllowNull()]
        [string[]]
        ${IncrementalRunDay} = $null,

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies the time at which incremental backup must be taken.')]
        [ValidatePattern("^[string]::Empty$|^([1-9]|1[0-2]):(00|30) (AM|PM)$", ErrorMessage = "Invalid value for IncrementalScheduleTime. Please provide a valid time in the format HH:00 or HH:30 AM/PM.")]
        [AllowEmptyString()]
        [string]
        ${IncrementalScheduleTime} = [string]::Empty,

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies the frequency of backup.')]
        [ValidateSet("Daily", "Weekly", "Hourly", ErrorMessage = "Invalid value for BackupFrequency. Please provide a valid value. Valid values are 'Daily', 'Weekly', and 'Hourly'.")]
        [AllowEmptyString()]
        [string]
        ${BackupFrequency} = [string]::Empty,

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies the days of the week for weekly backup.')]
        [ValidateScript({
            if ($_ -ne $null) {
                $allowedDays = "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
                foreach ($day in $_) {
                    if (-not ($day -in $allowedDays)) {
                        throw "Invalid day of the week: $day. Please provide a valid day of the week."
                    }
                }
            }
        
            return $true
        })]
        [AllowNull()]
        [string[]]
        ${ScheduleRunDay} = $null,

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies the time at which backup must be taken.')]
        [ValidatePattern("^[string]::Empty$|^([1-9]|1[0-2]):(00|30) (AM|PM)$", ErrorMessage = "Invalid value for ScheduleTime. Please provide a valid time in the format HH:00 or HH:30 AM/PM.")]
        [AllowEmptyString()]
        [string]
        ${ScheduleTime} = [string]::Empty,

        [Parameter(ParameterSetName='ModifySchedulePolicy', HelpMessage='Specifies the standard time zone.')]
        [AllowEmptyString()]
        [string]
        # TODO: Validate timezone
        ${TimeZone} = "UTC"
    )

    begin {
        $DatasourceType = $Policy.BackupManagementType -eq "AzureIaasVM" ? "AzureVM" : ($Policy.WorkLoadType -eq "SAPHanaDatabase" ? "SAPHANA" : "MSSQL")
        
        Write-Debug -Message "BackupFrequency before : $BackupFrequency"

        ValidateBackupScheduleOptions -Policy $Policy -DatasourceType $DatasourceType -PolicySubType ([ref]$PolicySubType) -HourlyInterval ([ref]$HourlyInterval) -HourlyScheduleWindowDuration ([ref]$HourlyScheduleWindowDuration) -BackupFrequency ([ref]$BackupFrequency) -ScheduleRunDay ([ref]$ScheduleRunDay) -ScheduleTime ([ref]$ScheduleTime) -EnableIncrementalBackup ([ref]$EnableIncrementalBackup) -IncrementalRunDay ([ref]$IncrementalRunDay) -IncrementalScheduleTime ([ref]$IncrementalScheduleTime) -EnableDifferentialBackup ([ref]$EnableDifferentialBackup) -DifferentialRunDay ([ref]$DifferentialRunDay) -DifferentialScheduleTime ([ref]$DifferentialScheduleTime) -EnableLogBackup ([ref]$EnableLogBackup) -LogBackupFrequencyInMin ([ref]$LogBackupFrequencyInMin)

        Write-Debug -Message "BackupFrequency after : $BackupFrequency"

        Write-Debug "Validation successful"
    }

    process { 

        $policyObject = $Policy

        if ($ScheduleTime) {
            # Get current date and time
            $currentDateTime = Get-Date

            # Parse user input as time
            $givenTime = [DateTime]::ParseExact($ScheduleTime, "h:mm tt", $null)

            Write-Debug -Message "Given Time: $givenTime"
            Write-Debug -Message "Current Date Time: $currentDateTime"

            # Combine current date, given time, and UTC offset to form the desired format
            $convertedDateTime = [DateTime]::SpecifyKind(
                [DateTime]::new($currentDateTime.Year, $currentDateTime.Month, $currentDateTime.Day, $givenTime.Hour, $givenTime.Minute, $givenTime.Second),
                [System.DateTimeKind]::Utc
            )
        }

        $policyJson = $policyObject | ConvertTo-Json -Depth 10
        Write-Debug -Message "Policy Details: $policyJson"

        $manifest = LoadManifest -DatasourceType $DatasourceType

        if ($manifest.allowedSubProtectionPolicyTypes.Count -gt 1) {

            Write-Debug "In SAPHANA"

            $FullBackupPolicy =  $policyObject.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
            $Index = $policyObject.SubProtectionPolicy.IndexOf($FullBackupPolicy)
                                       
            switch($BackupFrequency) { 

                "Daily" {
					$FullBackupPolicy.SchedulePolicy.ScheduleRunFrequency = "Daily"
                    
                    $FullBackupPolicy.SchedulePolicy.ScheduleRunTime[0] = $convertedDateTime
                    $FullBackupPolicy.RetentionPolicy.DailySchedule.RetentionTime[0] = $convertedDateTime
                    $FullBackupPolicy.RetentionPolicy.MonthlySchedule.RetentionTime[0] = $convertedDateTime
                    $FullBackupPolicy.RetentionPolicy.WeeklySchedule.RetentionTime[0] = $convertedDateTime
                    $FullBackupPolicy.RetentionPolicy.YearlySchedule.RetentionTime[0] = $convertedDateTime

                    $policyObject.SubProtectionPolicy[$Index] = $FullBackupPolicy

                    $policyObject.Setting.TimeZone = $TimeZone
				}
				        
                "Weekly" {

					$FullBackupPolicy.SchedulePolicy.ScheduleRunFrequency = "Weekly"
                    
                    $FullBackupPolicy.SchedulePolicy.ScheduleRunDay = $ScheduleRunDay
                    $FullBackupPolicy.RetentionPolicy.WeeklySchedule.DaysOfTheWeek = $ScheduleRunDay
                    
                    $FullBackupPolicy.SchedulePolicy.ScheduleRunTime[0] = $convertedDateTime
                    $FullBackupPolicy.RetentionPolicy.MonthlySchedule.RetentionTime[0] = $convertedDateTime
                    $FullBackupPolicy.RetentionPolicy.WeeklySchedule.RetentionTime[0] = $convertedDateTime
                    $FullBackupPolicy.RetentionPolicy.YearlySchedule.RetentionTime[0] = $convertedDateTime
                    
                    $policyObject.Setting.TimeZone = $TimeZone

                    $policyObject.SubProtectionPolicy[$Index] = $FullBackupPolicy
                }
            }

            if($EnableLogBackup) {
                $LogBackupPolicy =  $policyObject.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Log" }
                $Index = $policyObject.SubProtectionPolicy.IndexOf($LogBackupPolicy)

                $LogBackupPolicy.SchedulePolicy.ScheduleFrequencyInMin = $LogBackupFrequencyInMin
                
                $policyObject.SubProtectionPolicy[$Index] = $LogBackupPolicy
            }

            if ($EnableDifferentialBackup) {

                $givenTime = [DateTime]::ParseExact($DifferentialScheduleTime, "h:mm tt", $null)
        
                $convertedDateTime = [DateTime]::SpecifyKind(
                    [DateTime]::new($currentDateTime.Year, $currentDateTime.Month, $currentDateTime.Day, $givenTime.Hour, $givenTime.Minute, $givenTime.Second),
                    [System.DateTimeKind]::Utc
                )

                $DifferentialPolicy =  $policyObject.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Differential" }

                # Add a new sub protection policy for differential backup if it doesn't exist already
                if (-not $DifferentialPolicy) {
					$policyObject.SubProtectionPolicy += [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.SubProtectionPolicy]::new()
                    $DifferentialPolicy = $policyObject.SubProtectionPolicy[$policyObject.SubProtectionPolicy.Length - 1]
				}
                
                $Index = $policyObject.SubProtectionPolicy.IndexOf($DifferentialPolicy)

                $DifferentialPolicy.PolicyType = "Differential"
                $DifferentialPolicy.SchedulePolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.SimpleSchedulePolicy]::new()
                $DifferentialPolicy.SchedulePolicy.ScheduleRunFrequency = "Weekly"
                $DifferentialPolicy.SchedulePolicy.ScheduleRunDay = $DifferentialRunDay
                $DifferentialPolicy.SchedulePolicy.ScheduleRunTime = $convertedDateTime
                $DifferentialPolicy.SchedulePolicy.Type = "SimpleSchedulePolicy"
                $DifferentialPolicy.SchedulePolicy.ScheduleWeeklyFrequency = 0

                $policyObject.SubProtectionPolicy[$Index] = $DifferentialPolicy
            }
            elseif ($EnableDifferentialBackup -eq $false) {
				$DifferentialPolicy =  $policyObject.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Differential" }
				
                if ($DifferentialPolicy) {
					$Index = $policyObject.SubProtectionPolicy.IndexOf($DifferentialPolicy)
					$policyObject.SubProtectionPolicy.RemoveAt($Index)
				}
            }

            if ($EnableIncrementalBackup) {

                $givenTime = [DateTime]::ParseExact($IncrementalScheduleTime, "h:mm tt", $null)
        
                $convertedDateTime = [DateTime]::SpecifyKind(
                    [DateTime]::new($currentDateTime.Year, $currentDateTime.Month, $currentDateTime.Day, $givenTime.Hour, $givenTime.Minute, $givenTime.Second),
                    [System.DateTimeKind]::Utc
                )

                $IncrementalPolicy =  $policyObject.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Incremental" }
                
                # Add a new sub protection policy for incremental backup if it doesn't exist already
                if (-not $IncrementalPolicy) {
					$policyObject.SubProtectionPolicy += [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.SubProtectionPolicy]::new()
                    $IncrementalPolicy = $policyObject.SubProtectionPolicy[$policyObject.SubProtectionPolicy.Length - 1]
				}
                
                $Index = $policyObject.SubProtectionPolicy.IndexOf($IncrementalPolicy)

                $IncrementalPolicy.PolicyType = "Incremental"
                $IncrementalPolicy.SchedulePolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.SimpleSchedulePolicy]::new()
                $IncrementalPolicy.SchedulePolicy.ScheduleRunFrequency = "Weekly"
                $IncrementalPolicy.SchedulePolicy.ScheduleRunDay = $IncrementalRunDay
                $IncrementalPolicy.SchedulePolicy.ScheduleRunTime = $convertedDateTime
                $IncrementalPolicy.SchedulePolicy.Type = "SimpleSchedulePolicy"
                $IncrementalPolicy.SchedulePolicy.ScheduleWeeklyFrequency = 0

                $policyObject.SubProtectionPolicy[$Index] = $IncrementalPolicy
            }
            elseif ($EnableIncrementalPolicy -eq $false) {
                $IncrementalPolicy =  $policyObject.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Incremental" }

                if ($IncrementalPolicy) {
	                $Index = $policyObject.SubProtectionPolicy.IndexOf($IncrementalPolicy)
                    $policyObject.SubProtectionPolicy.RemoveAt($Index)
                }
            }
          
        }
        else {

            Write-Debug "In AzureVM"

            if ($PolicySubType) {
                $policyObject.PolicyType = ($PolicySubType -eq "Standard") ? "V1" : "V2"
            }
            
            if ($PolicySubType -eq "Enhanced") {
                $policyObject.SchedulePolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.SimpleSchedulePolicyV2]::new()
            }
            
            $policyJson = $policyObject | ConvertTo-Json -Depth 10
            Write-Debug $policyJson
      
            switch($BackupFrequency) {
                "Daily" {

                    if ($PolicySubType -eq "Enhanced") {
                        $policyObject.SchedulePolicy.DailyScheduleRunTime = @()
                        $policyObject.SchedulePolicy.DailyScheduleRunTime += $convertedDateTime

                        $policyObject.SchedulePolicy.Type = "SimpleSchedulePolicyV2"
                        $policyObject.SchedulePolicyType = "SimpleSchedulePolicyV2"
                    }
                    else {	
                        $policyObject.SchedulePolicy.ScheduleRunTime[0] = $convertedDateTime
                    }

                    $policyObject.RetentionPolicy.DailySchedule.RetentionTime[0] = $convertedDateTime

                    $policyObject.SchedulePolicy.ScheduleRunFrequency = "Daily"

					$policyObject.TimeZone = $TimeZone
                }

                "Weekly" {

                    if ($PolicySubType -eq "Enhanced") {
                        $policyObject.SchedulePolicy.WeeklyScheduleRunDay = $ScheduleRunDay
                        $policyObject.SchedulePolicy.WeeklyScheduleRunTime = @()
                        $policyObject.SchedulePolicy.WeeklyScheduleRunTime += $convertedDateTime

                        $policyObject.SchedulePolicy.Type = "SimpleSchedulePolicyV2"
                        $policyObject.SchedulePolicyType = "SimpleSchedulePolicyV2"
                    }
                    else {
                        $policyObject.SchedulePolicy.ScheduleRunDay = $ScheduleRunDay
                        $policyObject.SchedulePolicy.ScheduleRunTime[0] = $convertedDateTime
                    }

                    $policyObject.SchedulePolicy.ScheduleRunFrequency = "Weekly"

                    $policyObject.RetentionPolicy.WeeklySchedule.DaysOfTheWeek = $ScheduleRunDay
                    $policyObject.RetentionPolicy.WeeklySchedule.RetentionTime[0] = $convertedDateTime

                    $policyObject.TimeZone = $TimeZone

                    $policyObject.InstantRpRetentionRangeInDay = 5
                }

                "Hourly" {
                    Write-Debug "In Hourly"

                    $policyJson = $policyObject | ConvertTo-Json -Depth 10
                    Write-Debug $policyJson

                    $policyObject.SchedulePolicy.ScheduleRunFrequency = "Hourly"
                    $policyObject.SchedulePolicy.HourlySchedule.Interval = $HourlyInterval
                    $policyObject.SchedulePolicy.HourlySchedule.ScheduleWindowDuration = $HourlyScheduleWindowDuration
                               
                    $policyObject.SchedulePolicy.HourlySchedule.ScheduleWindowStartTime = $convertedDateTime
                    $policyObject.RetentionPolicy.DailySchedule.RetentionTime[0] = $convertedDateTime
                    
                    $policyObject.TimeZone = $TimeZone
                    
                    $policyObject.SchedulePolicy.Type = "SimpleSchedulePolicyV2"
                    $policyObject.SchedulePolicyType = "SimpleSchedulePolicyV2"
                    
                    $policyJson = $policyObject | ConvertTo-Json -Depth 10
                    Write-Debug $policyJson
                }
            }   
        }

        $policyJson = $policyObject | ConvertTo-Json -Depth 10
        Write-Debug $policyJson

        # Return the modified $policyObject
        $policyObject
    }
}