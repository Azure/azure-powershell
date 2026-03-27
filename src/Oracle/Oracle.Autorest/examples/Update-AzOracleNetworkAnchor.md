### Example 1: Update tags on a Network Anchor
```powershell
Update-AzOracleNetworkAnchor -ResourceGroupName PowerShellTestRg -Name OFake_owerShellTestNetworkAnchor -Tag @{ env="test"; owner="example@oracle.com" }
```

```output
Name                                          : OFake_owerShellTestNetworkAnchor
Id                                            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/networkAnchors/OFake_owerShellTestNetworkAnchor
Type                                          : oracle.database/networkanchors
Location                                      : eastus2
ResourceGroupName                             : PowerShellTestRg
OciUrl                                        : https://cloud.oracle.com/network-anchors/ocid1.networkanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example?region=us-ashbur
                                                n-1&tenant=orpsandbox3
Ocid                                          : ocid1.networkanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example
LinkedResourceId                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet
ProvisioningState                             : Succeeded
Property                                      : {
                                                  ...
                                                }
SystemDataCreatedAt                           : 05/07/2024 13:40:35
SystemDataCreatedBy                           : example@oracle.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 06/07/2024 09:19:26
SystemDataLastModifiedBy                      : 857ad006-4380-4712-ba4c-22f7c64d84e7
SystemDataLastModifiedByType                  : Application
Tag                                           : {
                                                  env=test
                                                  owner=example@oracle.com
                                                }
TimeCreated                                   : 05/07/2024 13:44:18
```

Updates the **tags** on an existing Network Anchor. For more information, execute `Get-Help Update-AzOracleNetworkAnchor`.

### Example 2: Partially update a Network Anchor property
```powershell
Update-AzOracleNetworkAnchor -ResourceGroupName PowerShellTestRg -Name OFake_owerShellTestNetworkAnchor
```

```output
Name                                          : OFake_owerShellTestNetworkAnchor
Id                                            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/networkAnchors/OFake_owerShellTestNetworkAnchor
Type                                          : oracle.database/networkanchors
Location                                      : eastus2
ResourceGroupName                             : PowerShellTestRg
OciUrl                                        : https://cloud.oracle.com/network-anchors/ocid1.networkanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example?region=us-ashbur
                                                n-1&tenant=orpsandbox3
Ocid                                          : ocid1.networkanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example
LinkedResourceId                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet
ProvisioningState                             : Succeeded
Property                                      : {
                                                  ...
                                                }
SystemDataCreatedAt                           : 05/07/2024 13:40:35
SystemDataCreatedBy                           : example@oracle.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 06/07/2024 09:19:26
SystemDataLastModifiedBy                      : 857ad006-4380-4712-ba4c-22f7c64d84e7
SystemDataLastModifiedByType                  : Application
Tag                                           : {
                                                  env=test
                                                  owner=example@oracle.com
                                                }
TimeCreated                                   : 05/07/2024 13:44:18
```

Performs a **partial update** (PATCH) of a Network Anchor to modify a property—in this case, `LinkedResourceId`. For more information, execute `Get-Help Update-AzOracleNetworkAnchor`.
