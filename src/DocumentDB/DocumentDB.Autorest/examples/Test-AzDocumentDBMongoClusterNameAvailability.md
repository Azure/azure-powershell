### Example 1: Check the availability of a mongo cluster name
```powershell
Test-AzDocumentDBMongoClusterNameAvailability -Name myCluster -Location eastus2 -Type 'Microsoft.DocumentDB/mongoClusters'
```

```output
NameAvailable Reason Message
------------- ------ -------
         True
```

Check whether a mongo cluster name is available in a location before creating the
cluster.
