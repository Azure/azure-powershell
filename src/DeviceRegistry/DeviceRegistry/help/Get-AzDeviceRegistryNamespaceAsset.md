---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/get-azdeviceregistrynamespaceasset
schema: 2.0.0
---

# Get-AzDeviceRegistryNamespaceAsset

## SYNOPSIS
Get a NamespaceAsset

## SYNTAX

### List (Default)
```
Get-AzDeviceRegistryNamespaceAsset -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityNamespace
```
Get-AzDeviceRegistryNamespaceAsset -AssetName <String> -NamespaceInputObject <IDeviceRegistryIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDeviceRegistryNamespaceAsset -AssetName <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDeviceRegistryNamespaceAsset -InputObject <IDeviceRegistryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a NamespaceAsset

## EXAMPLES

### Example 1: List Namespace Assets in a namespace.
```powershell
Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace"
```

```output
Location Name                                          SystemDataCreatedAt   SystemDataCreatedBy                  SystemDataCreatedB
                                                                                                                  yType
-------- ----                                          -------------------   -------------------                  ------------------
eastus2  test-ns-asset-create-expanded                 7/22/2025 10:05:30 PM user@outlook.com                   User
eastus2  test-ns-asset-create-json-file-path           7/22/2025 10:29:04 PM user@outlook.com                   User
```

Lists all the Device Registry Namespace Assets within the parent Namespace.

### Example 2: Get Namespace Via Namespace Identity
```powershell
$namespaceIdentity = @{
  SubscriptionId = "my-subscription-id"
  ResourceGroupName = "my-resource-group"
  NamespaceName = "my-namespace"
}
Get-AzDeviceRegistryNamespaceAsset -NamespaceInputObject $namespaceIdentity -AssetName "my-asset"
```

```output
AssetTypeRef                         :
Attribute                            : {
                                       }
Code                                 :
ConfigLastTransitionTime             :
ConfigVersion                        :
Dataset                              :
DefaultDatasetsConfiguration         :
DefaultDatasetsDestination           :
DefaultEventsConfiguration           :
DefaultEventsDestination             :
DefaultManagementGroupsConfiguration :
DefaultStreamsConfiguration          :
DefaultStreamsDestination            :
Description                          :
Detail                               :
DeviceRefDeviceName                  : myassetendpointprofile1
DeviceRefEndpointName                : primaryEndpoint
DiscoveredAssetRef                   :
DisplayName                          : test-asset-123
DocumentationUri                     :
Enabled                              : True
EventGroup                           :
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
ExternalAssetId                      : 63174c22-6858-4d69-b515-68b641ad537e
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/assets/my-asset
LastTransitionTime                   :
Location                             : eastus2
ManagementGroup                      :
Manufacturer                         :
ManufacturerUri                      :
Message                              :
Model                                :
Name                                 : my-asset
ProductCode                          :
ProvisioningState                    : Succeeded
ResourceGroupName                    : my-resource-group
SerialNumber                         :
SoftwareRevision                     :
StatusDataset                        :
StatusEventGroup                     :
StatusManagementGroup                :
StatusStream                         :
Stream                               :
SystemDataCreatedAt                  : 7/25/2025 5:48:47 AM
SystemDataCreatedBy                  : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType              : Application
SystemDataLastModifiedAt             : 7/25/2025 5:48:53 AM
SystemDataLastModifiedBy             : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType         : Application
Tag                                  : {
                                       }
Type                                 : microsoft.deviceregistry/namespaces/assets
Uuid                                 : 63174c22-6858-4d69-b515-68b641ad537e
Version                              : 2
```

Gets the details of a Namespace Asset using the parent Namespace's identity object.

### Example 3: Get Namespace Asset
```powershell
Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -AssetName "my-asset"
```

