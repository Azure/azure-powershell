### Example 1: Delete an existing AttachedDatabaseConfiguration by name
```powershell
PS C:\> Remove-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName "testrg" -WorkspaceName "testws" -KustoPoolName "testkustopool" -AttachedDatabaseConfigurationName "myfollowerconfiguration"
```

The above command deletes the attached database configuration with the given name "myfollowerconfiguration" from workspace "testws".
