### Example 1: Create Azure File Service Credential scan object
```powershell
New-AzPurviewAzureFileServiceCredentialScanObject -Kind 'AzureFileServiceCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'datascantestdataparv-accountkey' -CredentialType 'AccountKey' -ScanRulesetName 'AzureFileService'  -ScanRulesetType 'System' -ShareName 'share'
```

```output
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
CredentialReferenceName   : datascantestdataparv-accountkey
CredentialType            : AccountKey
Id                        :
Kind                      : AzureFileServiceCredential
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AzureFileService
ScanRulesetType           : System
ShareName                 : share
Worker                    :
```

Create Azure File Service Credential scan object

