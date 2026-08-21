### Example 1: List all DisconnectedOperations resources in the current subscription
```powershell
Get-AzDisconnectedOperationsDisconnectedOperation
```

```output
Location    Name                    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
--------    ----                    ------------------- -------------------     ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus2euap "Resource-1"            07/16/2025 00:04:48 user1@outlook.com       User                    07/16/2025 00:04:48      user1@outlook.com                    User                         ResourceGroup-1
West US 3   "Resource-2"            05/19/2025 21:23:25 user1@outlook.com       User                    05/20/2025 06:09:56      user2@outlook.com9                   User                         ResourceGroup-2
westus3     "Resource-3"            07/22/2025 20:08:35 user2@outlook.com       User                    07/22/2025 20:08:35      user1@outlook.com                    User                         ResourceGroup-1
```

This command lists all the DisconnectedOperations resources in the current subscription.

### Example 2: Get a specific DisconnectedOperation by name and resource group
```powershell
Get-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2"
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

This command retrieves a specific DisconnectedOperation resource by its name and resource group.


### Example 3: GetViaIdentity for a specific DisconnectedOperation
```powershell
$disconnectedOperation = @{
  "ResourceGroupName" = "winfield-demo-rg-2";
  "Name" = "winfield-ps-test";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsDisconnectedOperation -InputObject $disconnectedOperation
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

### Example 4: List all DisconnectedOperations from a specific resource group
```powershell
Get-AzDisconnectedOperationsDisconnectedOperation -ResourceGroupName "ResourceGroup-1"
```

```output
Location    Name                    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
--------    ----                    ------------------- -------------------     ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus2euap "Resource-1"            07/16/2025 00:04:48 user1@outlook.com       User                    07/16/2025 00:04:48      user1@outlook.com                    User                         ResourceGroup-1
westus3     "Resource-3"            07/22/2025 20:08:35 user2@outlook.com       User                    07/22/2025 20:08:35      user1@outlook.com                    User                         ResourceGroup-1
```

This command lists all the DisconnectedOperations resources from the resource group `ResourceGroup-1`.