#### New-AzConnectedVMwarevSphereCluster

#### SYNOPSIS
Create Or Update cluster.

#### SYNTAX

```powershell
New-AzConnectedVMwarevSphereCluster -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-InventoryItemId <String>] [-Kind <String>] [-MoRefId <String>] [-Tag <Hashtable>] [-VCenterId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwarevSphereCluster

#### SYNOPSIS
Implements cluster GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwarevSphereCluster [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwarevSphereCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwarevSphereCluster -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwarevSphereCluster -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwarevSphereCluster

#### SYNOPSIS
Implements cluster DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwarevSphereCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDelete] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwarevSphereCluster -InputObject <IConnectedVMwarevSphereIdentity> [-ForceDelete]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwarevSphereCluster

#### SYNOPSIS
API to update certain properties of the cluster resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwarevSphereCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwarevSphereCluster -InputObject <IConnectedVMwarevSphereIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwarevSphereDatastore

#### SYNOPSIS
Create Or Update datastore.

#### SYNTAX

```powershell
New-AzConnectedVMwarevSphereDatastore -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-InventoryItemId <String>] [-Kind <String>] [-MoRefId <String>] [-Tag <Hashtable>] [-VCenterId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwarevSphereDatastore

#### SYNOPSIS
Implements datastore GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwarevSphereDatastore [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwarevSphereDatastore -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwarevSphereDatastore -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwarevSphereDatastore -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwarevSphereDatastore

#### SYNOPSIS
Implements datastore DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwarevSphereDatastore -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDelete] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwarevSphereDatastore -InputObject <IConnectedVMwarevSphereIdentity> [-ForceDelete]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwarevSphereDatastore

#### SYNOPSIS
API to update certain properties of the datastore resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwarevSphereDatastore -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwarevSphereDatastore -InputObject <IConnectedVMwarevSphereIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwarevSphereGuestAgent

#### SYNOPSIS
Create Or Update GuestAgent.

#### SYNTAX

```powershell
New-AzConnectedVMwarevSphereGuestAgent -Name <String> -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String>] [-CredentialsPassword <SecureString>] [-CredentialsUsername <String>]
 [-HttpProxyConfigHttpsProxy <String>] [-ProvisioningAction <ProvisioningAction>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwarevSphereGuestAgent

#### SYNOPSIS
Implements GuestAgent GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwarevSphereGuestAgent -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwarevSphereGuestAgent -Name <String> -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwarevSphereGuestAgent -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwarevSphereGuestAgent

#### SYNOPSIS
Implements GuestAgent DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwarevSphereGuestAgent -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwarevSphereGuestAgent -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwarevSphereHost

#### SYNOPSIS
Create Or Update host.

#### SYNTAX

```powershell
New-AzConnectedVMwarevSphereHost -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-InventoryItemId <String>] [-Kind <String>] [-MoRefId <String>] [-Tag <Hashtable>] [-VCenterId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwarevSphereHost

#### SYNOPSIS
Implements host GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwarevSphereHost [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwarevSphereHost -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwarevSphereHost -InputObject <IConnectedVMwarevSphereIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwarevSphereHost -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwarevSphereHost

#### SYNOPSIS
Implements host DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwarevSphereHost -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDelete] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwarevSphereHost -InputObject <IConnectedVMwarevSphereIdentity> [-ForceDelete]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwarevSphereHost

#### SYNOPSIS
API to update certain properties of the host resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwarevSphereHost -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwarevSphereHost -InputObject <IConnectedVMwarevSphereIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwarevSphereHybridIdentityMetadata

#### SYNOPSIS
Create Or Update HybridIdentityMetadata.

#### SYNTAX

```powershell
New-AzConnectedVMwarevSphereHybridIdentityMetadata -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String>] [-PublicKey <String>] [-VMId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwarevSphereHybridIdentityMetadata

#### SYNOPSIS
Implements HybridIdentityMetadata GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwarevSphereHybridIdentityMetadata -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwarevSphereHybridIdentityMetadata -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwarevSphereHybridIdentityMetadata -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwarevSphereHybridIdentityMetadata

#### SYNOPSIS
Implements HybridIdentityMetadata DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwarevSphereHybridIdentityMetadata -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwarevSphereHybridIdentityMetadata -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwarevSphereInventoryItem

#### SYNOPSIS
Create Or Update InventoryItem.

#### SYNTAX

```powershell
New-AzConnectedVMwarevSphereInventoryItem -Name <String> -ResourceGroupName <String> -VcenterName <String>
 -InventoryType <InventoryType> [-SubscriptionId <String>] [-Kind <String>] [-ManagedResourceId <String>]
 [-MoName <String>] [-MoRefId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwarevSphereInventoryItem

#### SYNOPSIS
Implements InventoryItem GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwarevSphereInventoryItem -ResourceGroupName <String> -VcenterName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwarevSphereInventoryItem -Name <String> -ResourceGroupName <String> -VcenterName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwarevSphereInventoryItem -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwarevSphereInventoryItem

#### SYNOPSIS
Implements inventoryItem DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwarevSphereInventoryItem -Name <String> -ResourceGroupName <String> -VcenterName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwarevSphereInventoryItem -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwarevSphereMachineExtension

#### SYNOPSIS
The operation to create or update the extension.

#### SYNTAX

```powershell
New-AzConnectedVMwarevSphereMachineExtension -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String>] [-AutoUpgradeMinorVersion] [-EnableAutomaticUpgrade]
 [-ForceUpdateTag <String>] [-Location <String>] [-PropertiesType <String>] [-ProtectedSetting <IAny>]
 [-Publisher <String>] [-Setting <IAny>] [-Tag <Hashtable>] [-TypeHandlerVersion <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwarevSphereMachineExtension

#### SYNOPSIS
The operation to get the extension.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwarevSphereMachineExtension -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String[]>] [-Expand <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwarevSphereMachineExtension -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwarevSphereMachineExtension -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwarevSphereMachineExtension

#### SYNOPSIS
The operation to delete the extension.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwarevSphereMachineExtension -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwarevSphereMachineExtension -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwarevSphereMachineExtension

#### SYNOPSIS
The operation to update the extension.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwarevSphereMachineExtension -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String>] [-AutoUpgradeMinorVersion] [-EnableAutomaticUpgrade]
 [-ForceUpdateTag <String>] [-ProtectedSetting <IAny>] [-Publisher <String>] [-Setting <IAny>]
 [-Tag <Hashtable>] [-Type <String>] [-TypeHandlerVersion <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwarevSphereMachineExtension -InputObject <IConnectedVMwarevSphereIdentity>
 [-AutoUpgradeMinorVersion] [-EnableAutomaticUpgrade] [-ForceUpdateTag <String>] [-ProtectedSetting <IAny>]
 [-Publisher <String>] [-Setting <IAny>] [-Tag <Hashtable>] [-Type <String>] [-TypeHandlerVersion <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwarevSphereResourcePool

#### SYNOPSIS
Create Or Update resourcePool.

#### SYNTAX

```powershell
New-AzConnectedVMwarevSphereResourcePool -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-InventoryItemId <String>] [-Kind <String>] [-MoRefId <String>] [-Tag <Hashtable>] [-VCenterId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwarevSphereResourcePool

#### SYNOPSIS
Implements resourcePool GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwarevSphereResourcePool [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwarevSphereResourcePool -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwarevSphereResourcePool -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwarevSphereResourcePool -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwarevSphereResourcePool

#### SYNOPSIS
Implements resourcePool DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwarevSphereResourcePool -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ForceDelete] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwarevSphereResourcePool -InputObject <IConnectedVMwarevSphereIdentity> [-ForceDelete]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwarevSphereResourcePool

#### SYNOPSIS
API to update certain properties of the resourcePool resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwarevSphereResourcePool -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwarevSphereResourcePool -InputObject <IConnectedVMwarevSphereIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwarevSphereVCenter

#### SYNOPSIS
Create Or Update vCenter.

#### SYNTAX

```powershell
New-AzConnectedVMwarevSphereVCenter -Name <String> -ResourceGroupName <String> -Fqdn <String>
 -Location <String> [-SubscriptionId <String>] [-CredentialsPassword <SecureString>]
 [-CredentialsUsername <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-Kind <String>] [-Port <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwarevSphereVCenter

#### SYNOPSIS
Implements vCenter GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwarevSphereVCenter [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwarevSphereVCenter -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwarevSphereVCenter -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwarevSphereVCenter -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwarevSphereVCenter

#### SYNOPSIS
Implements vCenter DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwarevSphereVCenter -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDelete] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwarevSphereVCenter -InputObject <IConnectedVMwarevSphereIdentity> [-ForceDelete]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwarevSphereVCenter

#### SYNOPSIS
API to update certain properties of the vCenter resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwarevSphereVCenter -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwarevSphereVCenter -InputObject <IConnectedVMwarevSphereIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwarevSphereVM

#### SYNOPSIS
Create Or Update virtual machine.

#### SYNTAX

```powershell
New-AzConnectedVMwarevSphereVM -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-FirmwareType <FirmwareType>] [-HardwareProfileMemorySizeMb <Int32>]
 [-HardwareProfileNumCoresPerSocket <Int32>] [-HardwareProfileNumCpUs <Int32>] [-IdentityType <IdentityType>]
 [-InventoryItemId <String>] [-Kind <String>] [-LinuxConfigurationPatchSettingsAssessmentMode <String>]
 [-LinuxConfigurationPatchSettingsPatchMode <String>] [-MoRefId <String>]
 [-NetworkProfileNetworkInterface <INetworkInterface[]>] [-OSProfileAdminPassword <String>]
 [-OSProfileAdminUsername <String>] [-OSProfileComputerName <String>] [-OSProfileGuestId <String>]
 [-OSProfileOstype <OSType>] [-PlacementProfileClusterId <String>] [-PlacementProfileDatastoreId <String>]
 [-PlacementProfileHostId <String>] [-PlacementProfileResourcePoolId <String>] [-ResourcePoolId <String>]
 [-SmbiosUuid <String>] [-StorageProfileDisk <IVirtualDisk[]>] [-Tag <Hashtable>] [-TemplateId <String>]
 [-UefiSettingSecureBootEnabled] [-VCenterId <String>]
 [-WindowsConfigurationPatchSettingsAssessmentMode <String>]
 [-WindowsConfigurationPatchSettingsPatchMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwarevSphereVM

#### SYNOPSIS
Implements virtual machine GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwarevSphereVM [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwarevSphereVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwarevSphereVM -InputObject <IConnectedVMwarevSphereIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwarevSphereVM -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwarevSphereVM

#### SYNOPSIS
Implements virtual machine DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwarevSphereVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDelete] [-Retain] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwarevSphereVM -InputObject <IConnectedVMwarevSphereIdentity> [-ForceDelete] [-Retain]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Restart-AzConnectedVMwarevSphereVM

#### SYNOPSIS
Restart virtual machine.

#### SYNTAX

+ Restart (Default)
```powershell
Restart-AzConnectedVMwarevSphereVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ RestartViaIdentity
```powershell
Restart-AzConnectedVMwarevSphereVM -InputObject <IConnectedVMwarevSphereIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Start-AzConnectedVMwarevSphereVM

#### SYNOPSIS
Start virtual machine.

#### SYNTAX

+ Start (Default)
```powershell
Start-AzConnectedVMwarevSphereVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ StartViaIdentity
```powershell
Start-AzConnectedVMwarevSphereVM -InputObject <IConnectedVMwarevSphereIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Stop-AzConnectedVMwarevSphereVM

#### SYNOPSIS
Stop virtual machine.

#### SYNTAX

+ StopExpanded (Default)
```powershell
Stop-AzConnectedVMwarevSphereVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-SkipShutdown] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ Stop
```powershell
Stop-AzConnectedVMwarevSphereVM -Name <String> -ResourceGroupName <String> -Body <IStopVirtualMachineOptions>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ StopViaIdentity
```powershell
Stop-AzConnectedVMwarevSphereVM -InputObject <IConnectedVMwarevSphereIdentity>
 -Body <IStopVirtualMachineOptions> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ StopViaIdentityExpanded
```powershell
Stop-AzConnectedVMwarevSphereVM -InputObject <IConnectedVMwarevSphereIdentity> [-SkipShutdown]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwarevSphereVM

#### SYNOPSIS
API to update certain properties of the virtual machine resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwarevSphereVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-HardwareProfileMemorySizeMb <Int32>] [-HardwareProfileNumCoresPerSocket <Int32>]
 [-HardwareProfileNumCpUs <Int32>] [-IdentityType <IdentityType>]
 [-LinuxConfigurationPatchSettingsAssessmentMode <String>]
 [-LinuxConfigurationPatchSettingsPatchMode <String>]
 [-NetworkProfileNetworkInterface <INetworkInterfaceUpdate[]>] [-StorageProfileDisk <IVirtualDiskUpdate[]>]
 [-Tag <Hashtable>] [-WindowsConfigurationPatchSettingsAssessmentMode <String>]
 [-WindowsConfigurationPatchSettingsPatchMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwarevSphereVM -InputObject <IConnectedVMwarevSphereIdentity>
 [-HardwareProfileMemorySizeMb <Int32>] [-HardwareProfileNumCoresPerSocket <Int32>]
 [-HardwareProfileNumCpUs <Int32>] [-IdentityType <IdentityType>]
 [-LinuxConfigurationPatchSettingsAssessmentMode <String>]
 [-LinuxConfigurationPatchSettingsPatchMode <String>]
 [-NetworkProfileNetworkInterface <INetworkInterfaceUpdate[]>] [-StorageProfileDisk <IVirtualDiskUpdate[]>]
 [-Tag <Hashtable>] [-WindowsConfigurationPatchSettingsAssessmentMode <String>]
 [-WindowsConfigurationPatchSettingsPatchMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Invoke-AzConnectedVMwarevSphereVMAssessPatch

#### SYNOPSIS
The operation to assess patches on a vSphere VMware machine identity in Azure.

#### SYNTAX

+ Assess (Default)
```powershell
Invoke-AzConnectedVMwarevSphereVMAssessPatch -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ AssessViaIdentity
```powershell
Invoke-AzConnectedVMwarevSphereVMAssessPatch -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Install-AzConnectedVMwarevSphereVMPatch

#### SYNOPSIS
The operation to install patches on a vSphere VMware machine identity in Azure.

#### SYNTAX

+ InstallExpanded (Default)
```powershell
Install-AzConnectedVMwarevSphereVMPatch -Name <String> -ResourceGroupName <String> -MaximumDuration <String>
 -RebootSetting <VMGuestPatchRebootSetting> [-SubscriptionId <String>]
 [-LinuxParameterClassificationsToInclude <VMGuestPatchClassificationLinux[]>]
 [-LinuxParameterPackageNameMasksToExclude <String[]>] [-LinuxParameterPackageNameMasksToInclude <String[]>]
 [-WindowParameterClassificationsToInclude <VMGuestPatchClassificationWindows[]>]
 [-WindowParameterExcludeKbsRequiringReboot] [-WindowParameterKbNumbersToExclude <String[]>]
 [-WindowParameterKbNumbersToInclude <String[]>] [-WindowParameterMaxPatchPublishDate <DateTime>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ InstallViaIdentityExpanded
```powershell
Install-AzConnectedVMwarevSphereVMPatch -InputObject <IConnectedVMwarevSphereIdentity>
 -MaximumDuration <String> -RebootSetting <VMGuestPatchRebootSetting>
 [-LinuxParameterClassificationsToInclude <VMGuestPatchClassificationLinux[]>]
 [-LinuxParameterPackageNameMasksToExclude <String[]>] [-LinuxParameterPackageNameMasksToInclude <String[]>]
 [-WindowParameterClassificationsToInclude <VMGuestPatchClassificationWindows[]>]
 [-WindowParameterExcludeKbsRequiringReboot] [-WindowParameterKbNumbersToExclude <String[]>]
 [-WindowParameterKbNumbersToInclude <String[]>] [-WindowParameterMaxPatchPublishDate <DateTime>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwarevSphereVMTemplate

#### SYNOPSIS
Create Or Update virtual machine template.

#### SYNTAX

```powershell
New-AzConnectedVMwarevSphereVMTemplate -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-InventoryItemId <String>] [-Kind <String>] [-MoRefId <String>] [-Tag <Hashtable>] [-VCenterId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwarevSphereVMTemplate

#### SYNOPSIS
Implements virtual machine template GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwarevSphereVMTemplate [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwarevSphereVMTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwarevSphereVMTemplate -InputObject <IConnectedVMwarevSphereIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwarevSphereVMTemplate -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwarevSphereVMTemplate

#### SYNOPSIS
Implements virtual machine template DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwarevSphereVMTemplate -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ForceDelete] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwarevSphereVMTemplate -InputObject <IConnectedVMwarevSphereIdentity> [-ForceDelete]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwarevSphereVMTemplate

#### SYNOPSIS
API to update certain properties of the virtual machine template resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwarevSphereVMTemplate -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwarevSphereVMTemplate -InputObject <IConnectedVMwarevSphereIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwarevSphereVNet

#### SYNOPSIS
Create Or Update virtual network.

#### SYNTAX

```powershell
New-AzConnectedVMwarevSphereVNet -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-InventoryItemId <String>] [-Kind <String>] [-MoRefId <String>] [-Tag <Hashtable>] [-VCenterId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwarevSphereVNet

#### SYNOPSIS
Implements virtual network GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwarevSphereVNet [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwarevSphereVNet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwarevSphereVNet -InputObject <IConnectedVMwarevSphereIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwarevSphereVNet -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwarevSphereVNet

#### SYNOPSIS
Implements virtual network DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwarevSphereVNet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDelete] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwarevSphereVNet -InputObject <IConnectedVMwarevSphereIdentity> [-ForceDelete]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwarevSphereVNet

#### SYNOPSIS
API to update certain properties of the virtual network resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwarevSphereVNet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwarevSphereVNet -InputObject <IConnectedVMwarevSphereIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


