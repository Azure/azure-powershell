---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/remove-azvmsslifecyclehook
schema: 2.0.0
---

# Remove-AzVmssLifecycleHook

## SYNOPSIS
Removes one or all lifecycle hooks from a Virtual Machine Scale Set (VMSS).

## SYNTAX

### ByTypeParameterSet (Default)
```
Remove-AzVmssLifecycleHook -ResourceGroupName <String> -VMScaleSetName <String> -Type <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AllParameterSet
```
Remove-AzVmssLifecycleHook -ResourceGroupName <String> -VMScaleSetName <String> [-All]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzVmssLifecycleHook** cmdlet removes one lifecycle hook (by `-Type`) or all lifecycle hooks (`-All`) from an existing virtual machine scale set (VMSS) by fetching the current VMSS, removing the specified hook(s), and updating the VMSS.

## EXAMPLES

### Example 1: Remove a lifecycle hook by type
```powershell
Remove-AzVmssLifecycleHook -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -Type 'UpgradeAutoOSScheduling'
```

This example removes the 'UpgradeAutoOSScheduling' lifecycle hook from the specified VMSS.

### Example 2: Remove all lifecycle hooks
```powershell
Remove-AzVmssLifecycleHook -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -All
```

This example removes all lifecycle hooks from the specified VMSS.

### Example 3: Preview removal with WhatIf
```powershell
Remove-AzVmssLifecycleHook -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -Type 'UpgradeAutoOSScheduling' -WhatIf
```

This example previews what would happen when removing the hook, without making any changes.

## PARAMETERS

### -All
When specified, removes all lifecycle hooks from the virtual machine scale set.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AllParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Type
The lifecycle hook type to remove. Possible values: 'UpgradeAutoOSScheduling', 'UpgradeAutoOSRollingBatchStarting'.

```yaml
Type: System.String
Parameter Sets: ByTypeParameterSet
Aliases:
Accepted values: UpgradeAutoOSScheduling, UpgradeAutoOSRollingBatchStarting

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VMScaleSetName
The name of the VM scale set.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSet

## NOTES

## RELATED LINKS

[New-AzVmssLifecycleHookConfig](./New-AzVmssLifecycleHookConfig.md)

[Set-AzVmssLifecycleHooksProfile](./Set-AzVmssLifecycleHooksProfile.md)

[Get-AzVmssLifecycleHookEvent](./Get-AzVmssLifecycleHookEvent.md)

[Update-AzVmssLifecycleHookEvent](./Update-AzVmssLifecycleHookEvent.md)
