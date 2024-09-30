---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/start-azcontainerappjob
schema: 2.0.0
---

# Start-AzContainerAppJob

## SYNOPSIS
Start a Container Apps Job

## SYNTAX

### StartExpanded (Default)
```
Start-AzContainerAppJob -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Container <IJobExecutionContainer[]>] [-InitContainer <IJobExecutionContainer[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Start
```
Start-AzContainerAppJob -Name <String> -ResourceGroupName <String> -Template <IJobExecutionTemplate>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### StartViaIdentity
```
Start-AzContainerAppJob -InputObject <IAppIdentity> -Template <IJobExecutionTemplate>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StartViaIdentityExpanded
```
Start-AzContainerAppJob -InputObject <IAppIdentity> [-Container <IJobExecutionContainer[]>]
 [-InitContainer <IJobExecutionContainer[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### StartViaJsonFilePath
```
Start-AzContainerAppJob -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### StartViaJsonString
```
Start-AzContainerAppJob -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Start a Container Apps Job

## EXAMPLES

### Example 1: Start a Container Apps Job.
```powershell
$initContainer = New-AzContainerAppJobExecutionContainerObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:lates" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","echo hello; sleep 10;"
Start-AzContainerAppJob -Name azps-app-job -ResourceGroupName azps_test_group_app -InitContainer $initContainer
```

```output
Name                 ResourceGroupName
----                 -----------------
azps-app-job-vvhlnul azps_test_group_app
```

Start a Container Apps Job.

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

### -Container
List of container definitions for the Container Apps Job.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IJobExecutionContainer[]
Parameter Sets: StartExpanded, StartViaIdentityExpanded
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

### -InitContainer
List of specialized containers that run before job containers.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IJobExecutionContainer[]
Parameter Sets: StartExpanded, StartViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: StartViaIdentity, StartViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Start operation

```yaml
Type: System.String
Parameter Sets: StartViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Start operation

```yaml
Type: System.String
Parameter Sets: StartViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Job Name

```yaml
Type: System.String
Parameter Sets: Start, StartExpanded, StartViaJsonFilePath, StartViaJsonString
Aliases: JobName

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Start, StartExpanded, StartViaJsonFilePath, StartViaJsonString
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
Type: System.String
Parameter Sets: Start, StartExpanded, StartViaJsonFilePath, StartViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Template
Job's execution template, containing container configuration for a job's execution

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IJobExecutionTemplate
Parameter Sets: Start, StartViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IJobExecutionTemplate

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IJobExecutionBase

## NOTES

## RELATED LINKS

