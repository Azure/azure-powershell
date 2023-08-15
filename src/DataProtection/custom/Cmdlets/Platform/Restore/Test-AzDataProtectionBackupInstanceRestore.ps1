

function Test-AzDataProtectionBackupInstanceRestore
{   
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IOperationJobExtendedInfo')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Validates if Restore can be triggered for a DataSource')]

    param(
        [Parameter(ParameterSetName="ValidateRestore", Mandatory=$false, HelpMessage='Subscription Id of the backup vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(ParameterSetName="ValidateRestore", Mandatory, HelpMessage='The name of the resource group where the backup vault is present')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(ParameterSetName="ValidateRestore", Mandatory, HelpMessage='The name of the backup instance')]
        [System.String]
        ${Name},

        [Parameter(ParameterSetName="ValidateRestore", Mandatory, HelpMessage='The name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(ParameterSetName="ValidateRestore", Mandatory, HelpMessage='Restore request object for which to validate')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IAzureBackupRestoreRequest]
        ${RestoreRequest},

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
        $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.ValidateRestoreRequestObject]::new()
        $Parameter.RestoreRequestObject = $RestoreRequest
        $null = $PSBoundParameters.Remove("RestoreRequest")

        $null = $PSBoundParameters.Add("Parameter", $Parameter)
        
        Az.DataProtection.Internal\Test-AzDataProtectionBackupInstanceRestore @PSBoundParameters
    }
}