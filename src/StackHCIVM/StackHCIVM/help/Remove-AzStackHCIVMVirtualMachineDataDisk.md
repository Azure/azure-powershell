---
external help file: Az.StackHCIVM-help.xml
Module Name: Az.StackHCIVM
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/remove-azstackhcivmvirtualmachinedatadisk
schema: 2.0.0
---

# Remove-AzStackHCIVMVirtualMachineDataDisk

## SYNOPSIS
The operation to delete a data disk from a virtual machine.

## SYNTAX

### ByResourceId (Default)
```
Remove-AzStackHCIVMVirtualMachineDataDisk -ResourceId <String> [-DataDiskId <String[]>]
 [-DataDiskName <String[]>] [-DataDiskResourceGroup <String>] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByName
```
Remove-AzStackHCIVMVirtualMachineDataDisk -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DataDiskId <String[]>] [-DataDiskName <String[]>] [-DataDiskResourceGroup <String>] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to delete a data disk from a  virtual machine.

## EXAMPLES

### Example 1: Removes a Data Disk from a Virtual Machine
```powershell
Remove-AzStackHCIVMVirtualMachineDataDisk  -Name "testVm" -ResourceGroupName "test-rg"  -DataDiskName "testVhd"
```

```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```

This command removes a data disk from the virtual machine in the specified resource group.

## PARAMETERS

### -DataDiskId
Data Disks - list of data disks to be removed from  the virtual machine in id format.

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
Data Disks - list of data disks to be removed from  the virtual machine in name format.

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
Resource Group of the Data Disks.

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
Default value: None
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
The ARM Resource ID of the virtual machine.

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
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IVirtualMachineInstance

## NOTES

## RELATED LINKS
