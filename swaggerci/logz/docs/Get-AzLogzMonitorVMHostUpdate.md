---
external help file:
Module Name: Az.Logz
online version: https://docs.microsoft.com/en-us/powershell/module/az.logz/get-azlogzmonitorvmhostupdate
schema: 2.0.0
---

# Get-AzLogzMonitorVMHostUpdate

## SYNOPSIS
Sending request to update the collection when Logz.io agent has been installed on a VM for a given monitor.

## SYNTAX

### ListExpanded (Default)
```
Get-AzLogzMonitorVMHostUpdate -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-State <VMHostUpdateStates>] [-VMResourceId <IVMResources[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### List
```
Get-AzLogzMonitorVMHostUpdate -MonitorName <String> -ResourceGroupName <String> -Body <IVMHostUpdateRequest>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Sending request to update the collection when Logz.io agent has been installed on a VM for a given monitor.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Body
Request of a list VM Host Update Operation.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001.IVMHostUpdateRequest
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
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
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Specifies the state of the operation - install/ delete.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Support.VMHostUpdateStates
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMResourceId
Request of a list vm host update operation.
To construct, see NOTES section for VMRESOURCEID properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001.IVMResources[]
Parameter Sets: ListExpanded
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001.IVMHostUpdateRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001.IVMResources

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IVMHostUpdateRequest>: Request of a list VM Host Update Operation.
  - `[State <VMHostUpdateStates?>]`: Specifies the state of the operation - install/ delete.
  - `[VMResourceId <IVMResources[]>]`: Request of a list vm host update operation.
    - `[AgentVersion <String>]`: Version of the Logz agent installed on the VM.
    - `[Id <String>]`: Request of a list vm host update operation.

VMRESOURCEID <IVMResources[]>: Request of a list vm host update operation.
  - `[AgentVersion <String>]`: Version of the Logz agent installed on the VM.
  - `[Id <String>]`: Request of a list vm host update operation.

## RELATED LINKS

