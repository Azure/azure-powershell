### Example 1: Returns the cluster customer credentials for the dedicated appliance.
```powershell
Get-AzResourceConnectorBridgeKey -ResourceGroupName azps_test_group -Name azps-resource-bridge
```

```output
ArtifactProfile Kubeconfig SshKey
--------------- ---------- ------
{…                         {…
```

Returns the cluster customer credentials for the dedicated appliance.