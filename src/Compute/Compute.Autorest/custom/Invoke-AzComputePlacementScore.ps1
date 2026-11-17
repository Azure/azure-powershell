function Invoke-AzComputePlacementScore {
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
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.
        ${DefaultProfile},

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
            Path = "/subscriptions/$SubscriptionId/providers/Microsoft.Compute/locations/$Location/placementScores/regular/generate?api-version=2026-10-05-preview"
            Payload = ConvertTo-Json -InputObject $body -Depth 100 -Compress
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
