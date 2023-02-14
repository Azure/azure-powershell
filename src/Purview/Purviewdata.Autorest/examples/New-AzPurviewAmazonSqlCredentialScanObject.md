### Example 1: Create Amazon Sql Credential scan object
```powershell
<<<<<<< HEAD
New-AzPurviewAmazonSqlCredentialScanObject -Kind 'AmazonSqlCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth' -DatabaseName 'db' -Port 5432 -ScanRulesetName 'AmazonSql' -ScanRulesetType 'System' -ServerEndpoint 'DummyServer' -VpcEndpointServiceName 'com.amazonaws.ypce.wus.123456789'
```

```output
=======
PS C:\> New-AzPurviewAmazonSqlCredentialScanObject -Kind 'AmazonSqlCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth' -DatabaseName 'db' -Port 5432 -ScanRulesetName 'AmazonSql' -ScanRulesetType 'System' -ServerEndpoint 'DummyServer' -VpcEndpointServiceName 'com.amazonaws.ypce.wus.123456789'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
CredentialReferenceName   : sqlauth
CredentialType            : SqlAuth
DatabaseName              : db
Id                        :
Kind                      : AmazonSqlCredential
LastModifiedAt            :
Name                      :
Port                      : 5432
Result                    :
ScanRulesetName           : AmazonSql
ScanRulesetType           : System
ServerEndpoint            : DummyServer
VpcEndpointServiceName    : com.amazonaws.ypce.wus.123456789
Worker                    :
```

Create Amazon Sql Credential scan object

