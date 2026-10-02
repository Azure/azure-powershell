---
external help file: Az.Resilience-help.xml
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/invoke-azresiliencedrillrunreprotect
schema: 2.0.0
---

# Invoke-AzResilienceDrillRunReprotect

## SYNOPSIS
This initiates a new Reprotect operation on this Drill Run.

## SYNTAX

### InvokeExpanded (Default)
```
Invoke-AzResilienceDrillRunReprotect -DrillName <String> -DrillRunName <String> -ServiceGroupName <String>
 -OperationId <String> [-ReprotectRequestPropertySelectedResourceId <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeViaJsonString
```
Invoke-AzResilienceDrillRunReprotect -DrillName <String> -DrillRunName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeViaJsonFilePath
```
Invoke-AzResilienceDrillRunReprotect -DrillName <String> -DrillRunName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeViaIdentityServiceGroupExpanded
```
Invoke-AzResilienceDrillRunReprotect -DrillName <String> -DrillRunName <String>
 -ServiceGroupInputObject <IResilienceIdentity> -OperationId <String>
 [-ReprotectRequestPropertySelectedResourceId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeViaIdentityServiceGroup
```
Invoke-AzResilienceDrillRunReprotect -DrillName <String> -DrillRunName <String>
 -ServiceGroupInputObject <IResilienceIdentity> -OperationId <String> -Body <IDrillRunReprotectRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Invoke
```
Invoke-AzResilienceDrillRunReprotect -DrillName <String> -DrillRunName <String> -ServiceGroupName <String>
 -OperationId <String> -Body <IDrillRunReprotectRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeViaIdentityDrillExpanded
```
Invoke-AzResilienceDrillRunReprotect -DrillRunName <String> -DrillInputObject <IResilienceIdentity>
 -OperationId <String> [-ReprotectRequestPropertySelectedResourceId <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeViaIdentityDrill
```
Invoke-AzResilienceDrillRunReprotect -DrillRunName <String> -DrillInputObject <IResilienceIdentity>
 -OperationId <String> -Body <IDrillRunReprotectRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeViaIdentityExpanded
```
Invoke-AzResilienceDrillRunReprotect -InputObject <IResilienceIdentity> -OperationId <String>
 [-ReprotectRequestPropertySelectedResourceId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeViaIdentity
```
Invoke-AzResilienceDrillRunReprotect -InputObject <IResilienceIdentity> -OperationId <String>
 -Body <IDrillRunReprotectRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This initiates a new Reprotect operation on this Drill Run.

## EXAMPLES

### Example 1: Run drill run reprotect
```powershell
Invoke-AzResilienceDrillRunReprotect `
  -DrillName 'drill-zonal-payments' `
  -DrillRunName '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Starts the drill run reprotect operation and returns the job that tracks it.

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
Request body for Reprotect API.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrillRunReprotectRequest
Parameter Sets: InvokeViaIdentityServiceGroup, Invoke, InvokeViaIdentityDrill, InvokeViaIdentity
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
Parameter Sets: InvokeViaIdentityDrillExpanded, InvokeViaIdentityDrill
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
Parameter Sets: InvokeExpanded, InvokeViaJsonString, InvokeViaJsonFilePath, InvokeViaIdentityServiceGroupExpanded, InvokeViaIdentityServiceGroup, Invoke
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
Parameter Sets: InvokeExpanded, InvokeViaJsonString, InvokeViaJsonFilePath, InvokeViaIdentityServiceGroupExpanded, InvokeViaIdentityServiceGroup, Invoke, InvokeViaIdentityDrillExpanded, InvokeViaIdentityDrill
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
Parameter Sets: InvokeViaIdentityExpanded, InvokeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Invoke operation

```yaml
Type: System.String
Parameter Sets: InvokeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Invoke operation

```yaml
Type: System.String
Parameter Sets: InvokeViaJsonString
Aliases:

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

### -ReprotectRequestPropertySelectedResourceId
Selected recovery resource Ids to be processed.
If not provided, all qualified resources will be processed.

```yaml
Type: System.String[]
Parameter Sets: InvokeExpanded, InvokeViaIdentityServiceGroupExpanded, InvokeViaIdentityDrillExpanded, InvokeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: InvokeViaIdentityServiceGroupExpanded, InvokeViaIdentityServiceGroup
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
Parameter Sets: InvokeExpanded, InvokeViaJsonString, InvokeViaJsonFilePath, Invoke
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrillRunReprotectRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrillRunActionResponse

## NOTES

## RELATED LINKS
