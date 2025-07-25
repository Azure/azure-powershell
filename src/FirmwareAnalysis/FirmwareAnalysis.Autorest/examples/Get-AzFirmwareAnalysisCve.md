### Example 1:  List all the cve analysis results for a firmware. 
```powershell
Get-AzFirmwareAnalysisCve -FirmwareId FirmwareId -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName | ConvertTo-Json
```

```output
[
  {
    "ComponentId": ,
    "ComponentName": "",
    "ComponentVersion": "",
    "CveId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "CvssScore": "",
    "CvssV2Score": "",
    "CvssV3Score": "",
    "CvssVersion": "",
    "Description": "",
    "Id": "",
    "Link": [
      "",
      ""
    ],
    "Name": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "PropertiesName": "",
    "Severity": "",
    "SystemDataCreatedAt": ,
    "SystemDataCreatedBy": ,
    "SystemDataCreatedByType": ,
    "SystemDataLastModifiedAt": ,
    "SystemDataLastModifiedBy": ,
    "SystemDataLastModifiedByType": ,
    "Type": "Microsoft.IoTFirmwareDefense/workspaces/firmwares/cves"
  }
]
```

List all the cve analysis results for a firmware.

