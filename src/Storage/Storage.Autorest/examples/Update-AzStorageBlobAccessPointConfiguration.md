### Example 1: Change a Blob Access Point description
```powershell
Update-AzStorageBlobAccessPointConfiguration -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -Name "myaccesspoint" -Description "External archive source"
```

Updates the description without resending source credentials. Use Property or a JSON body for supported nested updates. The source endpoint cannot be changed by this operation.
