### Example 1: Get a list of the Network Anchor resources
```powershell
Get-AzOracleNetworkAnchor
```

```output
...
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
                                                }
TimeCreated                                   : 05/07/2024 13:44:18
```

Get a Network Anchor resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleNetworkAnchor`.

### Example 2: Get a Network Anchor by name and resource group name
```powershell
Get-AzOracleNetworkAnchor -ResourceGroupName PowerShellTestRg -Name OFake_owerShellTestNetworkAnchor
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
                                                }
TimeCreated                                   : 05/07/2024 13:44:18
```

Gets a specific Network Anchor resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleNetworkAnchor`.
