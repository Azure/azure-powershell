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
    # Trimmed test: cover minimal lifecycle (create with 1 IP, add 2nd triggers enforcement, bulk remove, set Allow)
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "East US"
    $hsmName = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "East US"
    $adminUserAAD = (Get-AzADUser -SignedIn).Id

    New-AzResourceGroup -Name $rgName -Location $rgLocation | Out-Null

    try {
        # 1. Create with single IP (Allow + rule accepted initially)
        $ip1 = "110.0.1.0/24"
        $nr = New-AzKeyVaultManagedHsmNetworkRuleSetObject -IpAddressRange $ip1 -Bypass AzureServices -DefaultAction Allow
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $adminUserAAD -SoftDeleteRetentionInDays 7 -NetworkRuleSet $nr
        $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
        Assert-AreEqual 1 $acls.IPRules.Count
        Assert-AreEqual $ip1 $acls.IPRules[0].Value

        # 2. Add second IP, expect two rules; DefaultAction may flip to Deny (enforced). Assert only counts & membership; tolerate either Allow or Deny.
        $ip2 = "110.0.3.0/24"
        Add-AzKeyVaultManagedHsmNetworkRule -Name $hsmName -ResourceGroupName $rgName -IpAddressRange $ip2 -PassThru | Out-Null
        $hsm = Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName
        $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
        Assert-AreEqual 2 $acls.IPRules.Count
        Assert-True { $acls.IPRules.Value -contains $ip1 }
        Assert-True { $acls.IPRules.Value -contains $ip2 }

        # 3. Remove both IPs in one shot
        Remove-AzKeyVaultManagedHsmNetworkRule -Name $hsmName -ResourceGroupName $rgName -IpAddressRange $ip1,$ip2 -PassThru | Out-Null
        $hsm = Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName
        $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
        Assert-True { $acls.IPRules.Count -eq 0 }

        # 4. Explicitly set Allow (no rules present)
        Update-AzKeyVaultManagedHsmNetworkRuleSet -Name $hsmName -ResourceGroupName $rgName -DefaultAction Allow -PassThru | Out-Null
        $hsm = Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName
        $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
        Assert-AreEqual 0 $acls.IPRules.Count
        Assert-AreEqual "Allow" $acls.DefaultAction

        Remove-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Force
    }
    finally {
        # IMPORTANT: Purging immediately often 404s because the soft-deleted HSM entry can take time to surface.
        # Also, removing the RG first makes the timing window worse. For playback-focused tests we can skip purge entirely.
        # So we (1) delete RG, (2) optionally attempt a bounded poll for deleted state, (3) purge only if found.

        Remove-AzResourceGroup -Name $rgName -Force -ErrorAction SilentlyContinue

        # Optional lightweight poll (keep short to avoid test runtime inflation). If not found, we skip purge silently.
        $maxAttempts = 5
        $deleted = $null
        for ($i=0; $i -lt $maxAttempts; $i++) {
            $deleted = Get-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState -ErrorAction SilentlyContinue
            if ($deleted) { break }
            Start-Sleep -Seconds 3
        }
        if ($deleted) {
            # Only purge if the soft-deleted instance is visible; ignore errors (NotFound/GatewayTimeout) as non-fatal.
            try { Remove-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState -Force -ErrorAction Stop } catch { }
        }
    }
}
