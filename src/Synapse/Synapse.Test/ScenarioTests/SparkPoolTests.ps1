<#
.SYNOPSIS
Tests Synapse SparkPool Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-SynapseSparkPool
{
	# Setup
	$testSuffix = getAssetName
	Create-WorkspaceTestEnvironment $testSuffix
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix

    $resourceGroupName = $params.rgname
    $workspaceName = $params.workspaceName
    $sparkPoolName = $params.sparkPoolName
    $sparkPoolNameForAutoScale = $sparkPoolName + "1"
    $sparkPoolNodeCount = 3
    $sparkAutoScaleMinNodeCount = 3
    $sparkAutoScaleMaxNodeCount = 6
    $sparkPoolNodeSize = "Small"
    $sparkVersion = 2.4

    try
    {
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

        # Enable Auto-scale and Auto-pause, DynamicExecutorAllocation
        $sparkPoolUpdated = Update-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName -EnableAutoScale $true -AutoScaleMinNodeCount 3 -AutoScaleMaxNodeCount 10 -EnableAutoPause $true -AutoPauseDelayInMinute 15 -EnableDynamicExecutorAllocation $true -MinExecutorCount 1 -MaxExecutorCount 5

        Assert-AreEqual $sparkPoolName $sparkPoolUpdated.Name
        Assert-AreEqual $location $sparkPoolUpdated.Location
        Assert-AreEqual "Microsoft.Synapse/workspaces/bigDataPools" $sparkPoolUpdated.Type
        Assert-True {$sparkPoolUpdated.Id -like "*$resourceGroupName*"}

        Assert-True {$sparkPoolUpdated.AutoScale.Enabled}
        Assert-AreEqual 3 $sparkPoolUpdated.AutoScale.MinNodeCount
        Assert-AreEqual 10 $sparkPoolUpdated.AutoScale.MaxNodeCount

        Assert-True {$sparkPoolUpdated.AutoPause.Enabled}
        Assert-AreEqual 15 $sparkPoolUpdated.AutoPause.DelayInMinutes

        Assert-True {$sparkPoolUpdated.DynamicExecutorAllocation.Enabled}
        Assert-AreEqual 1 $sparkPoolUpdated.DynamicExecutorAllocation.MinExecutors
        Assert-AreEqual 5 $sparkPoolUpdated.DynamicExecutorAllocation.MaxExecutors

        # Disable Auto-scale and Auto-pause, DynamicExecutorAllocation
        $sparkPoolUpdated = Update-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName -EnableAutoScale $false -EnableAutoPause $false -EnableDynamicExecutorAllocation $false

        Assert-AreEqual $sparkPoolName $sparkPoolUpdated.Name
        Assert-AreEqual $location $sparkPoolUpdated.Location
        Assert-AreEqual "Microsoft.Synapse/workspaces/bigDataPools" $sparkPoolUpdated.Type
        Assert-True {$sparkPoolUpdated.Id -like "*$resourceGroupName*"}

        Assert-False {$sparkPoolUpdated.AutoScale.Enabled}
        Assert-AreEqual 3 $sparkPoolUpdated.AutoScale.MinNodeCount
        Assert-AreEqual 10 $sparkPoolUpdated.AutoScale.MaxNodeCount

        Assert-False {$sparkPoolUpdated.AutoPause.Enabled}
        Assert-AreEqual 15 $sparkPoolUpdated.AutoPause.DelayInMinutes

        Assert-False {$sparkPoolUpdated.DynamicExecutorAllocation.Enabled}

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

<#
.SYNOPSIS
Creates the test environment needed to perform the Synapse Spark related tests
#>
function Create-SparkTestEnvironmentWithParams ($params, $location)
{
	Create-BasicTestEnvironmentWithParams $params $location
	New-AzSynapseSparkPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -PerformanceLevel $params.perfLevel
	Wait-Seconds 10
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-WorkspaceTestEnvironment ($testSuffix)
{
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix
	Create-TestEnvironmentWithParams $params $params.location
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-WorkspaceTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "ws-cmdlet-test-rg" +$testSuffix;
			  workspaceName = "ws" +$testSuffix;
			  storageAccountName = "wsstorage" + $testSuffix;
			  fileSystemName = "wscmdletfs" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
              location = "eastus";
              sparkPoolName = "spool" + $testSuffix;
		}
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-WorkspaceTestEnvironment ($testSuffix)
{
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}
