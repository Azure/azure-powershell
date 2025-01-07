---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/new-azdeviceregistryasset
schema: 2.0.0
---

# New-AzDeviceRegistryAsset

## SYNOPSIS
create a Asset

## SYNTAX

### CreateExpanded (Default)
```
New-AzDeviceRegistryAsset -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -ExtendedLocationName <String> -ExtendedLocationType <String> -Location <String>
 [-AssetEndpointProfileRef <String>] [-Attribute <Hashtable>] [-Dataset <IDataset[]>]
 [-DefaultDatasetsConfiguration <String>] [-DefaultEventsConfiguration <String>] [-DefaultTopicPath <String>]
 [-DefaultTopicRetain <String>] [-Description <String>] [-DiscoveredAssetRef <String[]>]
 [-DisplayName <String>] [-DocumentationUri <String>] [-Enabled] [-Event <IEvent[]>]
 [-ExternalAssetId <String>] [-HardwareRevision <String>] [-Manufacturer <String>] [-ManufacturerUri <String>]
 [-Model <String>] [-ProductCode <String>] [-SerialNumber <String>] [-SoftwareRevision <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDeviceRegistryAsset -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDeviceRegistryAsset -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
create a Asset

## EXAMPLES

### Example 1: Create or update an asset with the specified parameters
```powershell
$jsonString = '{
  "samplingInterval": 1000,
  "queueSize": 20,
  "publishingInterval": 10
}'
$dataSets = @(
  @{
    Name = "dataset1Foo"
    DatasetConfiguration = $jsonString
    Topic = @{
      Path = "/path/dataset1"
      Retain = "Keep"
    }
    DataPoint = @(
      @{
        Name = "datapoint1"
        DataSource = "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt1"
        DataPointConfiguration = $jsonString
      }
    )
  }
)

New-AzDeviceRegistryAsset -Name testassetfrompwsh2 -ResourceGroupName test-rg -ExtendedLocationName "/subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/location-xxxxx" -ExtendedLocationType CustomLocation -Location eastus2 -SubscriptionId xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx -AssetEndpointProfileRef myAssetEndpointProfile -DisplayName testassetfrompwsh1 -Manufacturer Contoso123 -ManufacturerUri ContosoModel -ProductCode SA34VDG -Model ContosoModel -SoftwareRevision "2.0" -HardwareRevision "1.0" -SerialNumber "64-103816-519918-8" -DocumentationUri "https://www.example.com/manual" -DefaultTopicPath "/path/defaultTopic" -DefaultTopicRetain "Keep" -DefaultDatasetsConfiguration $jsonString -DefaultEventsConfiguration $jsonString -Dataset $dataSets
```

```output
Attribute                    : {
                               }
Dataset                      : {{
                                 "topic": {
                                   "path": "/path/dataset1",
                                   "retain": "Keep"
                                 },
                                 "name": "dataset1Foo",
                                 "dataPoints": [
                                   {
                                     "name": "datapoint1",
                                     "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt1",
                                     "observabilityMode": "None"
                                   }
                                 ]
                               }}
DefaultDatasetsConfiguration : {
                                 "samplingInterval": 1000,
                                 "queueSize": 20,
                                 "publishingInterval": 10
                               }
DefaultEventsConfiguration   : {
                                 "samplingInterval": 1000,
                                 "queueSize": 20,
                                 "publishingInterval": 10
                               }
DefaultTopicPath             : /path/defaultTopic
DefaultTopicRetain           : Keep
Description                  :
DiscoveredAssetRef           :
DisplayName                  : testassetfrompwsh1
DocumentationUri             : https://www.example.com/manual
Enabled                      : True
EndpointProfileRef           : myAssetEndpointProfile
Event                        :
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations
                               /location-xxxxx
