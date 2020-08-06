<#
.SYNOPSIS
Tests Synapse SqlPool Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-SynapseSqlPoolV3
{
    param
    (
        $resourceGroupName = (Get-ResourceGroupName),
        $workspaceName = (Get-SynapseWorkspaceName),
        $sqlPoolName = (Get-SynapseSqlPoolName),
        $sqlPoolPerformanceLevel = 'DW500f'
    )

    try
    {
        $resourceGroupName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("resourceGroupName", $resourceGroupName)
        $workspaceName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("workspaceName", $workspaceName)
        $workspace = Get-AzSynapseWorkspace -resourceGroupName $resourceGroupName -Name $workspaceName
        $location = $workspace.Location

        # Test to make sure the SqlPool doesn't exist
        Assert-False {Test-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -Version 3}

        $sqlPoolCreated = New-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -PerformanceLevel $sqlPoolPerformanceLevel -Version 3

        Assert-AreEqual $sqlPoolName $sqlPoolCreated.Name
        Assert-AreEqual $location $sqlPoolCreated.Location
        Assert-AreEqual "Microsoft.Synapse/Workspaces/sqlPools" $sqlPoolCreated.Type
        Assert-True {$sqlPoolCreated.Id -like "*$resourceGroupName*"}

        # In loop to check if SQL pool exists
        for ($i = 0; $i -le 60; $i++)
        {
            [array]$sqlPoolGet = Get-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -Version 3
            if ($sqlPoolGet[0].Status -like "Online")
            {
                Assert-AreEqual $sqlPoolName $sqlPoolGet[0].Name
                Assert-AreEqual $location $sqlPoolGet[0].Location
                Assert-AreEqual "Microsoft.Synapse/Workspaces/sqlPools" $sqlPoolGet[0].Type
                Assert-True {$sqlPoolCreated.Id -like "*$resourceGroupName*"}
                break
            }

            Write-Host "SqlPool not yet provisioned. current state: $($sqlPoolGet[0].Status)"
            [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
            Assert-False {$i -eq 60} "Synapse SqlPool is not in succeeded state even after 30 min."
        }

        # Test to make sure the SqlPool does exist now
        Assert-True {Test-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -Version 3}
        
        # Updating SqlPool
        $newPerformanceLevel = 'DW1000f'
        Update-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -Version 3 -PerformanceLevel $newPerformanceLevel
 
		# Wait for 3 minutes for the update completion
		# Without this, the test will pass non-deterministically
		[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(180000)
        $sqlPoolUpdated = Get-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -Version 3

        Assert-AreEqual $sqlPoolName $sqlPoolUpdated.Name
        Assert-AreEqual $location $sqlPoolUpdated.Location
        Assert-AreEqual "Microsoft.Synapse/workspaces/sqlPools" $sqlPoolUpdated.Type
        Assert-True {$sqlPoolUpdated.Id -like "*$resourceGroupName*"}
    
        Assert-NotNull $sqlPoolUpdated.Sku.Name "Sku does not exist"
        Assert-AreEqual $newPerformanceLevel $sqlPoolUpdated.Sku.Name

        # List all SqlPools in workspace
        [array]$sqlPoolsInWorkspace = Get-AzSynapseSqlPool -resourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Version 3
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
        Assert-True {Remove-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -Version 3 -PassThru} "Remove SqlPool failed."

        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(180000)

        # Verify that it is gone by trying to get it again
        Assert-Throws {Get-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -Version 3}
    }
    finally
    {
        # cleanup the SQL pool that was used in case it still exists. This is a best effort task, we ignore failures here.
        Invoke-HandledCmdlet -Command {Remove-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -Version 3 -ErrorAction SilentlyContinue} -IgnoreFailures
    }
}
