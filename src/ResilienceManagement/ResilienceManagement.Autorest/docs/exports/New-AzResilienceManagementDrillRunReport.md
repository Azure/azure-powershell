---
external help file:
Module Name: Az.ResilienceManagement
online version: https://learn.microsoft.com/powershell/module/az.resiliencemanagement/new-azresiliencemanagementdrillrunreport
schema: 2.0.0
---

# New-AzResilienceManagementDrillRunReport

## SYNOPSIS
This generates, or regenerates, the report for this Drill Run.
The action is idempotent and is safe to call at any time: a call that arrives while a generation is already running joins it, and a call made after a failed attempt retries it.
A report that has been finalized is never regenerated.

## SYNTAX

### Generate (Default)
```
New-AzResilienceManagementDrillRunReport -DrillName <String> -DrillRunName <String> -ServiceGroupName <String>
 -OperationId <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GenerateViaIdentity
```
New-AzResilienceManagementDrillRunReport -InputObject <IResilienceManagementIdentity> -OperationId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GenerateViaIdentityDrill
```
New-AzResilienceManagementDrillRunReport -DrillInputObject <IResilienceManagementIdentity>
 -DrillRunName <String> -OperationId <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### GenerateViaIdentityServiceGroup
```
New-AzResilienceManagementDrillRunReport -DrillName <String> -DrillRunName <String>
 -ServiceGroupInputObject <IResilienceManagementIdentity> -OperationId <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This generates, or regenerates, the report for this Drill Run.
The action is idempotent and is safe to call at any time: a call that arrives while a generation is already running joins it, and a call made after a failed attempt retries it.
A report that has been finalized is never regenerated.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
{{ Add code here }}
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
{{ Add code here }}
```



## PARAMETERS

### -AsJob
Run the command as a job

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -DrillInputObject
Identity Parameter
To construct, see NOTES section for DRILLINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: GenerateViaIdentityDrill
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DrillName
The name of the Drill

```yaml
Type: System.String
Parameter Sets: Generate, GenerateViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DrillRunName
The name of the DrillRun (GUID).

```yaml
Type: System.String
Parameter Sets: Generate, GenerateViaIdentityDrill, GenerateViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: GenerateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -OperationId
A GUID that represents the Long Running OperationId.

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

### -ServiceGroupInputObject
Identity Parameter
To construct, see NOTES section for SERVICEGROUPINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: GenerateViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupName
The name of the service group.

```yaml
Type: System.String
Parameter Sets: Generate
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IDrillReportSummary

## NOTES

## RELATED LINKS

