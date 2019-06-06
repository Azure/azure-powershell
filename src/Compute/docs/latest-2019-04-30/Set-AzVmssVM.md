---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/set-azvmssvm
schema: 2.0.0
---

# Set-AzVmssVM

## SYNOPSIS
Updates a virtual machine of a VM scale set.

## SYNTAX

### Update1 (Default)
```
Set-AzVmssVM -InstanceId <String> -ResourceGroupName <String> -SubscriptionId <String>
 -VMScaleSetName <String> [-Parameter <IVirtualMachineScaleSetVM>] [-DefaultProfile <PSObject>] [-AsJob]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzVmssVM -InstanceId <String> -ResourceGroupName <String> -SubscriptionId <String>
 -VMScaleSetName <String> -Location <String> [-AvailabilitySetId <String>] [-BootDiagnosticEnabled]
 [-BootDiagnosticStorageUri <String>]
 [-ConfigurationNetworkInterfaceConfiguration <IVirtualMachineScaleSetNetworkConfiguration[]>]
 [-DataDisk <IDataDisk[]>] [-HardwareProfileVMSize <VirtualMachineSizeTypes>] [-ImageReferenceId <String>]
 [-ImageReferenceOffer <String>] [-ImageReferencePublisher <String>] [-ImageReferenceSku <String>]
 [-ImageReferenceVersion <String>] [-InstanceView <IVirtualMachineScaleSetVMInstanceView>]
 [-LicenseType <String>] [-LinuxConfigurationDisablePasswordAuthentication]
 [-LinuxConfigurationProvisionVMAgent] [-LinuxConfigurationSshPublicKey <ISshPublicKey[]>]
 [-NetworkInterface <INetworkInterfaceReference[]>] [-OSDisk <IOSDisk>] [-OSProfileAdminPassword <String>]
 [-OSProfileAdminUsername <String>] [-OSProfileAllowExtensionOperation] [-OSProfileComputerName <String>]
 [-OSProfileCustomData <String>] [-OSProfileSecret <IVaultSecretGroup[]>] [-PlanName <String>]
 [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>]
 [-ProtectionPolicyProtectFromScaleIn] [-ProtectionPolicyProtectFromScaleSetAction] [-SkuCapacity <Int64>]
 [-SkuName <String>] [-SkuTier <String>] [-Tag <IResourceTags>] [-UltraSsdEnabled]
 [-WinRmListener <IWinRmListener[]>]
 [-WindowConfigurationAdditionalUnattendContent <IAdditionalUnattendContent[]>]
 [-WindowConfigurationEnableAutomaticUpdate] [-WindowConfigurationProvisionVMAgent]
 [-WindowConfigurationTimeZone <String>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Set-AzVmssVM -InputObject <IComputeIdentity> -Location <String> [-AvailabilitySetId <String>]
 [-BootDiagnosticEnabled] [-BootDiagnosticStorageUri <String>]
 [-ConfigurationNetworkInterfaceConfiguration <IVirtualMachineScaleSetNetworkConfiguration[]>]
 [-DataDisk <IDataDisk[]>] [-HardwareProfileVMSize <VirtualMachineSizeTypes>] [-ImageReferenceId <String>]
 [-ImageReferenceOffer <String>] [-ImageReferencePublisher <String>] [-ImageReferenceSku <String>]
 [-ImageReferenceVersion <String>] [-InstanceView <IVirtualMachineScaleSetVMInstanceView>]
 [-LicenseType <String>] [-LinuxConfigurationDisablePasswordAuthentication]
 [-LinuxConfigurationProvisionVMAgent] [-LinuxConfigurationSshPublicKey <ISshPublicKey[]>]
 [-NetworkInterface <INetworkInterfaceReference[]>] [-OSDisk <IOSDisk>] [-OSProfileAdminPassword <String>]
 [-OSProfileAdminUsername <String>] [-OSProfileAllowExtensionOperation] [-OSProfileComputerName <String>]
 [-OSProfileCustomData <String>] [-OSProfileSecret <IVaultSecretGroup[]>] [-PlanName <String>]
 [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>]
 [-ProtectionPolicyProtectFromScaleIn] [-ProtectionPolicyProtectFromScaleSetAction] [-SkuCapacity <Int64>]
 [-SkuName <String>] [-SkuTier <String>] [-Tag <IResourceTags>] [-UltraSsdEnabled]
 [-WinRmListener <IWinRmListener[]>]
 [-WindowConfigurationAdditionalUnattendContent <IAdditionalUnattendContent[]>]
 [-WindowConfigurationEnableAutomaticUpdate] [-WindowConfigurationProvisionVMAgent]
 [-WindowConfigurationTimeZone <String>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates a virtual machine of a VM scale set.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AvailabilitySetId
Resource Id

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BootDiagnosticEnabled
Whether boot diagnostics should be enabled on the Virtual Machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BootDiagnosticStorageUri
Uri of the storage account to use for placing the console output and screenshot.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConfigurationNetworkInterfaceConfiguration
The list of network configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSetNetworkConfiguration[]
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DataDisk
Specifies the parameters that are used to add a data disk to a virtual machine.
  For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhdstoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IDataDisk[]
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HardwareProfileVMSize
Specifies the size of the virtual machine.
For more information about virtual machine sizes, see [Sizes for virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-sizestoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
  The available VM sizes depend on region and availability set.
For a list of available sizes use these APIs:    [List all available virtual machine sizes in an availability set](https://docs.microsoft.com/rest/api/compute/availabilitysets/listavailablesizes)    [List all available virtual machine sizes in a region](https://docs.microsoft.com/rest/api/compute/virtualmachinesizes/list)    [List all available virtual machine sizes for resizing](https://docs.microsoft.com/rest/api/compute/virtualmachines/listavailablesizes)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.VirtualMachineSizeTypes
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ImageReferenceId
Resource Id

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ImageReferenceOffer
Specifies the offer of the platform image or marketplace image used to create the virtual machine.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ImageReferencePublisher
The image publisher.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ImageReferenceSku
The image SKU.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ImageReferenceVersion
Specifies the version of the platform image or marketplace image used to create the virtual machine.
The allowed formats are Major.Minor.Build or 'latest'.
Major, Minor, and Build are decimal numbers.
Specify 'latest' to use the latest version of an image available at deploy time.
Even if you use 'latest', the VM image will not automatically update after deploy time even if a new version becomes available.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: UpdateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InstanceId
The instance ID of the virtual machine.

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InstanceView
The virtual machine instance view.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSetVMInstanceView
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LicenseType
Specifies that the image or disk that is being used was licensed on-premises.
This element is only used for images that contain the Windows Server operating system.
  Possible values are:    Windows_Client    Windows_Server    If this element is included in a request for an update, the value must match the initial value.
This value cannot be updated.
  For more information, see [Azure Hybrid Use Benefit for Windows Server](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-hybrid-use-benefit-licensingtoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json)    Minimum api-version: 2015-06-15

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LinuxConfigurationDisablePasswordAuthentication
Specifies whether password authentication should be disabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LinuxConfigurationProvisionVMAgent
Indicates whether virtual machine agent should be provisioned on the virtual machine.
  When this property is not specified in the request body, default behavior is to set it to true.
This will ensure that VM Agent is installed on the VM so that extensions can be added to the VM later.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LinuxConfigurationSshPublicKey
The list of SSH public keys used to authenticate with linux based VMs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.ISshPublicKey[]
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkInterface
Specifies the list of resource Ids for the network interfaces associated with the virtual machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.INetworkInterfaceReference[]
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSDisk
Specifies information about the operating system disk used by the virtual machine.
  For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhdstoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IOSDisk
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSProfileAdminPassword
Specifies the password of the administrator account.
  **Minimum-length (Windows):** 8 characters    **Minimum-length (Linux):** 6 characters    **Max-length (Windows):** 123 characters    **Max-length (Linux):** 72 characters    **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled   Has lower characters  Has upper characters   Has a digit   Has a special character (Regex match [\W_])    **Disallowed values:** "abc@123", "P@$$w0rd", "P@ssw0rd", "P@ssword123", "Pa$$word", "pass@word1", "Password!", "Password1", "Password22", "iloveyou!"    For resetting the password, see [How to reset the Remote Desktop service or its login password in a Windows VM](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-reset-rdptoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json)    For resetting root password, see [Manage users, SSH, and check or repair disks on Azure Linux VMs using the VMAccess Extension](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-vmaccess-extensiontoc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json#reset-root-password)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSProfileAdminUsername
Specifies the name of the administrator account.
  **Windows-only restriction:** Cannot end in "."    **Disallowed values:** "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm", "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0", "sys", "test2", "test3", "user4", "user5".
  **Minimum-length (Linux):** 1 character    **Max-length (Linux):** 64 characters    **Max-length (Windows):** 20 characters   <li> For root access to the Linux VM, see [Using root privileges on Linux virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-use-root-privilegestoc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json) <li> For a list of built-in system users on Linux that should not be used in this field, see [Selecting User Names for Linux on Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-usernamestoc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSProfileAllowExtensionOperation
Specifies whether extension operations should be allowed on the virtual machine.
 This may only be set to False when no extensions are present on the virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSProfileComputerName
Specifies the host OS name of the virtual machine.
  This name cannot be updated after the VM is created.
  **Max-length (Windows):** 15 characters    **Max-length (Linux):** 64 characters.
  For naming conventions and restrictions see [Azure infrastructure services implementation guidelines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-infrastructure-subscription-accounts-guidelinestoc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json#1-naming-conventions).

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSProfileCustomData
Specifies a base-64 encoded string of custom data.
The base-64 encoded string is decoded to a binary array that is saved as a file on the Virtual Machine.
The maximum length of the binary array is 65535 bytes.
  For using cloud-init for your VM, see [Using cloud-init to customize a Linux VM during creation](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-cloud-inittoc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSProfileSecret
Specifies set of certificates that should be installed onto the virtual machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVaultSecretGroup[]
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Describes a virtual machine scale set virtual machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSetVM
Parameter Sets: Update1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PlanName
The plan ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanProduct
Specifies the product of the image from the marketplace.
This is the same value as Offer under the imageReference element.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanPromotionCode
The promotion code.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanPublisher
The publisher ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProtectionPolicyProtectFromScaleIn
Indicates that the virtual machine scale set VM shouldn't be considered for deletion during a scale-in operation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProtectionPolicyProtectFromScaleSetAction
Indicates that model updates or actions (including scale-in) initiated on the virtual machine scale set should not be applied to the virtual machine scale set VM.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuCapacity
Specifies the number of virtual machines in the scale set.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
The sku name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuTier
Specifies the tier of virtual machines in a scale set.<br /><br /> Possible Values:<br /><br /> **Standard**<br /><br /> **Basic**

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20170330.IResourceTags
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UltraSsdEnabled
The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the VM or VMSS.
Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only if this property is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases: EnableUltraSSD

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VMScaleSetName
The name of the VM scale set where the extension should be create or updated.

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WindowConfigurationAdditionalUnattendContent
Specifies additional base-64 encoded XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IAdditionalUnattendContent[]
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WindowConfigurationEnableAutomaticUpdate
Indicates whether virtual machine is enabled for automatic Windows updates.
Default value is true.
  For virtual machine scale sets, this property can be updated and updates will take effect on OS reprovisioning.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WindowConfigurationProvisionVMAgent
Indicates whether virtual machine agent should be provisioned on the virtual machine.
  When this property is not specified in the request body, default behavior is to set it to true.
This will ensure that VM Agent is installed on the VM so that extensions can be added to the VM later.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WindowConfigurationTimeZone
Specifies the time zone of the virtual machine.
e.g.
"Pacific Standard Time"

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WinRmListener
The list of Windows Remote Management listeners

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IWinRmListener[]
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSetVM

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSetVM

## ALIASES

## RELATED LINKS

