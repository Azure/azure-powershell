---
external help file:
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/invoke-azresiliencedrillrunfailover
schema: 2.0.0
---

# Invoke-AzResilienceDrillRunFailover

## SYNOPSIS
This initiates a new Failover operation on this Drill Run.

## SYNTAX

### InvokeExpanded (Default)
```
Invoke-AzResilienceDrillRunFailover -DrillName <String> -DrillRunName <String> -ServiceGroupName <String>
 -OperationId <String> [-AutoFailover <String>] [-ExecutionConfigurationUserConsent <String>]
 [-FailoverRequestPropertySelectedResourceId <String[]>] [-FailoverRequestPropertySourceLocation <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Invoke
```
Invoke-AzResilienceDrillRunFailover -DrillName <String> -DrillRunName <String> -ServiceGroupName <String>
 -OperationId <String> -Body <IDrillRunFailoverRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaIdentity
```
Invoke-AzResilienceDrillRunFailover -InputObject <IResilienceIdentity> -OperationId <String>
 -Body <IDrillRunFailoverRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### InvokeViaIdentityDrill
```
Invoke-AzResilienceDrillRunFailover -DrillInputObject <IResilienceIdentity> -DrillRunName <String>
 -OperationId <String> -Body <IDrillRunFailoverRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaIdentityDrillExpanded
```
Invoke-AzResilienceDrillRunFailover -DrillInputObject <IResilienceIdentity> -DrillRunName <String>
 -OperationId <String> [-AutoFailover <String>] [-ExecutionConfigurationUserConsent <String>]
 [-FailoverRequestPropertySelectedResourceId <String[]>] [-FailoverRequestPropertySourceLocation <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaIdentityExpanded
```
Invoke-AzResilienceDrillRunFailover -InputObject <IResilienceIdentity> -OperationId <String>
 [-AutoFailover <String>] [-ExecutionConfigurationUserConsent <String>]
 [-FailoverRequestPropertySelectedResourceId <String[]>] [-FailoverRequestPropertySourceLocation <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaIdentityServiceGroup
```
Invoke-AzResilienceDrillRunFailover -DrillName <String> -DrillRunName <String>
 -ServiceGroupInputObject <IResilienceIdentity> -OperationId <String> -Body <IDrillRunFailoverRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaIdentityServiceGroupExpanded
```
Invoke-AzResilienceDrillRunFailover -DrillName <String> -DrillRunName <String>
 -ServiceGroupInputObject <IResilienceIdentity> -OperationId <String> [-AutoFailover <String>]
 [-ExecutionConfigurationUserConsent <String>] [-FailoverRequestPropertySelectedResourceId <String[]>]
 [-FailoverRequestPropertySourceLocation <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaJsonFilePath
```
Invoke-AzResilienceDrillRunFailover -DrillName <String> -DrillRunName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### InvokeViaJsonString
```
Invoke-AzResilienceDrillRunFailover -DrillName <String> -DrillRunName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This initiates a new Failover operation on this Drill Run.

## EXAMPLES

### Example 1: Run drill run failover
```powershell
Invoke-AzResilienceDrillRunFailover `
  -DrillName 'drill-zonal-payments' `
  -DrillRunName '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -FailoverRequestPropertySourceLocation @('eastus')
```

Starts the drill run failover operation and returns the job that tracks it.

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

### -AutoFailover
AutoFailover - whether to pause between Fault and Failover for manual input.

```yaml
Type: System.String
Parameter Sets: InvokeExpanded, InvokeViaIdentityDrillExpanded, InvokeViaIdentityExpanded, InvokeViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Request body for Failover API.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrillRunFailoverRequest
Parameter Sets: Invoke, InvokeViaIdentity, InvokeViaIdentityDrill, InvokeViaIdentityServiceGroup
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
Parameter Sets: InvokeViaIdentityDrill, InvokeViaIdentityDrillExpanded
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
Parameter Sets: Invoke, InvokeExpanded, InvokeViaIdentityServiceGroup, InvokeViaIdentityServiceGroupExpanded, InvokeViaJsonFilePath, InvokeViaJsonString
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
Parameter Sets: Invoke, InvokeExpanded, InvokeViaIdentityDrill, InvokeViaIdentityDrillExpanded, InvokeViaIdentityServiceGroup, InvokeViaIdentityServiceGroupExpanded, InvokeViaJsonFilePath, InvokeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExecutionConfigurationUserConsent
User consent for performing recovery action.

```yaml
Type: System.String
Parameter Sets: InvokeExpanded, InvokeViaIdentityDrillExpanded, InvokeViaIdentityExpanded, InvokeViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FailoverRequestPropertySelectedResourceId
Selected recovery resource Ids to be processed.
If not provided, all qualified resources based on the source location(s) will be processed.

```yaml
Type: System.String[]
Parameter Sets: InvokeExpanded, InvokeViaIdentityDrillExpanded, InvokeViaIdentityExpanded, InvokeViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FailoverRequestPropertySourceLocation
Source locations from where resources to be failed-over.

```yaml
Type: System.String[]
Parameter Sets: InvokeExpanded, InvokeViaIdentityDrillExpanded, InvokeViaIdentityExpanded, InvokeViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: InvokeViaIdentity, InvokeViaIdentityExpanded
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

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: InvokeViaIdentityServiceGroup, InvokeViaIdentityServiceGroupExpanded
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
Parameter Sets: Invoke, InvokeExpanded, InvokeViaJsonFilePath, InvokeViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrillRunFailoverRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrillRunActionResponse

## NOTES

## RELATED LINKS

