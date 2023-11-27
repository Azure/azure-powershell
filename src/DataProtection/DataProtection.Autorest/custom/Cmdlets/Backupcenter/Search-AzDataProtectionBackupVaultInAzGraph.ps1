function Search-AzDataProtectionBackupVaultInAzGraph
{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Searches for Backup vaults in Azure Resource Graph and retrieves the expected entries')]
    
    param (
        [Parameter(Mandatory, HelpMessage='Subscription of Vault')]
        [System.String[]]
        ${Subscription},

        [Parameter(Mandatory=$false, HelpMessage='Resource Group of Vault')]
        [System.String[]]
        ${ResourceGroup},

        [Parameter(Mandatory=$false, HelpMessage='Name of the vault')]
        [System.String[]]
        ${Vault}
    )

    process 
    {
        CheckResourceGraphModuleDependency

        # $manifest = LoadManifest -DatasourceType $DatasourceType
        $query = GetBackupVaultARGQuery

        if($PSBoundParameters.ContainsKey("ResourceGroup")){ $query = AddFilterToQuery -Query $query -FilterKey "resourceGroup" -FilterValues  $ResourceGroup }
        if($PSBoundParameters.ContainsKey("Vault")){ $query = AddFilterToQuery -Query $query -FilterKey "name" -FilterValues  $Vault }

        foreach($param in @("Subscription", "ResourceGroup", "Vault"))
        {
            if($PSBoundParameters.ContainsKey($param))
            {
                $null = $PSBoundParameters.Remove($param)
            }
        }
        $null = $PSBoundParameters.Add("Subscription", $Subscription)
        $null = $PSBoundParameters.Add("query", $query)
        $null = $PSBoundParameters.Add("First", 1000)

        $argAllVaults = Az.ResourceGraph\Search-AzGraph @PSBoundParameters
        $backupVaults = @()
        foreach($argVault in $argAllVaults)
        {
            $jsonStringResponse = $argVault | ConvertTo-Json -Depth 100                                                 
            $backupVaults += [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20231101.BackupVaultResource]::FromJsonString($jsonStringResponse)
        }
        return $backupVaults
    }
}