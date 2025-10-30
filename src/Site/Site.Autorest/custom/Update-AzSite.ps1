<#
.Synopsis
Update a Site
.Description
Update a Site in different scopes: Resource Group, Subscription, or Service Group
.Parameter Name
The name of the Site
.Parameter ResourceGroupName
The name of the resource group. Required for resource group scope operations.
.Parameter SubscriptionId
The ID of the target subscription. Required for resource group and subscription scope operations.
.Parameter ServicegroupName
The name of the service group. Required for service group scope operations.
.Parameter Site
Site details
.Parameter JsonFilePath
Path of Json file supplied to the Site operation
.Parameter JsonString
Json string supplied to the Site operation
.Parameter InputObject
Identity Parameter for pipeline operations
.Parameter DefaultProfile
The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available.
.Parameter AsJob
Run the command as a job
.Parameter NoWait
Run the command asynchronously
.Example
# Update a site at resource group scope
Update-AzSite -Name "MySite" -ResourceGroupName "MyRG" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Site $siteObject

.Example
# Update a site at subscription scope
Update-AzSite -Name "MySite" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Site $siteObject

.Example
# Update a site at service group scope
Update-AzSite -Name "MySite" -ServicegroupName "MyServiceGroup" -Site $siteObject

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISiteIdentity
Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISite
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISite
.Link
https://learn.microsoft.com/powershell/module/az.site/update-azsite
#>
function Update-AzSite {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISite])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    param(
        [Parameter(Mandatory)]
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
        [System.String]
        # The ID of the target subscription. Required for resource group and subscription scope.
        ${SubscriptionId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Path')]
        [System.String]
        # The name of the service group. Required for service group scope.
        ${ServicegroupName},

        [Parameter(ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISite]
        # Site details
        ${Site},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Body')]
        [System.String]
        # Path of Json file supplied to the Site operation
        ${JsonFilePath},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Body')]
        [System.String]
        # Json string supplied to the Site operation
        ${JsonString},

        # Expanded parameters for Site creation
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Body')]
        [System.String]
        # Description of Site resource
        ${Description},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Body')]
        [System.String]
        # Display name of Site resource
        ${DisplayName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Body')]
        [System.String]
        # City of the address
        ${City},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Body')]
        [System.String]
        # Country of the address
        ${Country},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Body')]
        [System.String]
        # Postal or ZIP code of the address
        ${PostalCode},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Body')]
        [System.String]
        # State or province of the address
        ${StateOrProvince},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Body')]
        [System.String]
        # First line of the street address
        ${StreetAddress1},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Body')]
        [System.String]
        # Second line of the street address
        ${StreetAddress2},

        [Parameter()]
        [Alias('Labels')]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Body')]
        [System.Collections.Hashtable]
        # Key-value pairs for labeling the site resource
        ${Label},

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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

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
                if ($PSCmdlet.ShouldProcess("Site '$($InputObject.SiteName)' in Resource Group '$($InputObject.ResourceGroupName)'", "Update")) {
                    Az.Site.internal\Update-AzSite @PSBoundParameters
                }
            }
            elseif ($InputObject.ServicegroupName) {
                # Service Group scope
                $null = $PSBoundParameters.Remove('SubscriptionId')
                $null = $PSBoundParameters.Remove('ResourceGroupName')
                if ($PSCmdlet.ShouldProcess("Site '$($InputObject.SiteName)' in Service Group '$($InputObject.ServicegroupName)'", "Update")) {
                    Az.Site.internal\Update-AzSiteSitesByServiceGroup @PSBoundParameters
                }
            }
            elseif ($InputObject.SubscriptionId) {
                # Subscription scope
                $null = $PSBoundParameters.Remove('ResourceGroupName')
                $null = $PSBoundParameters.Remove('ServicegroupName')
                if ($PSCmdlet.ShouldProcess("Site '$($InputObject.SiteName)' in Subscription '$($InputObject.SubscriptionId)'", "Update")) {
                    Az.Site.internal\Update-AzSiteSitesBySubscription @PSBoundParameters
                }
            }
            return
        }

        # Determine scope based on provided parameters
        if ($PSBoundParameters.ContainsKey('SubscriptionId') -and 
            $PSBoundParameters.ContainsKey('ResourceGroupName')) {
            # Resource Group Scope - call base generated cmdlet
            if ($PSCmdlet.ShouldProcess("Site '$SiteName' in Resource Group '$ResourceGroupName'", "Update")) {
                Az.Site.internal\Update-AzSite @PSBoundParameters
            }
        }
        elseif ($PSBoundParameters.ContainsKey('ServicegroupName')) {
            # Service Group Scope - remove incompatible parameters
            $null = $PSBoundParameters.Remove('SubscriptionId')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            if ($PSCmdlet.ShouldProcess("Site '$SiteName' in Service Group '$ServicegroupName'", "Update")) {
                Az.Site.internal\Update-AzSiteSitesByServiceGroup @PSBoundParameters
            }
        }
        elseif ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            # Subscription Scope - remove incompatible parameters
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('ServicegroupName')
            if ($PSCmdlet.ShouldProcess("Site '$SiteName' in Subscription '$SubscriptionId'", "Update")) {
                Az.Site.internal\Update-AzSiteSitesBySubscription @PSBoundParameters
            }
        }
        else {
            throw "Must provide either (SubscriptionId + ResourceGroupName), SubscriptionId only, or ServicegroupName only"
        }
    }
}