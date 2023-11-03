### Example 1: Accept subscription ownership.
```powershell
Invoke-AzSubscriptionAcceptOwnership -SubscriptionId XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX -SubscriptionName "createSub" -Tag @{"abc"="123"} -PassThru
```

```output
True
```

Accept subscription ownership.