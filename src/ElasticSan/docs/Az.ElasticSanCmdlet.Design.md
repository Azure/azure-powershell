#### New-AzElasticSan

#### SYNOPSIS
Create ElasticSan.

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzElasticSan -Name <String> -ResourceGroupName <String> -BaseSizeTiB <Int64>
 -ExtendedCapacitySizeTiB <Int64> -Location <String> -SkuName <String> [-SubscriptionId <String>]
 [-AvailabilityZone <String[]>] [-PublicNetworkAccess <String>] [-SkuTier <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityExpanded
```powershell
New-AzElasticSan -InputObject <IElasticSanIdentity> -BaseSizeTiB <Int64> -ExtendedCapacitySizeTiB <Int64>
 -Location <String> -SkuName <String> [-AvailabilityZone <String[]>] [-PublicNetworkAccess <String>]
 [-SkuTier <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create an Elastic SAN
```powershell
New-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan -BaseSizeTib 1 -ExtendedCapacitySizeTib 6 -Location eastus -SkuName 'Premium_LRS' -Tag @{tag1="value1";tag2="value2"}
```

```output
AvailabilityZone             : 
BaseSizeTiB                  : 1
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
Location                     : eastus
Name                         : myelasticsan
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      : 
SystemDataCreatedAt          : 9/19/2022 9:47:26 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 9/19/2022 9:47:26 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 5000
TotalMBps                    : 80
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 0
```

This command creates an Elastic SAN.


#### Get-AzElasticSan

#### SYNOPSIS
Get either a list of Elastic SANs from a subscription or a resource group, or get a single Elastic SAN.

#### SYNTAX

+ List (Default)
```powershell
Get-AzElasticSan [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzElasticSan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzElasticSan -InputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ List1
```powershell
Get-AzElasticSan -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get all Elastic SANs in a subscription
```powershell
Get-AzElasticSan
```

```output
AvailabilityZone             :
BaseSizeTiB                  : 1
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup
                               /providers/Microsoft.ElasticSan/elasticSans/myelasticsan1
Location                     : eastus
Name                         : myelasticsan1
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 9/19/2022 9:50:25 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 9/19/2022 9:50:25 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 5000
TotalMBps                    : 80
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 0

AvailabilityZone             :
BaseSizeTiB                  : 1
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Micr
                               osoft.ElasticSan/elasticSans/myelasticsan2
Location                     : eastus
Name                         : myelasticsan2
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 8/18/2022 8:42:21 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/18/2022 8:42:21 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 5000
TotalMBps                    : 80
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 100
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 7
```

This command gets all the Elastic SANs in a subscription.

+ Example 2: Get all Elastic Sans in a resource group
```powershell
Get-AzElasticSan -ResourceGroupName myresourcegroup
```

```output
AvailabilityZone             :
BaseSizeTiB                  : 1
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup
                               /providers/Microsoft.ElasticSan/elasticSans/myelasticsan1
Location                     : eastus
Name                         : myelasticsan1
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 9/19/2022 9:50:25 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 9/19/2022 9:50:25 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 5000
TotalMBps                    : 80
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 0

AvailabilityZone             :
BaseSizeTiB                  : 1
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Micr
                               osoft.ElasticSan/elasticSans/myelasticsan2
Location                     : eastus
Name                         : myelasticsan2
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 8/18/2022 8:42:21 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/18/2022 8:42:21 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 5000
TotalMBps                    : 80
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 100
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 7
```

This command gets all Elastic SANs in a resource group.

+ Example 3: Get a specific Elastic SAN
```powershell
Get-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan
```

```output
AvailabilityZone             :
BaseSizeTiB                  : 1
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Micr
                               osoft.ElasticSan/elasticSans/myelasticsan
Location                     : eastus
Name                         : myelasticsan
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 8/18/2022 8:42:21 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/18/2022 8:42:21 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 5000
TotalMBps                    : 80
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 100
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 7
```

This command gets a specific Elastic SAN.


#### Remove-AzElasticSan

#### SYNOPSIS
Delete a Elastic San.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzElasticSan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzElasticSan -InputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove a specific Elastic SAN
```powershell
Remove-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan 
```

This command removes a specific Elastic SAN.


#### Update-AzElasticSan

#### SYNOPSIS
Update a Elastic San.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzElasticSan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BaseSizeTiB <Int64>] [-ExtendedCapacitySizeTiB <Int64>] [-PublicNetworkAccess <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzElasticSan -InputObject <IElasticSanIdentity> [-BaseSizeTiB <Int64>]
 [-ExtendedCapacitySizeTiB <Int64>] [-PublicNetworkAccess <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update an Elastic SAN
```powershell
$elasticSan = Update-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan -BaseSizeTib 64 -ExtendedCapacitySizeTib 128 -Tag @{"tag3" = "value3"}
```

```output
AvailabilityZone             : 
BaseSizeTiB                  : 64
ExtendedCapacitySizeTiB      : 128
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
Location                     : eastus
Name                         : myelasticsan
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      : 
SystemDataCreatedAt          : 8/16/2022 4:59:54 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/16/2022 4:59:54 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 320000
TotalMBps                    : 5120
TotalSizeTiB                 : 192
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 0
```

This command updates the BaseSizeTib, ExtendedCapacitySizeTib, and Tag properties of an Elastic SAN.


#### Get-AzElasticSanSkuList

#### SYNOPSIS
List all the available Skus in the region and information related to them

#### SYNTAX

```powershell
Get-AzElasticSanSkuList [-SubscriptionId <String[]>] [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get all the available Skus 
```powershell
Get-AzElasticSanSkuList
```

```output
Location      Name           ResourceType Tier   
--------      ----           ------------ ----   
{eastus}      Premium_LRS    elasticSans  Premium
{eastus2}     Premium_LRS    elasticSans  Premium
```

This command gets all the available Skus.


#### New-AzElasticSanVirtualNetworkRuleObject

#### SYNOPSIS
Create an in-memory object for VirtualNetworkRule.

#### SYNTAX

```powershell
New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId <String> [-Action <String>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a virtual network rule object 
```powershell
New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
```

```output
Action State VirtualNetworkResourceId                                                                                                                       
------ ----- ------------------------                                                                                                                       
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1
```

This command creates a new virtual network rule object using the virtual network resource Id.


#### New-AzElasticSanVolume

#### SYNOPSIS
Create a Volume.

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzElasticSanVolume -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 -VolumeGroupName <String> -SizeGiB <Int64> [-SubscriptionId <String>] [-CreationDataCreateSource <String>]
 [-CreationDataSourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ CreateViaIdentityElasticSanExpanded
```powershell
New-AzElasticSanVolume -ElasticSanInputObject <IElasticSanIdentity> -Name <String> -VolumeGroupName <String>
 -SizeGiB <Int64> [-CreationDataCreateSource <String>] [-CreationDataSourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityExpanded
```powershell
New-AzElasticSanVolume -InputObject <IElasticSanIdentity> -SizeGiB <Int64>
 [-CreationDataCreateSource <String>] [-CreationDataSourceId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityVolumegroupExpanded
```powershell
New-AzElasticSanVolume -Name <String> -VolumegroupInputObject <IElasticSanIdentity> -SizeGiB <Int64>
 [-CreationDataCreateSource <String>] [-CreationDataSourceId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a volume
```powershell
New-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name myvolumegroup -SizeGib 100  -CreationDataSourceUri 'https://abc.com' 
```

```output
CreationDataCreateSource       : 
CreationDataSourceUri          : https://abc.com
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup/volumes/myvolume
Name                           : myvolume
SizeGiB                        : 100
StorageTargetIqn               : iqn.2022-09.net.windows.core.blob.ElasticSan.es-3ibot5m2r3y0:myvolume
StorageTargetPortalHostname    : es-3ibot5m2r3y0.z1.blob.storage.azure.net
StorageTargetPortalPort        : 3260
StorageTargetProvisioningState : Succeeded
StorageTargetStatus            : Running
SystemDataCreatedAt            : 9/19/2022 2:39:28 AM
SystemDataCreatedBy            : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType        : Application
SystemDataLastModifiedAt       : 9/19/2022 2:39:28 AM
SystemDataLastModifiedBy       : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType   : Application
Type                           : Microsoft.ElasticSan/ElasticSans
VolumeId                       : abababab-abab-abab-abab-abababababab
```

This command creates a volume.


#### Get-AzElasticSanVolume

#### SYNOPSIS
Get either a list of all volumes from a volume group or get a single volume from a volume group.

#### SYNTAX

+ List (Default)
```powershell
Get-AzElasticSanVolume -ElasticSanName <String> -ResourceGroupName <String> -VolumeGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzElasticSanVolume -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 -VolumeGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzElasticSanVolume -InputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentityElasticSan
```powershell
Get-AzElasticSanVolume -ElasticSanInputObject <IElasticSanIdentity> -Name <String> -VolumeGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentityVolumegroup
```powershell
Get-AzElasticSanVolume -Name <String> -VolumegroupInputObject <IElasticSanIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get all volumes in a volume group
```powershell
Get-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup
```

```output
CreationDataCreateSource       : 
CreationDataSourceUri          : 
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup/volumes/myvolume1
Name                           : myvolume1
SizeGiB                        : 120
StorageTargetIqn               : iqn.2022-09.net.windows.core.blob.ElasticSan.es-3ibot5m2r3y0:myvolume1
StorageTargetPortalHostname    : es-3ibot5m2r3y0.z1.blob.storage.azure.net
StorageTargetPortalPort        : 3260
StorageTargetProvisioningState : Succeeded
StorageTargetStatus            : Running
SystemDataCreatedAt            : 9/19/2022 2:39:28 AM
SystemDataCreatedBy            : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType        : Application
SystemDataLastModifiedAt       : 9/19/2022 2:39:28 AM
SystemDataLastModifiedBy       : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType   : Application
Tag                            : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
Type                           : Microsoft.ElasticSan/ElasticSans
VolumeId                       : abababab-abab-abab-abab-abababababab

CreationDataCreateSource       : 
CreationDataSourceUri          : 
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup/volumes/myvolume2
Name                           : myvolume2
SizeGiB                        : 100
StorageTargetIqn               : iqn.2022-09.net.windows.core.blob.ElasticSan.es-3ibot5m2r3y0:myvolume2
StorageTargetPortalHostname    : es-3ibot5m2r3y0.z1.blob.storage.azure.net
StorageTargetPortalPort        : 3260
StorageTargetProvisioningState : Succeeded
StorageTargetStatus            : Running
SystemDataCreatedAt            : 9/19/2022 2:39:28 AM
SystemDataCreatedBy            : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType        : Application
SystemDataLastModifiedAt       : 9/19/2022 2:39:28 AM
SystemDataLastModifiedBy       : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType   : Application
Tag                            : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
Type                           : Microsoft.ElasticSan/ElasticSans
VolumeId                       : cdcdcdcd-cdcd-cdcd-cdcd-cdcdcdcdcdcd
```

This command gets all the volumes in a volume group.

+ Example 2: Get a specific volume 
```powershell
Get-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name myvolume
```

```output
CreationDataCreateSource       : 
CreationDataSourceUri          : 
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup/volumes/myvolume
Name                           : myvolume
SizeGiB                        : 100
StorageTargetIqn               : iqn.2022-09.net.windows.core.blob.ElasticSan.es-3ibot5m2r3y0:myvolume
StorageTargetPortalHostname    : es-3ibot5m2r3y0.z1.blob.storage.azure.net
StorageTargetPortalPort        : 3260
StorageTargetProvisioningState : Succeeded
StorageTargetStatus            : Running
SystemDataCreatedAt            : 9/19/2022 2:39:28 AM
SystemDataCreatedBy            : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType        : Application
SystemDataLastModifiedAt       : 9/19/2022 2:39:28 AM
SystemDataLastModifiedBy       : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType   : Application
Tag                            : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
Type                           : Microsoft.ElasticSan/ElasticSans
VolumeId                       : abababab-abab-abab-abab-abababababab
```

This command gets a specific volume.


#### Remove-AzElasticSanVolume

#### SYNOPSIS
Delete an Volume.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzElasticSanVolume -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 -VolumeGroupName <String> [-SubscriptionId <String>] [-XmsDeleteSnapshot <String>] [-XmsForceDelete <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzElasticSanVolume -InputObject <IElasticSanIdentity> [-XmsDeleteSnapshot <String>]
 [-XmsForceDelete <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentityElasticSan
```powershell
Remove-AzElasticSanVolume -ElasticSanInputObject <IElasticSanIdentity> -Name <String>
 -VolumeGroupName <String> [-XmsDeleteSnapshot <String>] [-XmsForceDelete <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityVolumegroup
```powershell
Remove-AzElasticSanVolume -Name <String> -VolumegroupInputObject <IElasticSanIdentity>
 [-XmsDeleteSnapshot <String>] [-XmsForceDelete <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove a volume 
```powershell
Remove-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name myvolume
```

This command removes a volume.


#### Update-AzElasticSanVolume

#### SYNOPSIS
Update an Volume.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzElasticSanVolume -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 -VolumeGroupName <String> [-SubscriptionId <String>] [-SizeGiB <Int64>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityElasticSanExpanded
```powershell
Update-AzElasticSanVolume -ElasticSanInputObject <IElasticSanIdentity> -Name <String>
 -VolumeGroupName <String> [-SizeGiB <Int64>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzElasticSanVolume -InputObject <IElasticSanIdentity> [-SizeGiB <Int64>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityVolumegroupExpanded
```powershell
Update-AzElasticSanVolume -Name <String> -VolumegroupInputObject <IElasticSanIdentity> [-SizeGiB <Int64>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update an Elastic SAN volume
```powershell
$volume = Update-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name myvolume -SizeGib 120
```

```output
CreationDataCreateSource       : 
CreationDataSourceUri          : 
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup/volumes/myvolume
Name                           : myvolume
SizeGiB                        : 120
StorageTargetIqn               : iqn.2022-09.net.windows.core.blob.ElasticSan.es-3ibot5m2r3y0:myvolume
StorageTargetPortalHostname    : es-3ibot5m2r3y0.z1.blob.storage.azure.net
StorageTargetPortalPort        : 3260
StorageTargetProvisioningState : Succeeded
StorageTargetStatus            : Running
SystemDataCreatedAt            : 9/19/2022 2:39:28 AM
SystemDataCreatedBy            : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType        : Application
SystemDataLastModifiedAt       : 9/19/2022 2:39:28 AM
SystemDataLastModifiedBy       : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType   : Application
Type                           : Microsoft.ElasticSan/ElasticSans
VolumeId                       : abababab-abab-abab-abab-abababababab
```

This command updates the SizeGib and Tag properties of a volume.


#### New-AzElasticSanVolumeGroup

#### SYNOPSIS
Create a Volume Group.

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzElasticSanVolumeGroup -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Encryption <String>] [-EncryptionUserAssignedIdentity <String>]
 [-IdentityType <String>] [-IdentityUserAssignedIdentityId <String>] [-KeyName <String>]
 [-KeyVaultUri <String>] [-KeyVersion <String>] [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>]
 [-ProtocolType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ CreateViaIdentityElasticSanExpanded
```powershell
New-AzElasticSanVolumeGroup -ElasticSanInputObject <IElasticSanIdentity> -Name <String> [-Encryption <String>]
 [-EncryptionUserAssignedIdentity <String>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentityId <String>] [-KeyName <String>] [-KeyVaultUri <String>] [-KeyVersion <String>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-ProtocolType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityExpanded
```powershell
New-AzElasticSanVolumeGroup -InputObject <IElasticSanIdentity> [-Encryption <String>]
 [-EncryptionUserAssignedIdentity <String>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentityId <String>] [-KeyName <String>] [-KeyVaultUri <String>] [-KeyVersion <String>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-ProtocolType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a volume group with network rule objects 
```powershell
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow

New-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi' -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2
```

```output
Encryption                    : EncryptionAtRestWithPlatformKey
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                          : myvolumegroup
NetworkAclsVirtualNetworkRule : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                  : iSCSI
ProvisioningState             : Succeeded
SystemDataCreatedAt           : 9/19/2022 7:05:47 AM
SystemDataCreatedBy           : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType       : Application
SystemDataLastModifiedAt      : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy      : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType  : Application
Type                          : Microsoft.ElasticSan/ElasticSans
```

This example creates two VirtualNetworkRule objects and then input the objects and other variables to create a volume group.

+ Example 2: Create a volume group with network rule JSON input 
```powershell
New-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi' `
            -NetworkAclsVirtualNetworkRule (
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1";
                    Action="Allow"},
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2";
                    Action="Allow"})
```

```output
Encryption                    : EncryptionAtRestWithPlatformKey
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                          : myvolumegroup
NetworkAclsVirtualNetworkRule : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                  : iSCSI
ProvisioningState             : Succeeded
SystemDataCreatedAt           : 9/19/2022 7:05:47 AM
SystemDataCreatedBy           : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType       : Application
SystemDataLastModifiedAt      : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy      : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType  : Application
Type                          : Microsoft.ElasticSan/ElasticSans
```

This command creates a volume group with the NetworkAclsVirtualNetworkRule input in json format.

+ Example 3: Create a volume group with platform-managed key and SystemAssigned identity type 
```powershell
New-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -IdentityType SystemAssigned -ProtocolType Iscsi -Encryption EncryptionAtRestWithPlatformKey
```

```output
Encryption                                             : EncryptionAtRestWithPlatformKey
EncryptionIdentityEncryptionUserAssignedIdentity       :
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    : 00000000-0000-0000-0000-000000000000
IdentityTenantId                                       : 00000000-0000-0000-0000-000000000000
IdentityType                                           : SystemAssigned
IdentityUserAssignedIdentity                           : {
                                                         }
KeyVaultPropertyCurrentVersionedKeyExpirationTimestamp :
KeyVaultPropertyCurrentVersionedKeyIdentifier          :
KeyVaultPropertyKeyName                                :
KeyVaultPropertyKeyVaultUri                            :
KeyVaultPropertyKeyVersion                             :
KeyVaultPropertyLastKeyRotationTimestamp               :
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          :
PrivateEndpointConnection                              :
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 10/7/2023 6:20:55 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 10/7/2023 6:20:55 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command creates a volume group with identity type "SystemAssigned" and encryption type "platform-managed key".

+ Example 4: Create a volume group with platform-managed key and SystemAssigned identity type 
```powershell
$useridentity = Get-AzUserAssignedIdentity -ResourceGroupName myresoucegroup -Name myuai

New-AzElasticSanVolumeGroup -ResourceGroupName myresoucegroup -ElasticSanName myelasticsan -Name myvolumegroup -IdentityType UserAssigned -IdentityUserAssignedIdentity $useridentity.Id -Encryption EncryptionAtRestWithCustomerManagedKey -KeyName mykey -KeyVaultUri "https://mykeyvault.vault.azure.net:443" -EncryptionUserAssignedIdentity $useridentity.Id -ProtocolType Iscsi
```

```output
Encryption                                             : EncryptionAtRestWithCustomerManagedKey
EncryptionIdentityEncryptionUserAssignedIdentity       : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           : UserAssigned
IdentityUserAssignedIdentity                           : {
                                                           "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai": {
                                                           }
                                                         }
KeyVaultPropertyCurrentVersionedKeyExpirationTimestamp : 1/1/1970 12:00:00 AM
KeyVaultPropertyCurrentVersionedKeyIdentifier          : https://mykeyvault.vault.azure.net/keys/mykey/37ec78b20f9e4a29b14a0d29d93cb79f
KeyVaultPropertyKeyName                                : mykey
KeyVaultPropertyKeyVaultUri                            : https://mykeyvault.vault.azure.net:443
KeyVaultPropertyKeyVersion                             :
KeyVaultPropertyLastKeyRotationTimestamp               : 10/7/2023 6:32:28 AM
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          :
PrivateEndpointConnection                              :
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 10/7/2023 6:32:27 AM
SystemDataCreatedBy                                    : a000255f-5f09-45e0-a970-9d9ed9cc6453
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 10/7/2023 6:32:27 AM
SystemDataLastModifiedBy                               : a000255f-5f09-45e0-a970-9d9ed9cc6453
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command creates a volume group with identity type "SystemAssigned" and encryption type "platform-managed key".


#### Get-AzElasticSanVolumeGroup

#### SYNOPSIS
Get either a list of all volume groups from an Elastic SAN or get a single volume group from an Elastic SAN.

#### SYNTAX

+ List (Default)
```powershell
Get-AzElasticSanVolumeGroup -ElasticSanName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzElasticSanVolumeGroup -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzElasticSanVolumeGroup -InputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityElasticSan
```powershell
Get-AzElasticSanVolumeGroup -ElasticSanInputObject <IElasticSanIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get all volume groups in an Elastic SAN
```powershell
Get-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan
```

```output
Encryption                    : EncryptionAtRestWithPlatformKey
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup1
Name                          : myvolumegroup1
NetworkAclsVirtualNetworkRule : 
ProtocolType                  : iSCSI
ProvisioningState             : Succeeded
SystemDataCreatedAt           : 8/18/2022 8:43:35 AM
SystemDataCreatedBy           : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType       : Application
SystemDataLastModifiedAt      : 8/18/2022 8:43:35 AM
SystemDataLastModifiedBy      : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType  : Application
Tag                           : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
Type                          : Microsoft.ElasticSan/ElasticSans

Encryption                    : EncryptionAtRestWithPlatformKey
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup2
Name                          : myvolumegroup2
NetworkAclsVirtualNetworkRule : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet3, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet4, 
                                /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                  : iSCSI
ProvisioningState             : Succeeded
SystemDataCreatedAt           : 9/20/2022 2:37:33 AM
SystemDataCreatedBy           : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType       : Application
SystemDataLastModifiedAt      : 9/20/2022 2:37:33 AM
SystemDataLastModifiedBy      : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType  : Application
Tag                           : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
Type                          : Microsoft.ElasticSan/ElasticSans
```

This command gets all the volume groups in the Elastic SAN myelasticsan.

+ Example 2: Get a specific volume group
```powershell
Get-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup
```

```output
Encryption                    : EncryptionAtRestWithPlatformKey
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                          : myvolumegroup
NetworkAclsVirtualNetworkRule : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                  : iSCSI
ProvisioningState             : Succeeded
SystemDataCreatedAt           : 9/19/2022 7:05:47 AM
SystemDataCreatedBy           : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType       : Application
SystemDataLastModifiedAt      : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy      : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType  : Application
Tag                           : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
Type                          : Microsoft.ElasticSan/ElasticSans
```

This command gets a specific volume group.


#### Remove-AzElasticSanVolumeGroup

#### SYNOPSIS
Delete an VolumeGroup.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzElasticSanVolumeGroup -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzElasticSanVolumeGroup -InputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityElasticSan
```powershell
Remove-AzElasticSanVolumeGroup -ElasticSanInputObject <IElasticSanIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove a volume group
```powershell
Remove-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup
```

This command removes a specific volume group.


#### Update-AzElasticSanVolumeGroup

#### SYNOPSIS
Update an VolumeGroup.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzElasticSanVolumeGroup -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Encryption <String>] [-EncryptionUserAssignedIdentity <String>]
 [-IdentityType <String>] [-IdentityUserAssignedIdentityId <String>] [-KeyName <String>]
 [-KeyVaultUri <String>] [-KeyVersion <String>] [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>]
 [-ProtocolType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateViaIdentityElasticSanExpanded
```powershell
Update-AzElasticSanVolumeGroup -ElasticSanInputObject <IElasticSanIdentity> -Name <String>
 [-Encryption <String>] [-EncryptionUserAssignedIdentity <String>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentityId <String>] [-KeyName <String>] [-KeyVaultUri <String>] [-KeyVersion <String>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-ProtocolType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzElasticSanVolumeGroup -InputObject <IElasticSanIdentity> [-Encryption <String>]
 [-EncryptionUserAssignedIdentity <String>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentityId <String>] [-KeyName <String>] [-KeyVaultUri <String>] [-KeyVersion <String>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-ProtocolType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update a volume group
```powershell
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow

Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi' -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2
```

```output
Encryption                    : EncryptionAtRestWithPlatformKey
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                          : myvolumegroup
NetworkAclsVirtualNetworkRule : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                  : iSCSI
ProvisioningState             : Succeeded
SystemDataCreatedAt           : 9/19/2022 7:05:47 AM
SystemDataCreatedBy           : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType       : Application
SystemDataLastModifiedAt      : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy      : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType  : Application
Type                          : Microsoft.ElasticSan/ElasticSans
```

This example updates the protocol type and virtual network rules of a volume gorup

+ Example 2: Update a volume group virtual network rule with JSON input 
```powershell
Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi'`
            -NetworkAclsVirtualNetworkRule (
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1";
                    Action="Allow"},
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2";
                    Action="Allow"})
```

```output
Encryption                    : EncryptionAtRestWithPlatformKey
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                          : myvolumegroup
NetworkAclsVirtualNetworkRule : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                  : iSCSI
ProvisioningState             : Succeeded
SystemDataCreatedAt           : 9/19/2022 7:05:47 AM
SystemDataCreatedBy           : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType       : Application
SystemDataLastModifiedAt      : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy      : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType  : Application
Type                          : Microsoft.ElasticSan/ElasticSans
```

This example updates the protocol type, virtual network rules, and tag of a volume group.
It takes in the virtual network rules in JSON format.

+ Example 3: Update a volume group from CMK to PMK 
```powershell
Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -Encryption EncryptionAtRestWithPlatformKey
```

```output
Encryption                                             : EncryptionAtRestWithPlatformKey
EncryptionIdentityEncryptionUserAssignedIdentity       :
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           : UserAssigned
IdentityUserAssignedIdentity                           : {
                                                           "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/yifanz1/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai": {
                                                           }
                                                         }
KeyVaultPropertyCurrentVersionedKeyExpirationTimestamp :
KeyVaultPropertyCurrentVersionedKeyIdentifier          :
KeyVaultPropertyKeyName                                :
KeyVaultPropertyKeyVaultUri                            :
KeyVaultPropertyKeyVersion                             :
KeyVaultPropertyLastKeyRotationTimestamp               :
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          :
PrivateEndpointConnection                              :
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 10/7/2023 2:31:45 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 10/7/2023 6:47:24 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command updates a volume group from CMK to PMK.

+ Example 4: Update a volume group to a new user assigned identity
```powershell
$useridentity2 = Get-AzUserAssignedIdentity -ResourceGroupName myresoucegroup -Name myuai2

Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -IdentityType UserAssigned -IdentityUserAssignedIdentityId $useridentity2.Id -EncryptionUserAssignedIdentity $useridentity2.Id
```

```output
Encryption                                             : EncryptionAtRestWithCustomerManagedKey
EncryptionIdentityEncryptionUserAssignedIdentity       : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai2
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           : UserAssigned
IdentityUserAssignedIdentity                           : {
                                                           "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai2": {
                                                           }
                                                         }
KeyVaultPropertyCurrentVersionedKeyExpirationTimestamp : 1/1/1970 12:00:00 AM
KeyVaultPropertyCurrentVersionedKeyIdentifier          : https://mykeyvault.vault.azure.net/keys/mykey/37ec78b20f9e4a29b14a0d29d93cb79f
KeyVaultPropertyKeyName                                : mykey
KeyVaultPropertyKeyVaultUri                            : https://mykeyvault.vault.azure.net:443
KeyVaultPropertyKeyVersion                             :
KeyVaultPropertyLastKeyRotationTimestamp               : 10/7/2023 7:03:27 AM
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          :
PrivateEndpointConnection                              :
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 10/7/2023 6:32:27 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 10/7/2023 7:03:27 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command updates a volume group's user assigned identity.


#### Add-AzElasticSanVolumeGroupNetworkRule

#### SYNOPSIS
Add a list of virtual network rules to a VolumeGroup

#### SYNTAX

+ NetworkRuleObject (Default)
```powershell
Add-AzElasticSanVolumeGroupNetworkRule -ElasticSanName <String> -ResourceGroupName <String>
 -VolumeGroupName <String> -NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ NetworkRuleResourceId
```powershell
Add-AzElasticSanVolumeGroupNetworkRule -ElasticSanName <String> -ResourceGroupName <String>
 -VolumeGroupName <String> -NetworkAclsVirtualNetworkResourceId <String[]> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Add network rules to a volume group by NetworkAclsVirtualNetworkRule objects 
```powershell
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow

Add-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2
```

```output
Action State VirtualNetworkResourceId                                                                                                                       
------ ----- ------------------------                                                                                                                       
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2
```

This example creates two NetworkAclsVirtualNetworkRule objects using virtual network resource Ids, and then adds the network rules to a volume group.
The command outputs all the network rule objects in the volume group after the addition operation.

+ Example 2: Add network rules to a volume group by resource Ids
```powershell
$virtualNetworkResourceId1 = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1"
$virtualNetworkResourceId2 = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2"

Add-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -NetworkAclsVirtualNetworkResourceId $virtualNetworkResourceId1,$virtualNetworkResourceId2
```

```output
Action State VirtualNetworkResourceId                                                                                                                       
------ ----- ------------------------                                                                                                                       
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2
```

This example adds two virtual network rules to a volume group using the network rule resource Ids.
The command outputs all the network rule objects in the volume group after the addition operation.


#### Remove-AzElasticSanVolumeGroupNetworkRule

#### SYNOPSIS
Remove a list of virtual network rules from a VolumeGroup

#### SYNTAX

+ NetworkRuleObject (Default)
```powershell
Remove-AzElasticSanVolumeGroupNetworkRule -ElasticSanName <String> -ResourceGroupName <String>
 -VolumeGroupName <String> -NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ NetworkRuleResourceId
```powershell
Remove-AzElasticSanVolumeGroupNetworkRule -ElasticSanName <String> -ResourceGroupName <String>
 -VolumeGroupName <String> -NetworkAclsVirtualNetworkResourceId <String[]> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove network rules by NetworkAclsVirtualNetworkRule objects  
```powershell
#### Initialze network rule objects 
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow
$virtualNetworkRule3 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet3" -Action Allow
#### Add the network rule objects to the volume group
$rules = Add-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2,$virtualNetworkRule3

#### Remove some of the network rules from the volume group
Remove-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2
```

```output
Action State VirtualNetworkResourceId                                                                                                                       
------ ----- ------------------------                                                                                                                       
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet3
```

This example adds 3 network rules to a volume group, and then remove 2 of the network rules from the volume group by inputting network rule objects.
The command outputs all the network rule objects left in the volume group after the removal.

+ Example 2: Remove network rules by network rule resource Ids
```powershell
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow
$virtualNetworkRule3 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet3" -Action Allow
$virtualNetworkRuleResourceId1 = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1"
$virtualNetworkRuleResourceId2 = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2"
#### Update the volume group to contain the network rules 
$volGroup = Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2,$virtualNetworkRule3

#### Remove some of the network rules from the volume group
Remove-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -NetworkAclsVirtualNetworkResourceId $virtualNetworkRuleResourceId1,$virtualNetworkRuleResourceId2
```

```output
Action State VirtualNetworkResourceId                                                                                                                       
------ ----- ------------------------                                                                                                                       
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet3
```

This example adds 3 network rules to a volume group, and then remove 2 of the network rules from the volume group by inputting network rule resource Ids.
The command outputs all the network rule objects left in the volume group after the removal.


#### New-AzElasticSanVolumeSnapshot

#### SYNOPSIS
Create a Volume Snapshot.

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzElasticSanVolumeSnapshot -ElasticSanName <String> -ResourceGroupName <String> -SnapshotName <String>
 -VolumeGroupName <String> -CreationDataSourceId <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityElasticSanExpanded
```powershell
New-AzElasticSanVolumeSnapshot -ElasticSanInputObject <IElasticSanIdentity> -SnapshotName <String>
 -VolumeGroupName <String> -CreationDataSourceId <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityExpanded
```powershell
New-AzElasticSanVolumeSnapshot -InputObject <IElasticSanIdentity> -CreationDataSourceId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityVolumegroupExpanded
```powershell
New-AzElasticSanVolumeSnapshot -SnapshotName <String> -VolumegroupInputObject <IElasticSanIdentity>
 -CreationDataSourceId <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a volume snapshot 
```powershell
 $volume = New-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name myvolume -SizeGiB 1
 New-AzElasticSanVolumeSnapshot -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -CreationDataSourceId $volume.Id -SnapshotName mysnapshot
```

```output
CreationDataSourceId         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/volumes/myvolume
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/snapshots/mysnapshot
Name                         : mysnapshot
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
SourceVolumeSizeGiB          : 1
SystemDataCreatedAt          : 10/7/2023 3:37:01 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 10/7/2023 3:37:01 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : Microsoft.ElasticSan/elasticSans/volumeGroups/snapshots
VolumeName                   : testvol1
```

The first command creates a volume, and the second command creates a snapshot of the volume.


#### Get-AzElasticSanVolumeSnapshot

#### SYNOPSIS
Get a Volume Snapshot.

#### SYNTAX

+ List (Default)
```powershell
Get-AzElasticSanVolumeSnapshot -ElasticSanName <String> -ResourceGroupName <String> -VolumeGroupName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzElasticSanVolumeSnapshot -ElasticSanName <String> -ResourceGroupName <String> -SnapshotName <String>
 -VolumeGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzElasticSanVolumeSnapshot -InputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityElasticSan
```powershell
Get-AzElasticSanVolumeSnapshot -ElasticSanInputObject <IElasticSanIdentity> -SnapshotName <String>
 -VolumeGroupName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentityVolumegroup
```powershell
Get-AzElasticSanVolumeSnapshot -SnapshotName <String> -VolumegroupInputObject <IElasticSanIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List snapshots under a volume group 
```powershell
Get-AzElasticSanVolumeSnapshot -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup
```

```output
CreationDataSourceId         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/volumes/myvolume
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/snapshots/mysnap1
Name                         : mysnap1
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
SourceVolumeSizeGiB          : 1
SystemDataCreatedAt          : 10/7/2023 3:37:01 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 10/7/2023 3:37:01 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : Microsoft.ElasticSan/elasticSans/volumeGroups/snapshots
VolumeName                   : myvolume

CreationDataSourceId         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/volumes/myvolume
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/snapshots/mysnap2
Name                         : mysnap2
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
SourceVolumeSizeGiB          : 1
SystemDataCreatedAt          : 10/7/2023 4:06:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 10/7/2023 4:06:13 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : Microsoft.ElasticSan/elasticSans/volumeGroups/snapshots
VolumeName                   : myvolume
```

This command lists all snapshots under a volume group.

+ Example 2: Get a specific snapshot
```powershell
 Get-AzElasticSanVolumeSnapshot -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -SnapshotName mysnap1
```

```output
CreationDataSourceId         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/volumes/myvolume
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/snapshots/mysnap1
Name                         : mysnap1
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
SourceVolumeSizeGiB          : 1
SystemDataCreatedAt          : 10/7/2023 3:37:01 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 10/7/2023 3:37:01 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : Microsoft.ElasticSan/elasticSans/volumeGroups/snapshots
VolumeName                   : myvolume
```

This command gets a snapshot named "mysnap1" under the volume group "myvolumegroup"

+ Example 3: List snapshots of a volume with filter 
```powershell
Get-AzElasticSanVolumeSnapshot -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Filter 'volumeName eq myvolume'
```

```output
CreationDataSourceId         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/volumes/myvolume
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/snapshots/mysnap1
Name                         : mysnap1
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
SourceVolumeSizeGiB          : 1
SystemDataCreatedAt          : 10/7/2023 3:37:01 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 10/7/2023 3:37:01 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : Microsoft.ElasticSan/elasticSans/volumeGroups/snapshots
VolumeName                   : myvolume

CreationDataSourceId         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/volumes/myvolume
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/snapshots/mysnap2
Name                         : mysnap2
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
SourceVolumeSizeGiB          : 1
SystemDataCreatedAt          : 10/7/2023 4:06:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 10/7/2023 4:06:13 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : Microsoft.ElasticSan/elasticSans/volumeGroups/snapshots
VolumeName                   : myvolume
```

This command lists snapshots of volume "myvolume" under volume group "myvolumegroup".


#### Remove-AzElasticSanVolumeSnapshot

#### SYNOPSIS
Delete a Volume Snapshot.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzElasticSanVolumeSnapshot -ElasticSanName <String> -ResourceGroupName <String> -SnapshotName <String>
 -VolumeGroupName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzElasticSanVolumeSnapshot -InputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityElasticSan
```powershell
Remove-AzElasticSanVolumeSnapshot -ElasticSanInputObject <IElasticSanIdentity> -SnapshotName <String>
 -VolumeGroupName <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentityVolumegroup
```powershell
Remove-AzElasticSanVolumeSnapshot -SnapshotName <String> -VolumegroupInputObject <IElasticSanIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove a snapshot
```powershell
Remove-AzElasticSanVolumeSnapshot -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -SnapshotName mysnap1
```

This command removes a snapshot.


