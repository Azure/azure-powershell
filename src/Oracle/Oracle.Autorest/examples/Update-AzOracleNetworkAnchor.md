### Example 1: Update tags on a Network Anchor
```powershell
Update-AzOracleNetworkAnchor `
  -ResourceGroupName PowerShellTestRg `
  -Name PowerShellTestNetworkAnchor `
  -Tag @{ environment = "test"; owner = "example@contoso.com" }
```

Updates the tags on an existing Network Anchor. For more information, execute `Get-Help Update-AzOracleNetworkAnchor`.

### Example 2: Update the OCI backup CIDR block
```powershell
Update-AzOracleNetworkAnchor `
  -ResourceGroupName PowerShellTestRg `
  -Name PowerShellTestNetworkAnchor `
  -OciBackupCidrBlock "10.0.2.0/24"
```

Updates the OCI backup CIDR block for an existing Network Anchor. For more information, execute `Get-Help Update-AzOracleNetworkAnchor`.
