---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/new-aztask
schema: 2.0.0
---

# New-AzTask

## SYNOPSIS
The maximum lifetime of a Task from addition to completion is 180 days.
If a\nTask has not completed within 180 days of being added it will be terminated by\nthe Batch service and left in whatever state it was in at that time.

## SYNTAX

### CreateExpanded (Default)
```
New-AzTask -Endpoint <String> -JobId <String> -CommandLine <String> -Id <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-AffinityInfoAffinityId <String>]
 [-ApplicationPackageReference <IBatchApplicationPackageReference[]>]
 [-AuthenticationTokenSettingAccess <String[]>] [-AutoUserElevationLevel <String>] [-AutoUserScope <String>]
 [-ConstraintMaxTaskRetryCount <Int32>] [-ConstraintMaxWallClockTime <TimeSpan>]
 [-ConstraintRetentionTime <TimeSpan>]
 [-ContainerSettingContainerHostBatchBindMount <IContainerHostBatchBindMountEntry[]>]
 [-ContainerSettingContainerRunOption <String>] [-ContainerSettingImageName <String>]
 [-ContainerSettingWorkingDirectory <String>] [-DefaultDependencyAction <String>] [-DefaultJobAction <String>]
 [-DependOnTaskId <String[]>] [-DependOnTaskIdRange <IBatchTaskIdRange[]>] [-DisplayName <String>]
 [-EnvironmentSetting <IEnvironmentSetting[]>] [-ExitConditionExitCode <IExitCodeMapping[]>]
 [-ExitConditionExitCodeRange <IExitCodeRangeMapping[]>] [-FileUploadErrorDependencyAction <String>]
 [-FileUploadErrorJobAction <String>] [-IdentityReferenceResourceId <String>]
 [-MultiInstanceSettingCommonResourceFile <IResourceFile[]>]
 [-MultiInstanceSettingCoordinationCommandLine <String>] [-MultiInstanceSettingNumberOfInstance <Int32>]
 [-OutputFile <IOutputFile[]>] [-PreProcessingErrorDependencyAction <String>]
 [-PreProcessingErrorJobAction <String>] [-RegistryPassword <SecureString>] [-RegistryServer <String>]
 [-RegistryUsername <String>] [-RequiredSlot <Int32>] [-ResourceFile <IResourceFile[]>]
 [-UserIdentityUsername <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzTask -Endpoint <String> -JobId <String> -JsonFilePath <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzTask -Endpoint <String> -JobId <String> -JsonString <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The maximum lifetime of a Task from addition to completion is 180 days.
If a\nTask has not completed within 180 days of being added it will be terminated by\nthe Batch service and left in whatever state it was in at that time.

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

### -AffinityInfoAffinityId
An opaque string representing the location of a Compute Node or a Task that has run previously.
You can pass the affinityId of a Node to indicate that this Task needs to run on that Compute Node.
Note that this is just a soft affinity.
If the target Compute Node is busy or unavailable at the time the Task is scheduled, then the Task will be scheduled elsewhere.

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

### -ApplicationPackageReference
A list of Packages that the Batch service will deploy to the Compute Node before running the command line.
Application packages are downloaded and deployed to a shared directory, not the Task working directory.
Therefore, if a referenced package is already on the Node, and is up to date, then it is not re-downloaded; the existing copy on the Compute Node is used.
If a referenced Package cannot be installed, for example because the package has been deleted or because download failed, the Task fails.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchApplicationPackageReference[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationTokenSettingAccess
The Batch resources to which the token grants access.
The authentication token grants access to a limited set of Batch service operations.
Currently the only supported value for the access property is 'job', which grants access to all operations related to the Job which contains the Task.

```yaml
Type: System.String[]
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

