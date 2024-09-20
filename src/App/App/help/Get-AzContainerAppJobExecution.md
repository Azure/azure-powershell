---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/get-azcontainerappjobexecution
schema: 2.0.0
---

# Get-AzContainerAppJobExecution

## SYNOPSIS
Get details of a single job execution

## SYNTAX

### Job (Default)
```
Get-AzContainerAppJobExecution -JobName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### JobViaIdentityJob
```
Get-AzContainerAppJobExecution -Name <String> -JobInputObject <IAppIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### JobViaIdentity
```
Get-AzContainerAppJobExecution -InputObject <IAppIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get details of a single job execution

## EXAMPLES

### Example 1: Get details of a single job execution.
```powershell
Get-AzContainerAppJobExecution -JobName azps-app-job -ResourceGroupName azps_test_group_app -Name "azps-app-job-vvhlnul"
```

```output
EndTime Name                 ResourceGroupName   StartTime Status
------- ----                 -----------------   --------- ------
        azps-app-job-vvhlnul azps_test_group_app
```

Get details of a single job execution.

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: JobViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: JobViaIdentityJob
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobName
Job Name

```yaml
Type: System.String
Parameter Sets: Job
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Job execution name.

```yaml
Type: System.String
Parameter Sets: Job, JobViaIdentityJob
Aliases: JobExecutionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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
Parameter Sets: Job
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Job
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IJobExecution

## NOTES

## RELATED LINKS
