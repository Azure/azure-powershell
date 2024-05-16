### Example 1:  List all the crypto certificate analysis results for a firmware. 
```powershell
Get-AzFirmwareAnalysisCryptoCertificate -FirmwareId FirmwareId -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName | ConvertTo-Json
```

```output
[
 {
    "CryptoCertId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "Encoding": "",
    "ExpirationDate": "",
    "FilePath": [""],
    "Fingerprint": "",
    "Id": "",
    "IsExpired": boolean,
    "IsSelfSigned": boolean,
    "IsShortKeySize": boolean,
    "IsWeakSignature": "",
    "IssuedDate": "",
    "IssuerCommonName": "",
    "IssuerCountry": "",
    "IssuerOrganization": "",
    "IssuerOrganizationalUnit": "",
    "IssuerState": "",
    "KeyAlgorithm": "",
    "KeySize": ,
    "Name": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "PairedKeyId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "PairedKeyType": "",
    "PropertiesName": "",
    "Role": "",
    "SerialNumber": "",
    "SignatureAlgorithm": "",
    "SubjectCommonName": "",
    "SubjectCountry": "",
    "SubjectOrganization": "",
    "SubjectOrganizationalUnit": "",
    "SubjectState": "",
    "SystemDataCreatedAt": ,
    "SystemDataCreatedBy": ,
    "SystemDataCreatedByType": ,
    "SystemDataLastModifiedAt": ,
    "SystemDataLastModifiedBy": ,
    "SystemDataLastModifiedByType": ,
    "Type": "Microsoft.IoTFirmwareDefense/workspaces/firmwares/cryptoCertificates",
    "Usage": []
  }
]
```

List all the crypto certificate analysis results for a firmware.

