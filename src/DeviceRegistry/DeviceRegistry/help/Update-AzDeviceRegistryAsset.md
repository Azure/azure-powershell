---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/update-azdeviceregistryasset
schema: 2.0.0
---

# Update-AzDeviceRegistryAsset

## SYNOPSIS
update a Asset

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDeviceRegistryAsset -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Attribute <Hashtable>] [-Dataset <IDataset[]>] [-DefaultDatasetsConfiguration <String>]
 [-DefaultEventsConfiguration <String>] [-DefaultTopicPath <String>] [-DefaultTopicRetain <String>]
 [-Description <String>] [-DisplayName <String>] [-DocumentationUri <String>] [-Enabled] [-Event <IEvent[]>]
 [-HardwareRevision <String>] [-Manufacturer <String>] [-ManufacturerUri <String>] [-Model <String>]
 [-ProductCode <String>] [-SerialNumber <String>] [-SoftwareRevision <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzDeviceRegistryAsset -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzDeviceRegistryAsset -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDeviceRegistryAsset -InputObject <IDeviceRegistryIdentity> [-Attribute <Hashtable>]
 [-Dataset <IDataset[]>] [-DefaultDatasetsConfiguration <String>] [-DefaultEventsConfiguration <String>]
 [-DefaultTopicPath <String>] [-DefaultTopicRetain <String>] [-Description <String>] [-DisplayName <String>]
 [-DocumentationUri <String>] [-Enabled] [-Event <IEvent[]>] [-HardwareRevision <String>]
 [-Manufacturer <String>] [-ManufacturerUri <String>] [-Model <String>] [-ProductCode <String>]
 [-SerialNumber <String>] [-SoftwareRevision <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
update a Asset

## EXAMPLES

### Example 1: Update an asset by name and resource group.
```powershell
Update-AzDeviceRegistryAsset -Name test-asset -ResourceGroupName test-rg -Model ContosoModel2
```

```output
Attribute                    : {
                               }
Dataset                      :
DefaultDatasetsConfiguration :
DefaultEventsConfiguration   :
DefaultTopicPath             :
DefaultTopicRetain           :
Description                  :
DiscoveredAssetRef           :
DisplayName                  :
DocumentationUri             :
Enabled                      :
Ref           :
Event                        :
ExtendedLocationName         :
ExtendedLocationType         :
ExternalAssetId              :
HardwareRevision             :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                     :
Manufacturer                 :
ManufacturerUri              :
Model                        :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProductCode                  :
ProvisioningState            :
ResourceGroupName            :
SerialNumber                 :
SoftwareRevision             :
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         :
Uuid                         :
Version                      :
```

This command updates an asset's `Model` property with value `ContosoModel2`.
Note: the output response is only the operation status of the update command, not the patched asset.

### Example 2: UpdateViaIdentity for asset.
```powershell
$asset = @{ "ResourceGroupName" = "test-rg"; "AssetName" = "test-asset"; "SubscriptionId" = "xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx"; }
Update-AzDeviceRegistryAsset -InputObject $asset -Model ContosoModel2
```

```output
Attribute                    : {
                               }
Dataset                      :
DefaultDatasetsConfiguration :
DefaultEventsConfiguration   :
DefaultTopicPath             :
DefaultTopicRetain           :
Description                  :
DiscoveredAssetRef           :
DisplayName                  :
DocumentationUri             :
Enabled                      :
Ref           :
Event                        :
ExtendedLocationName         :
ExtendedLocationType         :
ExternalAssetId              :
HardwareRevision             :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                     :
Manufacturer                 :
ManufacturerUri              :
Model                        :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProductCode                  :
ProvisioningState            :
ResourceGroupName            :
SerialNumber                 :
SoftwareRevision             :
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         :
Uuid                         :
Version                      :
```

This command updates an asset's `Model` property with value `ContosoModel2` via Identity input object.
Note: the output response is only the operation status of the update command, not the patched asset.

### Example 3: Update an asset from a JSON file path
```powershell
Update-AzDeviceRegistryAsset -Name test-asset -ResourceGroupName test-rg -JsonFilePath "C:\Users\abc\Desktop\assetPatch.json"
```

```output
Attribute                    : {
                               }
Dataset                      :
DefaultDatasetsConfiguration :
DefaultEventsConfiguration   :
DefaultTopicPath             :
DefaultTopicRetain           :
Description                  :
DiscoveredAssetRef           :
DisplayName                  :
DocumentationUri             :
Enabled                      :
Ref           :
Event                        :
ExtendedLocationName         :
ExtendedLocationType         :
ExternalAssetId              :
HardwareRevision             :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                     :
Manufacturer                 :
ManufacturerUri              :
Model                        :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProductCode                  :
ProvisioningState            :
ResourceGroupName            :
SerialNumber                 :
SoftwareRevision             :
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         :
Uuid                         :
Version                      :
```

This command updates an asset's property(ies) with new value(s) by specifying a JSON file path containing the patch body.
Note: the output response is only the operation status of the update command, not the patched asset.

### Example 4: Update an asset from a stringified JSON
```powershell
$jsonStr = '{
    "properties": {
        "model": "ContosoModel2"
    }
}'
Update-AzDeviceRegistryAsset -Name test-asset -ResourceGroupName test-rg -JsonString $jsonStr
```

```output
Attribute                    : {
                               }
Dataset                      :
DefaultDatasetsConfiguration :
DefaultEventsConfiguration   :
DefaultTopicPath             :
DefaultTopicRetain           :
Description                  :
DiscoveredAssetRef           :
DisplayName                  :
DocumentationUri             :
Enabled                      :
Ref           :
Event                        :
ExtendedLocationName         :
ExtendedLocationType         :
ExternalAssetId              :
HardwareRevision             :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                     :
Manufacturer                 :
ManufacturerUri              :
Model                        :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProductCode                  :
ProvisioningState            :
ResourceGroupName            :
SerialNumber                 :
SoftwareRevision             :
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         :
Uuid                         :
Version                      :
```

This command updates an asset's `Model` property with new value `ContosoModel2` by specifying the patch as a stringified JSON body.
Note: the output response is only the operation status of the update command, not the patched asset.

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

### -Attribute
A set of key-value pairs that contain custom attributes set by the customer.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dataset
Array of datasets that are part of the asset.
Each dataset describes the data points that make up the set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDataset[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -DefaultTopicPath
The topic path for messages published to an MQTT broker.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultTopicRetain
When set to 'Keep', messages published to an MQTT broker will have the retain flag set.
Default: 'Never'.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DocumentationUri
Reference to the documentation.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
Enabled/Disabled status of the asset.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Event
Array of events that are part of the asset.
Each event can have per-event configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IEvent[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HardwareRevision
Revision number of the hardware.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -Manufacturer
Asset manufacturer name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Model
Asset model name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Asset name parameter.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases: AssetName

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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftwareRevision
Revision number of the software.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IAsset

## NOTES

## RELATED LINKS
