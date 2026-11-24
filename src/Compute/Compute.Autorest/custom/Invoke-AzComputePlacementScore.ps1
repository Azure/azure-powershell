function Invoke-AzComputePlacementScore {
    <#
    .Synopsis
    Generates placement scores for regular Compute VM SKUs.
    .Description
    Generates placement scores for regular Compute VM SKUs in the requested regions and availability zones.
    .Example
    $desiredSizes = @(@{ sku = 'Standard_D2_v3' }, @{ sku = 'Standard_D4_v3' })
    Invoke-AzComputePlacementScore -Location eastus -DesiredSize $desiredSizes -DesiredLocation @('eastus2', 'westus')
    .Example
    $desiredSizes = @(@{ sku = 'Standard_D2_v3' })
    Invoke-AzComputePlacementScore -Location eastus -DesiredSize $desiredSizes -DesiredCount 2 -AvailabilityZone
    #>
    [OutputType([PSObject])]
    [CmdletBinding(PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Path')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        # The name of the Azure region.
        ${Location},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        ${SubscriptionId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach.
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.SendAsyncStep[]]
        # SendAsync pipeline steps to append.
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.SendAsyncStep[]]
        # SendAsync pipeline steps to prepend.
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Runtime')]
        [System.Uri]
        # URI of the proxy server.
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for the proxy server.
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy.
        ${ProxyUseDefaultCredentials},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Defines if the scope is zonal or regional.
        ${AvailabilityZone},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Body')]
        [System.Int32]
        # Desired instance count per region or zone based on the scope.
        ${DesiredCount},

        [Parameter()]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Body')]
        [System.String[]]
        # The desired regions.
        ${DesiredLocation},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IResourceSize[]]
        # The desired virtual machine SKU sizes.
        ${DesiredSize}
    )

    process {
        if ($Break) {
            [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.AttachDebugger]::Break()
        }

        if (-not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $SubscriptionId = (Get-AzContext).Subscription.Id
        }

        $escapedSubscriptionId = [System.Uri]::EscapeDataString($SubscriptionId)
        $escapedLocation = [System.Uri]::EscapeDataString($Location)
        $body = @{
            desiredSizes = @($DesiredSize | ForEach-Object { @{ sku = $_.Sku } })
        }

        if ($PSBoundParameters.ContainsKey('AvailabilityZone')) {
            $body.availabilityZones = [bool]$AvailabilityZone
        }
        if ($PSBoundParameters.ContainsKey('DesiredCount')) {
            $body.desiredCount = $DesiredCount
        }
        if ($PSBoundParameters.ContainsKey('DesiredLocation')) {
            $body.desiredLocations = $DesiredLocation
        }

        $requestParameters = @{
            Method = 'POST'
            Path = "/subscriptions/$escapedSubscriptionId/providers/Microsoft.Compute/locations/$escapedLocation/placementScores/regular/generate?api-version=2026-10-05-preview"
            Payload = ConvertTo-Json -InputObject $body -Depth 100 -Compress
            ErrorAction = 'Stop'
        }
        if ($PSBoundParameters.ContainsKey('DefaultProfile')) {
            $requestParameters.DefaultProfile = $DefaultProfile
        }

        if ($PSCmdlet.ShouldProcess($Location, 'Generate compute placement scores')) {
            $response = Invoke-AzRestMethod @requestParameters
            if ($null -ne $response.Content) {
                return $response.Content | ConvertFrom-Json
            }
            return $response
        }
    }
}
