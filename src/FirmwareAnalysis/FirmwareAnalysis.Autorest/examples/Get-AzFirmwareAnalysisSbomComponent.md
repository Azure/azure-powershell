### Example 1: List all the sbom component analysis results for a firmware.
```powershell
Get-AzFirmwareAnalysisSbomComponent -FirmwareId FirmwareId -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName | ConvertTo-Json
```

```output
[
  {
    "ComponentId": "",
    "ComponentName": "",
    "FilePath": [""],
    "Id": "",
    "License": "",
    "Name": "",
    "SystemDataCreatedAt": ,
    "SystemDataCreatedBy": ,
    "SystemDataCreatedByType": ,
    "SystemDataLastModifiedAt": ,
    "SystemDataLastModifiedBy": ,
    "SystemDataLastModifiedByType": ,
    "Type": "Microsoft.IoTFirmwareDefense/workspaces/firmwares/sbomComponents",
    "Version": ""
  }
]
```

List all the sbom component analysis results for a firmware.

