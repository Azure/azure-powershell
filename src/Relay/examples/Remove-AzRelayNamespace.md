### Example 1: Remove a relay namespace
```powershell
Remove-AzRelayNamespace -ResourceGroupName lucas-relay-rg -Name namespace-pwsh01
```

```output
```

This cmdlet removes a relay namespace.

### Example 2: Remove a relay namespace by pipeline
```powershell
Get-AzRelayNamespace -ResourceGroupName lucas-relay-rg -Name namespace-pwsh01 | Remove-AzRelayNamespace
```

```output
```

This cmdlet removes a relay namespace by pipeline.