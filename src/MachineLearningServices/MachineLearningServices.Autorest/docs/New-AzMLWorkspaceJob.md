---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/new-azmlworkspacejob
schema: 2.0.0
---

# New-AzMLWorkspaceJob

## SYNOPSIS
Creates and executes a Job.\r\nFor update case, the Tags in the definition passed in will replace Tags in the existing job.

## SYNTAX

```
New-AzMLWorkspaceJob -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -Job <IJobBaseProperties> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates and executes a Job.\r\nFor update case, the Tags in the definition passed in will replace Tags in the existing job.

## EXAMPLES

### Example 1: Creates and executes a Job
```powershell
# The job type includes CommandJob, SweepJob, PipelineJob.
# You can use following command to create it then pass it as value to Job parameter of the New-AzMLWorkspaceJob cmdlet.
# New-AzMLWorkspaceCommandJobObject
# New-AzMLWorkspaceSweepJobObject
# New-AzMLWorkspacePipelineJobObject

New-AzMLWorkspaceEnvironmentVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandjobenv -Version 1 -Image "library/python:latest"
$commandJob = New-AzMLWorkspaceCommandJobObject -Command "echo `"hello world`"" `
-ComputeId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test01/computes/aml02' `
-EnvironmentId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test01/environments/commandjobenv/versions/1'`
-DisplayName 'commandjob01' -ExperimentName 'commandjobexperiment'
New-AzMLWorkspaceJob -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandJob01 -Job $commandJob
```

```output
Name                       SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                       -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
commandJob01               5/31/2022 7:58:38 AM UserName (Example)         User                                                                                                   ml-rg-test
```

Creates and executes a Job

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

### -Job
[Required] Additional attributes of the entity.
To construct, see NOTES section for JOB properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBaseProperties
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name and identifier for the Job.
This is case-sensitive.

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

### -SubscriptionId
The ID of the target subscription.

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

### -WorkspaceName
Name of Azure Machine Learning workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBase

## NOTES

## RELATED LINKS

