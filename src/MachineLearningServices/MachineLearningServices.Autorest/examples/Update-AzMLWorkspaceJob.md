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

```output
```

These commands update a Job.
