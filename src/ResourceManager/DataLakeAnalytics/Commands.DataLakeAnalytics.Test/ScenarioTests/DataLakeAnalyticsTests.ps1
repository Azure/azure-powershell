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
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
		[array]$accountGet = Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
        if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
        {
            Assert-AreEqual $accountName $accountGet[0].Name
            Assert-AreEqual $location $accountGet[0].Location
            Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
            Assert-AreEqual $resourceGroupName $accountGet[0].ResourceGroupName
            break
        }

		Write-Host "account not yet provisioned. current state: $($accountGet[0].Properties.ProvisioningState)"

        Assert-False {$i -eq 60} "dataLakeAnalytics account is not in succeeded state even after 30 min."
    }

    # Updating Account
	$tagsToUpdate = @{"TestTag"="TestUpdate"}
    $accountUpdated = Set-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Tags $tagsToUpdate
    
    Assert-AreEqual $accountName $accountUpdated.Name
    Assert-AreEqual $location $accountUpdated.Location
    Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountUpdated.Type
    Assert-AreEqual $resourceGroupName $accountUpdated.ResourceGroupName
	
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
            Assert-AreEqual $resourceGroupName $accountsInResourceGroup[$i].ResourceGroupName

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
            Assert-AreEqual $resourceGroupName $accountsInSubscription[$i].ResourceGroupName
    
            break
        }
    }
    Assert-True {$found -eq 1} "Account created earlier is not found when listing all in subscription."

    # Delete dataLakeAnalytics account
    Assert-True {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

	# Verify that it is gone by trying to get it again
	Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName} "Remove account failed. It can still be retrieved"
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
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
		[array]$accountGet = Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
        if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
        {
            Assert-AreEqual $accountName $accountGet[0].Name
            Assert-AreEqual $location $accountGet[0].Location
            Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
            Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
            break
        }
        Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
    }

    # For now, all Job related tests just ensure that they have a valid response and do not throw.

	# create the properties
	$sqlipProperties = New-AzureRmDataLakeAnalyticsSqlipJobProperties -Script "My fake test script"
	$jobInfo = Submit-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName -Name "TestJob" -Properties $sqlipProperties
	Assert-NotNull {$jobInfo}

	# "cancel" the fake job right away
	Assert-NotNull {Stop-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobIdentity $jobInfo.Id}

	# Get the specific job, and the list of all jobs in the resource group
	Assert-NotNull {Get-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobIdentity $jobInfo.Id}
	Assert-NotNull {Get-AzureRmDataLakeAnalyticsJob -ResourceGroupName $resourceGroupName -AccountName $accountName}

	# Get debug data associated with the job
	Assert-NotNull {Get-AzureRmDataLakeAnalyticsJobDebugInfo -ResourceGroupName $resourceGroupName -AccountName $accountName -JobIdentity $jobInfo.Id}

    # Delete the DataLakeAnalytics account
    Assert-True {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

	# Verify that it is gone by trying to get it again
	Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName} "Remove account failed. It can still be retrieved"
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
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
		[array]$accountGet = Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
        if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
        {
            Assert-AreEqual $accountName $accountGet[0].Name
            Assert-AreEqual $location $accountGet[0].Location
            Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
            Assert-AreEqual $resourceGroupName $accountGet[0].ResourceGroupName
            break
        }
        Assert-False {$i -eq 60} "dataLakeAnalytics accounts not in succeeded state even after 30 min."
    }

    # attempt to recreate the already created account
	Assert-Throws {New-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DefaultDataLakeStore $dataLakeAccountName}

	# attempt to update a non-existent account
	$tagsToUpdate = @{"TestTag"="TestUpdate"}
    Assert-Throws {Set-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $fakeaccountName -Tags $tagsToUpdate}

	# attempt to get a non-existent account
	Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $fakeaccountName}

    # Delete dataLakeAnalytics account
    Assert-True {Remove-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

	# Verify that it is gone by trying to get it again
	Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName} "Remove account failed. It can still be retrieved"
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
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
		[array]$accountGet = Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName
        if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
        {
            Assert-AreEqual $accountName $accountGet[0].Name
            Assert-AreEqual $location $accountGet[0].Location
            Assert-AreEqual "Microsoft.DataLakeAnalytics/accounts" $accountGet[0].Type
            Assert-AreEqual $resourceGroupName $accountGet[0].ResourceGroupName
            break
        }
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
	Assert-Throws {Get-AzureRmDataLakeAnalyticsAccount -ResourceGroupName $resourceGroupName -Name $accountName} "Remove account failed. It can still be retrieved"
}