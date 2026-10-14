---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/set-azvmsslifecyclehooksprofile
schema: 2.0.0
---

# Set-AzVmssLifecycleHooksProfile

## SYNOPSIS
Attaches lifecycle hooks to a Virtual Machine Scale Set (VMSS) configuration or live VMSS object.

## SYNTAX

```
Set-AzVmssLifecycleHooksProfile -VirtualMachineScaleSet <PSVirtualMachineScaleSet>
 -LifecycleHook <LifecycleHook[]> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzVmssLifecycleHooksProfile** cmdlet attaches lifecycle hooks to a VMSS configuration object (PSVirtualMachineScaleSet) and returns the updated object. This follows the standard Az.Compute builder convention (same as Set-AzVmssOsProfile, Set-AzVmssStorageProfile): it mutates the VMSS config object AND returns it.

The updated object must be passed to **New-AzVmss** (for new scale sets) or **Update-AzVmss** (for existing scale sets) to persist the changes to Azure.

## EXAMPLES

### Example 1: Attach a lifecycle hook to a new VMSS configuration
```powershell
$hook   = New-AzVmssLifecycleHookConfig -Type 'UpgradeAutoOSScheduling' -WaitDuration 'PT8H'
$config = New-AzVmssConfig -Location 'eastus' -SkuCapacity 2
$config = Set-AzVmssLifecycleHooksProfile -VirtualMachineScaleSet $config -LifecycleHook $hook
New-AzVmss -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -VirtualMachineScaleSet $config
```

This example creates a new VMSS with a lifecycle hook attached.

### Example 2: Add a lifecycle hook to an existing VMSS
```powershell
$vmss     = Get-AzVmss -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss'
$existing = if ($vmss.LifecycleHooksProfile) { $vmss.LifecycleHooksProfile.LifecycleHooks } else { @() }
$batch    = New-AzVmssLifecycleHookConfig -Type 'UpgradeAutoOSRollingBatchStarting' -WaitDuration 'PT30M'
$vmss     = Set-AzVmssLifecycleHooksProfile -VirtualMachineScaleSet $vmss -LifecycleHook ($existing + $batch)
Update-AzVmss -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -VirtualMachineScaleSet $vmss
```

This example adds a second lifecycle hook to an existing VMSS, preserving the existing hooks.

### Example 3: Use pipeline to attach hooks
```powershell
$hook = New-AzVmssLifecycleHookConfig -Type 'UpgradeAutoOSScheduling' -WaitDuration 'PT8H'
New-AzVmssConfig -Location 'eastus' -SkuCapacity 2 | Set-AzVmssLifecycleHooksProfile -LifecycleHook $hook
```

This example uses the pipeline to attach a lifecycle hook to a VMSS configuration.

## PARAMETERS

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

### -LifecycleHook
One or more lifecycle hook objects to attach to the VMSS. Use 'New-AzVmssLifecycleHookConfig' to create hook objects. Replaces any existing lifecycle hooks on the VMSS config object.

```yaml
Type: Microsoft.Azure.Management.Compute.Models.LifecycleHook[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualMachineScaleSet
The VMSS configuration object (PSVirtualMachineScaleSet) to update. Can be an in-memory config from 'New-AzVmssConfig' or a live VMSS object from 'Get-AzVmss'.

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSet
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue, ByPropertyName)
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

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSet

### Microsoft.Azure.Management.Compute.Models.LifecycleHook[]

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSet

## NOTES

## RELATED LINKS

[New-AzVmssLifecycleHookConfig](./New-AzVmssLifecycleHookConfig.md)

[New-AzVmssConfig](./New-AzVmssConfig.md)

[Remove-AzVmssLifecycleHook](./Remove-AzVmssLifecycleHook.md)

[Get-AzVmssLifecycleHookEvent](./Get-AzVmssLifecycleHookEvent.md)

[Update-AzVmssLifecycleHookEvent](./Update-AzVmssLifecycleHookEvent.md)
