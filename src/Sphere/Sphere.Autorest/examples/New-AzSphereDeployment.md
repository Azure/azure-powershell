### Example 1: Create a deployment with deployed image
```powershell
$image1 = Get-AzSphereImage -Name '14a6729e-5819-4737-8713-37b4798533f8' -CatalogName test2024 -ResourceGroupName joyer-test
New-AzSphereDeployment -Name .default -CatalogName test2024 -DeviceGroupName testdevicegroup -ProductName product2024 -ResourceGroupName joyer-test -DeployedImage $image1
```

```output
DateUtc                      : 3/1/2024 8:08:11 AM
DeployedImage                : {{
                                 "id": "/subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/images/14a6729e-5819-4737 
                               -8713-37b4798533f8",
                                 "name": "14a6729e-5819-4737-8713-37b4798533f8",
                                 "type": "Microsoft.AzureSphere/catalogs/images",
                                 "properties": {
                                   "image": "AzureSphereBlink1",
                                   "imageId": "14a6729e-5819-4737-8713-37b4798533f8",
                                   "regionalDataBoundary": "None",
                                   "uri": "https://as3imgptint003.blob.core.windows.net/7de8a199-bb33-4eda-9600-583103317243/imagesaks/14a6729e-5819-4737-8713-37b4798533f8?skoid=cc6e3fcf-ab4d-4 
                               b0d-b3f9-9769604c1e52\u0026sktid=72f988bf-86f1-41af-91ab-2d7cd011db47\u0026skt=2024-03-01T08%3A03%3A45Z\u0026ske=2024-03-01T09%3A08%3A45Z\u0026sks=b\u0026skv=2021
                               -12-02\u0026sv=2021-12-02\u0026spr=https,http\u0026se=2024-03-01T16%3A08%3A45Z\u0026sr=b\u0026sp=r\u0026sig=UviBTlciImOjqw968crarXzXyQ29UMEi4js56AEOPgU%3D",       
                                   "componentId": "42257ad6-382d-405f-b7cc-e110fbda2d0b",
                                   "imageType": "Applications",
                                   "provisioningState": "Succeeded"
                                 }
                               }}
DeploymentId                 : e1e61a75-0629-491c-8f4f-0c054116d71c
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024/deviceGroups/ 
                               testdevicegroup/deployments/e1e61a75-0629-491c-8f4f-0c054116d71c
Name                         : e1e61a75-0629-491c-8f4f-0c054116d71c
ProvisioningState            : Succeeded
ResourceGroupName            : joyer-test
SystemDataCreatedAt          : 3/1/2024 8:08:11 AM
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 3/1/2024 8:08:11 AM
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups/deployments
```

This command create a deployment with deployed images.

