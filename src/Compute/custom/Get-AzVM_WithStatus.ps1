function Get-AzVM {
    [CmdletBinding()]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Profile("latest-2019-04-01")]
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20181001.IVirtualMachine')]
    param(
        [Parameter(ParameterSetName='WithStatus', DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(ParameterSetName='WithStatus', DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(ParameterSetName='WithStatus', DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(ParameterSetName='WithStatus', DontShow)]
        [System.Uri]
        # The URI for the proxy server to use
        $Proxy,

        [Parameter(ParameterSetName='WithStatus', DontShow)]
        [ValidateNotNull()]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        $ProxyCredential,

        [Parameter(ParameterSetName='WithStatus', DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        $ProxyUseDefaultCredentials,

        [Parameter(ParameterSetName='WithStatus')]
        [System.String]
        # The location for which virtual machines under the subscription are queried.
        $Location,

        [Parameter(ParameterSetName='WithStatus')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
        $SubscriptionId,

        [Parameter(ParameterSetName='WithStatus')]
        [System.String]
        # The name of the virtual machine.
        $Name,

        [Parameter(ParameterSetName='WithStatus')]
        [System.String]
        # The name of the resource group.
        $ResourceGroupName,

        [Parameter(ParameterSetName='WithStatus')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(ParameterSetName='WithStatus', Mandatory=$true)]
        [System.Management.Automation.SwitchParameter]
        $Status
        )


    process {
       $PSBoundParameters.Remove("Status") | Out-Null
       Az.Compute\Get-AzVM @PSBoundParameters `
       | %{New-Object -TypeName 'Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20181001.VirtualMachineWithStatus' -ArgumentList $_, `
       (Az.Compute\Invoke-AzViewVMInstance -ResourceGroupName ($_.Id.Split('/')[4]) -VmName $_.Name)}
    }
}