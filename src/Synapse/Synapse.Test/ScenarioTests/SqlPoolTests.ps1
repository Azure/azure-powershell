<#
.SYNOPSIS
Tests Synapse SqlPool Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-SynapseSqlPool
{
    param
    (
        $resourceGroupName = (Get-ResourceGroupName),
        $workspaceName = (Get-SynapseWorkspaceName),
        $sqlPoolName = (Get-SynapseSqlPoolName),
        $restoreFromSqlPoolName = 'dwtestbackup',
        $sqlPoolPerformanceLevel = 'DW200c'
    )

    try
    {
        $resourceGroupName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("resourceGroupName", $resourceGroupName)
        $workspaceName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("workspaceName", $workspaceName)
        $workspace = Get-AzSynapseWorkspace -resourceGroupName $resourceGroupName -Name $workspaceName
        $location = $workspace.Location

        # Test to make sure the SqlPool doesn't exist
        Assert-False {Test-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName}

        $sqlPoolCreated = New-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -PerformanceLevel $sqlPoolPerformanceLevel

        Assert-AreEqual $sqlPoolName $sqlPoolCreated.Name
        Assert-AreEqual $location $sqlPoolCreated.Location
        Assert-AreEqual "Microsoft.Synapse/Workspaces/sqlPools" $sqlPoolCreated.Type
        Assert-True {$sqlPoolCreated.Id -like "*$resourceGroupName*"}

        # In loop to check if SQL pool exists
        for ($i = 0; $i -le 60; $i++)
        {
            [array]$sqlPoolGet = Get-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName
            if ($sqlPoolGet[0].ProvisioningState -like "Succeeded")
            {
                Assert-AreEqual $sqlPoolName $sqlPoolGet[0].Name
                Assert-AreEqual $location $sqlPoolGet[0].Location
                Assert-AreEqual "Microsoft.Synapse/Workspaces/sqlPools" $sqlPoolGet[0].Type
                Assert-True {$sqlPoolCreated.Id -like "*$resourceGroupName*"}
                break
            }

            Write-Host "SqlPool not yet provisioned. current state: $($sqlPoolGet[0].ProvisioningState)"
            [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
            Assert-False {$i -eq 60} "Synapse SqlPool is not in succeeded state even after 30 min."
        }

        # Test to make sure the SqlPool does exist now
        Assert-True {Test-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName}

        # Updating SqlPool
        $tagsToUpdate = @{"TestTag" = "TestUpdate"}
        Update-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -Tag $tagsToUpdate
 
		# Wait for 3 minutes for the update completion
		# Without this, the test will pass non-deterministically
		[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(180000)
        $sqlPoolUpdated = Get-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName

        Assert-AreEqual $sqlPoolName $sqlPoolUpdated.Name
        Assert-AreEqual $location $sqlPoolUpdated.Location
        Assert-AreEqual "Microsoft.Synapse/workspaces/sqlPools" $sqlPoolUpdated.Type
        Assert-True {$sqlPoolUpdated.Id -like "*$resourceGroupName*"}
    
        Assert-NotNull $sqlPoolUpdated.Tags "Tags do not exists"
        Assert-NotNull $sqlPoolUpdated.Tags["TestTag"] "The updated tag 'TestTag' does not exist"

        # List all SqlPools in workspace
        [array]$sqlPoolsInWorkspace = Get-AzSynapseSqlPool -resourceGroupName $resourceGroupName -WorkspaceName $workspaceName
        Assert-True {$sqlPoolsInWorkspace.Count -ge 1}
    
        $found = 0
        for ($i = 0; $i -lt $sqlPoolsInWorkspace.Count; $i++)
        {
            if ($sqlPoolsInWorkspace[$i].Name -eq $sqlPoolName)
            {
                $found = 1
                Assert-AreEqual $location $sqlPoolsInWorkspace[$i].Location
                Assert-AreEqual "Microsoft.Synapse/workspaces/sqlPools" $sqlPoolsInWorkspace[$i].Type
                Assert-True {$sqlPoolsInWorkspace[$i].Id -like "*$resourceGroupName*"}
                break
            }
        }
        Assert-True {$found -eq 1} "SqlPool created earlier is not found when listing all in resource group: $resourceGroupName."

        # Delete SqlPool
        Assert-True {Remove-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -PassThru} "Remove SqlPool failed."

        # Verify that it is gone by trying to get it again
        Assert-Throws {Get-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName}

        # Get restore point
        [array]$restorePoint = Get-AzSynapseSqlPoolRestorePoint -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $restoreFromSqlPoolName

        Assert-AreEqual "DISCRETE" $restorePoint[0].RestorePointType

        # Restore SqlPool
        $sqlPoolRestored = Restore-AzSynapseSqlPool -FromRestorePoint -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -SourceWorkspaceName $workspaceName -SourceSqlPoolName $restoreFromSqlPoolName -PerformanceLevel $sqlPoolPerformanceLevel

        Assert-AreEqual $sqlPoolName $sqlPoolRestored.Name
        Assert-AreEqual "Microsoft.Synapse/Workspaces/sqlPools" $sqlPoolRestored.Type
        Assert-True {$sqlPoolRestored.Id -like "*$resourceGroupName*"}

        # Suspend SqlPool
        $sqlPoolSuspended = Suspend-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName

        Assert-AreEqual "Paused" $sqlPoolSuspended.Status

        # Resume SqlPool
        $sqlPoolResumed = Resume-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName

        Assert-AreEqual "Online" $sqlPoolResumed.Status

        # Delete SqlPool
        Assert-True {Remove-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -PassThru} "Remove SqlPool failed."
    }
    finally
    {
        # cleanup the SQL pool that was used in case it still exists. This is a best effort task, we ignore failures here.
        Invoke-HandledCmdlet -Command {Remove-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -ErrorAction SilentlyContinue} -IgnoreFailures
    }
}
