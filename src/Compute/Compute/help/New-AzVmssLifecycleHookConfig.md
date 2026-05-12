---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azvmsslifecyclehookconfig
schema: 2.0.0
---

# New-AzVmssLifecycleHookConfig

## SYNOPSIS
Creates an in-memory lifecycle hook configuration object for use with a Virtual Machine Scale Set (VMSS).

## SYNTAX

```
New-AzVmssLifecycleHookConfig -Type <String> [-WaitDuration <String>] [-DefaultAction <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzVmssLifecycleHookConfig** cmdlet creates a lifecycle hook configuration object that can be passed to **Set-AzVmssLifecycleHooksProfile** or **New-AzVmssConfig**.

Lifecycle hooks let customers register hooks that fire before VMSS Auto OS Upgrade phases, then respond to events on a per-VM basis (approve, reject, or delay) before the platform proceeds.

> **Preview note:** During preview, the `-DefaultAction` value `Reject` returns a server-side validation error. No client change is required at GA.

## EXAMPLES

### Example 1: Create a lifecycle hook for Auto OS upgrade scheduling
```powershell
$hook = New-AzVmssLifecycleHookConfig -Type 'UpgradeAutoOSScheduling' -WaitDuration 'PT8H'
```

This example creates a lifecycle hook that fires before Auto OS Upgrade scheduling, with an 8-hour wait duration before the default action (Approve) is applied.

### Example 2: Create a lifecycle hook with explicit default action
```powershell
$hook = New-AzVmssLifecycleHookConfig -Type 'UpgradeAutoOSRollingBatchStarting' -WaitDuration 'PT30M' -DefaultAction 'Approve'
```

This example creates a lifecycle hook that fires before each rolling batch starts, with a 30-minute wait duration and an explicit default action of Approve.

### Example 3: Use the hook in a new VMSS
```powershell
$hook   = New-AzVmssLifecycleHookConfig -Type 'UpgradeAutoOSScheduling' -WaitDuration 'PT8H'
$config = New-AzVmssConfig -Location 'eastus' -SkuCapacity 2
$config = Set-AzVmssLifecycleHooksProfile -VirtualMachineScaleSet $config -LifecycleHook $hook
New-AzVmss -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -VirtualMachineScaleSet $config
```

This example creates a VMSS with a lifecycle hook attached.

## PARAMETERS

### -DefaultAction
Specifies the action applied to a target resource in the lifecycle hook event if the platform does not receive a response from the customer before the wait duration expires. Accepted values: 'Approve' (default), 'Reject'.

> **Preview note:** 'Reject' returns a server error during preview.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Approve, Reject

Required: False
Position: 2
Default value: Approve
Accept pipeline input: True (ByPropertyName)
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

### -Type
Specifies the type of the lifecycle hook. Possible values: 'UpgradeAutoOSScheduling', 'UpgradeAutoOSRollingBatchStarting'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: UpgradeAutoOSScheduling, UpgradeAutoOSRollingBatchStarting

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WaitDuration
Specifies the time duration the lifecycle hook event waits for a customer response before applying the default action. Must be in ISO 8601 duration format, for example 'PT8H' (8 hours) or 'PT30M' (30 minutes).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.Management.Compute.Models.LifecycleHook

## NOTES

## RELATED LINKS

[Set-AzVmssLifecycleHooksProfile](./Set-AzVmssLifecycleHooksProfile.md)

[New-AzVmssConfig](./New-AzVmssConfig.md)

[Get-AzVmssLifecycleHookEvent](./Get-AzVmssLifecycleHookEvent.md)

[Update-AzVmssLifecycleHookEvent](./Update-AzVmssLifecycleHookEvent.md)

[Remove-AzVmssLifecycleHook](./Remove-AzVmssLifecycleHook.md)
