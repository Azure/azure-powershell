<#
.SYNOPSIS
Tests DataLakeStore Account Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-DataLakeStoreAccount
{
    param
	(
		$resourceGroupName,
		$accountName,
		$location = "West US"
	)
	
    # Creating Account
    $accountCreated = New-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location
    
    Assert-AreEqual $accountName $accountCreated.Name
    Assert-AreEqual $location $accountCreated.Location
    Assert-AreEqual "Microsoft.DataLakeStore/dataLakeAccounts" $accountCreated.Type
    Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

    # In loop to check if account exists
    for ($i = 0; $i -le 60; $i++)
    {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
		[array]$accountGet = Get-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName
        if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
        {
            Assert-AreEqual $accountName $accountGet[0].Name
            Assert-AreEqual $location $accountGet[0].Location
            Assert-AreEqual "Microsoft.DataLakeStore/dataLakeAccounts" $accountGet[0].Type
            Assert-AreEqual $resourceGroupName $accountGet[0].ResourceGroupName
            break
        }

		Write-Host "account not yet provisioned. current state: $($accountGet[0].Properties.ProvisioningState)"

        Assert-False {$i -eq 60} "dataLake account is not in succeeded state even after 30 min."
    }

    # Updating Account
	$tagsToUpdate = @{"TestTag"="TestUpdate"}
    $accountUpdated = Set-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Tags $tagsToUpdate
    
    Assert-AreEqual $accountName $accountUpdated.Name
    Assert-AreEqual $location $accountUpdated.Location
    Assert-AreEqual "Microsoft.DataLakeStore/dataLakeAccounts" $accountUpdated.Type
    Assert-AreEqual $resourceGroupName $accountUpdated.ResourceGroupName
	
    Assert-NotNull $accountUpdated.Tags "Tags do not exists"
	Assert-NotNull $accountUpdated.Tags["TestTag"] "The updated tag 'TestTag' does not exist"

    # List all accounts in resource group
    [array]$accountsInResourceGroup = Get-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName
    Assert-True {$accountsInResourceGroup.Count -ge 1}
    
    $found = 0
    for ($i = 0; $i -lt $accountsInResourceGroup.Count; $i++)
    {
        if ($accountsInResourceGroup[$i].Name -eq $accountName)
        {
            $found = 1
            Assert-AreEqual $location $accountsInResourceGroup[$i].Location
            Assert-AreEqual "Microsoft.DataLakeStore/dataLakeAccounts" $accountsInResourceGroup[$i].Type
            Assert-AreEqual $resourceGroupName $accountsInResourceGroup[$i].ResourceGroupName

            break
        }
    }
    Assert-True {$found -eq 1} "Account created earlier is not found when listing all in resource group: $resourceGroupName."

    # List all dataLake accounts in subscription
    [array]$accountsInSubscription = Get-AzureDataLakeStoreAccount
    Assert-True {$accountsInSubscription.Count -ge 1}
    Assert-True {$accountsInSubscription.Count -ge $accountsInResourceGroup.Count}
    
    $found = 0
    for ($i = 0; $i -lt $accountsInSubscription.Count; $i++)
    {
        if ($accountsInSubscription[$i].Name -eq $accountName)
        {
            $found = 1
            Assert-AreEqual $location $accountsInSubscription[$i].Location
            Assert-AreEqual "Microsoft.DataLakeStore/dataLakeAccounts" $accountsInSubscription[$i].Type
            Assert-AreEqual $resourceGroupName $accountsInSubscription[$i].ResourceGroupName
    
            break
        }
    }
    Assert-True {$found -eq 1} "Account created earlier is not found when listing all in subscription."

    # Delete dataLake account
    Assert-True {Remove-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

	# Verify that it is gone by trying to get it again
	Assert-Throws {Get-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName} "Remove account failed. It can still be retrieved"
}

<#
.SYNOPSIS
Tests DataLakeStore Account Lifecycle Failure scenarios (Create, Update, Get, Delete).
#>
function Test-NegativeDataLakeStoreAccount
{
    param
	(
		$resourceGroupName,
		$accountName,
		$location = "West US",
		$fakeaccountName = "psfakedataLakeaccounttest"
	)
	
    # Creating Account
    $accountCreated = New-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location
    
    Assert-AreEqual $accountName $accountCreated.Name
    Assert-AreEqual $location $accountCreated.Location
    Assert-AreEqual "Microsoft.DataLakeStore/dataLakeAccounts" $accountCreated.Type
    Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

    # In loop to check if account exists
    for ($i = 0; $i -le 60; $i++)
    {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
		[array]$accountGet = Get-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName
        if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
        {
            Assert-AreEqual $accountName $accountGet[0].Name
            Assert-AreEqual $location $accountGet[0].Location
            Assert-AreEqual "Microsoft.DataLakeStore/dataLakeAccounts" $accountGet[0].Type
            Assert-AreEqual $resourceGroupName $accountGet[0].ResourceGroupName
            break
        }
        Assert-False {$i -eq 60} "dataLake accounts not in succeeded state even after 30 min."
    }

    # attempt to recreate the already created account
	Assert-Throws {New-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location}

	# attempt to update a non-existent account
	$tagsToUpdate = @{"TestTag"="TestUpdate"}
    Assert-Throws {Set-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $fakeaccountName -Tags $tagsToUpdate}

	# attempt to get a non-existent account
	Assert-Throws {Get-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $fakeaccountName}

    # Delete dataLake account
    Assert-True {Remove-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

	# Verify that it is gone by trying to get it again
	Assert-Throws {Get-AzureDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName} "Remove account failed. It can still be retrieved"
}