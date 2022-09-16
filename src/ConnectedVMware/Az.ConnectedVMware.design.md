#### New-AzConnectedVMwareCluster

#### SYNOPSIS
Create Or Update cluster.

#### SYNTAX

```powershell
New-AzConnectedVMwareCluster -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-InventoryItemId <String>] [-Kind <String>] [-MoRefId <String>] [-Tag <Hashtable>] [-VCenterId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwareCluster

#### SYNOPSIS
Implements cluster GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwareCluster [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwareCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwareCluster -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwareCluster -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwareCluster

#### SYNOPSIS
Implements cluster DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwareCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDeletion] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwareCluster -InputObject <IConnectedVMwareIdentity> [-ForceDeletion]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwareCluster

#### SYNOPSIS
API to update certain properties of the cluster resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwareCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwareCluster -InputObject <IConnectedVMwareIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwareDatastore

#### SYNOPSIS
Create Or Update datastore.

#### SYNTAX

```powershell
New-AzConnectedVMwareDatastore -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-InventoryItemId <String>] [-Kind <String>] [-MoRefId <String>] [-Tag <Hashtable>] [-VCenterId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwareDatastore

#### SYNOPSIS
Implements datastore GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwareDatastore [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwareDatastore -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwareDatastore -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwareDatastore -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwareDatastore

#### SYNOPSIS
Implements datastore DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwareDatastore -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDeletion] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwareDatastore -InputObject <IConnectedVMwareIdentity> [-ForceDeletion]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwareDatastore

#### SYNOPSIS
API to update certain properties of the datastore resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwareDatastore -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwareDatastore -InputObject <IConnectedVMwareIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwareGuestAgent

#### SYNOPSIS
Create Or Update GuestAgent.

#### SYNTAX

```powershell
New-AzConnectedVMwareGuestAgent -Name <String> -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String>] [-CredentialsPassword <SecureString>] [-CredentialsUsername <String>]
 [-HttpProxyConfigHttpsProxy <String>] [-ProvisioningAction <ProvisioningAction>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwareGuestAgent

#### SYNOPSIS
Implements GuestAgent GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwareGuestAgent -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwareGuestAgent -Name <String> -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwareGuestAgent -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```


#### Remove-AzConnectedVMwareGuestAgent

#### SYNOPSIS
Implements GuestAgent DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwareGuestAgent -Name <String> -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwareGuestAgent -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwareHost

#### SYNOPSIS
Create Or Update host.

#### SYNTAX

```powershell
New-AzConnectedVMwareHost -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-InventoryItemId <String>] [-Kind <String>] [-MoRefId <String>] [-Tag <Hashtable>] [-VCenterId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwareHost

#### SYNOPSIS
Implements host GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwareHost [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwareHost -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwareHost -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwareHost -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwareHost

#### SYNOPSIS
Implements host DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwareHost -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDeletion] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwareHost -InputObject <IConnectedVMwareIdentity> [-ForceDeletion]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwareHost

#### SYNOPSIS
API to update certain properties of the host resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwareHost -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwareHost -InputObject <IConnectedVMwareIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwareHybridIdentityMetadata

#### SYNOPSIS
Create Or Update HybridIdentityMetadata.

#### SYNTAX

```powershell
New-AzConnectedVMwareHybridIdentityMetadata -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String>] [-PublicKey <String>] [-VMId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwareHybridIdentityMetadata

#### SYNOPSIS
Implements HybridIdentityMetadata GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwareHybridIdentityMetadata -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwareHybridIdentityMetadata -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwareHybridIdentityMetadata -InputObject <IConnectedVMwareIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwareHybridIdentityMetadata

#### SYNOPSIS
Implements HybridIdentityMetadata DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwareHybridIdentityMetadata -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwareHybridIdentityMetadata -InputObject <IConnectedVMwareIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwareInventoryItem

#### SYNOPSIS
Create Or Update InventoryItem.

#### SYNTAX

```powershell
New-AzConnectedVMwareInventoryItem -Name <String> -ResourceGroupName <String> -VcenterName <String>
 -InventoryType <InventoryType> [-SubscriptionId <String>] [-Kind <String>] [-ManagedResourceId <String>]
 [-MoName <String>] [-MoRefId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwareInventoryItem

#### SYNOPSIS
Implements InventoryItem GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwareInventoryItem -ResourceGroupName <String> -VcenterName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwareInventoryItem -Name <String> -ResourceGroupName <String> -VcenterName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwareInventoryItem -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```


#### Remove-AzConnectedVMwareInventoryItem

#### SYNOPSIS
Implements inventoryItem DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwareInventoryItem -Name <String> -ResourceGroupName <String> -VcenterName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwareInventoryItem -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwareMachineExtension

#### SYNOPSIS
The operation to create or update the extension.

#### SYNTAX

```powershell
New-AzConnectedVMwareMachineExtension -Name <String> -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String>] [-AutoUpgradeMinorVersion] [-EnableAutomaticUpgrade] [-ForceUpdateTag <String>]
 [-Location <String>] [-PropertiesType <String>] [-ProtectedSetting <IAny>] [-Publisher <String>]
 [-Setting <IAny>] [-Tag <Hashtable>] [-TypeHandlerVersion <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwareMachineExtension

#### SYNOPSIS
The operation to get the extension.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwareMachineExtension -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String[]>] [-Expand <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwareMachineExtension -Name <String> -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwareMachineExtension -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```


#### Remove-AzConnectedVMwareMachineExtension

#### SYNOPSIS
The operation to delete the extension.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwareMachineExtension -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwareMachineExtension -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwareMachineExtension

#### SYNOPSIS
The operation to update the extension.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwareMachineExtension -Name <String> -ResourceGroupName <String>
 -VirtualMachineName <String> [-SubscriptionId <String>] [-AutoUpgradeMinorVersion] [-EnableAutomaticUpgrade]
 [-ForceUpdateTag <String>] [-ProtectedSetting <IAny>] [-Publisher <String>] [-Setting <IAny>]
 [-Tag <Hashtable>] [-Type <String>] [-TypeHandlerVersion <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwareMachineExtension -InputObject <IConnectedVMwareIdentity> [-AutoUpgradeMinorVersion]
 [-EnableAutomaticUpgrade] [-ForceUpdateTag <String>] [-ProtectedSetting <IAny>] [-Publisher <String>]
 [-Setting <IAny>] [-Tag <Hashtable>] [-Type <String>] [-TypeHandlerVersion <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwareResourcePool

#### SYNOPSIS
Create Or Update resourcePool.

#### SYNTAX

```powershell
New-AzConnectedVMwareResourcePool -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-InventoryItemId <String>] [-Kind <String>] [-MoRefId <String>] [-Tag <Hashtable>] [-VCenterId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwareResourcePool

#### SYNOPSIS
Implements resourcePool GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwareResourcePool [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwareResourcePool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwareResourcePool -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwareResourcePool -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwareResourcePool

#### SYNOPSIS
Implements resourcePool DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwareResourcePool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDeletion] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwareResourcePool -InputObject <IConnectedVMwareIdentity> [-ForceDeletion]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwareResourcePool

#### SYNOPSIS
API to update certain properties of the resourcePool resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwareResourcePool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwareResourcePool -InputObject <IConnectedVMwareIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwareVCenter

#### SYNOPSIS
Create Or Update vCenter.

#### SYNTAX

```powershell
New-AzConnectedVMwareVCenter -Name <String> -ResourceGroupName <String> -Fqdn <String> -Location <String>
 [-SubscriptionId <String>] [-CredentialsPassword <SecureString>] [-CredentialsUsername <String>]
 [-ExtendedLocationName <String>] [-ExtendedLocationType <String>] [-Kind <String>] [-Port <Int32>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwareVCenter

#### SYNOPSIS
Implements vCenter GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwareVCenter [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwareVCenter -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwareVCenter -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwareVCenter -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwareVCenter

#### SYNOPSIS
Implements vCenter DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwareVCenter -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDeletion] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwareVCenter -InputObject <IConnectedVMwareIdentity> [-ForceDeletion]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwareVCenter

#### SYNOPSIS
API to update certain properties of the vCenter resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwareVCenter -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwareVCenter -InputObject <IConnectedVMwareIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwareVM

#### SYNOPSIS
Create Or Update virtual machine.

#### SYNTAX

```powershell
New-AzConnectedVMwareVM -Name <String> -ResourceGroupName <String> -Location <String>
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


#### Get-AzConnectedVMwareVM

#### SYNOPSIS
Implements virtual machine GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwareVM [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwareVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwareVM -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwareVM -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```


#### Remove-AzConnectedVMwareVM

#### SYNOPSIS
Implements virtual machine DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwareVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDeletion] [-Retain] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwareVM -InputObject <IConnectedVMwareIdentity> [-ForceDeletion] [-Retain]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Restart-AzConnectedVMwareVM

#### SYNOPSIS
Restart virtual machine.

#### SYNTAX

+ Restart (Default)
```powershell
Restart-AzConnectedVMwareVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ RestartViaIdentity
```powershell
Restart-AzConnectedVMwareVM -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Start-AzConnectedVMwareVM

#### SYNOPSIS
Start virtual machine.

#### SYNTAX

+ Start (Default)
```powershell
Start-AzConnectedVMwareVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ StartViaIdentity
```powershell
Start-AzConnectedVMwareVM -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Stop-AzConnectedVMwareVM

#### SYNOPSIS
Stop virtual machine.

#### SYNTAX

+ StopExpanded (Default)
```powershell
Stop-AzConnectedVMwareVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-SkipShutdown]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ Stop
```powershell
Stop-AzConnectedVMwareVM -Name <String> -ResourceGroupName <String> -Body <IStopVirtualMachineOptions>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ StopViaIdentity
```powershell
Stop-AzConnectedVMwareVM -InputObject <IConnectedVMwareIdentity> -Body <IStopVirtualMachineOptions>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ StopViaIdentityExpanded
```powershell
Stop-AzConnectedVMwareVM -InputObject <IConnectedVMwareIdentity> [-SkipShutdown] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwareVM

#### SYNOPSIS
API to update certain properties of the virtual machine resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwareVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
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
Update-AzConnectedVMwareVM -InputObject <IConnectedVMwareIdentity> [-HardwareProfileMemorySizeMb <Int32>]
 [-HardwareProfileNumCoresPerSocket <Int32>] [-HardwareProfileNumCpUs <Int32>] [-IdentityType <IdentityType>]
 [-LinuxConfigurationPatchSettingsAssessmentMode <String>]
 [-LinuxConfigurationPatchSettingsPatchMode <String>]
 [-NetworkProfileNetworkInterface <INetworkInterfaceUpdate[]>] [-StorageProfileDisk <IVirtualDiskUpdate[]>]
 [-Tag <Hashtable>] [-WindowsConfigurationPatchSettingsAssessmentMode <String>]
 [-WindowsConfigurationPatchSettingsPatchMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Invoke-AzConnectedVMwareVMAssessPatch

#### SYNOPSIS
The operation to assess patches on a vSphere VMware machine identity in Azure.

#### SYNTAX

+ Assess (Default)
```powershell
Invoke-AzConnectedVMwareVMAssessPatch -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ AssessViaIdentity
```powershell
Invoke-AzConnectedVMwareVMAssessPatch -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Install-AzConnectedVMwareVMPatch

#### SYNOPSIS
The operation to install patches on a vSphere VMware machine identity in Azure.

#### SYNTAX

+ InstallExpanded (Default)
```powershell
Install-AzConnectedVMwareVMPatch -Name <String> -ResourceGroupName <String> -MaximumDuration <String>
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
Install-AzConnectedVMwareVMPatch -InputObject <IConnectedVMwareIdentity> -MaximumDuration <String>
 -RebootSetting <VMGuestPatchRebootSetting>
 [-LinuxParameterClassificationsToInclude <VMGuestPatchClassificationLinux[]>]
 [-LinuxParameterPackageNameMasksToExclude <String[]>] [-LinuxParameterPackageNameMasksToInclude <String[]>]
 [-WindowParameterClassificationsToInclude <VMGuestPatchClassificationWindows[]>]
 [-WindowParameterExcludeKbsRequiringReboot] [-WindowParameterKbNumbersToExclude <String[]>]
 [-WindowParameterKbNumbersToInclude <String[]>] [-WindowParameterMaxPatchPublishDate <DateTime>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwareVMTemplate

#### SYNOPSIS
Create Or Update virtual machine template.

#### SYNTAX

```powershell
New-AzConnectedVMwareVMTemplate -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-InventoryItemId <String>] [-Kind <String>] [-MoRefId <String>] [-Tag <Hashtable>] [-VCenterId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwareVMTemplate

#### SYNOPSIS
Implements virtual machine template GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwareVMTemplate [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwareVMTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwareVMTemplate -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwareVMTemplate -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwareVMTemplate

#### SYNOPSIS
Implements virtual machine template DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwareVMTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDeletion] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwareVMTemplate -InputObject <IConnectedVMwareIdentity> [-ForceDeletion]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwareVMTemplate

#### SYNOPSIS
API to update certain properties of the virtual machine template resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwareVMTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwareVMTemplate -InputObject <IConnectedVMwareIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzConnectedVMwareVNet

#### SYNOPSIS
Create Or Update virtual network.

#### SYNTAX

```powershell
New-AzConnectedVMwareVNet -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-InventoryItemId <String>] [-Kind <String>] [-MoRefId <String>] [-Tag <Hashtable>] [-VCenterId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzConnectedVMwareVNet

#### SYNOPSIS
Implements virtual network GET method.

#### SYNTAX

+ List (Default)
```powershell
Get-AzConnectedVMwareVNet [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzConnectedVMwareVNet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzConnectedVMwareVNet -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzConnectedVMwareVNet -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzConnectedVMwareVNet

#### SYNOPSIS
Implements virtual network DELETE method.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzConnectedVMwareVNet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForceDeletion] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzConnectedVMwareVNet -InputObject <IConnectedVMwareIdentity> [-ForceDeletion]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzConnectedVMwareVNet

#### SYNOPSIS
API to update certain properties of the virtual network resource.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzConnectedVMwareVNet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzConnectedVMwareVNet -InputObject <IConnectedVMwareIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