ExtendedLocationType         : CustomLocation
ExternalAssetId              : 94a7017e-2edd-4e72-b7b5-2a61a1b1c702
HardwareRevision             : 1.0
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DeviceRegistry/assets/test-asset
Location                     : eastus2
Manufacturer                 : Contoso123
ManufacturerUri              : ContosoModel
Model                        : ContosoModel
Name                         : test-asset
ProductCode                  : SA34VDG
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
SerialNumber                 : 64-103816-519918-8
SoftwareRevision             : 2.0
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          : 12/18/2024 6:55:47 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/18/2024 7:19:47 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/assets
Uuid                         : 94a7017e-2edd-4e72-b7b5-2a61a1b1c702
Version                      : 4
```

Creates a new asset `test-asset` in resource group `test-rg`

### Example 2: Create or update an asset from a JSON file path
```powershell
New-AzDeviceRegistryAsset -Name test-asset -ResourceGroupName test-rg -JsonFilePath "C:\Users\abc\Desktop\asset.json"
```

```output
Attribute                    : {
                               }
Dataset                      : {{
                                 "topic": {
                                   "path": "/path/dataset1",
                                   "retain": "Keep"
                                 },
                                 "name": "dataset1Foo",
                                 "dataPoints": [
                                   {
                                     "name": "datapoint1",
                                     "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt1",
                                     "observabilityMode": "None"
                                   }
                                 ]
                               }}
DefaultDatasetsConfiguration : {
                                 "samplingInterval": 1000,
                                 "queueSize": 20,
                                 "publishingInterval": 10
                               }
DefaultEventsConfiguration   : {
                                 "samplingInterval": 1000,
                                 "queueSize": 20,
                                 "publishingInterval": 10
                               }
DefaultTopicPath             : /path/defaultTopic
DefaultTopicRetain           : Keep
Description                  :
DiscoveredAssetRef           :
DisplayName                  : testassetfrompwsh1
DocumentationUri             : https://www.example.com/manual
Enabled                      : True
EndpointProfileRef           : myAssetEndpointProfile
Event                        :
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations
                               /location-xxxxx
ExtendedLocationType         : CustomLocation
ExternalAssetId              : 94a7017e-2edd-4e72-b7b5-2a61a1b1c702
HardwareRevision             : 1.0
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DeviceRegistry/assets/test-asset
Location                     : eastus2
Manufacturer                 : Contoso123
ManufacturerUri              : ContosoModel
Model                        : ContosoModel
Name                         : test-asset
ProductCode                  : SA34VDG
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
SerialNumber                 : 64-103816-519918-8
SoftwareRevision             : 2.0
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          : 12/18/2024 6:55:47 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/18/2024 7:19:47 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/assets
Uuid                         : 94a7017e-2edd-4e72-b7b5-2a61a1b1c702
Version                      : 4
```

Creates a new asset `test-asset`in resource group `test-rg` from the provided json file at path `C:\Users\abc\Desktop\asset.json`

### Example 3: Create or update an asset from a stringified JSON
```powershell
$jsonStr = '{
    "location": "eastus2",
    "extendedLocation": {
        "type": "CustomLocation",
        "name": "/subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/location-xxxxx"
    },
    "properties": {
        "assetEndpointProfileRef": "myAssetEndpointProfile",
        "version": 73766,
        "manufacturer": "Contoso123",
        "manufacturerUri": "https://www.contoso.com/manufacturerUri",
        "model": "ContosoModel",
        "productCode": "SA34VDG",
        "softwareRevision": "2.0",
        "documentationUri": "https://www.example.com/manual",
        "serialNumber": "64-103816-519918-8",
        "defaultDatasetsConfiguration": "{\"publishingInterval\":10,\"samplingInterval\":1000,\"queueSize\":20}",
        "defaultEventsConfiguration": "{\"publishingInterval\":10,\"samplingInterval\":1000,\"queueSize\":20}",
        "defaultTopic": {
          "path": "/path/defaultTopic",
          "retain": "Keep"
        },
        "datasets": [
          {
            "name": "dataset1Foo",
            "datasetConfiguration": "{\"publishingInterval\":10,\"samplingInterval\":1000,\"queueSize\":20}",
            "topic": {
              "path": "/path/dataset1",
              "retain": "Keep"
            },
            "dataPoints": [
              {
                "name": "dataPoint1",
                "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt1",
                "dataPointConfiguration": "{\"publishingInterval\":8,\"samplingInterval\":1000,\"queueSize\":4}"
              }
            ]
          }
        ]
    }
}'
New-AzDeviceRegistryAsset -Name test-asset -ResourceGroupName test-rg -JsonString $jsonStr
```

```output
Attribute                    : {
                               }
