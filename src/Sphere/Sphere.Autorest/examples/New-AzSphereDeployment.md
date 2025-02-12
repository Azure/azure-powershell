### Example 1: Create a deployment with deployed image
```powershell
$image1 = Get-AzSphereImage -Name '14a6729e-5819-4737-8713-37b4798533f8' -CatalogName test2024 -ResourceGroupName group-test
New-AzSphereDeployment -Name .default -CatalogName test2024 -DeviceGroupName testdevicegroup -ProductName product2024 -ResourceGroupName group-test -DeployedImage $image1
```

```output
DateUtc                      : 3/1/2024 8:08:11 AM
DeployedImage                : {{
                                 "id": "/subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024/images/14a6729e-5819-4737 
                               -8713-37b4798533f8",
                                 "name": "14a6729e-5819-4737-8713-37b4798533f8",
                                 "type": "Microsoft.AzureSphere/catalogs/images",
                                 "properties": {
                                   "image": "AzureSphereBlink1",
                                   "imageId": "14a6729e-5819-4737-8713-37b4798533f8",
                                   "regionalDataBoundary": "None",
                                   "uri": "****************",       
                                   "componentId": "42257ad6-382d-405f-b7cc-e110fbda2d0b",
                                   "imageType": "Applications",
                                   "provisioningState": "Succeeded"
                                 }
                               }}
DeploymentId                 : 11111111-2222-3333-4444-123456789107
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024/deviceGroups/testdevicegroup/deployments/11111111-2222-3333-4444-123456789107
Name                         : 11111111-2222-3333-4444-123456789107
ProvisioningState            : Succeeded
ResourceGroupName            : group-test
SystemDataCreatedAt          : 3/1/2024 8:08:11 AM
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 3/1/2024 8:08:11 AM
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups/deployments
```

This command create a deployment with deployed images.

