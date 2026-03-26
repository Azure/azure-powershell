<#
.Synopsis
Delete a Site
.Description
Delete a Site from different scopes: Resource Group, Subscription, or Service Group
.Parameter Name
The name of the Site
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
.Parameter AsJob
Run the command as a job
.Parameter NoWait
Run the command asynchronously
.Parameter PassThru
Returns true when the command succeeds
.Example
# Remove a site at resource group scope
Remove-AzSite -Name "MySite" -ResourceGroupName "MyRG" -SubscriptionId "12345678-1234-1234-1234-123456789012"

.Example
# Remove a site at subscription scope
Remove-AzSite -Name "MySite" -SubscriptionId "12345678-1234-1234-1234-123456789012"

.Example
# Remove a site at service group scope
Remove-AzSite -Name "MySite" -ServicegroupName "MyServiceGroup"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISiteIdentity
.Outputs
System.Boolean
.Link
https://learn.microsoft.com/powershell/module/az.site/remove-azsite
#>
function Remove-AzSite {
    [OutputType([System.Boolean])]
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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Site.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Returns true when the command succeeds
        ${PassThru},

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
                if ($PSCmdlet.ShouldProcess("Site '$($InputObject.Name)' in Resource Group '$($InputObject.ResourceGroupName)'", "Remove")) {
                    Az.Site.internal\Remove-AzSite @PSBoundParameters
                }
            }
            elseif ($InputObject.ServicegroupName) {
                # Service Group scope - clean parameters
                $null = $PSBoundParameters.Remove('SubscriptionId')
                $null = $PSBoundParameters.Remove('ResourceGroupName')
                if ($PSCmdlet.ShouldProcess("Site '$($InputObject.Name)' in Service Group '$($InputObject.ServicegroupName)'", "Remove")) {
                    Az.Site.internal\Remove-AzSiteSitesByServiceGroup @PSBoundParameters
                }
            }
            elseif ($InputObject.SubscriptionId) {
                # Subscription scope - clean parameters
                $null = $PSBoundParameters.Remove('ResourceGroupName')
                $null = $PSBoundParameters.Remove('ServicegroupName')
                if ($PSCmdlet.ShouldProcess("Site '$($InputObject.Name)' in Subscription '$($InputObject.SubscriptionId)'", "Remove")) {
                    Az.Site.internal\Remove-AzSiteSitesBySubscription @PSBoundParameters
                }
            }
            return
        }

        # Determine scope based on provided parameters
        if ($PSBoundParameters.ContainsKey('SubscriptionId') -and 
            $PSBoundParameters.ContainsKey('ResourceGroupName')) {
            # Resource Group Scope - call base generated cmdlet
            if ($PSCmdlet.ShouldProcess("Site '$Name' in Resource Group '$ResourceGroupName'", "Remove")) {
                Az.Site.internal\Remove-AzSite @PSBoundParameters
            }
        }
        elseif ($PSBoundParameters.ContainsKey('ServicegroupName')) {
            # Service Group Scope - prepare parameters for service group-scoped cmdlet
            $null = $PSBoundParameters.Remove('SubscriptionId')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            if ($PSCmdlet.ShouldProcess("Site '$Name' in Service Group '$ServicegroupName'", "Remove")) {
                Az.Site.internal\Remove-AzSiteSitesByServiceGroup @PSBoundParameters
            }
        }
        elseif ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            # Subscription Scope - prepare parameters for subscription-scoped cmdlet
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('ServicegroupName')
            if ($PSCmdlet.ShouldProcess("Site '$Name' in Subscription '$SubscriptionId'", "Remove")) {
                Az.Site.internal\Remove-AzSiteSitesBySubscription @PSBoundParameters
            }
        }
        else {
            throw "Must provide either (SubscriptionId + ResourceGroupName), SubscriptionId only, or ServicegroupName only"
        }
    }
}