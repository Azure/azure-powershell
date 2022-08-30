### Example 1: Create a Databricks workspace
```powershell
PS C:\> New-AzDatabricksWorkspace -Name workspace3miaeb -ResourceGroupName databricks-rg-rqb2yo -Location eastus -ManagedResourceGroupName databricks-group -Sku standard

Name            ResourceGroupName    Location Managed Resource Group ID
----            -----------------    -------- -------------------------
workspace3miaeb databricks-rg-rqb2yo eastus   /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3miaeb-3c0s2mbgrqv9k
```

This command creates a Databricks workspace.

### Example 2: Create a Databricks workspace with a customized virtual network
```powershell
PS C:\> $dlg = New-AzDelegation -Name dbrdl -ServiceName "Microsoft.Databricks/workspaces"
PS C:\> $rdpRule = New-AzNetworkSecurityRuleConfig -Name rdp-rule -Description "Allow RDP" -Access Allow -Protocol Tcp -Direction Inbound -Priority 100 -SourceAddressPrefix Internet -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 3389
PS C:\> $networkSecurityGroup = New-AzNetworkSecurityGroup -ResourceGroupName databricks-rg-rqb2yo -Location eastus -Name nsg-test -SecurityRules $rdpRule
PS C:\> $privSubnet = New-AzVirtualNetworkSubnetConfig -Name priv-sub -AddressPrefix "10.0.1.0/24" -NetworkSecurityGroup $networkSecurityGroup -Delegation $dlg
PS C:\> $pubSubnet = New-AzVirtualNetworkSubnetConfig -Name pub-sub  -AddressPrefix "10.0.2.0/24" -NetworkSecurityGroup $networkSecurityGroup -Delegation $dlg
PS C:\> $testVN = New-AzVirtualNetwork -Name testvn -ResourceGroupName databricks-rg-rqb2yo -Location eastus -AddressPrefix "10.0.0.0/16" -Subnet $privSubnet,$pubSubnet
PS C:\> New-AzDatabricksWorkspace -Name workspace3miaeb-with-custom-vn -ResourceGroupName databricks-rg-rqb2yo -Location eastus -VirtualNetworkId $testVN.Id -PrivateSubnetName $privSubnet.Name -PublicSubnetName $privSubnet.Name -Sku standard

Name            ResourceGroupName    Location Managed Resource Group ID
----            -----------------    -------- -------------------------
workspace3miaeb databricks-rg-rqb2yo eastus   /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3miaeb-3c0s2mbgrqv9k
```

This command creates a Databricks workspace with customized virtual network in a resource group.

### Example 3: Create a Databricks workspace with enable encryption
```powershell
PS C:\> New-AzDatabricksWorkspace -Name workspace3miaeb -ResourceGroupName databricks-rg-rqb2yo -PrepareEncryption -Location "East US 2 EUAP" -Sku premium

Name            ResourceGroupName    Location Managed Resource Group ID
----            -----------------    -------- -------------------------
workspace3miaeb databricks-rg-rqb2yo eastus   /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3miaeb-3c0s2mbgrqv9k
```

This command creates a Databricks workspace and sets it to prepare for encryption. Please refer to the examples of Update-AzDatabricksWorkspace for more settings to encryption.