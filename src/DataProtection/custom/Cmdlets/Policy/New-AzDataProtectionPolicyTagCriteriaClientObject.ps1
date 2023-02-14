function New-AzDataProtectionPolicyTagCriteriaClientObject{
<<<<<<< HEAD
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IScheduleBasedBackupCriteria')]
=======
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.IScheduleBasedBackupCriteria')]
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates a new criteria object')]

    param(
        [Parameter(ParameterSetName='AbsoluteCriteria', Mandatory, HelpMessage='Absolute criteria')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteTagCriteria]
        ${AbsoluteCriteria},

        [Parameter(ParameterSetName='ScheduleCriteria', HelpMessage='Days of the week')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DaysOfWeek[]]
        ${DaysOfWeek},

        [Parameter(ParameterSetName='ScheduleCriteria', HelpMessage='Weeks of the month.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeeksOfMonth[]]
        ${WeeksOfMonth},

        [Parameter(ParameterSetName='ScheduleCriteria', HelpMessage='Months of the year.')]
        [Parameter(ParameterSetName='MonthlyCriteria', HelpMessage='Months of the year.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.MonthsOfYear[]]
        ${MonthsOfYear},

        [Parameter(ParameterSetName='ScheduleCriteria', HelpMessage='Schedule times.')]
        [Parameter(ParameterSetName='MonthlyCriteria', HelpMessage='Schedule times.')]
        [System.DateTime[]]
        ${ScheduleTimes},

        [Parameter(ParameterSetName='MonthlyCriteria', Mandatory, HelpMessage='Days of the month. Allowed values are 1 to 28 and Last')]
        [System.String[]]
        ${DaysOfMonth}
    )

    process {
<<<<<<< HEAD
        $criteria = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.ScheduleBasedBackupCriteria]::new()
=======
        $criteria = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.ScheduleBasedBackupCriteria]::new()
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
        $criteria.ObjectType = "ScheduleBasedBackupCriteria"
        if($AbsoluteCriteria -ne $null){
            $criteria.AbsoluteCriterion = $AbsoluteCriteria
        }

        if($DaysOfWeek -ne $null){
            $criteria.DaysOfTheWeek = $DaysOfWeek | Foreach-Object { $_ = $_.ToString(); $_ }
        }

        if($WeeksOfMonth -ne $null){
            $criteria.WeeksOfTheMonth = $WeeksOfMonth | Foreach-Object { $_ = $_.ToString(); $_ }
        }

        if($MonthsOfYear -ne $null){
            $criteria.MonthsOfYear = $MonthsOfYear | Foreach-Object { $_ = $_.ToString(); $_ }
        }

        if($DaysOfMonth -ne $null){
            $criteria.DaysOfMonth = @()
            Foreach($dayOfMonth in $DaysOfMonth)
            {
                if($dayOfMonth -match "^[\d]+$")
                {
                    $dayOfMonthNumber = [int]$dayOfMonth
                    if(($dayOfMonthNumber -lt 1) -or ($dayOfMonthNumber -gt 28))
                    {
                        throw "Day of month should be between 1 and 28."
                    }
<<<<<<< HEAD
                    $day = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.Day]::new()
=======
                    $day = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.Day]::new()
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
                    $day.Date = $dayOfMonthNumber
                    $day.IsLast = $false
                    $criteria.DaysOfMonth += $day
                }
                else 
                {
                    if($dayOfMonth.ToLower() -ne "last")
                    {
                        thow "Day of month should either be between 1 and 28 or it should be last"
                    }
<<<<<<< HEAD
                    $day = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.Day]::new()
=======
                    $day = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.Day]::new()
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
                    $day.IsLast = $true
                    $criteria.DaysOfMonth += $day
                }
            }
        }

        if($ScheduleTimes -ne $null){
            $criteria.ScheduleTime = $ScheduleTimes
        }


        return $criteria
    }
}