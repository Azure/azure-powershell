### Example 1: UpdateExpanded
```powershell
PS C:\> Update-AzBareMetal -Name oraclerac53 -ResourceGroupName SAT09A-T530 -Tag @{"env"="test"}

Location       Name        ResourceGroupName
--------       ----        -----------------
southcentralus oraclerac53 SAT09A-T530
```

Patches the Tags field of a Azure BareMetal instance for the specified subscription, resource group, and instance name.

### Example 2: UpdateViaIdentityExpanded
```powershell
PS C:\> Get-AzBareMetal -Name oraclerac53 -ResourceGroupName SAT09A-T530 | Update-AzBareMetal -Tag @{"env"="test"}

Location       Name        ResourceGroupName
--------       ----        -----------------
southcentralus oraclerac53 SAT09A-T530
```

Patches the Tags field of a Azure BareMetal instance for the specified subscription, resource group, and instance name.