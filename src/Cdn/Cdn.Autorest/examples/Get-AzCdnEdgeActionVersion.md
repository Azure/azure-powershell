### Example 1: List all Edge Action Versions
```powershell
Get-AzCdnEdgeActionVersion -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001"
```

```output
Name                      : v1
Id                        : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/versions/v1
Type                      : Microsoft.Cdn/edgeActions/versions
Location                  : global
ResourceGroupName         : testps-rg-da16jm
DeploymentType            : zip
IsDefaultVersion          : True
ProvisioningState         : Succeeded
ValidationStatus          : Succeeded
LastPackageUpdateTime     : 10/27/2025 10:30:45 AM

Name                      : v2
Id                        : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/versions/v2
Type                      : Microsoft.Cdn/edgeActions/versions
Location                  : global
ResourceGroupName         : testps-rg-da16jm
DeploymentType            : zip
IsDefaultVersion          : False
ProvisioningState         : Succeeded
ValidationStatus          : Succeeded
LastPackageUpdateTime     : 10/27/2025 11:15:30 AM
```

List all versions of the specified Edge Action

### Example 2: Get a specific Edge Action Version by name
```powershell
Get-AzCdnEdgeActionVersion -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001" -Version "v1"
```

```output
Name                      : v1
Id                        : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/versions/v1
Type                      : Microsoft.Cdn/edgeActions/versions
Location                  : global
ResourceGroupName         : testps-rg-da16jm
DeploymentType            : zip
IsDefaultVersion          : True
ProvisioningState         : Succeeded
ValidationStatus          : Succeeded
LastPackageUpdateTime     : 10/27/2025 10:30:45 AM
```

Get a specific Edge Action Version by name

