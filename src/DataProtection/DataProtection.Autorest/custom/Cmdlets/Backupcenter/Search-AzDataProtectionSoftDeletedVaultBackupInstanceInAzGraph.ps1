function Search-AzDataProtectionSoftDeletedVaultBackupInstanceInAzGraph
{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Gets soft deleted backup instances from a deleted vault using Azure Resource Graph')]
    
    param (
        [Parameter(Mandatory=$false, HelpMessage='Subscription of Deleted Vault')]
        [System.String[]]
        ${Subscription},

        [Parameter(Mandatory=$false, HelpMessage='Name of the deleted vault')]
        [Alias('DeletedVaultGUID')]
        [System.String]
        ${DeletedVaultName},

        [Parameter(Mandatory=$false, HelpMessage='Deleted Vault ARM Id')]
        [System.String]
        ${DeletedVaultId},
        
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

        $query = GetSoftDeletedVaultBackupInstanceARGQuery
        
        # Add filters based on provided parameters
        if($PSBoundParameters.ContainsKey("DeletedVaultId"))
        { 
            $query += " | where id startswith '$DeletedVaultId'"
        }
        elseif($PSBoundParameters.ContainsKey("DeletedVaultName"))
        {
            $query += " | where id contains '/deletedVaults/$DeletedVaultName/'"
        }

        # Remove custom parameters before passing to Search-AzGraph
        foreach($param in @("DeletedVaultName", "DeletedVaultId"))
        {
            if($PSBoundParameters.ContainsKey($param))
            {
                $null = $PSBoundParameters.Remove($param)
            }
        }

        $null = $PSBoundParameters.Add("query", $query)
        $null = $PSBoundParameters.Remove("HttpPipelinePrepend")

        # Implement pagination to retrieve all results
        $backupInstances = @()
        $skipToken = 0
        $pageSize = 1000
        
        do {
            if($PSBoundParameters.ContainsKey("First")) {
                $null = $PSBoundParameters.Remove("First")
            }
            if($PSBoundParameters.ContainsKey("Skip")) {
                $null = $PSBoundParameters.Remove("Skip")
            }
            
            $null = $PSBoundParameters.Add("First", $pageSize)
            
            # Only add Skip parameter if we're not on the first page
            if($skipToken -gt 0) {
                $null = $PSBoundParameters.Add("Skip", $skipToken)
            }
            
            $argInstanceResponse = Az.ResourceGraph\Search-AzGraph @PSBoundParameters
            
            foreach($argResponse in $argInstanceResponse)
            {
                $jsonStringResponse = $argResponse | ConvertTo-Json -Depth 100
                $backupInstances += [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.DeletedBackupInstanceResource]::FromJsonString($jsonStringResponse)
            }
            
            $skipToken += $pageSize
            
        } while ($argInstanceResponse.Count -eq $pageSize)
        
        return $backupInstances
    }
}
