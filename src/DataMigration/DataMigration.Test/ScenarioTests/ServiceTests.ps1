# ----------------------------------------------------------------------------------
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

function Test-CreateAndGetService
{
	$rg = Create-ResourceGroupForTest
	try
	{
		$service = Create-DataMigrationService($rg)

		#Get all service
		$all = Get-AzDataMigrationService -ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual 1 $all.Count
		
		#Get specific service
		$all = Get-AzDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name

		Assert-AreEqual $service.Name $all[0].Name
		Assert-AreEqual $rg.Location $all[0].Location
		Assert-AreEqual $service.Service.VirtualSubnetId $all[0].Service.VirtualSubnetId

		#Get random service - should get Not Found
		Assert-ThrowsContains { $all = Get-AzDataMigrationService -ResourceGroupName $rg.ResourceGroupName -Name Get-ServiceName;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-StopStartDataMigrationService
{
	$rg = Create-ResourceGroupForTest
	try
	{
		$service = Create-DataMigrationService($rg)
		#Stop Service
		Stop-AzDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name

		$all = Get-AzDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name
		Assert-AreEqual 1 $all.Count
		Assert-AreEqual "Stopped" $all[0].Service.ProvisioningState

		#Start Service
		Start-AzDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name
		
		$all = Get-AzDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name
		Assert-AreEqual 1 $all.Count
		Assert-AreEqual "Succeeded" $all[0].Service.ProvisioningState
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-CreateAndGetProjectSqlSqlDb
{
	$rg = Create-ResourceGroupForTest
	try
	{
		$service = Create-DataMigrationService($rg)
		
		$project = Create-ProjectSqlSqlDb $rg $service

		#Get Project for a service
		$all = Get-AzDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name

        Write-Host $all

		#Service Will contain only One Project for this test case
		# Test case May FAIL if you are using Existing Service
		Assert-AreEqual $all.Count 1
		
		#Get specific projet
		$all = Get-AzDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name

		Assert-AreEqual $project.Name $all[0].Name
		Assert-AreEqual SQL $all[0].Project.SourcePlatform
		Assert-AreEqual SQLDB $all[0].Project.TargetPlatform

		#Get random project should get Not Found
		Assert-ThrowsContains { $all = Get-AzDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName Get-ProjectName;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-RemoveService
{
	# Setup
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		# Test using parameters
		Remove-AzDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -Force
		
		Assert-ThrowsContains { $all = Get-AzDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-RemoveProject
{
	# Setup
	$rg = Create-ResourceGroupForTest

	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDb $rg $service
		# Test using parameters
		Remove-AzDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -Force
		
		Assert-ThrowsContains { $all = Get-AzDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-ConnectToSourceSqlServer
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDb $rg $service
		$taskName = Get-TaskName
		$connectionInfo = New-SourceSqlConnectionInfo
		$userName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_USERNAME")
		$password = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_PASSWORD")
		$cred = Get-Creds $userName $password

		$task = New-AzDataMigrationTask -TaskType ConnectToSourceSqlServer -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -SourceConnection $connectioninfo -SourceCred $cred

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-ConnectToTargetSqlDb
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDb $rg $service
		$taskName = Get-TaskName
		$connectionInfo = New-TargetSqlConnectionInfo
		$userName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDB_USERNAME") 
		$password = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDB_PASSWORD") 
		$cred = Get-Creds $userName $password

		$task = New-AzDataMigrationTask -TaskType ConnectToTargetSqlDb -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -TargetConnection $connectioninfo -TargetCred $cred

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-GetUserTableTask
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDb $rg $service
		$taskName = Get-TaskName
		$connectionInfo = New-SourceSqlConnectionInfo
		$userName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_USERNAME")
		$password = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_PASSWORD")
		$cred = Get-Creds $userName $password
		$selectedDbs = @("JasmineTest")

		$task = New-AzDataMigrationTask -TaskType GetUserTablesSql -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -SourceConnection $connectioninfo -SourceCred $cred -SelectedDatabase $selectedDbs

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-MigrateSqlSqlDB
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDb $rg $service
		$taskName = Get-TaskName

		#Source Connection Details
		$sourceConnectionInfo = New-SourceSqlConnectionInfo
		$sourceUserName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_USERNAME")
		$sourcePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_PASSWORD")
		$sourceCred = Get-Creds $sourceUserName $sourcePassword

		#Target Connection Details
		$targetConnectionInfo = New-TargetSqlConnectionInfo
		$targetUserName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDB_USERNAME")
		$targetPassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDB_PASSWORD")
		$targetCred = Get-Creds $targetUserName $targetPassword

		$tableMap = New-Object 'system.collections.generic.dictionary[string,string]'
		$tableMap.Add("dbo.TestTable1", "dbo.TestTable1")
		$tableMap.Add("dbo.TestTable2","dbo.TestTable2")

		$sourceDbName = "MigrateOneTime"
		$targetDbName = "JasmineTest"

		$selectedDbs = New-AzDataMigrationSelectedDB -MigrateSqlServerSqlDb -Name $sourceDbName -TargetDatabaseName $targetDbName -TableMap $tableMap
		Assert-AreEqual $sourceDbName $selectedDbs[0].Name
		Assert-AreEqual $targetDbName $selectedDbs[0].TargetDatabaseName
		Assert-AreEqual 2 $selectedDbs[0].TableMap.Count
		Assert-AreEqual true $selectedDbs[0].TableMap.ContainsKey("dbo.TestTable1")
		Assert-AreEqual "dbo.TestTable1" $selectedDbs[0].TableMap["dbo.TestTable1"]

		$migTask = New-AzDmsTask -TaskType MigrateSqlServerSqlDb -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -SourceConnection $sourceConnectionInfo -SourceCred $sourceCred -TargetConnection $targetConnectionInfo -TargetCred $targetCred -SelectedDatabase  $selectedDbs

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count		
		Assert-AreEqual $sourceDbName $task.ProjectTask.Properties.Input.SelectedDatabases[0].Name
		Assert-AreEqual $targetDbName $task.ProjectTask.Properties.Input.SelectedDatabases[0].TargetDatabaseName

		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-ConnectToTargetSqlDbMi
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDbMi $rg $service
		$taskName = Get-TaskName
		$connectionInfo = New-TargetSqlMiConnectionInfo
		$userName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_USERNAME")
		$password = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_PASSWORD")
		$cred = Get-Creds $userName $password

		$task = New-AzDataMigrationTask -TaskType ConnectToTargetSqlDbMi -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -TargetConnection $connectioninfo -TargetCred $cred

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-MigrateSqlSqlDBMi
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDbMi $rg $service
		$taskName = Get-TaskName

		#Source Connection Details
		$sourceConnectionInfo = New-SourceSqlConnectionInfo
		$sourceUserName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_USERNAME")
		$sourcePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_PASSWORD")
		$sourceCred = Get-Creds $sourceUserName $sourcePassword

		#Target Connection Details
		$targetConnectionInfo = New-TargetSqlMiConnectionInfo
		$targetUserName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_USERNAME")
		$targetPassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_PASSWORD")
		$targetCred = Get-Creds $targetUserName $targetPassword
		
		$blobSasUri = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("BLOB_SAS_URI")
		$fileSharePath = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("FILESHARE_PATH")
		$fileShareUsername = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("FILESHARE_USERNAME")
		$fileSharePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("FILESHARE_PASSWORD")
		$fileShareCred = Get-Creds $fileShareUsername $fileSharePassword

		$backupFileShare = New-AzDmsFileShare -Path $fileSharePath -Credential $fileShareCred
		$sourceDbName = "TestMI"
		$targetDbName = "TestMI6"
        $backupMode = "CreateBackup"

		$selectedDbs = New-AzDataMigrationSelectedDB -MigrateSqlServerSqlDbMi -Name $sourceDbName -TargetDatabaseName $targetDbName -BackupFileShare $backupFileShare

		Assert-AreEqual $sourceDbName $selectedDbs[0].Name
		Assert-AreEqual $targetDbName $selectedDbs[0].RestoreDatabaseName

        #Migrating Logins and AgentJobs
        #$selectedLogins = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("MI_LOGINS")
        #$selectedLogins = $selectedLogins -split ","

        #$selectedJobs = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("MI_AGENTJOBS")
        #$selectedJobs = $selectedJobs -split ","

		$migTask = New-AzDataMigrationTask -TaskType MigrateSqlServerSqlDbMi `
		  -ResourceGroupName $rg.ResourceGroupName `
		  -ServiceName $service.Name `
		  -ProjectName $project.Name `
		  -TaskName $taskName `
		  -TargetConnection $targetConnectionInfo `
		  -TargetCred $targetCred `
		  -SourceConnection $sourceConnectionInfo `
		  -SourceCred $sourceCred `
		  -BackupBlobSasUri $blobSasUri `
		  -BackupFileShare $backupFileShare `
		  -SelectedDatabase $selectedDbs `
          -BackupMode $backupMode

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		#Assert-AreEqual $selectedJobs[0] $task.ProjectTask.Properties.Input.SelectedAgentJobs[0]
		#Assert-AreEqual $selectedLogins[0] $task.ProjectTask.Properties.Input.SelectedLogins[0]
		Assert-AreEqual $sourceDbName $task.ProjectTask.Properties.Input.SelectedDatabases[0].Name
		Assert-AreEqual $targetDbName $task.ProjectTask.Properties.Input.SelectedDatabases[0].RestoreDatabaseName

		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-ValidateMigrationInputSqlSqlDbMi
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDbMi $rg $service
		$taskName = Get-TaskName

		#Source Connection Details
		$sourceConnectionInfo = New-SourceSqlConnectionInfo
		$sourceUserName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_USERNAME")
		$sourcePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_PASSWORD")
		$sourceCred = Get-Creds $sourceUserName $sourcePassword

		#Target Connection Details
		$targetConnectionInfo = New-TargetSqlMiConnectionInfo
		$targetUserName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_USERNAME")
		$targetPassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_PASSWORD")
		$targetCred = Get-Creds $targetUserName $targetPassword
		
		$blobSasUri = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("BLOB_SAS_URI")
		$fileSharePath = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("FILESHARE_PATH")
		$fileShareUsername = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("FILESHARE_USERNAME")
		$fileSharePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("FILESHARE_PASSWORD")
		$fileShareCred = Get-Creds $fileShareUsername $fileSharePassword

		$backupFileShare = New-AzDmsFileShare -Path $fileSharePath -Credential $fileShareCred

		$sourceDbName = "TestMI"
		$targetDbName = "TestTarget"
        $backupMode = "CreateBackup"

		$selectedDbs = New-AzDataMigrationSelectedDB -MigrateSqlServerSqlDbMi -Name $sourceDbName -TargetDatabaseName $targetDbName -BackupFileShare $backupFileShare

		$migTask = New-AzDataMigrationTask -TaskType ValidateSqlServerSqlDbMi `
		  -ResourceGroupName $rg.ResourceGroupName `
		  -ServiceName $service.Name `
		  -ProjectName $project.Name `
		  -TaskName $taskName `
		  -SourceConnection $sourceConnectionInfo `
		  -SourceCred $sourceCred `
		  -TargetConnection $targetConnectionInfo `
		  -TargetCred $targetCred `
		  -BackupBlobSasUri $blobSasUri `
		  -BackupFileShare $backupFileShare `
		  -SelectedDatabase $selectedDbs `
          -BackupMode $backupMode

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-ConnectToSourceSqlServerSync
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDb $rg $service
		$taskName = Get-TaskName
		$connectionInfo = New-SourceSqlConnectionInfo
		$userName = "testuser"
		$password = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_PASSWORD")
		$cred = Get-Creds $userName $password

		$task = New-AzDataMigrationTask -TaskType ConnectToSourceSqlServerSync -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -SourceConnection $connectioninfo -SourceCred $cred

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-ConnectToTargetSqlDbSync
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDb $rg $service
		$taskName = Get-TaskName
		
		$sourceConnectionInfo = New-SourceSqlConnectionInfo
		$sourceUserName = "testuser"
		$sourcePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_PASSWORD")
		$sourceCred = Get-Creds $sourceUserName $sourcePassword

		$targetConnectionInfo = New-TargetSqlConnectionInfo
		$targetUserName = "testuser"
		$targetPassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDB_PASSWORD")
		$targetCred = Get-Creds $targetUserName $targetPassword

		$task = New-AzDataMigrationTask -TaskType ConnectToTargetSqlSync -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -SourceConnection $sourceConnectionInfo -SourceCred $sourceCred -TargetConnection $targetConnectionInfo -TargetCred $targetCred

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-GetUserTableSyncTask
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDb $rg $service
		$taskName = Get-TaskName

		$sourceConnectionInfo = New-SourceSqlConnectionInfo
		$sourceUserName = "testuser"
		$sourcePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_PASSWORD")
		$sourceCred = Get-Creds $sourceUserName $sourcePassword

		$targetConnectionInfo = New-TargetSqlConnectionInfo
		$targetUserName = "testuser"
		$targetPassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDB_PASSWORD")
		$targetCred = Get-Creds $targetUserName $targetPassword

		$selectedSourceDb = @("MigrateOneTime")
		$selectedTargetDb = @("JasmineTest")

		$task = New-AzDataMigrationTask -TaskType GetUserTablesSqlSync `
			-ResourceGroupName $rg.ResourceGroupName `
			-ServiceName $service.Name `
			-ProjectName $project.Name `
			-TaskName $taskName `
			-SourceConnection $sourceConnectionInfo `
			-SourceCred $sourceCred `
			-TargetConnection $targetConnectionInfo `
			-TargetCred $targetCred `
			-SelectedSourceDatabases $selectedSourceDb `
			-SelectedTargetDatabases $selectedTargetDb

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-ValidateMigrationInputSqlSqlDbSync
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDb $rg $service
		$taskName = Get-TaskName

		$sourceConnectionInfo = New-SourceSqlConnectionInfo
		$sourceUserName = "testuser"
		$sourcePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_PASSWORD")
		$sourceCred = Get-Creds $sourceUserName $sourcePassword

		$targetConnectionInfo = New-TargetSqlConnectionInfo
		$targetUserName = "testuser"
		$targetPassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDB_PASSWORD")
		$targetCred = Get-Creds $targetUserName $targetPassword

		$tableMap = New-Object 'system.collections.generic.dictionary[string,string]'
		$tableMap.Add("dbo.TestTable1", "dbo.TestTable1")
		$tableMap.Add("dbo.TestTable2","dbo.TestTable2")

        $sourceDb = "MigrateOneTime"
        $targetDb = "JasmineTest"

		$selectedDbs = New-AzDmsSyncSelectedDB -TargetDatabaseName $targetDb `
		  -SchemaName dbo `
		  -TableMap $tableMap `
		  -Name $sourceDb

		$migTask = New-AzDataMigrationTask -TaskType ValidateSqlServerSqlDbSync `
		  -ResourceGroupName $rg.ResourceGroupName `
		  -ServiceName $service.Name `
		  -ProjectName $project.Name `
		  -TaskName $taskName `
		  -SourceConnection $sourceConnectionInfo `
		  -SourceCred $sourceCred `
		  -TargetConnection $targetConnectionInfo `
		  -TargetCred $targetCred `
		  -SelectedDatabase  $selectedDbs

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-MigrateSqlSqlDBSync
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDb $rg $service
		$taskName = Get-TaskName

		$sourceConnectionInfo = New-SourceSqlConnectionInfo
		$sourceUserName = "testuser"
		$sourcePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_PASSWORD")
		$sourceCred = Get-Creds $sourceUserName $sourcePassword

		$targetConnectionInfo = New-TargetSqlConnectionInfo
		$targetUserName = "testuser"
		$targetPassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDB_PASSWORD")
		$targetCred = Get-Creds $targetUserName $targetPassword

		$tableMap = New-Object 'system.collections.hashtable'
		$tableMap.Add("dbo.TestTable1", "dbo.TestTable1")
		$tableMap.Add("dbo.TestTable2","dbo.TestTable2")

        $sourceDb = "MigrateOneTime"
        $targetDb = "JasmineTest"

		$selectedDbs = New-AzDmsSyncSelectedDB -TargetDatabaseName $targetDb `
		  -SchemaName dbo `
		  -TableMap $tableMap `
		  -SourceDatabaseName $sourceDb

		$migTask = New-AzDmsTask -TaskType MigrateSqlServerSqlDbSync `
			-ResourceGroupName $rg.ResourceGroupName `
			-ServiceName $service.Name `
			-ProjectName $project.Name `
			-TaskName $taskName `
			-SourceConnection $sourceConnectionInfo `
			-SourceCred $sourceCred `
			-TargetConnection $targetConnectionInfo `
			-TargetCred $targetCred `
			-SelectedDatabase  $selectedDbs

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count

		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			Foreach($output in $task.ProjectTask.Properties.Output) {
			    if ($output.Id -clike 'db|*')
			    {
				    Write-Host ($output | Format-List | Out-String)

				    if ($output.MigrationState -eq "READY_TO_COMPLETE")
				    {
					    $command = Invoke-AzDmsCommand -CommandType CompleteSqlDBSync `
						    -ResourceGroupName $rg.ResourceGroupName `
						    -ServiceName $service.Name `
						    -ProjectName $project.Name `
						    -TaskName $taskName `
						    -DatabaseName $output.DatabaseName
				    }
                }
            }

			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-ConnectToSourceMongoDb
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectMongoDbMongoDb $rg $service
		$taskName = Get-TaskName
		$connectionInfo = New-SourceMongoDbConnectionInfo

		$task = New-AzDataMigrationTask -TaskType ConnectToSourceMongoDb -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -SourceConnection $connectioninfo -Wait

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}

}

function Test-ConnectToTargetCosmosDb
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectMongoDbMongoDb $rg $service
		$taskName = Get-TaskName
		$connectionInfo = New-TargetMongoDbConnectionInfo

		$task = New-AzDataMigrationTask -TaskType ConnectToSourceMongoDb -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -SourceConnection $connectioninfo -Wait

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-MigrateMongoDb
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectMongoDbMongoDb $rg $service
		$taskName = Get-TaskName

		$sourceConnectionInfo = New-SourceMongoDbConnectionInfo
		$targetConnectionInfo = New-TargetMongoDbConnectionInfo

		#----------------------
		# MIGRATION SETUP
		#----------------------
		$testColSettingA = New-AzDataMigrationMongoDbCollectionSetting -Name large -RU 1000 -CanDelete -ShardKey "_id"
		$testColSettingB = New-AzDataMigrationMongoDbCollectionSetting -Name many -RU 1000 -CanDelete -ShardKey "_id"
		$testDbSetting = New-AzDataMigrationMongoDbDatabaseSetting -Name test -CollectionSetting @($testColSettingA, $testColSettingB)

		#----------------------
		# MIGRATION VALIDATION
		#----------------------
		$validationTask = New-AzDmsTask -TaskType ValidateMongoDbMigration -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -SourceConnection $sourceConnectionInfo -TargetConnection $targetConnectionInfo  -SelectedDatabase  @($testDbSetting) -Wait
		$taskName = Get-TaskName
		$migTask = New-AzDmsTask -TaskType MigrateMongoDb -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -SourceConnection $sourceConnectionInfo -TargetConnection $targetConnectionInfo  -SelectedDatabase  @($testDbSetting) -MigrationValidation $validationTask -Replication Disabled

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

			if($task.ProjectTask.Properties.State -eq "Running") {
				$res = Invoke-AzDataMigrationCommand  -CommandType CancelMongoDB -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -ObjectName "test.many"
				Assert-AreEqual "Accepted" $res.State
			}
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-ConnectToTargetSqlDbMiSync
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDbMi $rg $service
		$taskName = Get-TaskName
		$connectionInfo = New-TargetSqlMiSyncConnectionInfo
		$userName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_USERNAME")
		$password = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_PASSWORD")
		$cred = Get-Creds $userName $password
		$app = New-AzureActiveDirectoryApp

		$task = New-AzDataMigrationTask -TaskType ConnectToTargetSqlDbMiSync -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -TargetConnection $connectioninfo -TargetCred $cred -AzureActiveDirectoryApp $app

		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State
		
		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-ValidateMigrationInputSqlSqlDbMiSync
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDbMi $rg $service
		$taskName = Get-TaskName

		#Source Connection Details
		$sourceConnectionInfo = New-SourceSqlConnectionInfo
		$sourceUserName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_USERNAME")
		$sourcePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_PASSWORD")
		$sourceCred = Get-Creds $sourceUserName $sourcePassword

		#Target Connection Details
		$targetConnectionInfo = New-TargetSqlMiSyncConnectionInfo
		$targetUserName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_USERNAME")
		$targetPassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_PASSWORD")
		$targetCred = Get-Creds $targetUserName $targetPassword
		
		$app = New-AzureActiveDirectoryApp

		$fileSharePath = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("FILESHARE_PATH")
		$fileShareUsername = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("FILESHARE_USERNAME")
		$fileSharePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("FILESHARE_PASSWORD")
		$fileShareCred = Get-Creds $fileShareUsername $fileSharePassword
		$backupFileShare = New-AzDmsFileShare -Path $fileSharePath -Credential $fileShareCred

		$storageResourceId = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("STORAGE_RESOURCE_ID")

		$sourceDbName = "AdventureWorks"
		$targetDbName = getDmsAssetName AdventureWorks

		$selectedDbs = New-AzDataMigrationSelectedDB -MigrateSqlServerSqlDbMi -Name $sourceDbName -TargetDatabaseName $targetDbName -BackupFileShare $backupFileShare

		$migTask = New-AzDataMigrationTask -TaskType ValidateSqlServerSqlDbMiSync `
		  -ResourceGroupName $rg.ResourceGroupName `
		  -ServiceName $service.Name `
		  -ProjectName $project.Name `
		  -TaskName $taskName `
		  -SourceConnection $sourceConnectionInfo `
		  -SourceCred $sourceCred `
		  -TargetConnection $targetConnectionInfo `
		  -TargetCred $targetCred `
		  -BackupFileShare $backupFileShare `
		  -SelectedDatabase $selectedDbs `
		  -AzureActiveDirectoryApp $app `
		  -StorageResourceId $storageResourceId


		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-MigrateSqlSqlDbMiSync
{
	$rg = Create-ResourceGroupForTest
	
	try
	{
		$service = Create-DataMigrationService($rg)
		$project = Create-ProjectSqlSqlDbMi $rg $service
		$taskName = Get-TaskName

		#Source Connection Details
		$sourceConnectionInfo = New-SourceSqlConnectionInfo
		$sourceUserName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_USERNAME")
		$sourcePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_PASSWORD")
		$sourceCred = Get-Creds $sourceUserName $sourcePassword

		#Target Connection Details
		$targetConnectionInfo = New-TargetSqlMiSyncConnectionInfo
		$targetUserName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_USERNAME")
		$targetPassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_PASSWORD")
		$targetCred = Get-Creds $targetUserName $targetPassword
		
		$app = New-AzureActiveDirectoryApp

		$fileSharePath = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("FILESHARE_PATH")
		$fileShareUsername = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("FILESHARE_USERNAME")
		$fileSharePassword = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("FILESHARE_PASSWORD")
		$fileShareCred = Get-Creds $fileShareUsername $fileSharePassword
		$backupFileShare = New-AzDmsFileShare -Path $fileSharePath -Credential $fileShareCred

		$storageResourceId = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("STORAGE_RESOURCE_ID")

		$sourceDbName = "AdventureWorks"
		$dbId = "db|"+$sourceDbName
		$targetDbName = getDmsAssetName AdventureWorks

		$selectedDbs = New-AzDataMigrationSelectedDB -MigrateSqlServerSqlDbMi -Name $sourceDbName -TargetDatabaseName $targetDbName -BackupFileShare $backupFileShare

		$migTask = New-AzDataMigrationTask -TaskType MigrateSqlServerSqlDbMiSync `
		  -ResourceGroupName $rg.ResourceGroupName `
		  -ServiceName $service.Name `
		  -ProjectName $project.Name `
		  -TaskName $taskName `
		  -SourceConnection $sourceConnectionInfo `
		  -SourceCred $sourceCred `
		  -TargetConnection $targetConnectionInfo `
		  -TargetCred $targetCred `
		  -BackupFileShare $backupFileShare `
		  -SelectedDatabase $selectedDbs `
		  -AzureActiveDirectoryApp $app `
		  -StorageResourceId $storageResourceId


		$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			Foreach($output in $task.ProjectTask.Properties.Output)
			{
				if ($output.Id -eq  $dbId)
				{
					if ($output.MigrationState -eq "LOG_FILES_UPLOADING")
					{
						if ($output.FullBackupSetInfo.BackupType -eq "Database")
						{
							if($output.FullBackupSetInfo.IsBackupRestored)
							{
								$command = Invoke-AzDmsCommand -CommandType CompleteSqlMiSync `
								-ResourceGroupName $rg.ResourceGroupName `
								-ServiceName $service.Name `
								-ProjectName $project.Name `
								-TaskName $taskName `
								-DatabaseName $output.SourceDatabaseName
							}
						}
					}
				}
			}

			SleepTask 15
			$task = Get-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}