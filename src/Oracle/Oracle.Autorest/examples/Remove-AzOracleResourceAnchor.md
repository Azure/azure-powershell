### Example 1: Delete a Resource Anchor
```powershell
Remove-AzOracleResourceAnchor -ResourceGroupName PowerShellTestRg -Name OFake_PowerShellTestResourceAnchor -PassThru
```

```output
True
```

Deletes a Resource Anchor by name and resource group. For more information, execute `Get-Help Remove-AzOracleResourceAnchor`.

### Example 2: Delete a Resource Anchor by piping from Get
```powershell
Get-AzOracleResourceAnchor -ResourceGroupName PowerShellTestRg -Name OFake_PowerShellTestResourceAnchor | Remove-AzOracleResourceAnchor -PassThru
```

```output
True
```

Gets a Resource Anchor and deletes it by piping the object to `Remove-AzOracleResourceAnchor`. For more information, execute `Get-Help Remove-AzOracleResourceAnchor`.
