### Example 1: List the VM ingestion details that will be monitored by the Elastic monitor resource
```powershell
Get-AzElasticDetailVMIngestion -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01
```

```output
CloudId
-------
Monitor01:xxxxxxxxxxxxxxxxxxxxxxxxx
```

List the VM ingestion details that will be monitored by the Elastic monitor resource.

### Example 2: List the VM ingestion details that will be monitored by the Elastic monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor02 | Get-AzElasticDetailVMIngestion
```

```output
CloudId
-------
Monitor02:xxxxxxxxxxxxxxxxxxxxxxxxx
```

List the VM ingestion details that will be monitored by the Elastic monitor resource via pipeline.
