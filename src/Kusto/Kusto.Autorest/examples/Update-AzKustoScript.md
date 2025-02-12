### Example 1: Update an existing kusto script by name
```powershell
Update-AzKustoScript -DatabaseName mykustodatabase -Name newkustoscript -ClusterName testnewkustocluster -ResourceGroupName testrg -ScriptUrl $BlobSASURL -ScriptUrlSasToken $BlobSASToken -PrincipalPermissionsAction RemovePermissionOnScriptCompletion -ScriptLevel Database
```

```output
Name                                               Type
----                                               ----
testnewkustocluster/mykustodatabase/newkustoscript Microsoft.Kusto/Clusters/Databases/Scripts
```

The above command updates the Kusto script "newkustoscript" found in the resource group "testrg".