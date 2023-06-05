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

### Example 2: Get resources by ResourceName
```powershell
Get-AzGraphServicesAccount -ResourceGroupName myRG -ResourceName myGraphAppBilling
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
Global   myGraphAppBilling myRG
```


