---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/new-azjob
schema: 2.0.0
---

# New-AzJob

## SYNOPSIS
The Batch service supports two ways to control the work done as part of a Job.\nIn the first approach, the user specifies a Job Manager Task.
The Batch service\nlaunches this Task when it is ready to start the Job.
The Job Manager Task\ncontrols all other Tasks that run under this Job, by using the Task APIs.
In\nthe second approach, the user directly controls the execution of Tasks under an\nactive Job, by using the Task APIs.
Also note: when naming Jobs, avoid\nincluding sensitive information such as user names or secret project names.\nThis information may appear in telemetry logs accessible to Microsoft Support\nengineers.

## SYNTAX

### CreateExpanded (Default)
```
New-AzJob -Endpoint <String> -Id <String> [-TimeOut <Int32>] [-ClientRequestId <String>] [-Ocpdate <String>]
 [-ReturnClientRequestId] [-AllowTaskPreemption] [-AllTasksCompleteMode <String>]
 [-AutoPoolSpecificationAutoPoolIdPrefix <String>] [-AutoPoolSpecificationKeepAlive]
 [-AutoPoolSpecificationPool <IBatchPoolSpecification>] [-AutoPoolSpecificationPoolLifetimeOption <String>]
 [-AutoUserElevationLevel <String>] [-AutoUserScope <String>]
 [-CommonEnvironmentSetting <IEnvironmentSetting[]>] [-ConstraintMaxTaskRetryCount <Int32>]
 [-ConstraintMaxWallClockTime <TimeSpan>]
 [-ContainerSettingContainerHostBatchBindMount <IContainerHostBatchBindMountEntry[]>]
 [-ContainerSettingContainerRunOption <String>] [-ContainerSettingImageName <String>]
 [-ContainerSettingWorkingDirectory <String>] [-DisplayName <String>] [-IdentityReferenceResourceId <String>]
 [-JobManagerTask <IBatchJobManagerTask>] [-JobPreparationTask <IBatchJobPreparationTask>]
 [-JobReleaseTaskCommandLine <String>] [-JobReleaseTaskEnvironmentSetting <IEnvironmentSetting[]>]
 [-JobReleaseTaskId <String>] [-JobReleaseTaskMaxWallClockTime <TimeSpan>]
 [-JobReleaseTaskResourceFile <IResourceFile[]>] [-JobReleaseTaskRetentionTime <TimeSpan>]
 [-MaxParallelTask <Int32>] [-Metadata <IBatchMetadataItem[]>] [-NetworkConfigurationSkipWithdrawFromVnet]
 [-NetworkConfigurationSubnetId <String>] [-PoolInfoPoolId <String>] [-Priority <Int32>]
 [-RegistryPassword <SecureString>] [-RegistryServer <String>] [-RegistryUsername <String>]
 [-TaskFailureMode <String>] [-UserIdentityUsername <String>] [-UsesTaskDependency]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzJob -Endpoint <String> -JsonFilePath <String> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzJob -Endpoint <String> -JsonString <String> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The Batch service supports two ways to control the work done as part of a Job.\nIn the first approach, the user specifies a Job Manager Task.
The Batch service\nlaunches this Task when it is ready to start the Job.
The Job Manager Task\ncontrols all other Tasks that run under this Job, by using the Task APIs.
In\nthe second approach, the user directly controls the execution of Tasks under an\nactive Job, by using the Task APIs.
Also note: when naming Jobs, avoid\nincluding sensitive information such as user names or secret project names.\nThis information may appear in telemetry logs accessible to Microsoft Support\nengineers.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AllowTaskPreemption
Whether Tasks in this job can be preempted by other high priority jobs.
If the value is set to True, other high priority jobs submitted to the system will take precedence and will be able requeue tasks from this job.
You can update a job's allowTaskPreemption after it has been created using the update job API.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllTasksCompleteMode
The action the Batch service should take when all Tasks in the Job are in the completed state.
Note that if a Job contains no Tasks, then all Tasks are considered complete.
This option is therefore most commonly used with a Job Manager task; if you want to use automatic Job termination without a Job Manager, you should initially set onAllTasksComplete to noaction and update the Job properties to set onAllTasksComplete to terminatejob once you have finished adding Tasks.
The default is noaction.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoPoolSpecificationAutoPoolIdPrefix
A prefix to be added to the unique identifier when a Pool is automatically created.
The Batch service assigns each auto Pool a unique identifier on creation.
To distinguish between Pools created for different purposes, you can specify this element to add a prefix to the ID that is assigned.
The prefix can be up to 20 characters long.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoPoolSpecificationKeepAlive
Whether to keep an auto Pool alive after its lifetime expires.
If false, the Batch service deletes the Pool once its lifetime (as determined by the poolLifetimeOption setting) expires; that is, when the Job or Job Schedule completes.
If true, the Batch service does not delete the Pool automatically.
It is up to the user to delete auto Pools created with this option.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoPoolSpecificationPool
The Pool specification for the auto Pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchPoolSpecification
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoPoolSpecificationPoolLifetimeOption
The minimum lifetime of created auto Pools, and how multiple Jobs on a schedule are assigned to Pools.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoUserElevationLevel
The elevation level of the auto user.
The default value is nonAdmin.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoUserScope
The scope for the auto user.
The default value is pool.
If the pool is running Windows a value of Task should be specified if stricter isolation between tasks is required.
For example, if the task mutates the registry in a way which could impact other tasks, or if certificates have been specified on the pool which should not be accessible by normal tasks but should be accessible by StartTasks.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientRequestId
The caller-generated request identity, in the form of a GUID with no decoration
such as curly braces, e.g.
9C4D50EE-2D56-4CD3-8152-34347DC9F2B0.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonEnvironmentSetting
The list of common environment variable settings.
These environment variables are set for all Tasks in the Job (including the Job Manager, Job Preparation and Job Release Tasks).
Individual Tasks can override an environment setting specified here by specifying the same setting name with a different value.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IEnvironmentSetting[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConstraintMaxTaskRetryCount
The maximum number of times each Task may be retried.
The Batch service retries a Task if its exit code is nonzero.
Note that this value specifically controls the number of retries.
The Batch service will try each Task once, and may then retry up to this limit.
For example, if the maximum retry count is 3, Batch tries a Task up to 4 times (one initial try and 3 retries).
If the maximum retry count is 0, the Batch service does not retry Tasks.
If the maximum retry count is -1, the Batch service retries Tasks without limit.
The default value is 0 (no retries).

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConstraintMaxWallClockTime
The maximum elapsed time that the Job may run, measured from the time the Job is created.
If the Job does not complete within the time limit, the Batch service terminates it and any Tasks that are still running.
In this case, the termination reason will be MaxWallClockTimeExpiry.
If this property is not specified, there is no time limit on how long the Job may run.

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSettingContainerHostBatchBindMount
The paths you want to mounted to container task.
If this array is null or be not present, container task will mount entire temporary disk drive in windows (or AZ_BATCH_NODE_ROOT_DIR in Linux).
It won't' mount any data paths into container if this array is set as empty.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IContainerHostBatchBindMountEntry[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSettingContainerRunOption
Additional options to the container create command.
These additional options are supplied as arguments to the "docker create" command, in addition to those controlled by the Batch Service.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSettingImageName
The Image to use to create the container in which the Task will run.
This is the full Image reference, as would be specified to "docker pull".
If no tag is provided as part of the Image name, the tag ":latest" is used as a default.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSettingWorkingDirectory
The location of the container Task working directory.
The default is 'taskWorkingDirectory'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -DisplayName
The display name for the Job.
The display name need not be unique and can contain any Unicode characters up to a maximum length of 1024.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
Batch account endpoint (for example: https://batchaccount.eastus2.batch.azure.com).

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

### -Id
A string that uniquely identifies the Job within the Account.
The ID can contain any combination of alphanumeric characters including hyphens and underscores, and cannot contain more than 64 characters.
The ID is case-preserving and case-insensitive (that is, you may not have two IDs within an Account that differ only by case).

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityReferenceResourceId
The ARM resource id of the user assigned identity.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobManagerTask
Details of a Job Manager Task to be launched when the Job is started.
If the Job does not specify a Job Manager Task, the user must explicitly add Tasks to the Job.
If the Job does specify a Job Manager Task, the Batch service creates the Job Manager Task when the Job is created, and will try to schedule the Job Manager Task before scheduling other Tasks in the Job.
The Job Manager Task's typical purpose is to control and/or monitor Job execution, for example by deciding what additional Tasks to run, determining when the work is complete, etc.
(However, a Job Manager Task is not restricted to these activities - it is a fully-fledged Task in the system and perform whatever actions are required for the Job.) For example, a Job Manager Task might download a file specified as a parameter, analyze the contents of that file and submit additional Tasks based on those contents.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchJobManagerTask
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobPreparationTask
The Job Preparation Task.
If a Job has a Job Preparation Task, the Batch service will run the Job Preparation Task on a Node before starting any Tasks of that Job on that Compute Node.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchJobPreparationTask
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobReleaseTaskCommandLine
The command line of the Job Release Task.
The command line does not run under a shell, and therefore cannot take advantage of shell features such as environment variable expansion.
If you want to take advantage of such features, you should invoke the shell in the command line, for example using "cmd /c MyCommand" in Windows or "/bin/sh -c MyCommand" in Linux.
If the command line refers to file paths, it should use a relative path (relative to the Task working directory), or use the Batch provided environment variable (https://learn.microsoft.com/azure/batch/batch-compute-node-environment-variables).

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobReleaseTaskEnvironmentSetting
A list of environment variable settings for the Job Release Task.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IEnvironmentSetting[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobReleaseTaskId
A string that uniquely identifies the Job Release Task within the Job.
The ID can contain any combination of alphanumeric characters including hyphens and underscores and cannot contain more than 64 characters.
If you do not specify this property, the Batch service assigns a default value of 'jobrelease'.
No other Task in the Job can have the same ID as the Job Release Task.
If you try to submit a Task with the same id, the Batch service rejects the request with error code TaskIdSameAsJobReleaseTask; if you are calling the REST API directly, the HTTP status code is 409 (Conflict).

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobReleaseTaskMaxWallClockTime
The maximum elapsed time that the Job Release Task may run on a given Compute Node, measured from the time the Task starts.
If the Task does not complete within the time limit, the Batch service terminates it.
The default value is 15 minutes.
You may not specify a timeout longer than 15 minutes.
If you do, the Batch service rejects it with an error; if you are calling the REST API directly, the HTTP status code is 400 (Bad Request).

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobReleaseTaskResourceFile
A list of files that the Batch service will download to the Compute Node before running the command line.
There is a maximum size for the list of resource files.
When the max size is exceeded, the request will fail and the response error code will be RequestEntityTooLarge.
If this occurs, the collection of ResourceFiles must be reduced in size.
This can be achieved using .zip files, Application Packages, or Docker Containers.
Files listed under this element are located in the Task's working directory.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IResourceFile[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobReleaseTaskRetentionTime
The minimum time to retain the Task directory for the Job Release Task on the Compute Node.
After this time, the Batch service may delete the Task directory and all its contents.
The default is 7 days, i.e.
the Task directory will be retained for 7 days unless the Compute Node is removed or the Job is deleted.

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded
Aliases:

Required: False
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

### -MaxParallelTask
The maximum number of tasks that can be executed in parallel for the job.
The value of maxParallelTasks must be -1 or greater than 0 if specified.
If not specified, the default value is -1, which means there's no limit to the number of tasks that can be run at once.
You can update a job's maxParallelTasks after it has been created using the update job API.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
A list of name-value pairs associated with the Job as metadata.
The Batch service does not assign any meaning to metadata; it is solely for the use of user code.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchMetadataItem[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkConfigurationSkipWithdrawFromVnet
Whether to withdraw Compute Nodes from the virtual network to DNC when the job is terminated or deleted.
If true, nodes will remain joined to the virtual network to DNC.
If false, nodes will automatically withdraw when the job ends.
Defaults to false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkConfigurationSubnetId
The ARM resource identifier of the virtual network subnet which Compute Nodes running Tasks from the Job will join for the duration of the Task.
The virtual network must be in the same region and subscription as the Azure Batch Account.
The specified subnet should have enough free IP addresses to accommodate the number of Compute Nodes which will run Tasks from the Job.
This can be up to the number of Compute Nodes in the Pool.
The 'MicrosoftAzureBatch' service principal must have the 'Classic Virtual Machine Contributor' Role-Based Access Control (RBAC) role for the specified VNet so that Azure Batch service can schedule Tasks on the Nodes.
This can be verified by checking if the specified VNet has any associated Network Security Groups (NSG).
If communication to the Nodes in the specified subnet is denied by an NSG, then the Batch service will set the state of the Compute Nodes to unusable.
This is of the form /subscriptions/{subscription}/resourceGroups/{group}/providers/{provider}/virtualNetworks/{network}/subnets/{subnet}.
If the specified VNet has any associated Network Security Groups (NSG), then a few reserved system ports must be enabled for inbound communication from the Azure Batch service.
For Pools created with a Virtual Machine configuration, enable ports 29876 and 29877, as well as port 22 for Linux and port 3389 for Windows.
Port 443 is also required to be open for outbound connections for communications to Azure Storage.
For more details see: https://learn.microsoft.com/azure/batch/batch-api-basics#virtual-network-vnet-and-firewall-configuration.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ocpdate
The time the request was issued.
Client libraries typically set this to the
current system clock time; set it explicitly if you are calling the REST API
directly.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -PoolInfoPoolId
The ID of an existing Pool.
All the Tasks of the Job will run on the specified Pool.
You must ensure that the Pool referenced by this property exists.
If the Pool does not exist at the time the Batch service tries to schedule a Job, no Tasks for the Job will run until you create a Pool with that id.
Note that the Batch service will not reject the Job request; it will simply not run Tasks until the Pool exists.
You must specify either the Pool ID or the auto Pool specification, but not both.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Priority
The priority of the Job.
Priority values can range from -1000 to 1000, with -1000 being the lowest priority and 1000 being the highest priority.
The default value is 0.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryPassword
The password to log into the registry server.

```yaml
Type: System.Security.SecureString
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryServer
The registry URL.
If omitted, the default is "docker.io".

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryUsername
The user name to log into the registry server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReturnClientRequestId
Whether the server should return the client-request-id in the response.

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

### -TaskFailureMode
The action the Batch service should take when any Task in the Job fails.
A Task is considered to have failed if has a failureInfo.
A failureInfo is set if the Task completes with a non-zero exit code after exhausting its retry count, or if there was an error starting the Task, for example due to a resource file download error.
The default is noaction.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeOut
The maximum time that the server can spend processing the request, in seconds.
The default is 30 seconds.
If the value is larger than 30, the default will be used instead.".

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserIdentityUsername
The name of the user identity under which the Task is run.
The userName and autoUser properties are mutually exclusive; you must specify one but not both.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsesTaskDependency
Whether Tasks in the Job can define dependencies on each other.
The default is false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

