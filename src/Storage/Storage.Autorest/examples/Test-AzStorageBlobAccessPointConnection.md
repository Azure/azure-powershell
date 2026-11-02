### Example 1: Test a proposed source connection
```powershell
Test-AzStorageBlobAccessPointConnection -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -JsonFilePath "./proposed-connection.json"
```

Tests a proposed connection without creating a stored configuration. The JSON file contains a top-level source object with sourceType, connection, and auth properties. Protect the file if it contains credentials and remove it when no longer needed.
