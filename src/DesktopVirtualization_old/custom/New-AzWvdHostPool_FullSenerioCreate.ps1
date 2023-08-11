function New-AzWvdHostPool_FullSenerioCreate {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IHostPool')]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
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
        ${Name},

        [Parameter(HelpMessage='Desktop App Group Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${DesktopAppGroupName},

        [Parameter(HelpMessage='Workspace Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${WorkspaceName},

        [Parameter(Mandatory, HelpMessage='HostPool Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType]
        ${HostPoolType},

        [Parameter(Mandatory, HelpMessage='LoadBalancer Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.LoadBalancerType]
        ${LoadBalancerType},

        [Parameter(Mandatory, HelpMessage='Preferred App Group Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.PreferredAppGroupType]
        ${PreferredAppGroupType},

        [Parameter(Mandatory, HelpMessage='Location')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${Location}
    )

    process {
        $saveDesktopAppGroupName = $null
        if ($PSBoundParameters.ContainsKey("DesktopAppGroupName")) {
            $saveDesktopAppGroupName = $PSBoundParameters["DesktopAppGroupName"]
        }
        $saveWorkspaceName = $null
        if ($PSBoundParameters.ContainsKey("WorkspaceName")) {
            $saveWorkspaceName = $PSBoundParameters["WorkspaceName"]
        }
        $null = $PSBoundParameters.Remove("DesktopAppGroupName")
        $null = $PSBoundParameters.Remove("WorkspaceName")
        
        $hostpool = Az.DesktopVirtualization\New-AzWvdHostPool @PSBoundParameters

        $null = $PSBoundParameters.Remove("HostPoolType")
        $null = $PSBoundParameters.Remove("LoadBalancerType")
        $null = $PSBoundParameters.Remove("PreferredAppGroupType")
        $null = $PSBoundParameters.Remove("Name")
        $null = $PSBoundParameters.Add("ApplicationGroupName", $saveDesktopAppGroupName)
        $applicationGroup = Az.DesktopVirtualization\New-AzWvdApplicationGroup @PSBoundParameters `
            -HostPoolArmPath $hostpool.Id `
            -ApplicationGroupType "Desktop"

        $null = $PSBoundParameters.Remove("ApplicationGroupName")
        $null = $PSBoundParameters.Add("WorkspaceName", $saveWorkspaceName)
        $workspace = Az.DesktopVirtualization\New-AzWvdWorkspace @PSBoundParameters `
            -ApplicationGroupReference $applicationGroup.Id
        $hostpool
    }
}