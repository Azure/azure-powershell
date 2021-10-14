function Update-AzLabServicesLabPlan_LabPlan {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILabPlan])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.LabPlan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
    ${LabPlan},

    [Parameter()]
    [String[]]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${AllowedRegions},

    [Parameter()]
    [timespan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${DefaultAutoShutdownProfileDisconnectDelay},

    [Parameter()]
    [timespan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${DefaultAutoShutdownProfileIdleDelay},

    [Parameter()]
    [timespan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${DefaultAutoShutdownProfileNoConnectDelay},
    
    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState])]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState]
    ${DefaultAutoShutdownProfileShutdownOnDisconnect},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ShutdownOnIdleMode])]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ShutdownOnIdleMode]
    ${DefaultAutoShutdownProfileShutdownOnIdle},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState])]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState]
    ${DefaultAutoShutdownProfileShutdownWhenNotConnected},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType])]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType]
    ${DefaultConnectionProfileClientRdpAccessEnabled},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType])]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType]
    ${DefaultConnectionProfileClientSshAccessEnabled},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${DefaultNetworkProfileSubnetId},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${LinkedLmsInstance},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${SharedGalleryId},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${SupportInfoEmail},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${SupportInfoInstructions},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${SupportInfoPhone},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${SupportInfoUrl},

    [Parameter()]
    [String[]]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${Tags},

    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

process {    
    $PSBoundParameters = $LabPlan.BindResourceParameters($PSBoundParameters)
    $PSBoundParameters.Remove("LabPlan") > $null
    return Az.LabServices\Update-AzLabServicesLabPlan @PSBoundParameters
}

}
