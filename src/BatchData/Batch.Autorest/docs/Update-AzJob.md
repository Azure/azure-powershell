---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/update-azjob
schema: 2.0.0
---

# Update-AzJob

## SYNOPSIS
This replaces only the Job properties specified in the request.
For example, if\nthe Job has constraints, and a request does not specify the constraints\nelement, then the Job keeps the existing constraints.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzJob -Endpoint <String> -Id <String> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>] [-IfUnmodifiedSince <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-AllowTaskPreemption] [-AllTasksCompleteMode <String>]
 [-AutoPoolSpecificationAutoPoolIdPrefix <String>] [-AutoPoolSpecificationKeepAlive]
 [-AutoPoolSpecificationPool <IBatchPoolSpecificationUpdate>]
 [-AutoPoolSpecificationPoolLifetimeOption <String>] [-ConstraintMaxTaskRetryCount <Int32>]
 [-ConstraintMaxWallClockTime <TimeSpan>] [-MaxParallelTask <Int32>] [-Metadata <IBatchMetadataItem[]>]
 [-NetworkConfigurationSkipWithdrawFromVnet] [-NetworkConfigurationSubnetId <String>]
 [-PoolInfoPoolId <String>] [-Priority <Int32>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzJob -Endpoint <String> -InputObject <IBatchIdentity> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>] [-IfUnmodifiedSince <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-AllowTaskPreemption] [-AllTasksCompleteMode <String>]
 [-AutoPoolSpecificationAutoPoolIdPrefix <String>] [-AutoPoolSpecificationKeepAlive]
 [-AutoPoolSpecificationPool <IBatchPoolSpecificationUpdate>]
 [-AutoPoolSpecificationPoolLifetimeOption <String>] [-ConstraintMaxTaskRetryCount <Int32>]
 [-ConstraintMaxWallClockTime <TimeSpan>] [-MaxParallelTask <Int32>] [-Metadata <IBatchMetadataItem[]>]
 [-NetworkConfigurationSkipWithdrawFromVnet] [-NetworkConfigurationSubnetId <String>]
 [-PoolInfoPoolId <String>] [-Priority <Int32>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzJob -Endpoint <String> -Id <String> -JsonFilePath <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>]
 [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzJob -Endpoint <String> -Id <String> -JsonString <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>]
 [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This replaces only the Job properties specified in the request.
For example, if\nthe Job has constraints, and a request does not specify the constraints\nelement, then the Job keeps the existing constraints.

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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllTasksCompleteMode
The action the Batch service should take when all Tasks in the Job are in the completed state.
If omitted, the completion behavior is left unchanged.
You may not change the value from terminatejob to noaction - that is, once you have engaged automatic Job termination, you cannot turn it off again.
If you try to do this, the request fails with an 'invalid property value' error response; if you are calling the REST API directly, the HTTP status code is 400 (Bad Request).

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

### -AutoPoolSpecificationAutoPoolIdPrefix
A prefix to be added to the unique identifier when a Pool is automatically created.
The Batch service assigns each auto Pool a unique identifier on creation.
To distinguish between Pools created for different purposes, you can specify this element to add a prefix to the ID that is assigned.
The prefix can be up to 20 characters long.

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

### -AutoPoolSpecificationKeepAlive
Whether to keep an auto Pool alive after its lifetime expires.
If false, the Batch service deletes the Pool once its lifetime (as determined by the poolLifetimeOption setting) expires; that is, when the Job or Job Schedule completes.
If true, the Batch service does not delete the Pool automatically.
It is up to the user to delete auto Pools created with this option.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchPoolSpecificationUpdate
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
The ID of the Job whose properties you want to update.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: JobId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
An ETag value associated with the version of the resource known to the client.
The operation will be performed only if the resource's current ETag on the
service exactly matches the value specified by the client.

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

### -IfModifiedSince
A timestamp indicating the last modified time of the resource known to the
client.
The operation will be performed only if the resource on the service has
been modified since the specified time.

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

### -IfNoneMatch
An ETag value associated with the version of the resource known to the client.
The operation will be performed only if the resource's current ETag on the
service does not match the value specified by the client.

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

### -IfUnmodifiedSince
A timestamp indicating the last modified time of the resource known to the
client.
The operation will be performed only if the resource on the service has
not been modified since the specified time.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
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

### -MaxParallelTask
The maximum number of tasks that can be executed in parallel for the job.
The value of maxParallelTasks must be -1 or greater than 0 if specified.
If not specified, the default value is -1, which means there's no limit to the number of tasks that can be run at once.
You can update a job's maxParallelTasks after it has been created using the update job API.

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

### -Metadata
A list of name-value pairs associated with the Job as metadata.
If omitted, the existing Job metadata is left unchanged.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchMetadataItem[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
If omitted, the priority of the Job is left unchanged.

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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

