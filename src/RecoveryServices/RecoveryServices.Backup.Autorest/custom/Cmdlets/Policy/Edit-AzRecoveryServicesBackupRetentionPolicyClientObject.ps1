

function Edit-AzRecoveryServicesBackupRetentionPolicyClientObject {
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('Edits the retention settings for the policy client object')]

    param(
        [Parameter(ParameterSetName="ModifyRetentionPolicy",Mandatory=$true, HelpMessage='Specifies the policy to be edited.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy]
        ${Policy},

        [Parameter(ParameterSetName="ModifyRetentionPolicy",Mandatory=$true, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Switch parameter to modify FullBackup retention policy. You can use this parameter for DatasourceType: MSSQL, SAPHANA')]
        [switch]
        ${ModifyFullBackup},  
        
        [Parameter(ParameterSetName="ModifyRetentionPolicy",  HelpMessage='Switch parameter to modify differential backup retention policy. You can use this parameter for DatasourceType: MSSQL, SAPHANA')]
        [switch]
        ${ModifyDifferentialBackup},  

        [Parameter(ParameterSetName="ModifyRetentionPolicy",  HelpMessage='Switch parameter to modify incremental backup retention policy. You can use this parameter for DatasourceType: MSSQL, SAPHANA')]
        [switch]
        ${ModifyIncrementalBackup},

        [Parameter(ParameterSetName="ModifyRetentionPolicy",  HelpMessage='Switch parameter to modify log backup retention policy. You can use this parameter for DatasourceType: MSSQL, SAPHANA')]
        [switch]
        ${ModifyLogBackup},

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Boolean parameter to Enable/Disable Daily retention')]
        [Nullable[Boolean]]
        ${EnableDailyRetention},
        
        [Parameter(ParameterSetName="ModifyRetentionPolicy",  HelpMessage ='Boolean parameter to Enable/Disable Weekly retention')]
        [Nullable[Boolean]]
        ${EnableWeeklyRetention},
        
        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage ='Boolean parameter to Enable/Disable Monthly retention')]
        [Nullable[Boolean]]
        ${EnableMonthlyRetention},
    
        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage ='Boolean parameter to Enable/Disable Yearly retention')]
        [Nullable[Boolean]]
        ${EnableYearlyRetention},

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the daily schedule duration in days.')]
        [ValidateRange(7, 9999)]
        [Nullable[int]]
        ${DailyRetentionDurationInDays},

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the weekly schedule duration in weeks.')]
        [ValidateRange(1, 5163)]
        [Nullable[int]]
        ${WeeklyRetentionDurationInWeeks},
    
        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the days of the week for the weekly schedule.')]
        [string[]]
        ${WeeklyRetentionDaysOfTheWeek},      

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the retention schedule type for the monthly schedule: Week Based/Day Based')]
        [ValidateSet("Daily", "Weekly", ErrorMessage = "Invalid value for Monthly Retention ScheduleType. Please provide a valid value. Valid values are 'Daily', 'Weekly'.")]
        [string]
        ${MonthlyRetentionScheduleType},

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the retention schedule type for the yearly schedule.')]
        [ValidateSet("Daily", "Weekly", ErrorMessage = "Invalid value for Yearly Retention ScheduleType. Please provide a valid value. Valid values are 'Daily', 'Weekly'.")]
        [string]
        ${YearlyRetentionScheduleType},

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the monthly schedule duration in months.')]
        [ValidateRange(1, 1188)]
        [Nullable[int]]
        ${MonthlyRetentionDurationInMonths},   

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the days of the month for the monthly schedule.')]
        [ValidateRange(1, 28)]
        [int[]]
        ${MonthlyRetentionDaysOfTheMonth},             

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Boolean parameter to enable the day based monthly retention on last day of the month.')]
        [Nullable[bool]]
        ${MonthlyRetentionIsLastDayIncluded},

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the days of the week for the monthly schedule.')]
        [string[]]
        ${MonthlyRetentionDaysOfTheWeek},          
    
        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the weeks of the month for the monthly schedule.')]
        [string[]]
        ${MonthlyRetentionWeeksOfTheMonth},        

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the yearly schedule duration in years.')]
        [ValidateRange(1, 99)]
        [Nullable[int]]
        ${YearlyRetentionDurationInYears},          

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the months of the year for the yearly schedule.')]
        [string[]]
        ${YearlyRetentionMonthsOfTheYear},         

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the days of the week for the yearly schedule.')]
        [string[]]
        ${YearlyRetentionDaysOfTheWeek},       

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the days of the month for the monthly schedule.')]
        [ValidateRange(1, 28)]
        [int[]]
        ${YearlyRetentionDaysOfTheMonth},       

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Boolean parameter to enable the day based yearly retention on last day of the month.')]
        [Nullable[bool]]
        ${YearlyRetentionIsLastDayIncluded},

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the weeks of the month for the monthly schedule.')]
        [string[]]
        ${YearlyRetentionWeeksOfTheMonth},       
       
        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the retention period for Differential Backup')]   
        [ValidateRange(7, 180)]
        [Nullable[int]]
        ${DifferentialRetentionPeriodInDays},           

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the retention period for Incremental Backup')]   
        [ValidateRange(7, 180)]
        [Nullable[int]]
        ${IncrementalRetentionPeriodInDays},   

        [Parameter(ParameterSetName="ModifyRetentionPolicy", HelpMessage='Specifies the retention period for Log Backup')]
        [ValidateRange(7, 35)]
        [Nullable[int]]
        ${LogRetentionPeriodInDays}
    )

    process 
    {
          $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
          
          #Validation part begins

          $parametersToTest = @{}
          $commandParameters = (Get-Command Edit-AzRecoveryServicesBackupRetentionPolicyClientObject).Parameters
          # Retrieve the parameter names and their default values
          foreach ($parameter in $commandParameters.Values) {
              $parameterName = $parameter.Name
              $defaultValue = $parameter.DefaultValue
              # Skip parameters with default value of null or empty string
              if ($defaultValue -ne $null -and $defaultValue -ne '') {
                  $parametersToTest[$parameterName] = $defaultValue
              }
          }
          ValidateRetentionParameters -Policy $Policy -DatasourceType $DatasourceType -parametersToTest $parametersToTest
          ValidateDaysOfTheWeek -DatasourceType $DatasourceType -WeeklyRetentionDaysOfTheWeek $WeeklyRetentionDaysOfTheWeek -MonthlyRetentionDaysOfTheWeek $MonthlyRetentionDaysOfTheWeek -YearlyRetentionDaysOfTheWeek $YearlyRetentionDaysOfTheWeek
          ValidateMonthsOfTheYear -DatasourceType $DatasourceType -YearlyRetentionMonthsOfTheYear $YearlyRetentionMonthsOfTheYear
          ValidateWeeksOfTheMonth -DatasourceType $DatasourceType -MonthlyRetentionWeeksOfTheMonth $MonthlyRetentionWeeksOfTheMonth -YearlyRetentionWeeksOfTheMonth $YearlyRetentionWeeksOfTheMonth
          
          # main code begins
          $policyObject = $Policy 
          $scheduletime=$null
          if($policyObject.PolicyType -eq "V2")
          {
              if($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Hourly")
              {
                  $scheduletime=$policyObject.SchedulePolicy.HourlySchedule.ScheduleWindowStartTime
              }
              elseif($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Daily")
              {
                  $scheduletime=$policyObject.SchedulePolicy.DailyScheduleRunTime
              }
              elseif($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
              {
                  $scheduletime=$policyObject.SchedulePolicy.WeeklyScheduleRunTime
              }
          }
          else
          {
              $scheduletime=$policyObject.SchedulePolicy.ScheduleRunTime
          }

          if(-not($ModifyFullBackup))
          {
              if($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Weekly" -and ($policyObject.RetentionPolicy.DailySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.RetentionPolicy.DailySchedule.RetentionDuration.Count -ne 0))
              {
                  $policyObject.RetentionPolicy.DailySchedule = $null
                  Write-Warning "Daily Retention is disabled when Schedule run frequency is weekly"
              }
              elseif ($EnableDailyRetention -eq $false) 
              {
                  if($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Daily")
                  {
                      $errormsg = "Daily retention can't be disabled when backup schedule frequency is Daily"
                      throw $errormsg
                  }
                  else
                  {
                      $policyObject.RetentionPolicy.DailySchedule = $null
                  }
              }
              elseif ($EnableDailyRetention -eq $true) 
              {   
                  if($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                  {
                      $policyObject.RetentionPolicy.DailySchedule = $null
                      $errormsg="Daily retention can't be enabled with weekly backup schedule."
                      throw $errormsg
                  }
                  if (($policyObject.RetentionPolicy.DailySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.RetentionPolicy.DailySchedule.RetentionDuration.Count -ne 0)) 
                  {
                      # DailySchedule exists, check retentionDuration
                      if ( $DailyRetentionDurationInDays -ne $null ) 
                      {
                         $policyObject.RetentionPolicy.DailySchedule.RetentionDuration.Count = $DailyRetentionDurationInDays 
                      }
                  }
                  else
                  {
                     # DailySchedule doesn't exist, create a new one
                     $policyObject.RetentionPolicy.DailySchedule = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionSchedule]::new()
                     $policyObject.RetentionPolicy.DailySchedule.retentionDuration = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration]::new()
                     $policyObject.RetentionPolicy.DailySchedule.RetentionDuration.Count = $DailyRetentionDurationInDays
                     $policyObject.RetentionPolicy.dailySchedule.retentionDuration.durationType = "Days"   
                  }
              }    
              if(($policyObject.RetentionPolicy.DailySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.RetentionPolicy.DailySchedule.RetentionDuration.Count -ne 0)) 
              {
                   $policyObject.RetentionPolicy.DailySchedule.RetentionTime=$scheduletime
              }


              if($EnableWeeklyRetention -eq $false)
              {
                  if($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                  {
                      $errormsg = "Weekly retention can't be disabled."
                      throw $errormsg
                  }
                  else
                  {
                      $policyObject.RetentionPolicy.WeeklySchedule=$null
                  }
              }
              elseif ($EnableWeeklyRetention -eq $true ) 
              { 
                  # Set weekly retention properties
                  if (($policyObject.RetentionPolicy.WeeklySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.RetentionPolicy.WeeklySchedule.RetentionDuration.Count -ne 0)) 
                  {
                      if ($WeeklyRetentionDaysOfTheWeek -ne $null)
                      {
                          if($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Daily")
                          {
                              $policyObject.RetentionPolicy.WeeklySchedule.DaysOfTheWeek=$WeeklyRetentionDaysOfTheWeek 
                          }
                          elseif($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                          {
                              $policyObject.RetentionPolicy.WeeklySchedule.DaysOfTheWeek=$policyObject.SchedulePolicy.ScheduleRunDay
                              Write-Host "Weekly retention days of the week can be modified only if schedule run days are modified for weekly schedule frequency"
                          }  
                      }
                      if($WeeklyRetentionDurationInWeeks -ne $null)
                      {
                          $policyObject.RetentionPolicy.WeeklySchedule.RetentionDuration[0].Count = $WeeklyRetentionDurationInWeeks 
                      }
                  }
                  else
                  {
                      $policyObject.RetentionPolicy.WeeklySchedule = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionSchedule]::new()
                      $policyObject.RetentionPolicy.WeeklySchedule.RetentionDuration = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration]::new()
                      $policyObject.RetentionPolicy.WeeklySchedule.RetentionDuration[0].Count = $WeeklyRetentionDurationInWeeks
                      $policyObject.RetentionPolicy.WeeklySchedule.RetentionDuration[0].DurationType = "Weeks"                     
                      if($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Daily")
                      {
                          $policyObject.RetentionPolicy.WeeklySchedule.DaysOfTheWeek =$WeeklyRetentionDaysOfTheWeek
                      }
                      elseif($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                      {
                          $policyObject.RetentionPolicy.WeeklySchedule.DaysOfTheWeek=$policyObject.SchedulePolicy.ScheduleRunDay
                      }
                  }
              }
              if (($policyObject.RetentionPolicy.WeeklySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.RetentionPolicy.WeeklySchedule.RetentionDuration.Count -ne 0)) 
              {
                   $policyObject.RetentionPolicy.WeeklySchedule.RetentionTime=$scheduletime
              }

              if($EnableMonthlyRetention -eq $false )
              {
                   $policyObject.RetentionPolicy.MonthlySchedule = $null
              }
              elseif ($EnableMonthlyRetention -eq $true ) 
              {
                   if($MonthlyRetentionScheduleType -ne $null)
                   {
                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType=$MonthlyRetentionScheduleType
                   }
                   if($policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Daily" -and $policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                   {
                       $errormsg1 = "Day Based monthly Retention can only be set with Daily Backup Schedule Frequency"
                       throw $errormsg1
                   }
                   # Set monthly retention properties
                   if (($policyObject.RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -ne $null) -and ($policyObject.RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -ne 0)) 
                   {
                       if($MonthlyRetentionDurationInMonths -ne $null)
                       {
                           $policyObject.RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count = $MonthlyRetentionDurationInMonths 
                       }
                       if($policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Weekly")   
                       {  
                           if ($MonthlyRetentionDaysOfTheWeek -ne $null)
                           {
                               if($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Daily")
                               {
                                   $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly[0].DaysOfTheWeek=$MonthlyRetentionDaysOfTheWeek
                               }
                               elseif($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Weekly") 
                               {
                                   $validDaysOfWeek = $policyObject.SchedulePolicy.ScheduleRunDay
                                   $selectedDays = $MonthlyRetentionDaysOfTheWeek | Where-Object { $validDaysOfWeek -contains $_ }
                                   if ($selectedDays.Count -ne $MonthlyRetentionDaysOfTheWeek.Count)
                                   {
                                       throw "Only schedule run days are valid for weekly schedule."
                                   }
                                   else
                                   {
                                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly[0].DaysOfTheWeek = $selectedDays
                                   }
                               }
                           }
                           if($MonthlyRetentionWeeksOfTheMonth -ne $null)   
                           {    
                               $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly[0].WeeksOfTheMonth=$MonthlyRetentionWeeksOfTheMonth
                           }
                       }
                       elseif($policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Daily") 
                       {
                           if($MonthlyRetentionDaysOfTheMonth -ne $null)
                           {
                               $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleDaily = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat]::new()
                               $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth += foreach ($day in $MonthlyRetentionDaysOfTheMonth) {
                                    $existingDay = $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth | Where-Object { $_.Date -eq $day }
                                    if ($existingDay -eq $null) {
                                        $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                                        $dayObject.Date = $day
                                        $dayObject
                                    }
                               }
                           }
                           if($MonthlyRetentionIsLastDayIncluded -eq $true)
                           {
                               $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                               $dayObject.Date = 0
                               $dayObject.IsLast = $true
                               $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth +=$dayObject
                           }
                       }
                   }
                   elseif($MonthlyRetentionScheduleType -eq "Daily") # monthly retention is null and retention schedule type is daily
                   {
                       $policyObject.RetentionPolicy.MonthlySchedule = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.MonthlyRetentionSchedule]::new()                   
                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionDuration = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration]::new()
                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionDuration.Count = $MonthlyRetentionDurationInMonths
                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionDuration.DurationType = "Months"
                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType=$MonthlyRetentionScheduleType
                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleDaily = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat]::new()
                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth += foreach ($day in $MonthlyRetentionDaysOfTheMonth) {
                            $existingDay = $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth | Where-Object { $_.Date -eq $day }
                            if ($existingDay -eq $null) {
                                $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                                $dayObject.Date = $day
                                $dayObject
                            }
                       }
                       if($MonthlyRetentionIsLastDayIncluded -eq $true)
                       {
                           $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                           $dayObject.Date = 0
                           $dayObject.IsLast = $true
                           $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth +=$dayObject
                       }
                   }
                   elseif($MonthlyRetentionScheduleType -eq "Weekly") # monthly retention is null and retention schedule type is weekly
                   {
                       $policyObject.RetentionPolicy.MonthlySchedule = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.MonthlyRetentionSchedule]::new()
                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionDuration = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration]::new()
                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionDuration.Count = $MonthlyRetentionDurationInMonths
                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionDuration.DurationType = "Months"
                       #$policyObject.RetentionPolicy.MonthlySchedule.RetentionTime=$policyObject.SchedulePolicy.ScheduleRunTime
                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat]::new()
                       $validDaysOfWeek = $policyObject.SchedulePolicy.ScheduleRunDay
                       $selectedDays = $MonthlyRetentionDaysOfTheWeek | Where-Object { $validDaysOfWeek -contains $_ }
                       if ($selectedDays.Count -eq 0) 
                       {
                           throw "Only schedule run days are valid for weekly schedule."
                       }
                       else
                       {
                           $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly[0].DaysOfTheWeek = $selectedDays
                       }
                       $policyObject.RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly[0].WeeksOfTheMonth = $MonthlyRetentionWeeksOfTheMonth
                   }
              }
              if (($policyObject.RetentionPolicy.MonthlySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.RetentionPolicy.MonthlySchedule.RetentionDuration.Count -ne 0)) 
              {
                   $policyObject.RetentionPolicy.MonthlySchedule.RetentionTime=$scheduletime
              }


              if($EnableYearlyRetention -eq $false) 
              {
                   $policyObject.RetentionPolicy.YearlySchedule = $null
              }
              elseif ($EnableYearlyRetention -eq $true ) 
              {     
                    if($YearlyRetentionScheduleType -ne $null)
                    {
                        $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleFormatType=$YearlyRetentionScheduleType 
                    }
                    if(($policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Daily") -and ($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Weekly"))
                    {
                        $errormsg1 = "Day Based Yearly Retention can only be set with Daily Backup Schedule Frequency"
                        throw $errormsg1
                    }
                    # Set yearly retention properties
                    if (($policyObject.RetentionPolicy.YearlySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.RetentionPolicy.YearlySchedule.RetentionDuration.Count -ne 0)) 
                    {
                        if($YearlyRetentionDurationInYears -ne $null)
                        {
                            $policyObject.RetentionPolicy.YearlySchedule.RetentionDuration.Count = $YearlyRetentionDurationInYears
                        }
                        if($YearlyRetentionMonthsOfTheYear -ne $null)
                        {
                            $policyObject.RetentionPolicy.YearlySchedule.MonthsOfYear=$YearlyRetentionMonthsOfTheYear
                        }
                        if($policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Daily")
                        {
                            $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleDaily = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat]::new()
                            if($YearlyRetentionDaysOfTheMonth -ne $null)
                            {
                                $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth += foreach ($day in $YearlyRetentionDaysOfTheMonth) {
                                     $existingDay = $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth | Where-Object { $_.Date -eq $day }
                                     if ($existingDay -eq $null) {
                                         $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                                         $dayObject.Date = $day
                                         $dayObject
                                     }
                                }
                            }
                            if($YearlyRetentionIsLastDayIncluded -eq $true)
                            {
                                $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                                $dayObject.Date = 0
                                $dayObject.IsLast = $true
                                $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth +=$dayObject
                            }
                        }
                        elseif($policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Weekly")
                        {
                            if($YearlyRetentionDaysOfTheWeek -ne $null)
                            {
                                if($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Daily")
                                {
                                    $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek =$YearlyRetentionDaysOfTheWeek
                                }
                                elseif($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                                {
                                   $validDaysOfWeek = $policyObject.SchedulePolicy.ScheduleRunDay
                                   $selectedDays = $YearlyRetentionDaysOfTheWeek | Where-Object { $validDaysOfWeek -contains $_ }
                                   if ($selectedDays.Count -ne $YearlyRetentionDaysOfTheWeek.Count) 
                                   {
                                       $errormsg="Only schedule run days are valid for weekly schedule."
                                       throw $errormsg
                                   }
                                   else
                                   {
                                       $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek = $selectedDays
                                   }
                                }
                            }
                            if($YearlyRetentionWeeksOfTheMonth -ne $null)
                            {
                                $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.WeeksOfTheMonth =$YearlyRetentionWeeksOfTheMonth
                            }
                        }                       
                    }
                    else # yearly retention is null 
                    {
                        $policyObject.RetentionPolicy.YearlySchedule = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.YearlyRetentionSchedule]::new()
                        $policyObject.RetentionPolicy.YearlySchedule.RetentionDuration = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration]::new()
                        $policyObject.RetentionPolicy.YearlySchedule.RetentionDuration.Count = $YearlyRetentionDurationInYears
                        $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleFormatType=$YearlyRetentionScheduleType
                        $policyObject.RetentionPolicy.YearlySchedule.RetentionDuration.DurationType = "Years"                             
              
                        $policyObject.RetentionPolicy.YearlySchedule.MonthsOfYear+=foreach ($monthOfYear in $YearlyRetentionMonthsOfTheYear){[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.MonthOfYear]::new()|
                                  Add-Member -MemberType NoteProperty -Name "MonthOfYear" -Value $monthOfYear -PassThru}
                        $policyObject.RetentionPolicy.YearlySchedule.MonthsOfYear =$YearlyRetentionMonthsOfTheYear
              
                        if($YearlyRetentionScheduleType -eq "Daily") # yearly retention is null and retention schedule type is daily
                        {
                            $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleDaily = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat]::new()
                            if($YearlyRetentionIsLastDayIncluded -eq $true)
                            {
                                $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                                $dayObject.Date = 0
                                $dayObject.IsLast = $true
                                $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth =$dayObject
                            }
                            $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth += foreach ($day in $YearlyRetentionDaysOfTheMonth) {
                                $existingDay = $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth | Where-Object { $_.Date -eq $day }
                                if ($existingDay -eq $null) {
                                    $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                                    $dayObject.Date = $day
                                    $dayObject
                                }
                            }
                            
                        }
                        elseif($YearlyRetentionScheduleType -eq "Weekly") # yearly retention is null and retention schedule type is Weekly
                        {
                            $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat]::new()
                            if($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Daily")
                            {
                                $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek = foreach ($DayOfWeek in $YearlyRetentionDaysOfTheWeek){[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DayOfWeek]::new()|
                                    Add-Member -MemberType NoteProperty -Name "DayOfWeek" -Value $DayOfWeek -PassThru}
                                $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek =$YearlyRetentionDaysOfTheWeek
                            }
                            elseif($policyObject.SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                            {
                                $validDaysOfWeek = $policyObject.SchedulePolicy.ScheduleRunDay
                                $selectedDays = $YearlyRetentionDaysOfTheWeek | Where-Object { $validDaysOfWeek -contains $_ }
                                if ($selectedDays.Count -ne $YearlyRetentionDaysOfTheWeek.Count)
                                {
                                    throw "Only schedule run days are valid for weekly schedule."
                                }
                                else
                                {
                                    $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek = $selectedDays
                                }
                            }
                            
                            $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.WeeksOfTheMonth = foreach ($WeekOfMonth in $YearlyRetentionWeeksOfTheMonth){[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.WeekOfMonth]::new()|
                                    Add-Member -MemberType NoteProperty -Name "WeekOfMonth" -Value $WeekOfMonth -PassThru}
                            $policyObject.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.WeeksOfTheMonth =$YearlyRetentionWeeksOfTheMonth
                        }
                    }
              }
              if (($policyObject.RetentionPolicy.YearlySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.RetentionPolicy.YearlySchedule.RetentionDuration.Count -ne 0)) 
              {
                   $policyObject.RetentionPolicy.YearlySchedule.RetentionTime=$scheduletime
              }

          }
          
          if($ModifyDifferentialBackup)
          {
               $FullBackupPolicy =  $policyObject.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
               $Index1 = $policyObject.SubProtectionPolicy.IndexOf($FullBackupPolicy)
              
               if($ModifyIncrementalBackup)        
               {
                   $errormsg= "Incremental backup is not allowed when Differential backup is enabled"
                   throw $errormsg
               }
               if($policyObject.SubProtectionPolicy[$Index1].SchedulePolicy.ScheduleRunFrequency -eq "Daily")
               {
                   $errormsg="Differential backup is not allowed for daily full backups."
                   throw $errormsg
               }
               else
               {
                   $policyObject.SubProtectionPolicy[$Index1].RetentionPolicy.DailySchedule=$null
                   $DifferentialPolicy = $policyObject.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Differential" }
                   if (-not $DifferentialPolicy )
                   {
                       $errormsg= "Differential policy dosen't exist. Please use the Edit-AzRecoveryServicesBackupSchedulePolicyClientObject command to initiate Differential backup."
                   }
                   else
                   {
                       $Index = $policyObject.SubProtectionPolicy.IndexOf($DifferentialPolicy)
                       if(($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount -eq $null) -or ($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount -eq 0))
                       {
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.SimpleRetentionPolicy]::new()
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.Type = "SimpleRetentionPolicy"
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicyType = "SimpleRetentionPolicy"
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationType = "Days"
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount = $DifferentialRetentionPeriodInDays
                       }
                       elseif(($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount -ne $null -or $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount -ne 0) -and ($DifferentialRetentionPeriodInDays -ne $null) )
                       {
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount = $DifferentialRetentionPeriodInDays
                       }
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationType="Days"
                   }                   
               }
               #Write-Host "Retention period for differential backups: $($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount)"
          }
          
          if($ModifyIncrementalBackup)
          {
               $FullBackupPolicy =  $policyObject.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
               $Index1 = $policyObject.SubProtectionPolicy.IndexOf($FullBackupPolicy)

               if($ModifyDifferentialBackup)
               {
                   $errormsg2= "Differential backup is not allowed when Incremental backup is enabled"
                   throw $errormsg2
               }
               if($policyObject.SubProtectionPolicy[$Index1].SchedulePolicy.ScheduleRunFrequency -eq "Daily")
               {
                   $errormsg="Incremental backup is not allowed for daily full backups."
                   throw $errormsg
               }
               else
               {
                   $policyObject.SubProtectionPolicy[$Index1].RetentionPolicy.DailySchedule=$null
                   $IncrementalPolicy =  $policyObject.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Incremental" }
                   if (-not $IncrementalPolicy)
                   {
                       $errormsg= "Incremental policy dosen't exist. Please use the Edit-AzRecoveryServicesBackupSchedulePolicyClientObject command to initiate Incremental backup."
                   }
                   else
                   {
                       $Index = $policyObject.SubProtectionPolicy.IndexOf($IncrementalPolicy)
                       if(($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount -eq $null) -or ($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount -eq 0))
                       {
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.SimpleRetentionPolicy]::new()
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.Type = "SimpleRetentionPolicy"
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicyType = "SimpleRetentionPolicy"
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationType = "Days"
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount = $IncrementalRetentionPeriodInDays
                       }
                       elseif(($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount -ne $null -or $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount -ne 0) -and ($IncrementalRetentionPeriodInDays -ne $null) )
                       {
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount = $IncrementalRetentionPeriodInDays
                       }
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationType="Days"
                   }                       
               }
               #Write-Host "Retention period for incremental backups: $($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount)"
          }
          
          if($ModifyLogBackup)
          {
               $LogBackupPolicy = $policyObject.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Log" }
               $Index = $policyObject.SubProtectionPolicy.IndexOf($LogBackupPolicy)
               if ($policyObject.SubProtectionPolicy[$index] -ne $null )
               {
                     if($LogRetentionPeriodInDays -ne $null)
                     {
                         $policyObject.SubProtectionPolicy[$index].RetentionPolicy.RetentionDurationCount = $LogRetentionPeriodInDays
                     }
                     $policyObject.SubProtectionPolicy[$index].RetentionPolicy.RetentionDurationType="Days"
                    # Write-Host "Retention period for log backups: $($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.RetentionDurationCount)"
               }               
          }
        
          if($ModifyFullBackup)
          {
              $FullBackupPolicy =  $policyObject.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
              $Index = $policyObject.SubProtectionPolicy.IndexOf($FullBackupPolicy)
              if($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Weekly" -and ($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count -ne 0))
              {
                  $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule = $null
                  Write-Warning "Daily Retention has been disabled since Schedule run frequency is weekly"
              }
              elseif ($EnableDailyRetention -eq $false) 
              {
                  if($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Daily")
                  {
                      $errormsg = "Daily retention can't be disabled when backup schedule frequency is Daily."
                      throw $errormsg
                  }
                  else
                  {
                      $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule = $null
                  }
              }
              elseif ($EnableDailyRetention -eq $true) 
              { 
                  if($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                  {
                      $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule = $null
                      $errormsg="Daily retention can't be enabled with weekly backup schedule."
                      throw $errormsg
                  }
                  if (($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count -ne 0)) 
                  {
                      # DailySchedule exists, check retentionDuration
                      if ( $DailyRetentionDurationInDays -ne $null ) 
                      {
                         $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count = $DailyRetentionDurationInDays 
                      }                      
                  }
                  else
                  {
                     # DailySchedule doesn't exist, create a new one
                     $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionSchedule]::new()
                     $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.retentionDuration = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration]::new()
                     $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count = $DailyRetentionDurationInDays
                     $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.dailySchedule.retentionDuration.durationType = "Days"                  
                  }
              }
              if (($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionDuration.Count -ne 0)) 
              {
                  $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.DailySchedule.RetentionTime=$policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunTime    
              }


              
              if($EnableWeeklyRetention -eq $false)
              {
                  if($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                  {
                      $errormsg = "Weekly retention can't be disabled."
                      throw $errormsg
                  }
                  else
                  {
                      $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule=$null
                  }
              }
              elseif ($EnableWeeklyRetention -eq $true ) 
              { 
                  # Set weekly retention properties
                  
                  if (($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration.Count -ne 0))
                  {
                      if ($WeeklyRetentionDaysOfTheWeek -ne $null)
                      { 
                          if($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Daily") 
                          {
                              $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.DaysOfTheWeek = $WeeklyRetentionDaysOfTheWeek 
                          }
                          elseif($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                          {
                              $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.DaysOfTheWeek=$policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunDay
                              Write-Host "Weekly retention days of the week can be modified only if schedule run days are modified for weekly schedule frequency"
                          }  
                      }
                      if($WeeklyRetentionDurationInWeeks -ne $null)
                      {
                          $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration[0].Count = $WeeklyRetentionDurationInWeeks 
                      }
                  }
                  else
                  {
                      $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionSchedule]::new()
                      $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration]::new()
                      $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration[0].Count = $WeeklyRetentionDurationInWeeks
                      $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration[0].DurationType = "Weeks"
                      $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionTime=$policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunTime
                      if($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                      {
                          $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.DaysOfTheWeek=$policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunDay
                      }
                      elseif($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Daily")
                      {
                          $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.DaysOfTheWeek =$WeeklyRetentionDaysOfTheWeek
                      }
                  }
              }
              if (($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionDuration.Count -ne 0))
              {
                  $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.WeeklySchedule.RetentionTime=$policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunTime
              }

          
              if($EnableMonthlyRetention -eq $false )
              {
                   $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule = $null
              }
              elseif ($EnableMonthlyRetention -eq $true ) 
              {
                   if($MonthlyRetentionScheduleType -ne $null)
                   {
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType=$MonthlyRetentionScheduleType
                       
                   }
                   if($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Daily" -and $policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                   {
                       $errormsg1 = "Day Based monthly Retention can only be set with Daily Backup Schedule Frequency"
                       throw $errormsg1
                   }
                   # Set monthly retention properties
                   if (($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -ne $null) -and ($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -ne 0)) 
                   {
                       if($MonthlyRetentionDurationInMonths -ne $null)
                       {
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count = $MonthlyRetentionDurationInMonths 
                       }
                       if($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Weekly")   
                       {  
                           if ($MonthlyRetentionDaysOfTheWeek -ne $null)
                           {
                               if($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Daily")
                               {
                                   $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly[0].DaysOfTheWeek=$MonthlyRetentionDaysOfTheWeek
                               }
                               elseif($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Weekly") 
                               {
                                   $validDaysOfWeek = $policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunDay
                                   $selectedDays = $MonthlyRetentionDaysOfTheWeek | Where-Object { $validDaysOfWeek -contains $_ }
                                   if ($selectedDays.Count -ne $MonthlyRetentionDaysOfTheWeek.Count)
                                   {
                                       throw "Only schedule run days are valid for weekly schedule."
                                   }
                                   else
                                   {
                                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly[0].DaysOfTheWeek = $selectedDays
                                   }
                               }
                           }
                           if($MonthlyRetentionWeeksOfTheMonth -ne $null)   
                           {    
                               $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly[0].WeeksOfTheMonth=$MonthlyRetentionWeeksOfTheMonth
                           }
                       }
                       elseif($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType -eq "Daily")
                       {
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleDaily = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat]::new()
                           if($MonthlyRetentionDaysOfTheMonth -ne $null)
                           {
                               $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth += foreach ($day in $MonthlyRetentionDaysOfTheMonth) {
                                    $existingDay = $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth | Where-Object { $_.Date -eq $day }
                                    if ($existingDay -eq $null) {
                                        $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                                        $dayObject.Date = $day
                                        $dayObject
                                    }
                               }
                           }
                           if($MonthlyRetentionIsLastDayIncluded -eq $true)
                           {
                               $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                               $dayObject.Date = 0
                               $dayObject.IsLast = $true
                               $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth +=$dayObject
                           }
                       }
                   }
                   elseif($MonthlyRetentionScheduleType -eq "Daily") # monthly retention is null and retention schedule type is daily
                   {
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.MonthlyRetentionSchedule]::new()                   
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration]::new()
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration.Count = $MonthlyRetentionDurationInMonths
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration.DurationType = "Months"
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleFormatType=$MonthlyRetentionScheduleType
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionTime=$policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunTime
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleDaily = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat]::new()
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth += foreach ($day in $MonthlyRetentionDaysOfTheMonth) {
                            $existingDay = $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth | Where-Object { $_.Date -eq $day }
                            if ($existingDay -eq $null) {
                                $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                                $dayObject.Date = $day
                                $dayObject
                            }
                       }
                       if($MonthlyRetentionIsLastDayIncluded -eq $true)
                       {
                           $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                           $dayObject.Date = 0
                           $dayObject.IsLast = $true
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth +=$dayObject
                       }
                   }
                   elseif($MonthlyRetentionScheduleType -eq "Weekly") # monthly retention is null and retention schedule type is weekly
                   {
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.MonthlyRetentionSchedule]::new()
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration]::new()
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration.Count = $MonthlyRetentionDurationInMonths
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration.DurationType = "Months"
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat]::new()
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly[0].WeeksOfTheMonth = $MonthlyRetentionWeeksOfTheMonth
                       $validDaysOfWeek = $policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunDay
                       $selectedDays = $MonthlyRetentionDaysOfTheWeek | Where-Object { $validDaysOfWeek -contains $_ }
                       if ($selectedDays.Count -eq 0) 
                       {
                           throw "Only schedule run days are valid for weekly schedule."
                       }
                       else
                       {
                           $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly[0].DaysOfTheWeek = $selectedDays
                       }
                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly[0].WeeksOfTheMonth = $MonthlyRetentionWeeksOfTheMonth
                   }
              }
              if (($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -ne $null) -and ($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionDuration[0].Count -ne 0)) 
              {
                  $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.MonthlySchedule.RetentionTime=$policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunTime
              }

          
              if($EnableYearlyRetention -eq $false) 
              {
                   $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule = $null
              }
              elseif ($EnableYearlyRetention -eq $true ) 
              {
                    if($YearlyRetentionScheduleType -ne $null)
                    {
                        $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleFormatType=$YearlyRetentionScheduleType
                        
                    }
                    if($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Daily" -and $policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                    {
                        $errormsg1 = "Day Based yearly Retention can only be set with Daily Backup Schedule Frequency"
                        throw $errormsg1
                    }
                    # Set yearly retention properties
                    if (( $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration.Count -ne 0)) 
                    {
                        if($YearlyRetentionDurationInYears -ne $null)
                        {
                            $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration.Count = $YearlyRetentionDurationInYears
                        }
                        if($YearlyRetentionMonthsOfTheYear -ne $null)
                        {
                            $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.MonthsOfYear=$YearlyRetentionMonthsOfTheYear
                        }
                        if($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Daily")
                        {
                            $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleDaily = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat]::new()
                            if($YearlyRetentionDaysOfTheMonth -ne $null)
                            {                                
                                $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth = foreach ($day in $YearlyRetentionDaysOfTheMonth) {
                                     $existingDay = $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth | Where-Object { $_.Date -eq $day }
                                     if ($existingDay -eq $null) {
                                         $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                                         $dayObject.Date = $day
                                         $dayObject
                                     }
                                }
                            }
                            if($YearlyRetentionIsLastDayIncluded -eq $true)
                            {
                                $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                                $dayObject.Date = 0
                                $dayObject.IsLast = $true
                                $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth +=$dayObject
                            }
                        }
                        elseif($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleFormatType -eq "Weekly")
                        {
                            if($YearlyRetentionDaysOfTheWeek -ne $null)
                            {
                                if($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Daily")
                                {
                                    $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek =$YearlyRetentionDaysOfTheWeek
                                }
                                elseif($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                                {
                                   $validDaysOfWeek = $policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunDay
                                   $selectedDays = $YearlyRetentionDaysOfTheWeek | Where-Object { $validDaysOfWeek -contains $_ }
                                   if ($selectedDays.Count -ne $YearlyRetentionDaysOfTheWeek.Count)
                                   {
                                       throw "Only schedule run days are valid for weekly schedule."
                                   }
                                   else
                                   {
                                       $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly[0].DaysOfTheWeek = $selectedDays
                                   }
                                } 
                            }
                            if($YearlyRetentionWeeksOfTheMonth -ne $null)
                            {
                                $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.WeeksOfTheMonth =$YearlyRetentionWeeksOfTheMonth
                            }
                        }
                    }
                    else # yearly retention is null 
                    {
                        $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.YearlyRetentionSchedule]::new()
                        $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration]::new()
                        $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration.Count = $YearlyRetentionDurationInYears
                        $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleFormatType=$YearlyRetentionScheduleType
                        $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration.DurationType = "Years"     
          
                        $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.MonthsOfYear=foreach ($monthOfYear in $YearlyRetentionMonthsOfTheYear){[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.MonthOfYear]::new()|
                                  Add-Member -MemberType NoteProperty -Name "MonthOfYear" -Value $monthOfYear -PassThru}
                        $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.MonthsOfYear =$YearlyRetentionMonthsOfTheYear
          
                        if($YearlyRetentionScheduleType -eq "Daily") # yearly retention is null and retention schedule type is daily
                        {
                            $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleDaily = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat]::new()
                            $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth = foreach ($day in $YearlyRetentionDaysOfTheMonth) {
                                $existingDay = $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth | Where-Object { $_.Date -eq $day }
                                if ($existingDay -eq $null) {
                                    $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                                    $dayObject.Date = $day
                                    $dayObject
                                }
                            }
                            if($YearlyRetentionIsLastDayIncluded -eq $true)
                            {
                                $dayObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.Day]::new()
                                $dayObject.Date = 0
                                $dayObject.IsLast = $true
                                $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth +=$dayObject
                            }
                        }
                        elseif($YearlyRetentionScheduleType -eq "Weekly") # yearly retention is null and retention schedule type is Weekly
                        {
                            $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat]::new()
                        
                            if($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Daily")
                            {
                                $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek = foreach ($DayOfWeek in $YearlyRetentionDaysOfTheWeek){[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DayOfWeek]::new()|
                                    Add-Member -MemberType NoteProperty -Name "DayOfWeek" -Value $DayOfWeek -PassThru}
                                $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek =$YearlyRetentionDaysOfTheWeek
                            }
                            elseif($policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunFrequency -eq "Weekly")
                            {
                                $validDaysOfWeek = $policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunDay
                                $selectedDays = $YearlyRetentionDaysOfTheWeek | Where-Object { $validDaysOfWeek -contains $_ }
                                if ($selectedDays.Count -eq 0) 
                                {
                                    throw "Only schedule run days are valid for weekly schedule."
                                }
                                else
                                {
                                    $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly[0].DaysOfTheWeek = $selectedDays
                                }
                            }
               
                            $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.WeeksOfTheMonth = foreach ($WeekOfMonth in $YearlyRetentionWeeksOfTheMonth){[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.WeekOfMonth]::new()|
                                    Add-Member -MemberType NoteProperty -Name "WeekOfMonth" -Value $WeekOfMonth -PassThru}
                            $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.WeeksOfTheMonth =$YearlyRetentionWeeksOfTheMonth
                        }
                    }
              }
              if (( $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration.Count -ne $null) -and ($policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionDuration.Count -ne 0)) 
              {
                  $policyObject.SubProtectionPolicy[$Index].RetentionPolicy.YearlySchedule.RetentionTime=$policyObject.SubProtectionPolicy[$Index].SchedulePolicy.ScheduleRunTime
              }

          }      
      ValidateMandatoryFields -Policy $policyObject -DatasourceType $DatasourceType -EnableDailyRetention $EnableDailyRetention -EnableWeeklyRetention $EnableWeeklyRetention -EnableMonthlyRetention $EnableMonthlyRetention -EnableYearlyRetention $EnableYearlyRetention -DailyRetentionDurationInDays $DailyRetentionDurationInDays -WeeklyRetentionDurationInWeeks $WeeklyRetentionDurationInWeeks -WeeklyRetentionDaysOfTheWeek $WeeklyRetentionDaysOfTheWeek -MonthlyRetentionDurationInMonths $MonthlyRetentionDurationInMonths -MonthlyRetentionDaysOfTheMonth $MonthlyRetentionDaysOfTheMonth -MonthlyRetentionDaysOfTheWeek $MonthlyRetentionDaysOfTheWeek -MonthlyRetentionWeeksOfTheMonth $MonthlyRetentionWeeksOfTheMonth -YearlyRetentionDurationInYears $YearlyRetentionDurationInYears -YearlyRetentionMonthsOfTheYear $YearlyRetentionMonthsOfTheYear -YearlyRetentionDaysOfTheWeek $YearlyRetentionDaysOfTheWeek -YearlyRetentionDaysOfTheMonth $YearlyRetentionDaysOfTheMonth -YearlyRetentionWeeksOfTheMonth $YearlyRetentionWeeksOfTheMonth 

      # Return the modified $policyObject
      $policyObject     
    }
}
