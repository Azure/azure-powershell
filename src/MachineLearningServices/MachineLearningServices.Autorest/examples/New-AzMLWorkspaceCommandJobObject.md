### Example 1: Create an in-memory object for CommandJob
```powershell
# You can use following commands to create job input or job oupt as vaule pass to JobInput or JobOutput parameter of the  New-AzMLWorkspaceCommandJobObject

# New-AzMLWorkspaceCustomModelJobInputObject
# New-AzMLWorkspaceCustomModelJobOutputObject
# New-AzMLWorkspaceLiteralJobInputObject
# New-AzMLWorkspaceMLFlowModelJobInputObject
# New-AzMLWorkspaceMLFlowModelJobOutputObject
# New-AzMLWorkspaceMLTableJobInputObject
# New-AzMLWorkspaceMLTableJobOutputObject
# New-AzMLWorkspaceSharedPrivateLinkResourceObject
# New-AzMLWorkspaceTritonModelJobInputObject
# New-AzMLWorkspaceTritonModelJobOutputObject
# New-AzMLWorkspaceUriFileJobInputObject
# New-AzMLWorkspaceUriFileJobOutputObject
# New-AzMLWorkspaceUriFolderJobInputObject
# New-AzMLWorkspaceUriFolderJobOutputObject

New-AzMLWorkspaceCommandJobObject -Command "echo `"hello world`"" `
-ComputeId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test01/computes/aml02' `
-EnvironmentId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test01/environments/commandjobenv/versions/1'`
-DisplayName 'commandjob01' -ExperimentName 'commandjobexperiment'
```

```output
```

Create an in-memory object for CommandJob.