```output
AssetTypeRef                         :
Attribute                            : {
                                       }
Code                                 :
ConfigLastTransitionTime             :
ConfigVersion                        :
Dataset                              :
DefaultDatasetsConfiguration         :
DefaultDatasetsDestination           :
DefaultEventsConfiguration           :
DefaultEventsDestination             :
DefaultManagementGroupsConfiguration :
DefaultStreamsConfiguration          :
DefaultStreamsDestination            :
Description                          :
Detail                               :
DeviceRefDeviceName                  : myassetendpointprofile1
DeviceRefEndpointName                : primaryEndpoint
DiscoveredAssetRef                   :
DisplayName                          : test-asset-123
DocumentationUri                     :
Enabled                              : True
EventGroup                           :
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
ExternalAssetId                      : 63174c22-6858-4d69-b515-68b641ad537e
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/assets/my-asset
LastTransitionTime                   :
Location                             : eastus2
ManagementGroup                      :
Manufacturer                         :
ManufacturerUri                      :
Message                              :
Model                                :
Name                                 : my-asset
ProductCode                          :
ProvisioningState                    : Succeeded
ResourceGroupName                    : my-resource-group
SerialNumber                         :
SoftwareRevision                     :
StatusDataset                        :
StatusEventGroup                     :
StatusManagementGroup                :
StatusStream                         :
Stream                               :
SystemDataCreatedAt                  : 7/25/2025 5:48:47 AM
SystemDataCreatedBy                  : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType              : Application
SystemDataLastModifiedAt             : 7/25/2025 5:48:53 AM
SystemDataLastModifiedBy             : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType         : Application
Tag                                  : {
                                       }
Type                                 : microsoft.deviceregistry/namespaces/assets
Uuid                                 : 63174c22-6858-4d69-b515-68b641ad537e
Version                              : 2
```

Gets the details of a Namespace Asset under its parent Namespace.

### Example 4: Get Namespace Asset Via Identity
```powershell
$identity = @{
  SubscriptionId = "my-subscription"
  ResourceGroupName = "my-resource-group"
  NamespaceName = "my-namespace"
  AssetName = "my-asset"
}
Get-AzDeviceRegistryNamespaceAsset -InputObject $identity
```

```output
AssetTypeRef                         :
Attribute                            : {
                                       }
Code                                 :
ConfigLastTransitionTime             :
ConfigVersion                        :
Dataset                              :
DefaultDatasetsConfiguration         :
DefaultDatasetsDestination           :
DefaultEventsConfiguration           :
DefaultEventsDestination             :
DefaultManagementGroupsConfiguration :
DefaultStreamsConfiguration          :
DefaultStreamsDestination            :
Description                          :
Detail                               :
DeviceRefDeviceName                  : myassetendpointprofile1
DeviceRefEndpointName                : primaryEndpoint
DiscoveredAssetRef                   :
DisplayName                          : test-asset-123
DocumentationUri                     :
Enabled                              : True
EventGroup                           :
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
ExternalAssetId                      : 63174c22-6858-4d69-b515-68b641ad537e
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/assets/my-asset
LastTransitionTime                   :
Location                             : eastus2
ManagementGroup                      :
Manufacturer                         :
ManufacturerUri                      :
Message                              :
Model                                :
Name                                 : my-asset
ProductCode                          :
ProvisioningState                    : Succeeded
ResourceGroupName                    : my-resource-group
SerialNumber                         :
SoftwareRevision                     :
StatusDataset                        :
StatusEventGroup                     :
StatusManagementGroup                :
StatusStream                         :
Stream                               :
SystemDataCreatedAt                  : 7/25/2025 5:48:47 AM
SystemDataCreatedBy                  : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType              : Application
SystemDataLastModifiedAt             : 7/25/2025 5:48:53 AM
SystemDataLastModifiedBy             : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType         : Application
Tag                                  : {
                                       }
Type                                 : microsoft.deviceregistry/namespaces/assets
Uuid                                 : 63174c22-6858-4d69-b515-68b641ad537e
Version                              : 2
```

Gets a Namespace Asset via the asset's Identity object.

## PARAMETERS

### -AssetName
The name of the asset.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityNamespace, Get
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: GetViaIdentityNamespace
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceAsset

## NOTES

## RELATED LINKS
