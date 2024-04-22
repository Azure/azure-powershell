### Example 1: Create AdlsGen2 Credential scan object
```powershell
New-AzPurviewAdlsGen2CredentialScanObject -Kind 'AdlsGen2Credential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'datascantestdataparv-accountkey' -CredentialType 'AccountKey' -ScanRulesetName 'AdlsGen2'  -ScanRulesetType 'System'
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
Kind                      : AdlsGen2Credential
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AdlsGen2
ScanRulesetType           : System
Worker                    :
```

Create AdlsGen2 Credential scan object

