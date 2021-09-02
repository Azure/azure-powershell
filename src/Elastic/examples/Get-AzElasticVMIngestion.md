### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzElasticVMIngestion -ResourceGroupName lucas-elastic-test -Name elastic-pwsh02

CloudId 					  IngestionKey
------- 					  ------------
elastic-pwsh02:xxxxxxxxxxxxxx xxxxxxxxxxxxxx
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzElasticMonitor -ResourceGroupName lucas-elastic-test -Name elastic-pwsh02 | Get-AzElasticVMIngestion

CloudId 					  IngestionKey
------- 					  ------------
elastic-pwsh02:xxxxxxxxxxxxxx xxxxxxxxxxxxxx
```

{{ Add description here }}

