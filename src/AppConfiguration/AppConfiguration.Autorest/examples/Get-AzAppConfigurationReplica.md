### Example 1: List all replicas of an app configuration store
```powershell
Get-AzAppConfigurationReplica -ConfigStoreName azpstest-appstore -ResourceGroupName azpstest_gp
```

```output
Name            Location  ProvisioningState ResourceGroupName
----            --------  ----------------- -----------------
westus2replica  westus2   Succeeded         azpstest_gp
eastusreplica   eastus    Succeeded         azpstest_gp
```

This command lists all replicas of the specified app configuration store.

### Example 2: Get a specific replica of an app configuration store
```powershell
Get-AzAppConfigurationReplica -ConfigStoreName azpstest-appstore -ResourceGroupName azpstest_gp -Name westus2replica
```

```output
Name            Location  ProvisioningState ResourceGroupName
----            --------  ----------------- -----------------
westus2replica  westus2   Succeeded         azpstest_gp
```

This command gets the properties of a specific replica by name.

