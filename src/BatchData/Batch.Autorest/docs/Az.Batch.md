---
Module Name: Az.Batch
Module Guid: 286c310a-f7fe-4b4e-9966-a7934b3c5168
Download Help Link: https://learn.microsoft.com/powershell/module/az.batch
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Batch Module
## Description
Microsoft Azure PowerShell: Batch cmdlets

## Az.Batch Cmdlets
### [Disable-AzJob](Disable-AzJob.md)
The Batch Service immediately moves the Job to the disabling state.
Batch then\nuses the disableTasks parameter to determine what to do with the currently\nrunning Tasks of the Job.
The Job remains in the disabling state until the\ndisable operation is completed and all Tasks have been dealt with according to\nthe disableTasks option; the Job then moves to the disabled state.
No new Tasks\nare started under the Job until it moves back to active state.
If you try to\ndisable a Job that is in any state other than active, disabling, or disabled,\nthe request fails with status code 409.

### [Disable-AzJobSchedule](Disable-AzJobSchedule.md)
No new Jobs will be created until the Job Schedule is enabled again.

### [Disable-AzNodeScheduling](Disable-AzNodeScheduling.md)
You can disable Task scheduling on a Compute Node only if its current\nscheduling state is enabled.

### [Disable-AzPoolAutoScale](Disable-AzPoolAutoScale.md)
Disables automatic scaling for a Pool.

### [Enable-AzJob](Enable-AzJob.md)
When you call this API, the Batch service sets a disabled Job to the enabling\nstate.
After the this operation is completed, the Job moves to the active\nstate, and scheduling of new Tasks under the Job resumes.
The Batch service\ndoes not allow a Task to remain in the active state for more than 180 days.\nTherefore, if you enable a Job containing active Tasks which were added more\nthan 180 days ago, those Tasks will not run.

### [Enable-AzJobSchedule](Enable-AzJobSchedule.md)
Enables a Job Schedule.

### [Enable-AzNodeScheduling](Enable-AzNodeScheduling.md)
You can enable Task scheduling on a Compute Node only if its current scheduling\nstate is disabled

### [Enable-AzPoolAutoScale](Enable-AzPoolAutoScale.md)
You cannot enable automatic scaling on a Pool if a resize operation is in\nprogress on the Pool.
If automatic scaling of the Pool is currently disabled,\nyou must specify a valid autoscale formula as part of the request.
If automatic\nscaling of the Pool is already enabled, you may specify a new autoscale formula\nand/or a new evaluation interval.
You cannot call this API for the same Pool\nmore than once every 30 seconds.

### [Get-AzApplication](Get-AzApplication.md)
This operation returns only Applications and versions that are available for\nuse on Compute Nodes; that is, that can be used in an Package reference.
For\nadministrator information about Applications and versions that are not yet\navailable to Compute Nodes, use the Azure portal or the Azure Resource Manager\nAPI.

### [Get-AzCertificate](Get-AzCertificate.md)
Gets information about the specified Certificate.

### [Get-AzJob](Get-AzJob.md)
Gets information about the specified Job.

### [Get-AzJobFromSchedule](Get-AzJobFromSchedule.md)
Lists the Jobs that have been created under the specified Job Schedule.

### [Get-AzJobPreparationAndReleaseTaskStatus](Get-AzJobPreparationAndReleaseTaskStatus.md)
This API returns the Job Preparation and Job Release Task status on all Compute\nNodes that have run the Job Preparation or Job Release Task.
This includes\nCompute Nodes which have since been removed from the Pool.
If this API is\ninvoked on a Job which has no Job Preparation or Job Release Task, the Batch\nservice returns HTTP status code 409 (Conflict) with an error code of\nJobPreparationTaskNotSpecified.

### [Get-AzJobSchedule](Get-AzJobSchedule.md)
Gets information about the specified Job Schedule.

### [Get-AzJobTaskCount](Get-AzJobTaskCount.md)
Task counts provide a count of the Tasks by active, running or completed Task\nstate, and a count of Tasks which succeeded or failed.
Tasks in the preparing\nstate are counted as running.
Note that the numbers returned may not always be\nup to date.
If you need exact task counts, use a list query.

### [Get-AzNode](Get-AzNode.md)
Gets information about the specified Compute Node.

