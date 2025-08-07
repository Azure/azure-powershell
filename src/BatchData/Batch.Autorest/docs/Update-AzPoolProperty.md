---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/update-azpoolproperty
schema: 2.0.0
---

# Update-AzPoolProperty

## SYNOPSIS
This fully replaces all the updatable properties of the Pool.
For example, if\nthe Pool has a StartTask associated with it and if StartTask is not specified\nwith this request, then the Batch service will remove the existing StartTask.

## SYNTAX

### Replace (Default)
```
Update-AzPoolProperty -Endpoint <String> -PoolId <String> -Pool <IBatchPoolReplaceOptions> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceExpanded
```
Update-AzPoolProperty -Endpoint <String> -PoolId <String>
 -ApplicationPackageReference <IBatchApplicationPackageReference[]>
 -CertificateReference <IBatchCertificateReference[]> -Metadata <IBatchMetadataItem[]> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-AutoUserElevationLevel <String>]
 [-AutoUserScope <String>]
 [-ContainerSettingContainerHostBatchBindMount <IContainerHostBatchBindMountEntry[]>]
 [-ContainerSettingContainerRunOption <String>] [-ContainerSettingImageName <String>]
 [-ContainerSettingWorkingDirectory <String>] [-IdentityReferenceResourceId <String>]
 [-RegistryPassword <SecureString>] [-RegistryServer <String>] [-RegistryUsername <String>]
 [-StartTaskCommandLine <String>] [-StartTaskEnvironmentSetting <IEnvironmentSetting[]>]
 [-StartTaskMaxTaskRetryCount <Int32>] [-StartTaskResourceFile <IResourceFile[]>] [-StartTaskWaitForSuccess]
 [-TargetNodeCommunicationMode <String>] [-UserIdentityUsername <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceViaIdentity
```
Update-AzPoolProperty -Endpoint <String> -InputObject <IBatchIdentity> -Pool <IBatchPoolReplaceOptions>
 [-TimeOut <Int32>] [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceViaIdentityExpanded
```
Update-AzPoolProperty -Endpoint <String> -InputObject <IBatchIdentity>
 -ApplicationPackageReference <IBatchApplicationPackageReference[]>
 -CertificateReference <IBatchCertificateReference[]> -Metadata <IBatchMetadataItem[]> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-AutoUserElevationLevel <String>]
 [-AutoUserScope <String>]
 [-ContainerSettingContainerHostBatchBindMount <IContainerHostBatchBindMountEntry[]>]
 [-ContainerSettingContainerRunOption <String>] [-ContainerSettingImageName <String>]
 [-ContainerSettingWorkingDirectory <String>] [-IdentityReferenceResourceId <String>]
 [-RegistryPassword <SecureString>] [-RegistryServer <String>] [-RegistryUsername <String>]
 [-StartTaskCommandLine <String>] [-StartTaskEnvironmentSetting <IEnvironmentSetting[]>]
 [-StartTaskMaxTaskRetryCount <Int32>] [-StartTaskResourceFile <IResourceFile[]>] [-StartTaskWaitForSuccess]
 [-TargetNodeCommunicationMode <String>] [-UserIdentityUsername <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceViaJsonFilePath
```
Update-AzPoolProperty -Endpoint <String> -PoolId <String> -JsonFilePath <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceViaJsonString
```
Update-AzPoolProperty -Endpoint <String> -PoolId <String> -JsonString <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This fully replaces all the updatable properties of the Pool.
For example, if\nthe Pool has a StartTask associated with it and if StartTask is not specified\nwith this request, then the Batch service will remove the existing StartTask.

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

### -ApplicationPackageReference
The list of Application Packages to be installed on each Compute Node in the Pool.
The list replaces any existing Application Package references on the Pool.
Changes to Application Package references affect all new Compute Nodes joining the Pool, but do not affect Compute Nodes that are already in the Pool until they are rebooted or reimaged.
There is a maximum of 10 Application Package references on any given Pool.
If omitted, or if you specify an empty collection, any existing Application Packages references are removed from the Pool.
A maximum of 10 references may be specified on a given Pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchApplicationPackageReference[]
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
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
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateReference
This list replaces any existing Certificate references configured on the Pool.If you specify an empty collection, any existing Certificate references are removed from the Pool.For Windows Nodes, the Batch service installs the Certificates to the specified Certificate store and location.For Linux Compute Nodes, the Certificates are stored in a directory inside the Task working directory and an environment variable AZ_BATCH_CERTIFICATES_DIR is supplied to the Task to query for this location.For Certificates with visibility of 'remoteUser', a 'certs' directory is created in the user's home directory (e.g., /home/{user-name}/certs) and Certificates are placed in that directory.Warning: This property is deprecated and will be removed after February, 2024.
Please use the [Azure KeyVault Extension](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide) instead.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchCertificateReference[]
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: True
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

### -ContainerSettingContainerHostBatchBindMount
The paths you want to mounted to container task.
If this array is null or be not present, container task will mount entire temporary disk drive in windows (or AZ_BATCH_NODE_ROOT_DIR in Linux).
It won't' mount any data paths into container if this array is set as empty.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IContainerHostBatchBindMountEntry[]
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
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
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
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
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
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
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
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

### -IdentityReferenceResourceId
The ARM resource id of the user assigned identity.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: ReplaceViaIdentity, ReplaceViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Replace operation

```yaml
Type: System.String
Parameter Sets: ReplaceViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Replace operation

```yaml
Type: System.String
Parameter Sets: ReplaceViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
A list of name-value pairs associated with the Pool as metadata.
This list replaces any existing metadata configured on the Pool.
If omitted, or if you specify an empty collection, any existing metadata is removed from the Pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchMetadataItem[]
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: True
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

### -Pool
Parameters for replacing properties on an Azure Batch Pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchPoolReplaceOptions
Parameter Sets: Replace, ReplaceViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PoolId
The ID of the Pool to update.

```yaml
Type: System.String
Parameter Sets: Replace, ReplaceExpanded, ReplaceViaJsonFilePath, ReplaceViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryPassword
The password to log into the registry server.

```yaml
Type: System.Security.SecureString
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
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
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
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
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
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

### -StartTaskCommandLine
The command line of the StartTask.
The command line does not run under a shell, and therefore cannot take advantage of shell features such as environment variable expansion.
If you want to take advantage of such features, you should invoke the shell in the command line, for example using "cmd /c MyCommand" in Windows or "/bin/sh -c MyCommand" in Linux.
If the command line refers to file paths, it should use a relative path (relative to the Task working directory), or use the Batch provided environment variable (https://learn.microsoft.com/azure/batch/batch-compute-node-environment-variables).

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskEnvironmentSetting
A list of environment variable settings for the StartTask.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IEnvironmentSetting[]
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskMaxTaskRetryCount
The maximum number of times the Task may be retried.
The Batch service retries a Task if its exit code is nonzero.
Note that this value specifically controls the number of retries.
The Batch service will try the Task once, and may then retry up to this limit.
For example, if the maximum retry count is 3, Batch tries the Task up to 4 times (one initial try and 3 retries).
If the maximum retry count is 0, the Batch service does not retry the Task.
If the maximum retry count is -1, the Batch service retries the Task without limit, however this is not recommended for a start task or any task.
The default value is 0 (no retries).

```yaml
Type: System.Int32
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskResourceFile
A list of files that the Batch service will download to the Compute Node before running the command line.
There is a maximum size for the list of resource files.
When the max size is exceeded, the request will fail and the response error code will be RequestEntityTooLarge.
If this occurs, the collection of ResourceFiles must be reduced in size.
This can be achieved using .zip files, Application Packages, or Docker Containers.
Files listed under this element are located in the Task's working directory.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IResourceFile[]
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskWaitForSuccess
Whether the Batch service should wait for the StartTask to complete successfully (that is, to exit with exit code 0) before scheduling any Tasks on the Compute Node.
If true and the StartTask fails on a Node, the Batch service retries the StartTask up to its maximum retry count (maxTaskRetryCount).
If the Task has still not completed successfully after all retries, then the Batch service marks the Node unusable, and will not schedule Tasks to it.
This condition can be detected via the Compute Node state and failure info details.
If false, the Batch service will not wait for the StartTask to complete.
In this case, other Tasks can start executing on the Compute Node while the StartTask is still running; and even if the StartTask fails, new Tasks will continue to be scheduled on the Compute Node.
The default is true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetNodeCommunicationMode
The desired node communication mode for the pool.
This setting replaces any existing targetNodeCommunication setting on the Pool.
If omitted, the existing setting is default.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
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
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchPoolReplaceOptions

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

