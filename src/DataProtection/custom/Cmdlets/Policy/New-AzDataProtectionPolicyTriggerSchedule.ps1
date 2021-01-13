
function New-AzDataProtectionPolicyTriggerSchedule{
	[OutputType('System.String[]')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates new Schedule object')]

    param (
        [Parameter(Mandatory, HelpMessage='Source Datastore')]
        [System.DateTime[]]
        ${ScheduleDays},

        [Parameter(Mandatory, HelpMessage='Source Datastore')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.BackupFrequency]
        ${Frequency}
    )

    process {
        $timezone = Get-TimeZone
        $offset = $timezone.BaseUtcOffset.ToString()
        $offset = $offset.Substring(0, 5)

        $repeatingTimeIntervals = @()

        foreach($day in $ScheduleDays){
            $format = $day.ToString("yyyy-MM-ddTHH:mm:ss")
            $backupFrequency = GetBackupFrequencyString -frequency $Frequency
            $timeInterval = "R/" + $format + "+" + $offset + "/" + $backupFrequency
            $repeatingTimeIntervals += $timeInterval
        }
        
        return $repeatingTimeIntervals
    }
}