### [Get-AzNodeExtension](Get-AzNodeExtension.md)
Gets information about the specified Compute Node Extension.

### [Get-AzNodeRemoteLoginSetting](Get-AzNodeRemoteLoginSetting.md)
Before you can remotely login to a Compute Node using the remote login settings, \nyou must get a user Account on the Compute Node.

### [Get-AzPool](Get-AzPool.md)
Gets information about the specified Pool.

### [Get-AzPoolNodeCount](Get-AzPoolNodeCount.md)
Gets the number of Compute Nodes in each state, grouped by Pool.
Note that the\nnumbers returned may not always be up to date.
If you need exact node counts,\nuse a list query.

### [Get-AzPoolSupportedImage](Get-AzPoolSupportedImage.md)
Lists all Virtual Machine Images supported by the Azure Batch service.

### [Get-AzPoolUsageMetric](Get-AzPoolUsageMetric.md)
If you do not specify a $filter clause including a poolId, the response\nincludes all Pools that existed in the Account in the time range of the\nreturned aggregation intervals.
If you do not specify a $filter clause\nincluding a startTime or endTime these filters default to the start and end\ntimes of the last aggregation interval currently available; that is, only the\nlast aggregation interval is returned.

### [Get-AzTask](Get-AzTask.md)
For multi-instance Tasks, information such as affinityId, executionInfo and\nnodeInfo refer to the primary Task.
Use the list subtasks API to retrieve\ninformation about subtasks.

### [Get-AzTaskSubTask](Get-AzTaskSubTask.md)
If the Task is not a multi-instance Task then this returns an empty collection.

### [Invoke-AzDeallocateNode](Invoke-AzDeallocateNode.md)
You can deallocate a Compute Node only if it is in an idle or running state.

### [Invoke-AzJobScheduleExist](Invoke-AzJobScheduleExist.md)
Checks the specified Job Schedule exists.

### [Invoke-AzPoolExist](Invoke-AzPoolExist.md)
Gets basic properties of a Pool.

### [Invoke-AzReactivateTask](Invoke-AzReactivateTask.md)
Reactivation makes a Task eligible to be retried again up to its maximum retry\ncount.
The Task's state is changed to active.
As the Task is no longer in the\ncompleted state, any previous exit code or failure information is no longer\navailable after reactivation.
Each time a Task is reactivated, its retry count\nis reset to 0.
Reactivation will fail for Tasks that are not completed or that\npreviously completed successfully (with an exit code of 0).
Additionally, it\nwill fail if the Job has completed (or is terminating or deleting).

### [Invoke-AzTerminateJob](Invoke-AzTerminateJob.md)
When a Terminate Job request is received, the Batch service sets the Job to the\nterminating state.
The Batch service then terminates any running Tasks\nassociated with the Job and runs any required Job release Tasks.
Then the Job\nmoves into the completed state.
If there are any Tasks in the Job in the active\nstate, they will remain in the active state.
Once a Job is terminated, new\nTasks cannot be added and any remaining active Tasks will not be scheduled.

### [Invoke-AzTerminateJobSchedule](Invoke-AzTerminateJobSchedule.md)
Terminates a Job Schedule.

### [Invoke-AzTerminateTask](Invoke-AzTerminateTask.md)
When the Task has been terminated, it moves to the completed state.
For\nmulti-instance Tasks, the terminate Task operation applies synchronously to the\nprimary task; subtasks are then terminated asynchronously in the background.

### [Invoke-AzUploadNodeLog](Invoke-AzUploadNodeLog.md)
This is for gathering Azure Batch service log files in an automated fashion\nfrom Compute Nodes if you are experiencing an error and wish to escalate to\nAzure support.
The Azure Batch service log files should be shared with Azure\nsupport to aid in debugging issues with the Batch service.

### [New-AzCertificate](New-AzCertificate.md)
Create a Certificate to the specified Account.

### [New-AzJob](New-AzJob.md)
The Batch service supports two ways to control the work done as part of a Job.\nIn the first approach, the user specifies a Job Manager Task.
The Batch service\nlaunches this Task when it is ready to start the Job.
The Job Manager Task\ncontrols all other Tasks that run under this Job, by using the Task APIs.
In\nthe second approach, the user directly controls the execution of Tasks under an\nactive Job, by using the Task APIs.
Also note: when naming Jobs, avoid\nincluding sensitive information such as user names or secret project names.\nThis information may appear in telemetry logs accessible to Microsoft Support\nengineers.

