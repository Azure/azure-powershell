

function Unlock-AzDataProtectionResourceGuardOperation
{   
	[OutputType('System.String')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Unlocks the critical operation which is protected by the resource guard')]

    param(
        [Parameter(ParameterSetName="UnlockDelete", Mandatory=$false, HelpMessage='Subscription Id of the backup vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(ParameterSetName="UnlockDelete", Mandatory, HelpMessage='Resource Group name of the backup vault')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(ParameterSetName="UnlockDelete", Mandatory, HelpMessage='Name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(ParameterSetName="UnlockDelete", Mandatory=$false, HelpMessage='List of critical operations which are protected by the resourceGuard and need to be unlocked. Supported values are DeleteBackupInstance, DisableMUA')]
        [System.String[]]
        ${ResourceGuardOperationRequest},

        [Parameter(ParameterSetName="UnlockDelete", Mandatory=$false, HelpMessage='ARM Id of the resource that need to be unlocked for performing critical operation')]
        [System.String]
        ${ResourceToBeDeleted},
        
        [Parameter(ParameterSetName="UnlockDelete", Mandatory=$false, HelpMessage='Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Token to fetch authorization token for different tenant.')]
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
        $ResGuardProxy = $null
        if($SubscriptionId -ne $null){
            $ResGuardProxy = Get-AzDataProtectionResourceGuardMapping -VaultName $VaultName -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId
        }
        else {
            $ResGuardProxy = Get-AzDataProtectionResourceGuardMapping -VaultName $VaultName -ResourceGroupName $ResourceGroupName
        }
                
        $CriticalOperationsMap = @{ DisableMUA = "deleteResourceGuardProxyRequests"; DeleteBackupInstance = "deleteBackupInstanceRequests" }          
        
        # modify Critical operation exclusion list         
        $ResourceGuardOperationRequestInternal = [System.Collections.ArrayList]@()

        foreach($operation in $ResourceGuardOperationRequest)
        {
            if($CriticalOperationsMap.ContainsKey($operation)){
                $arrayIndex = $ResourceGuardOperationRequestInternal.Add(($ResGuardProxy.ResourceGuardOperationDetail.DefaultResourceRequest | Where-Object { $_ -match $CriticalOperationsMap[$operation] } ))
            }
            else {
                $arrayIndex = $ResourceGuardOperationRequestInternal.Add($operation)
            }
        }

        if($PSBoundParameters.ContainsKey("ResourceGuardOperationRequest"))
        {
            $null = $PSBoundParameters.Remove("ResourceGuardOperationRequest")
            $null = $PSBoundParameters.Add("ResourceGuardOperationRequest", $ResourceGuardOperationRequestInternal)
        }

        if($PSBoundParameters.ContainsKey("Token"))
        {            
            $null = $PSBoundParameters.Remove("Token")
            $null = $PSBoundParameters.Add("Token", "Bearer $Token")
        }
       
        Az.DataProtection.Internal\Unlock-AzDataProtectionDppResourceGuardProxyDelete @PSBoundParameters
    }
}