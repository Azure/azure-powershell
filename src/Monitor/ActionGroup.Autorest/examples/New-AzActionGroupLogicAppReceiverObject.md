### Example 1: create action group logic app receiver
```powershell
New-AzActionGroupLogicAppReceiverObject -CallbackUrl "https://p*****7w" -Name "sample logic app" -ResourceId "/subscriptions/{subId}/resourceGroups/LogicApp/providers/Microsoft.Logic/workflows/testLogicApp"
```

```output
CallbackUrl      Name             ResourceId
-----------      ----             ----------
https://p*****7w sample logic app /subscriptions/{subId}/resourceGroups/LogicApp/provid…
```

This command creates action group logic app receiver object.

