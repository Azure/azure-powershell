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

    # Delete the DataLakeAnalytics account
    Assert-True {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

	# Verify that it is gone by trying to get it again
	Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName}
}