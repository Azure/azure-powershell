### Example 1: Remove a replica of an app configuration store
```powershell
Remove-AzAppConfigurationReplica -ConfigStoreName azpstest-appstore -ResourceGroupName azpstest_gp -Name westus2replica
```

This command removes the specified replica from an app configuration store.

### Example 2: Remove a replica of an app configuration store by pipeline
```powershell
Get-AzAppConfigurationReplica -ConfigStoreName azpstest-appstore -ResourceGroupName azpstest_gp -Name westus2replica | Remove-AzAppConfigurationReplica
```

This command removes a replica by piping the output of Get-AzAppConfigurationReplica.

