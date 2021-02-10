function New-AzDataProtectionPolicyTagCriteria{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IScheduleBasedBackupCriteria')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Prepares Datasource object for backup')]

    param(
        [Parameter(ParameterSetName='AbsoluteCriteria', Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteTagCriteria]
        ${AbsoluteCriteria},

        [Parameter(ParameterSetName='ScheduleCriteria', HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DaysOfWeek[]]
        ${DaysOfWeek},

        [Parameter(ParameterSetName='ScheduleCriteria', HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeeksOfMonth[]]
        ${WeeksOfMonth},

        [Parameter(ParameterSetName='ScheduleCriteria', HelpMessage='Datasource Type')]
        [Parameter(ParameterSetName='MonthlyCriteria', HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.MonthsOfYear[]]
        ${MonthsOfYear},

        [Parameter(ParameterSetName='ScheduleCriteria', HelpMessage='Datasource Type')]
        [Parameter(ParameterSetName='MonthlyCriteria', HelpMessage='Datasource Type')]
        [System.DateTime[]]
        ${ScheduleTimes},

        [Parameter(ParameterSetName='MonthlyCriteria', Mandatory, HelpMessage='Datasource Type')]
        [System.String[]]
        ${DaysOfMonth}
    )

    process {
        $criteria = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ScheduleBasedBackupCriteria]::new()
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
            $criteria.DaysOfMonth = $DaysOfMonth
        }

        if($ScheduleTimes -ne $null){
            $criteria.ScheduleTime = $ScheduleTimes
        }


        return $criteria
    }
}