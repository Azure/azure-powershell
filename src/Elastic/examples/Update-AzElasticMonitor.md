### Example 1: {{ Add title here }}
```powershell
PS C:\> Update-AzElasticMonitor -ResourceGroupName lucas-elastic-test -Name elastic-pwsh02 -Tag @{'key01' = '1'; 'key2' = '2'; 'key3' = '3'}

Location Name           Type
-------- ----           ----
westus2  elastic-pwsh02 microsoft.elastic/monitors
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzElasticMonitor -ResourceGroupName lucas-elastic-test -Name elastic-pwsh02 | Update-AzElasticMonitor -Tag @{'key01' = '1'; 'key2' = '2'; 'key3' = '3'}
Location Name           Type
-------- ----           ----
westus2  elastic-pwsh02 microsoft.elastic/monitors
```

{{ Add description here }}

