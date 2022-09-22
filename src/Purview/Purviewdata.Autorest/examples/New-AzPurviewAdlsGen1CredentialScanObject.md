### Example 1: Create AdlsGen1 Credential scan object
```powershell
New-AzPurviewAdlsGen1CredentialScanObject -Kind 'AdlsGen1Credential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'svcp' -CredentialType 'ServicePrincipal' -ScanRulesetName 'AdlsGen1' -ScanRulesetType 'System'
```

```output
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
CredentialReferenceName   : svcp
CredentialType            : ServicePrincipal
Id                        :
Kind                      : AdlsGen1Credential
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AdlsGen1
ScanRulesetType           : System
Worker                    :
```

Create AdlsGen1 Credential scan object

