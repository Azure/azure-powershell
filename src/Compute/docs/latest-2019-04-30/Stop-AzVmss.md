---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/stop-azvmss
schema: 2.0.0
---

# Stop-AzVmss

## SYNOPSIS
Power off (stop) one or more virtual machines in a VM scale set.
Note that resources are still attached and you are getting charged for the resources.
Instead, use deallocate to release resources and avoid charges.

## SYNTAX

### PowerOff1 (Default)
```
Stop-AzVmss -ResourceGroupName <String> -SubscriptionId <String> -VMScaleSetName <String> [-SkipShutdown]
 [-PassThru] [-VMInstanceID <IVirtualMachineScaleSetVMInstanceIds>] [-DefaultProfile <PSObject>] [-AsJob]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PowerOffExpanded1
```
Stop-AzVmss -ResourceGroupName <String> -SubscriptionId <String> -VMScaleSetName <String> [-SkipShutdown]
 [-PassThru] [-InstanceId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### PowerOffViaIdentityExpanded1
```
Stop-AzVmss -InputObject <IComputeIdentity> [-SkipShutdown] [-PassThru] [-InstanceId <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PowerOffViaIdentity1
```
Stop-AzVmss -InputObject <IComputeIdentity> [-SkipShutdown] [-PassThru]
 [-VMInstanceID <IVirtualMachineScaleSetVMInstanceIds>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Power off (stop) one or more virtual machines in a VM scale set.
Note that resources are still attached and you are getting charged for the resources.
Instead, use deallocate to release resources and avoid charges.

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
Parameter Sets: PowerOffViaIdentityExpanded1, PowerOffViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InstanceId
The virtual machine scale set instance ids.
Omitting the virtual machine scale set instance ids will result in the operation being performed on all virtual machines in the virtual machine scale set.

```yaml
Type: System.String[]
Parameter Sets: PowerOffExpanded1, PowerOffViaIdentityExpanded1
Aliases:

Required: False
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
Parameter Sets: PowerOff1, PowerOffExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkipShutdown
The parameter to request non-graceful VM shutdown.
True value for this flag indicates non-graceful shutdown whereas false indicates otherwise.
Default value for this flag is false if not specified

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

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: PowerOff1, PowerOffExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VMInstanceID
Specifies a list of virtual machine instance IDs from the VM scale set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineScaleSetVMInstanceIds
Parameter Sets: PowerOff1, PowerOffViaIdentity1
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
Parameter Sets: PowerOff1, PowerOffExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineScaleSetVMInstanceIds

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### System.Boolean

## ALIASES

## RELATED LINKS

