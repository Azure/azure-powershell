<#
.Synopsis
Creates or updates a DNS zone. Does not modify DNS records within the zone.
.Description
Creates or updates a DNS zone. Does not modify DNS records within the zone.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.dns/new-azdnszone
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IZone
.Link
https://docs.microsoft.com/en-us/powershell/module/az.dns/new-azdnszone
#>
function New-AzDnsZone {
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IZone')]
[CmdletBinding(DefaultParameterSetName='CreatePublic', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
[Microsoft.Azure.PowerShell.Cmdlets.Dns.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.Dns.Description('Creates or updates a DNS zone. Does not modify DNS records within the zone.')]
param(
    [Parameter(Mandatory, HelpMessage='The name of the DNS zone (without a terminating dot).')]
    [Alias('ZoneName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.Info(SerializedName='zoneName', Required, PossibleTypes=([System.String]), Description='The name of the DNS zone (without a terminating dot).')]
    [System.String]
    # The name of the DNS zone (without a terminating dot).
    ${Name},

    [Parameter(Mandatory, HelpMessage='The name of the resource group.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.Info(SerializedName='resourceGroupName', Required, PossibleTypes=([System.String]), Description='The name of the resource group.')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter(Mandatory, HelpMessage='Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription.
    ${SubscriptionId},

    [Parameter(Mandatory, HelpMessage='Resource location.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.Info(SerializedName='location', Required, PossibleTypes=([System.String]), Description='Resource location.')]
    [System.String]
    # Resource location.
    ${Location},

    [Parameter(HelpMessage='Does not overwrite the record set if it already exists.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Header')]
    [System.Management.Automation.SwitchParameter]
    # Does not overwrite the record set if it already exists.
    ${DoNotOverwrite},

    [Parameter(HelpMessage='The etag of the zone.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.Info(SerializedName='etag', PossibleTypes=([System.String]), Description='The etag of the zone.')]
    [System.String]
    # The etag of the zone.
    ${Etag},

    [Parameter(HelpMessage='Resource tags.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.Info(SerializedName='tags', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20171001.IResourceTags]), Description='Resource tags.')]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter(ParameterSetName='CreatePrivate', Mandatory, HelpMessage='When provided, creates a private DNS zone.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # When provided, creates a private DNS zone.
    ${Private},

    [Parameter(ParameterSetName='CreatePrivate', HelpMessage='A list of references to virtual networks that register hostnames in this DNS zone.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.Info(SerializedName='registrationVirtualNetworks', PossibleTypes=([System.String]), Description='A list of references to virtual networks that register hostnames in this DNS zone.')]
    [System.String[]]
    # A list of references to virtual networks that register hostnames in this DNS zone.
    ${RegistrationVirtualNetworkId},

    [Parameter(ParameterSetName='CreatePrivate', HelpMessage='A list of references to virtual networks that resolve records in this DNS zone.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.Info(SerializedName='resolutionVirtualNetworks', PossibleTypes=([System.String]), Description='A list of references to virtual networks that resolve records in this DNS zone.')]
    [System.String[]]
    # A list of references to virtual networks that resolve records in this DNS zone.
    ${ResolutionVirtualNetworkId},

    [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

process {
    $PSBoundParameters['ZoneType'] = [Microsoft.Azure.PowerShell.Cmdlets.Dns.Support.ZoneType]::Public
    if ($PSBoundParameters.ContainsKey('DoNotOverwrite')) {
        $null = $PSBoundParameters.Remove('DoNotOverwrite')
        $PSBoundParameters['IfNoneMatch'] = '*'
    }
    if ($PSBoundParameters.ContainsKey('Private')) {
        $null = $PSBoundParameters.Remove('Private')
        $PSBoundParameters['ZoneType'] = [Microsoft.Azure.PowerShell.Cmdlets.Dns.Support.ZoneType]::Private
        if ($PSBoundParameters.ContainsKey('RegistrationVirtualNetworkId')) {
            $null = $PSBoundParameters.Remove('RegistrationVirtualNetworkId')
            $PSBoundParameters['RegistrationVirtualNetwork'] = ($RegistrationVirtualNetworkId | ForEach-Object { @{ Id = $_ } })
        }
        if ($PSBoundParameters.ContainsKey('ResolutionVirtualNetworkId')) {
            $null = $PSBoundParameters.Remove('ResolutionVirtualNetworkId')
            $PSBoundParameters['ResolutionVirtualNetwork'] = ($ResolutionVirtualNetworkId | ForEach-Object { @{ Id = $_ } })
        }
    }
    Az.Dns.internal\New-AzDnsZone @PSBoundParameters
}
}
