### Example 1: Get a Blob Access Point configuration
```powershell
Get-AzStorageBlobAccessPointConfiguration -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -Name "myaccesspoint"
```

Gets the stored configuration and connection-test status. Omit Name to list the storage account's configurations. The service does not return write-only credentials.