### [New-AzJobSchedule](New-AzJobSchedule.md)
Create a Job Schedule to the specified Account.

### [New-AzNodeUser](New-AzNodeUser.md)
You can add a user Account to a Compute Node only when it is in the idle or\nrunning state.

### [New-AzPool](New-AzPool.md)
When naming Pools, avoid including sensitive information such as user names or\nsecret project names.
This information may appear in telemetry logs accessible\nto Microsoft Support engineers.

### [New-AzTask](New-AzTask.md)
The maximum lifetime of a Task from addition to completion is 180 days.
If a\nTask has not completed within 180 days of being added it will be terminated by\nthe Batch service and left in whatever state it was in at that time.

### [New-AzTaskCollection](New-AzTaskCollection.md)
Note that each Task must have a unique ID.
The Batch service may not return the\nresults for each Task in the same order the Tasks were submitted in this\nrequest.
If the server times out or the connection is closed during the\nrequest, the request may have been partially or fully processed, or not at all.\nIn such cases, the user should re-issue the request.
Note that it is up to the\nuser to correctly handle failures when re-issuing a request.
For example, you\nshould use the same Task IDs during a retry so that if the prior operation\nsucceeded, the retry will not create extra Tasks unexpectedly.
If the response\ncontains any Tasks which failed to add, a client can retry the request.
In a\nretry, it is most efficient to resubmit only Tasks that failed to add, and to\nomit Tasks that were successfully added on the first attempt.
The maximum\nlifetime of a Task from addition to completion is 180 days.
If a Task has not\ncompleted within 180 days of being added it will be terminated by the Batch\nservice and left in whatever state it was in at that time.

### [Remove-AzCertificate](Remove-AzCertificate.md)
You cannot delete a Certificate if a resource (Pool or Compute Node) is using\nit.
Before you can delete a Certificate, you must therefore make sure that the\nCertificate is not associated with any existing Pools, the Certificate is not\ninstalled on any Nodes (even if you remove a Certificate from a Pool, it is not\nremoved from existing Compute Nodes in that Pool until they restart), and no\nrunning Tasks depend on the Certificate.
If you try to delete a Certificate\nthat is in use, the deletion fails.
The Certificate status changes to\ndeleteFailed.
You can use Cancel Delete Certificate to set the status back to\nactive if you decide that you want to continue using the Certificate.

### [Remove-AzJob](Remove-AzJob.md)
Deleting a Job also deletes all Tasks that are part of that Job, and all Job\nstatistics.
This also overrides the retention period for Task data; that is, if\nthe Job contains Tasks which are still retained on Compute Nodes, the Batch\nservices deletes those Tasks' working directories and all their contents.
When\na Delete Job request is received, the Batch service sets the Job to the\ndeleting state.
All delete operations on a Job that is in deleting state will\nfail with status code 409 (Conflict), with additional information indicating\nthat the Job is being deleted.

### [Remove-AzJobSchedule](Remove-AzJobSchedule.md)
When you delete a Job Schedule, this also deletes all Jobs and Tasks under that\nschedule.
When Tasks are deleted, all the files in their working directories on\nthe Compute Nodes are also deleted (the retention period is ignored).
The Job\nSchedule statistics are no longer accessible once the Job Schedule is deleted,\nthough they are still counted towards Account lifetime statistics.

### [Remove-AzNodeUser](Remove-AzNodeUser.md)
You can delete a user Account to a Compute Node only when it is in the idle or\nrunning state.

### [Remove-AzPool](Remove-AzPool.md)
When you request that a Pool be deleted, the following actions occur: the Pool\nstate is set to deleting; any ongoing resize operation on the Pool are stopped;\nthe Batch service starts resizing the Pool to zero Compute Nodes; any Tasks\nrunning on existing Compute Nodes are terminated and requeued (as if a resize\nPool operation had been requested with the default requeue option); finally,\nthe Pool is removed from the system.
Because running Tasks are requeued, the\nuser can rerun these Tasks by updating their Job to target a different Pool.\nThe Tasks can then run on the new Pool.
If you want to override the requeue\nbehavior, then you should call resize Pool explicitly to shrink the Pool to\nzero size before deleting the Pool.
If you call an delete  Patch or Delete API\non a Pool in the deleting state, it will fail with HTTP status code 409 with\nerror code PoolBeingDeleted.

