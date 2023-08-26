### Example 1: Get resources by ResourceGroupName
```powershell
Get-AzGraphServicesAccount -ResourceGroupName myRG
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
Global   myGraphAppBilling1 myRG
Global   myGraphAppBilling2 myRG
```

This command gets all the GraphServices Account resources for a resource group. 

### Example 2: Get resources by Name
```powershell
Get-AzGraphServicesAccount -ResourceGroupName myRG -Name myGraphAppBilling
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
Global   myGraphAppBilling myRG
```

This command gets a GraphServices Account resource. 
