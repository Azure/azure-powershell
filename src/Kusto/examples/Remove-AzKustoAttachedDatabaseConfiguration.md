### Example 1: Delete an existing AttachedDatabaseConfiguration by name
```powershell
PS C:\> Remove-AzKustoAttachedDatabaseConfiguration -ResourceGroupName "testrg" -ClusterName "testnewkustoclusterf" -Name "myfollowerconfiguration"
```

The above command deletes the follower database defined in the AttachedDatabaseConfiguration "myfollowerconfiguration" from cluster "testnewkustoclusterf".
