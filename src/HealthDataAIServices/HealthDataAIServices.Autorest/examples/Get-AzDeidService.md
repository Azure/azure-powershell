### Example 1: Get a De-identification Service resource by name
```powershell
Get-AzDeidService -Name azpwshDeidService1 -ResourceGroupName azpwsh-test-rg
```

```output
Id                           : /subscriptions/a49b70b4-60ee-4422-a7e2-3a5223f5fae4/resourceGroups/azpwsh-test-rg/providers/Microsoft.HealthDataAIServices/DeidServices/azpwshDeidService1
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus2
Name                         : azpwshDeidService1
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : azpwsh-test-rg
ServiceUrl                   : https://vebsefg7b9cackat.api.eus2001.deid.azure.com
SystemDataCreatedAt          : 10/21/2024 12:00:35 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/21/2024 12:00:35 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.healthdataaiservices/deidservices
```

Gets a De-identification Service by its name and the resource group it belongs to.

### Example 2: List all De-identification Service resources in a resource group
```powershell
Get-AzDeidService -ResourceGroupName azpwsh-test-rg
```

```output
Location Name               SystemDataCreatedAt    SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----               -------------------    -------------------     ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus2  azpwshDeidService1 10/21/2024 12:00:35 AM contoso@microsoft.com User                    10/21/2024 12:00:35 AM   contoso@microsoft.com  User                         azpwsh-test-rg
eastus2  azpwshDeidService2 10/21/2024 12:01:06 AM contoso@microsoft.com User                    10/21/2024 12:01:06 AM   contoso@microsoft.com  User                         azpwsh-test-rg
```

Lists all De-identification Service resources in the specified resource group.