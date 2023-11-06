---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhci/update-azstackhcivmvirtualmachine
schema: 2.0.0
---

# Update-AzStackHCIVmVirtualMachine

## SYNOPSIS
The operation to update a virtual machine instance.

## SYNTAX

### ByResourceId (Default)
```
Update-AzStackHCIVmVirtualMachine -ResourceId <String> [-ProvisionVMAgent] [-ProvisionVMConfigAgent]
 [-VmMemoryInMB <Int64>] [-VmProcessors <Int32>] [-VmSize <VMSizeEnum>] [<CommonParameters>]
```

### ByName
```
Update-AzStackHCIVmVirtualMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ProvisionVMAgent] [-ProvisionVMConfigAgent] [-VmMemoryInMB <Int64>] [-VmProcessors <Int32>]
 [-VmSize <VMSizeEnum>] [<CommonParameters>]
```

## DESCRIPTION
The operation to update a virtual machine instance.

## EXAMPLES

### Example 1: Update the Size of the Virtual Machine. 
```powershell
PS C:\> Update-AzStackHCIVmVirtualMachine  -Name "testVm" -ResourceGroupName "test-rg" -VmMemoryInMB "4"
```

```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```

This command updates an existing virtual machine in the specified resource group.

## PARAMETERS

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

### -ProvisionVMAgent
Indicates whether virtual machine agent should be provisioned on the virtual machine.

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
The ARM Resource ID of the virtual network.

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

Required: True
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VmMemoryInMB
RAM in MB for the virtual machine instance

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
number of processors for the virtual machine instance

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IVirtualMachineInstance

## NOTES

ALIASES

## RELATED LINKS

