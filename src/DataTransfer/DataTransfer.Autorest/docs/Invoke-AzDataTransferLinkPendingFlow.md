---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/invoke-azdatatransferlinkpendingflow
schema: 2.0.0
---

# Invoke-AzDataTransferLinkPendingFlow

## SYNOPSIS
Links the specified flow.

## SYNTAX

### LinkExpanded (Default)
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionName <String> -FlowName <String> -ResourceGroupName <String>
 -PendingFlowId <String> [-SubscriptionId <String>] [-StatusReason <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Link
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionName <String> -FlowName <String> -ResourceGroupName <String>
 -Flow <IResourceBody> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### LinkViaIdentity
```
Invoke-AzDataTransferLinkPendingFlow -InputObject <IDataTransferIdentity> -Flow <IResourceBody>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### LinkViaIdentityConnection
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionInputObject <IDataTransferIdentity> -FlowName <String>
 -Flow <IResourceBody> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### LinkViaIdentityConnectionExpanded
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionInputObject <IDataTransferIdentity> -FlowName <String>
 -PendingFlowId <String> [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### LinkViaIdentityExpanded
```
Invoke-AzDataTransferLinkPendingFlow -InputObject <IDataTransferIdentity> -PendingFlowId <String>
 [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### LinkViaJsonFilePath
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionName <String> -FlowName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### LinkViaJsonString
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionName <String> -FlowName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Links the specified flow.

## EXAMPLES

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

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionInputObject
Identity Parameter

```yaml
Type: ADT.Models.IDataTransferIdentity
Parameter Sets: LinkViaIdentityConnection, LinkViaIdentityConnectionExpanded
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
Parameter Sets: Link, LinkExpanded, LinkViaJsonFilePath, LinkViaJsonString
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

### -Flow
The resource to reference.

```yaml
Type: ADT.Models.IResourceBody
Parameter Sets: Link, LinkViaIdentity, LinkViaIdentityConnection
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FlowName
The name for the flow to perform the operation on.

```yaml
Type: System.String
Parameter Sets: Link, LinkExpanded, LinkViaIdentityConnection, LinkViaIdentityConnectionExpanded, LinkViaJsonFilePath, LinkViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: ADT.Models.IDataTransferIdentity
Parameter Sets: LinkViaIdentity, LinkViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Link operation

```yaml
Type: System.String
Parameter Sets: LinkViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Link operation

```yaml
Type: System.String
Parameter Sets: LinkViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PendingFlowId
ID of the resource.

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkViaIdentityConnectionExpanded, LinkViaIdentityExpanded
Aliases:

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
Parameter Sets: Link, LinkExpanded, LinkViaJsonFilePath, LinkViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusReason
Reason for resource operation.

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkViaIdentityConnectionExpanded, LinkViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Link, LinkExpanded, LinkViaJsonFilePath, LinkViaJsonString
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

### ADT.Models.IDataTransferIdentity

### ADT.Models.IResourceBody

## OUTPUTS

### ADT.Models.IFlow

## NOTES

## RELATED LINKS

