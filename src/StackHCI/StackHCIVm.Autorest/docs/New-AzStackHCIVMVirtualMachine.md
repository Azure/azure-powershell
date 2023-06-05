---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.StackHCIVM/new-azStackHCIVMvirtualmachine
schema: 2.0.0
---

# New-AzStackHCIVMVirtualMachine

## SYNOPSIS
The operation to create or update a virtual machine.
Please note some properties can be set only during virtual machine creation.

## SYNTAX

### ByImageId (Default)
```
New-AzStackHCIVMVirtualMachine -Name <String> -ResourceGroupName <String> -CustomLocationId <String>
 -ImageId <String> -Location <String> -OsType <OSTypeEnum> [-SubscriptionId <String>]
 [-AdminPassword <String>] [-AdminUsername <String>] [-ComputerName <String>] [-DataDiskIds <String[]>]
 [-DataDiskNames <String[]>] [-DataDiskResourceGroup <String>] [-DisablePasswordAuthentication]
 [-DynamicMemoryMaximumMemory <Int64>] [-DynamicMemoryMinimumMemory <Int64>]
 [-DynamicMemoryTargetBuffer <Int32>] [-EnableAutomaticUpdate] [-EnableTpm]
 [-IdentityType <ResourceIdentityType>] [-NicIds <String[]>] [-NicNames <String[]>]
 [-NicResourceGroup <String>] [-ProvisionVMAgent] [-SecureBootEnabled] [-SshPublicKeys <String[]>]
 [-StoragePathId <String>] [-StoragePathName <String>] [-StoragePathResourceGroup <String>]
 [-Tags <Hashtable>] [-TimeZone <String>] [-VmMemory <Int64>] [-VmProcessors <Int32>] [-VmSize <VMSizeEnum>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByImageName
```
New-AzStackHCIVMVirtualMachine -Name <String> -ResourceGroupName <String> -CustomLocationId <String>
 -ImageName <String> -Location <String> -OsType <OSTypeEnum> [-SubscriptionId <String>]
 [-AdminPassword <String>] [-AdminUsername <String>] [-ComputerName <String>] [-DataDiskIds <String[]>]
 [-DataDiskNames <String[]>] [-DataDiskResourceGroup <String>] [-DisablePasswordAuthentication]
 [-DynamicMemoryMaximumMemory <Int64>] [-DynamicMemoryMinimumMemory <Int64>]
 [-DynamicMemoryTargetBuffer <Int32>] [-EnableAutomaticUpdate] [-EnableTpm]
 [-IdentityType <ResourceIdentityType>] [-ImageResourceGroup <String>] [-NicIds <String[]>]
 [-NicNames <String[]>] [-NicResourceGroup <String>] [-ProvisionVMAgent] [-SecureBootEnabled]
 [-SshPublicKeys <String[]>] [-StoragePathId <String>] [-StoragePathName <String>]
 [-StoragePathResourceGroup <String>] [-Tags <Hashtable>] [-TimeZone <String>] [-VmMemory <Int64>]
 [-VmProcessors <Int32>] [-VmSize <VMSizeEnum>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ByOsDiskId
```
New-AzStackHCIVMVirtualMachine -Name <String> -ResourceGroupName <String> -CustomLocationId <String>
 -Location <String> -OSDiskId <String> -OsType <OSTypeEnum> [-SubscriptionId <String>]
 [-AdminPassword <String>] [-AdminUsername <String>] [-ComputerName <String>] [-DataDiskIds <String[]>]
 [-DataDiskNames <String[]>] [-DataDiskResourceGroup <String>] [-DisablePasswordAuthentication]
 [-DynamicMemoryMaximumMemory <Int64>] [-DynamicMemoryMinimumMemory <Int64>]
 [-DynamicMemoryTargetBuffer <Int32>] [-EnableAutomaticUpdate] [-EnableTpm]
 [-IdentityType <ResourceIdentityType>] [-NicIds <String[]>] [-NicNames <String[]>]
 [-NicResourceGroup <String>] [-ProvisionVMAgent] [-SecureBootEnabled] [-SshPublicKeys <String[]>]
 [-StoragePathId <String>] [-StoragePathName <String>] [-StoragePathResourceGroup <String>]
 [-Tags <Hashtable>] [-TimeZone <String>] [-VmMemory <Int64>] [-VmProcessors <Int32>] [-VmSize <VMSizeEnum>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByOsDiskName
```
New-AzStackHCIVMVirtualMachine -Name <String> -ResourceGroupName <String> -CustomLocationId <String>
 -Location <String> -OSDiskName <String> -OsType <OSTypeEnum> [-SubscriptionId <String>]
 [-AdminPassword <String>] [-AdminUsername <String>] [-ComputerName <String>] [-DataDiskIds <String[]>]
 [-DataDiskNames <String[]>] [-DataDiskResourceGroup <String>] [-DisablePasswordAuthentication]
 [-DynamicMemoryMaximumMemory <Int64>] [-DynamicMemoryMinimumMemory <Int64>]
 [-DynamicMemoryTargetBuffer <Int32>] [-EnableAutomaticUpdate] [-EnableTpm]
 [-IdentityType <ResourceIdentityType>] [-NicIds <String[]>] [-NicNames <String[]>]
 [-NicResourceGroup <String>] [-OSDiskResourceGroup <String>] [-ProvisionVMAgent] [-SecureBootEnabled]
 [-SshPublicKeys <String[]>] [-StoragePathId <String>] [-StoragePathName <String>]
 [-StoragePathResourceGroup <String>] [-Tags <Hashtable>] [-TimeZone <String>] [-VmMemory <Int64>]
 [-VmProcessors <Int32>] [-VmSize <VMSizeEnum>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a virtual machine.
Please note some properties can be set only during virtual machine creation.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
{{ Add code here }}
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
{{ Add code here }}
```



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

### -ComputerName
ComputerName - name of the compute

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

### -DynamicMemoryMaximumMemory
.

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

### -DynamicMemoryMinimumMemory
.

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
Whether to EnableAutomaticUpdates on the machine

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
.

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
Resource ID of the image

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
NetworkInterfaces - list of network interfaces to be attached to the virtual machine
To construct, see NOTES section for NETWORKPROFILENETWORKINTERFACE properties and create a hash table.

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
NetworkInterfaces - list of network interfaces to be attached to the virtual machine
To construct, see NOTES section for NETWORKPROFILENETWORKINTERFACE properties and create a hash table.

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
NetworkInterfaces - list of network interfaces to be attached to the virtual machine
To construct, see NOTES section for NETWORKPROFILENETWORKINTERFACE properties and create a hash table.

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
Resource ID of the OS disk

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
Resource ID of the OS disk

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
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum
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
Id of the storage container that hosts the VM configuration file

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

### -VmMemory
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
number of processors for the virtual machine

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
.

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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachines

## NOTES

ALIASES

## RELATED LINKS

