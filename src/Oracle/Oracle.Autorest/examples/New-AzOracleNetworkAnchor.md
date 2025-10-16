### Example 1: Create a Network Anchor
```powershell
New-AzOracleNetworkAnchor `
  -ResourceGroupName PowerShellTestRg `
  -Name OFake_owerShellTestNetworkAnchor `
  -Location eastus2 `
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
SystemDataLastModifiedAt                      : 05/07/2024 13:40:35
SystemDataLastModifiedBy                      : example@oracle.com
SystemDataLastModifiedByType                  : User
Tag                                           : {
                                                }
TimeCreated                                   : 05/07/2024 13:40:35
```

Creates a Network Anchor in the specified resource group and location, linking it to a virtual network. For more information, execute `Get-Help New-AzOracleNetworkAnchor`.

### Example 2: Create a Network Anchor with tags
```powershell
New-AzOracleNetworkAnchor `
  -ResourceGroupName PowerShellTestRg `
  -Name OFake_owerShellTestNetworkAnchor `
  -Location eastus2 `
  -Tag @{ env="test"; owner="example@oracle.com" }
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
SystemDataCreatedAt                           : 05/07/2024 13:42:10
SystemDataCreatedBy                           : example@oracle.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 05/07/2024 13:42:10
SystemDataLastModifiedBy                      : example@oracle.com
SystemDataLastModifiedByType                  : User
Tag                                           : {
                                                  env=test
                                                  owner=example@oracle.com
                                                }
TimeCreated                                   : 05/07/2024 13:42:10
```

Creates a Network Anchor and assigns tags. For more information, execute `Get-Help New-AzOracleNetworkAnchor`.
