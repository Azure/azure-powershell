---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/disable-azdatatransferflow
schema: 2.0.0
---

# Disable-AzDataTransferFlow

## SYNOPSIS
Disables the specified flow

## SYNTAX

### Disable (Default)
```
Disable-AzDataTransferFlow -ConnectionName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DisableViaIdentity
```
Disable-AzDataTransferFlow -InputObject <IDataTransferIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DisableViaIdentityConnection
```
Disable-AzDataTransferFlow -ConnectionInputObject <IDataTransferIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Disables the specified flow

## EXAMPLES

### Example 1: Disable a specific flow
```powershell
Disable-AzDataTransferFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01 -Name Flow01 -Confirm:$false
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
Status                                 : Disabled
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

This example disables a specific flow named `Flow01` in the connection `Connection01` within the resource group `ResourceGroup01` without prompting for confirmation.

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
Parameter Sets: DisableViaIdentityConnection
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
Parameter Sets: Disable
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
Parameter Sets: DisableViaIdentity
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
Parameter Sets: Disable, DisableViaIdentityConnection
Aliases: FlowName

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Disable
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
Type: System.String
Parameter Sets: Disable
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

## OUTPUTS

### ADT.Models.IFlow

## NOTES

## RELATED LINKS