Dataset                      : {{
                                 "topic": {
                                   "path": "/path/dataset1",
                                   "retain": "Keep"
                                 },
                                 "name": "dataset1Foo",
                                 "dataPoints": [
                                   {
                                     "name": "datapoint1",
                                     "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt1",
                                     "observabilityMode": "None"
                                   }
                                 ]
                               }}
DefaultDatasetsConfiguration : {
                                 "samplingInterval": 1000,
                                 "queueSize": 20,
                                 "publishingInterval": 10
                               }
DefaultEventsConfiguration   : {
                                 "samplingInterval": 1000,
                                 "queueSize": 20,
                                 "publishingInterval": 10
                               }
DefaultTopicPath             : /path/defaultTopic
DefaultTopicRetain           : Keep
Description                  :
DiscoveredAssetRef           :
DisplayName                  : testassetfrompwsh1
DocumentationUri             : https://www.example.com/manual
Enabled                      : True
EndpointProfileRef           : myAssetEndpointProfile
Event                        :
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations
                               /location-xxxxx
ExtendedLocationType         : CustomLocation
ExternalAssetId              : 94a7017e-2edd-4e72-b7b5-2a61a1b1c702
HardwareRevision             : 1.0
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DeviceRegistry/assets/test-asset
Location                     : eastus2
Manufacturer                 : Contoso123
ManufacturerUri              : ContosoModel
Model                        : ContosoModel
Name                         : test-asset
ProductCode                  : SA34VDG
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
SerialNumber                 : 64-103816-519918-8
SoftwareRevision             : 2.0
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          : 12/18/2024 6:55:47 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/18/2024 7:19:47 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/assets
Uuid                         : 94a7017e-2edd-4e72-b7b5-2a61a1b1c702
Version                      : 4
```

Creates a new asset `test-asset`in resource group `test-rg` from the provided stringified JSON.

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

### -AssetEndpointProfileRef
A reference to the asset endpoint profile (connection information) used by brokers to connect to an endpoint that provides data points for this asset.
Must provide asset endpoint profile name.

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

### -Attribute
A set of key-value pairs that contain custom attributes set by the customer.

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

### -Dataset
Array of datasets that are part of the asset.
Each dataset describes the data points that make up the set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDataset[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### -DefaultTopicPath
The topic path for messages published to an MQTT broker.

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

### -DefaultTopicRetain
When set to 'Keep', messages published to an MQTT broker will have the retain flag set.
Default: 'Never'.

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

### -Description
Human-readable description of the asset.

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

### -DiscoveredAssetRef
Reference to a list of discovered assets.
Populated only if the asset has been created from discovery flow.
Discovered asset names must be provided.

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

### -DisplayName
Human-readable display name.

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

### -DocumentationUri
Reference to the documentation.

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

### -Enabled
Enabled/Disabled status of the asset.

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

### -Event
Array of events that are part of the asset.
Each event can have per-event configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IEvent[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The extended location name.

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

### -ExtendedLocationType
The extended location type.

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

### -ExternalAssetId
Asset id provided by the customer.

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

### -HardwareRevision
Revision number of the hardware.

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

### -Manufacturer
Asset manufacturer name.

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

### -ManufacturerUri
Asset manufacturer URI.

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

### -Model
Asset model name.

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
Asset name parameter.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IAsset

## NOTES

## RELATED LINKS
