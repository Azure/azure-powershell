
function New-AzDataProtectionPolicyTriggerScheduleClientObject{
	[OutputType('System.String[]')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates new Schedule object')]

    param (
        [Parameter(Mandatory, HelpMessage='Days with which backup will be scheduled.')]
        [System.DateTime[]]
        ${ScheduleDays},

        [Parameter(Mandatory, HelpMessage='Freuquency of the backup.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.BackupFrequency]
        ${IntervalType},

        [Parameter(Mandatory, HelpMessage='Frequency of the backup.')]
        [System.Int32]
        ${IntervalCount}
    )

    process {
        # DppRef: can add a TimeZone parameter to control the timezone and offset 

        # Validation for Interval Type and Interval count

        if(($IntervalType.ToString() -eq "Daily") -or ($IntervalType.ToString() -eq "Weekly"))
        {
            if($IntervalCount -ne 1)
            {
                throw "Interval Count for Daily or Weekly Backup must be 1."
            }
        }
        elseif($IntervalType.ToString() -eq "Hourly")
        {
            if(@(4, 6, 8, 12).Contains($IntervalCount) -eq $false)
            {
                throw "Interval Count for Hourly Backup must be one of 4, 6, 8, 12."
            }
        }

        # this completely ignores the timeZone given by user and anyway adds the offset as per time zone
        $timezone = Get-TimeZone
        $offset = $timezone.BaseUtcOffset.ToString()
        
        $repeatingTimeIntervals = @()

        foreach($day in $ScheduleDays){
            $format = $day.ToString("yyyy-MM-ddTHH:mm:ss")
            $backupFrequency = GetBackupFrequencyString -frequency $IntervalType -Count $IntervalCount

            if($offset.StartsWith("-")){
                $offset = $offset.Substring(0, 6)
                $timeInterval = "R/" + $format + $offset + "/" + $backupFrequency
            }
            else {
                $offset = $offset.Substring(0, 5)
                $timeInterval = "R/" + $format + "+" + $offset + "/" + $backupFrequency
            }
            
            $repeatingTimeIntervals += $timeInterval
        }
        
        return $repeatingTimeIntervals
    }
}