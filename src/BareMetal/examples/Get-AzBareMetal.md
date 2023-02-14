### Example 1: List
```powershell
<<<<<<< HEAD
Get-AzBareMetal
```

```output
=======
PS C:\> Get-AzBareMetal

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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
<<<<<<< HEAD
Get-AzBareMetal -Name oelnvmetest -ResourceGroupName SAT09A-T230
```

```output
=======
PS C:\> Get-AzBareMetal -Name oelnvmetest -ResourceGroupName SAT09A-T230

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location       Name         ResourceGroupName
--------       ----         -----------------
southcentralus oelnvmetest  SAT09A-T230
```

Gets an Azure BareMetal instance for the specified subscription, resource group, and instance name.

### Example 3: List1
```powershell
<<<<<<< HEAD
Get-AzBareMetal -ResourceGroupName MWH03A-T210
```

```output
=======
PS C:\> Get-AzBareMetal -ResourceGroupName MWH03A-T210

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name        ResourceGroupName
-------- ----        -----------------
westus2  rhel79ora01 MWH03A-T210
westus2  rhel79ora02 MWH03A-T210
```

Gets Azure BareMetal instance for the resource group.