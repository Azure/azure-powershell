### Example 1: Delete a Relay dedicated cluster
```powershell
Remove-AzRelayCluster -ResourceGroupName lucas-relay-rg -Name relaycluster01
```

The cmdlet deletes the specified Relay dedicated cluster. A cluster cannot be deleted while namespaces are still assigned to it.

### Example 2: Delete a Relay dedicated cluster via pipeline
```powershell
Get-AzRelayCluster -ResourceGroupName lucas-relay-rg -Name relaycluster01 | Remove-AzRelayCluster
```

The cmdlet deletes a Relay dedicated cluster piped in from Get-AzRelayCluster.
