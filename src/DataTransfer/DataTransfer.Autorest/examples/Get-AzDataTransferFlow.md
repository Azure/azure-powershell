### Example 1: Get a specified flow
```powershell
Get-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01 -Name Flow01
```

```output
CustomerManagedKeyVaultUri         : 
DataType                           : Blob
DestinationEndpoint                : 
DestinationEndpointPort            : 
FlowId                             : 00000000-0000-0000-0000-000000000000
FlowType                           : Mission
Id                                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01/flows/Flow01
IdentityPrincipalId                : 
IdentityTenantId                   : 
IdentityType                       : None
IdentityUserAssignedIdentity       : {}
KeyVaultUri                        : 
LinkStatus                         : Linked
LinkedFlowId                       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup02/providers/Microsoft.AzureDataTransfer/connections/Connection02/flows/flow02
Location                           : westcentralus
MessagingOptionBillingTier         : 
Name                               : Flow01
Passphrase                         : 
PlanName                           : 
PlanProduct                        : 
PlanPromotionCode                  : 
PlanPublisher                      : 
PlanVersion                        : 
Policy                             : 
ProvisioningState                  : Succeeded
ResourceGroupName                  : ResourceGroup01
SchemaConnectionId                 : 
SchemaContent                      : 
SchemaDirection                    : 
SchemaId                           : 
SchemaName                         : 
SchemaStatus                       : 
SchemaType                         : 
SchemaUri                          : 
ServiceBusQueueId                  : 
SourceAddressList                  : 
Status                             : Enabled
StorageAccountId                   : 
StorageAccountName                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroupStorage/providers/Microsoft.Storage/storageAccounts/test
StorageContainerName               : test-container
StreamId                           : 
StreamLatency                      : 
StreamProtocol                     : 
SystemDataCreatedAt                : 
SystemDataCreatedBy                : 
SystemDataCreatedByType            : 
SystemDataLastModifiedAt           : 3/20/2025 11:25:07 AM
SystemDataLastModifiedBy           : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType       : Application
Tag                                : {}
Type                               : Microsoft.azuredatatransfer/connections/flows
```

This example retrieves a specific flow named `Flow01` in the connection `Connection01` within the resource group `ResourceGroup01`.

### Example 2: Get a list of flows in a connection
```powershell
Get-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01
```

```output
CustomerManagedKeyVaultUri         : 
DataType                           : Blob
DestinationEndpoint                : 
DestinationEndpointPort            : 
FlowId                             : 00000000-0000-0000-0000-000000000000
FlowType                           : Mission
Id                                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01/flows/Flow01
IdentityPrincipalId                : 
IdentityTenantId                   : 
IdentityType                       : None
IdentityUserAssignedIdentity       : {}
KeyVaultUri                        : 
LinkStatus                         : Linked
LinkedFlowId                       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup02/providers/Microsoft.AzureDataTransfer/connections/Connection02/flows/flow02
Location                           : westcentralus
MessagingOptionBillingTier         : 
Name                               : Flow01
Passphrase                         : 
PlanName                           : 
PlanProduct                        : 
PlanPromotionCode                  : 
PlanPublisher                      : 
PlanVersion                        : 
Policy                             : 
ProvisioningState                  : Succeeded
ResourceGroupName                  : ResourceGroup01
SchemaConnectionId                 : 
SchemaContent                      : 
SchemaDirection                    : 
SchemaId                           : 
SchemaName                         : 
SchemaStatus                       : 
SchemaType                         : 
SchemaUri                          : 
ServiceBusQueueId                  : 
SourceAddressList                  : 
Status                             : Enabled
StorageAccountId                   : 
StorageAccountName                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroupStorage/providers/Microsoft.Storage/storageAccounts/test
StorageContainerName               : test-container
StreamId                           : 
StreamLatency                      : 
StreamProtocol                     : 
SystemDataCreatedAt                : 
SystemDataCreatedBy                : 
SystemDataCreatedByType            : 
SystemDataLastModifiedAt           : 3/20/2025 11:25:07 AM
SystemDataLastModifiedBy           : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType       : Application
Tag                                : {}
Type                               : Microsoft.azuredatatransfer/connections/flows
```

This example retrieves all flows in the connection `Connection01` within the resource group `ResourceGroup01`.
