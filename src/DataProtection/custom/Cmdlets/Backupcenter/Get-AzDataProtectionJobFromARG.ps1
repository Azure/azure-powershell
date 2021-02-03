function Get-AzDataProtectionJobFromARG
{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Get Backup Vault storage setting object')]
    
    param (
        [Parameter(Mandatory, HelpMessage='Subscription of Vault')]
        [System.String[]]
        ${Subscription},

        [Parameter(Mandatory=$false, HelpMessage='Resource Group of Vault')]
        [System.String[]]
        ${ResourceGroup},

        [Parameter(Mandatory=$false, HelpMessage='Name of the vault')]
        [System.String[]]
        ${Vault},

        [Parameter(Mandatory=$false, HelpMessage='Name of the vault')]
        [System.DateTime]
        ${StartTime},

        [Parameter(Mandatory=$false, HelpMessage='Name of the vault')]
        [System.DateTime]
        ${EndTime}
    )

    process 
    {
        $query = "RecoveryServicesResources"
        $query = AddFilterToQuery -Query $query -FilterKey "type" -FilterValues "microsoft.dataprotection/backupvaults/backupjobs"
        if($PSBoundParameters.ContainsKey("ResourceGroup"))
        {
            $query = AddFilterToQuery -Query $query -FilterKey "resourceGroup" -FilterValues  $resourceGroup
        }

        if($PSBoundParameters.ContainsKey("Vault"))
        {
            $query = AddFilterToQuery -Query $query -FilterKey "properties.vaultName" -FilterValues  $Vault
        }

        if($StartTime -ne $null)
        {   
            $utcStartTime = $StartTime.ToUniversalTime()
            $startTimeFilter = $utcStartTime.ToString("yyyy-MM-ddTHH:mm:ssZ")
            $query += "| where properties.startTime > datetime(" + $startTimeFilter + ")"
        }

        if($EndTime -ne $null)
        {   
            $utcEndTime = $EndTime.ToUniversalTime()
            $endTimeFilter = $utcEndTime.ToString("yyyy-MM-ddTHH:mm:ssZ")
            $query += "| where properties.endTime > datetime(" + $endTimeFilter + ")"
        }

        foreach($param in @("Subscription", "ResourceGroup", "Vault", "StartTime", "EndTime"))
        {
            if($PSBoundParameters.ContainsKey($param))
            {
                $null = $PSBoundParameters.Remove($param)
            }
        }

        $null = $PSBoundParameters.Add("Subscription", $Subscription)
        $null = $PSBoundParameters.Add("query", $query)

        $argJobResponse = Az.ResourceGraph\Search-AzGraph @PSBoundParameters
        $jobs = @()
        foreach($jobresponse in $argJobResponse)
        {
            $jobs += [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.AzureBackupJobResource]::DeserializeFromPSObject($jobresponse.properties)
        }

        return $jobs
    }
}