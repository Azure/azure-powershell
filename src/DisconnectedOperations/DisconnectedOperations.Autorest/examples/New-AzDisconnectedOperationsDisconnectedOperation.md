### Example 1: Create a new DisconnectedOperation with expanded parameters
```powershell
New-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -ConnectionIntent "Disconnected" -BillingConfigurationAutoRenew "Disabled" -CurrentCore 8 -CurrentPricingModel "Annual" -BenefitPlanAzureHybridWindowsServerBenefit "Enabled" -BenefitPlanWindowsServerVMCount 10 -Location "eastus2euap" -Tag @{}
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
RegistrationStatus                         : Unregistered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 10:07:05
SystemDataCreatedBy                        : user1@outlook.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/02/2026 10:07:05
SystemDataLastModifiedBy                   : user1@outlook.com
SystemDataLastModifiedByType               : User
Tag                                        : {
                                             }
Type                                       : microsoft.edge/disconnectedoperations
UpcomingCore                               : 0
UpcomingEndDate                            :
UpcomingPricingModel                       :
UpcomingStartDate                          :
```

This command creates a new DisconnectedOperation resource named "winfield-ps-test" in the resource group "winfield-demo-rg-2" located in "eastus2euap" with expanded parameters.

### Example 2: Create a DisconnectedOperation using a JSON file path
```powershell
New-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -JsonFilePath "path/to/jsonFiles/CreateDisconnectedOperations.json"
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
RegistrationStatus                         : Unregistered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 10:07:05
SystemDataCreatedBy                        : user1@outlook.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/02/2026 10:07:05
SystemDataLastModifiedBy                   : user1@outlook.com
SystemDataLastModifiedByType               : User
Tag                                        : {
                                             }
Type                                       : microsoft.edge/disconnectedoperations
UpcomingCore                               : 0
UpcomingEndDate                            :
UpcomingPricingModel                       :
UpcomingStartDate                          :
```

This command creates a DisconnectedOperation resource using the configuration specified in the JSON file located at "path/to/jsonFiles/CreateDisconnectedOperations.json".

### Example 3: Create a DisconnectedOperation using a JSON string
```powershell
New-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test-2" -ResourceGroupName "winfield-demo-rg-2" -JsonString '{"properties":{"connectionIntent":"Disconnected","billingModel":"Capacity","billingConfiguration":{"autoRenew":"Disabled","current":{"cores":8,"pricingModel":"Annual"},"upcoming":{"cores":8,"pricingModel":"Annual"}},"benefitPlans":{"azureHybridWindowsServerBenefit":"Enabled","windowsServerVmCount":10}},"tags":{},"location":"eastus2euap"}'
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
Id                                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test-2
Location                                   : eastus2euap
Name                                       : winfield-ps-test-2
ProvisioningState                          : Succeeded
RegistrationStatus                         : Unregistered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 09:59:40
SystemDataCreatedBy                        : user1@outlook.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/02/2026 09:59:40
SystemDataLastModifiedBy                   : user1@outlook.com
SystemDataLastModifiedByType               : User
Tag                                        : {
                                             }
Type                                       : microsoft.edge/disconnectedoperations
UpcomingCore                               : 8
UpcomingEndDate                            : 03/01/2028 00:00:00
UpcomingPricingModel                       : Annual
UpcomingStartDate                          : 03/02/2027 00:00:00
```

This command creates a DisconnectedOperation resource using the configuration specified in the provided JSON string.