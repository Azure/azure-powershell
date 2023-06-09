### Example 1: Enable an application
```powershell
New-AzGraphServicesAccount -ResourceGroupName myRG -ResourceName myGraphAppBilling -AppId myGraphAppBilling -SubscriptionId mySubscriptionGUID -Location Global
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
Global   myGraphAppBilling myRG
```

This command enables an App for billing.