function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    $workSpaceName1 = RandomString -allChars $false -len 6
    $workSpaceName2 = RandomString -allChars $false -len 6
    $workSpaceName3 = RandomString -allChars $false -len 6
    $vNetName1 = RandomString -allChars $false -len 6
    $accessConnectorName1 = RandomString -allChars $false -len 6

    $env.Add("workSpaceName1", $workSpaceName1)
    $env.Add("workSpaceName2", $workSpaceName2)
    $env.Add("workSpaceName3", $workSpaceName3)
    $env.Add("vNetName1", $vNetName1)
    $env.Add("accessConnectorName1", $accessConnectorName1)

    $networkSecurityRuleName = RandomString -allChars $false -len 6
    $networkSecurityGroupName = RandomString -allChars $false -len 6
    $vNetSubnetName1 = RandomString -allChars $false -len 6
    $vNetSubnetName2 = RandomString -allChars $false -len 6
    $vNetSubnetName3 = RandomString -allChars $false -len 6
    $vNetName = RandomString -allChars $false -len 6
    $keyVaultName = "azps" + (RandomString -allChars $false -len 6)

    $env.Add("networkSecurityRuleName", $networkSecurityRuleName)
    $env.Add("networkSecurityGroupName", $networkSecurityGroupName)
    $env.Add("vNetSubnetName1", $vNetSubnetName1)
    $env.Add("vNetSubnetName2", $vNetSubnetName2)
    $env.Add("vNetSubnetName3", $vNetSubnetName3)
    $env.Add("vNetName", $vNetName)
    $env.Add("keyVaultName", $keyVaultName)

    write-host "start to create test group"
    $env.Add("location", "eastus")
    $resourceGroup = "auto-test-databricks-" + (RandomString -allChars $false -len 2)
    $env.Add("resourceGroup", $resourceGroup)
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    $dlg = New-AzDelegation -Name dbrdl -ServiceName "Microsoft.Databricks/workspaces"

    write-host "start to create NetworkSecurity env"
    $rdpRule = New-AzNetworkSecurityRuleConfig -Name $env.networkSecurityRuleName -Description "Allow RDP" -Access Allow -Protocol Tcp -Direction Inbound -Priority 100 -SourceAddressPrefix Internet -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 3389
    $networkSecurityGroup = New-AzNetworkSecurityGroup -ResourceGroupName $env.resourceGroup -Location $env.location -Name $env.networkSecurityGroupName -SecurityRules $rdpRule
    $kvSubnet = New-AzVirtualNetworkSubnetConfig -Name $env.vNetSubnetName1 -AddressPrefix "110.0.1.0/24" -ServiceEndpoint "Microsoft.KeyVault"
    $priSubnet = New-AzVirtualNetworkSubnetConfig -Name $env.vNetSubnetName2 -AddressPrefix "110.0.2.0/24" -NetworkSecurityGroup $networkSecurityGroup -Delegation $dlg
    $pubSubnet = New-AzVirtualNetworkSubnetConfig -Name $env.vNetSubnetName3 -AddressPrefix "110.0.3.0/24" -NetworkSecurityGroup $networkSecurityGroup -Delegation $dlg

    write-host "start to create VirtualNetwork env"
    $testVN = New-AzVirtualNetwork -Name $env.vNetName -ResourceGroupName $env.resourceGroup -Location $env.location -AddressPrefix "110.0.0.0/16" -Subnet $kvSubnet,$priSubnet,$pubSubnet
    $vNetResId = (Get-AzVirtualNetwork -Name $env.vNetName -ResourceGroupName $env.resourceGroup).Subnets[0].Id
    $ruleSet = New-AzKeyVaultNetworkRuleSetObject -DefaultAction Allow -Bypass AzureServices -IpAddressRange "110.0.1.0/24" -VirtualNetworkResourceId $vNetResId
    
    write-host "start to create KeyVault env"
    New-AzKeyVault -ResourceGroupName $env.resourceGroup -VaultName $env.keyVaultName -NetworkRuleSet $ruleSet -Location $env.location -Sku 'Premium' -EnablePurgeProtection
    
    write-host "start to create Databricks(have vNet) env"
    New-AzDatabricksWorkspace -Name $env.workSpaceName1 -ResourceGroupName $env.resourceGroup -Location $env.location -VirtualNetworkId $testVN.Id -PrivateSubnetName $priSubnet.Name -PublicSubnetName $pubSubnet.Name -Sku Premium

    write-host "start to create Databricks env"
    New-AzDatabricksWorkspace -Name $env.workSpaceName3 -ResourceGroupName $env.resourceGroup -Location $env.location -Sku premium

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.resourceGroup
}