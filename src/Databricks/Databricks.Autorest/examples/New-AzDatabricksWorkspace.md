### Example 1: Create a Databricks workspace.
```powershell
New-AzDatabricksWorkspace -Name azps-databricks-workspace-t1 -ResourceGroupName azps_test_gp_db -Location eastus -ManagedResourceGroupName azps_test_gp_kv_t1 -Sku Premium
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t1 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t1
```

This command creates a Databricks workspace.

### Example 2: Create a Databricks workspace with a customized virtual network.
```powershell
$dlg = New-AzDelegation -Name dbrdl -ServiceName "Microsoft.Databricks/workspaces"
$rdpRule = New-AzNetworkSecurityRuleConfig -Name azps-network-security-rule -Description "Allow RDP" -Access Allow -Protocol Tcp -Direction Inbound -Priority 100 -SourceAddressPrefix Internet -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 3389
$networkSecurityGroup = New-AzNetworkSecurityGroup -ResourceGroupName azps_test_gp_db -Location eastus -Name azps-network-security-group -SecurityRules $rdpRule
$kvSubnet = New-AzVirtualNetworkSubnetConfig -Name azps-vnetwork-sub-kv -AddressPrefix "110.0.1.0/24" -ServiceEndpoint "Microsoft.KeyVault"
$priSubnet = New-AzVirtualNetworkSubnetConfig -Name azps-vnetwork-sub-pri -AddressPrefix "110.0.2.0/24" -NetworkSecurityGroup $networkSecurityGroup -Delegation $dlg
$pubSubnet = New-AzVirtualNetworkSubnetConfig -Name azps-vnetwork-sub-pub -AddressPrefix "110.0.3.0/24" -NetworkSecurityGroup $networkSecurityGroup -Delegation $dlg
$testVN = New-AzVirtualNetwork -Name azps-virtual-network -ResourceGroupName azps_test_gp_db -Location eastus -AddressPrefix "110.0.0.0/16" -Subnet $kvSubnet,$priSubnet,$pubSubnet
$vNetResId = (Get-AzVirtualNetwork -Name azps-virtual-network -ResourceGroupName azps_test_gp_db).Subnets[0].Id
$ruleSet = New-AzKeyVaultNetworkRuleSetObject -DefaultAction Allow -Bypass AzureServices -IpAddressRange "110.0.1.0/24" -VirtualNetworkResourceId $vNetResId
New-AzKeyVault -ResourceGroupName azps_test_gp_db -VaultName azps-keyvault -NetworkRuleSet $ruleSet -Location eastus -Sku 'Premium' -EnablePurgeProtection
New-AzDatabricksWorkspace -Name azps-databricks-workspace-t2 -ResourceGroupName azps_test_gp_db -Location eastus -ManagedResourceGroupName azps_test_gp_kv_t2 -VirtualNetworkId $testVN.Id -PrivateSubnetName $priSubnet.Name -PublicSubnetName $pubSubnet.Name -Sku Premium
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t2 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t2
```

This command creates a Databricks workspace with customized virtual network in a resource group.

### Example 3: Create a Databricks workspace with enable encryption.
```powershell
New-AzDatabricksWorkspace -Name azps-databricks-workspace-t3 -ResourceGroupName azps_test_gp_db -Location eastus -PrepareEncryption -ManagedResourceGroupName azps_test_gp_kv_t3 -Sku premium
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t3 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t3
```

This command creates a Databricks workspace and sets it to prepare for encryption.
Please refer to the examples of Update-AzDatabricksWorkspace for more settings to encryption.