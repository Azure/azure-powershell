### Example 1: {{ Add title here }}
```powershell
PS C:\> New-AzResourceGraphQuery -ResourceGroupName lucas-rg-test -Name query-t03 -Location 'global' -Query 'project id, name, type, location' -Description 'test'

ETag Location Name      Type
---- -------- ----      ----
     global   query-t03 microsoft.resourcegraph/queries
```

{{ Add description here }}

