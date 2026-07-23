---
external help file:
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/update-azdeviceregistrynamespacediscoveredasset
schema: 2.0.0
---

# Update-AzDeviceRegistryNamespaceDiscoveredAsset

## SYNOPSIS
Update a NamespaceDiscoveredAsset

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDeviceRegistryNamespaceDiscoveredAsset -DiscoveredAssetName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-AssetTypeRef <String[]>] [-Attribute <Hashtable>]
 [-Dataset <INamespaceDiscoveredDataset[]>] [-DefaultDatasetsConfiguration <String>]
 [-DefaultDatasetsDestination <IDatasetDestination[]>] [-DefaultEventsConfiguration <String>]
 [-DefaultEventsDestination <IEventDestination[]>] [-DefaultManagementGroupsConfiguration <String>]
 [-DefaultStreamsConfiguration <String>] [-DefaultStreamsDestination <IStreamDestination[]>]
 [-Description <String>] [-DeviceRefDeviceName <String>] [-DeviceRefEndpointName <String>]
 [-DiscoveryId <String>] [-DisplayName <String>] [-DocumentationUri <String>]
 [-EventGroup <INamespaceDiscoveredEventGroup[]>] [-HardwareRevision <String>]
 [-ManagementGroup <INamespaceDiscoveredManagementGroup[]>] [-Manufacturer <String>]
 [-ManufacturerUri <String>] [-Model <String>] [-ProductCode <String>] [-SerialNumber <String>]
 [-SoftwareRevision <String>] [-Stream <INamespaceDiscoveredStream[]>] [-Tag <Hashtable>] [-Version <Int64>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDeviceRegistryNamespaceDiscoveredAsset -InputObject <IDeviceRegistryIdentity>
 [-AssetTypeRef <String[]>] [-Attribute <Hashtable>] [-Dataset <INamespaceDiscoveredDataset[]>]
 [-DefaultDatasetsConfiguration <String>] [-DefaultDatasetsDestination <IDatasetDestination[]>]
 [-DefaultEventsConfiguration <String>] [-DefaultEventsDestination <IEventDestination[]>]
 [-DefaultManagementGroupsConfiguration <String>] [-DefaultStreamsConfiguration <String>]
 [-DefaultStreamsDestination <IStreamDestination[]>] [-Description <String>] [-DeviceRefDeviceName <String>]
 [-DeviceRefEndpointName <String>] [-DiscoveryId <String>] [-DisplayName <String>]
 [-DocumentationUri <String>] [-EventGroup <INamespaceDiscoveredEventGroup[]>] [-HardwareRevision <String>]
 [-ManagementGroup <INamespaceDiscoveredManagementGroup[]>] [-Manufacturer <String>]
 [-ManufacturerUri <String>] [-Model <String>] [-ProductCode <String>] [-SerialNumber <String>]
 [-SoftwareRevision <String>] [-Stream <INamespaceDiscoveredStream[]>] [-Tag <Hashtable>] [-Version <Int64>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityNamespaceExpanded
```
Update-AzDeviceRegistryNamespaceDiscoveredAsset -DiscoveredAssetName <String>
 -NamespaceInputObject <IDeviceRegistryIdentity> [-AssetTypeRef <String[]>] [-Attribute <Hashtable>]
 [-Dataset <INamespaceDiscoveredDataset[]>] [-DefaultDatasetsConfiguration <String>]
 [-DefaultDatasetsDestination <IDatasetDestination[]>] [-DefaultEventsConfiguration <String>]
 [-DefaultEventsDestination <IEventDestination[]>] [-DefaultManagementGroupsConfiguration <String>]
 [-DefaultStreamsConfiguration <String>] [-DefaultStreamsDestination <IStreamDestination[]>]
 [-Description <String>] [-DeviceRefDeviceName <String>] [-DeviceRefEndpointName <String>]
 [-DiscoveryId <String>] [-DisplayName <String>] [-DocumentationUri <String>]
 [-EventGroup <INamespaceDiscoveredEventGroup[]>] [-HardwareRevision <String>]
 [-ManagementGroup <INamespaceDiscoveredManagementGroup[]>] [-Manufacturer <String>]
 [-ManufacturerUri <String>] [-Model <String>] [-ProductCode <String>] [-SerialNumber <String>]
 [-SoftwareRevision <String>] [-Stream <INamespaceDiscoveredStream[]>] [-Tag <Hashtable>] [-Version <Int64>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzDeviceRegistryNamespaceDiscoveredAsset -DiscoveredAssetName <String> -NamespaceName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzDeviceRegistryNamespaceDiscoveredAsset -DiscoveredAssetName <String> -NamespaceName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a NamespaceDiscoveredAsset

## EXAMPLES

### Example 1: Update a Device Registry Namespace Discovered Asset with expanded parameters
```powershell
Update-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredAssetName "my-discovered-asset" -DocumentationUri "https://www.example.com/docs" -SerialNumber "SN123456789"
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

Updates a Device Registry Namespace Discovered Asset by modifying its properties using individual parameters.

### Example 2: Update a Device Registry Namespace Discovered Asset using JSON string
```powershell
$updateJson = '{
  "properties": {
    "documentationUri": "https://www.example.com/docs",
    "serialNumber": "SN123456789"
  }
}'
Update-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredAssetName "my-discovered-asset" -JsonString $updateJson
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

Updates a Device Registry Namespace Discovered Asset using a JSON string containing the properties to update.

### Example 3: Update a Device Registry Namespace Discovered Asset using JSON file path
```powershell
Update-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredAssetName "my-discovered-asset" -JsonFilePath "C:\path\to\update-discovered-asset.json"
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

Updates a Device Registry Namespace Discovered Asset using a JSON file containing the properties to update.

### Example 4: Update a Device Registry Namespace Discovered Asset using namespace identity object
```powershell
$namespaceIdentity = @{
    SubscriptionId = "00000000-0000-0000-0000-000000000000"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Update-AzDeviceRegistryNamespaceDiscoveredAsset -NamespaceInputObject $namespaceIdentity -DiscoveredAssetName "my-discovered-asset" -DocumentationUri "https://www.example.com/docs" -SerialNumber "SN123456789"
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

Updates a Device Registry Namespace Discovered Asset using the parent namespace's identity object.

### Example 5: Update a Device Registry Namespace Discovered Asset using discovered asset identity object
```powershell
Update-AzDeviceRegistryNamespaceDiscoveredAsset -InputObject $discoveredAssetObject -DocumentationUri "https://www.example.com/docs" -SerialNumber "SN123456789"
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

Updates a Device Registry Namespace Discovered Asset using the discovered asset's identity object.

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

### -AssetTypeRef
URIs or type definition IDs.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Attribute
A set of key-value pairs that contain custom attributes.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dataset
Array of datasets that are part of the asset.
Each dataset spec describes the data points that make up the set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredDataset[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultDatasetsConfiguration
Stringified JSON that contains connector-specific default configuration for all datasets.
Each dataset can have its own configuration that overrides the default settings here.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultDatasetsDestination
Default destinations for a dataset.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDatasetDestination[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultEventsConfiguration
Stringified JSON that contains connector-specific default configuration for all events.
Each event can have its own configuration that overrides the default settings here.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultEventsDestination
Default destinations for an event.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IEventDestination[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultManagementGroupsConfiguration
Stringified JSON that contains connector-specific default configuration for all management groups.
Each management group can have its own configuration that overrides the default settings here.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
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

### -DefaultStreamsConfiguration
Stringified JSON that contains connector-specific default configuration for all streams.
Each stream can have its own configuration that overrides the default settings here.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultStreamsDestination
Default destinations for a stream.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IStreamDestination[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Human-readable description of the asset.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceRefDeviceName
Name of the device resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceRefEndpointName
The name of endpoint to use

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiscoveredAssetName
The name of the discovered asset.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiscoveryId
Identifier used to detect changes in the asset.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
Human-readable display name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DocumentationUri
Asset documentation reference.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventGroup
Array of event groups that are part of the asset.
Each event group can have per-event group configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredEventGroup[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HardwareRevision
Asset hardware revision number.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementGroup
Array of management groups that are part of the asset.
Each management group can have a per-group configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredManagementGroup[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Manufacturer
Asset manufacturer.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManufacturerUri
Asset manufacturer URI.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Model
Asset model.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: UpdateViaIdentityNamespaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
The name of the namespace.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

### -ProductCode
Asset product code.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SerialNumber
Asset serial number.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftwareRevision
Asset software revision number.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Stream
Array of streams that are part of the asset.
Each stream can have a per-stream configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredStream[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
An integer that is incremented each time the resource is modified.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNamespaceExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredAsset

## NOTES

## RELATED LINKS

