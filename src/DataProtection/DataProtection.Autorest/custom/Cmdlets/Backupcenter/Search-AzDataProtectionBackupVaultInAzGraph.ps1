function Search-AzDataProtectionBackupVaultInAzGraph
{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Searches for Backup vaults in Azure Resource Graph and retrieves the expected entries')]
    
    param (
        [Parameter(Mandatory, HelpMessage='Subscription of Vault')]
        [Alias('SubscriptionId')]
        [System.String[]]
        ${Subscription}, # TODO: add alias to all ARG command params

        [Parameter(Mandatory=$false, HelpMessage='Resource Group of Vault')]
        [Alias('ResourceGroupName')]
        [System.String[]]
        ${ResourceGroup},

        [Parameter(Mandatory=$false, HelpMessage='Name of the vault')]
        [Alias('VaultName')]
        [System.String[]]
        ${Vault},
        
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
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
        $null = $PSBoundParameters.Remove("HttpPipelinePrepend")

        $argAllVaults = Az.ResourceGraph\Search-AzGraph @PSBoundParameters
        $backupVaults = @()
        foreach($argVault in $argAllVaults)
        {
            $jsonStringResponse = $argVault | ConvertTo-Json -Depth 100                                                 
            $backupVaults += [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.BackupVaultResource]::FromJsonString($jsonStringResponse)
        }
        return $backupVaults
    }
}