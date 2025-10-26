

function Update-AzDataProtectionBackupInstanceAssociatedPolicy
{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250201.IBackupInstanceResource')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Updates associated policy for a given backup instance')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id of the vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='Resource Group of the backup vault')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(Mandatory, HelpMessage='Unique Name of protected backup instance')]
        [System.String]
        ${BackupInstanceName},

        [Parameter(Mandatory, HelpMessage='Id of the Policy to be associated with the backup instance')]
        [System.String]
        ${PolicyId},
        
        [Parameter(Mandatory=$false, HelpMessage='Resource guard operation request in the format similar to <ResourceGuard-ARMID>/dppModifyPolicy/default. Use this parameter when the operation is MUA protected.')]
        [System.String[]]
        ${ResourceGuardOperationRequest},

        [Parameter(Mandatory=$false, HelpMessage='Parameter deprecate. Please use SecureToken instead.')]
        [System.String]
        ${Token},

        [Parameter(Mandatory=$false, HelpMessage='Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch authorization token for different tenant.')]
        [System.Security.SecureString]
        ${SecureToken},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process
    {
        $null = $PSBoundParameters.Remove("PolicyId")
        $instance = Az.DataProtection\Get-AzDataProtectionBackupInstance @PSBoundParameters
        $instance.Property.PolicyInfo.PolicyId = $PolicyId
        $null = $PSBoundParameters.Remove("BackupInstanceName")

        $hasResourceGuardOperationRequest = $PSBoundParameters.Remove("ResourceGuardOperationRequest")
        if($hasResourceGuardOperationRequest){
            $instance.Property.ResourceGuardOperationRequest = $ResourceGuardOperationRequest
        }
        
        # Explicitly setting the whole DSSetInfo object as null when ResourceID is null
        if($instance.Property.DataSourceSetInfo.ResourceId -eq $null){
            $instance.Property.DataSourceSetInfo =$null      
        }

        $null = $PSBoundParameters.Add("Parameter", $instance)
        $null = $PSBoundParameters.Add("Name", $instance.Name)        

        $hasToken = $PSBoundParameters.Remove("Token")
        $hasSecureToken = $PSBoundParameters.Remove("SecureToken")
        if($hasToken -or $hasSecureToken)
        {   
            if($hasSecureToken -and $hasToken){
                throw "Both Token and SecureToken parameters cannot be provided together"
            }
            elseif($hasToken){
                Write-Warning -Message 'The Token parameter is deprecated and will be removed in future versions. Please use SecureToken instead.'
                $null = $PSBoundParameters.Add("Token", "Bearer $Token")
            }
            else{
                $plainToken = UnprotectSecureString -SecureString $SecureToken
                $null = $PSBoundParameters.Add("Token", "Bearer $plainToken")
            }
        }

        Az.DataProtection.Internal\New-AzDataProtectionBackupInstance  @PSBoundParameters
    }
}