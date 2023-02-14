### Example 1: Create a scan instance under a data source
```powershell
<<<<<<< HEAD
$obj = New-AzPurviewAzureStorageCredentialScanObject -Kind 'AzureStorageCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'datascantestdataparv-accountkey' -CredentialType 'AccountKey' -ScanRulesetName 'AzureStorage' -ScanRulesetType 'System'
New-AzPurviewScan -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv' -Name 'ScanTest' -Body $obj
```

```output
=======
PS C:\> $obj = New-AzPurviewAzureStorageCredentialScanObject -Kind 'AzureStorageCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'datascantestdataparv-accountkey' -CredentialType 'AccountKey' -ScanRulesetName 'AzureStorage' -ScanRulesetType 'System'
New-AzPurviewScan -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv' -Name 'ScanTest' -Body $obj

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
CollectionLastModifiedAt  : 2/15/2022 3:49:23 PM
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 : 2/15/2022 3:49:23 PM
CredentialReferenceName   : datascantestdataparv-accountkey
CredentialType            : AccountKey
Id                        : datasources/DataScanTestData-Parv/scans/ScanTest
Kind                      : AzureStorageCredential
LastModifiedAt            : 2/15/2022 11:46:29 PM
Name                      : ScanTest
Result                    :
ScanRulesetName           : AzureStorage
ScanRulesetType           : System
Worker                    :
```

Create a scan instance 'ScanTest' under data source

