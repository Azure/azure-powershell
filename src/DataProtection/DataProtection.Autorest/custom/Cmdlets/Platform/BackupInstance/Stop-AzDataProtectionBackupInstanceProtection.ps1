

function Stop-AzDataProtectionBackupInstanceProtection
{   
	[OutputType('System.Boolean')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('This operation will stop protection of a backup instance and data will be held forever')]

    param(        
        [Parameter(ParameterSetName="Stop", Mandatory=$false, HelpMessage='Subscription Id of the backup vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(ParameterSetName="Stop", Mandatory, HelpMessage='The name of the resource group where the backup vault is present')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(ParameterSetName="Stop", Mandatory, HelpMessage='The name of the backup instance')]
        [System.String]
        ${BackupInstanceName},

        [Parameter(ParameterSetName="Stop", Mandatory, HelpMessage='The name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(ParameterSetName="StopViaIdentity", Mandatory, HelpMessage='Identity Parameter To construct, see NOTES section for INPUTOBJECT properties and create a hash table.', ValueFromPipeline=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity]
        ${InputObject},

        [Parameter(Mandatory=$false, HelpMessage='Resource guard operation request in the format similar to <ResourceGuard-ARMID>/dppDisableStopProtectionRequests/default. Use this parameter when the operation is MUA protected.')]
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
                
        [Parameter(HelpMessage='Run the command as a job')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(HelpMessage='Run the command asynchronously')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
        
        [Parameter(HelpMessage='Returns true when the command succeeds')]
        [System.Management.Automation.SwitchParameter]        
        ${PassThru},

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
        $parameterSetName = $PsCmdlet.ParameterSetName
        if($parameterSetName -eq "StopViaIdentity"){
            $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250201.StopProtectionRequest]::new()

            $hasResourceGuardOperationRequest = $PSBoundParameters.Remove("ResourceGuardOperationRequest")
            if($hasResourceGuardOperationRequest){
                $Parameter.ResourceGuardOperationRequest = $ResourceGuardOperationRequest
            }

            $null = $PSBoundParameters.Add("Parameter", $Parameter)
        }

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
        
        Az.DataProtection.Internal\Stop-AzDataProtectionBackupInstanceProtection @PSBoundParameters
    }
}