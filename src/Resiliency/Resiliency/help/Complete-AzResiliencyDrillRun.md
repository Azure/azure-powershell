---
external help file:
Module Name: Az.Resiliency
online version: https://learn.microsoft.com/powershell/module/az.resiliency/complete-azresiliencydrillrun
schema: 2.0.0
---

# Complete-AzResiliencyDrillRun

## SYNOPSIS
This enables the user to mark this stage as complete, disabling further retries on it.

## SYNTAX

### CompleteExpanded (Default)
```
Complete-AzResiliencyDrillRun -DrillName <String> -Name <String> -ServiceGroupName <String>
 -OperationId <String> -DrillRunStage <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Complete
```
Complete-AzResiliencyDrillRun -DrillName <String> -Name <String> -ServiceGroupName <String>
 -OperationId <String> -Body <IMarkAsCompleteRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CompleteViaIdentity
```
Complete-AzResiliencyDrillRun -InputObject <IResiliencyIdentity> -OperationId <String>
 -Body <IMarkAsCompleteRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CompleteViaIdentityDrill
```
Complete-AzResiliencyDrillRun -DrillInputObject <IResiliencyIdentity> -Name <String> -OperationId <String>
 -Body <IMarkAsCompleteRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CompleteViaIdentityDrillExpanded
```
Complete-AzResiliencyDrillRun -DrillInputObject <IResiliencyIdentity> -Name <String> -OperationId <String>
 -DrillRunStage <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CompleteViaIdentityExpanded
```
Complete-AzResiliencyDrillRun -InputObject <IResiliencyIdentity> -OperationId <String> -DrillRunStage <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CompleteViaIdentityServiceGroup
```
Complete-AzResiliencyDrillRun -DrillName <String> -Name <String>
 -ServiceGroupInputObject <IResiliencyIdentity> -OperationId <String> -Body <IMarkAsCompleteRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CompleteViaIdentityServiceGroupExpanded
```
Complete-AzResiliencyDrillRun -DrillName <String> -Name <String>
 -ServiceGroupInputObject <IResiliencyIdentity> -OperationId <String> -DrillRunStage <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CompleteViaJsonFilePath
```
Complete-AzResiliencyDrillRun -DrillName <String> -Name <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CompleteViaJsonString
```
Complete-AzResiliencyDrillRun -DrillName <String> -Name <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This enables the user to mark this stage as complete, disabling further retries on it.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Request body for MarkAsComplete API.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IMarkAsCompleteRequest
Parameter Sets: Complete, CompleteViaIdentity, CompleteViaIdentityDrill, CompleteViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: CompleteViaIdentityDrill, CompleteViaIdentityDrillExpanded
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
Parameter Sets: Complete, CompleteExpanded, CompleteViaIdentityServiceGroup, CompleteViaIdentityServiceGroupExpanded, CompleteViaJsonFilePath, CompleteViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DrillRunStage
State of the Drill Run.

```yaml
Type: System.String
Parameter Sets: CompleteExpanded, CompleteViaIdentityDrillExpanded, CompleteViaIdentityExpanded, CompleteViaIdentityServiceGroupExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: CompleteViaIdentity, CompleteViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Complete operation

```yaml
Type: System.String
Parameter Sets: CompleteViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Complete operation

```yaml
Type: System.String
Parameter Sets: CompleteViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the DrillRun (GUID).

```yaml
Type: System.String
Parameter Sets: Complete, CompleteExpanded, CompleteViaIdentityDrill, CompleteViaIdentityDrillExpanded, CompleteViaIdentityServiceGroup, CompleteViaIdentityServiceGroupExpanded, CompleteViaJsonFilePath, CompleteViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: CompleteViaIdentityServiceGroup, CompleteViaIdentityServiceGroupExpanded
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
Parameter Sets: Complete, CompleteExpanded, CompleteViaJsonFilePath, CompleteViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IMarkAsCompleteRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IMarkAsCompleteResponse

## NOTES

## RELATED LINKS

