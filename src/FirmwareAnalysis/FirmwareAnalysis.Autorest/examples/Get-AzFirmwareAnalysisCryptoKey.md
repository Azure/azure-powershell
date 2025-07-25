### Example 1:  List all the crypto key analysis results for a firmware. 
```powershell
Get-AzFirmwareAnalysisCryptoKey -FirmwareId FirmwareId -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName | ConvertTo-Json
```

```output
[
  {
    "CryptoKeyId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "FilePath": [""],
    "Id": "",
    "IsShortKeySize": ,
    "KeyAlgorithm": "",
    "KeySize": ,
    "KeyType": "",
    "Name": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "PairedKeyId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "PairedKeyType": "",
    "SystemDataCreatedAt": ,
    "SystemDataCreatedBy": ,
    "SystemDataCreatedByType": ,
    "SystemDataLastModifiedAt": ,
    "SystemDataLastModifiedBy": ,
    "SystemDataLastModifiedByType": ,
    "Type": "Microsoft.IoTFirmwareDefense/workspaces/firmwares/cryptoKeys",
    "Usage": [
      ""
    ]
  }
]
```

List all the crypto key analysis results for a firmware.

