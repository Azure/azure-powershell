### Example 1: Create a Kusto database script
```powershell
New-AzKustoScript -ClusterName testnewkustocluster -DatabaseName mykustodatabase -Name newkustoscript -ResourceGroupName testrg -ScriptUrl $BlobSASURL -ScriptUrlSasToken $BlobSASToken -PrincipalPermissionsAction "RemovePermissionOnScriptCompletion" -ScriptLevel "Database"
```

```output
Name                                               Type
----                                               ----
testnewkustocluster/mykustodatabase/newkustoscript Microsoft.Kusto/Clusters/Databases/Scripts
```

The above command creates a Kusto database script named "newkustocript" in the resource group "testrg". 
This script contains database scoped commands and the permissions of the script executor will be removed upon completion
