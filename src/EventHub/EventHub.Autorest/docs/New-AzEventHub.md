---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/new-azeventhub
schema: 2.0.0
---

# New-AzEventHub

## SYNOPSIS
Creates or updates a new Event Hub as a nested resource within a Namespace.

## SYNTAX

```
New-AzEventHub -Name <String> -NamespaceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ArchiveNameFormat <String>] [-BlobContainer <String>] [-CaptureEnabled]
 [-CleanupPolicy <CleanupPolicyRetentionDescription>] [-DestinationName <String>]
 [-Encoding <EncodingCaptureDescription>] [-IntervalInSeconds <Int32>] [-PartitionCount <Int64>]
 [-RetentionTimeInHour <Int64>] [-SizeLimitInBytes <Int32>] [-SkipEmptyArchive] [-Status <EntityStatus>]
 [-StorageAccountResourceId <String>] [-TombstoneRetentionTimeInHour <Int32>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a new Event Hub as a nested resource within a Namespace.

## EXAMPLES

### Example 1: Create an EventHub entity
```powershell
New-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -RetentionTimeInHour 168 -PartitionCount 5 -CleanupPolicy Delete
```

```output
ArchiveNameFormat            :
BlobContainer                :
CaptureEnabled               :
CleanupPolicy                : Delete
CreatedAt                    : 4/25/2023 3:55:45 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              :
Encoding                     :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myEventHub
IntervalInSeconds            :
Location                     : eastus
MessageRetentionInDay        : 7
Name                         : myEventHub
PartitionCount               : 5
PartitionId                  : {0, 1, 2, 3�}
ResourceGroupName            : myResourceGroup
RetentionTimeInHour          : 168
SizeLimitInBytes             :
SkipEmptyArchive             :
Status                       : Active
StorageAccountResourceId     :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TombstoneRetentionTimeInHour :
Type                         : Microsoft.EventHub/namespaces/eventhubs
UpdatedAt                    : 4/25/2023 3:55:46 AM
```

Creates a new eventhub entity `myEventHub` on namespace `myNamespace` with CleaupPolicy `Delete`.

### Example 2: Create EventHub with Capture Enabled
```powershell
New-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}" -BlobContainer container -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId "/subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount -CleanupPolicy Delete"
```

```output
ArchiveNameFormat            : {Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}
BlobContainer                : container
CaptureEnabled               : true
CreatedAt                    : 9/1/2022 5:55:46 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              :
Encoding                     : Avro
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myFirstEventHub
IntervalInSeconds            : 600
Location                     : centralus
MessageRetentionInDays       : 6
Name                         : myFirstEventHub
PartitionCount               : 5
PartitionId                  : {0}
ResourceGroupName            : myResourceGroup
RetentionTimeInHour          : 24
SizeLimitInBytes             : 11000000
SkipEmptyArchive             : true
Status                       : Active
```

Creates a new eventhub entity `myEventHub` on namespace `myNamespace` with capture enabled.

### Example 3: Create an EventHub entity
```powershell
New-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -CleanupPolicy Compact
```

```output
ArchiveNameFormat            :
BlobContainer                :
CaptureEnabled               :
CleanupPolicy                : Compact
CreatedAt                    : 4/25/2023 4:05:57 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              :
Encoding                     :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myEventHub
IntervalInSeconds            :
Location                     : eastus
MessageRetentionInDay        : 9223372036854775807
Name                         : myEventHub
PartitionCount               : 4
PartitionId                  : {0, 1, 2, 3}
ResourceGroupName            : myResourceGroup
RetentionTimeInHour          :
SizeLimitInBytes             :
SkipEmptyArchive             :
Status                       : Active
StorageAccountResourceId     :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TombstoneRetentionTimeInHour :
Type                         : Microsoft.EventHub/namespaces/eventhubs
UpdatedAt                    : 4/25/2023 4:05:58 AM
```

Creates a new eventhub entity `myEventHub` on namespace `myNamespace` with CleaupPolicy `Compact`.

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

### -CaptureEnabled
A value that indicates whether capture description is enabled.

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

### -CleanupPolicy
Enumerates the possible values for cleanup policy

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.CleanupPolicyRetentionDescription
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IntervalInSeconds
The time window allows you to set the frequency with which the capture to Azure Blobs will happen, value should between 60 to 900 seconds

```yaml
Type: System.Int32
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartitionCount
Number of partitions created for the Event Hub, allowed values are from 1 to 32 partitions.

```yaml
Type: System.Int64
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IEventhub

## NOTES

ALIASES

## RELATED LINKS

