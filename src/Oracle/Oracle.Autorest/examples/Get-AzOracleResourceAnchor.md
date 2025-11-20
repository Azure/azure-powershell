### Example 1: Get a list of the Resource Anchor resources
```powershell
Get-AzOracleResourceAnchor
```

```output
...
Name                                          : OFake_PowerShellTestResourceAnchor
Id                                            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/resourceAnchors/OFake_PowerShellTestResourceAnchor
Type                                          : oracle.database/resourceanchors
Location                                      : eastus2
ResourceGroupName                             : PowerShellTestRg
OciUrl                                        : https://cloud.oracle.com/resource-anchors/ocid1.resourceanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example?region=us-ashbur
                                                n-1&tenant=orpsandbox3
Ocid                                          : ocid1.resourceanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example
LinkedResourceId                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/autonomousDatabases/OFakePowerShellTestAdbs
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

Get a Resource Anchor resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleResourceAnchor`.

### Example 2: Get a Resource Anchor by name and resource group name
```powershell
Get-AzOracleResourceAnchor -ResourceGroupName PowerShellTestRg -Name OFake_PowerShellTestResourceAnchor
```

```output
Name                                          : OFake_PowerShellTestResourceAnchor
Id                                            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/resourceAnchors/OFake_PowerShellTestResourceAnchor
Type                                          : oracle.database/resourceanchors
Location                                      : eastus2
ResourceGroupName                             : PowerShellTestRg
OciUrl                                        : https://cloud.oracle.com/resource-anchors/ocid1.resourceanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example?region=us-ashbur
                                                n-1&tenant=orpsandbox3
Ocid                                          : ocid1.resourceanchor.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuvm62example
LinkedResourceId                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/autonomousDatabases/OFakePowerShellTestAdbs
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

Gets a specific Resource Anchor resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleResourceAnchor`.
