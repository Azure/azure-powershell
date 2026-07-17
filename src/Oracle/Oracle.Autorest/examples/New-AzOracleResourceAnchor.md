### Example 1: Create a Resource Anchor
```powershell
New-AzOracleResourceAnchor `
  -ResourceGroupName PowerShellTestRg `
  -Name OFake_PowerShellTestResourceAnchor `
  -Location eastus2 `
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
SystemDataLastModifiedAt                      : 05/07/2024 13:40:35
SystemDataLastModifiedBy                      : example@oracle.com
SystemDataLastModifiedByType                  : User
Tag                                           : {
                                                }
TimeCreated                                   : 05/07/2024 13:40:35
```

Creates a Resource Anchor in the specified resource group and location, linking it to an Autonomous Database. For more information, execute `Get-Help New-AzOracleResourceAnchor`.

### Example 2: Create a Resource Anchor with tags
```powershell
New-AzOracleResourceAnchor `
  -ResourceGroupName PowerShellTestRg `
  -Name OFake_PowerShellTestResourceAnchor `
  -Location eastus2 `
  -Tag @{ env="test"; owner="example@oracle.com" }
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

Creates a Resource Anchor and assigns tags. For more information, execute `Get-Help New-AzOracleResourceAnchor`.
