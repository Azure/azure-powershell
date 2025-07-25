### Example 1:  List all the binary hardening analysis results for a firmware.
```powershell
Get-AzFirmwareAnalysisBinaryHardening -FirmwareId FirmwareId -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName | ConvertTo-Json
```

```output
[
  {
    "Architecture": "",
    "BinaryHardeningId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "Class": "",
    "FeatureCanary": boolean,
    "FeatureNx": boolean,
    "FeaturePie": boolean,
    "FeatureRelro": boolean,
    "FeatureStripped": boolean,
    "FilePath": "filePath",
    "Id": "id",
    "Name": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "Rpath": "",
    "Runpath": "",
    "SystemDataCreatedAt": "",
    "SystemDataCreatedBy": "",
    "SystemDataCreatedByType": "",
    "SystemDataLastModifiedAt": "",
    "SystemDataLastModifiedBy": "",
    "SystemDataLastModifiedByType": "",
    "Type": "Microsoft.IoTFirmwareDefense/workspaces/firmwares/binaryHardeningResults"
  }
] 
```

List all the binary hardening analysis results for a firmware.

