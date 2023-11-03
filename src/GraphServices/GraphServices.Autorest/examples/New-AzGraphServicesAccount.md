### Example 1: Enable an application
```powershell
New-AzGraphServicesAccount -ResourceGroupName myRG -Name myGraphAppBilling -AppId myAppGUID -SubscriptionId mySubscriptionGUID -Location Global
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
Global   myGraphAppBilling myRG
```

This command enables an App for billing.