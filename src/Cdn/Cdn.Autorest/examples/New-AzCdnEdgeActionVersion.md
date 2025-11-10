### Example 1: Create a new Edge Action Version
```powershell
New-AzCdnEdgeActionVersion -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001" -Version "v1" -Location "global" -DeploymentType "zip" -IsDefaultVersion "True"
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
LastPackageUpdateTime     : 10/27/2025 12:00:00 PM
```

Create a new Edge Action Version under the specified Edge Action