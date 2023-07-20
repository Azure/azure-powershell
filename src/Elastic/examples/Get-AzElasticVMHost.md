### Example 1: List the VM resources currently being monitored by the Elastic monitor resource
```powershell
Get-AzElasticVMHost -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01
```

```output
VMResourceId
------------
/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ElasticResourceGroup01/providers/Microsoft.Comp…
```

List the VM resources currently being monitored by the Elastic monitor resource.

### Example 2: List the VM resources currently being monitored by the Elastic monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor01 | Get-AzElasticVMHost
```

```output
VMResourceId
------------
/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ElasticResourceGroup01/providers/Microsoft.Comp…
```

List the VM resources currently being monitored by the Elastic monitor resource via pipeline.
