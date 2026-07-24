---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/update-azvmsslifecyclehookevent
schema: 2.0.0
---

# Update-AzVmssLifecycleHookEvent

## SYNOPSIS
Responds to a Virtual Machine Scale Set (VMSS) lifecycle hook event by approving, rejecting, or delaying it.

## SYNTAX

### ByNameParameterSet (Default)
```
Update-AzVmssLifecycleHookEvent -ResourceGroupName <String> -VMScaleSetName <String> -Name <String>
 [-ActionState <String>] [-InstanceId <String[]>] [-WaitUntil <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzVmssLifecycleHookEvent -InputObject <VMScaleSetLifecycleHookEvent> [-ActionState <String>]
 [-InstanceId <String[]>] [-WaitUntil <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzVmssLifecycleHookEvent** cmdlet responds to a VMSS lifecycle hook event. You can:
- Approve or reject the event (`-ActionState`)
- Approve or reject a subset of VM instances (`-InstanceId` with `-ActionState`)
- Delay the event deadline (`-WaitUntil`)

The cmdlet accepts pipeline input from **Get-AzVmssLifecycleHookEvent**.

## EXAMPLES

### Example 1: Approve all targets in an event
```powershell
Update-AzVmssLifecycleHookEvent -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -Name $eventGuid -ActionState Approved
```

This example approves all target resources in the lifecycle hook event.

### Example 2: Reject all targets
```powershell
Update-AzVmssLifecycleHookEvent -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -Name $eventGuid -ActionState Rejected
```

This example rejects all target resources.

### Example 3: Approve a subset of VMs in a Uniform VMSS
```powershell
Update-AzVmssLifecycleHookEvent -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -Name $eventGuid -InstanceId '0','1','2' -ActionState Approved
```

This example approves VMs with instance IDs 0, 1, and 2 in a Uniform VMSS.

### Example 4: Approve a subset of VMs in a Flex VMSS
```powershell
Update-AzVmssLifecycleHookEvent -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -Name $eventGuid -InstanceId 'myvmss_3ec87a','myvmss_a1b2c3' -ActionState Approved
```

This example approves specific VM names in a Flex VMSS.

### Example 5: Delay the event deadline
```powershell
Update-AzVmssLifecycleHookEvent -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -Name $eventGuid -WaitUntil '2026-05-08T11:00:00Z'
```

This example delays the event deadline to the specified UTC timestamp.

### Example 6: Preview what would be approved
```powershell
Update-AzVmssLifecycleHookEvent -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -Name $eventGuid -ActionState Approved -WhatIf
```

This example shows what the cmdlet would do without making any changes.

### Example 7: Approve all active events via pipeline
```powershell
Get-AzVmssLifecycleHookEvent -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' |
    Where-Object { $_.Properties.State -eq 'Active' } |
    Update-AzVmssLifecycleHookEvent -ActionState Approved
```

This example retrieves all active lifecycle hook events and approves each one through the pipeline.

## PARAMETERS

### -ActionState
The action state to apply to the lifecycle hook event targets. Accepted values: 'Approved', 'Rejected'.

When `-InstanceId` is not specified, the action is applied to all target resources in the event. When `-InstanceId` is specified, only the matching targets are updated.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Approved, Rejected

Required: False
Position: Named
Default value: None
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

### -InputObject
The lifecycle hook event object from 'Get-AzVmssLifecycleHookEvent'. When using this parameter set, the resource group name, VMSS name, and event name are extracted from the object.

```yaml
Type: Microsoft.Azure.Management.Compute.Models.VMScaleSetLifecycleHookEvent
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceId
Filters the update to a subset of target VM instance IDs (decimal IDs for Uniform VMSS) or VM names (for Flex VMSS). When omitted, the action state is applied to all target resources in the event.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name (GUID) of the lifecycle hook event to update.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VMScaleSetName
The name of the VM scale set.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WaitUntil
Delays the event deadline to the specified UTC timestamp in ISO 8601 format (for example, '2026-05-08T11:00:00Z'). The timestamp must not exceed the event's MaxWaitUntil value.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
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

### Microsoft.Azure.Management.Compute.Models.VMScaleSetLifecycleHookEvent

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.Management.Compute.Models.VMScaleSetLifecycleHookEvent

## NOTES

## RELATED LINKS

[Get-AzVmssLifecycleHookEvent](./Get-AzVmssLifecycleHookEvent.md)

[New-AzVmssLifecycleHookConfig](./New-AzVmssLifecycleHookConfig.md)

[Set-AzVmssLifecycleHooksProfile](./Set-AzVmssLifecycleHooksProfile.md)

[Remove-AzVmssLifecycleHook](./Remove-AzVmssLifecycleHook.md)
