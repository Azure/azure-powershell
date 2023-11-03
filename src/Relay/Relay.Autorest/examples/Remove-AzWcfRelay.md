### Example 1: Remove a Wcf Relay
```powershell
Remove-AzWcfRelay -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name wcf-02
```

```output
```

This cmdlet removes a Wcf Relay.

### Example 2: Remove a Wcf Relay by pipeline
```powershell
Get-AzWcfRelay -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name wcf-03 | Remove-AzWcfRelay
```

```output
```

This cmdlet removes a Wcf Relay by pipeline.