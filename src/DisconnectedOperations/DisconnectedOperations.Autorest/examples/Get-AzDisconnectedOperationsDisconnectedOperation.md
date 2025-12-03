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
Get-AzDisconnectedOperationsDisconnectedOperation -Name "Resource-1" -ResourceGroupName "ResourceGroup-1"
```

```output
BillingModel                 : Capacity
ConnectionIntent             : Disconnected
ConnectionStatus             : Disconnected
DeviceVersion                :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedoperations/Resource-1
Location                     : EastUS2EUAP
Name                         : Resource-1
ProvisioningState            : Succeeded
RegistrationStatus           : Unregistered
ResourceGroupName            : ResourceGroup-1
StampId                      : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt          : 05/19/2025 21:23:25
SystemDataCreatedBy          : user1@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 05/20/2025 06:09:56
SystemDataLastModifiedBy     : user1@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.edge/disconnectedoperations
```

This command retrieves a specific DisconnectedOperation resource by its name and resource group.


### Example 3: GetViaIdentity for a specific DisconnectedOperation
```powershell
$disconnectedOperation = @{
  "ResourceGroupName" = "ResourceGroup-1";
  "DisconnectedOperationName" = "Resource-1";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsDisconnectedOperation -InputObject $disconnectedOperation
```

```output
BillingModel                 : Capacity
ConnectionIntent             : Disconnected
ConnectionStatus             : Disconnected
DeviceVersion                :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedoperations/Resource-1
Location                     : EastUS2EUAP
Name                         : Resource-1
ProvisioningState            : Succeeded
RegistrationStatus           : Unregistered
ResourceGroupName            : ResourceGroup-1
StampId                      : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt          : 05/19/2025 21:23:25
SystemDataCreatedBy          : user1@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 05/20/2025 06:09:56
SystemDataLastModifiedBy     : user1@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.edge/disconnectedoperations
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