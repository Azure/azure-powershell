<#
.SYNOPSIS
Tests DataLakeAnalytics Job recurrence and pipeline commands (Submit, Get).
#>
function Test-DataLakeAnalyticsJobRelationships
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
		New-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Location $location
		$accountCreated = New-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName
		$nowTime = $accountCreated.CreationTime
        
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
			Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
		}

		# Wait for 5 minutes for the server to restore the account cache
		# Without this, the test will pass non-deterministically
		[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(300000)

		# submit a job
		$guidForJob = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::GenerateGuid("relationTest01")
		
		# define job relationship values
		$guidForJobRecurrence = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::GenerateGuid("relationTest02")
		$guidForJobPipeline = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::GenerateGuid("relationTest03")
		$guidForJobRun = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::GenerateGuid("relationTest04")
		$pipelineName = getAssetName
		$recurrenceName = getAssetName
		$pipelineUri = "https://begoldsm.contoso.com/jobs"

		[Microsoft.Azure.Commands.DataLakeAnalytics.Models.DataLakeAnalyticsClient]::JobIdQueue.Enqueue($guidForJob)
		$jobInfo = Submit-AdlJob `
			-AccountName $accountName `
			-Name "TestJob" `
			-Script "DROP DATABASE IF EXISTS foo; CREATE DATABASE foo;" `
			-PipelineId $guidForJobPipeline `
			-RecurrenceId $guidForJobRecurrence `
			-RecurrenceName $recurrenceName `
			-PipelineName $pipelineName `
			-PipelineUri $pipelineUri `
			-RunId $guidForJobRun

		# wait for the job to finish and then confirm the relationship properties
		$jobInfo = Wait-AdlJob -Account $accountName -JobId $jobInfo.JobId
		
		Assert-NotNull {$jobInfo}
		Assert-AreEqual $guidForJobRecurrence $jobInfo.Related.RecurrenceId
		Assert-AreEqual $guidForJobPipeline $jobInfo.Related.PipelineId
		Assert-AreEqual $guidForJobRun $jobInfo.Related.RunId
		Assert-AreEqual $pipelineName $jobInfo.Related.PipelineName
		Assert-AreEqual $recurrenceName $jobInfo.Related.RecurrenceName
		Assert-AreEqual $pipelineUri $jobInfo.Related.PipelineUri

		# list all jobs with a specific pipelineId and then a specific recurrenceId
		$jobList = Get-AdlJob -Account $accountName -PipelineId $guidForJobPipeline
		Assert-True {$jobList.Count -ge 1}

		$jobList = Get-AdlJob -Account $accountName -RecurrenceId $guidForJobRecurrence
		Assert-True {$jobList.Count -ge 1}

		# get and list pipelines and recurrences
		$recurrenceList = Get-AdlJobRecurrence -Account $accountName
		Assert-True {$recurrenceList.Count -ge 1}

		$recurrence = Get-AdlJobRecurrence -Account $accountName -RecurrenceId $guidForJobRecurrence
		Assert-AreEqual $recurrenceName $recurrence.RecurrenceName
		Assert-AreEqual $guidForJobRecurrence $recurrence.RecurrenceId

		$pipelineList = Get-AdlJobPipeline -Account $accountName
		Assert-True {$pipelineList.Count -ge 1}

		$pipeline = Get-AdlJobPipeline -Account $accountName -PipelineId $guidForJobPipeline
		Assert-AreEqual $pipelineName $pipeline.PipelineName
		Assert-AreEqual $guidForJobPipeline $pipeline.PipelineId
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests DataLakeAnalytics Account compute policy lifecycle (Create, Update, Get, List, Delete).
#>
function Test-DataLakeAnalyticsComputePolicy
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
		# Creating Account
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		# Test to make sure the account doesn't exist
		Assert-False {Test-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-False {Test-AdlAnalyticsAccount -Name $accountName}

		New-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Location $location

		$accountCreated = New-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Analytics account is not in succeeded state even after 30 min."
		}

		# Test to make sure the account does exist
		Assert-True {Test-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}

		# define compute policies
		$userPolicyObjectId = "8ce05900-7a9e-4895-b3f0-0fbcee507803"
		$userPolicyName = getAssetName
		$groupPolicyObjectId = "0583cfd7-60f5-43f0-9597-68b85591fc69"
		$groupPolicyName = getAssetName

		# Test to confirm there are no compute policies.
		Assert-AreEqual 0 $accountCreated.ComputePolicies.Count 		

		# attempt to create an empty policy without specifying either max or min
		Assert-Throws {New-AdlAnalyticsComputePolicy -ResourceGroupName $resourceGroupName -AccountName  $accountName -Name $userPolicyName -ObjectId $userPolicyObjectId -ObjectType "User"}

		# Add a compute policy with one policy for a user
		New-AdlAnalyticsComputePolicy -ResourceGroupName $resourceGroupName -AccountName  $accountName -Name $userPolicyName -ObjectId $userPolicyObjectId -ObjectType "User" -MaxDegreeOfParallelismPerJob 2

		# Add a compute policy with two policy for a group
		New-AdlAnalyticsComputePolicy -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $groupPolicyName -ObjectId $groupPolicyObjectId -ObjectType "Group" -MaxDegreeOfParallelismPerJob 2 -MinPriorityPerJob 2

		# Get the list of policies
		$policyResult = Get-AdlAnalyticsComputePolicy -ResourceGroupName $resourceGroupName -AccountName $accountName

		Assert-AreEqual 2 $policyResult.Count

		# Get a specific policy (user policy)
		$singlePolicy = Get-AdlAnalyticsComputePolicy -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $userPolicyName
		Assert-AreEqual $userPolicyName $singlePolicy.Name
		Assert-AreEqual 2 $singlePolicy.MaxDegreeOfParallelismPerJob

		# attempt to update that policy with no policy pieces (should fail)
		Assert-Throws {Update-AdlAnalyticsComputePolicy -ResourceGroupName $resourceGroupName -AccountName  $accountName -Name $userPolicyName}

		# update the user policy to include a min priority
		Update-AdlAnalyticsComputePolicy -ResourceGroupName $resourceGroupName -AccountName  $accountName -Name $userPolicyName -MinPriorityPerJob 2

		# get the policy and confirm the change
		$singlePolicy = Get-AdlAnalyticsComputePolicy -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $userPolicyName
		Assert-AreEqual $userPolicyName $singlePolicy.Name
		Assert-AreEqual 2 $singlePolicy.MaxDegreeOfParallelismPerJob
		Assert-AreEqual 2 $singlePolicy.MinPriorityPerJob

		# remove the user policy
		Remove-AdlAnalyticsComputePolicy -AccountName $accountName -Name $userPolicyName

		# Make sure get throws.
		Assert-Throws {Get-AdlAnalyticsComputePolicy -AccountName $accountName -Name $userPolicyName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests DataLakeAnalytics Account firewall rule lifecycle (Create, Update, Get, List, Delete).
#>
function Test-DataLakeAnalyticsFirewall
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
		# Creating Account
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		# Test to make sure the account doesn't exist
		Assert-False {Test-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-False {Test-AdlAnalyticsAccount -Name $accountName}

		New-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Location $location

		$accountCreated = New-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Analytics account is not in succeeded state even after 30 min."
		}

		# Test to make sure the account does exist
		Assert-True {Test-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}

		# Test to enable the firewall as well as allowing azure IPs
		Assert-AreEqual "Disabled" $accountCreated.FirewallState 
		
		# TODO: Re-enable this when this property is re-introduced by the service
		# Assert-AreEqual "Disabled" $accountCreated.FirewallAllowAzureIps 

		$accountSet = Set-AdlAnalyticsAccount -Name $accountName -FirewallState "Enabled" -AllowAzureIpState "Enabled"

		Assert-AreEqual "Enabled" $accountSet.FirewallState 
		
		# TODO: Re-enable this when this property is re-introduced by the service
		# Assert-AreEqual "Enabled" $accountSet.FirewallAllowAzureIps

		$firewallRuleName = getAssetName
		$startIp = "127.0.0.1"
		$endIp = "127.0.0.2"
		# Add a firewall rule
		Add-AdlAnalyticsFirewallRule -AccountName $accountName -Name $firewallRuleName -StartIpAddress $startIp -EndIpAddress $endIp

		# Get the firewall rule
		$result = Get-AdlAnalyticsFirewallRule -AccountName $accountName -Name $firewallRuleName
		Assert-AreEqual $firewallRuleName $result.Name
		Assert-AreEqual $startIp $result.StartIpAddress
		Assert-AreEqual $endIp $result.EndIpAddress

		# remove the firewall rule
		Remove-AdlAnalyticsFirewallRule -AccountName $accountName -Name $firewallRuleName

		# Make sure get throws.
		Assert-Throws {Get-AdlAnalyticsFirewallRule -AccountName $accountName -Name $firewallRuleName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

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
		Assert-False {Test-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-False {Test-AdlAnalyticsAccount -Name $accountName}

		New-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Location $location
		New-AdlStore -ResourceGroupName $resourceGroupName -Name $secondDataLakeAccountName -Location $location
		$accountCreated = New-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
			Assert-False {$i -eq 60} "dataLakeAnalytics account is not in succeeded state even after 30 min."
		}

		# Test to make sure the account does exist now
		Assert-True {Test-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-True {Test-AdlAnalyticsAccount -Name $accountName}

		# Updating Account
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		$accountUpdated = Set-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Tags $tagsToUpdate
    
		Assert-AreEqual $accountName $accountUpdated.Name
		Assert-AreEqual $location $accountUpdated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountUpdated.Type
		Assert-True {$accountUpdated.Id -like "*$resourceGroupName*"}
	
		Assert-NotNull $accountUpdated.Tags "Tags do not exists"
		Assert-NotNull $accountUpdated.Tags["TestTag"] "The updated tag 'TestTag' does not exist"

		# List all accounts in resource group
		[array]$accountsInResourceGroup = Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName
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
		[array]$accountsInSubscription = Get-AdlAnalyticsAccount
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
		Add-AdlAnalyticsDataSource -Account $accountName -DataLakeStore $secondDataLakeAccountName

		# get the account and ensure that it contains two data lake stores
		$testStoreAdd = Get-AdlAnalyticsAccount -Name $accountName
		Assert-AreEqual 2 $testStoreAdd.DataLakeStoreAccounts.Count

		# get the specific data source added
		$adlsAccountInfo = Get-AdlAnalyticsDataSource -Account $accountName -DataLakeStore $secondDataLakeAccountName
		Assert-AreEqual $secondDataLakeAccountName $adlsAccountInfo.Name

		# get the list of all data sources
		$adlsAccountInfos = Get-AdlAnalyticsDataSource -Account $accountName
		Assert-AreEqual 2 $adlsAccountInfos.Count

		# remove the Data lake storage account
		Assert-True {Remove-AdlAnalyticsDataSource -Account $accountName -DataLakeStore $secondDataLakeAccountName -Force -PassThru} "Remove Data Lake Store account failed."

		# get the account and ensure that it contains one data lake store
		$testStoreAdd = Get-AdlAnalyticsAccount -Name $accountName
		Assert-AreEqual 1 $testStoreAdd.DataLakeStoreAccounts.Count

		# add a blob account to the analytics account
		Add-AdlAnalyticsDataSource -Account $accountName -Blob $blobAccountName -AccessKey $blobAccountKey

		# get the account and ensure that it contains one blob account
		$testStoreAdd = Get-AdlAnalyticsAccount -Name $accountName
		Assert-AreEqual 1 $testStoreAdd.StorageAccounts.Count

		# get the specific data source added
		$blobAccountInfo = Get-AdlAnalyticsDataSource -Account $accountName -Blob $blobAccountName
		Assert-AreEqual $blobAccountName $blobAccountInfo.Name

		# get the list of data sources (there should be two, one ADLS account and one blob storage account)
		$blobAccountInfos = Get-AdlAnalyticsDataSource -Account $accountName
		Assert-AreEqual 2 $blobAccountInfos.Count

		# remove the blob storage account
		Assert-True {Remove-AdlAnalyticsDataSource -Account $accountName -Blob $blobAccountName -Force -PassThru} "Remove blob Storage account failed."

		# get the account and ensure that it contains no azure storage accounts
		$testStoreAdd = Get-AdlAnalyticsAccount -Name $accountName
		Assert-True {$testStoreAdd.StorageAccounts -eq $null -or $testStoreAdd.StorageAccounts.Count -eq 0} "Remove blob storage reported success but failed to remove the account."

		# Delete dataLakeAnalytics account
		Assert-True {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $secondDataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}


<#
.SYNOPSIS
Tests DataLakeAnalytics Account commitment tier (Create, Update, Get).
#>
function Test-DataLakeAnalyticsAccountTiers
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

		# Test to make sure the account doesn't exist
		Assert-False {Test-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-False {Test-AdlAnalyticsAccount -Name $accountName}

		New-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Location $location

		# Test 1: create account with no pricing tier and validate default
		$accountCreated = New-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName
    
		Assert-AreEqual "Consumption" $accountCreated.CurrentTier
		Assert-AreEqual "Consumption" $accountCreated.NewTier

		# Test 2: update this account to have a new pricing tier
		$accountUpdated = Set-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Tier Commitment100AUHours

		Assert-AreEqual "Consumption" $accountUpdated.CurrentTier
		Assert-AreEqual "Commitment100AUHours" $accountUpdated.NewTier

		# Test 3: Create a new account with a tier specified
		$secondAccountName = (Get-DataLakeAnalyticsAccountName)
		$accountCreated = New-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $secondAccountName -Location $location -DefaultDataLakeStore $dataLakeAccountName -Tier Commitment100AUHours
		Assert-AreEqual "Commitment100AUHours" $accountCreated.CurrentTier
		Assert-AreEqual "Commitment100AUHours" $accountCreated.NewTier
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $secondAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
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
		New-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Location $location
		$accountCreated = New-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName
		$nowTime = $accountCreated.CreationTime
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
			Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
		}

		# Wait for 5 minutes for the server to restore the account cache
		# Without this, the test will pass non-deterministically
		[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(300000)

		# Submit a job
		$guidForJob = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::GenerateGuid("jobTest02")
		[Microsoft.Azure.Commands.DataLakeAnalytics.Models.DataLakeAnalyticsClient]::JobIdQueue.Enqueue($guidForJob)

		$jobInfo = Submit-AdlJob -AccountName $accountName -Name "TestJob" -Script "DROP DATABASE IF EXISTS foo; CREATE DATABASE foo;"
		Assert-NotNull {$jobInfo}

		# "Cancel" the fake job right away
		Stop-AdlJob -AccountName $accountName -JobId $jobInfo.JobId -Force
		$cancelledJob = Get-AdlJob -AccountName $accountName -JobId $jobInfo.JobId

		# Get the specific job, and the list of all jobs in the resource group
		Assert-NotNull {$cancelledJob}
	
		# Verify the job was actually cancelled.
		Assert-True {$cancelledJob.Result -like "*Cancel*"}

		Assert-NotNull {Get-AdlJob -AccountName $accountName}

		$jobsWithDateOffset = Get-AdlJob -AccountName $accountName -SubmittedAfter $([DateTimeOffset]($nowTime).AddMinutes(-10))

		Assert-True {$jobsWithDateOffset.Count -gt 0} "Failed to retrieve jobs submitted after ten miuntes ago"
		
		# We add ten minutes to ensure that the timing is right, since we are using the account creation time, and not truly "now"
		$jobsWithDateOffset = Get-AdlJob -AccountName $accountName -SubmittedBefore $([DateTimeOffset]($nowTime).AddMinutes(10))

		Assert-True {$jobsWithDateOffset.Count -gt 0} "Failed to retrieve jobs submitted before right now"

		# Submit a job with script parameters
		$guidForJob = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::GenerateGuid("jobTest04")
		[Microsoft.Azure.Commands.DataLakeAnalytics.Models.DataLakeAnalyticsClient]::JobIdQueue.Enqueue($guidForJob)

		# Define script parameters
		$parameters = [ordered]@{}
		$parameters["byte_type"] = [byte]0
		$parameters["sbyte_type"] = [sbyte]1
		$parameters["int_type"] = [int32]2
		$parameters["uint_type"] = [uint32]3
		$parameters["long_type"] = [int64]4
		$parameters["ulong_type"] = [uint64]5
		$parameters["float_type"] = [float]6
		$parameters["double_type"] = [double]7
		$parameters["decimal_type"] = [decimal]8
		$parameters["short_type"] = [int16]9
		$parameters["ushort_type"] = [uint16]10
		$parameters["char_type"] = [char]"a"
		$parameters["string_type"] = "test"
		$parameters["datetime_type"] = [DateTime](Get-Date -Date "2018-01-01 00:00:00")
		$parameters["bool_type"] = $true
		$parameters["guid_type"] = [guid]"8dbdd1e8-0675-4cf2-a7f7-5e376fa43c6d"
		$parameters["bytearray_type"] = [byte[]]@(0, 1, 2)

		# Define the expected script
		$expectedScript = "DECLARE @byte_type byte = 0;`nDECLARE @sbyte_type sbyte = 1;`nDECLARE @int_type int = 2;`nDECLARE @uint_type uint = 3;`nDECLARE @long_type long = 4;`nDECLARE @ulong_type ulong = 5;`nDECLARE @float_type float = 6;`nDECLARE @double_type double = 7;`nDECLARE @decimal_type decimal = 8;`nDECLARE @short_type short = 9;`nDECLARE @ushort_type ushort = 10;`nDECLARE @char_type char = 'a';`nDECLARE @string_type string = `"test`";`nDECLARE @datetime_type DateTime = new DateTime(2018, 1, 1, 0, 0, 0, 0);`nDECLARE @bool_type bool = true;`nDECLARE @guid_type Guid = new Guid(`"8dbdd1e8-0675-4cf2-a7f7-5e376fa43c6d`");`nDECLARE @bytearray_type byte[] = new byte[] {`n  0,`n  1,`n  2,`n};`nDROP DATABASE IF EXISTS foo; CREATE DATABASE foo;"

		$jobInfo = Submit-AdlJob -AccountName $accountName -Name "TestJob" -Script "DROP DATABASE IF EXISTS foo; CREATE DATABASE foo;" -ScriptParameter $parameters
		Assert-NotNull {$jobInfo}

		# Wait for the job to finish and then confirm the script
		$jobInfo = Wait-AdlJob -Account $accountName -JobId $jobInfo.JobId
		Assert-NotNull {$jobInfo}
		Assert-AreEqual "Succeeded" $jobInfo.Result
		Assert-AreEqual $expectedScript $jobInfo.Properties.Script

		# Delete the DataLakeAnalytics account
		Assert-True {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
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
		New-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Location $location
		$accountCreated = New-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName
		
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
			Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
		}

		# attempt to recreate the already created account
		Assert-Throws {New-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName}

		# attempt to update a non-existent account
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		Assert-Throws {Set-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $fakeaccountName -Tags $tagsToUpdate}

		# attempt to get a non-existent account
		Assert-Throws {Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $fakeaccountName}

		# Delete dataLakeAnalytics account
		Assert-True {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that trying to delete a non existent account now throws
		Assert-Throws {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru}

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
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
		New-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Location $location
		$accountCreated = New-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName
		$nowTime = $accountCreated.CreationTime
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
			Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
		}

		# attempt to "cancel" a non-existent job
		Assert-Throws {Stop-AdlJob -AccountName $accountName -JobIdentity [Guid]::Empty}

		# Attempt to get a job that doesn't exist
		Assert-Throws {Get-AdlJob -AccountName $accountName -JobIdentity [Guid]::Empty}

		# Attempt to Get debug data for a non-existent job
		Assert-Throws {Get-AdlJobDebugInfo -AccountName $accountName -JobIdentity [Guid]::Empty}

		$jobsWithDateOffset = Get-AdlJob -AccountName $accountName -SubmittedAfter $([DateTimeOffset]$nowTime)

		Assert-True {$jobsWithDateOffset.Count -eq 0} "Retrieval of jobs submitted after right now returned results and should not have"

		# Delete the DataLakeAnalytics account
		Assert-True {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
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
		New-AdlStore -Name $dataLakeAccountName -Location $location -ResourceGroupName $resourceGroupName
		$accountCreated = New-AdlAnalyticsAccount -Name $accountName -Location $location -ResourceGroupName $resourceGroupName -DefaultDataLakeStore $dataLakeAccountName
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
			Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
		}

		# Wait for 5 minutes for the server to restore the account cache
		# Without this, the test will pass non-deterministically
		[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(300000)
	
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
		PARTITIONED BY (UserId) HASH (Region) //Column to partition by
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
		$guidForJob = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::GenerateGuid("catalogCreationJob01")
		[Microsoft.Azure.Commands.DataLakeAnalytics.Models.DataLakeAnalyticsClient]::JobIdQueue.Enqueue($guidForJob)
		$jobInfo = Submit-AdlJob -AccountName $accountName -Name "TestJob" -Script $scriptToRun
		$result = Wait-AdlJob -AccountName $accountName -JobId $jobInfo.JobId
		Assert-AreEqual "Succeeded" $result.Result

		# retrieve the list of databases and ensure the created DB is in it
		$itemList = Get-AdlCatalogItem -AccountName $accountName -ItemType Database

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
		$specificItem = Get-AdlCatalogItem -AccountName $accountName -ItemType Database -Path $databaseName
		Assert-NotNull $specificItem "Could not retrieve the db by name"
		Assert-AreEqual $databaseName $specificItem.Name

		# retrieve the list of tables and ensure the created table is in it
		$itemList = Get-AdlCatalogItem -AccountName $accountName -ItemType Table -Path "$databaseName.dbo"

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
		# retrieve the list in the database (no schema)
		$itemList = Get-AdlCatalogItem -AccountName $accountName -ItemType Table -Path "$databaseName"

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
		$specificItem = Get-AdlCatalogItem -AccountName $accountName -ItemType Table -Path "$databaseName.dbo.$tableName"
		Assert-NotNull $specificItem "Could not retrieve the table by name"
		Assert-AreEqual $tableName $specificItem.Name

		# retrieve the list of table partitions
		$itemList = Get-AdlCatalogItem -AccountName $accountName -ItemType TablePartition -Path "$databaseName.dbo.$tableName"

		Assert-NotNull $itemList "The table partition list is null"

		Assert-True {$itemList.count -gt 0} "The table partition list is empty"
		
		$itemToFind = $itemList[0]
	
		# retrieve the specific table partition
		$specificItem = Get-AdlCatalogItem -AccountName $accountName -ItemType TablePartition -Path "$databaseName.dbo.$tableName.[$($itemToFind.Name)]"
		Assert-NotNull $specificItem "Could not retrieve the table partition by name"
		Assert-AreEqual $itemToFind.Name $specificItem.Name

		# retrieve the list of table valued functions and ensure the created tvf is in it
		$itemList = Get-AdlCatalogItem -AccountName $accountName -ItemType TableValuedFunction -Path "$databaseName.dbo"

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
	
		# get the items from just the database (no schema)
		$itemList = Get-AdlCatalogItem -AccountName $accountName -ItemType TableValuedFunction -Path "$databaseName"

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
		$specificItem = Get-AdlCatalogItem -AccountName $accountName -ItemType TableValuedFunction -Path "$databaseName.dbo.$tvfName"
		Assert-NotNull $specificItem "Could not retrieve the TVF by name"
		Assert-AreEqual $tvfName $specificItem.Name

		# retrieve the list of procedures and ensure the created procedure is in it
		$itemList = Get-AdlCatalogItem -AccountName $accountName -ItemType Procedure -Path "$databaseName.dbo"

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
		$specificItem = Get-AdlCatalogItem -AccountName $accountName -ItemType Procedure -Path "$databaseName.dbo.$procName"
		Assert-NotNull $specificItem "Could not retrieve the procedure by name"
		Assert-AreEqual $procName $specificItem.Name

		# retrieve the list of views and ensure the created view is in it
		$itemList = Get-AdlCatalogItem -AccountName $accountName -ItemType View -Path "$databaseName.dbo"

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

		# get views in database only (no schema)
		$itemList = Get-AdlCatalogItem -AccountName $accountName -ItemType View -Path "$databaseName"

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
		$specificItem = Get-AdlCatalogItem -AccountName $accountName -ItemType View -Path "$databaseName.dbo.$viewName"
		Assert-NotNull $specificItem "Could not retrieve the view by name"
		Assert-AreEqual $viewName $specificItem.Name

		# create the secret
		$pw = ConvertTo-SecureString -String $secretPwd -AsPlainText -Force
		$secret = New-Object System.Management.Automation.PSCredential($secretName,$pw)
		$secretName2 = $secretName + "dup"
		$secret2 = New-Object System.Management.Automation.PSCredential($secretName2,$pw)

		New-AdlCatalogSecret -AccountName $accountName -secret $secret -DatabaseName $databaseName -Uri "https://pstest.contoso.com:443"
		New-AdlCatalogSecret -AccountName $accountName -secret $secret2 -DatabaseName $databaseName -Uri "https://pstest.contoso.com:443"

		# verify that the secret can be retrieved
		# NOTE: Secret CRUD is deprecated and will be removed soon.
		# Credential creation through jobs has already been completely removed, so secret CRUD will be removed soon.
		$getSecret = Get-AdlCatalogItem -AccountName $accountName -ItemType Secret -Path "$databaseName.$secretName"
		Assert-NotNull $getSecret "Could not retrieve the secret"
    
		# Create the credential using the new create credential cmdlet
		New-AdlCatalogCredential -AccountName $accountName -DatabaseName $databaseName -CredentialName $credentialName -Credential $secret -Uri "https://fakedb.contoso.com:443"

		# retrieve the list of credentials and ensure the created credential is in it
		$itemList = Get-AdlCatalogItem -AccountName $accountName -ItemType Credential -Path $databaseName

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
		$specificItem = Get-AdlCatalogItem -AccountName $accountName -ItemType Credential -Path "$databaseName.$credentialName"
		Assert-NotNull $specificItem "Could not retrieve the credential by name"
		Assert-AreEqual $credentialName $specificItem.Name

		# Remove the credential
		Remove-AdlCatalogCredential -AccountName $accountName -DatabaseName $databaseName -Name $credentialName
		
		# Verify that trying to get the credential fails
		Assert-Throws {Get-AdlCatalogItem -AccountName $accountName -ItemType Credential -Path "$databaseName.$credentialName"}

		# recreate the credential to drop with recursive parameters to ensure that it still works.
		New-AdlCatalogCredential -AccountName $accountName -DatabaseName $databaseName -CredentialName $credentialName -Credential $secret -Uri "https://fakedb.contoso.com:443"

		# Remove the credential with recurse
		Remove-AdlCatalogCredential -AccountName $accountName -DatabaseName $databaseName -Name $credentialName -Recurse -Force
		
		# Verify that trying to get the credential fails
		Assert-Throws {Get-AdlCatalogItem -AccountName $accountName -ItemType Credential -Path "$databaseName.$credentialName"}

		# delete the secret
		Remove-AdlCatalogSecret -AccountName $accountName -Name $secretName -DatabaseName $databaseName -Force

		# verify that the secret cannot be retrieved
		Assert-Throws {Get-AdlCatalogItem -AccountName $accountName -ItemType Secret -Path "$databaseName.$secretName"}

		# delete all secrets
		Remove-AdlCatalogSecret -AccountName $accountName -DatabaseName $databaseName -Force

		# verify that the second secret cannot be retrieved
		Assert-Throws {Get-AdlCatalogItem -AccountName $accountName -ItemType Secret -Path "$databaseName.$secretName2"}

		# Delete the DataLakeAnalytics account
		Assert-True {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $dataLakeAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}