---
external help file:
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/resume-azresiliencedrillrun
schema: 2.0.0
---

# Resume-AzResilienceDrillRun

## SYNOPSIS
This unblocks a Failover workflow that is paused after the Fault stage, to proceed to the Failover stage.

## SYNTAX

### Resume (Default)
```
Resume-AzResilienceDrillRun -DrillName <String> -Name <String> -ServiceGroupName <String>
 -OperationId <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ResumeViaIdentity
```
Resume-AzResilienceDrillRun -InputObject <IResilienceIdentity> -OperationId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResumeViaIdentityDrill
```
Resume-AzResilienceDrillRun -DrillInputObject <IResilienceIdentity> -Name <String> -OperationId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResumeViaIdentityServiceGroup
```
Resume-AzResilienceDrillRun -DrillName <String> -Name <String> -ServiceGroupInputObject <IResilienceIdentity>
 -OperationId <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
This unblocks a Failover workflow that is paused after the Fault stage, to proceed to the Failover stage.

## EXAMPLES

### Example 1: Resume a drill run
```powershell
Resume-AzResilienceDrillRun `
  -DrillName 'drill-zonal-payments' `
  -Name '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Resumes a drill run that is paused awaiting operator input.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: ResumeViaIdentityDrill
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
Parameter Sets: Resume, ResumeViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: ResumeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the DrillRun (GUID).

```yaml
Type: System.String
Parameter Sets: Resume, ResumeViaIdentityDrill, ResumeViaIdentityServiceGroup
Aliases: DrillRunName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: ResumeViaIdentityServiceGroup
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
Parameter Sets: Resume
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrillRunActionResponse

## NOTES

## RELATED LINKS

