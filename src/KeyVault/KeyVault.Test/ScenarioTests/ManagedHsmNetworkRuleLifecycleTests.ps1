# Shared state object to track HSM name, RG, IPs across test phases.
# Each phase is a separate test, so no in-memory state is preserved.
if (-not $Global:MhsmLifecycle) { $Global:MhsmLifecycle = @{} }


function Test-ManagedHsmNetworkRuleLifecycle-New {
    if ($Global:MhsmLifecycle.HsmName) {
        Write-Host "[New] HSM already exists ($($Global:MhsmLifecycle.HsmName))" -ForegroundColor Yellow
        return
    }
    $rgName  = getAssetName
    $rgLoc   = Get-Location "Microsoft.Resources" "resourceGroups" "East US"
    $hsmName = getAssetName
    $hsmLoc  = Get-Location "Microsoft.KeyVault" "managedHSMs" "East US"
    $adminId = (Get-AzADUser -SignedIn).Id
    
    New-AzResourceGroup -Name $rgName -Location $rgLoc | Out-Null
    $ip1 = "110.0.1.0/24"
    $nr  = New-AzKeyVaultManagedHsmNetworkRuleSetObject -DefaultAction Deny -IpAddressRange $ip1 -Bypass AzureServices
    $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLoc -Administrator $adminId -SoftDeleteRetentionInDays 7 -NetworkRuleSet $nr
    $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
    Assert-AreEqual 1 $acls.IPRules.Count
    Assert-AreEqual $ip1 $acls.IPRules[0].Value
    Assert-AreEqual "Deny" $acls.DefaultAction

    $Global:MhsmLifecycle = @{ ResourceGroupName = $rgName; HsmName = $hsmName; Location = $hsmLoc; AdminId = $adminId; Ip1 = $ip1; Ip2 = $null }
    Write-Host "[New] Created HSM $hsmName in RG $rgName" -ForegroundColor Cyan
}


function Test-ManagedHsmNetworkRuleLifecycle-Add {
    if (-not $Global:MhsmLifecycle.HsmName) { throw "Run New first (no global context found)." }
    if ($Global:MhsmLifecycle.Ip2) { Write-Host "[Add] Ip2 already added ($($Global:MhsmLifecycle.Ip2))." -ForegroundColor Yellow; return }
    $ip2 = "110.0.3.0/24"
    Add-AzKeyVaultManagedHsmNetworkRule -Name $Global:MhsmLifecycle.HsmName -ResourceGroupName $Global:MhsmLifecycle.ResourceGroupName -IpAddressRange $ip2 | Out-Null
    $hsm  = Get-AzKeyVaultManagedHsm -Name $Global:MhsmLifecycle.HsmName -ResourceGroupName $Global:MhsmLifecycle.ResourceGroupName
    $acls = $hsm.OriginalManagedHsm.Properties.NetworkAcls
    Assert-True { $acls.IPRules.Value -contains $Global:MhsmLifecycle.Ip1 }
    Assert-True { $acls.IPRules.Value -contains $ip2 }
    Assert-AreEqual "Deny" $acls.DefaultAction
    $Global:MhsmLifecycle.Ip2 = $ip2
    Write-Host "[Add] Added IP2 $ip2" -ForegroundColor Cyan
}


function Test-ManagedHsmNetworkRuleLifecycle-Remove {
    if (-not $Global:MhsmLifecycle.HsmName) { throw "Run New first (no global context found)." }
    if (-not $Global:MhsmLifecycle.Ip2) { throw "Run Add first so two IPs exist before Remove." }
    Remove-AzKeyVaultManagedHsmNetworkRule -Name $Global:MhsmLifecycle.HsmName -ResourceGroupName $Global:MhsmLifecycle.ResourceGroupName -IpAddressRange $Global:MhsmLifecycle.Ip1,$Global:MhsmLifecycle.Ip2 | Out-Null
    $acls = (Get-AzKeyVaultManagedHsm -Name $Global:MhsmLifecycle.HsmName -ResourceGroupName $Global:MhsmLifecycle.ResourceGroupName).OriginalManagedHsm.Properties.NetworkAcls
    Assert-AreEqual 0 $acls.IPRules.Count
    Assert-AreEqual "Deny" $acls.DefaultAction
    Write-Host "[Remove] Both IP rules removed." -ForegroundColor Cyan
}


function Test-ManagedHsmNetworkRuleLifecycle-Update {
    if (-not $Global:MhsmLifecycle.HsmName) { throw "Run New first (no state file or global context)." }
    $acls = (Get-AzKeyVaultManagedHsm -Name $Global:MhsmLifecycle.HsmName -ResourceGroupName $Global:MhsmLifecycle.ResourceGroupName).OriginalManagedHsm.Properties.NetworkAcls
    if ($acls.IPRules.Count -gt 0) { throw "Expected 0 IP rules before Update (run Remove)." }
    Update-AzKeyVaultManagedHsmNetworkRuleSet -Name $Global:MhsmLifecycle.HsmName -ResourceGroupName $Global:MhsmLifecycle.ResourceGroupName -DefaultAction Allow | Out-Null
    $acls = (Get-AzKeyVaultManagedHsm -Name $Global:MhsmLifecycle.HsmName -ResourceGroupName $Global:MhsmLifecycle.ResourceGroupName).OriginalManagedHsm.Properties.NetworkAcls
    Assert-AreEqual 0 $acls.IPRules.Count
    Assert-AreEqual "Allow" $acls.DefaultAction
    Write-Host "[Update] DefaultAction switched to Allow." -ForegroundColor Cyan
}

