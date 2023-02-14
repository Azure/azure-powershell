### Example 1: Create PowerBI delegated scan object
```powershell
<<<<<<< HEAD
New-AzPurviewPowerBIDelegatedScanObject -Kind 'PowerBIDelegated' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -IncludePersonalWorkspace $true -ClientId 'xxxxxxx-cdfd-4016-9e80-xxxxxxxx' -UserName 'abcd@msft.com' -Password 'pwd'
```

```output
=======
PS C:\> New-AzPurviewPowerBIDelegatedScanObject -Kind 'PowerBIDelegated' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -IncludePersonalWorkspace $true -ClientId 'xxxxxxx-cdfd-4016-9e80-xxxxxxxx' -UserName 'abcd@msft.com' -Password 'pwd'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
AuthenticationType        :
ClientId                  : xxxxxxx-cdfd-4016-9e80-xxxxxxxx
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
Id                        :
IncludePersonalWorkspace  : True
Kind                      : PowerBIDelegated
LastModifiedAt            :
Name                      :
Password                  : pwd
Result                    :
ScanRulesetName           :
ScanRulesetType           :
Tenant                    :
UserName                  : abcd@msft.com
Worker                    :
```

Create PowerBI delegated scan object

