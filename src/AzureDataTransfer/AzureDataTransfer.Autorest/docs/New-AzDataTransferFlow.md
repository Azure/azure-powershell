---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/new-azdatatransferflow
schema: 2.0.0
---

# New-AzDataTransferFlow

## SYNOPSIS
create the flow resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDataTransferFlow -ConnectionName <String> -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-CustomerManagedKeyVaultUri <String>] [-DataType <String>]
 [-DestinationEndpoint <String[]>] [-DestinationEndpointPort <Int64[]>] [-EnableSystemAssignedIdentity]
 [-FlowPropertyConnectionId <String>] [-FlowPropertyConnectionLocation <String>]
 [-FlowPropertyConnectionName <String>] [-FlowPropertyConnectionSubscriptionName <String>]
 [-FlowType <String>] [-KeyVaultUri <String>] [-MessagingOptionBillingTier <String>] [-Passphrase <String>]
 [-PlanName <String>] [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>]
 [-PlanVersion <String>] [-Policy <String[]>] [-SchemaConnectionId <String>] [-SchemaContent <String>]
 [-SchemaDirection <String>] [-SchemaId <String>] [-SchemaName <String>] [-SchemaStatus <String>]
 [-SchemaType <String>] [-SchemaUri <String>] [-ServiceBusQueueId <String>] [-SourceAddressList <String[]>]
 [-Status <String>] [-StorageAccountId <String>] [-StorageAccountName <String>]
 [-StorageContainerName <String>] [-StreamId <String>] [-StreamLatency <Int64>] [-StreamProtocol <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDataTransferFlow -ConnectionName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDataTransferFlow -ConnectionName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
create the flow resource.

## EXAMPLES

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

### -ConnectionName
The name for the connection that is to be requested.

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

### -CustomerManagedKeyVaultUri
The URI to the customer managed key for this flow

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataType
Transfer Storage Blobs or Tables

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
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

### -DestinationEndpoint
The destination endpoints of the stream

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationEndpointPort
The destination endpoint ports of the stream

```yaml
Type: System.Int64[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlowPropertyConnectionId
Id of the connection

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlowPropertyConnectionLocation
Location of the connection

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlowPropertyConnectionName
Name of the connection

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlowPropertyConnectionSubscriptionName
Name of the subscription with the connection

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlowType
The flow type for this flow

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultUri
AME, PME, or TORUS only! AKV Chain Containing SAS Token

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MessagingOptionBillingTier
Billing tier for this messaging flow

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the flow that is to be onboarded.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -Passphrase
The passphrase used for SRT streams

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanName
A user defined name of the 3rd Party Artifact that is being procured.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanProduct
The 3rd Party artifact that is being procured.
E.g.
NewRelic.
Product maps to the OfferID specified for the artifact at the time of Data Market onboarding.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanPromotionCode
A publisher provided promotion code as provisioned in Data Market for the said product/artifact.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanPublisher
The publisher of the 3rd Party Artifact that is being bought.
E.g.
NewRelic

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanVersion
The version of the desired product/artifact.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Policy
The policies for this flow

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaConnectionId
Connection ID associated with this schema

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaContent
Content of the schema

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaDirection
The direction of the schema.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaId
ID associated with this schema

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaName
Name of the schema

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaStatus
Status of the schema

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaType
The Schema Type

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaUri
Uri containing SAS token for the zipped schema

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceBusQueueId
Service Bus Queue ID

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceAddressList
A source IP address or CIDR range

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Status of the current flow

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountId
Storage Account ID

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountName
Storage Account

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageContainerName
Storage Container Name

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StreamId
The flow stream identifier

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StreamLatency
The latency of the stream in milliseconds

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StreamProtocol
The protocol of the stream

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### PrivateADT.Models.IFlow

## NOTES

## RELATED LINKS

