### Example 1: Check if a file share name is available
```powershell
Test-AzFileShareNameAvailability -Location uaecentral -Name $shareName -Type "Microsoft.FileShares/fileShares"
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

This command checks if the file share name is available.
