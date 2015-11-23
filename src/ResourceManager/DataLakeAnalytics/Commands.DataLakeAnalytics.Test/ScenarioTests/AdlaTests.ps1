<#
.SYNOPSIS
Tests DataLakeAnalytics Account Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-DataLakeAnalyticsAccount
{
    param
	(
		$resourceGroupName,
		$accountName,
		$dataLakeAccountName,
		$secondDataLakeAccountName,
		$blobAccountName,
		$blobAccountKey,
		$location = "East US 2"
	)
    
    # Creating Account
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
		[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
        Assert-False {$i -eq 60} "dataLakeAnalytics account is not in succeeded state even after 30 min."
    }

    # Updating Account
	$tagsToUpdate = @{"Name" = "TestTag"; "Value" = "TestUpdate"}
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


<#
.SYNOPSIS
Tests DataLakeAnalytics Job Lifecycle (Submit, Get, List, Cancel and Get Debug data).
#>
function Test-DataLakeAnalyticsJob
{
    param
	(
		$resourceGroupName,
		$accountName,
		$dataLakeAccountName,
		$location = "West US"
	)
	
    # Creating Account
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
		[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
        Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
    }

    # For now, all Job related tests just ensure that they have a valid response and do not throw.
	# Wait for two minutes prior to attempting to submit the job in the freshly created account.
	[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(120000)
	# submit a job
	$jobInfo = Submit-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName -Name "TestJob" -Script "DROP DATABASE IF EXISTS foo; CREATE DATABASE foo;"
	Assert-NotNull {$jobInfo}

	# "cancel" the fake job right away
	Stop-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobId $jobInfo.JobId -Force
	$cancelledJob = Get-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobId $jobInfo.JobId

	# Get the specific job, and the list of all jobs in the resource group
	Assert-NotNull {$cancelledJob}
	
	# Verify the job was actually cancelled.
	Assert-True {$cancelledJob.Result -like "*Cancel*"}

	Assert-NotNull {Get-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName}

	$jobsWithDateOffset = Get-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName -SubmittedAfter $(([DateTime]::Now).AddMinutes(-5))

	Assert-True {$jobsWithDateOffset.Count -gt 0} "Failed to retrieve jobs submitted after five miuntes ago"

	$jobsWithDateOffset = Get-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName -SubmittedBefore $(([DateTime]::Now).AddMinutes(0))

	Assert-True {$jobsWithDateOffset.Count -gt 0} "Failed to retrieve jobs submitted before right now"

    # Delete the DataLakeAnalytics account
    Assert-True {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

	# Verify that it is gone by trying to get it again
	Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
}


<#
.SYNOPSIS
Tests DataLakeAnalytics Account Lifecycle Failure scenarios (Create, Update, Get, Delete).
#>
function Test-NegativeDataLakeAnalyticsAccount
{
    param
	(
		$resourceGroupName,
		$accountName,
		$location = "West US",
		$dataLakeAccountName,
		$fakeaccountName = "psfakedataLakeAnalyticsaccounttest"
	)
	
    # Creating Account
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
		[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
        Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
    }

    # attempt to recreate the already created account
	Assert-Throws {New-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName}

	# attempt to update a non-existent account
	$tagsToUpdate = @{"Name" = "TestTag"; "Value" = "TestUpdate"}
    Assert-Throws {Set-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $fakeaccountName -Tags $tagsToUpdate}

	# attempt to get a non-existent account
	Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $fakeaccountName}

    # Delete dataLakeAnalytics account
    Assert-True {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

	# Verify that it is gone by trying to get it again
	Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
}


<#
.SYNOPSIS
Tests DataLakeAnalytics Job Lifecycle (Get, Cancel and Get Debug data).
#>
function Test-NegativeDataLakeAnalyticsJob
{
   param
	(
		$resourceGroupName,
		$accountName,
		$dataLakeAccountName,
		$location = "West US"
	)
	
    # Creating Account
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
		[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
        Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
    }

	# attempt to "cancel" a non-existent job
	Assert-Throws {Stop-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobIdentity [Guid]::Empty}

	# Attempt to get a job that doesn't exist
	Assert-Throws {Get-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobIdentity [Guid]::Empty}

	# Attempt to Get debug data for a non-existent job
	Assert-Throws {Get-AzureRmDataLakeAnalyticsJobDebugInfo -ResourceGroupName $resourceGroupName -AccountName $accountName -JobIdentity [Guid]::Empty}

	$jobsWithDateOffset = Get-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName -SubmittedAfter $([DateTime]::Now)

	Assert-True {$jobsWithDateOffset.Count -eq 0} "Retrieval of jobs submitted after right now returned results and should not have"

    # Delete the DataLakeAnalytics account
    Assert-True {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

	# Verify that it is gone by trying to get it again
	Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
}