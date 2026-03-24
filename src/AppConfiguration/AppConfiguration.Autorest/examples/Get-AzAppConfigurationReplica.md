### Example 1: List all replicas of an app configuration store
```powershell
Get-AzAppConfigurationReplica -ConfigStoreName azpstest-appstore -ResourceGroupName azpstest_gp
```

```output
Name            Location
----            --------
westus2replica  westus2
eastusreplica   eastus
```

This command lists all replicas of the specified app configuration store.

### Example 2: Get a specific replica of an app configuration store
```powershell
Get-AzAppConfigurationReplica -ConfigStoreName azpstest-appstore -ResourceGroupName azpstest_gp -Name westus2replica
```

```output
Name            Location
----            --------
westus2replica  westus2
```

This command gets the properties of a specific replica by name.

