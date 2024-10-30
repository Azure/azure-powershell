
### Example 1: Create a new De-identification Service resource
```powershell
New-AzDeidService -Name myHealthDeidService -ResourceGroupName azpwsh-test-rg -Location eastus2 -EnableSystemAssignedIdentity -PublicNetworkAccess "Disabled"
```

```output
Id                           : /subscriptions/a49b70b4-60ee-4422-a7e2-3a5223f5fae4/resourceGroups/azpwsh-test-rg/providers/Microsoft.HealthDataAIServices/deidServices/myHealthDeidService
IdentityPrincipalId          : efab95dd-6969-4c43-bd96-4126dc372bfa
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus2
Name                         : myHealthDeidService
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          : Disabled
ResourceGroupName            : azpwsh-test-rg
ServiceUrl                   : https://h8bxaqamerbxd9a7.api.eus2001.deid.azure.com
SystemDataCreatedAt          : 10/21/2024 5:26:15 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/21/2024 5:26:15 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.healthdataaiservices/deidservices
```

Creates a new De-identification Service resource in the specified resource group and location.

### Example 2: Create a new De-identification Service resource from a JSON file
```powershell
New-AzDeidService -Name myHealthDeidService -ResourceGroupName azpwsh-test-rg -JsonFilePath path/to/json.json
```

```output
Id                           : /subscriptions/a49b70b4-60ee-4422-a7e2-3a5223f5fae4/resourceGroups/azpwsh-test-rg/providers/Microsoft.HealthDataAIServices/deidServices/myHealthDeidService
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus2
Name                         : myHealthDeidService
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          : Disabled
ResourceGroupName            : azpwsh-test-rg
ServiceUrl                   : https://h8bxaqamerbxd9a7.api.eus2001.deid.azure.com
SystemDataCreatedAt          : 10/21/2024 5:26:15 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/21/2024 5:26:15 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.healthdataaiservices/deidservices
```

Creates a new De-identification Service resource with location and properties specified in the JSON file.