---
external help file: Az.Resilience-help.xml
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/complete-azresiliencedrillrun
schema: 2.0.0
---

# Complete-AzResilienceDrillRun

## SYNOPSIS
This enables the user to mark this stage as complete, disabling further retries on it.

## SYNTAX

### CompleteExpanded (Default)
```
Complete-AzResilienceDrillRun -DrillName <String> -Name <String> -ServiceGroupName <String>
 -OperationId <String> -DrillRunStage <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompleteViaJsonString
```
Complete-AzResilienceDrillRun -DrillName <String> -Name <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompleteViaJsonFilePath
```
Complete-AzResilienceDrillRun -DrillName <String> -Name <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompleteViaIdentityServiceGroupExpanded
```
Complete-AzResilienceDrillRun -DrillName <String> -Name <String> -ServiceGroupInputObject <IResilienceIdentity>
 -OperationId <String> -DrillRunStage <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompleteViaIdentityServiceGroup
```
Complete-AzResilienceDrillRun -DrillName <String> -Name <String> -ServiceGroupInputObject <IResilienceIdentity>
 -OperationId <String> -Body <IMarkAsCompleteRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Complete
```
Complete-AzResilienceDrillRun -DrillName <String> -Name <String> -ServiceGroupName <String>
 -OperationId <String> -Body <IMarkAsCompleteRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompleteViaIdentityDrillExpanded
```
Complete-AzResilienceDrillRun -Name <String> -DrillInputObject <IResilienceIdentity> -OperationId <String>
 -DrillRunStage <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompleteViaIdentityDrill
```
Complete-AzResilienceDrillRun -Name <String> -DrillInputObject <IResilienceIdentity> -OperationId <String>
 -Body <IMarkAsCompleteRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompleteViaIdentityExpanded
```
Complete-AzResilienceDrillRun -InputObject <IResilienceIdentity> -OperationId <String> -DrillRunStage <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CompleteViaIdentity
```
Complete-AzResilienceDrillRun -InputObject <IResilienceIdentity> -OperationId <String>
 -Body <IMarkAsCompleteRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This enables the user to mark this stage as complete, disabling further retries on it.

## EXAMPLES

### Example 1: Complete a drill run
```powershell
Complete-AzResilienceDrillRun `
  -DrillName 'drill-zonal-payments' `
  -Name '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -DrillRunStage 'Failover'
```

Marks the specified drill run stage as complete, disabling further retries.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IMarkAsCompleteRequest
Parameter Sets: CompleteViaIdentityServiceGroup, Complete, CompleteViaIdentityDrill, CompleteViaIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: CompleteViaIdentityDrillExpanded, CompleteViaIdentityDrill
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
Parameter Sets: CompleteExpanded, CompleteViaJsonString, CompleteViaJsonFilePath, CompleteViaIdentityServiceGroupExpanded, CompleteViaIdentityServiceGroup, Complete
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
Parameter Sets: CompleteExpanded, CompleteViaIdentityServiceGroupExpanded, CompleteViaIdentityDrillExpanded, CompleteViaIdentityExpanded
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
Parameter Sets: CompleteViaIdentityExpanded, CompleteViaIdentity
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
Parameter Sets: CompleteExpanded, CompleteViaJsonString, CompleteViaJsonFilePath, CompleteViaIdentityServiceGroupExpanded, CompleteViaIdentityServiceGroup, Complete, CompleteViaIdentityDrillExpanded, CompleteViaIdentityDrill
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
Parameter Sets: CompleteViaIdentityServiceGroupExpanded, CompleteViaIdentityServiceGroup
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
Parameter Sets: CompleteExpanded, CompleteViaJsonString, CompleteViaJsonFilePath, Complete
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IMarkAsCompleteRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IMarkAsCompleteResponse

## NOTES

## RELATED LINKS
