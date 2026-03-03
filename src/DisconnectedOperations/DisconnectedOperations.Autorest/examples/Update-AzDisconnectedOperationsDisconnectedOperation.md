### Example 1: Update a DisconnectedOperation by name and resource group
```powershell
Update-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -RegistrationStatus "Registered"
```

```output
BenefitPlanAzureHybridWindowsServerBenefit : Enabled
BenefitPlanWindowsServerVMCount            : 10
BillingConfigurationAutoRenew              : Disabled
BillingConfigurationBillingStatus          : Enabled
BillingModel                               : Capacity
ConnectionIntent                           : Disconnected
ConnectionStatus                           : Disconnected
CurrentCore                                : 8
CurrentEndDate                             : 03/01/2027 00:00:00
CurrentPricingModel                        : Annual
CurrentStartDate                           : 03/02/2026 00:00:00
DeviceVersion                              :
Id                                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test
Location                                   : eastus2euap
Name                                       : winfield-ps-test
ProvisioningState                          : Succeeded
RegistrationStatus                         : Registered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 10:07:05
SystemDataCreatedBy                        : aviranjan@microsoft.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/03/2026 09:21:10
SystemDataLastModifiedBy                   : aviranjan@microsoft.com
SystemDataLastModifiedByType               : User
Tag                                        : {
                                             }
Type                                       : microsoft.edge/disconnectedoperations
UpcomingCore                               : 0
UpcomingEndDate                            :
UpcomingPricingModel                       :
UpcomingStartDate                          :
```

This command updates the DisconnectedOperation resource named `winfield-ps-test` in the resource group `winfield-demo-rg-2` to set the registration status to `Registered` using expanded parameters.

### Example 2: Update a DisconnectedOperation by json file path
```powershell
Update-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -JsonFilePath "path/to/jsonFiles/UpdateDisconnectedOperations.json"
```

```output
BenefitPlanAzureHybridWindowsServerBenefit : Enabled
BenefitPlanWindowsServerVMCount            : 10
BillingConfigurationAutoRenew              : Disabled
BillingConfigurationBillingStatus          : Enabled
BillingModel                               : Capacity
ConnectionIntent                           : Disconnected
ConnectionStatus                           : Disconnected
CurrentCore                                : 8
CurrentEndDate                             : 03/01/2027 00:00:00
CurrentPricingModel                        : Annual
CurrentStartDate                           : 03/02/2026 00:00:00
DeviceVersion                              :
Id                                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test
Location                                   : eastus2euap
Name                                       : winfield-ps-test
ProvisioningState                          : Succeeded
RegistrationStatus                         : Registered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 10:07:05
SystemDataCreatedBy                        : aviranjan@microsoft.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/03/2026 09:21:10
SystemDataLastModifiedBy                   : aviranjan@microsoft.com
SystemDataLastModifiedByType               : User
Tag                                        : {
                                             }
Type                                       : microsoft.edge/disconnectedoperations
UpcomingCore                               : 0
UpcomingEndDate                            :
UpcomingPricingModel                       :
UpcomingStartDate                          :
```

This command updates the DisconnectedOperation resource named `winfield-ps-test` in the resource group `winfield-demo-rg-2` using the details provided in the specified JSON file.

### Example 3: Update a DisconnectedOperation by jsonString
```powershell
Update-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -JsonString '{"properties": {"registrationStatus": "Registered"}}'
```

```output
BenefitPlanAzureHybridWindowsServerBenefit : Enabled
BenefitPlanWindowsServerVMCount            : 10
BillingConfigurationAutoRenew              : Disabled
BillingConfigurationBillingStatus          : Enabled
BillingModel                               : Capacity
ConnectionIntent                           : Disconnected
ConnectionStatus                           : Disconnected
CurrentCore                                : 8
CurrentEndDate                             : 03/01/2027 00:00:00
CurrentPricingModel                        : Annual
CurrentStartDate                           : 03/02/2026 00:00:00
DeviceVersion                              :
Id                                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test
Location                                   : eastus2euap
Name                                       : winfield-ps-test
ProvisioningState                          : Succeeded
RegistrationStatus                         : Registered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 10:07:05
SystemDataCreatedBy                        : aviranjan@microsoft.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/03/2026 09:21:10
SystemDataLastModifiedBy                   : aviranjan@microsoft.com
SystemDataLastModifiedByType               : User
Tag                                        : {
                                             }
Type                                       : microsoft.edge/disconnectedoperations
UpcomingCore                               : 0
UpcomingEndDate                            :
UpcomingPricingModel                       :
UpcomingStartDate                          :
```

This command updates the DisconnectedOperation resource named `winfield-ps-test` in the resource group `winfield-demo-rg-2` using the details provided in the specified JSON string.

### Example 4: Update a DisconnectedOperation by identity
```powershell
$disconnectedOperation = @{
  "ResourceGroupName" = "winfield-demo-rg-2";
  "DisconnectedOperationName" = "winfield-ps-test";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}

Update-AzDisconnectedOperationsDisconnectedOperation -InputObject $disconnectedOperation -RegistrationStatus "Registered"
```

```output
BenefitPlanAzureHybridWindowsServerBenefit : Enabled
BenefitPlanWindowsServerVMCount            : 10
BillingConfigurationAutoRenew              : Disabled
BillingConfigurationBillingStatus          : Enabled
BillingModel                               : Capacity
ConnectionIntent                           : Disconnected
ConnectionStatus                           : Disconnected
CurrentCore                                : 8
CurrentEndDate                             : 03/01/2027 00:00:00
CurrentPricingModel                        : Annual
CurrentStartDate                           : 03/02/2026 00:00:00
DeviceVersion                              :
Id                                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test
Location                                   : eastus2euap
Name                                       : winfield-ps-test
ProvisioningState                          : Succeeded
RegistrationStatus                         : Registered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 10:07:05
SystemDataCreatedBy                        : aviranjan@microsoft.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/03/2026 09:21:10
SystemDataLastModifiedBy                   : aviranjan@microsoft.com
SystemDataLastModifiedByType               : User
Tag                                        : {
                                             }
Type                                       : microsoft.edge/disconnectedoperations
UpcomingCore                               : 0
UpcomingEndDate                            :
UpcomingPricingModel                       :
UpcomingStartDate                          :
```

This command updates the DisconnectedOperation resource identified by the provided identity to set the registration status to `Registered` using the InputObject and expanded parameters.