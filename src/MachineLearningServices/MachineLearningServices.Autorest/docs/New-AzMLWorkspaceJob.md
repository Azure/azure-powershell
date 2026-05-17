---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/new-azmlworkspacejob
schema: 2.0.0
---

# New-AzMLWorkspaceJob

## SYNOPSIS
Create and execute a Job.For update case, the Tags in the definition passed in will replace Tags in the existing job.

## SYNTAX

### CreateViaIdentityWorkspaceExpanded (Default)
```
New-AzMLWorkspaceJob -Name <String> -WorkspaceInputObject <IMachineLearningServicesIdentity>
 -Job <IJobBaseProperties> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzMLWorkspaceJob -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -Job <IJobBaseProperties> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzMLWorkspaceJob -Name <String> -ResourceGroupName <String> -WorkspaceName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzMLWorkspaceJob -Name <String> -ResourceGroupName <String> -WorkspaceName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create and execute a Job.For update case, the Tags in the definition passed in will replace Tags in the existing job.

## EXAMPLES

### Example 1: Create and execute a Job
```powershell
# The job type includes CommandJob, SweepJob, PipelineJob.
# You can use following command to create it then pass it as value to Job parameter of the New-AzMLWorkspaceJob cmdlet.
# New-AzMLWorkspaceCommandJobObject
# New-AzMLWorkspaceSweepJobObject
# New-AzMLWorkspacePipelineJobObject

New-AzMLWorkspaceEnvironmentVersion -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name commandjobenv -Version 1 -Image "library/python:latest"
$commandJob = New-AzMLWorkspaceCommandJobObject -Command "echo `"hello world`"" `
-ComputeId '/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/computes/aml02' `
-EnvironmentId '/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/environments/commandjobenv/versions/1'`
-DisplayName 'commandjob01' -ExperimentName 'commandjobexperiment'
New-AzMLWorkspaceJob -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name commandJob01 -Job $commandJob
```

```output
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/jobs/commandJob01
Name                         : commandJob01
Property                     : {
                                 "properties": {
                                   "_azureml.ComputeTargetType": "amlctrain",
                                   "_azureml.ClusterName": "aml02"
                                 },
                                 "computeId":
                               "/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/computes/aml02", 
                                 "displayName": "commandjob01",
                                 "experimentName": "commandjobexperiment",
                                 "isArchived": false,
                                 "jobType": "Command",
                                 "services": {
                                   "Tracking": {
                                   },
                                   "Studio": {
                                   }
                                 },
                                 "status": "Starting",
                                 "limits": {
                                   "jobLimitsType": "Command"
                                 },
                                 "queueSettings": {
                                   "jobTier": "Null"
                                 },
                                 "resources": {
                                   "instanceCount": 1,
                                   "shmSize": "2g"
                                 },
                                 "command": "echo \"hello world\"",
                                 "environmentId": "/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-tes 
                               t2/environments/commandjobenv/versions/1",
                                 "outputs": {
                                   "default": {
                                     "uri": "azureml://datastores/workspaceartifactstore/ExperimentRun/dcid.commandJob01"
                                   }
                                 }
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/5/2025 9:51:47 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.MachineLearningServices/workspaces/jobs
```

These commands create and execute a Job.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IJobBaseProperties
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: CreateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
Name of Azure Machine Learning workspace.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IJobBase

## NOTES

## RELATED LINKS

