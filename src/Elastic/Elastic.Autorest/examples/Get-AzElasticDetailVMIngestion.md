### Example 1: List the vm ingestion details that will be monitored by the Elastic monitor resource
```powershell
PS C:\> Get-AzElasticDetailVMIngestion -ResourceGroupName elastic-rg-3eytki -Name elastic-rhqz1v

CloudId                                  IngestionKey
-------                                  ------------
elastic-rhqz1v:xxxxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxx
```

This command lists the vm ingestion details that will be monitored by the Elastic monitor resource.

### Example 2: List the vm ingestion details that will be monitored by the Elastic monitor resource by pipeline
```powershell
PS C:\> Get-AzElasticMonitor -ResourceGroupName elastic-rg-3eytki -Name elastic-rhqz1v | Get-AzElasticDetailVMIngestion

CloudId                                  IngestionKey
-------                                  ------------
elastic-rhqz1v:xxxxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxx
```

This command lists the vm ingestion details that will be monitored by the Elastic monitor resource by pipeline.

