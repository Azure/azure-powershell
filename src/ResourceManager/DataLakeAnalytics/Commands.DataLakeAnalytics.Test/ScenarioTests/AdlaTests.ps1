<#
.SYNOPSIS
Tests DataLakeAnalytics Account Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-DataLakeAnalyticsAccount
{
    param
	(
		$resourceGroupName = (Get-ResourceGroupName),
		$accountName = (Get-DataLakeAnalyticsAccountName),
		$dataLakeAccountName = (Get-DataLakeStoreAccountName),
		$secondDataLakeAccountName = (Get-DataLakeStoreAccountName),
		$blobAccountName,
		$blobAccountKey,
		$location = "West US"
	)

    try
	{
		# Creating Account and initial setup
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		# Test to make sure the account doesn't exist
		Assert-False {Test-AzureRMDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-False {Test-AzureRMDataLakeAnalyticsAccount -Name $accountName}

		New-AzureRmDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Location $location
		New-AzureRmDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $secondDataLakeAccountName -Location $location
		$accountCreated = New-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].Properties.ProvisioningState)"
			[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
			Assert-False {$i -eq 60} "dataLakeAnalytics account is not in succeeded state even after 30 min."
		}

		# Test to make sure the account does exist now
		Assert-True {Test-AzureRMDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-True {Test-AzureRMDataLakeAnalyticsAccount -Name $accountName}

		# Updating Account
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		$accountUpdated = Set-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Tags $tagsToUpdate
    
		Assert-AreEqual $accountName $accountUpdated.Name
		Assert-AreEqual $location $accountUpdated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountUpdated.Type
		Assert-True {$accountUpdated.Id -like "*$resourceGroupName*"}
	
		Assert-NotNull $accountUpdated.Tags "Tags do not exists"
		Assert-NotNull $accountUpdated.Tags["TestTag"] "The updated tag 'TestTag' does not exist"

		# List all accounts in resource group
		[array]$accountsInResourceGroup = Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName
		Assert-True {$accountsInResourceGroup.Count -ge 1}
    
		$found = 0
		for ($i = 0; $i -lt $accountsInResourceGroup.Count; $i++)
		{
			if ($accountsInResourceGroup[$i].Name -eq $accountName)
			{
				$found = 1
				Assert-AreEqual $location $accountsInResourceGroup[$i].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountsInResourceGroup[$i].Type
				Assert-True {$accountsInResourceGroup[$i].Id -like "*$resourceGroupName*"}
				break
			}
		}
		Assert-True {$found -eq 1} "Account created earlier is not found when listing all in resource group: $resourceGroupName."

		# List all dataLakeAnalytics accounts in subscription
		[array]$accountsInSubscription = Get-AzureRmDataLakeAnalyticsAccount
		Assert-True {$accountsInSubscription.Count -ge 1}
		Assert-True {$accountsInSubscription.Count -ge $accountsInResourceGroup.Count}
    
		$found = 0
		for ($i = 0; $i -lt $accountsInSubscription.Count; $i++)
		{
			if ($accountsInSubscription[$i].Name -eq $accountName)
			{
				$found = 1
				Assert-AreEqual $location $accountsInSubscription[$i].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountsInSubscription[$i].Type
				Assert-True {$accountsInSubscription[$i].Id -like "*$resourceGroupName*"}
				break
			}
		}
		Assert-True {$found -eq 1} "Account created earlier is not found when listing all in subscription."

		# add a data lake store account to the analytics account
		Add-AzureRmDataLakeAnalyticsDataSource -Account $accountName -DataLakeStore $secondDataLakeAccountName

		# get the account and ensure that it contains two data lake stores
		$testStoreAdd = Get-AzureRmDataLakeAnalyticsAccount -Name $accountName
		Assert-AreEqual 2 $testStoreAdd.Properties.DataLakeStoreAccounts.Count

		# get the specific data source added
		$adlsAccountInfo = Get-AzureRmDataLakeAnalyticsDataSource -Account $accountName -DataLakeStore $secondDataLakeAccountName
		Assert-AreEqual $secondDataLakeAccountName $adlsAccountInfo.Name

		# get the list of all data sources
		$adlsAccountInfos = Get-AzureRmDataLakeAnalyticsDataSource -Account $accountName
		Assert-AreEqual 2 $adlsAccountInfos.Count

		# remove the Data lake storage account
		Assert-True {Remove-AzureRmDataLakeAnalyticsDataSource -Account $accountName -DataLakeStore $secondDataLakeAccountName -Force -PassThru} "Remove Data Lake Store account failed."

		# get the account and ensure that it contains one data lake store
		$testStoreAdd = Get-AzureRmDataLakeAnalyticsAccount -Name $accountName
		Assert-AreEqual 1 $testStoreAdd.Properties.DataLakeStoreAccounts.Count

		# add a blob account to the analytics account
		Add-AzureRmDataLakeAnalyticsDataSource -Account $accountName -Blob $blobAccountName -AccessKey $blobAccountKey

		# get the account and ensure that it contains one blob account
		$testStoreAdd = Get-AzureRmDataLakeAnalyticsAccount -Name $accountName
		Assert-AreEqual 1 $testStoreAdd.Properties.StorageAccounts.Count

		# get the specific data source added
		$blobAccountInfo = Get-AzureRmDataLakeAnalyticsDataSource -Account $accountName -Blob $blobAccountName
		Assert-AreEqual $blobAccountName $blobAccountInfo.Name

		# get the list of data sources (there should be two, one ADLS account and one blob storage account)
		$blobAccountInfos = Get-AzureRmDataLakeAnalyticsDataSource -Account $accountName
		Assert-AreEqual 2 $blobAccountInfos.Count

		# remove the blob storage account
		Assert-True {Remove-AzureRmDataLakeAnalyticsDataSource -Account $accountName -Blob $blobAccountName -Force -PassThru} "Remove blob Storage account failed."

		# get the account and ensure that it contains no azure storage accounts
		$testStoreAdd = Get-AzureRmDataLakeAnalyticsAccount -Name $accountName
		Assert-True {$testStoreAdd.Properties.StorageAccounts -eq $null -or $testStoreAdd.Properties.StorageAccounts.Count -eq 0} "Remove blob storage reported success but failed to remove the account."

		# Delete dataLakeAnalytics account
		Assert-True {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $secondDataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}


<#
.SYNOPSIS
Tests DataLakeAnalytics Job Lifecycle (Submit, Get, List, Cancel and Get Debug data).
#>
function Test-DataLakeAnalyticsJob
{
    param
	(
		$resourceGroupName = (Get-ResourceGroupName),
		$accountName = (Get-DataLakeAnalyticsAccountName),
		$dataLakeAccountName = (Get-DataLakeStoreAccountName),
		$location = "West US"
	)
	try
	{
		# Creating Account and initial setup
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
		New-AzureRmDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Location $location
		$accountCreated = New-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName
		$nowTime = $accountCreated.Properties.CreationTime
        
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].Properties.ProvisioningState)"
			[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
			Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
		}

		# For now, all Job related tests just ensure that they have a valid response and do not throw.
		# Wait for two minutes and 30 seconds prior to attempting to submit the job in the freshly created account.
		[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(150000)
		# submit a job
		$guidForJob = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::GenerateGuid("jobTest01")
		[Microsoft.Azure.Commands.DataLakeAnalytics.Models.DataLakeAnalyticsClient]::JobIdQueue.Enqueue($guidForJob)
		$jobInfo = Submit-AzureRmDataLakeAnalyticsJob -AccountName $accountName -Name "TestJob" -Script "DROP DATABASE IF EXISTS foo; CREATE DATABASE foo;"
		Assert-NotNull {$jobInfo}

		# "cancel" the fake job right away
		Stop-AzureRmDataLakeAnalyticsJob -AccountName $accountName -JobId $jobInfo.JobId -Force
		$cancelledJob = Get-AzureRmDataLakeAnalyticsJob -AccountName $accountName -JobId $jobInfo.JobId

		# Get the specific job, and the list of all jobs in the resource group
		Assert-NotNull {$cancelledJob}
	
		# Verify the job was actually cancelled.
		Assert-True {$cancelledJob.Result -like "*Cancel*"}

		Assert-NotNull {Get-AzureRmDataLakeAnalyticsJob -AccountName $accountName}

		$jobsWithDateOffset = Get-AzureRmDataLakeAnalyticsJob -AccountName $accountName -SubmittedAfter $([DateTimeOffset]($nowTime).AddMinutes(-5))

		Assert-True {$jobsWithDateOffset.Count -gt 0} "Failed to retrieve jobs submitted after five miuntes ago"
		# we add five minutes to ensure that the timing is right, since we are using the account creation time, and not truly "now"
		$jobsWithDateOffset = Get-AzureRmDataLakeAnalyticsJob -AccountName $accountName -SubmittedBefore $([DateTimeOffset]($nowTime).AddMinutes(5)) 

		Assert-True {$jobsWithDateOffset.Count -gt 0} "Failed to retrieve jobs submitted before right now"

		# Delete the DataLakeAnalytics account
		Assert-True {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}


<#
.SYNOPSIS
Tests DataLakeAnalytics Account Lifecycle Failure scenarios (Create, Update, Get, Delete).
#>
function Test-NegativeDataLakeAnalyticsAccount
{
    param
	(
		$resourceGroupName = (Get-ResourceGroupName),
		$accountName = (Get-DataLakeAnalyticsAccountName),
		$location = "West US",
		$dataLakeAccountName = (Get-DataLakeStoreAccountName),
		$fakeaccountName = "psfakedataLakeAnalyticsaccounttest"
	)
	
	try
	{
		# Creating Account and initial setup
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
		New-AzureRmDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Location $location
		$accountCreated = New-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].Properties.ProvisioningState)"
			[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
			Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
		}

		# attempt to recreate the already created account
		Assert-Throws {New-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName}

		# attempt to update a non-existent account
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		Assert-Throws {Set-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $fakeaccountName -Tags $tagsToUpdate}

		# attempt to get a non-existent account
		Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $fakeaccountName}

		# Delete dataLakeAnalytics account
		Assert-True {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that trying to delete a non existent account now throws
		Assert-Throws {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru}

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}


<#
.SYNOPSIS
Tests DataLakeAnalytics Job Lifecycle (Get, Cancel and Get Debug data).
#>
function Test-NegativeDataLakeAnalyticsJob
{
   param
	(
		$resourceGroupName = (Get-ResourceGroupName),
		$accountName = (Get-DataLakeAnalyticsAccountName),
		$dataLakeAccountName = (Get-DataLakeStoreAccountName),
		$location = "West US"
	)
	
	try
	{
		# Creating Account and initial setup
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
		New-AzureRmDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Location $location
		$accountCreated = New-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName
        $nowTime = $accountCreated.Properties.CreationTime
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].Properties.ProvisioningState)"
			[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
			Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
		}

		# attempt to "cancel" a non-existent job
		Assert-Throws {Stop-AzureRmDataLakeAnalyticsJob -AccountName $accountName -JobIdentity [Guid]::Empty}

		# Attempt to get a job that doesn't exist
		Assert-Throws {Get-AzureRmDataLakeAnalyticsJob -AccountName $accountName -JobIdentity [Guid]::Empty}

		# Attempt to Get debug data for a non-existent job
		Assert-Throws {Get-AzureRmDataLakeAnalyticsJobDebugInfo -AccountName $accountName -JobIdentity [Guid]::Empty}

		$jobsWithDateOffset = Get-AzureRmDataLakeAnalyticsJob -AccountName $accountName -SubmittedAfter $([DateTimeOffset]$nowTime)

		Assert-True {$jobsWithDateOffset.Count -eq 0} "Retrieval of jobs submitted after right now returned results and should not have"

		# Delete the DataLakeAnalytics account
		Assert-True {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests DataLakeAnalytics Job Lifecycle (Get, Cancel and Get Debug data).
#>
function Test-DataLakeAnalyticsCatalog
{
   param
	(
		$resourceGroupName = (Get-ResourceGroupName),
		$accountName = (Get-DataLakeAnalyticsAccountName),
		$dataLakeAccountName = (Get-DataLakeStoreAccountName),
		$databaseName = (getAssetName),
		$tableName = (getAssetName),
		$tvfName = (getAssetName),
		$viewName = (getAssetName),
		$procName = (getAssetName),
		$credentialName = (getAssetName),
		$secretName = (getAssetName),
		$secretPwd = (getAssetName),
		$location = "West US"
	)
	
	try
	{
		# Creating Account and initial setup
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
		New-AzureRmDataLakeStoreAccount -Name $dataLakeAccountName -Location $location -ResourceGroupName $resourceGroupName
		$accountCreated = New-AzureRmDataLakeAnalyticsAccount -Name $accountName -Location $location -ResourceGroupName $resourceGroupName -DefaultDataLakeStore $dataLakeAccountName
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].Properties.ProvisioningState)"
			[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
			Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
		}
	
		# For now, all Job related tests just ensure that they have a valid response and do not throw.
		# Wait for two minutes prior to attempting to submit the job in the freshly created account.
		[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(120000)
	
		# Run a job to create the catalog items (except secret and credential)
		$scriptTemplate = @"
	DROP DATABASE IF EXISTS {0}; CREATE DATABASE {0};
	CREATE TABLE {0}.dbo.{1}
	(
			//Define schema of table
			UserId          int, 
			Start           DateTime, 
			Region          string, 
			Query           string, 
			Duration        int, 
			Urls            string, 
			ClickedUrls     string,
		INDEX idx1 //Name of index
		CLUSTERED (Region ASC) //Column to cluster by
		PARTITIONED BY BUCKETS (UserId) HASH (Region) //Column to partition by
	);
	ALTER TABLE {0}.dbo.{1} ADD IF NOT EXISTS PARTITION (1);
	DROP FUNCTION IF EXISTS {0}.dbo.{2};

	//create table weblogs on space-delimited website log data
	CREATE FUNCTION {0}.dbo.{2}()
	RETURNS @result TABLE
	(
		s_date DateTime,
		s_time string,
		s_sitename string,
		cs_method string, 
		cs_uristem string,
		cs_uriquery string,
		s_port int,
		cs_username string, 
		c_ip string,
		cs_useragent string,
		cs_cookie string,
		cs_referer string, 
		cs_host string,
		sc_status int,
		sc_substatus int,
		sc_win32status int, 
		sc_bytes int,
		cs_bytes int,
		s_timetaken int
	)
	AS
	BEGIN

		@result = EXTRACT
			s_date DateTime,
			s_time string,
			s_sitename string,
			cs_method string,
			cs_uristem string,
			cs_uriquery string,
			s_port int,
			cs_username string,
			c_ip string,
			cs_useragent string,
			cs_cookie string,
			cs_referer string,
			cs_host string,
			sc_status int,
			sc_substatus int,
			sc_win32status int,
			sc_bytes int,
			cs_bytes int,
			s_timetaken int
		FROM @"/Samples/Data/WebLog.log"
		USING Extractors.Text(delimiter:' ');

	RETURN;
	END;
	CREATE VIEW {0}.dbo.{3} 
	AS 
		SELECT * FROM 
		(
			VALUES(1,2),(2,4)
		) 
	AS 
	T(a, b);
	CREATE PROCEDURE {0}.dbo.{4}()
	AS BEGIN
	  CREATE VIEW {0}.dbo.{3} 
	  AS 
		SELECT * FROM 
		(
			VALUES(1,2),(2,4)
		) 
	  AS 
	  T(a, b);
	END;
"@
		# run the script
		$scriptToRun = [string]::Format($scriptTemplate, $databaseName, $tableName, $tvfName, $viewName, $procName)
		
		$guidForJob = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::GenerateGuid("createCatalogJob01")
		[Microsoft.Azure.Commands.DataLakeAnalytics.Models.DataLakeAnalyticsClient]::JobIdQueue.Enqueue($guidForJob)
		
		$jobInfo = Submit-AzureRmDataLakeAnalyticsJob -AccountName $accountName -Name "TestJob" -Script $scriptToRun
		$result = Wait-AzureRMDataLakeAnalyticsJob -AccountName $accountName -JobId $jobInfo.JobId
		Assert-AreEqual "Succeeded" $result.Result

		# retrieve the list of databases and ensure the created DB is in it
		$itemList = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType Database

		Assert-NotNull $itemList "The database list is null"

		Assert-True {$itemList.count -gt 0} "The database list is empty"
		$found = $false
		foreach($item in $itemList)
		{
			if($item.Name -eq $databaseName)
			{
				$found = $true
				break
			}
		}

		Assert-True {$found} "Could not find the database $databaseName in the database list"
	
		# retrieve the specific DB
		$specificItem = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType Database -Path $databaseName
		Assert-NotNull $specificItem "Could not retrieve the db by name"
		Assert-AreEqual $databaseName $specificItem.Name

		# retrieve the list of tables and ensure the created table is in it
		$itemList = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType Table -Path "$databaseName.dbo"

		Assert-NotNull $itemList "The table list is null"

		Assert-True {$itemList.count -gt 0} "The table list is empty"
		$found = $false
		foreach($item in $itemList)
		{
			if($item.Name -eq $tableName)
			{
				$found = $true
				break
			}
		}

		Assert-True {$found} "Could not find the table $tableName in the table list"
	
		# retrieve the specific table
		$specificItem = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType Table -Path "$databaseName.dbo.$tableName"
		Assert-NotNull $specificItem "Could not retrieve the table by name"
		Assert-AreEqual $tableName $specificItem.Name

		# retrieve the list of table partitions
		$itemList = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType TablePartition -Path "$databaseName.dbo.$tableName"

		Assert-NotNull $itemList "The table partition list is null"

		Assert-True {$itemList.count -gt 0} "The table partition list is empty"
		
		$itemToFind = $itemList[0]
	
		# retrieve the specific table partition
		$specificItem = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType TablePartition -Path "$databaseName.dbo.$tableName.[$($itemToFind.Name)]"
		Assert-NotNull $specificItem "Could not retrieve the table partition by name"
		Assert-AreEqual $itemToFind.Name $specificItem.Name

		# retrieve the list of table valued functions and ensure the created tvf is in it
		$itemList = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType TableValuedFunction -Path "$databaseName.dbo"

		Assert-NotNull $itemList "The TVF list is null"

		Assert-True {$itemList.count -gt 0} "The TVF list is empty"
		$found = $false
		foreach($item in $itemList)
		{
			if($item.Name -eq $tvfName)
			{
				$found = $true
				break
			}
		}

		Assert-True {$found} "Could not find the TVF $tvfName in the TVF list"
	
		# retrieve the specific TVF
		$specificItem = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType TableValuedFunction -Path "$databaseName.dbo.$tvfName"
		Assert-NotNull $specificItem "Could not retrieve the TVF by name"
		Assert-AreEqual $tvfName $specificItem.Name

		# retrieve the list of procedures and ensure the created procedure is in it
		$itemList = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType Procedure -Path "$databaseName.dbo"

		Assert-NotNull $itemList "The procedure list is null"

		Assert-True {$itemList.count -gt 0} "The procedure list is empty"
		$found = $false
		foreach($item in $itemList)
		{
			if($item.Name -eq $procName)
			{
				$found = $true
				break
			}
		}

		Assert-True {$found} "Could not find the procedure $procName in the procedure list"
	
		# retrieve the specific procedure
		$specificItem = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType Procedure -Path "$databaseName.dbo.$procName"
		Assert-NotNull $specificItem "Could not retrieve the procedure by name"
		Assert-AreEqual $procName $specificItem.Name

		# retrieve the list of views and ensure the created view is in it
		$itemList = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType View -Path "$databaseName.dbo"

		Assert-NotNull $itemList "The view list is null"

		Assert-True {$itemList.count -gt 0} "The view list is empty"
		$found = $false
		foreach($item in $itemList)
		{
			if($item.Name -eq $viewName)
			{
				$found = $true
				break
			}
		}
	
		Assert-True {$found} "Could not find the view $viewName in the view list"

		# retrieve the specific view
		$specificItem = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType View -Path "$databaseName.dbo.$viewName"
		Assert-NotNull $specificItem "Could not retrieve the view by name"
		Assert-AreEqual $viewName $specificItem.Name

		# create the secret
		$pw = ConvertTo-SecureString -String $secretPwd -AsPlainText -Force
		$secret = New-Object System.Management.Automation.PSCredential($secretName,$pw)
		$secretName2 = $secretName + "dup"
		$secret2 = New-Object System.Management.Automation.PSCredential($secretName2,$pw)

		New-AzureRmDataLakeAnalyticsCatalogSecret -AccountName $accountName -secret $secret -DatabaseName $databaseName -Uri "https://pstest.contoso.com:443"
		New-AzureRmDataLakeAnalyticsCatalogSecret -AccountName $accountName -secret $secret2 -DatabaseName $databaseName -Uri "https://pstest.contoso.com:443"

		# verify that the credential can be retrieved
		$getSecret = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType Secret -Path "$databaseName.$secretName"
		Assert-NotNull $getSecret "Could not retrieve the secret"

		# verify that attmepting to create the secret again throws
		# TODO: enable once we actually do throw when re-creating a secret.
		# Assert-Throws {New-AzureRmDataLakeAnalyticsCatalogSecret -AccountName $accountName -secret $secret -DatabaseName $databaseName -Uri "https://pstest.contoso.com:8080"}

		# credential job template
		$credentialJobTemplate = @"
	USE {0};
	CREATE CREDENTIAL {1} WITH USER_NAME = "scope@rkm4grspxa", IDENTITY = "{2}";
"@
		$credentialJob = [string]::Format($credentialJobTemplate, $databaseName, $credentialName, $secretName)
		
		$guidForJob = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::GenerateGuid("createCredentialjob02")
		[Microsoft.Azure.Commands.DataLakeAnalytics.Models.DataLakeAnalyticsClient]::JobIdQueue.Enqueue($guidForJob)
		$jobInfo = Submit-AzureRmDataLakeAnalyticsJob -AccountName $accountName -Name "TestJobCredential" -Script $credentialJob
		$result = Wait-AzureRMDataLakeAnalyticsJob -AccountName $accountName -JobId $jobInfo.JobId
		Assert-AreEqual "Succeeded" $result.Result

		# retrieve the list of credentials and ensure the created credential is in it
		$itemList = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType Credential -Path $databaseName

		Assert-NotNull $itemList "The credential list is null"

		Assert-True {$itemList.count -gt 0} "The credential list is empty"
		$found = $false
		foreach($item in $itemList)
		{
			if($item.Name -eq $credentialName)
			{
				$found = $true
				break
			}
		}
	
		# retrieve the specific credential
		$specificItem = Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType Credential -Path "$databaseName.$credentialName"
		Assert-NotNull $specificItem "Could not retrieve the credential by name"
		Assert-AreEqual $credentialName $specificItem.Name

		# credential job template
		$credentialJobTemplate = @"
	USE {0};
	DROP CREDENTIAL {1};
"@
		$credentialJob = [string]::Format($credentialJobTemplate, $databaseName, $credentialName)
		$guidForJob = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::GenerateGuid("dropCredentialJob02")
		[Microsoft.Azure.Commands.DataLakeAnalytics.Models.DataLakeAnalyticsClient]::JobIdQueue.Enqueue($guidForJob)
		$jobInfo = Submit-AzureRmDataLakeAnalyticsJob -AccountName $accountName -Name "TestJobCredential" -Script $credentialJob
		$result = Wait-AzureRMDataLakeAnalyticsJob -AccountName $accountName -JobId $jobInfo.JobId
		Assert-AreEqual "Succeeded" $result.Result
    
		# delete the secret
		Remove-AzureRmDataLakeAnalyticsCatalogSecret -AccountName $accountName -Name $secretName -DatabaseName $databaseName -Force

		# verify that the secret cannot be retrieved
		Assert-Throws {Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType Secret -Path "$databaseName.$secretName"}

		# delete all secrets
		Remove-AzureRmDataLakeAnalyticsCatalogSecret -AccountName $accountName -DatabaseName $databaseName -Force

		# verify that the second secret cannot be retrieved
		Assert-Throws {Get-AzureRMDataLakeAnalyticsCatalogItem -AccountName $accountName -ItemType Secret -Path "$databaseName.$secretName2"}

		# Delete the DataLakeAnalytics account
		Assert-True {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}