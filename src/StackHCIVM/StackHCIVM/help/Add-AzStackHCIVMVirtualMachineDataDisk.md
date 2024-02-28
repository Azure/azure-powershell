---
external help file: Az.StackHCIVM-help.xml
Module Name: Az.StackHCIVM
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/add-azstackhcivmvirtualmachinedatadisk
schema: 2.0.0
---

# Add-AzStackHCIVMVirtualMachineDataDisk

## SYNOPSIS
The operation to add a data disk to a virtual machine.

## SYNTAX

### ByResourceId (Default)
```
Add-AzStackHCIVMVirtualMachineDataDisk -ResourceId <String> [-DataDiskId <String[]>] [-DataDiskName <String[]>]
 [-DataDiskResourceGroup <String>] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByName
```
Add-AzStackHCIVMVirtualMachineDataDisk -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DataDiskId <String[]>] [-DataDiskName <String[]>] [-DataDiskResourceGroup <String>] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to add a data disk to a virtual machine.

## EXAMPLES

### EXAMPLE 1
```
Add-AzStackHCIVMVirtualMachineDataDisk  -Name 'testVm' -ResourceGroupName 'test-rg'  -DataDiskName 'testVhd'
```

## PARAMETERS

### -DataDiskId
List of data disks to be attached to the virtual machine passed in Id format

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

### -DataDiskName
List of data disks to be attached to the virtual machine passed by Name

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
Resource Group of the Data Disks

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

### -Name
Name of the virtual machine

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: VirtualMachineName

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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The ARM Resource ID of the VM

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: ByName
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable, -ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IVirtualMachineInstance
## NOTES

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.stackhcivm/add-azstackhcivmvirtualmachinedatadisk](https://learn.microsoft.com/powershell/module/az.stackhcivm/add-azstackhcivmvirtualmachinedatadisk)
