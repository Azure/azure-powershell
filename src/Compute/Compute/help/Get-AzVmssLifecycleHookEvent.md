---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/get-azvmsslifecyclehookevent
schema: 2.0.0
---

# Get-AzVmssLifecycleHookEvent

## SYNOPSIS
Lists or retrieves lifecycle hook events for a Virtual Machine Scale Set (VMSS).

## SYNTAX

### ListParameterSet (Default)
```
Get-AzVmssLifecycleHookEvent -ResourceGroupName <String> -VMScaleSetName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetParameterSet
```
Get-AzVmssLifecycleHookEvent -ResourceGroupName <String> -VMScaleSetName <String> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzVmssLifecycleHookEvent** cmdlet lists all lifecycle hook events for a virtual machine scale set (VMSS) or retrieves a specific event by name (GUID). Lifecycle hook events are created by the platform when configured hooks fire during Auto OS Upgrade phases.

Events have a `Properties.State` of either 'Active' (waiting for a customer response) or 'Completed'.

## EXAMPLES

### Example 1: List all lifecycle hook events for a VMSS
```powershell
Get-AzVmssLifecycleHookEvent -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss'
```

This example lists all lifecycle hook events for the specified VMSS.

### Example 2: Get a specific event by name
```powershell
Get-AzVmssLifecycleHookEvent -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' -Name 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'
```

This example retrieves a specific lifecycle hook event by its GUID name.

### Example 3: Filter to active events only
```powershell
Get-AzVmssLifecycleHookEvent -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' |
    Where-Object { $_.Properties.State -eq 'Active' }
```

This example lists only the active lifecycle hook events.

### Example 4: Approve all active events via pipeline
```powershell
Get-AzVmssLifecycleHookEvent -ResourceGroupName 'myRg' -VMScaleSetName 'myVmss' |
    Where-Object { $_.Properties.State -eq 'Active' } |
    Update-AzVmssLifecycleHookEvent -ActionState Approved
```

This example retrieves all active events and approves each one through the pipeline.

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

### -Name
The name (GUID) of the lifecycle hook event to retrieve. When omitted, all events for the VMSS are listed.

```yaml
Type: System.String
Parameter Sets: GetParameterSet
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Management.Compute.Models.VMScaleSetLifecycleHookEvent

## NOTES

## RELATED LINKS

[Update-AzVmssLifecycleHookEvent](./Update-AzVmssLifecycleHookEvent.md)

[New-AzVmssLifecycleHookConfig](./New-AzVmssLifecycleHookConfig.md)

[Set-AzVmssLifecycleHooksProfile](./Set-AzVmssLifecycleHooksProfile.md)

[Remove-AzVmssLifecycleHook](./Remove-AzVmssLifecycleHook.md)
