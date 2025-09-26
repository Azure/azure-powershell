### Example 1: Create a new flow with basic parameters
```powershell
New-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01 -Name Flow01 -Location "EastUS" -FlowType "Mission" -DataType "Blob" -StorageAccountName "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.Storage/storageAccounts/storageAccount01" -StorageContainerName "teststorage" -Confirm:$false
```

```output
ApiFlowOptionApiMode                   : 
ApiFlowOptionAudienceOverride          : 
ApiFlowOptionCname                     : 
ApiFlowOptionIdentityTranslation       : 
ApiFlowOptionRemoteCallingModeClientId : 
ApiFlowOptionRemoteEndpoint            : 
ApiFlowOptionSenderClientId            : 
ConnectionId                           : 
ConnectionLocation                     : 
ConnectionName                         : 
ConnectionSubscriptionName             : 
ConsumerGroup                          : 
CustomerManagedKeyVaultUri             : 
DataType                               : Blob
DestinationEndpoint                    : 
DestinationEndpointPort                : 
EventHubId                             : 
FlowId                                 : 
FlowType                               : Mission
ForceDisabledStatus                    : 
Id                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01/flows/Flow01
IdentityPrincipalId                    : 
IdentityTenantId                       : 
IdentityType                           : None
IdentityUserAssignedIdentity           : {}
KeyVaultUri                            : 
LinkStatus                             : Unlinked
LinkedFlowId                           : 
Location                               : EastUS
MessagingOptionBillingTier             : 
Name                                   : Flow01
Passphrase                             : 
PlanName                               : 
PlanProduct                            : 
PlanPromotionCode                      : 
PlanPublisher                          : 
PlanVersion                            : 
Policy                                 : 
ProvisioningState                      : Succeeded
ResourceGroupName                      : ResourceGroup01
SchemaConnectionId                     : 
SchemaContent                          : 
SchemaDirection                        : 
SchemaId                               : 
SchemaName                             : 
SchemaStatus                           : 
SchemaType                             : 
SchemaUri                              : 
ServiceBusQueueId                      : 
SourceAddressSourceAddresses           : 
Status                                 : Enabled
StorageAccountId                       : 
StorageAccountName                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.Storage/storageAccounts/storageAccount01
StorageContainerName                   : teststorage
StorageTableName                       : 
StreamId                               : 
StreamLatency                          : 
StreamProtocol                         : 
SystemDataCreatedAt                    : 6/11/2099 7:09:52 AM
SystemDataCreatedBy                    : test@test.com
SystemDataCreatedByType                : User
SystemDataLastModifiedAt               : 6/11/2099 7:09:52 AM
SystemDataLastModifiedBy               : test@test.com
SystemDataLastModifiedByType           : User
Tag                                    : {
                                           "creationTime": "2099-06-11T07:09:49.5571186Z",
                                           "vteam": "Experience"
                                         }
Type                                   : microsoft.azuredatatransfer/connections/flows
```

This example creates a new flow named `Flow01` in the connection `Connection01` within the resource group `ResourceGroup01` located in the `EastUS` region with basic parameters such as flow type, data type, StorageAccountName and StorageContainerName.

### Example 2: Create a new flow with additional parameters
```powershell
New-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01 -Name Flow01 -Location "EastUS" -FlowType "Mission" -DataType "Blob" -StorageAccountName "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.Storage/storageAccounts/storageAccount01" -StorageContainerName "teststorage" -Status Enabled -Tag @{Environment="Production"} -Confirm:$false
```

```output
ApiFlowOptionApiMode                   : 
ApiFlowOptionAudienceOverride          : 
ApiFlowOptionCname                     : 
ApiFlowOptionIdentityTranslation       : 
ApiFlowOptionRemoteCallingModeClientId : 
ApiFlowOptionRemoteEndpoint            : 
ApiFlowOptionSenderClientId            : 
ConnectionId                           : 
ConnectionLocation                     : 
ConnectionName                         : 
ConnectionSubscriptionName             : 
ConsumerGroup                          : 
CustomerManagedKeyVaultUri             : 
DataType                               : Blob
DestinationEndpoint                    : 
DestinationEndpointPort                : 
EventHubId                             : 
FlowId                                 : 
FlowType                               : Mission
ForceDisabledStatus                    : 
Id                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01/flows/Flow01
IdentityPrincipalId                    : 
IdentityTenantId                       : 
IdentityType                           : None
IdentityUserAssignedIdentity           : {}
KeyVaultUri                            : 
LinkStatus                             : Unlinked
LinkedFlowId                           : 
Location                               : EastUS
MessagingOptionBillingTier             : 
Name                                   : Flow01
Passphrase                             : 
PlanName                               : 
PlanProduct                            : 
PlanPromotionCode                      : 
PlanPublisher                          : 
PlanVersion                            : 
Policy                                 : 
ProvisioningState                      : Succeeded
ResourceGroupName                      : ResourceGroup01
SchemaConnectionId                     : 
SchemaContent                          : 
SchemaDirection                        : 
SchemaId                               : 
SchemaName                             : 
SchemaStatus                           : 
SchemaType                             : 
SchemaUri                              : 
ServiceBusQueueId                      : 
SourceAddressSourceAddresses           : 
Status                                 : Enabled
StorageAccountId                       : 
StorageAccountName                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.Storage/storageAccounts/storageAccount01
StorageContainerName                   : teststorage
StorageTableName                       : 
StreamId                               : 
StreamLatency                          : 
StreamProtocol                         : 
SystemDataCreatedAt                    : 6/11/2099 7:09:52 AM
SystemDataCreatedBy                    : test@test.com
SystemDataCreatedByType                : User
SystemDataLastModifiedAt               : 6/11/2099 7:09:52 AM
SystemDataLastModifiedBy               : test@test.com
SystemDataLastModifiedByType           : User
Tag                                    : {
                                           "Environment": "Production",
                                           "creationTime": "2099-06-11T07:14:45.0294500Z",
                                           "vteam": "Experience"
                                         }
Type                                   : microsoft.azuredatatransfer/connections/flows
```

