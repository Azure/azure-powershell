---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/new-aznetworkcloudvirtualmachine
schema: 2.0.0
---

# New-AzNetworkCloudVirtualMachine

## SYNOPSIS
Create a new virtual machine or create the properties of the existing virtual machine.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkCloudVirtualMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] -AdminUsername <String>
 -CloudServiceNetworkAttachmentAttachedNetworkId <String>
 -CloudServiceNetworkAttachmentIPAllocationMethod <String> -CpuCore <Int64> -ExtendedLocationName <String>
 -ExtendedLocationType <String> -Location <String> -MemorySizeGb <Int64> -OSDiskSizeGb <Int64>
 -VMImage <String> [-BootMethod <String>] [-CloudServiceNetworkAttachmentDefaultGateway <String>]
 [-CloudServiceNetworkAttachmentIpv4Address <String>] [-CloudServiceNetworkAttachmentIpv6Address <String>]
 [-CloudServiceNetworkAttachmentName <String>] [-ConsoleExtendedLocationName <String>]
 [-ConsoleExtendedLocationType <String>] [-IsolateEmulatorThread <String>]
 [-NetworkAttachment <INetworkAttachment[]>] [-NetworkData <String>] [-OSDiskCreateOption <String>]
 [-OSDiskDeleteOption <String>] [-PlacementHint <IVirtualMachinePlacementHint[]>]
 [-SshPublicKey <ISshPublicKey[]>] [-StorageProfileVolumeAttachment <String[]>] [-Tag <Hashtable>]
 [-UserData <String>] [-VMDeviceModel <String>] [-VMImageRepositoryCredentialsPassword <SecureString>]
 [-VMImageRepositoryCredentialsRegistryUrl <String>] [-VMImageRepositoryCredentialsUsername <String>]
 [-VirtioInterface <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkCloudVirtualMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkCloudVirtualMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a new virtual machine or create the properties of the existing virtual machine.

## EXAMPLES

### Example 1: Create virtual machine
```powershell
$networkAttachment = @{
    AttachedNetworkId = "attachedNetworkID"
    IpAllocationMethod = "Dynamic"
}
$hint = @{
    HintType = "Affinity"
    SchedulingExecution = "schedulingExecution"
    Scope = "scope"
    ResourceId = "resourceId"
}
$sshPublicKey = @{
    KeyData = "ssh-rsa aaaKyfsdx= fakekey@vm"
}

$securePassword = ConvertTo-SecureString "password" -asplaintext -force

New-AzNetworkCloudVirtualMachine -Name vmName  -ResourceGroupName resourceGroup -AdminUsername adminUsername -CloudServiceNetworkAttachmentAttachedNetworkId csnAttachedNetworkId -CloudServiceNetworkAttachmentIPAllocationMethod ipAllocationMethod -CpuCore cpuCore -ExtendedLocationName extendedLocationName -ExtendedLocationType "Custom" -Location location -SubscriptionId subscriptionId -MemorySizeGb memorySizeGb -OSDiskSizeGb osDiskSizeGb -VMImage vmImage -BootMethod bootMethod -CloudServiceNetworkAttachmentDefaultGateway defaultGateway -CloudServiceNetworkAttachmentName csnAttachmentName -IsolateEmulatorThread isolateEmulatorThread -NetworkAttachment $networkAttachment -NetworkData networkData -OSDiskCreateOption osDiskCreationOption -OSDiskDeleteOption osDiskDeleteOption -PlacementHint $hint -SshPublicKey $sshPublicKey -Tag @{tags = "tags"} -UserData userData -VirtioInterface virtioInterface -VMDeviceModel vmDeviceModel -VMImageRepositoryCredentialsUsername registryUsername -VMImageRepositoryCredentialsPassword $securePassword -VMImageRepositoryCredentialsRegistryUrl registryUrl
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataL
                                                                                                                                                  astModified
                                                                                                                                                  ByType
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             -----------
eastus   default 7/07/2023 21:32:03 <user>                 User                    07/07/2023 21:32:41      <identity>                           Application
```

This command creates a virtual machine.

## PARAMETERS

### -AdminUsername
The name of the administrator to which the ssh public keys will be added into the authorized keys.

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

### -BootMethod
Selects the boot method for the virtual machine.

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

### -CloudServiceNetworkAttachmentAttachedNetworkId
The resource ID of the associated network attached to the virtual machine.It can be one of cloudServicesNetwork, l3Network, l2Network or trunkedNetwork resources.

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

### -CloudServiceNetworkAttachmentDefaultGateway
The indicator of whether this is the default gateway.Only one of the attached networks (including the CloudServicesNetwork attachment) for a single machine may be specified as True.

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

### -CloudServiceNetworkAttachmentIPAllocationMethod
The IP allocation mechanism for the virtual machine.Dynamic and Static are only valid for l3Network which may also specify Disabled.Otherwise, Disabled is the only permitted value.

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

### -CloudServiceNetworkAttachmentIpv4Address
The IPv4 address of the virtual machine.This field is used only if the attached network has IPAllocationType of IPV4 or DualStack.If IPAllocationMethod is:Static - this field must contain a user specified IPv4 address from within the subnet specified in the attached network.Dynamic - this field is read-only, but will be populated with an address from within the subnet specified in the attached network.Disabled - this field will be empty.

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

### -CloudServiceNetworkAttachmentIpv6Address
The IPv6 address of the virtual machine.This field is used only if the attached network has IPAllocationType of IPV6 or DualStack.If IPAllocationMethod is:Static - this field must contain an IPv6 address range from within the range specified in the attached network.Dynamic - this field is read-only, but will be populated with an range from within the subnet specified in the attached network.Disabled - this field will be empty.

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

### -CloudServiceNetworkAttachmentName
The associated network's interface name.If specified, the network attachment name has a maximum length of 15 characters and must be unique to this virtual machine.If the user doesn't specify this value, the default interface name of the network resource will be used.For a CloudServicesNetwork resource, this name will be ignored.

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

### -ConsoleExtendedLocationName
The resource ID of the extended location on which the resource will be created.

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

### -ConsoleExtendedLocationType
The extended location type, for example, CustomLocation.

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

### -CpuCore
The number of CPU cores in the virtual machine.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded
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

### -ExtendedLocationName
The resource ID of the extended location on which the resource will be created.

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
The extended location type, for example, CustomLocation.

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

### -IfMatch
The ETag of the transformation.
Omit this value to always overwrite the current resource.
Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.

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

### -IfNoneMatch
Set to '*' to allow a new record set to be created, but to prevent updating an existing resource.
Other values will result in error from server as they are not supported.

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

### -IsolateEmulatorThread
Field Deprecated, the value will be ignored if provided.
The indicator of whether one of the specified CPU cores is isolated to run the emulator thread for this virtual machine.

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

### -MemorySizeGb
The memory size of the virtual machine.
Allocations are measured in gibibytes.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VirtualMachineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAttachment
The list of network attachments to the virtual machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkAttachment[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkData
The Base64 encoded cloud-init network data.

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

### -OSDiskCreateOption
The strategy for creating the OS disk.

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

### -OSDiskDeleteOption
The strategy for deleting the OS disk.

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

### -OSDiskSizeGb
The size of the disk.
Required if the createOption is Ephemeral.
Allocations are measured in gibibytes.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlacementHint
The scheduling hints for the virtual machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IVirtualMachinePlacementHint[]
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

### -SshPublicKey
The list of ssh public keys.
Each key will be added to the virtual machine using the cloud-init ssh_authorized_keys mechanism for the adminUsername.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.ISshPublicKey[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageProfileVolumeAttachment
The resource IDs of volumes that are requested to be attached to the virtual machine.

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

### -UserData
The Base64 encoded cloud-init user data.

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

### -VirtioInterface
Field Deprecated, use virtualizationModel instead.
The type of the virtio interface.

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

### -VMDeviceModel
The type of the device model to use.

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

### -VMImage
The virtual machine image that is currently provisioned to the OS disk, using the full url and tag notation used to pull the image.

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

### -VMImageRepositoryCredentialsPassword
The password or token used to access an image in the target repository.

```yaml
Type: System.Security.SecureString
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImageRepositoryCredentialsRegistryUrl
The URL of the authentication server used to validate the repository credentials.

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

### -VMImageRepositoryCredentialsUsername
The username used to access an image in the target repository.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IVirtualMachine

## NOTES

## RELATED LINKS
