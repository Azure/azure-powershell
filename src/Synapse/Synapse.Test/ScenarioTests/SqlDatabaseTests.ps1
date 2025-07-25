<#
.SYNOPSIS
Tests Synapse SqlDatabase Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-SynapseSqlDatabase
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
        $sqlDatabaseName = $params.sqlDatabaseName

        # Test to make sure the SqlDatabase doesn't exist
        Assert-False {Test-AzSynapseSqlDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $SqlDatabaseName}

        $SqlDatabaseCreated = New-AzSynapseSqlDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $SqlDatabaseName

        Assert-AreEqual $SqlDatabaseName $SqlDatabaseCreated.Name
        Assert-AreEqual $location $SqlDatabaseCreated.Location
        Assert-AreEqual "Microsoft.Synapse/Workspaces/SqlDatabases" $SqlDatabaseCreated.Type
        Assert-True {$SqlDatabaseCreated.Id -like "*$resourceGroupName*"}

        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(180000)
        [array]$SqlDatabaseGet = Get-AzSynapseSqlDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $SqlDatabaseName
        Assert-AreEqual $SqlDatabaseName $SqlDatabaseGet[0].Name
        Assert-AreEqual $location $SqlDatabaseGet[0].Location
        Assert-AreEqual "Microsoft.Synapse/Workspaces/SqlDatabases" $SqlDatabaseGet[0].Type
        Assert-True {$SqlDatabaseCreated.Id -like "*$resourceGroupName*"}

        # Test to make sure the SqlDatabase does exist now
        Assert-True {Test-AzSynapseSqlDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $SqlDatabaseName}

        # List all SqlDatabases in workspace
        [array]$SqlDatabasesInWorkspace = Get-AzSynapseSqlDatabase -resourceGroupName $resourceGroupName -WorkspaceName $workspaceName
        Assert-True {$SqlDatabasesInWorkspace.Count -ge 1}
    
        $found = 0
        for ($i = 0; $i -lt $SqlDatabasesInWorkspace.Count; $i++)
        {
            if ($SqlDatabasesInWorkspace[$i].Name -eq $SqlDatabaseName)
            {
                $found = 1
                Assert-AreEqual $location $SqlDatabasesInWorkspace[$i].Location
                Assert-AreEqual "Microsoft.Synapse/workspaces/SqlDatabases" $SqlDatabasesInWorkspace[$i].Type
                Assert-True {$SqlDatabasesInWorkspace[$i].Id -like "*$resourceGroupName*"}
                break
            }
        }

        Assert-True {$found -eq 1} "SqlDatabase created earlier is not found when listing all in resource group: $resourceGroupName."

        # Delete SqlDatabase
        Assert-True {Remove-AzSynapseSqlDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $SqlDatabaseName -PassThru -Force} "Remove SqlDatabase failed."

        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(180000)

        # Verify that it is gone by trying to get it again
        Assert-Throws {Get-AzSynapseSqlDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $SqlDatabaseName}
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
			  sqlDatabaseName = "sqldb" + $testSuffix;
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
