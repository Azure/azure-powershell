### Example 1: Delete a Network Anchor
```powershell
Remove-AzOracleNetworkAnchor -ResourceGroupName PowerShellTestRg -Name PowerShellTestNetworkAnchor -PassThru
```

```output
True
```

Deletes the specified Network Anchor. For more information, execute `Get-Help Remove-AzOracleNetworkAnchor`.

### Example 2: Delete a Network Anchor by piping from Get
```powershell
Get-AzOracleNetworkAnchor -ResourceGroupName PowerShellTestRg -Name PowerShellTestNetworkAnchor | Remove-AzOracleNetworkAnchor -PassThru
```

```output
True
```

Gets the specified Network Anchor and deletes it. For more information, execute `Get-Help Remove-AzOracleNetworkAnchor`.
