function Test-PrivateEndpoint {
    $rg = Get-ResourceGroupName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $vaultLocation = Get-Location "Microsoft.KeyVault" "vault" "West US"
    $vnetLocation = Get-Location "Microsoft.Network" "virtualNetworks" "West US"
    $peLocation = Get-Location "Microsoft.Network" "privateEndpoints" "West US"
    New-AzResourceGroup -Name $rg -Location $rgLocation

    try {
        $vault = New-AzKeyVault -ResourceGroupName $rg -VaultName (GetAssetName) -Location $vaultLocation

        # get private link resource
        $privateLinkResource = Get-AzPrivateLinkResource -PrivateLinkResourceId $vault.ResourceId
        Assert-NotNull $privateLinkResource
        Assert-AreEqual "vault" $privateLinkResource.GroupId

        # create private endpoint connection
        $subnetConfig = New-AzVirtualNetworkSubnetConfig -Name (GetAssetName) -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPolicies "Disabled"
        $vnet = New-AzVirtualNetwork -ResourceGroupName $rg -Name (GetAssetName) -Location $vnetLocation -AddressPrefix "11.0.0.0/16" -Subnet $subnetConfig
        $privateLinkServiceConnection = New-AzPrivateLinkServiceConnection -Name (GetAssetName) -PrivateLinkServiceId $vault.ResourceId -GroupId $privateLinkResource.GroupId
        New-AzPrivateEndpoint -ResourceGroupName $rg -Name (GetAssetName) -Location $peLocation -Subnet $vnet.subnets[0] -PrivateLinkServiceConnection $privateLinkServiceConnection -ByManualRequest
        $privateEndpointConnection = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $vault.ResourceId
        Assert-NotNull $privateEndpointConnection
        Assert-AreEqual "Pending" $privateEndpointConnection.PrivateLinkServiceConnectionState.Status

        # approve connection
        $connectionApprove = Approve-AzPrivateEndpointConnection -ResourceId $privateEndpointConnection.Id
        Assert-NotNull $connectionApprove
        Assert-AreEqual "Approved" $connectionApprove.PrivateLinkServiceConnectionState.Status

        # Wait for connection provisioning successed, 20000 is not enough
        # Start-TestSleep -Seconds 20

        # Comments as we need too much to wait
        # remove connection
        # $connectionRemove = Remove-AzPrivateEndpointConnection -ResourceId $privateEndpointConnection.Id -PassThru -Force
        # Assert-True { $connectionRemove }
        # Start-TestSleep -Seconds 15
        # Assert-Null (Get-AzPrivateEndpointConnection -PrivateLinkResourceId $vault.ResourceId)


    }
    finally {
        Remove-AzResourceGroup -Name $rg -Force
    }
}
