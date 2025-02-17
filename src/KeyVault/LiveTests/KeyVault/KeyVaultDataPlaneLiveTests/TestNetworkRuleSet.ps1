Invoke-LiveTestScenario -Name "Create key vault and specifies network rules" -Description "Create key vault and specifies network rules to allow access to the specified IP address" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $vaultName = New-LiveTestResourceName
    $vnName = New-LiveTestResourceName
    $vaultLocation = "eastus"
    $vnLocation = "westus"
    $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "110.0.1.0/24" -ServiceEndpoint Microsoft.KeyVault
    $virtualNetwork = New-AzVirtualNetwork -Name $vnName -ResourceGroupName $rg.ResourceGroupName -Location $vnLocation -AddressPrefix "110.0.0.0/16" -Subnet $frontendSubnet
    $myNetworkResId = $virtualNetwork.Subnets[0].Id
    $ruleSet = New-AzKeyVaultNetworkRuleSetObject -DefaultAction Allow -Bypass AzureServices -IpAddressRange "110.0.1.0/24" -VirtualNetworkResourceId $myNetworkResId
    $keyvault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $vaultLocation -NetworkRuleSet $ruleSet -DisableRbacAuthorization
    Assert-AreEqual $keyvault.NetworkAcls.DefaultAction Allow
    Assert-AreEqual $keyvault.NetworkAcls.Bypass AzureServices
    # Assert-AreEqual $keyvault.NetworkAcls.VirtualNetworkResourceIds $myNetworkResId

}