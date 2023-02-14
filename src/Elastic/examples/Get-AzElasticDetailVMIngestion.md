### Example 1: List the vm ingestion details that will be monitored by the Elastic monitor resource
```powershell
<<<<<<< HEAD
Get-AzElasticDetailVMIngestion -ResourceGroupName elastic-rg-3eytki -Name elastic-rhqz1v
```

```output
=======
PS C:\> Get-AzElasticDetailVMIngestion -ResourceGroupName elastic-rg-3eytki -Name elastic-rhqz1v

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
CloudId                                  IngestionKey
-------                                  ------------
elastic-rhqz1v:xxxxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxx
```

This command lists the vm ingestion details that will be monitored by the Elastic monitor resource.

### Example 2: List the vm ingestion details that will be monitored by the Elastic monitor resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzElasticMonitor -ResourceGroupName elastic-rg-3eytki -Name elastic-rhqz1v | Get-AzElasticDetailVMIngestion
```

```output
=======
PS C:\> Get-AzElasticMonitor -ResourceGroupName elastic-rg-3eytki -Name elastic-rhqz1v | Get-AzElasticDetailVMIngestion

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
CloudId                                  IngestionKey
-------                                  ------------
elastic-rhqz1v:xxxxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxx
```

This command lists the vm ingestion details that will be monitored by the Elastic monitor resource by pipeline.

