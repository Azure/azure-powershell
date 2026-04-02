### Example 1: List all replicas of an app configuration store
```powershell
Get-AzAppConfigurationReplica -ConfigStoreName azpstest-appstore -ResourceGroupName azpstest_gp
```

```output
Name            Location  Endpoint                                                                   ProvisioningState ResourceGroupName
----            --------  --------                                                                   ----------------- -----------------
westus2replica  westus2   https://azpstest-appstore-westus2replica.westus2.appconfig.io               Succeeded         azpstest_gp
eastusreplica   eastus    https://azpstest-appstore-eastusreplica.eastus.appconfig.io                 Succeeded         azpstest_gp
```

This command lists all replicas of the specified app configuration store.

### Example 2: Get a specific replica of an app configuration store
```powershell
Get-AzAppConfigurationReplica -ConfigStoreName azpstest-appstore -ResourceGroupName azpstest_gp -Name westus2replica
```

```output
Name            Location  Endpoint                                                                   ProvisioningState ResourceGroupName
----            --------  --------                                                                   ----------------- -----------------
westus2replica  westus2   https://azpstest-appstore-westus2replica.westus2.appconfig.io               Succeeded         azpstest_gp
```

This command gets the properties of a specific replica by name.

