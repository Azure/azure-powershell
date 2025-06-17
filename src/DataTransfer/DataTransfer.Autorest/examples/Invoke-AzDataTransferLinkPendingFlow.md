### Example 1: Link a pending flow by ID
```powershell
$sendFlow = Get-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName SendConnection01 -FlowName SendFlow01
Invoke-AzDataTransferLinkPendingFlow -ResourceGroupName ResourceGroup02 -ConnectionName ReceiveConnection01 -FlowName ReceiveFlow01 -PendingFlowId $sendFlow.Id -StatusReason "Linking approved" -Confirm:$false
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
FlowId                                 : 00000000-0000-0000-0000-000000000000
FlowType                               : Mission
ForceDisabledStatus                    : 
Id                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup02/providers/Microsoft.AzureDataTransfer/connections/ReceiveConnection01/flows/ReceiveFlow01
IdentityPrincipalId                    : 
IdentityTenantId                       : 
IdentityType                           : None
IdentityUserAssignedIdentity           : {}
KeyVaultUri                            : 
LinkStatus                             : Linked
LinkedFlowId                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/SendConnection01/flows/SendFlow01
Location                               : eastus
MessagingOptionBillingTier             : 
Name                                   : ReceiveFlow01
Passphrase                             : 
PlanName                               : 
PlanProduct                            : 
PlanPromotionCode                      : 
PlanPublisher                          : 
PlanVersion                            : 
Policy                                 : 
ProvisioningState                      : Succeeded
ResourceGroupName                      : ResourceGroup02
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
StorageAccountName                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup03/providers/Microsoft.Storage/storageAccounts/test
StorageContainerName                   : test-container
StorageTableName                       : 
StreamId                               : 
StreamLatency                          : 
StreamProtocol                         : 
SystemDataCreatedAt                    : 5/30/2099 10:06:51 AM
SystemDataCreatedBy                    : test@test.com
SystemDataCreatedByType                : User
SystemDataLastModifiedAt               : 6/11/2099 6:07:36 AM
SystemDataLastModifiedBy               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType           : Application
Tag                                    : {
                                           "creationTime": "2099-05-30T10:06:48.5223272Z",
                                           "vteam": "Experience"
                                         }
Type                                   : microsoft.azuredatatransfer/connections/flows
```

This example links a pending send side flow with the naem `SendFlow01` to the receive side flow `ReceiveFlow01` in the connection `ReceiveConnection01` within the resource group `ResourceGroup02` and provides a status reason.
