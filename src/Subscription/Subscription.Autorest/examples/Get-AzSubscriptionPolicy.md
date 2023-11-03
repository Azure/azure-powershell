### Example 1: Get the subscription tenant policy for the user's tenant.
```powershell
Get-AzSubscriptionPolicy
```

```output
Name    PolicyId                             BlockSubscriptionsIntoTenant BlockSubscriptionsLeavingTenant
----    --------                             ---------------------------- -------------------------------
default XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX False                        True
```

Get the subscription tenant policy for the user's tenant.