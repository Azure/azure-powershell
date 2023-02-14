### Example 1: UpdateExpanded
```powershell
<<<<<<< HEAD
Update-AzBareMetal -Name oraclerac53 -ResourceGroupName SAT09A-T530 -Tag @{"env"="test"}
```

```output
=======
PS C:\> Update-AzBareMetal -Name oraclerac53 -ResourceGroupName SAT09A-T530 -Tag @{"env"="test"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location       Name        ResourceGroupName
--------       ----        -----------------
southcentralus oraclerac53 SAT09A-T530
```

Patches the Tags field of a Azure BareMetal instance for the specified subscription, resource group, and instance name.

### Example 2: UpdateViaIdentityExpanded
```powershell
<<<<<<< HEAD
Get-AzBareMetal -Name oraclerac53 -ResourceGroupName SAT09A-T530 | Update-AzBareMetal -Tag @{"env"="test"}
```

```output
=======
PS C:\> Get-AzBareMetal -Name oraclerac53 -ResourceGroupName SAT09A-T530 | Update-AzBareMetal -Tag @{"env"="test"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location       Name        ResourceGroupName
--------       ----        -----------------
southcentralus oraclerac53 SAT09A-T530
```

Patches the Tags field of a Azure BareMetal instance for the specified subscription, resource group, and instance name.