### Example 1: Removes the HybridConnection from the specified HybridConnection namespace
```powershell
Remove-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name connection-01
```

```output
```

This command removes the HybridConnection from the specified HybridConnection namespace.

### Example 2: Removes the HybridConnection from the specified HybridConnection namespace by pipeline
```powershell
Get-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name connection-01 | Remove-AzRelayHybridConnection
```

```output
```

This command removes the HybridConnection from the specified HybridConnection namespace by pipeline.