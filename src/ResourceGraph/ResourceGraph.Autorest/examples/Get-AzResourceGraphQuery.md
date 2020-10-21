### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzResourceGraphQuery -ResourceGroupName lucas-rg-test

ETag Location Name            Type
---- -------- ----            ----
     global   SharedQuery-t01 microsoft.resourcegraph/queries
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzResourceGraphQuery -ResourceGroupName lucas-rg-test -Name SharedQuery-t01

ETag Location Name            Type
---- -------- ----            ----
     global   SharedQuery-t01 microsoft.resourcegraph/queries
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> $query = New-AzResourceGraphQuery -ResourceGroupName lucas-rg-test -Name query-t03 -Location 'global' -Query 'project id, name, type, location' -Description 'test'
PS C:\> Get-AzResourceGraphQuery -InputObject $query

ETag Location Name            Type
---- -------- ----            ----
     global   SharedQuery-t01 microsoft.resourcegraph/queries
```

{{ Add description here }}

