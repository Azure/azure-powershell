function New-AzWvdRegistrationInfo {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20191210Preview.IRegistrationInfo')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials},

        [Parameter(Mandatory, HelpMessage='Subscription Id')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='Resource Group Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Host Pool Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${HostPoolName},

        [Parameter(Mandatory, HelpMessage='Expiration Time')]
        [System.String]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        ${ExpirationTime}
    )

    process {
        $saveExpirationTime = $PSBoundParameters["ExpirationTime"]
        $null = $PSBoundParameters.Remove("ExpirationTime")
        $hostpool = Az.DesktopVirtualization\Get-AzWvdHostPool @PSBoundParameters
        $hostpool = Az.DesktopVirtualization\New-AzWvdHostPool @PSBoundParameters `
            -Location $hostpool.Location `
            -HostPoolType $hostpool.HostPoolType `
            -LoadBalancerType $hostpool.LoadBalancerType `
            -RegistrationTokenOperation "Update" `
            -ExpirationTime $saveExpirationTime `
            -Description $hostpool.Description `
            -FriendlyName $hostpool.FriendlyName `
            -MaxSessionLimit $hostpool.MaxSessionLimit `
            -VMTemplate $hostpool.VMTemplate `
            -SsoContext $hostpool.SsoContext `
            -CustomRdpProperty $hostpool.CustomRdpProperty `
            -Ring $hostpool.Ring `
            -ValidationEnvironment:$hostpool.ValidationEnvironment
        New-Object -TypeName 'Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20191210Preview.RegistrationInfo' `
            -Property @{ `
                ExpirationTime = $hostpool.RegistrationInfoExpirationTime; `
                RegistrationTokenOperation = $hostpool.RegistrationInfoRegistrationTokenOperation; `
                Token = $hostpool.RegistrationInfoToken}
    }
}