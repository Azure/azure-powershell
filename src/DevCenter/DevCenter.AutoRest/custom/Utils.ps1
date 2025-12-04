function TestPoolHasValue {
    param($Value)
    return $null -ne $Value -and (
        ($Value -is [string] -and $Value.Trim() -ne "") -or
        ($Value -isnot [string] -and $Value.Count -gt 0)
    )
}

function ValidatePoolCreate {
    param(
        $VirtualNetworkType,
        $NetworkConnectionName,
        $ManagedVirtualNetworkRegion,
        $DevBoxDefinitionImageReference,
        $DevBoxDefinitionSku,
        $DevBoxDefinitionType,
        $DevBoxDefinitionName
    )

    if (
        -not (TestPoolHasValue $ManagedVirtualNetworkRegion) -and
        $VirtualNetworkType -eq "Managed"
    ) {
        $errorString = 'When VirtualNetworkType is set to "Managed", ManagedVirtualNetworkRegion should be set.'
        Write-Error $errorString -ErrorAction Stop
    }
    if (
        -not (TestPoolHasValue $NetworkConnectionName) -and
        ($VirtualNetworkType -eq "Unmanaged" -or -not (TestPoolHasValue $VirtualNetworkType))
    ) {
        $errorString = 'When VirtualNetworkType is not used or set to "Unmanaged", NetworkConnectionName should be set.'
        Write-Error $errorString -ErrorAction Stop
    }
    if (
        (TestPoolHasValue $ManagedVirtualNetworkRegion) -and
        ($VirtualNetworkType -eq "Unmanaged" -or -not (TestPoolHasValue $VirtualNetworkType))
    ) {
        $errorString = 'When VirtualNetworkType is not used or set to "Unmanaged", ManagedVirtualNetworkRegion should not be set.'
        Write-Error $errorString -ErrorAction Stop
    }
    if (
        (TestPoolHasValue $DevBoxDefinitionType) -and $DevBoxDefinitionType -eq "Value" -and
        (-not (TestPoolHasValue $DevBoxDefinitionImageReference) -or -not (TestPoolHasValue $DevBoxDefinitionSku))
    ) {
        $errorString = 'When DevBoxDefinitionType is set to "Value", DevBoxDefinitionSku and DevBoxDefinitionImageReference should be set.'
        Write-Error $errorString -ErrorAction Stop
    }
    if (
        (-not (TestPoolHasValue $DevBoxDefinitionType) -or $DevBoxDefinitionType -eq "Reference") -and
        -not (TestPoolHasValue $DevBoxDefinitionName)
    ) {
        $errorString = 'When DevBoxDefinitionType is set to "Reference" or not provided, DevBoxDefinitionName should be set.'
        Write-Error $errorString -ErrorAction Stop
    }
}
