### Example 1: Create a Network Anchor
```powershell
$resourceAnchorId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/resourceAnchors/PowerShellTestResourceAnchor"
$subnetId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PowerShellTestVnet/subnets/delegated"

New-AzOracleNetworkAnchor `
  -ResourceGroupName PowerShellTestRg `
  -Name PowerShellTestNetworkAnchor `
  -Location eastus `
  -ResourceAnchorId $resourceAnchorId `
  -SubnetId $subnetId `
  -Zone 2
```

Creates a Network Anchor that associates an Oracle Resource Anchor with a delegated subnet. For more information, execute `Get-Help New-AzOracleNetworkAnchor`.

### Example 2: Create a Network Anchor with tags
```powershell
$resourceAnchorId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/resourceAnchors/PowerShellTestResourceAnchor"
$subnetId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PowerShellTestVnet/subnets/delegated"

New-AzOracleNetworkAnchor `
  -ResourceGroupName PowerShellTestRg `
  -Name PowerShellTestNetworkAnchor `
  -Location eastus `
  -ResourceAnchorId $resourceAnchorId `
  -SubnetId $subnetId `
  -Zone 2 `
  -Tag @{ environment = "test"; owner = "example@contoso.com" }
```

Creates a Network Anchor and assigns tags. For more information, execute `Get-Help New-AzOracleNetworkAnchor`.
