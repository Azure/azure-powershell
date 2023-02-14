### Example 1: Create/Update a resource type registration.
```powershell
<<<<<<< HEAD
New-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -RoutingType "Default" -Regionality "Regional" -Endpoint @{ApiVersion = "2021-01-01-preview"; Location = "West US 2", "East US 2 EUAP"; RequiredFeature = "Microsoft.Contoso/SampleApp" } -SwaggerSpecification @{ApiVersion = "2021-01-01-preview"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" } -EnableAsyncOperation
```

```output
=======
PS C:\> New-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -RoutingType "Default" -Regionality "Regional" -Endpoint @{ApiVersion = "2021-01-01-preview"; Location = "West US 2", "East US 2 EUAP"; RequiredFeature = "Microsoft.Contoso/SampleApp" } -SwaggerSpecification @{ApiVersion = "2021-01-01-preview"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" } -EnableAsyncOperation

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                  Type
----                  ----
testResourceType      Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
```

Create/Update a resource type registration.

### Example 2: Create/Update a nested resource type registration.
```powershell
<<<<<<< HEAD
New-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -RoutingType "Default" -Regionality "Global" -Endpoint @{ApiVersion = "2021-01-01-preview"; Location = ""; RequiredFeature = "Microsoft.Contoso/SampleApp" } -SwaggerSpecification @{ApiVersion = "2021-01-01-preview"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" }
```

```output
=======
PS C:\> New-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -RoutingType "Default" -Regionality "Global" -Endpoint @{ApiVersion = "2021-01-01-preview"; Location = ""; RequiredFeature = "Microsoft.Contoso/SampleApp" } -SwaggerSpecification @{ApiVersion = "2021-01-01-preview"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" }

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                                     Type
----                                     ----
testResourceType/nestedResourceType      Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
```

Create/Update a nested resource type registration.
