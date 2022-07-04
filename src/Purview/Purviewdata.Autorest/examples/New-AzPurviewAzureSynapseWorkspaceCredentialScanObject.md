### Example 1: Create Azure Synapse Workspace Credential scan object
```powershell
New-AzPurviewAzureSynapseWorkspaceCredentialScanObject -Kind 'AzureSynapseWorkspaceCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialType 'ServicePrincipal' -CredentialReferenceName 'svcp' -ScanRulesetName 'AzureSynapseSQL' -ScanRulesetType 'System'
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
Kind                      : AzureSynapseWorkspaceCredential
LastModifiedAt            :
Name                      :
ResourceType              : {
                            }
Result                    :
ScanRulesetName           : AzureSynapseSQL
ScanRulesetType           : System
Worker                    :
```

Create Azure Synapse Workspace Credential scan object

