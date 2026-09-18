---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/get-azdatatransferflow
schema: 2.0.0
---

# Get-AzDataTransferFlow

## SYNOPSIS
Gets flow resource.

## SYNTAX

### List (Default)
```
Get-AzDataTransferFlow -ConnectionName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDataTransferFlow -ConnectionName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataTransferFlow -InputObject <IDataTransferIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityConnection
```
Get-AzDataTransferFlow -ConnectionInputObject <IDataTransferIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets flow resource.

## EXAMPLES

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

## PARAMETERS

### -ConnectionInputObject
Identity Parameter

```yaml
Type: ADT.Models.IDataTransferIdentity
Parameter Sets: GetViaIdentityConnection
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectionName
The name for the connection to perform the operation on.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: ADT.Models.IDataTransferIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name for the flow to perform the operation on.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityConnection
Aliases: FlowName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### ADT.Models.IDataTransferIdentity

## OUTPUTS

### ADT.Models.IFlow

## NOTES

## RELATED LINKS

