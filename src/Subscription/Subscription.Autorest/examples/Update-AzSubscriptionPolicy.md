### Example 1: Create or Update Subscription tenant policy for user's tenant.
```powershell
Update-AzSubscriptionPolicy -BlockSubscriptionsIntoTenant:$true -BlockSubscriptionsLeavingTenant:$false -ExemptedPrincipal XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
```

```output
Name    PolicyId                             BlockSubscriptionsIntoTenant BlockSubscriptionsLeavingTenant
----    --------                             ---------------------------- -------------------------------
default XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX True                         False
```

Create or Update Subscription tenant policy for user's tenant.