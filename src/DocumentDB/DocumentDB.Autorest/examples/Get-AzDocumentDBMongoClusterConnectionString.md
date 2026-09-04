### Example 1: List the connection strings of a mongo cluster
```powershell
Get-AzDocumentDBMongoClusterConnectionString -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

```output
Name                    ConnectionString
----                    ----------------
Default connection s... mongodb+srv://<user>:<password>@myCluster.global.mongocluster.cosmos.azure.com/...
```

List the connection strings for a provisioned mongo cluster. The credential
placeholders in the returned strings must be replaced with the administrator
credentials.
