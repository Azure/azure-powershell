---
external help file: Az.DataTransfer-help.xml
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/get-azdatatransferpendingflow
schema: 2.0.0
---

# Get-AzDataTransferPendingFlow

## SYNOPSIS
Lists all remote flows that have not yet been linked to local flows

## SYNTAX

```
Get-AzDataTransferPendingFlow -ConnectionName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Lists all remote flows that have not yet been linked to local flows

## EXAMPLES

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

## PARAMETERS

### -ConnectionName
The name for the connection to perform the operation on.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### ADT.Models.IPendingFlow

## NOTES

## RELATED LINKS
