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


function Test-ManagedHsmNetworkRuleLifecycle {
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "East US"
    $hsmName = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "East US"
    $adminUserAAD = (Get-AzADUser -SignedIn).Id

    # We'll create a simple virtual network + subnet so we can add a VNet rule later
    $vnetName = getAssetName
    $vnetLocation = Get-Location "Microsoft.Network" "virtualNetworks" "East US"

    New-AzResourceGroup -Name $rgName -Location $rgLocation | Out-Null

    try {
        # Create initial network rule set object with a single IP range and default Allow/AzureServices
        $initialIp = "110.0.1.0/24"
        $nr = New-AzKeyVaultManagedHsmNetworkRuleSetObject -IpAddressRange $initialIp -Bypass AzureServices -DefaultAction Allow

        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $adminUserAAD -SoftDeleteRetentionInDays 7 -NetworkRuleSet $nr
        Assert-NotNull $hsm
        Assert-NotNull $hsm.OriginalManagedHsm
        Assert-NotNull $hsm.OriginalManagedHsm.Properties.NetworkAcls

        $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
        Assert-AreEqual "Allow" $acls.DefaultAction
        Assert-AreEqual "AzureServices" $acls.Bypass
        Assert-NotNull $acls.IPRules
        Assert-AreEqual 1 $acls.IPRules.Count
        Assert-AreEqual $initialIp $acls.IPRules[0].Value

        # Prepare a VNet with service endpoint for Microsoft.KeyVault so it can be added as a rule
        $subnet = New-AzVirtualNetworkSubnetConfig -Name subnet1 -AddressPrefix "110.0.2.0/24" -ServiceEndpoint Microsoft.KeyVault
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName -Location $vnetLocation -AddressPrefix "110.0.0.0/16" -Subnet $subnet
        $subnetId = (Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName).Subnets[0].Id

        # Add a new IP and a VNet rule
        $addedIp = "110.0.3.0/24"
        Add-AzKeyVaultManagedHsmNetworkRule -Name $hsmName -ResourceGroupName $rgName -IpAddressRange $addedIp -VirtualNetworkResourceId $subnetId -PassThru | Out-Null
        $hsm = Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName
        $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
        Assert-AreEqual 2 $acls.IPRules.Count
        Assert-True { $acls.IPRules.Value -contains $initialIp }
        Assert-True { $acls.IPRules.Value -contains $addedIp }
        Assert-AreEqual 1 $acls.VirtualNetworkRules.Count
        Assert-AreEqual $subnetId $acls.VirtualNetworkRules[0].Id

        # Update (authoritative) to change default action to Deny and keep same sets (explicitly re-supplying IP ranges)
        Update-AzKeyVaultManagedHsmNetworkRuleSet -Name $hsmName -ResourceGroupName $rgName -DefaultAction Deny -IpAddressRange @($initialIp, $addedIp) -VirtualNetworkResourceId $subnetId -PassThru | Out-Null
        $hsm = Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName
        $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
        Assert-AreEqual "Deny" $acls.DefaultAction
        Assert-AreEqual 2 $acls.IPRules.Count

        # Remove one IP and the VNet rule
        Remove-AzKeyVaultManagedHsmNetworkRule -Name $hsmName -ResourceGroupName $rgName -IpAddressRange $addedIp -VirtualNetworkResourceId $subnetId -PassThru | Out-Null
        $hsm = Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName
        $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
        Assert-AreEqual 1 $acls.IPRules.Count
        Assert-AreEqual $initialIp $acls.IPRules[0].Value
        Assert-Null $acls.VirtualNetworkRules

        # Final clean remove (soft delete) to ensure no lingering resources break subsequent tests
        Remove-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Force
    }
    finally {
        Remove-AzResourceGroup -Name $rgName -Force -ErrorAction SilentlyContinue
        # Attempt to purge if soft-deleted (ignore failures)
        $hsmLocation = $hsmLocation
        try { Remove-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState -Force -ErrorAction SilentlyContinue } catch {}
    }
}
