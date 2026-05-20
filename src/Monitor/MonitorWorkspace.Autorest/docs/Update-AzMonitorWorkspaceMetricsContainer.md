---
external help file:
<<<<<<<< HEAD:src/MachineLearningServices/MachineLearningServices.Autorest/docs/Update-AzMLWorkspaceJob.md
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/update-azmlworkspacejob
schema: 2.0.0
---

# Update-AzMLWorkspaceJob

## SYNOPSIS
Update and execute a Job.\r\nFor update case, the Tags in the definition passed in will replace Tags in the existing job.
========
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/update-azmonitorworkspacemetricscontainer
schema: 2.0.0
---

# Update-AzMonitorWorkspaceMetricsContainer

## SYNOPSIS
Update metrics container settings for a monitoring account.
>>>>>>>> upstream/main:src/Monitor/MonitorWorkspace.Autorest/docs/Update-AzMonitorWorkspaceMetricsContainer.md

## SYNTAX

### UpdateExpanded (Default)
```
<<<<<<<< HEAD:src/MachineLearningServices/MachineLearningServices.Autorest/docs/Update-AzMLWorkspaceJob.md
Update-AzMLWorkspaceJob -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-Job <IJobBaseProperties>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
========
Update-AzMonitorWorkspaceMetricsContainer -AzureMonitorWorkspaceName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Version <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
>>>>>>>> upstream/main:src/Monitor/MonitorWorkspace.Autorest/docs/Update-AzMonitorWorkspaceMetricsContainer.md
```

### UpdateViaIdentityAccountExpanded
```
Update-AzMonitorWorkspaceMetricsContainer -AccountInputObject <IMonitorWorkspaceIdentity> -Name <String>
 [-Version <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
<<<<<<<< HEAD:src/MachineLearningServices/MachineLearningServices.Autorest/docs/Update-AzMLWorkspaceJob.md
Update-AzMLWorkspaceJob -InputObject <IMachineLearningServicesIdentity> [-Job <IJobBaseProperties>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityWorkspaceExpanded
```
Update-AzMLWorkspaceJob -Name <String> -WorkspaceInputObject <IMachineLearningServicesIdentity>
 [-Job <IJobBaseProperties>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update and execute a Job.\r\nFor update case, the Tags in the definition passed in will replace Tags in the existing job.

## EXAMPLES

### Example 1: Update and execute a Job
```powershell
# The job type includes CommandJob, SweepJob, PipelineJob.
# You can use following command to create it then pass it as value to Job parameter of the New-AzMLWorkspaceJob cmdlet.
# New-AzMLWorkspaceCommandJobObject
# New-AzMLWorkspaceSweepJobObject
# New-AzMLWorkspacePipelineJobObject

$commandJob = New-AzMLWorkspaceCommandJobObject -Command "echo `"hello world`"" -EnvironmentId '/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/environments/commandjobenv/versions/1'
Update-AzMLWorkspaceJob -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name commandJob01 -Job $commandJob
```

These commands update a Job.

## PARAMETERS

========
Update-AzMonitorWorkspaceMetricsContainer -InputObject <IMonitorWorkspaceIdentity> [-Version <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update metrics container settings for a monitoring account.

## EXAMPLES

### Example 1: Update a metrics container
```powershell
Update-AzMonitorWorkspaceMetricsContainer -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -Name metrics-container-001 -Version "v3"
```

```output
Name                  ProvisioningState Version
----                  ----------------- -------
metrics-container-001 Succeeded         v3
```

Updates metrics-container-001 in the workspace.

## PARAMETERS

### -AccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity
Parameter Sets: UpdateViaIdentityAccountExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AzureMonitorWorkspaceName
The name of the Azure Monitor Workspace.
The name is case insensitive

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

>>>>>>>> upstream/main:src/Monitor/MonitorWorkspace.Autorest/docs/Update-AzMonitorWorkspaceMetricsContainer.md
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
<<<<<<<< HEAD:src/MachineLearningServices/MachineLearningServices.Autorest/docs/Update-AzMLWorkspaceJob.md
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
========
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity
>>>>>>>> upstream/main:src/Monitor/MonitorWorkspace.Autorest/docs/Update-AzMonitorWorkspaceMetricsContainer.md
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

<<<<<<<< HEAD:src/MachineLearningServices/MachineLearningServices.Autorest/docs/Update-AzMLWorkspaceJob.md
### -Job
[Required] Additional attributes of the entity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IJobBaseProperties
Parameter Sets: (All)
Aliases:
========
### -Name
The name of the MetricsContainer

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityAccountExpanded
Aliases: MetricsContainerName
>>>>>>>> upstream/main:src/Monitor/MonitorWorkspace.Autorest/docs/Update-AzMonitorWorkspaceMetricsContainer.md

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
Parameter Sets: UpdateExpanded, UpdateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<<< HEAD:src/MachineLearningServices/MachineLearningServices.Autorest/docs/Update-AzMLWorkspaceJob.md
### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

========
>>>>>>>> upstream/main:src/Monitor/MonitorWorkspace.Autorest/docs/Update-AzMonitorWorkspaceMetricsContainer.md
### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<<< HEAD:src/MachineLearningServices/MachineLearningServices.Autorest/docs/Update-AzMLWorkspaceJob.md
### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: UpdateViaIdentityWorkspaceExpanded
========
### -Version
The version of Metrics Query Service that this AMW will use for all metric queries.

```yaml
Type: System.String
Parameter Sets: (All)
>>>>>>>> upstream/main:src/Monitor/MonitorWorkspace.Autorest/docs/Update-AzMonitorWorkspaceMetricsContainer.md
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
Parameter Sets: UpdateExpanded
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

<<<<<<<< HEAD:src/MachineLearningServices/MachineLearningServices.Autorest/docs/Update-AzMLWorkspaceJob.md
### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IJobBase
========
### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMonitorWorkspaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.IMetricsContainerResource
>>>>>>>> upstream/main:src/Monitor/MonitorWorkspace.Autorest/docs/Update-AzMonitorWorkspaceMetricsContainer.md

## NOTES

## RELATED LINKS

