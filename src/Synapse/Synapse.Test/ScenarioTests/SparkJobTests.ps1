<#
.SYNOPSIS
Tests Synapse SparkJob Lifecycle (Submit, Get, List, Stop).
#>
function Test-SynapseSparkJob
{
    param
    (
        $resourceGroupName = (Get-resourceGroupName),
        $workspaceName = (Get-SynapseWorkspaceName),
        $sparkPoolName = (Get-SynapseSparkPoolName),
        $sparkPoolNodeCount = 8,
        $sparkPoolNodeSize = "Small",
        $sparkVersion = 2.4
    )

    try
    {
        $resourceGroupName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("resourceGroupName", $resourceGroupName)
        $workspaceName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("workspaceName", $workspaceName)
        $workspace = Get-AzSynapseWorkspace -resourceGroupName $resourceGroupName -Name $workspaceName
        $location = $workspace.Location

        # Test to make sure the SparkPool does exist now
        Assert-True {Test-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sparkPoolName}
        # Test it without specifying a resource group
        Assert-True {Test-AzSynapseSparkPool -WorkspaceName $workspaceName -Name $sparkPoolName}

        $defaultStorageUrl = $workspace.DefaultDataLakeStorage.DefaultDataLakeStorageAccountUrl
        $defaultFileSystem = $workspace.DefaultDataLakeStorage.DefaultDataLakeStorageFilesystem

        # Submit a job
        $jobInfo = Submit-AzSynapseSparkJob -WorkspaceName $workspaceName -SparkPoolName $sparkPoolName -Name WordCount_Java `
            -Language Spark `
            -MainDefinitionFile "$defaultStorageUrl/$defaultFileSystem/samples/java/wordcount/wordcount.jar" `
            -MainClassName WordCount `
            -CommandLineArguments "$defaultStorageUrl/$defaultFileSystem/samples/java/wordcount/shakespeare.txt","$defaultStorageUrl/$defaultFileSystem/samples/java/wordcount/result/" `
            -ExecutorCount 2 `
            -ExecutorSize Small

        Assert-NotNull {$jobInfo}
        Assert-AreEqual WordCount_Java $jobInfo.Name
        Assert-AreEqual SparkBatch $jobInfo.JobType

		# Wait for 3 minutes for the job completion
		# Without this, the test will pass non-deterministically
		[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(180000)

        # Wait for the job to finish and then confirm the script
        $jobInfo = Wait-AzSynapseSparkJob -WorkspaceName $workspaceName -SparkPoolName $sparkPoolName -LivyId $jobInfo.Id
        Assert-NotNull {$jobInfo}
        Assert-AreEqual "Succeeded" $jobInfo.Result

        # Get the job
        $sparkJobGet = Get-AzSynapseSparkPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -LivyId $jobInfo.Id
        Assert-NotNull {$sparkJobGet}
        Assert-AreEqual $jobInfo.Id $sparkJobGet.Id
        Assert-AreEqual "Succeeded" $sparkJobGet.Result

        # Create a Spark session
        $session = Start-AzSynapseSparkSession -WorkspaceName $workspaceName -SparkPoolName $sparkPoolName -Name testSession `
            -Language PySpark `
            -ExecutorCount 1 `
            -ExecutorSize Small

        Assert-NotNull {$session}
        Assert-AreEqual testSession $session.Name
        Assert-AreEqual SparkSession $session.JobType

        # Submit a session statement
        $code = @"
        new_rows = [('CA',22, 45000),("WA",35,65000) ,("WA",50,85000)]
        demo_df = spark.createDataFrame(new_rows, ['state', 'age', 'salary'])
        demo_df.show()
"@

        $stmtCreated = $session | Invoke-AzSynapseSparkStatement -Code $code
        Assert-AreEqual "Succeeded" $stmtCreated.Result

        $stmtGet = $session | Get-AzSynanpseSparkStatement -LivyId $stmtCreated.Id
        Assert-NotNull {$stmtGet}
        Assert-AreEqual $stmtCreated.Id $stmtGet.Id
        Assert-AreEqual "Succeeded" $stmtCreated.Get
    }
    finally
    {
        # TODO: cleanup the spark pool that was used in case it still exists. This is a best effort task, we ignore failures here.
    }
}
