<#
.Synopsis
Get a Site
.Description
Get a Site from different scopes: Resource Group, Subscription, or Service Group
.Parameter Name
The name of the Site (optional for list operations)
.Parameter ResourceGroupName
The name of the resource group. Required for resource group scope operations.
.Parameter SubscriptionId
The ID of the target subscription. Required for resource group and subscription scope operations.
.Parameter ServicegroupName
The name of the service group. Required for service group scope operations.
.Parameter InputObject
Identity Parameter for pipeline operations
.Parameter DefaultProfile
The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available.
.Example
# Get a specific site at resource group scope
Get-AzSite -Name "MySite" -ResourceGroupName "MyRG" -SubscriptionId "12345678-1234-1234-1234-123456789012"

.Example
# List all sites in a subscription
Get-AzSite -SubscriptionId "12345678-1234-1234-1234-123456789012"

.Example
# Get a specific site at subscription scope
Get-AzSite -Name "MySite" -SubscriptionId "12345678-1234-1234-1234-123456789012"

.Example
# Get a specific site at service group scope
Get-AzSite -Name "MySite" -ServicegroupName "MyServiceGroup"

.Example
# List all sites in a service group
Get-AzSite -ServicegroupName "MyServiceGroup"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISiteIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISite
.Link
https://learn.microsoft.com/powershell/module/az.site/get-azsite
#>
function Get-AzSite {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISite])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter()]
        [Alias('SiteName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Path')]
        [System.String]
        # The name of the Site
        ${Name},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Path')]
        [System.String]
        # The name of the resource group. Required for resource group scope.
        ${ResourceGroupName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # The ID of the target subscription. Required for resource group and subscription scope.
        ${SubscriptionId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Path')]
        [System.String]
        # The name of the service group. Required for service group scope.
        ${ServicegroupName},

        [Parameter(ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISiteIdentity]
        # Identity Parameter
        ${InputObject},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The DefaultProfile parameter is not functional.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        # Handle InputObject parameter for pipeline scenarios
        if ($PSBoundParameters.ContainsKey('InputObject')) {
            # Extract parameters from InputObject and route accordingly
            if ($InputObject.ResourceGroupName -and $InputObject.SubscriptionId) {
                # Resource Group scope
                Az.Site.internal\Get-AzSite @PSBoundParameters
            }
            elseif ($InputObject.ServicegroupName) {
                # Service Group scope
                $null = $PSBoundParameters.Remove('SubscriptionId')
                $null = $PSBoundParameters.Remove('ResourceGroupName')
                Az.Site.internal\Get-AzSiteSitesByServiceGroup @PSBoundParameters
            }
            elseif ($InputObject.SubscriptionId) {
                # Subscription scope
                $null = $PSBoundParameters.Remove('ResourceGroupName')
                $null = $PSBoundParameters.Remove('ServicegroupName')
                Az.Site.internal\Get-AzSiteSitesBySubscription @PSBoundParameters
            }
            return
        }

        # Determine scope based on provided parameters
        if ($PSBoundParameters.ContainsKey('SubscriptionId') -and 
            $PSBoundParameters.ContainsKey('ResourceGroupName')) {
            # Resource Group Scope - call base generated cmdlet (uses Name parameter)
            $null = $PSBoundParameters.Remove('ServicegroupName')
            Az.Site.internal\Get-AzSite @PSBoundParameters
        }
        elseif ($PSBoundParameters.ContainsKey('ServicegroupName')) {
            $null = $PSBoundParameters.Remove('SubscriptionId')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            Az.Site.internal\Get-AzSiteSitesByServiceGroup @PSBoundParameters
        }
        elseif ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('ServicegroupName')
            Az.Site.internal\Get-AzSiteSitesBySubscription @PSBoundParameters
        }
        else {
            throw "Must provide either (SubscriptionId + ResourceGroupName), SubscriptionId only, or ServicegroupName only"
        }
    }
}