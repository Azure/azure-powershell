function Search-AzDataProtectionBackupInstanceInAzGraph
{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Searches for Backup instances in Azure Resource Graph and retrieves the expected entries')]
    
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

        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(Mandatory=$false, HelpMessage='Protection Status of the item')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProtectionStatus[]]
        ${ProtectionStatus}
    )

    process 
    {
        CheckResourceGraphModuleDependency

        $manifest = LoadManifest -DatasourceType $DatasourceType
        $query = GetBackupInstanceARGQuery
        $query = AddFilterToQuery -Query $query -FilterKey "properties.dataSourceInfo.datasourceType" -FilterValues $manifest.datasourceType

        if($PSBoundParameters.ContainsKey("ResourceGroup")){ $query = AddFilterToQuery -Query $query -FilterKey "resourceGroup" -FilterValues  $resourceGroup }
        if($PSBoundParameters.ContainsKey("Vault")){ $query = AddFilterToQuery -Query $query -FilterKey "vaultName" -FilterValues  $Vault }
        if($PSBoundParameters.ContainsKey("ProtectionStatus")){ $query = AddFilterToQuery -Query $query -FilterKey "protectionState" -FilterValues $ProtectionStatus }

        foreach($param in @("Subscription", "ResourceGroup", "Vault", "DatasourceType", "ProtectionStatus"))
        {
            if($PSBoundParameters.ContainsKey($param))
            {
                $null = $PSBoundParameters.Remove($param)
            }
        }

        $null = $PSBoundParameters.Add("Subscription", $Subscription)
        $null = $PSBoundParameters.Add("query", $query)
        $null = $PSBoundParameters.Add("First", 1000)

        $argInstanceResponse = Az.ResourceGraph\Search-AzGraph @PSBoundParameters
        $backupInstances = @()
        foreach($argResponse in $argInstanceResponse)
        {
            $jsonStringResponse = $argResponse | ConvertTo-Json -Depth 100
            $backupInstances += [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.BackupInstanceResource]::FromJsonString($jsonStringResponse)
        }
        return $backupInstances
    }
}