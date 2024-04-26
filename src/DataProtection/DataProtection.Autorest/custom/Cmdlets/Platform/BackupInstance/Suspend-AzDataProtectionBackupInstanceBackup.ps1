

function Suspend-AzDataProtectionBackupInstanceBackup
{   
	[OutputType('System.Boolean')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('This operation will stop backup for a backup instance and retains the backup data as per the policy except latest Recovery point, which will be retained forever')]

    param(        
        [Parameter(ParameterSetName="Suspend", Mandatory=$false, HelpMessage='Subscription Id of the backup vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(ParameterSetName="Suspend", Mandatory, HelpMessage='The name of the resource group where the backup vault is present')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(ParameterSetName="Suspend", Mandatory, HelpMessage='The name of the backup instance')]
        [System.String]
        ${BackupInstanceName},

        [Parameter(ParameterSetName="Suspend", Mandatory, HelpMessage='The name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(ParameterSetName="SuspendViaIdentity", Mandatory, HelpMessage='Identity Parameter To construct, see NOTES section for INPUTOBJECT properties and create a hash table.', ValueFromPipeline=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity]
        ${InputObject},

        [Parameter(Mandatory=$false, HelpMessage='Resource guard operation request in the format similar to <ResourceGuard-ARMID>/dppDisableSuspendBackupsRequests/default. Use this parameter when the operation is MUA protected.')]
        [System.String[]]
        ${ResourceGuardOperationRequest},

        [Parameter(Mandatory=$false, HelpMessage='Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Token to fetch authorization token for different tenant.')]
        [System.String]        
        ${Token},

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
        if($parameterSetName -eq "SuspendViaIdentity"){
            $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.SuspendBackupRequest]::new()

            $hasResourceGuardOperationRequest = $PSBoundParameters.Remove("ResourceGuardOperationRequest")
            if($hasResourceGuardOperationRequest){
                $Parameter.ResourceGuardOperationRequest = $ResourceGuardOperationRequest
            }

            $null = $PSBoundParameters.Add("Parameter", $Parameter)
        }

        if($PSBoundParameters.ContainsKey("Token"))
        {            
            $null = $PSBoundParameters.Remove("Token")
            $null = $PSBoundParameters.Add("Token", "Bearer $Token")
        }                
     
        Az.DataProtection.Internal\Suspend-AzDataProtectionBackupInstanceBackup @PSBoundParameters
    }
}