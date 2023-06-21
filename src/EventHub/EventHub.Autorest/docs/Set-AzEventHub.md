---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/set-azeventhub
schema: 2.0.0
---

# Set-AzEventHub

## SYNOPSIS
Creates or updates a new Event Hub as a nested resource within a Namespace.

## SYNTAX

### SetExpanded (Default)
```
Set-AzEventHub -Name <String> -NamespaceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ArchiveNameFormat <String>] [-BlobContainer <String>] [-CaptureEnabled] [-DestinationName <String>]
 [-Encoding <EncodingCaptureDescription>] [-IntervalInSeconds <Int32>] [-RetentionTimeInHour <Int64>]
 [-SizeLimitInBytes <Int32>] [-SkipEmptyArchive] [-Status <EntityStatus>] [-StorageAccountResourceId <String>]
 [-TombstoneRetentionTimeInHour <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SetViaIdentityExpanded
```
Set-AzEventHub -InputObject <IEventHubIdentity> [-ArchiveNameFormat <String>] [-BlobContainer <String>]
 [-CaptureEnabled] [-DestinationName <String>] [-Encoding <EncodingCaptureDescription>]
 [-IntervalInSeconds <Int32>] [-RetentionTimeInHour <Int64>] [-SizeLimitInBytes <Int32>] [-SkipEmptyArchive]
 [-Status <EntityStatus>] [-StorageAccountResourceId <String>] [-TombstoneRetentionTimeInHour <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzEventHub -Name <String> -NamespaceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ArchiveNameFormat <String>] [-BlobContainer <String>] [-CaptureDescriptionEnabled]
 [-CaptureDescriptionEncoding <EncodingCaptureDescription>] [-CaptureDescriptionIntervalInSecond <Int32>]
 [-CaptureDescriptionSizeLimitInByte <Int32>] [-CaptureDescriptionSkipEmptyArchive]
 [-DataLakeAccountName <String>] [-DataLakeFolderPath <String>] [-DataLakeSubscriptionId <String>]
 [-DestinationName <String>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <String>] [-MessageRetentionInDay <Int64>] [-PartitionCount <Int64>]
 [-RetentionDescriptionCleanupPolicy <CleanupPolicyRetentionDescription>]
 [-RetentionDescriptionRetentionTimeInHour <Int64>]
 [-RetentionDescriptionTombstoneRetentionTimeInHour <Int32>] [-Status <EntityStatus>]
 [-StorageAccountResourceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a new Event Hub as a nested resource within a Namespace.

## EXAMPLES

### Example 1: Set capture on an existing EventHub entity
```powershell
Set-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}" -BlobContainer container -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId "/subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount"
```

```output
ArchiveNameFormat            : {Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}
BlobContainer                : container
CaptureEnabled               : True
CleanupPolicy                : Delete
CreatedAt                    : 1/1/0001 12:00:00 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              : EventHubArchive.AzureBlockBlob
Encoding                     : Avro
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/namespace3/eventhubs/myEventHub
IntervalInSeconds            : 600
Location                     : eastus
MessageRetentionInDay        : 7
Name                         : myEventHub
PartitionCount               : 5
PartitionId                  : {}
ResourceGroupName            : myResourceGroup
RetentionTimeInHour          : 168
SizeLimitInBytes             : 11000000
SkipEmptyArchive             : True
Status                       : Active
StorageAccountResourceId     : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TombstoneRetentionTimeInHour :
Type                         : Microsoft.EventHub/namespaces/eventhubs
UpdatedAt                    : 1/1/0001 12:00:00 AM
```

Updates EventHub entity `myEventHub` from namespace `myNamespace` to enable capture on it.

### Example 2: Update EventHub EventHub entity using InputObject parameter set
```powershell
$eventhub = Get-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace
Set-AzEventHub -InputObject $eventhub -RetentionTimeInHour 72
```

```output
ArchiveNameFormat            : {Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}
BlobContainer                : container1entHub]>
CaptureEnabled               : True
CleanupPolicy                : Delete
CreatedAt                    : 1/1/0001 12:00:00 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              : EventHubArchive.AzureBlockBlob
Encoding                     : Avro
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myEventHub
IntervalInSeconds            : 600
Location                     : eastus
MessageRetentionInDay        : 3
Name                         : myEventHub
PartitionCount               : 5
PartitionId                  : {}
ResourceGroupName            : myResourceGroup
RetentionTimeInHour          : 72
SizeLimitInBytes             : 11000000
SkipEmptyArchive             : True
Status                       : Active
StorageAccountResourceId     : /subscriptions/subscriptionId/resourceGroups/myResourcegroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount
                               1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TombstoneRetentionTimeInHour :
Type                         : Microsoft.EventHub/namespaces/eventhubs
UpdatedAt                    : 1/1/0001 12:00:00 AM
```

Updates `RetentionTimeInHour` in EventHub entity `myEventHub` to 72 hours.

## PARAMETERS

### -ArchiveNameFormat
Blob naming convention for archive, e.g.
{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}.
Here all the parameters (Namespace,EventHub ..
etc) are mandatory irrespective of order

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobContainer
Blob container Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CaptureDescriptionEnabled
A value that indicates whether capture description is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CaptureDescriptionEncoding
Enumerates the possible values for the encoding format of capture description.
Note: 'AvroDeflate' will be deprecated in New API Version

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.EncodingCaptureDescription
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CaptureDescriptionIntervalInSecond
The time window allows you to set the frequency with which the capture to Azure Blobs will happen, value should between 60 to 900 seconds

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CaptureDescriptionSizeLimitInByte
The size window defines the amount of data built up in your Event Hub before an capture operation, value should be between 10485760 to 524288000 bytes

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CaptureDescriptionSkipEmptyArchive
A value that indicates whether to Skip Empty Archives

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CaptureEnabled
A value that indicates whether capture description is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeAccountName
The Azure Data Lake Store name for the captured events

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeFolderPath
The destination folder path for the captured events

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeSubscriptionId
Subscription Id of Azure Data Lake Store

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### -DestinationName
Name for capture destination

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Encoding
Enumerates the possible values for the encoding format of capture description.
Note: 'AvroDeflate' will be deprecated in New API Version

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.EncodingCaptureDescription
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Type of Azure Active Directory Managed Identity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.ManagedServiceIdentityType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
ARM ID of Managed User Identity.
This property is required is the type is UserAssignedIdentity.
If type is SystemAssigned, then the System Assigned Identity Associated with the namespace will be used.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity parameter.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IntervalInSeconds
The time window allows you to set the frequency with which the capture to Azure Blobs will happen, value should between 60 to 900 seconds

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MessageRetentionInDay
Number of days to retain the events for this Event Hub, value should be 1 to 7 days

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The Event Hub name

```yaml
Type: System.String
Parameter Sets: SetExpanded, UpdateExpanded
Aliases: EventHubName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The Namespace name

```yaml
Type: System.String
Parameter Sets: SetExpanded, UpdateExpanded
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
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartitionCount
Number of partitions created for the Event Hub, allowed values are from 1 to 32 partitions.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group within the azure subscription.

```yaml
Type: System.String
Parameter Sets: SetExpanded, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionDescriptionCleanupPolicy
Enumerates the possible values for cleanup policy

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.CleanupPolicyRetentionDescription
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionDescriptionRetentionTimeInHour
Number of hours to retain the events for this Event Hub.
This value is only used when cleanupPolicy is Delete.
If cleanupPolicy is Compact the returned value of this property is Long.MaxValue

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionDescriptionTombstoneRetentionTimeInHour
Number of hours to retain the tombstone markers of a compacted Event Hub.
This value is only used when cleanupPolicy is Compact.
Consumer must complete reading the tombstone marker within this specified amount of time if consumer begins from starting offset to ensure they get a valid snapshot for the specific key described by the tombstone marker within the compacted Event Hub

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionTimeInHour
Number of hours to retain the events for this Event Hub.
This value is only used when cleanupPolicy is Delete.
If cleanupPolicy is Compaction the returned value of this property is Long.MaxValue

```yaml
Type: System.Int64
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SizeLimitInBytes
The size window defines the amount of data built up in your Event Hub before an capture operation, value should be between 10485760 to 524288000 bytes

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipEmptyArchive
A value that indicates whether to Skip Empty Archives

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Enumerates the possible values for the status of the Event Hub.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.EntityStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountResourceId
Resource id of the storage account to be used to create the blobs

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: SetExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TombstoneRetentionTimeInHour
Number of hours to retain the tombstone markers of a compacted Event Hub.
This value is only used when cleanupPolicy is Compaction.
Consumer must complete reading the tombstone marker within this specified amount of time if consumer begins from starting offset to ensure they get a valid snapshot for the specific key described by the tombstone marker within the compacted Event Hub

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202301Preview.IEventhub

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IEventHubIdentity>`: Identity parameter.
  - `[Alias <String>]`: The Disaster Recovery configuration name
  - `[ApplicationGroupName <String>]`: The Application Group name 
  - `[AuthorizationRuleName <String>]`: The authorization rule name.
  - `[ClusterName <String>]`: The name of the Event Hubs Cluster.
  - `[ConsumerGroupName <String>]`: The consumer group name
  - `[EventHubName <String>]`: The Event Hub name
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The Namespace name
  - `[PrivateEndpointConnectionName <String>]`: The PrivateEndpointConnection name
  - `[ResourceAssociationName <String>]`: The ResourceAssociation Name
  - `[ResourceGroupName <String>]`: Name of the resource group within the azure subscription.
  - `[SchemaGroupName <String>]`: The Schema Group name 
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

