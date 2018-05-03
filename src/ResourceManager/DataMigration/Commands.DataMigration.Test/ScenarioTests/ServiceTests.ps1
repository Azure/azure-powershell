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
		$all = Get-AzureRmDataMigrationService -ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual 1 $all.Count
		
		#Get specific service
		$all = Get-AzureRmDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name

		Assert-AreEqual $service.Name $all[0].Name
		Assert-AreEqual $rg.Location $all[0].Location
		Assert-AreEqual $service.Service.VirtualSubnetId $all[0].Service.VirtualSubnetId

		#Get random service - should get Not Found
		Assert-ThrowsContains { $all = Get-AzureRmDataMigrationService -ResourceGroupName $rg.ResourceGroupName -Name Get-ServiceName;} "NotFound"
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
		Stop-AzureRmDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name

		$all = Get-AzureRmDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name
		Assert-AreEqual 1 $all.Count
		Assert-AreEqual "Stopped" $all[0].Service.ProvisioningState

		#Start Service
		Start-AzureRmDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name
		
		$all = Get-AzureRmDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name
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
		$all = Get-AzureRmDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name

		#Service Will contain only One Project for this test case
		# Test case May FAIL if you are using Existing Service
		Assert-AreEqual $all.Count 1
		
		#Get specific projet
		$all = Get-AzureRmDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name

		Assert-AreEqual $project.Name $all[0].Name
		Assert-AreEqual SQL $all[0].Project.SourcePlatform
		Assert-AreEqual SQLDB $all[0].Project.TargetPlatform

		#Get random project should get Not Found
		Assert-ThrowsContains { $all = Get-AzureRmDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName Get-ProjectName;} "NotFound"
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
		Remove-AzureRmDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -Force
		
		Assert-ThrowsContains { $all = Get-AzureRmDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name ;} "NotFound"
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
		Remove-AzureRmDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -Force
		
		Assert-ThrowsContains { $all = Get-AzureRmDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name ;} "NotFound"
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

		$task = New-AzureRmDataMigrationTask -TaskType ConnectToSourceSqlServer -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -SourceConnection $connectioninfo -SourceCred $cred

		$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzureRmDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
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

		$task = New-AzureRmDataMigrationTask -TaskType ConnectToTargetSqlDb -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -TargetConnection $connectioninfo -TargetCred $cred

		$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzureRmDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
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
		$selectedDbs = @("tpcc")

		$task = New-AzureRmDataMigrationTask -TaskType GetUserTablesSql -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -SourceConnection $connectioninfo -SourceCred $cred -SelectedDatabase $selectedDbs

		$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzureRmDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
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
		$tableMap.Add("HR.COUNTRIES", "HR.COUNTRIES")
		$tableMap.Add("HR.DEPARTMENTS","HR.DEPARTMENTS")
		$tableMap.Add("HR.EMPLOYEES","HR.EMPLOYEES")
		$tableMap.Add("HR.JOBS","HR.JOBS")
		$tableMap.Add("HR.LOCATIONS","HR.LOCATIONS")
		$tableMap.Add("HR.REGIONS","HR.REGIONS")

		$sourceDbName = "HR"
		$targetDbName = "psTarget"

		$selectedDbs = New-AzureRmDataMigrationSelectedDB -MigrateSqlServerSqlDb -Name $sourceDbName -TargetDatabaseName $targetDbName -TableMap $tableMap
		Assert-AreEqual $sourceDbName $selectedDbs[0].Name
		Assert-AreEqual $targetDbName $selectedDbs[0].TargetDatabaseName
		Assert-AreEqual 6 $selectedDbs[0].TableMap.Count
		Assert-AreEqual true $selectedDbs[0].TableMap.ContainsKey("HR.COUNTRIES")
		Assert-AreEqual "HR.COUNTRIES" $selectedDbs[0].TableMap["HR.COUNTRIES"]

		$migTask = New-AzureRmDmsTask -TaskType MigrateSqlServerSqlDb -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -SourceConnection $sourceConnectionInfo -SourceCred $sourceCred -TargetConnection $targetConnectionInfo -TargetCred $targetCred -SelectedDatabase  $selectedDbs

		$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count		
		Assert-AreEqual $sourceDbName $task.ProjectTask.Properties.Input.SelectedDatabases[0].Name
		Assert-AreEqual $targetDbName $task.ProjectTask.Properties.Input.SelectedDatabases[0].TargetDatabaseName

		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzureRmDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
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

		$task = New-AzureRmDataMigrationTask -TaskType ConnectToTargetSqlDbMi -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -TargetConnection $connectioninfo -TargetCred $cred

		$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzureRmDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
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

		$backupFileShare = New-AzureRmDmsFileShare -Path $fileSharePath -Credential $fileShareCred
		Assert-AreEqual $fileSharePath $backupFileShare.Path
		Assert-AreEqual $fileShareUserName $backupFileShare.Username
		Assert-AreEqual $fileSharePassword $backupFileShare.Password

		$sourceDbName = "HR"
		$targetDbName = "HR_PSTEST"

		$selectedDbs = New-AzureRmDataMigrationSelectedDB -MigrateSqlServerSqlDbMi -Name $sourceDbName -TargetDatabaseName $targetDbName -BackupFileShare $backupFileShare

		Assert-AreEqual $sourceDbName $selectedDbs[0].Name
		Assert-AreEqual $targetDbName $selectedDbs[0].RestoreDatabaseName
		Assert-AreEqual $backupFileShare.Path $selectedDbs[0].BackupFileShare.Path

        $selectedLogins = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("MI_LOGINS")
        $selectedLogins = $selectedLogins -split ","

        $selectedJobs = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("MI_AGENTJOBS")
        $selectedJobs = $selectedJobs -split ","

		$migTask = New-AzureRmDataMigrationTask -TaskType MigrateSqlServerSqlDbMi `
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
          -SelectedAgentJobs $selectedJobs `
          -SelectedLogins $selectedLogins 

		$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual $backupFileShare.Path $task.ProjectTask.Properties.Input.BackupFileShare.Path
		Assert-AreEqual $selectedJobs[0] $task.ProjectTask.Properties.Input.SelectedAgentJobs[0]
		Assert-AreEqual $selectedLogins[0] $task.ProjectTask.Properties.Input.SelectedLogins[0]
		Assert-AreEqual $sourceDbName $task.ProjectTask.Properties.Input.SelectedDatabases[0].Name
		Assert-AreEqual $targetDbName $task.ProjectTask.Properties.Input.SelectedDatabases[0].RestoreDatabaseName

		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzureRmDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
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

		$backupFileShare = New-AzureRmDmsFileShare -Path $fileSharePath -Credential $fileShareCred

		$selectedDbs = New-AzureRmDataMigrationSelectedDB -MigrateSqlServerSqlDbMi -Name "HR" -TargetDatabaseName "HR_PSTEST1" -BackupFileShare $backupFileShare

		$migTask = New-AzureRmDataMigrationTask -TaskType ValidateSqlServerSqlDbMi `
		  -ResourceGroupName $rg.ResourceGroupName `
		  -ServiceName $service.Name `
		  -ProjectName $project.Name `
		  -TaskName $taskName `
		  -TargetConnection $targetConnectionInfo `
		  -TargetCred $targetCred `
		  -BackupBlobSasUri $blobSasUri `
		  -BackupFileShare $backupFileShare `
		  -SelectedDatabase $selectedDbs

		$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand

		Assert-AreEqual $taskName $task[0].Name
		Assert-AreEqual 1 $task.Count
		
		while(($task.ProjectTask.Properties.State -eq "Running") -or ($task.ProjectTask.Properties.State -eq "Queued"))
		{
			SleepTask 15
			$task = Get-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand
		}

		Assert-AreEqual "Succeeded" $task.ProjectTask.Properties.State

		Remove-AzureRmDataMigrationTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Force
		
		Assert-ThrowsContains { $all = Get-AzureRmDmsTask -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $project.Name -TaskName $taskName -Expand ;} "NotFound"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}