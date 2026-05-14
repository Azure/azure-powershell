### Example 1: List all pending flows for a specific connection

```powershell
$pendingFlows = Get-AzDataTransferPendingFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01
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
FlowId                                 : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
FlowType                               : Mission
ForceDisabledStatus                    : 
Id                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection02/flows/Flow02
KeyVaultUri                            : 
LinkStatus                             : 
LinkedFlowId                           : 
Location                               : eastus
MessagingOptionBillingTier             : 
Name                                   : Flow02
Passphrase                             : 
Policy                                 : 
ProvisioningState                      : 
SchemaConnectionId                     : 
SchemaContent                          : 
SchemaDirection                        : 
SchemaId                               : 
SchemaName                             : 
SchemaStatus                           : 
SchemaType                             : 
SchemaUri                              : 
SelectedResourceId                     : 
ServiceBusQueueId                      : 
SourceAddressSourceAddresses           : 
Status                                 : 
StorageAccountId                       : 
StorageAccountName                     : 
StorageContainerName                   : 
StorageTableName                       : 
StreamId                               : 
StreamLatency                          : 
StreamProtocol                         : 
SubscriptionId                         : 00000000-0000-0000-0000-000000000000
SystemDataCreatedAt                    : 
SystemDataCreatedBy                    : 
SystemDataCreatedByType                : 
SystemDataLastModifiedAt               : 
SystemDataLastModifiedBy               : 
SystemDataLastModifiedByType           : 
Tag                                    : {}
Type                                   : microsoft.azuredatatransfer/connections/flows
```

This example lists all pending flows on send side for the receive side connection `Connection01` within the resource group `ResourceGroup01`.
