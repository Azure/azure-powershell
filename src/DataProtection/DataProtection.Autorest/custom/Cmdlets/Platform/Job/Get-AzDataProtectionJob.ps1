function Get-AzDataProtectionJob
{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IAzureBackupJobResource')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Gets or lists jobs in a backup vault')]

    param(
        [Parameter(ParameterSetName="Get", Mandatory=$false, HelpMessage='Subscription Id of the vault')]
        [Parameter(ParameterSetName="List", Mandatory=$false, HelpMessage='Subscription Id of the vault')]        
        [System.String[]]
        ${SubscriptionId},

        [Parameter(ParameterSetName="Get", Mandatory=$true, HelpMessage='Resource Group of the backup vault')]
        [Parameter(ParameterSetName="List", Mandatory=$true, HelpMessage='Resource Group of the backup vault')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(ParameterSetName="Get", Mandatory=$true, HelpMessage='Name of the backup vault')]
        [Parameter(ParameterSetName="List", Mandatory=$true, HelpMessage='Name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(ParameterSetName="Get", Mandatory=$true, HelpMessage='Job ID to get a particular Job')]
        [Alias('JobId')]
        [System.String]
        ${Id},

        [Parameter(ParameterSetName="GetViaIdentity", Mandatory=$true, HelpMessage='Identity Parameter', ValueFromPipeline=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity]
        ${InputObject},

        [Parameter(ParameterSetName="Get", Mandatory=$false, HelpMessage='Switch parameter to fetch dataprotection job from secondary region (Cross Region Restore)')]
        [Parameter(ParameterSetName="List", Mandatory=$false, HelpMessage='Switch parameter to fetch dataprotection job from secondary region (Cross Region Restore)')]
        [Switch]
        ${UseSecondaryRegion},

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
        $jobs = $null
        $hasUseSecondaryRegion = $PSBoundParameters.Remove("UseSecondaryRegion")

        if($hasUseSecondaryRegion){
            $hasId = $PSBoundParameters.Remove("Id")

            # fetch vault from ARG
            $hasSubscriptionId = $PSBoundParameters.Remove("SubscriptionId")
            $null = $PSBoundParameters.Remove("ResourceGroupName")
            $null = $PSBoundParameters.Remove("VaultName")
            $PSBoundParameters.Add('ResourceGroup', $ResourceGroupName)
            $PSBoundParameters.Add('Vault', $VaultName)
            if($hasSubscriptionId) { $PSBoundParameters.Add('Subscription', $SubscriptionId) }
            
            $vault = Search-AzDataProtectionBackupVaultInAzGraph @PSBoundParameters

            $null = $PSBoundParameters.Remove("Subscription")
            $null = $PSBoundParameters.Remove("ResourceGroup")
            $null = $PSBoundParameters.Remove("Vault")
            $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)            
            if($hasSubscriptionId) { $PSBoundParameters.Add('SubscriptionId', $SubscriptionId) }            

            # Location - CRR secondary region - $vault.ReplicatedRegion[0]
            $PSBoundParameters.Add('Location', $vault.ReplicatedRegion[0])
            $PSBoundParameters.Add('SourceBackupVaultId', $vault.Id)
            $PSBoundParameters.Add('SourceRegion', $vault.Location)

            if($hasId){
                $PSBoundParameters.Add('JobId', $Id)
                Az.DataProtection.internal\Get-AzDataProtectionCrossRegionRestoreJobDetail @PSBoundParameters
            }
            else{
                 Az.DataProtection.internal\Get-AzDataProtectionCrossRegionRestoreJob @PSBoundParameters
            }
        }
        else{
            Az.DataProtection.internal\Get-AzDataProtectionJob @PSBoundParameters
        }
        
    }
}
