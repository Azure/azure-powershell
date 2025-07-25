### Example 1: List the vm ingestion details that will be monitored by the Elastic monitor resource
```powershell
Get-AzElasticDetailVMIngestion -ResourceGroupName elastic-rg-3eytki -Name elastic-rhqz1v
```

```output
CloudId                                  IngestionKey
-------                                  ------------
elastic-rhqz1v:xxxxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxx
```

This command lists the vm ingestion details that will be monitored by the Elastic monitor resource.

### Example 2: List the vm ingestion details that will be monitored by the Elastic monitor resource by pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName elastic-rg-3eytki -Name elastic-rhqz1v | Get-AzElasticDetailVMIngestion
```

```output
CloudId                                  IngestionKey
-------                                  ------------
elastic-rhqz1v:xxxxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxx
```

This command lists the vm ingestion details that will be monitored by the Elastic monitor resource by pipeline.

