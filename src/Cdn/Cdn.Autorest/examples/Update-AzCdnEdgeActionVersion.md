### Example 1: Update Edge Action Version with expanded parameters
```powershell
Update-AzCdnEdgeActionVersion -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001" -Version "v1" -DeploymentType "zip" -IsDefaultVersion "False"
```

```output
Name                      : v1
Id                        : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/versions/v1
Type                      : Microsoft.Cdn/edgeActions/versions
Location                  : global
ResourceGroupName         : testps-rg-da16jm
DeploymentType            : zip
IsDefaultVersion          : False
ProvisioningState         : Succeeded
ValidationStatus          : Succeeded
LastPackageUpdateTime     : 10/27/2025 12:30:00 PM
```

Update an Edge Action Version with new configuration settings

