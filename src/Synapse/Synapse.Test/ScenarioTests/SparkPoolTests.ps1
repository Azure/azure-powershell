<#
.SYNOPSIS
Tests Synapse SparkPool Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-SynapseSparkPool
{
    param
    (
        $resourceGroupName = (Get-ResourceGroupName),
        $workspaceName = (Get-SynapseWorkspaceName),
        $sparkPoolName = (Get-SynapseSparkPoolName),
        $sparkPoolNameForAutoScale = $sparkPoolName + "1",
        $sparkPoolNodeCount = 3,
        $sparkAutoScaleMinNodeCount = 3,
        $sparkAutoScaleMaxNodeCount = 6,
        $sparkPoolNodeSize = "Small",
        $sparkVersion = 2.4
    )

    try
    {
        $resourceGroupName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("resourceGroupName", $resourceGroupName)
		$workspaceName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("workspaceName", $workspaceName)
        $workspace = Get-AzSynapseWorkspace -resourceGroupName $resourceGroupName -Name $workspaceName
        $location = $workspace.Location

        # Test to make sure the SparkPool doesn't exist
        Assert-False {Test-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName}

        # UnableAutoScale 
        $sparkPoolCreatedForUnableAutoScale = New-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName -NodeCount $sparkPoolNodeCount -SparkVersion $sparkVersion -NodeSize $sparkPoolNodeSize

        Assert-AreEqual $sparkPoolName $sparkPoolCreatedForUnableAutoScale.Name
        Assert-AreEqual $location $sparkPoolCreatedForUnableAutoScale.Location
        Assert-AreEqual "Microsoft.Synapse/Workspaces/bigDataPools" $sparkPoolCreatedForUnableAutoScale.Type
        Assert-True {$sparkPoolCreatedForUnableAutoScale.Id -like "*$resourceGroupName*"}

        # just test create for EnableAutoScale
        $sparkPoolCreatedForAutoScale = New-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolNameForAutoScale -AutoScaleMinNodeCount $sparkAutoScaleMinNodeCount -AutoScaleMaxNodeCount $sparkAutoScaleMaxNodeCount   -SparkVersion $sparkVersion -NodeSize $sparkPoolNodeSize

        Assert-AreEqual $sparkPoolNameForAutoScale $sparkPoolCreatedForAutoScale.Name
        Assert-AreEqual $location $sparkPoolCreatedForAutoScale.Location
        Assert-AreEqual "Microsoft.Synapse/Workspaces/bigDataPools" $sparkPoolCreatedForAutoScale.Type
        Assert-True {$sparkPoolCreatedForAutoScale.Id -like "*$resourceGroupName*"}
        
        # In loop to check if Spark pool exists
        for ($i = 0; $i -le 60; $i++)
        {
            [array]$sparkPoolGet = Get-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName
            if ($sparkPoolGet[0].ProvisioningState -like "Succeeded")
            {
                Assert-AreEqual $sparkPoolName $sparkPoolGet[0].Name
                Assert-AreEqual $location $sparkPoolGet[0].Location
                Assert-AreEqual "Microsoft.Synapse/Workspaces/bigDataPools" $sparkPoolGet[0].Type
                Assert-True {$sparkPoolCreatedForUnableAutoScale.Id -like "*$resourceGroupName*"}
                break
            }

            Write-Host "SparkPool not yet provisioned. current state: $($sparkPoolGet[0].ProvisioningState)"
            [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
            Assert-False {$i -eq 60} "Synapse SparkPool is not in succeeded state even after 30 min."
        }

        # Test to make sure the SparkPool does exist now
        Assert-True {Test-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName}

        # Updating SparkPool
        $tagsToUpdate = @{"TestTag" = "TestUpdate"}
        $sparkPoolUpdated = Update-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName -Tag $tagsToUpdate
    
        Assert-AreEqual $sparkPoolName $sparkPoolUpdated.Name
        Assert-AreEqual $location $sparkPoolUpdated.Location
        Assert-AreEqual "Microsoft.Synapse/workspaces/bigDataPools" $sparkPoolUpdated.Type
        Assert-True {$sparkPoolUpdated.Id -like "*$resourceGroupName*"}
    
        Assert-NotNull $sparkPoolUpdated.Tags "Tags do not exists"
        Assert-NotNull $sparkPoolUpdated.Tags["TestTag"] "The updated tag 'TestTag' does not exist"

        # Enable Auto-scale and Auto-pause
        $sparkPoolUpdated = Update-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName -EnableAutoScale $true -AutoScaleMinNodeCount 3 -AutoScaleMaxNodeCount 10 -EnableAutoPause $true -AutoPauseDelayInMinute 15

        Assert-AreEqual $sparkPoolName $sparkPoolUpdated.Name
        Assert-AreEqual $location $sparkPoolUpdated.Location
        Assert-AreEqual "Microsoft.Synapse/workspaces/bigDataPools" $sparkPoolUpdated.Type
        Assert-True {$sparkPoolUpdated.Id -like "*$resourceGroupName*"}

        Assert-True {$sparkPoolUpdated.AutoScale.Enabled}
        Assert-AreEqual 3 $sparkPoolUpdated.AutoScale.MinNodeCount
        Assert-AreEqual 10 $sparkPoolUpdated.AutoScale.MaxNodeCount

        Assert-True {$sparkPoolUpdated.AutoPause.Enabled}
        Assert-AreEqual 15 $sparkPoolUpdated.AutoPause.DelayInMinutes

        # Disable Auto-scale and Auto-pause
        $sparkPoolUpdated = Update-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName -EnableAutoScale $false -EnableAutoPause $false

        Assert-AreEqual $sparkPoolName $sparkPoolUpdated.Name
        Assert-AreEqual $location $sparkPoolUpdated.Location
        Assert-AreEqual "Microsoft.Synapse/workspaces/bigDataPools" $sparkPoolUpdated.Type
        Assert-True {$sparkPoolUpdated.Id -like "*$resourceGroupName*"}

        Assert-False {$sparkPoolUpdated.AutoScale.Enabled}
        Assert-AreEqual 3 $sparkPoolUpdated.AutoScale.MinNodeCount
        Assert-AreEqual 10 $sparkPoolUpdated.AutoScale.MaxNodeCount

        Assert-False {$sparkPoolUpdated.AutoPause.Enabled}
        Assert-AreEqual 15 $sparkPoolUpdated.AutoPause.DelayInMinutes

        # List all SparkPools in workspace
        [array]$sparkPoolsInWorkspace = Get-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName
        Assert-True {$sparkPoolsInWorkspace.Count -ge 1}
    
        $found = 0
        for ($i = 0; $i -lt $sparkPoolsInWorkspace.Count; $i++)
        {
            if ($sparkPoolsInWorkspace[$i].Name -eq $sparkPoolName)
            {
                $found = 1
                Assert-AreEqual $location $sparkPoolsInWorkspace[$i].Location
                Assert-AreEqual "Microsoft.Synapse/workspaces/bigDataPools" $sparkPoolsInWorkspace[$i].Type
                Assert-True {$sparkPoolsInWorkspace[$i].Id -like "*$resourceGroupName*"}
                break
            }
        }
        Assert-True {$found -eq 1} "SparkPool created earlier is not found when listing all in resource group: $resourceGroupName."

        # Delete SparkPool
        Assert-True {Remove-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName -PassThru -Force} "Remove SparkPool failed."
        Assert-True {Remove-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolNameForAutoScale -PassThru -Force} "Remove SparkPool failed."

        # Verify that it is gone by trying to get it again
        Assert-Throws {Get-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName}
    }
    finally
    {
        # cleanup the spark pool that was used in case it still exists. This is a best effort task, we ignore failures here.
        Invoke-HandledCmdlet -Command {Remove-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName -ErrorAction SilentlyContinue -Force} -IgnoreFailures
        Invoke-HandledCmdlet -Command {Remove-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolNameForAutoScale -ErrorAction SilentlyContinue -Force} -IgnoreFailures
    }
}