This example creates a new flow named `Flow01` in the connection `Connection01` within the resource group `ResourceGroup01` with additional parameters Status and resource tags.

### Example 3: Create a new flow using FlowProfile parameters
```powershell
New-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName BasicReceiveConnection01 -Name BasicRecvBlobFiles01 -Location "CentralUS" -Status "Enabled" -FlowDataType "Blob" -FlowProfilePipeline "Pipeline01" -FlowProfileName "BasicFlowProfile01" -FlowProfileReplicationScenario "Files" -FlowProfileStatus "Enabled" -FlowProfileId "000000000000-0000-0000-00000000" -FlowProfileDescription "Basic flow profile for file replication" -Confirm:$false
```

```output
ApiFlowOptionApiMode                   : 
ApiFlowOptionAudienceOverride          : 
ApiFlowOptionCname                     : 
ApiFlowOptionIdentityTranslation       : 
ApiFlowOptionRemoteCallingModeClientId : 
ApiFlowOptionRemoteEndpoint            : 
ApiFlowOptionSenderClientId            : 
ConnectionId                           : 
ConnectionLocation                     : 
ConnectionName                         : BasicReceiveConnection01
ConnectionSubscriptionName             : 
ConsumerGroup                          : 
CustomerManagedKeyVaultUri             : 
DataType                               : 
DestinationEndpoint                    : 
DestinationEndpointPort                : 
EventHubId                             : 
FlowId                                 : 
FlowType                               : 
ForceDisabledStatus                    : 
Id                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/BasicReceiveConnection01/flows/BasicRecvBlobFiles01
IdentityPrincipalId                    : 
IdentityTenantId                       : 
IdentityType                           : None
IdentityUserAssignedIdentity           : {}
KeyVaultUri                            : 
LinkStatus                             : Unlinked
LinkedFlowId                           : 
Location                               : CentralUS
MessagingOptionBillingTier             : 
Name                                   : BasicRecvBlobFiles01
Passphrase                             : 
PlanName                               : 
PlanProduct                            : 
PlanPromotionCode                      : 
PlanPublisher                          : 
PlanVersion                            : 
Policy                                 : 
ProvisioningState                      : Succeeded
ResourceGroupName                      : ResourceGroup01
SchemaConnectionId                     : 
SchemaContent                          : 
SchemaDirection                        : 
SchemaId                               : 
SchemaName                             : 
SchemaStatus                           : 
SchemaType                             : 
SchemaUri                              : 
ServiceBusQueueId                      : 
SourceAddressSourceAddresses           : 
Status                                 : Enabled
StorageAccountId                       : 
StorageAccountName                     : 
StorageContainerName                   : 
StorageTableName                       : 
StreamId                               : 
StreamLatency                          : 
StreamProtocol                         : 
SystemDataCreatedAt                    : 6/11/2099 7:15:30 AM
SystemDataCreatedBy                    : test@test.com
SystemDataCreatedByType                : User
SystemDataLastModifiedAt               : 6/11/2099 7:15:30 AM
SystemDataLastModifiedBy               : test@test.com
SystemDataLastModifiedByType           : User
Tag                                    : {
                                           "creationTime": "2099-06-11T07:15:27.2345678Z",
                                           "vteam": "Experience"
                                         }
Type                                   : microsoft.azuredatatransfer/connections/flows
```

This example creates a new flow named `BasicRecvBlobFiles01` using FlowProfile parameters. The flow is created on a basic receive connection and uses an existing FlowProfile for file replication scenario. FlowProfile parameters allow for standardized flow configuration and reuse of predefined flow settings.
