### Example 1: Get the default account for the scope Tenant.
```powershell
Get-AzPurviewDefaultAccount -ScopeTenantId xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a -ScopeType Tenant
```

```output
AccountName ResourceGroupName Scope                                ScopeTenantId                        ScopeType SubscriptionId
----------- ----------------- -----                                -------------                        --------- --------------
test-pa      test-rg            xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a Tenant    xxxxxxxx-1bf0-4dda-aec3
```

 Get the default account for the scope Tenant