### -CommandLine
The command line of the Task.
For multi-instance Tasks, the command line is executed as the primary Task, after the primary Task and all subtasks have finished executing the coordination command line.
The command line does not run under a shell, and therefore cannot take advantage of shell features such as environment variable expansion.
If you want to take advantage of such features, you should invoke the shell in the command line, for example using "cmd /c MyCommand" in Windows or "/bin/sh -c MyCommand" in Linux.
If the command line refers to file paths, it should use a relative path (relative to the Task working directory), or use the Batch provided environment variable (https://learn.microsoft.com/azure/batch/batch-compute-node-environment-variables).

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

### -ConstraintMaxTaskRetryCount
The maximum number of times the Task may be retried.
The Batch service retries a Task if its exit code is nonzero.
Note that this value specifically controls the number of retries for the Task executable due to a nonzero exit code.
The Batch service will try the Task once, and may then retry up to this limit.
For example, if the maximum retry count is 3, Batch tries the Task up to 4 times (one initial try and 3 retries).
If the maximum retry count is 0, the Batch service does not retry the Task after the first attempt.
If the maximum retry count is -1, the Batch service retries the Task without limit, however this is not recommended for a start task or any task.
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
The maximum elapsed time that the Task may run, measured from the time the Task starts.
If the Task does not complete within the time limit, the Batch service terminates it.
If this is not specified, there is no time limit on how long the Task may run.

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

### -ConstraintRetentionTime
The minimum time to retain the Task directory on the Compute Node where it ran, from the time it completes execution.
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

### -DefaultDependencyAction
An action that the Batch service performs on Tasks that depend on this Task.
Possible values are 'satisfy' (allowing dependent tasks to progress) and 'block' (dependent tasks continue to wait).
Batch does not yet support cancellation of dependent tasks.

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

### -DefaultJobAction
An action to take on the Job containing the Task, if the Task completes with the given exit condition and the Job's onTaskFailed property is 'performExitOptionsJobAction'.
The default is none for exit code 0 and terminate for all other exit conditions.
If the Job's onTaskFailed property is noaction, then specifying this property returns an error and the add Task request fails with an invalid property value error; if you are calling the REST API directly, the HTTP status code is 400 (Bad Request).

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

### -DependOnTaskId
The list of Task IDs that this Task depends on.
All Tasks in this list must complete successfully before the dependent Task can be scheduled.
The taskIds collection is limited to 64000 characters total (i.e.
the combined length of all Task IDs).
If the taskIds collection exceeds the maximum length, the Add Task request fails with error code TaskDependencyListTooLong.
In this case consider using Task ID ranges instead.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DependOnTaskIdRange
The list of Task ID ranges that this Task depends on.
All Tasks in all ranges must complete successfully before the dependent Task can be scheduled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchTaskIdRange[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
A display name for the Task.
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

### -EnvironmentSetting
A list of environment variable settings for the Task.

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

### -ExitConditionExitCode
A list of individual Task exit codes and how the Batch service should respond to them.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IExitCodeMapping[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExitConditionExitCodeRange
A list of Task exit code ranges and how the Batch service should respond to them.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IExitCodeRangeMapping[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileUploadErrorDependencyAction
An action that the Batch service performs on Tasks that depend on this Task.
Possible values are 'satisfy' (allowing dependent tasks to progress) and 'block' (dependent tasks continue to wait).
Batch does not yet support cancellation of dependent tasks.

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

### -FileUploadErrorJobAction
An action to take on the Job containing the Task, if the Task completes with the given exit condition and the Job's onTaskFailed property is 'performExitOptionsJobAction'.
The default is none for exit code 0 and terminate for all other exit conditions.
If the Job's onTaskFailed property is noaction, then specifying this property returns an error and the add Task request fails with an invalid property value error; if you are calling the REST API directly, the HTTP status code is 400 (Bad Request).

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

### -Id
A string that uniquely identifies the Task within the Job.
The ID can contain any combination of alphanumeric characters including hyphens and underscores, and cannot contain more than 64 characters.
The ID is case-preserving and case-insensitive (that is, you may not have two IDs within a Job that differ only by case).

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

### -JobId
The ID of the Job to which the Task is to be created.

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

### -MultiInstanceSettingCommonResourceFile
A list of files that the Batch service will download before running the coordination command line.
The difference between common resource files and Task resource files is that common resource files are downloaded for all subtasks including the primary, whereas Task resource files are downloaded only for the primary.
Also note that these resource files are not downloaded to the Task working directory, but instead are downloaded to the Task root directory (one directory above the working directory).
There is a maximum size for the list of resource files.
When the max size is exceeded, the request will fail and the response error code will be RequestEntityTooLarge.
If this occurs, the collection of ResourceFiles must be reduced in size.
This can be achieved using .zip files, Application Packages, or Docker Containers.

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

### -MultiInstanceSettingCoordinationCommandLine
The command line to run on all the Compute Nodes to enable them to coordinate when the primary runs the main Task command.
A typical coordination command line launches a background service and verifies that the service is ready to process inter-node messages.

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

### -MultiInstanceSettingNumberOfInstance
The number of Compute Nodes required by the Task.
If omitted, the default is 1.

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

### -OutputFile
A list of files that the Batch service will upload from the Compute Node after running the command line.
For multi-instance Tasks, the files will only be uploaded from the Compute Node on which the primary Task is executed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IOutputFile[]
Parameter Sets: CreateExpanded
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

### -PreProcessingErrorDependencyAction
An action that the Batch service performs on Tasks that depend on this Task.
Possible values are 'satisfy' (allowing dependent tasks to progress) and 'block' (dependent tasks continue to wait).
Batch does not yet support cancellation of dependent tasks.

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

### -PreProcessingErrorJobAction
An action to take on the Job containing the Task, if the Task completes with the given exit condition and the Job's onTaskFailed property is 'performExitOptionsJobAction'.
The default is none for exit code 0 and terminate for all other exit conditions.
If the Job's onTaskFailed property is noaction, then specifying this property returns an error and the add Task request fails with an invalid property value error; if you are calling the REST API directly, the HTTP status code is 400 (Bad Request).

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

### -RequiredSlot
The number of scheduling slots that the Task required to run.
The default is 1.
A Task can only be scheduled to run on a compute node if the node has enough free scheduling slots available.
For multi-instance Tasks, this must be 1.

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

### -ResourceFile
A list of files that the Batch service will download to the Compute Node before running the command line.
For multi-instance Tasks, the resource files will only be downloaded to the Compute Node on which the primary Task is executed.
There is a maximum size for the list of resource files.
When the max size is exceeded, the request will fail and the response error code will be RequestEntityTooLarge.
If this occurs, the collection of ResourceFiles must be reduced in size.
This can be achieved using .zip files, Application Packages, or Docker Containers.

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

