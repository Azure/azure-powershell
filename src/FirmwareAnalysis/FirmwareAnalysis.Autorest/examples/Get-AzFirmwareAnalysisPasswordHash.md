### Example 1:  List all the password hash analysis results for a firmware. 
```powershell
 Get-AzFirmwareAnalysisPasswordHash -FirmwareId FirmwareId -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName | ConvertTo-Json 
```

```output
[
  {
    "Algorithm": "",
    "Context": "",
    "FilePath": "/path/to/file",
    "Hash": "",
    "Id": "",
    "Name": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "PasswordHashId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "Salt": "",
    "SystemDataCreatedAt": ,
    "SystemDataCreatedBy": ,
    "SystemDataCreatedByType": ,
    "SystemDataLastModifiedAt": ,
    "SystemDataLastModifiedBy": ,
    "SystemDataLastModifiedByType": ,
    "Type": "Microsoft.IoTFirmwareDefense/workspaces/firmwares/passwordHashes",
    "Username": ""
  }
]
```

 List all the password hash analysis results for a firmware. 

