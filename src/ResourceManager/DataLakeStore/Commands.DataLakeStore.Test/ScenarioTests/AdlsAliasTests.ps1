<#
.SYNOPSIS
Tests DataLakeStore Account Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-DataLakeStoreAccount
{
    param
	(
		$location = "West US"
	)
	
	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		# Test to make sure the account doesn't exist
		Assert-False {Test-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-False {Test-AdlStore -Name $accountName}

		$accountCreated = New-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Location $location
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].Properties.ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Store account is not in succeeded state even after 30 min."
		}

		# Test to make sure the account does exist
		Assert-True {Test-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-True {Test-AdlStore -Name $accountName}

		# Updating Account
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		$accountUpdated = Set-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Tags $tagsToUpdate
    
		Assert-AreEqual $accountName $accountUpdated.Name
		Assert-AreEqual $location $accountUpdated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountUpdated.Type
		Assert-True {$accountUpdated.Id -like "*$resourceGroupName*"}
	
		Assert-NotNull $accountUpdated.Tags "Tags do not exists"
		Assert-NotNull $accountUpdated.Tags["TestTag"] "The updated tag 'TestTag' does not exist"

		# List all accounts in resource group
		[array]$accountsInResourceGroup = Get-AdlStore -ResourceGroupName $resourceGroupName
		Assert-True {$accountsInResourceGroup.Count -ge 1}
    
		$found = 0
		for ($i = 0; $i -lt $accountsInResourceGroup.Count; $i++)
		{
			if ($accountsInResourceGroup[$i].Name -eq $accountName)
			{
				$found = 1
				Assert-AreEqual $location $accountsInResourceGroup[$i].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountsInResourceGroup[$i].Type
				Assert-True {$accountsInResourceGroup[$i].Id -like "*$resourceGroupName*"}

				break
			}
		}
		Assert-True {$found -eq 1} "Account created earlier is not found when listing all in resource group: $resourceGroupName."

		# List all Data Lake accounts in subscription
		[array]$accountsInSubscription = Get-AdlStore
		Assert-True {$accountsInSubscription.Count -ge 1}
		Assert-True {$accountsInSubscription.Count -ge $accountsInResourceGroup.Count}
    
		$found = 0
		for ($i = 0; $i -lt $accountsInSubscription.Count; $i++)
		{
			if ($accountsInSubscription[$i].Name -eq $accountName)
			{
				$found = 1
				Assert-AreEqual $location $accountsInSubscription[$i].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountsInSubscription[$i].Type
				Assert-True {$accountsInSubscription[$i].Id -like "*$resourceGroupName*"}
    
				break
			}
		}
		Assert-True {$found -eq 1} "Account created earlier is not found when listing all in subscription."

		# Delete Data Lake account
		Assert-True {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

function Test-DataLakeStoreFileSystem
{
	param
	(
		$fileToCopy,
		$location = "West US"
	)

	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
		$accountCreated = New-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Location $location
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].Properties.ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Store account is not in succeeded state even after 30 min."
		}

		# define all the files and folders to create
		$folderToCreate = "/adlspstestfolder"
		$emptyFilePath = "$folderToCreate\emptyfile.txt" # have one where the slash is in the wrong direction to make sure they get fixed.
		$contentFilePath = "$folderToCreate/contentfile.txt"
		$concatFile = "$folderToCreate/concatfile.txt"
		$moveFile = "$folderToCreate/movefile.txt"
		$movefolder = "/adlspstestmovefolder"
		$importFile = "$folderToCreate/importfile.txt"
		$content = "Test file content! @ Azure PsTest01?"
	

		# Create and get Empty folder
		$result = New-AdlStoreItem -Account $accountName -path $folderToCreate -Folder
		Assert-NotNull $result "No value was returned on folder creation"
		$result = Get-AdlStoreItem -Account $accountName -path $folderToCreate
		Assert-NotNull $result "No value was returned on folder get"
		Assert-AreEqual "Directory" $result.Type
		# Create and get Empty File
		$result = New-AdlStoreItem -Account $accountName -path $emptyFilePath
		Assert-NotNull $result "No value was returned on empty file creation"
		$result = Get-AdlStoreItem -Account $accountName -path $emptyFilePath
		Assert-NotNull $result "No value was returned on empty file get"
		Assert-AreEqual "File" $result.Type
		Assert-AreEqual 0 $result.Length
		# Create and get file with content
		$result = New-AdlStoreItem -Account $accountName -path $contentFilePath -Value $content
		Assert-NotNull $result "No value was returned on content file creation"
		$result = Get-AdlStoreItem -Account $accountName -path $contentFilePath
		Assert-NotNull $result "No value was returned on content file get"
		Assert-AreEqual "File" $result.Type
		Assert-AreEqual $content.length $result.Length
		# list files
		$result = Get-AdlStoreChildItem -Account $accountName -path $folderToCreate
		Assert-NotNull $result "No value was returned on folder list"
		Assert-AreEqual 2 $result.length
		# add content to empty file
		Add-AdlStoreItemContent -Account $accountName -Path $emptyFilePath -Value $content
		$result = Get-AdlStoreItem -Account $accountName -path $emptyFilePath
		Assert-NotNull $result "No value was returned on empty file get with content added"
		Assert-AreEqual "File" $result.Type
		Assert-AreEqual $content.length $result.Length
		# concat files
		$result = Join-AdlStoreItem -Account $accountName -Paths $emptyFilePath,$contentFilePath -Destination $concatFile
		Assert-NotNull $result "No value was returned on concat file"
		$result = Get-AdlStoreItem -Account $accountName -path $concatFile
		Assert-NotNull $result "No value was returned on concat file get"
		Assert-AreEqual "File" $result.Type
		Assert-AreEqual $($content.length*2) $result.Length
	
		# Preview content from the file
		$previewContent = Get-AdlStoreItemContent -Account $accountName -Path $concatFile
		Assert-AreEqual $($content.length*2) $previewContent.Length

		# Preview a subset of the content
		$previewContent = Get-AdlStoreItemContent -Account $accountName -Path $concatFile -Offset 2
		Assert-AreEqual $(($content.length*2) - 2) $previewContent.Length

		# Preview a subset with a specific length
		$previewContent = Get-AdlStoreItemContent -Account $accountName -Path $concatFile -Offset 2 -Length $content.Length
		Assert-AreEqual $content.length $previewContent.Length

		# Import and get file
		$localFileInfo = Get-ChildItem $fileToCopy
		$result = Import-AdlStoreItem -Account $accountName -Path $fileToCopy -Destination $importFile
		Assert-NotNull $result "No value was returned on import file"
		$result = Get-AdlStoreItem -Account $accountName -path $importFile
		Assert-NotNull $result "No value was returned on import file get"
		Assert-AreEqual "File" $result.Type
		Assert-AreEqual $localFileInfo.length $result.Length
		# download file
		$currentDir = Split-Path $fileToCopy
		$targetFile = Join-Path $currentDir "adlspstestdownload.txt"
		if(Test-Path $targetFile)
		{
			Remove-Item -path $targetFile -force -confirm:$false
		}

		Export-AdlStoreItem -Account $accountName -Path $concatFile -Destination $targetFile
		$downloadedFileInfo = Get-ChildItem $targetFile
		Assert-AreEqual $($content.length*2) $downloadedFileInfo.length
		Remove-Item -path $targetFile -force -confirm:$false

		# move a file
		$result = Move-AdlStoreItem -Account $accountName -Path $concatFile -Destination $moveFile
		Assert-NotNull $result "No value was returned on move file"
		$result = Get-AdlStoreItem -Account $accountName -path $moveFile
		Assert-NotNull $result "No value was returned on move file get"
		Assert-AreEqual "File" $result.Type
		Assert-AreEqual $($content.length*2) $result.Length
		Assert-Throws {Get-AdlStoreItem -Account $accountName -path $concatFile}
		# move a folder
		$result = Move-AdlStoreItem -Account $accountName -Path $folderToCreate -Destination $moveFolder
		Assert-NotNull $result "No value was returned on move folder"
		$result = Get-AdlStoreItem -Account $accountName -path $moveFolder
		Assert-NotNull $result "No value was returned on move folder get"
		Assert-AreEqual "Directory" $result.Type
		Assert-AreEqual 0 $result.Length
		Assert-Throws {Get-AdlStoreItem -Account $accountName -path $folderToCreate}
		# delete a file
		Assert-True {Remove-AdlStoreItem -Account $accountName -paths "$moveFolder/movefile.txt" -force -passthru } "Remove File Failed"
		Assert-Throws {Get-AdlStoreItem -Account $accountName -path $moveFile}
		# delete a folder
		Assert-True {Remove-AdlStoreItem -Account $accountName -paths $moveFolder -force -recurse -passthru} "Remove folder failed"
		Assert-Throws {Get-AdlStoreItem -Account $accountName -path $moveFolder}
    
		# Delete Data Lake account
		Assert-True {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

function Test-DataLakeStoreFileSystemPermissions
{
	param
	(
		$location = "West US"
	)

	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
		$accountCreated = New-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Location $location
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].Properties.ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Store account is not in succeeded state even after 30 min."
		}

		# define the permissions to add/remove
		$aceUserId = "027c28d5-c91d-49f0-98c5-d10134b169b3"

		# Set and get all the permissions
		$result = Get-AdlStoreItemAcl -Account $accountName -path "/"
		Assert-NotNull $result "Did not get any result from ACL get" 
		Assert-True {$result.UserAces.count -ge 0} "UserAces is negative or null"
		$currentCount = $result.UserAces.Count
		
		# use the new cmdlet and ensure the count is the same or large than the old count
		Assert-True {(Get-AdlStoreItemAclEntry -Account $accountName -path "/").Count -ge $result.UserAces.Count} "Get-AdlStoreItemAclEntry returned fewer results than Get-AdlStoreItemAcl"

		$result.UserAces.Add($aceUserId, "rwx") 
		Set-AdlStoreItemAcl -Account $accountName -path "/" -Acl $result
		$result = Get-AdlStoreItemAcl -Account $accountName -path "/"
		Assert-AreEqual $($currentCount+1) $result.UserACes.Count
		$result.UserAces.Remove($aceUserId)
		# remove the account
		Set-AdlStoreItemAcl -Account $accountName -path "/" -Acl $result
		$result = Get-AdlStoreItemAcl -Account $accountName -path "/"
		Assert-AreEqual $currentCount $result.UserAces.Count

		# Set and get a specific permission with friendly sets
		Set-AdlStoreItemAclEntry -Account $accountName -path "/" -AceType User -Id $aceUserId -Permissions All
		$result = Get-AdlStoreItemAcl -Account $accountName -path "/"
		Assert-AreEqual $($currentCount+1) $result.UserAces.Count
		# remove a specific permission with friendly remove
		Remove-AdlStoreItemAclEntry -Account $accountName -path "/" -AceType User -Id $aceUserId
		$result = Get-AdlStoreItemAcl -Account $accountName -path "/"
		Assert-AreEqual $currentCount $result.UserAces.Count
		# set and get a specific permission with the ACE string
		Set-AdlStoreItemAclEntry -Account $accountName -path "/" -Acl $([string]::Format("user:{0}:rwx", $aceUserId))
		$result = Get-AdlStoreItemAcl -Account $accountName -path "/"
		Assert-AreEqual $($currentCount+1) $result.UserAces.Count
		# remove a specific permission with the ACE string
		Remove-AdlStoreItemAclEntry -Account $accountName -path "/" -Acl $([string]::Format("user:{0}:---", $aceUserId))
		$result = Get-AdlStoreItemAcl -Account $accountName -path "/"
		Assert-AreEqual $currentCount $result.UserAces.Count

		# Validate full ACL removal
		Remove-AdlStoreItemAcl -Account $accountName -Path "/" -Force -Default
		$result = Get-AdlStoreItemAclEntry -Account $accountName -path "/"
		Assert-AreEqual 4 $result.Count
		Remove-AdlStoreItemAcl -Account $accountName -Path "/" -Force
		$result = Get-AdlStoreItemAclEntry -Account $accountName -path "/"
		Assert-AreEqual 3 $result.Count

		# validate permissions
		$permission = Get-AdlStoreItemPermission -Account $accountName -path "/"
		Assert-AreEqual 770 $permission
		Set-AdlStoreItemPermission -Account $accountName -path "/" -Permission 777 | Out-Null
		$permission = Get-AdlStoreItemPermission -Account $accountName -path "/"
		Assert-AreEqual 777 $permission

		# Delete Data Lake account
		Assert-True {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests DataLakeStore Account Lifecycle Failure scenarios (Create, Update, Get, Delete).
#>
function Test-NegativeDataLakeStoreAccount
{
    param
	(
		$location = "West US",
		$fakeaccountName = "psfakedataLakeaccounttest"
	)
	
	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
		$accountCreated = New-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Location $location
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
        
			[array]$accountGet = Get-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].Properties.ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].Properties.ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Store account not in succeeded state even after 30 min."
		}

		# attempt to recreate the already created account
		Assert-Throws {New-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Location $location}

		# attempt to update a non-existent account
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		Assert-Throws {Set-AdlStore -ResourceGroupName $resourceGroupName -Name $fakeaccountName -Tags $tagsToUpdate}

		# attempt to get a non-existent account
		Assert-Throws {Get-AdlStore -ResourceGroupName $resourceGroupName -Name $fakeaccountName}

		# Delete Data Lake account
		Assert-True {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Delete Data Lake account again should throw.
		Assert-Throws {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru}

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AdlStore -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}