### Example 1: Delete a Network Anchor
```powershell
Remove-AzOracleNetworkAnchor -ResourceGroupName PowerShellTestRg -Name OFake_owerShellTestNetworkAnchor -PassThru
```

```output
True
```

Deletes a Network Anchor by name and resource group. For more information, execute `Get-Help Remove-AzOracleNetworkAnchor`.

### Example 2: Delete a Network Anchor by piping from Get
```powershell
Get-AzOracleNetworkAnchor -ResourceGroupName PowerShellTestRg -Name OFake_owerShellTestNetworkAnchor | Remove-AzOracleNetworkAnchor -PassThru
```

```output
True
```

Gets a Network Anchor and deletes it by piping the object to `Remove-AzOracleNetworkAnchor`. For more information, execute `Get-Help Remove-AzOracleNetworkAnchor`.
