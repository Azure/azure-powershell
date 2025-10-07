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
    # Updated lifecycle matching explicit validation rules (no Allow + IP rules at creation or modification)
    # Steps:
    # 1. Create with one IP rule and DefaultAction Deny
    # 2. Add second IP rule (still Deny)
    # 3. Remove both IPs
    # 4. Switch DefaultAction to Allow (now that no rules remain)
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "East US"
    $hsmName = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "East US"
    $adminUserAAD = (Get-AzADUser -SignedIn).Id

    New-AzResourceGroup -Name $rgName -Location $rgLocation | Out-Null

    try {
        # 1. Create with single IP and Deny
        $ip1 = "110.0.1.0/24"
        $nr = New-AzKeyVaultManagedHsmNetworkRuleSetObject -IpAddressRange $ip1 -Bypass AzureServices -DefaultAction Deny
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $adminUserAAD -SoftDeleteRetentionInDays 7 -NetworkRuleSet $nr
        $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
        Assert-AreEqual 1 $acls.IPRules.Count
        Assert-AreEqual $ip1 $acls.IPRules[0].Value
        Assert-AreEqual "Deny" $acls.DefaultAction

        # 2. Add second IP
        $ip2 = "110.0.3.0/24"
        Add-AzKeyVaultManagedHsmNetworkRule -Name $hsmName -ResourceGroupName $rgName -IpAddressRange $ip2 -PassThru | Out-Null
        $hsm = Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName
        $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
        Assert-AreEqual 2 $acls.IPRules.Count
        Assert-True { $acls.IPRules.Value -contains $ip1 }
        Assert-True { $acls.IPRules.Value -contains $ip2 }
        Assert-AreEqual "Deny" $acls.DefaultAction

        # 3. Remove both IPs
        Remove-AzKeyVaultManagedHsmNetworkRule -Name $hsmName -ResourceGroupName $rgName -IpAddressRange $ip1,$ip2 -PassThru | Out-Null
        $hsm = Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName
        $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
        Assert-True { $acls.IPRules.Count -eq 0 }

        # 4. Set Allow (legal now that there are no IP rules)
        Update-AzKeyVaultManagedHsmNetworkRuleSet -Name $hsmName -ResourceGroupName $rgName -DefaultAction Allow -PassThru | Out-Null
        $hsm = Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName
        $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
        Assert-AreEqual 0 $acls.IPRules.Count
        Assert-AreEqual "Allow" $acls.DefaultAction

        Remove-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Force
    }
    finally {
        # Simplified cleanup per new guidance: only remove the resource group.
        # We intentionally do NOT poll or purge the soft-deleted Managed HSM to avoid long-running operations / gateway timeouts.
        Remove-AzResourceGroup -Name $rgName -Force -ErrorAction SilentlyContinue
    }
}
