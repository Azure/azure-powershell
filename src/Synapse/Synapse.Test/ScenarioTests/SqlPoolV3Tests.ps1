<#
.SYNOPSIS
Tests Synapse SqlPool Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-SynapseSqlPoolV3
{
	# Setup
	$testSuffix = getAssetName
	Create-SqlPoolV3TestEnvironment $testSuffix
	$params = Get-SqlPoolV3TestEnvironmentParameters $testSuffix

    try
    {
        $resourceGroupName = $params.rgname
        $workspaceName = $params.WorkspaceName
        $location = $params.location
        $sqlPoolName = $params.sqlPoolName
        $sqlPoolPerformanceLevel = 'DW100c'

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
        $newPerformanceLevel = 'DW200c'
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
        Assert-True {Remove-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -Version 3 -PassThru -Force} "Remove SqlPool failed."

        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(180000)

        # Verify that it is gone by trying to get it again
        Assert-Throws {Get-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -Version 3}
    }
    finally
    {
		# Cleanup
		Remove-SqlPoolV3TestEnvironment $testSuffix
    }
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-SqlPoolV3TestEnvironment ($testSuffix)
{
	$params = Get-SqlPoolV3TestEnvironmentParameters $testSuffix
	Create-TestEnvironmentWithParams $params $params.location
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-SqlPoolV3TestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "sql-cmdlet-test-rg" +$testSuffix;
			  workspaceName = "sqlws" +$testSuffix;
			  sqlPoolName = "sqlpoolv3" + $testSuffix;
			  storageAccountName = "sqlstorage" + $testSuffix;
			  fileSystemName = "sqlcmdletfs" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
              location = "eastus2euap";
		}
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-SqlPoolV3TestEnvironment ($testSuffix)
{
	$params = Get-SqlPoolV3TestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}
