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
