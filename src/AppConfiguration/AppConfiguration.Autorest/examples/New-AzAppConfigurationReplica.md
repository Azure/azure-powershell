### Example 1: Create a new replica of an app configuration store
```powershell
New-AzAppConfigurationReplica -ConfigStoreName azpstest-appstore -ResourceGroupName azpstest_gp -Name westus2replica -Location westus2
```

```output
Name            Location
----            --------
westus2replica  westus2
```

This command creates a new replica of the specified app configuration store in the West US 2 region.

