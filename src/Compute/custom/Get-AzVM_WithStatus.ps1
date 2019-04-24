function Get-AzVM {
    [CmdletBinding(DefaultParameterSetName="WithStatus")]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Profile("latest-2019-04-01")]
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20181001.VirtualMachineWithStatus')]
    param(
        [Parameter(ParameterSetName='WithStatus')]
        [System.Uri]
        # The URI for the proxy server to use
        $Proxy,

        [Parameter(ParameterSetName='WithStatus')]
        [ValidateNotNull()]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        $ProxyCredential,

        [Parameter(ParameterSetName='WithStatus')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        $ProxyUseDefaultCredentials,
    
        [Parameter(ParameterSetName='WithStatus', Mandatory=$true)]
        [System.Management.Automation.SwitchParameter]
        $Status
        )


    process {
           $PSBoundParameters.Remove("Status") | Out-Null
           Az.Compute\Get-AzVMAll @PSBoundParameters `
           | %{$vm = $_;$view = (Az.Compute\Invoke-AzInstanceVmView -ResourceGroupName ($_.Id.Split('/')[4]) -VmName $_.Name);  `
           New-Object -TypeName 'Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20181001.VirtualMachineWithStatus' -ArgumentList $vm, $view}

    }
}