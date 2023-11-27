### Example 1: Gets the system assigned identity available under the specified RP scope
```powershell
Get-AzSystemAssignedIdentity -Scope "/subscriptions/00000000-0000-0000-00000000000/resourcegroups/lucas-rg-test/providers/Microsoft.Web/sites/functionportal01"
```

```output
Name            Location ResourceGroupName
----            -------- -----------------
ubuntu-portal01 eastus   azure-rg-test
```

This command gets the system assigned identity available under the specified RP scope.
