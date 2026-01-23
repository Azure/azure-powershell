### Example 1: Update a DisconnectedOperation by name and resource group
```powershell
Update-AzDisconnectedOperationsDisconnectedOperation -Name "Resource-1" -ResourceGroupName "ResourceGroup-1" -RegistrationStatus "Registered"
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
RegistrationStatus           : Registered
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

This command updates the DisconnectedOperation resource named `Resource-1` in the resource group `ResourceGroup-1` to set the registration status to `Registered` using expanded parameters.

### Example 2: Update a DisconnectedOperation by json file path
```powershell
Update-AzDisconnectedOperationsDisconnectedOperation -Name "Resource-1" -ResourceGroupName "ResourceGroup-1" -JsonFilePath "path/to/jsonFiles/UpdateDisconnectedOperations.json"
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
RegistrationStatus           : Registered
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
This command updates the DisconnectedOperation resource named `Resource-1` in the resource group `ResourceGroup-1` using the details provided in the specified JSON file.

### Example 3: Update a DisconnectedOperation by jsonString
```powershell
Update-AzDisconnectedOperationsDisconnectedOperation -Name "Resource-1" -ResourceGroupName "ResourceGroup-1" -JsonString '{"properties": {"registrationStatus": "Registered"}}'
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
RegistrationStatus           : Registered
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
This command updates the DisconnectedOperation resource named `Resource-1` in the resource group `ResourceGroup-1` using the details provided in the specified JSON string.

### Example 4: Update a DisconnectedOperation by identity
```powershell
$disconnectedOperation = @{
  "ResourceGroupName" = "ResourceGroup-1";
  "DisconnectedOperationName" = "Resource-1";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}

Update-AzDisconnectedOperationsDisconnectedOperation -InputObject $disconnectedOperation -RegistrationStatus "Registered"
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
RegistrationStatus           : Registered
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

This command updates the DisconnectedOperation resource identified by the provided identity to set the registration status to `Registered` using the InputObject and expanded parameters.