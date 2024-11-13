---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/update-azcontainerappjob
schema: 2.0.0
---

# Update-AzContainerAppJob

## SYNOPSIS
Patches a Container Apps Job using JSON Merge Patch

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzContainerAppJob -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ConfigurationRegistry <IRegistryCredentials[]>] [-ConfigurationReplicaRetryLimit <Int32>]
 [-ConfigurationReplicaTimeout <Int32>] [-ConfigurationSecret <ISecret[]>] [-ConfigurationTriggerType <String>]
 [-EnvironmentId <String>] [-EventStreamEndpoint <String>] [-EventTriggerConfigParallelism <Int32>]
 [-EventTriggerConfigReplicaCompletionCount <Int32>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-ManualTriggerConfigParallelism <Int32>]
 [-ManualTriggerConfigReplicaCompletionCount <Int32>] [-OutboundIPAddress <String[]>]
 [-ScaleMaxExecution <Int32>] [-ScaleMinExecution <Int32>] [-ScalePollingInterval <Int32>]
 [-ScaleRule <IJobScaleRule[]>] [-ScheduleTriggerConfigCronExpression <String>]
 [-ScheduleTriggerConfigParallelism <Int32>] [-ScheduleTriggerConfigReplicaCompletionCount <Int32>]
 [-Tag <Hashtable>] [-TemplateContainer <IContainer[]>] [-TemplateInitContainer <IInitContainer[]>]
 [-TemplateVolume <IVolume[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzContainerAppJob -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzContainerAppJob -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzContainerAppJob -InputObject <IAppIdentity> [-ConfigurationRegistry <IRegistryCredentials[]>]
 [-ConfigurationReplicaRetryLimit <Int32>] [-ConfigurationReplicaTimeout <Int32>]
 [-ConfigurationSecret <ISecret[]>] [-ConfigurationTriggerType <String>] [-EnvironmentId <String>]
 [-EventStreamEndpoint <String>] [-EventTriggerConfigParallelism <Int32>]
 [-EventTriggerConfigReplicaCompletionCount <Int32>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-ManualTriggerConfigParallelism <Int32>]
 [-ManualTriggerConfigReplicaCompletionCount <Int32>] [-OutboundIPAddress <String[]>]
 [-ScaleMaxExecution <Int32>] [-ScaleMinExecution <Int32>] [-ScalePollingInterval <Int32>]
 [-ScaleRule <IJobScaleRule[]>] [-ScheduleTriggerConfigCronExpression <String>]
 [-ScheduleTriggerConfigParallelism <Int32>] [-ScheduleTriggerConfigReplicaCompletionCount <Int32>]
 [-Tag <Hashtable>] [-TemplateContainer <IContainer[]>] [-TemplateInitContainer <IInitContainer[]>]
 [-TemplateVolume <IVolume[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Patches a Container Apps Job using JSON Merge Patch

## EXAMPLES

### Example 1: Update container app job.
```powershell
$EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName azps_test_group_app -Name azps-env).Id
$probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
$probe = New-AzContainerAppProbeObject -Type "Liveness" -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -HttpGetHttpHeader $probeHttpGetHttpHeader
$temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart:latest" -Name "simple-hello-world-container" -Probe $probe -ResourceCpu 0.25 -ResourceMemory "0.5Gi"

Update-AzContainerAppJob -Name azps-app-job -ResourceGroupName azps_test_group_app -ConfigurationReplicaRetryLimit 10 -ConfigurationReplicaTimeout 10 -ConfigurationTriggerType Manual -EnvironmentId $EnvId -ManualTriggerConfigParallelism 4 -ManualTriggerConfigReplicaCompletionCount 1 -TemplateContainer $temp
```

```output
Location Name         ProvisioningState ResourceGroupName
-------- ----         ----------------- -----------------
East US  azps-app-job Succeeded         azps_test_group_app
```

Update container app job.

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

### -ConfigurationRegistry
Collection of private container registry credentials used by a Container apps job

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRegistryCredentials[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationReplicaRetryLimit
Maximum number of retries before failing the job.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationReplicaTimeout
Maximum number of seconds a replica is allowed to run.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationSecret
Collection of secrets used by a Container Apps Job

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.ISecret[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationTriggerType
Trigger type of the job

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -EnvironmentId
Resource ID of environment.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventStreamEndpoint
The endpoint of the eventstream of the container apps job.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventTriggerConfigParallelism
Number of parallel replicas of a job that can run at a given time.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventTriggerConfigReplicaCompletionCount
Minimum number of successful replica completions before overall job completion.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManualTriggerConfigParallelism
Number of parallel replicas of a job that can run at a given time.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManualTriggerConfigReplicaCompletionCount
Minimum number of successful replica completions before overall job completion.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Job Name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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

### -OutboundIPAddress
Outbound IP Addresses of a container apps job.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleMaxExecution
Maximum number of job executions that are created for a trigger, default 100.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleMinExecution
Minimum number of job executions that are created for a trigger, default 0

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScalePollingInterval
Interval to check each event source in seconds.
Defaults to 30s

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleRule
Scaling rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IJobScaleRule[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleTriggerConfigCronExpression
Cron formatted repeating schedule ("* * * * *") of a Cron Job.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleTriggerConfigParallelism
Number of parallel replicas of a job that can run at a given time.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleTriggerConfigReplicaCompletionCount
Minimum number of successful replica completions before overall job completion.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateContainer
List of container definitions for the Container App.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IContainer[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateInitContainer
List of specialized containers that run before app containers.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IInitContainer[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateVolume
List of volume definitions for the Container App.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IVolume[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IJob

## NOTES

## RELATED LINKS
