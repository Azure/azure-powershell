---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/invoke-azvmssvmreimage
schema: 2.0.0
---

# Invoke-AzVmssVMReimage

## SYNOPSIS
Reimages (upgrade the operating system) a specific virtual machine in a VM scale set.

## SYNTAX

### Reimage2 (Default)
```
Invoke-AzVmssVMReimage -InstanceId <String> -ResourceGroupName <String> -SubscriptionId <String>
 -VMScaleSetName <String> [-PassThru] [-VirtualMachineScaleSetVM <IVirtualMachineScaleSetVMReimageParameters>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReimageExpanded
```
Invoke-AzVmssVMReimage -InstanceId <String> -ResourceGroupName <String> -SubscriptionId <String>
 -VMScaleSetName <String> [-PassThru] [-TempDisk] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Reimage3
```
Invoke-AzVmssVMReimage -InstanceId <String> -ResourceGroupName <String> -SubscriptionId <String>
 -VMScaleSetName <String> [-PassThru] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ReimageViaIdentityExpanded
```
Invoke-AzVmssVMReimage -InputObject <IComputeIdentity> [-PassThru] [-TempDisk] [-DefaultProfile <PSObject>]
 [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReimageViaIdentity3
```
Invoke-AzVmssVMReimage -InputObject <IComputeIdentity> [-PassThru] [-DefaultProfile <PSObject>] [-AsJob]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReimageViaIdentity2
```
Invoke-AzVmssVMReimage -InputObject <IComputeIdentity> [-PassThru]
 [-VirtualMachineScaleSetVM <IVirtualMachineScaleSetVMReimageParameters>] [-DefaultProfile <PSObject>]
 [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Reimages (upgrade the operating system) a specific virtual machine in a VM scale set.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: ReimageViaIdentityExpanded, ReimageViaIdentity3, ReimageViaIdentity2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InstanceId
The instance ID of the virtual machine.

```yaml
Type: System.String
Parameter Sets: Reimage2, ReimageExpanded, Reimage3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Reimage2, ReimageExpanded, Reimage3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Reimage2, ReimageExpanded, Reimage3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TempDisk
Specifies whether to reimage temp disk.
Default value: false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ReimageExpanded, ReimageViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualMachineScaleSetVM
Describes a Virtual Machine Scale Set VM Reimage Parameters.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSetVMReimageParameters
Parameter Sets: Reimage2, ReimageViaIdentity2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -VMScaleSetName
The name of the VM scale set.

```yaml
Type: System.String
Parameter Sets: Reimage2, ReimageExpanded, Reimage3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSetVMReimageParameters

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### System.Boolean

## ALIASES

### Update-AzVmssVM

## RELATED LINKS

