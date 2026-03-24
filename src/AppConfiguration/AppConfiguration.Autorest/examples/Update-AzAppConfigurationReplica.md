### Example 1: Update a replica of an app configuration store
```powershell
Update-AzAppConfigurationReplica -ConfigStoreName azpstest-appstore -ResourceGroupName azpstest_gp -Name westus2replica
```

```output
Name            Location
----            --------
westus2replica  westus2
```

This command updates the specified replica of an app configuration store.

### Example 2: Update a replica of an app configuration store by pipeline
```powershell
Get-AzAppConfigurationReplica -ConfigStoreName azpstest-appstore -ResourceGroupName azpstest_gp -Name westus2replica | Update-AzAppConfigurationReplica
```

```output
Name            Location
----            --------
westus2replica  westus2
```

This command updates a replica by piping the output of Get-AzAppConfigurationReplica.

