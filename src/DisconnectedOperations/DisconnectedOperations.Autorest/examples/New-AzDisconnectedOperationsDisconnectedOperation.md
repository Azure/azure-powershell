### Example 1: Create a new DisconnectedOperation with expanded parameters
```powershell
New-AzDisconnectedOperationsDisconnectedOperation -Name "Resource-1" -ResourceGroupName "ResourceGroup-1" -Location "westus3" -ConnectionIntent "Disconnected" -Tag @{}
```

```output
BillingModel                 : Capacity
ConnectionIntent             : Disconnected
ConnectionStatus             : Disconnected
DeviceVersion                :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedoperations/Resource-1
Location                     : WestUS3
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

This command creates a new DisconnectedOperation resource named "Resource-1" in the resource group "ResourceGroup-1" located in "westus3" with the connection intent set to "Disconnected" and no tags.

### Example 2: Create a DisconnectedOperation using a JSON file path
```powershell
New-AzDisconnectedOperationsDisconnectedOperation -Name "Resource-1" -ResourceGroupName "ResourceGroup-1" -JsonFilePath "path/to/jsonFiles/CreateDisconnectedOperations.json"
```

```output
BillingModel                 : Capacity
ConnectionIntent             : Disconnected
ConnectionStatus             : Disconnected
DeviceVersion                :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedoperations/Resource-1
Location                     : WestUS3
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

This command creates a DisconnectedOperation resource using the configuration specified in the JSON file located at "path/to/jsonFiles/CreateDisconnectedOperations.json".

### Example 3: Create a DisconnectedOperation using a JSON string
```powershell
New-AzDisconnectedOperationsDisconnectedOperation -Name "Resource-1" -ResourceGroupName "ResourceGroup-1" -JsonString '{"properties":{"connectionIntent":"Disconnected","billingModel":"Capacity"},"tags":{},"location":"westus3"}'
```

```output
BillingModel                 : Capacity
ConnectionIntent             : Disconnected
ConnectionStatus             : Disconnected
DeviceVersion                :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedoperations/Resource-1
Location                     : WestUS3
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

This command creates a DisconnectedOperation resource using the configuration specified in the provided JSON string.