### [Remove-AzPoolNode](Remove-AzPoolNode.md)
This operation can only run when the allocation state of the Pool is steady.\nWhen this operation runs, the allocation state changes from steady to resizing.\nEach request may remove up to 100 nodes.

### [Remove-AzTask](Remove-AzTask.md)
When a Task is deleted, all of the files in its directory on the Compute Node\nwhere it ran are also deleted (regardless of the retention time).
For\nmulti-instance Tasks, the delete Task operation applies synchronously to the\nprimary task; subtasks and their files are then deleted asynchronously in the\nbackground.

### [Resize-AzPool](Resize-AzPool.md)
You can only resize a Pool when its allocation state is steady.
If the Pool is\nalready resizing, the request fails with status code 409.
When you resize a\nPool, the Pool's allocation state changes from steady to resizing.
You cannot\nresize Pools which are configured for automatic scaling.
If you try to do this,\nthe Batch service returns an error 409.
If you resize a Pool downwards, the\nBatch service chooses which Compute Nodes to remove.
To remove specific Compute\nNodes, use the Pool remove Compute Nodes API instead.

### [Restart-AzNode](Restart-AzNode.md)
You can restart a Compute Node only if it is in an idle or running state.

### [Start-AzNode](Start-AzNode.md)
You can start a Compute Node only if it has been deallocated.

### [Stop-AzCertificateDeletion](Stop-AzCertificateDeletion.md)
If you try to delete a Certificate that is being used by a Pool or Compute\nNode, the status of the Certificate changes to deleteFailed.
If you decide that\nyou want to continue using the Certificate, you can use this operation to set\nthe status of the Certificate back to active.
If you intend to delete the\nCertificate, you do not need to run this operation after the deletion failed.\nYou must make sure that the Certificate is not being used by any resources, and\nthen you can try again to delete the Certificate.

### [Stop-AzPoolResize](Stop-AzPoolResize.md)
This does not restore the Pool to its previous state before the resize\noperation: it only stops any further changes being made, and the Pool maintains\nits current state.
After stopping, the Pool stabilizes at the number of Compute\nNodes it was at when the stop operation was done.
During the stop operation,\nthe Pool allocation state changes first to stopping and then to steady.
A\nresize operation need not be an explicit resize Pool request; this API can also\nbe used to halt the initial sizing of the Pool when it is created.

### [Test-AzPoolAutoScale](Test-AzPoolAutoScale.md)
This API is primarily for validating an autoscale formula, as it simply returns\nthe result without applying the formula to the Pool.
The Pool must have auto\nscaling enabled in order to evaluate a formula.

### [Update-AzJob](Update-AzJob.md)
This replaces only the Job properties specified in the request.
For example, if\nthe Job has constraints, and a request does not specify the constraints\nelement, then the Job keeps the existing constraints.

### [Update-AzJobSchedule](Update-AzJobSchedule.md)
This replaces only the Job Schedule properties specified in the request.
For\nexample, if the schedule property is not specified with this request, then the\nBatch service will keep the existing schedule.
Changes to a Job Schedule only\nimpact Jobs created by the schedule after the update has taken place; currently\nrunning Jobs are unaffected.

### [Update-AzNode](Update-AzNode.md)
You can reinstall the operating system on a Compute Node only if it is in an\nidle or running state.
This API can be invoked only on Pools created with the\ncloud service configuration property.

### [Update-AzPool](Update-AzPool.md)
This only replaces the Pool properties specified in the request.
For example,\nif the Pool has a StartTask associated with it, and a request does not specify\na StartTask element, then the Pool keeps the existing StartTask.

### [Update-AzPoolProperty](Update-AzPoolProperty.md)
This fully replaces all the updatable properties of the Pool.
For example, if\nthe Pool has a StartTask associated with it and if StartTask is not specified\nwith this request, then the Batch service will remove the existing StartTask.

