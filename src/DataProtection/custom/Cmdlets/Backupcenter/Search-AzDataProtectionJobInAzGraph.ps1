function Search-AzDataProtectionJobInAzGraph
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

        [Parameter(Mandatory=$false, HelpMessage='Start Time of the backup Job')]
        [System.DateTime]
        ${StartTime},

        [Parameter(Mandatory=$false, HelpMessage='End Time of the Backup Job')]
        [System.DateTime]
        ${EndTime},

        [Parameter(Mandatory=$false, HelpMessage='Operation of the Job Filter')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.JobOperation[]]
        ${Operation},

        [Parameter(Mandatory=$false, HelpMessage='Status of the Job Filter')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.JobStatus[]]
        ${Status},

        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        ${DatasourceType}
    )

    process 
    {
        CheckResourceGraphModuleDependency

        $manifest = LoadManifest -DatasourceType $DatasourceType
        $query = GetBackupJobARGQuery
        $query = AddFilterToQuery -Query $query -FilterKey "properties.dataSourceType" -FilterValues $manifest.datasourceType

        if($PSBoundParameters.ContainsKey("ResourceGroup")) { $query = AddFilterToQuery -Query $query -FilterKey "resourceGroup" -FilterValues  $resourceGroup }
        if($PSBoundParameters.ContainsKey("Vault")) { $query = AddFilterToQuery -Query $query -FilterKey "vaultName" -FilterValues  $Vault }
        if($PSBoundParameters.ContainsKey("Operation")) { $query = AddFilterToQuery -Query $query -FilterKey "operation" -FilterValues $Operation }
        if($PSBoundParameters.ContainsKey("Status")) { $query = AddFilterToQuery -Query $query -FilterKey "status" -FilterValues $Status }

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
            $query += "| where properties.endTime < datetime(" + $endTimeFilter + ")"
        }

        foreach($param in @("Subscription", "ResourceGroup", "Vault", "StartTime", "EndTime", "Operation", "DatasourceType", "Status"))
        {
            if($PSBoundParameters.ContainsKey($param))
            {
                $null = $PSBoundParameters.Remove($param)
            }
        }

        $null = $PSBoundParameters.Add("Subscription", $Subscription)
        $null = $PSBoundParameters.Add("query", $query)
        $null = $PSBoundParameters.Add("First", 1000)

        $argJobResponse = Az.ResourceGraph\Search-AzGraph @PSBoundParameters

        $backupJobs = @()
        foreach($jobresponse in $argJobResponse)
        {
            $jsonStringResponse = $jobresponse | ConvertTo-Json -Depth 100
            $backupJobs += [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupJobResource]::FromJsonString($jsonStringResponse)
        }
        return $backupJobs
    }
}