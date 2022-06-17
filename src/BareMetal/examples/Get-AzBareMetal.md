### Example 1: List
```powershell
Get-AzBareMetal
```

```output
Location       Name         ResourceGroupName
--------       ----         -----------------
westus2        rhel79ora01  MWH03A-T210
westus2        rhel79ora02  MWH03A-T210
southcentralus oelnvmetest  SAT09A-T230
centraluseuap  orcllabdsm01 DSM05A-T030
```

Gets Azure BareMetal instance.

### Example 2: Get
```powershell
Get-AzBareMetal -Name oelnvmetest -ResourceGroupName SAT09A-T230
```

```output
Location       Name         ResourceGroupName
--------       ----         -----------------
southcentralus oelnvmetest  SAT09A-T230
```

Gets an Azure BareMetal instance for the specified subscription, resource group, and instance name.

### Example 3: List1
```powershell
Get-AzBareMetal -ResourceGroupName MWH03A-T210
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
westus2  rhel79ora01 MWH03A-T210
westus2  rhel79ora02 MWH03A-T210
```

Gets Azure BareMetal instance for the resource group.