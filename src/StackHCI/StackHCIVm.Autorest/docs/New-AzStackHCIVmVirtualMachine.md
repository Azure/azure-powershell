---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhci/new-azstackhcivmvirtualmachine
schema: 2.0.0
---

# New-AzStackHCIVmVirtualMachine

## SYNOPSIS
The operation to create or update a virtual machine.
Please note some properties can be set only during virtual machine creation.

## SYNTAX

### ByImageId (Default)
```
New-AzStackHCIVmVirtualMachine -Name <String> -ResourceGroupName <String> -CustomLocationId <String>
 -ImageId <String> -Location <String> -OsType <String> [-SubscriptionId <String>] [-AdminPassword <String>]
 [-AdminUsername <String>] [-ComputerName <String>] [-DataDiskIds <String[]>] [-DataDiskNames <String[]>]
 [-DataDiskResourceGroup <String>] [-DisablePasswordAuthentication] [-DynamicMemoryMaximumMemoryInMb <Int64>]
 [-DynamicMemoryMinimumMemoryInMb <Int64>] [-DynamicMemoryTargetBuffer <Int32>] [-EnableAutomaticUpdate]
 [-EnableTpm] [-IdentityType <ResourceIdentityType>] [-NicIds <String[]>] [-NicNames <String[]>]
 [-NicResourceGroup <String>] [-ProvisionVMAgent] [-ProvisionVMConfigAgent] [-SecureBootEnabled]
 [-SshPublicKeys <String[]>] [-StoragePathId <String>] [-StoragePathName <String>]
 [-StoragePathResourceGroup <String>] [-Tags <Hashtable>] [-TimeZone <String>] [-VmMemoryInMB <Int64>]
 [-VmProcessors <Int32>] [-VmSize <VMSizeEnum>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByImageName
```
New-AzStackHCIVmVirtualMachine -Name <String> -ResourceGroupName <String> -CustomLocationId <String>
 -ImageName <String> -Location <String> -OsType <String> [-SubscriptionId <String>] [-AdminPassword <String>]
 [-AdminUsername <String>] [-ComputerName <String>] [-DataDiskIds <String[]>] [-DataDiskNames <String[]>]
 [-DataDiskResourceGroup <String>] [-DisablePasswordAuthentication] [-DynamicMemoryMaximumMemoryInMb <Int64>]
 [-DynamicMemoryMinimumMemoryInMb <Int64>] [-DynamicMemoryTargetBuffer <Int32>] [-EnableAutomaticUpdate]
 [-EnableTpm] [-IdentityType <ResourceIdentityType>] [-ImageResourceGroup <String>] [-NicIds <String[]>]
 [-NicNames <String[]>] [-NicResourceGroup <String>] [-ProvisionVMAgent] [-ProvisionVMConfigAgent]
 [-SecureBootEnabled] [-SshPublicKeys <String[]>] [-StoragePathId <String>] [-StoragePathName <String>]
 [-StoragePathResourceGroup <String>] [-Tags <Hashtable>] [-TimeZone <String>] [-VmMemoryInMB <Int64>]
 [-VmProcessors <Int32>] [-VmSize <VMSizeEnum>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByOsDiskId
```
New-AzStackHCIVmVirtualMachine -Name <String> -ResourceGroupName <String> -CustomLocationId <String>
 -Location <String> -OSDiskId <String> -OsType <String> [-SubscriptionId <String>] [-AdminPassword <String>]
 [-AdminUsername <String>] [-ComputerName <String>] [-DataDiskIds <String[]>] [-DataDiskNames <String[]>]
 [-DataDiskResourceGroup <String>] [-DisablePasswordAuthentication] [-DynamicMemoryMaximumMemoryInMb <Int64>]
 [-DynamicMemoryMinimumMemoryInMb <Int64>] [-DynamicMemoryTargetBuffer <Int32>] [-EnableAutomaticUpdate]
 [-EnableTpm] [-IdentityType <ResourceIdentityType>] [-NicIds <String[]>] [-NicNames <String[]>]
 [-NicResourceGroup <String>] [-ProvisionVMAgent] [-ProvisionVMConfigAgent] [-SecureBootEnabled]
 [-SshPublicKeys <String[]>] [-StoragePathId <String>] [-StoragePathName <String>]
 [-StoragePathResourceGroup <String>] [-Tags <Hashtable>] [-TimeZone <String>] [-VmMemoryInMB <Int64>]
 [-VmProcessors <Int32>] [-VmSize <VMSizeEnum>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByOsDiskName
```
New-AzStackHCIVmVirtualMachine -Name <String> -ResourceGroupName <String> -CustomLocationId <String>
 -Location <String> -OSDiskName <String> -OsType <String> [-SubscriptionId <String>] [-AdminPassword <String>]
 [-AdminUsername <String>] [-ComputerName <String>] [-DataDiskIds <String[]>] [-DataDiskNames <String[]>]
 [-DataDiskResourceGroup <String>] [-DisablePasswordAuthentication] [-DynamicMemoryMaximumMemoryInMb <Int64>]
 [-DynamicMemoryMinimumMemoryInMb <Int64>] [-DynamicMemoryTargetBuffer <Int32>] [-EnableAutomaticUpdate]
 [-EnableTpm] [-IdentityType <ResourceIdentityType>] [-NicIds <String[]>] [-NicNames <String[]>]
 [-NicResourceGroup <String>] [-OSDiskResourceGroup <String>] [-ProvisionVMAgent] [-ProvisionVMConfigAgent]
 [-SecureBootEnabled] [-SshPublicKeys <String[]>] [-StoragePathId <String>] [-StoragePathName <String>]
 [-StoragePathResourceGroup <String>] [-Tags <Hashtable>] [-TimeZone <String>] [-VmMemoryInMB <Int64>]
 [-VmProcessors <Int32>] [-VmSize <VMSizeEnum>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a virtual machine.
Please note some properties can be set only during virtual machine creation.

## EXAMPLES

### Example 1: Create a Virtual Machine with an Image. 
```powershell
PS C:\> New-AzStackHCIVmVirtualMachine -Name "testVm" -OsType "Linux"  -ImageName "testImage" -VmSize "Standard_K8S_v1"  -AdminUsername "localadmin" -ComputerName "testVm"  -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}"  -Location "eastus"
```

```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```

This command creates a virtual machine from a gallery image.

### Example 2: Create a Virtual Machine with a Disk. 
```powershell
PS C:\> New-AzStackHCIVmVirtualMachine -Name "testVm" -OsType "Linux" -OsDiskName "testOsDisk" -VmSize "Standard_K8S_v1"  -AdminUsername "localadmin" -ComputerName "testVm" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}" -Location "eastus"
```

```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```
This command creates a virtual machine from a disk.

## PARAMETERS

### -AdminPassword
AdminPassword - admin password

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

### -AdminUsername
AdminUsername - admin username

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

### -ComputerName
ComputerName - name of the computer

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

### -CustomLocationId
The name of the extended location.

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

### -DataDiskIds
Data Disks - List of data disks to be attached to the virtual machine in id format.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataDiskNames
Data Disks - List of data disks to be attached to the virtual machine in name format .

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataDiskResourceGroup
Data Disks - Resource Group of Data Disks.

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

### -DisablePasswordAuthentication
DisablePasswordAuthentication - whether password authentication should be disabled

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

### -DynamicMemoryMaximumMemoryInMb
Maximum Dynamic Memory

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

### -DynamicMemoryMinimumMemoryInMb
Minimum Dynamic Memory

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

### -DynamicMemoryTargetBuffer
Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total memory that the virtual machine is thought to need.
This only applies to virtual systems with dynamic memory enabled.
This property can be in the range of 5 to 2000.

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

### -EnableAutomaticUpdate
Specifies Whether to EnableAutomaticUpdates on the machine.

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

### -EnableTpm
Used to indicate whether or not to enable TPM

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

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageId
Resource ID of the image to create the VM with.

```yaml
Type: System.String
Parameter Sets: ByImageId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageName
Name of the image to create the VM with.

```yaml
Type: System.String
Parameter Sets: ByImageName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageResourceGroup
Resource group of the image to create the VM from.

```yaml
Type: System.String
Parameter Sets: ByImageName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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

### -Name
Name of the virtual machine

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

### -NicIds
NetworkInterfaces - list of network interfaces to be attached to the virtual machine in ARM Id format.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NicNames
NetworkInterfaces - list of network interfaces to be attached to the virtual machine in name format.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NicResourceGroup
NetworkInterfaces - Resource Group of Network Interfaces.

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

### -OSDiskId
Resource ID of the OS disk

```yaml
Type: System.String
Parameter Sets: ByOsDiskId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSDiskName
Name of the OS disk

```yaml
Type: System.String
Parameter Sets: ByOsDiskName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSDiskResourceGroup
Resource Group of the OS disk

```yaml
Type: System.String
Parameter Sets: ByOsDiskName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OsType
OsType - string specifying whether the OS is Linux or Windows

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

### -ProvisionVMAgent
Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
VM Agent is provsioned by default.
Please pass -ProvisionVMAgent:$false to disable.

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

### -ProvisionVMConfigAgent
Indicates whether virtual machine configuration agent should be provisioned on the virtual machine.
When this property is not specified, default behavior is to set it to true.
VM Config Agent is provisioned by default.
Please pass -ProvisionVMConfigAgent:$false to disable.

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

### -SecureBootEnabled
Specifies whether secure boot should be enabled on the virtual machine.

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

### -SshPublicKeys
PublicKeys - The list of SSH public keys used to authenticate with VMs

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StoragePathId
Id of the storage container that hosts the VM configuration file

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

### -StoragePathName
Name of the storage container that hosts the VM configuration file

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

### -StoragePathResourceGroup
Storage Container resource group.
The resource group of the virtual machine will be used if this value is not provided.

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
The ID of the target subscription.

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

### -Tags
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeZone
TimeZone for the virtual machine

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

### -VmMemoryInMB
RAM in MB for the virtual machine

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

### -VmProcessors
Number of processors for the virtual machine

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

### -VmSize
Size of the VM.
Can be a Predefined size or Custom.
Possible Predefined Sizes include - Custom,Standard_A2_v2,Standard_A4_v2,Standard_D16s_v3,Standard_D2s_v3,Standard_D32s_v3,Standard_D4s_v3,Standard_D8s_v3,Standard_DS13_v2,Standard_DS2_v2,Standard_DS3_v2,Standard_DS4_v2,Standard_DS5_v2,Standard_K8S2_v1,Standard_K8S3_v1,Standard_K8S4_v1,Standard_K8S5_v1,Standard_K8S_v1,Standard_NK12,Standard_NK6,Standard_NV12, StandardNv6

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IVirtualMachineInstance

## NOTES

ALIASES

## RELATED LINKS

