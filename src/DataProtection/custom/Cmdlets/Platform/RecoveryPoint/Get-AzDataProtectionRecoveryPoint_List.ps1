function Get-AzDataProtectionRecoveryPoint_List
{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Gets list of recovery point associated with a protected backup instance.')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id of the vault')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(HelpMessage='Resource Group of the backup vault')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(HelpMessage='Name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(HelpMessage='Unique Name of protected backup instance')]
        [System.String]
        ${BackupInstanceName},

        [Parameter(HelpMessage='Start Time filter for recovery points')]
        [System.DateTime]
        ${StartTime},

        [Parameter(HelpMessage='End Time filter for recovery points')]
        [System.DateTime]
        ${EndTime}
    )

    process
    {
        $filter = ""
        if($PSBoundParameters.ContainsKey("StartTime"))
        {
            $utcStartTime = $StartTime.ToUniversalTime()
            $startTimeFilter = $utcStartTime.ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
            $filter = "startDate eq '" + $startTimeFilter + "'"

        }
        if($PSBoundParameters.ContainsKey("EndTime"))
        {
            if($PSBoundParameters.ContainsKey("StartTime"))
            {
                $filter += " and "
            }
            $utcEndTime = $EndTime.ToUniversalTime()
            $endTimeFilter = $utcEndTime.ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
            $filter += "endDate eq '" + $endTimeFilter + "'"
            $null = $PSBoundParameters.Remove("EndTime")
        }

        if($PSBoundParameters.ContainsKey("StartTime"))
        {
            $null = $PSBoundParameters.Remove("StartTime")
        }

        if($filter -ne "")
        {
            $null = $PSBoundParameters.Add("Filter", $filter)
        }

        $rps = Az.DataProtection.internal\Get-AzDataProtectionRecoveryPointList @PSBoundParameters
        return $rps
    }
}