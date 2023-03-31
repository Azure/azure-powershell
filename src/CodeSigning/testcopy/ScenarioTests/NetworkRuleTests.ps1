function Test-CreateVaultWithNetworkRule {
    $resourceGroupName = getAssetName
    $resourceGroupLocation = Get-Location "Microsoft.Resources" "resourceGroups" "westus"
    $vaultName = getAssetName
    $vaultLocation = Get-Location "Microsoft.KeyVault" "vaults" "westus"
    $virtualNetworkName = getAssetName
    $virtualNetworkLocation = Get-Location "Microsoft.Network" "virtualNetworks" "westus"

    try {
        $rg = New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation

        # Bypass / AzureServices
        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "110.0.1.0/24" -ServiceEndpoint Microsoft.KeyVault
        $virtualNetwork = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $resourceGroupName -Location $virtualNetworkLocation -AddressPrefix "110.0.0.0/16" -Subnet $frontendSubnet
        $myNetworkResId = (Get-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $resourceGroupName).Subnets[0].Id

        $networkRuleSet = New-AzKeyVaultNetworkRuleSetObject -IpAddressRange "110.0.1.0/24" -VirtualNetworkResourceId $myNetworkResId -Bypass AzureServices -DefaultAction Allow
        $vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroupName -Location $vaultLocation -NetworkRuleSet $networkRuleSet

        Assert-AreEqual $vault.NetworkAcls.IpAddressRanges.Count 1
        Assert-AreEqual $vault.NetworkAcls.IpAddressRanges[0] "110.0.1.0/24"
        Assert-AreEqual $vault.NetworkAcls.VirtualNetworkResourceIds.Count 1
        Assert-AreEqual $vault.NetworkAcls.VirtualNetworkResourceIds[0] $myNetworkResId
        Assert-AreEqual $vault.NetworkAcls.Bypass.toString() "AzureServices"
        Assert-AreEqual $vault.NetworkAcls.DefaultAction.toString() "Allow"

        # None / Deny
        $networkRuleSet = New-AzKeyVaultNetworkRuleSetObject -Bypass None -DefaultAction Deny
        $vault = New-AzKeyVault -VaultName (getAssetName) -ResourceGroupName $resourceGroupName -Location $vaultLocation -NetworkRuleSet $networkRuleSet
        Assert-AreEqual $vault.NetworkAcls.Bypass.toString() "None"
        Assert-AreEqual $vault.NetworkAcls.DefaultAction.toString() "Deny"
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-UpdateVaultWithNetworkRule {
    $resourceGroupName = getAssetName
    $resourceGroupLocation = Get-Location "Microsoft.Resources" "resourceGroups" "westus"
    $vaultName = getAssetName
    $vaultLocation = Get-Location "Microsoft.KeyVault" "vaults" "westus"
    $virtualNetworkName = getAssetName
    $virtualNetworkLocation = Get-Location "Microsoft.Network" "virtualNetworks" "westus"

    try {
        $rg = New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation
        $vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroupName -Location $vaultLocation

        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "110.0.1.0/24" -ServiceEndpoint Microsoft.KeyVault
        $virtualNetwork = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $resourceGroupName -Location $virtualNetworkLocation -AddressPrefix "110.0.0.0/16" -Subnet $frontendSubnet

        $myNetworkResId = (Get-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $resourceGroupName).Subnets[0].Id
        Add-AzKeyVaultNetworkRule -VaultName $vaultName -IpAddressRange "110.0.1.0/24" -VirtualNetworkResourceId $myNetworkResId
        $vault = Get-AzKeyVault -ResourceGroupName $resourceGroupName -Name $vaultName
        Assert-AreEqual $vault.NetworkAcls.IpAddressRanges.Count 1
        Assert-AreEqual $vault.NetworkAcls.IpAddressRanges[0] "110.0.1.0/24"
        Assert-AreEqual $vault.NetworkAcls.VirtualNetworkResourceIds.Count 1
        Assert-AreEqual $vault.NetworkAcls.VirtualNetworkResourceIds[0] $myNetworkResId
        Assert-AreEqual $vault.NetworkAcls.Bypass.toString() "AzureServices"
        Assert-AreEqual $vault.NetworkAcls.DefaultAction.toString() "Allow"

        $networkRule = Update-AzKeyVaultNetworkRuleSet -VaultName $vaultName -ResourceGroupName $resourceGroupName -Bypass None -DefaultAction Deny -PassThru
        Assert-AreEqual $networkRule.NetworkAcls.Bypass.toString() "None"
        Assert-AreEqual $networkRule.NetworkAcls.DefaultAction.toString() "Deny"
        $vault = Get-AzKeyVault -ResourceGroupName $resourceGroupName -Name $vaultName
        Assert-AreEqual $vault.NetworkAcls.Bypass.toString() "None"
        Assert-AreEqual $vault.NetworkAcls.DefaultAction.toString() "Deny"

        Remove-AzKeyVaultNetworkRule -VaultName $vaultName -ResourceGroupName $resourceGroupName -IpAddressRange "110.0.1.0/24" -VirtualNetworkResourceId $myNetworkResId
        $vault = Get-AzKeyVault -ResourceGroupName $resourceGroupName -Name $vaultName
        Assert-AreEqual $vault.NetworkAcls.IpAddressRanges.Count 0
        Assert-AreEqual $vault.NetworkAcls.VirtualNetworkResourceIds.Count 0
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}