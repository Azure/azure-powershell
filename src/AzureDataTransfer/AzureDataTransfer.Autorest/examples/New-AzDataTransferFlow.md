### Example 1: Create a new flow with basic parameters
```powershell
New-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01 -Name Flow01 -Location "EastUS" -FlowType "Mission" -DataType "Blob" -StorageAccountName "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.Storage/storageAccounts/storageAccount01" -StorageContainerName "teststorage" -Confirm:$false
```

```output
CustomerManagedKeyVaultUri         : 
DataType                           : Blob
DestinationEndpoint                : 
DestinationEndpointPort            : 
FlowId                             : 
FlowType                           : Mission
Id                                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01/flows/flow01
IdentityPrincipalId                : 
IdentityTenantId                   : 
IdentityType                       : None
IdentityUserAssignedIdentity       : {}
KeyVaultUri                        : 
LinkStatus                         : Unlinked
LinkedFlowId                       : 
Location                           : EastUS
MessagingOptionBillingTier         : 
Name                               : flow01
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
StorageAccountName                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.Storage/storageAccounts/storageAccount01
StorageContainerName               : teststorage
StreamId                           : 
StreamLatency                      : 
StreamProtocol                     : 
SystemDataCreatedAt                : 
SystemDataCreatedBy                : 
SystemDataCreatedByType            : 
SystemDataLastModifiedAt           : 5/13/2025 11:23:19 AM
SystemDataLastModifiedBy           : test@example.com
SystemDataLastModifiedByType       : User
Tag                                : {}
Type                               : microsoft.azuredatatransfer/connections/flows
```


This example creates a new flow named `Flow01` in the connection `Connection01` within the resource group `ResourceGroup01` located in the `EastUS` region with basic parameters such as flow type, data type, StorageAccountName and StorageContainerName.

---

### Example 2: Create a new flow with additional parameters
```powershell
New-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01 -Name Flow01 -Location "EastUS" -FlowType "Mission" -DataType "Blob" -StorageAccountName "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.Storage/storageAccounts/storageAccount01" -StorageContainerName "teststorage" -Status Enabled -Tag @{Environment="Production"} -Confirm:$false
```

This example creates a new flow named `Flow01` in the connection `Connection01` within the resource group `ResourceGroup01` with additional parameters Status and resource tags.

---
