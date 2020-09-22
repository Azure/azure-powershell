---
external help file:
Module Name: Az.Migrate
online version: https://docs.microsoft.com/en-us/powershell/module/az.migrate/get-azmigratejob
schema: 2.0.0
---

# Get-AzMigrateJob

## SYNOPSIS
Retrieves the status of an Azure Migrate job.

## SYNTAX

### GetByName (Default)
```
Get-AzMigrateJob -JobName <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GetByID
```
Get-AzMigrateJob -JobID <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetByInputObject
```
Get-AzMigrateJob -InputObject <IJob> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzMigrateJob cmdlet retrives the status of an Azure Migrate job.

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
Default value: None
Accept pipeline input: False
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

### -InputObject
Specifies the job object of the replicating server.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob
Parameter Sets: GetByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobID
Specifies the job id for which the details needs to be retrieved.

```yaml
Type: System.String
Parameter Sets: GetByID
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobName
Job identifier

```yaml
Type: System.String
Parameter Sets: GetByName
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

### -ProjectName
The name of the migrate project.

```yaml
Type: System.String
Parameter Sets: GetByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the recovery services vault is present.

```yaml
Type: System.String
Parameter Sets: GetByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IJob>: Specifies the job object of the replicating server.
  - `[Location <String>]`: Resource Location
  - `[ActivityId <String>]`: The activity id.
  - `[AllowedAction <String[]>]`: The Allowed action the job.
  - `[CustomDetailAffectedObjectDetail <IJobDetailsAffectedObjectDetails>]`: The affected object properties like source server, source cloud, target server, target cloud etc. based on the workflow object details.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[EndTime <DateTime?>]`: The end time.
  - `[Error <IJobErrorDetails[]>]`: The errors.
    - `[CreationTime <DateTime?>]`: The creation time of job error.
    - `[ErrorLevel <String>]`: Error level of error.
    - `[ProviderErrorDetailErrorCode <Int32?>]`: The Error code.
    - `[ProviderErrorDetailErrorId <String>]`: The Provider error Id.
    - `[ProviderErrorDetailErrorMessage <String>]`: The Error message.
    - `[ProviderErrorDetailPossibleCaus <String>]`: The possible causes for the error.
    - `[ProviderErrorDetailRecommendedAction <String>]`: The recommended action to resolve the error.
    - `[ServiceErrorDetailActivityId <String>]`: Activity Id.
    - `[ServiceErrorDetailCode <String>]`: Error code.
    - `[ServiceErrorDetailMessage <String>]`: Error message.
    - `[ServiceErrorDetailPossibleCaus <String>]`: Possible causes of error.
    - `[ServiceErrorDetailRecommendedAction <String>]`: Recommended action to resolve error.
    - `[TaskId <String>]`: The Id of the task.
  - `[FriendlyName <String>]`: The DisplayName.
  - `[ScenarioName <String>]`: The ScenarioName.
  - `[StartTime <DateTime?>]`: The start time.
  - `[State <String>]`: The status of the Job. It is one of these values - NotStarted, InProgress, Succeeded, Failed, Cancelled, Suspended or Other.
  - `[StateDescription <String>]`: The description of the state of the Job. For e.g. - For Succeeded state, description can be Completed, PartiallySucceeded, CompletedWithInformation or Skipped.
  - `[TargetInstanceType <String>]`: The type of the affected object which is of {Microsoft.Azure.SiteRecovery.V2015_11_10.AffectedObjectType} class.
  - `[TargetObjectId <String>]`: The affected Object Id.
  - `[TargetObjectName <String>]`: The name of the affected object.
  - `[Task <IAsrTask[]>]`: The tasks.
    - `[AllowedAction <String[]>]`: The state/actions applicable on this task.
    - `[CustomDetailInstanceType <String>]`: The type of task details.
    - `[EndTime <DateTime?>]`: The end time.
    - `[Error <IJobErrorDetails[]>]`: The task error details.
    - `[FriendlyName <String>]`: The name.
    - `[GroupTaskCustomDetailChildTask <IAsrTask[]>]`: The child tasks.
    - `[GroupTaskCustomDetailInstanceType <String>]`: The type of task details.
    - `[Name <String>]`: The unique Task name.
    - `[StartTime <DateTime?>]`: The start time.
    - `[State <String>]`: The State. It is one of these values - NotStarted, InProgress, Succeeded, Failed, Cancelled, Suspended or Other.
    - `[StateDescription <String>]`: The description of the task state. For example - For Succeeded state, description can be Completed, PartiallySucceeded, CompletedWithInformation or Skipped.
    - `[TaskId <String>]`: The Id.
    - `[TaskType <String>]`: The type of task. Details in CustomDetails property depend on this type.

## RELATED LINKS

