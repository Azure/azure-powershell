﻿<#
.SYNOPSIS
Tests DataLakeStore Account trusted identity provider Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-DataLakeStoreTrustedIdProvider
{
    param
    (
        $location
    )

    if ([string]::IsNullOrEmpty($location))
    {
        $location = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
    }
	
	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName
		New-AzResourceGroup -Name $resourceGroupName -Location $location

		# Test to make sure the account doesn't exist
		Assert-False {Test-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-False {Test-AzDataLakeStoreAccount -Name $accountName}

		$accountCreated = New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -Encryption ServiceManaged
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Store account is not in succeeded state even after 30 min."
		}

		# Test to make sure the account does exist
		Assert-True {Test-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}

		# Test to ensure/enable trusted id provider states
		Assert-AreEqual "Disabled" $accountCreated.TrustedIdProviderState

		$accountSet = Set-AzDataLakeStoreAccount -Name $accountName -TrustedIdProviderState Enabled
		Assert-AreEqual "Enabled" $accountSet.TrustedIdProviderState

		$trustedIdName = getAssetName
		$trustedIdEndpoint = "https://sts.windows.net/6b04908c-b91f-40ce-8024-7ee8a4fd6150"

		# Add a provider
		Add-AzDataLakeStoreTrustedIdProvider -AccountName $accountName -Name $trustedIdName -ProviderEndpoint $trustedIdEndpoint

		# Get the provider
		$result = Get-AzDataLakeStoreTrustedIdProvider -AccountName $accountName -Name $trustedIdName
		Assert-AreEqual $trustedIdName $result.Name
		Assert-AreEqual $trustedIdEndpoint $result.IdProvider

		# remove the provider
		Remove-AzDataLakeStoreTrustedIdProvider -AccountName $accountName -Name $trustedIdName

		# Make sure get throws.
		Assert-Throws {Get-AzDataLakeStoreTrustedIdProvider -AccountName $accountName -Name $trustedIdName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests DataLakeStore Account firewall rules Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-DataLakeStoreFirewall
{
    param
    (
        $location
    )

    if ([string]::IsNullOrEmpty($location))
    {
        $location = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
    }
	
	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName
		New-AzResourceGroup -Name $resourceGroupName -Location $location

		# Test to make sure the account doesn't exist
		Assert-False {Test-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-False {Test-AzDataLakeStoreAccount -Name $accountName}

		$accountCreated = New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -Encryption ServiceManaged
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Store account is not in succeeded state even after 30 min."
		}

		# Test to make sure the account does exist
		Assert-True {Test-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}

		# Enable the firewall state and azure IPs
		Assert-AreEqual "Disabled" $accountCreated.FirewallState
		
		# TODO: Re-enable this when this property is re-introduced by the service
		# Assert-AreEqual "Disabled" $accountCreated.FirewallAllowAzureIps 

		$accountSet = Set-AzDataLakeStoreAccount -Name $accountName -FirewallState "Enabled" -AllowAzureIpState "Enabled"

		Assert-AreEqual "Enabled" $accountSet.FirewallState
		
		# TODO: Re-enable this when this property is re-introduced by the service
		# Assert-AreEqual "Enabled" $accountSet.FirewallAllowAzureIps

		$firewallRuleName = getAssetName
		$startIp = "127.0.0.1"
		$endIp = "127.0.0.2"
		# Add a firewall rule
		Add-AzDataLakeStoreFirewallRule -AccountName $accountName -Name $firewallRuleName -StartIpAddress $startIp -EndIpAddress $endIp

		# Get the firewall rule
		$result = Get-AzDataLakeStoreFirewallRule -AccountName $accountName -Name $firewallRuleName
		Assert-AreEqual $firewallRuleName $result.Name
		Assert-AreEqual $startIp $result.StartIpAddress
		Assert-AreEqual $endIp $result.EndIpAddress

		# remove the firewall rule
		Remove-AzDataLakeStoreFirewallRule -AccountName $accountName -Name $firewallRuleName

		# Make sure get throws.
		Assert-Throws {Get-AzDataLakeStoreFirewallRule -AccountName $accountName -Name $firewallRuleName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests DataLakeStore Account virtual network rules Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-DataLakeStoreVirtualNetwork
{
    param
    (
        $location
    )

    if ([string]::IsNullOrEmpty($location))
    {
        $location = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
    }

	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName
		New-AzResourceGroup -Name $resourceGroupName -Location $location

		# Test to make sure the account doesn't exist
		Assert-False {Test-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-False {Test-AzDataLakeStoreAccount -Name $accountName}

		$accountCreated = New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -Encryption ServiceManaged

		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Store account is not in succeeded state even after 30 min."
		}

		# Test to make sure the account does exist
		Assert-True {Test-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}

		# Enable the firewall state and azure IPs
		Assert-AreEqual "Disabled" $accountCreated.FirewallState

		$accountSet = Set-AzDataLakeStoreAccount -Name $accountName -FirewallState "Enabled" -AllowAzureIpState "Enabled"

		Assert-AreEqual "Enabled" $accountSet.FirewallState

		$virtualNetworkRuleName = getAssetName

		$vnetName1 = "vnet1"
		$virtualNetwork1 = CreateAndGetVirtualNetwork $resourceGroupName $vnetName1 $location
		$virtualNetworkSubnetId1 = $virtualNetwork1.Subnets[0].Id

		$vnetName2 = "vnet2"
		$virtualNetwork2 = CreateAndGetVirtualNetwork $resourceGroupName $vnetName2 $location
		$virtualNetworkSubnetId2 = $virtualNetwork2.Subnets[0].Id

		# Add a virtual network rule
		Add-AzDataLakeStoreVirtualNetworkRule -Account $accountName -Name $vnetName1 -SubnetId $virtualNetworkSubnetId1

		# Get the virtual network rule
		$result = Get-AzDataLakeStoreVirtualNetworkRule -Account $accountName -Name $vnetName1
		Assert-AreEqual $vnetName1 $result.VirtualNetworkRuleName
		Assert-AreEqual $virtualNetworkSubnetId1 $result.VirtualNetworkSubnetId

		# remove the virtual network rule
		Remove-AzDataLakeStoreVirtualNetworkRule -Account $accountName -Name $vnetName1

		# Make sure get throws.
		Assert-Throws {Get-AzDataLakeStoreVirtualNetworkRule -Account $accountName -Name $vnetName1}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests DataLakeStore Account Commitment tiers (in Create and Update).
#>
function Test-DataLakeStoreAccountTiers
{
    param
    (
        $location
    )

    if ([string]::IsNullOrEmpty($location))
    {
        $location = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
    }
	
	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName
		$secondAccountName = Get-DataLakeStoreAccountName
		New-AzResourceGroup -Name $resourceGroupName -Location $location

		# Test to make sure the account doesn't exist
		Assert-False {Test-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-False {Test-AzDataLakeStoreAccount -Name $accountName}

		# Test 1: create without a tier specified verify that it defaults to "consumption"
		$accountCreated = New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}
		Assert-AreEqual "Consumption" $accountCreated.CurrentTier
		Assert-AreEqual "Consumption" $accountCreated.NewTier

		# Test 2: update this account to use a different tier
		$accountUpdated = Set-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Tier Commitment1TB

		Assert-AreEqual "Consumption" $accountUpdated.CurrentTier
		Assert-AreEqual "Commitment1TB" $accountUpdated.NewTier

		# Test 3: create a new account with a specific tier.
		$accountCreated = New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $secondAccountName -Location $location -Tier Commitment1TB
		
		Assert-AreEqual "Commitment1TB" $accountCreated.CurrentTier
		Assert-AreEqual "Commitment1TB" $accountCreated.NewTier
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $secondAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests DataLakeStore Account Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-DataLakeStoreAccount
{
    param
    (
        $location
    )

    if ([string]::IsNullOrEmpty($location))
    {
        $location = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
    }
	
	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName
		New-AzResourceGroup -Name $resourceGroupName -Location $location

		# Test to make sure the account doesn't exist
		Assert-False {Test-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-False {Test-AzDataLakeStoreAccount -Name $accountName}

		$accountCreated = New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -Encryption ServiceManaged
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				Assert-True {$accountGet[0].Identity -ne $null}
				Assert-True {$accountGet[0].EncryptionConfig -ne $null}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Store account is not in succeeded state even after 30 min."
		}

		# Test to make sure the account does exist
		Assert-True {Test-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}
		# Test it without specifying a resource group
		Assert-True {Test-AzDataLakeStoreAccount -Name $accountName}

		# Updating Account
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		$accountUpdated = Set-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Tag $tagsToUpdate
    
		Assert-AreEqual $accountName $accountUpdated.Name
		Assert-AreEqual $location $accountUpdated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountUpdated.Type
		Assert-True {$accountUpdated.Id -like "*$resourceGroupName*"}
	
		Assert-NotNull $accountUpdated.Tags "Tags do not exists"
		Assert-NotNull $accountUpdated.Tags["TestTag"] "The updated tag 'TestTag' does not exist"

		# List all accounts in resource group
		[array]$accountsInResourceGroup = Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName
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
		[array]$accountsInSubscription = Get-AzDataLakeStoreAccount
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

		# Test creation of a new account without specifying encryption and ensure it is still ServiceManaged.
		$secondAccountName = Get-DataLakeStoreAccountName
		$accountCreated = New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $secondAccountName -Location $location
		Assert-True {$accountCreated.EncryptionConfig -ne $null}
		Assert-AreEqual "ServiceManaged" $accountCreated.EncryptionConfig.Type
		Assert-AreEqual "Enabled" $accountCreated.EncryptionState

		# attempt to enable the key vault, which should throw since it is already enabled
		Assert-Throws {Enable-AzDataLakeStoreKeyVault -ResourceGroupName $resourceGroupName -Account $secondAccountName}
		

		# Create an account with no encryption explicitly.
		$thirdAccountName = Get-DataLakeStoreAccountName
		$accountCreated = New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $thirdAccountName -Location $location -DisableEncryption
		Assert-True {[string]::IsNullOrEmpty(($accountCreated.EncryptionConfig.Type))}
		Assert-AreEqual "Disabled" $accountCreated.EncryptionState

		# Delete Data Lake account
		Assert-True {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $secondAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $thirdAccountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}
<#
.SYNOPSIS
Tests DataLakeStore filesystem operations (Create, append, get, delete, read, etc.).
#>
function Test-DataLakeStoreFileSystem
{
	param
    (
        $fileToCopy,
		$location
    )

    if ([string]::IsNullOrEmpty($location))
    {
        $location = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
    }

	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName
		New-AzResourceGroup -Name $resourceGroupName -Location $location
		$accountCreated = New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DisableEncryption
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Store account is not in succeeded state even after 30 min."
		}

		# define all the files and folders to create
		$encodingFolder="/encodingFolder"
		$folderToCreate = "/adlspstestfolder"
		$emptyFilePath = "$folderToCreate\emptyfile.txt" # have one where the slash is in the wrong direction to make sure they get fixed.
		$contentFilePath = "$folderToCreate/contentfile.txt"
		$unicodeContentFilePath="$encodingFolder/unicodecontentfile.txt"
		$unicodetext="I am unicode text"
		$utf32ContentFilePath="$encodingFolder/utf32contentfile.txt"
		$utf32text="I am utf32 text"
		$concatFile = "$folderToCreate/concatfile.txt"
		$moveFile = "$folderToCreate/movefile.txt"
		$movefolder = "/adlspstestmovefolder"
		$importFile = "$folderToCreate/importfile.txt"
		$content = "Test file content! @ Azure PsTest01?"
		$summaryFolder="/adlspstestsummaryfolder"
		$subFolderToCreate = "$summaryFolder/Folder0"
		$subSubFolderToCreate = "$summaryFolder/Folder0/SubFolder0"
		$subFileToCreate = "$summaryFolder/File0"

		# Create and get Empty folder
		$result = New-AzDataLakeStoreItem -Account $accountName -path $folderToCreate -Folder
		Assert-NotNull $result "No value was returned on folder creation"
		$result = Get-AzDataLakeStoreItem -Account $accountName -path $folderToCreate
		Assert-NotNull $result "No value was returned on folder get"
		Assert-AreEqual "Directory" $result.Type
		
		# Create and get Empty File
		$result = New-AzDataLakeStoreItem -Account $accountName -path $emptyFilePath
		Assert-NotNull $result "No value was returned on empty file creation"
		$result = Get-AzDataLakeStoreItem -Account $accountName -path $emptyFilePath
		$emptyFileCreationDate=$result.LastWriteTime # To be used later
		Assert-NotNull $result "No value was returned on empty file get"
		Assert-AreEqual "File" $result.Type
		Assert-AreEqual 0 $result.Length
		
		# Create and get file with content
		$result = New-AzDataLakeStoreItem -Account $accountName -path $contentFilePath -Value $content
		Assert-NotNull $result "No value was returned on content file creation"
		$result = Get-AzDataLakeStoreItem -Account $accountName -path $contentFilePath
		Assert-NotNull $result "No value was returned on content file get"
		Assert-AreEqual "File" $result.Type
		Assert-AreEqual $content.length $result.Length
		
		#Create empty file and add unicode content
		$result = New-AzDataLakeStoreItem -Account $accountName -path $unicodeContentFilePath
		Assert-NotNull $result "No value was returned on content file creation"
		Add-AzDataLakeStoreItemContent -Account $accountName -Path $unicodeContentFilePath -Value $unicodetext -Encoding Unicode
		$retrievedContent = Get-AzDataLakeStoreItemContent -Account $accountName -Path $unicodeContentFilePath -Encoding Unicode
		Assert-AreEqual $unicodetext $retrievedContent

		#Create utf32 file with content
		$result = New-AzDataLakeStoreItem -Account $accountName -path $utf32ContentFilePath -Value $utf32text -Encoding UTF32
		Assert-NotNull $result "No value was returned on content file creation"
		$retrievedContent = Get-AzDataLakeStoreItemContent -Account $accountName -Path $utf32ContentFilePath -Encoding UTF32
		Assert-AreEqual $utf32text $retrievedContent

		# set absolute expiration for content file
		Assert-True {253402300800000 -ge $result.ExpirationTime -or 0 -le $result.ExpirationTime} # validate that expiration is currently max value
		[DateTimeOffset]$timeToUse = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("absoluteTime", [DateTimeOffset]::UtcNow.AddSeconds(120))
		$result = Set-AdlStoreItemExpiry -Account $accountName -path $contentFilePath -Expiration $timeToUse
		Assert-NumAreInRange $timeToUse.UtcTicks $result.Expiration.UtcTicks 5000000 # range of 50 milliseconds
		
		# set it back to "never expire"
		$result = Set-AdlStoreItemExpiry -Account $accountName -path $contentFilePath
		Assert-True {253402300800000 -ge $result.ExpirationTime -or 0 -le $result.ExpirationTime} # validate that expiration is currently max value
		
		# list files
		$result = Get-AzDataLakeStoreChildItem -Account $accountName -path $folderToCreate
		Assert-NotNull $result "No value was returned on folder list"
		Assert-AreEqual 2 $result.length
		
		# add content to empty file
		Add-AzDataLakeStoreItemContent -Account $accountName -Path $emptyFilePath -Value $content
		$result = Get-AzDataLakeStoreItem -Account $accountName -path $emptyFilePath
		Assert-NotNull $result "No value was returned on empty file get with content added"
		Assert-AreEqual "File" $result.Type
		Assert-AreEqual $content.length $result.Length
		
		# concat files
		$result = Join-AzDataLakeStoreItem -Account $accountName -Paths $emptyFilePath,$contentFilePath -Destination $concatFile
		Assert-NotNull $result "No value was returned on concat file"
		$result = Get-AzDataLakeStoreItem -Account $accountName -path $concatFile
		Assert-NotNull $result "No value was returned on concat file get"
		Assert-AreEqual "File" $result.Type
		Assert-AreEqual $($content.length*2) $result.Length
	
		# Preview content from the file
		$previewContent = Get-AzDataLakeStoreItemContent -Account $accountName -Path $concatFile
		Assert-AreEqual $($content.length*2) $previewContent.Length

		# Preview a subset of the content
		$previewContent = Get-AzDataLakeStoreItemContent -Account $accountName -Path $concatFile -Offset 2
		Assert-AreEqual $(($content.length*2) - 2) $previewContent.Length

		# Preview a subset with a specific length
		$previewContent = Get-AzDataLakeStoreItemContent -Account $accountName -Path $concatFile -Offset 2 -Length $content.Length
		Assert-AreEqual $content.length $previewContent.Length

		# Create a file with 4 rows and get the top 2 and last 2.
		$previewHeadTailFile = "/headtail/filetest.txt"
		$headTailContent = @"
1
2
3
4
"@
		New-AzDataLakeStoreItem -Account $accountName -Path $previewHeadTailFile -Force -Value $headTailContent
		
		# Get the first two elements
		$headTailResult = Get-AzDataLakeStoreItemContent -Account $accountName -Path $previewHeadTailFile -Head 2
		Assert-AreEqual 2 $headTailResult.Length
		Assert-AreEqual 1 $headTailResult[0]
		Assert-AreEqual 2 $headTailResult[1]

		# get the last two elements
		$headTailResult = Get-AzDataLakeStoreItemContent -Account $accountName -Path $previewHeadTailFile -Tail 2
		Assert-AreEqual 2 $headTailResult.Length
		Assert-AreEqual 3 $headTailResult[0]
		Assert-AreEqual 4 $headTailResult[1]

        #Create a file with byte and read it
        $byteDataFile="/byteData/filetest.txt"
        [byte[]] $byteData = 1,2,3,4,5
        New-AzDataLakeStoreItem -Account $accountName -Path $byteDataFile -Force -Value $byteData -Encoding Byte
        $result = Get-AzDataLakeStoreItemContent -Account $accountName -path $byteDataFile -Encoding Byte
        Assert-True {@(Compare-Object $byteData $result -SyncWindow 0).Length -eq 0}

		# Import and get file
		$localFileInfo = Get-ChildItem $fileToCopy
		$result = Import-AzDataLakeStoreItem -Account $accountName -Path $fileToCopy -Destination $importFile
		Assert-NotNull $result "No value was returned on import file"
		$result = Get-AzDataLakeStoreItem -Account $accountName -path $importFile
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

		Export-AzDataLakeStoreItem -Account $accountName -Path $concatFile -Destination $targetFile
		$downloadedFileInfo = Get-ChildItem $targetFile
		Assert-AreEqual $($content.length*2) $downloadedFileInfo.length
		
		# move a file
		$result = Move-AzDataLakeStoreItem -Account $accountName -Path $concatFile -Destination $moveFile
		Assert-NotNull $result "No value was returned on move file"
		$result = Get-AzDataLakeStoreItem -Account $accountName -path $moveFile
		Assert-NotNull $result "No value was returned on move file get"
		Assert-AreEqual "File" $result.Type
		Assert-AreEqual $($content.length*2) $result.Length
		Assert-Throws {Get-AzDataLakeStoreItem -Account $accountName -path $concatFile}
		
		# move a folder
		$result = Move-AzDataLakeStoreItem -Account $accountName -Path $folderToCreate -Destination $moveFolder
		Assert-NotNull $result "No value was returned on move folder"
		$result = Get-AzDataLakeStoreItem -Account $accountName -path $moveFolder
		Assert-NotNull $result "No value was returned on move folder get"
		Assert-AreEqual "Directory" $result.Type
		Assert-AreEqual 0 $result.Length
		Assert-Throws {Get-AzDataLakeStoreItem -Account $accountName -path $folderToCreate}

		# getcontentsummary
		$result = New-AzDataLakeStoreItem -Account $accountName -path $summaryFolder -Folder
		Assert-NotNull $result "No value was returned on folder creation"
		$result = New-AzDataLakeStoreItem -Account $accountName -path $subFolderToCreate -Folder
		Assert-NotNull $result "No value was returned on folder creation"
		$result = New-AzDataLakeStoreItem -Account $accountName -path $subSubFolderToCreate -Folder
		Assert-NotNull $result "No value was returned on folder creation"
		New-AzDataLakeStoreItem -Account $accountName -Path $subFileToCreate -Force -Value $content
		$result = Get-AzDataLakeStoreChildItemSummary -Account $accountName -Path $summaryFolder
		Assert-AreEqual $result.Length $content.Length
		# Files will be the test file and the above moved file
		Assert-AreEqual $result.FileCount 1

		# Export DiskUsage
		#$targetFile = Join-Path $currentDir "DuOutputAdls"
		#Export-AzDataLakeStoreChildItemProperties -Account $accountName -Path $summaryFolder -OutputPath $targetFile -GetDiskUsage -IncludeFile
		#$result = Get-Item -Path $targetFile
		#Assert-NotNull $result "No file was created on export properties"
        #Remove-Item -Path $targetFile

		# delete a file
		Assert-True {Remove-AdlStoreItem -Account $accountName -paths "$moveFolder/movefile.txt" -force -passthru } "Remove File Failed"
		Assert-Throws {Get-AdlStoreItem -Account $accountName -path $moveFile}
		
		# delete a folder
		Assert-True {Remove-AzDataLakeStoreItem -Account $accountName -paths $moveFolder -force -recurse -passthru} "Remove folder failed"
		Assert-Throws {Get-AzDataLakeStoreItem -Account $accountName -path $moveFolder}
		Assert-True {Remove-AzDataLakeStoreItem -Account $accountName -paths $summaryFolder -force -recurse -passthru} "Remove folder failed"
		Assert-Throws {Get-AzDataLakeStoreItem -Account $accountName -path $summaryFolder}
		Assert-True {Remove-AzDataLakeStoreItem -Account $accountName -paths $encodingFolder -force -recurse -passthru} "Remove folder failed"
    
		# Delete Data Lake account
		Assert-True {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests DataLakeStore filesystem permissions operations (Create, Update, Get, List, Delete).
#>
function Test-DataLakeStoreFileSystemPermissions
{
	param
    (
        $location
    )

    if ([string]::IsNullOrEmpty($location))
    {
        $location = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
    }

	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName
		New-AzResourceGroup -Name $resourceGroupName -Location $location
		$accountCreated = New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location -DisableEncryption
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Store account is not in succeeded state even after 30 min."
		}

		#define folder name to create for recursive Acl
		$folderToCreate = "/aclRecurseFolder"

		# define the permissions to add/remove
		$aceUserId = "027c28d5-c91d-49f0-98c5-d10134b169b3"

		#set owner
        New-AdlStoreItem -Account $accountName -Path "/temp"
        $prevOwner=Get-AdlStoreItemOwner -Account $accountName -Path "/temp" -Type User
        $prevGroup=Get-AdlStoreItemOwner -Account $accountName -Path "/temp" -Type Group
        $currentOwner=Set-AdlStoreItemOwner -Account $accountName -Path "/temp" -Type User -Id $aceUserId -PassThru
        $currentGroup=Get-AdlStoreItemOwner -Account $accountName -Path "/temp" -Type Group
        Assert-AreEqual $aceUserId $currentOwner
        Assert-AreNotEqual $prevOwner $currentOwner
        Assert-AreEqual $prevGroup $currentGroup
        Remove-AdlStoreItem -Account $accountName -paths "/temp" -force

		# Set and get all the permissions
		$result = Get-AzDataLakeStoreItemAclEntry -Account $accountName -path "/"
		Assert-NotNull $result "Did not get any result from ACL get" 
		Assert-True {$result.Count -ge 0} "UserAces is negative or null"
 		$currentCount = $result.Count
 		$result.Add("user:$aceUserId`:rwx")
 		$toRemove = $result[$result.Count -1]
		Assert-AreEqual $aceUserId $toRemove.Id

		Set-AzDataLakeStoreItemAcl -Account $accountName -path "/" -Acl $result
		$result = Get-AzDataLakeStoreItemAclEntry -Account $accountName -path "/"
		
		Assert-AreEqual $($currentCount+1) $result.Count
 		$found = $false
 		for($i = 0; $i -lt $result.Count; $i++)
 		{
 			if($result[$i].Id -like $aceUserId)
 			{
 				$found = $true
 				$result.RemoveAt($i)
 				break
 			}
 		}
 
 		Assert-True { $found } "Failed to remove the element: $($toRemove.Entry)"

		# remove the account
		Set-AzDataLakeStoreItemAcl -Account $accountName -path "/" -Acl $result
		$result = Get-AzDataLakeStoreItemAclEntry -Account $accountName -path "/"

		Assert-AreEqual $($currentCount) $result.Count

		# Set and get a specific permission with friendly sets
		Set-AzDataLakeStoreItemAclEntry -Account $accountName -path "/" -AceType User -Id $aceUserId -Permissions All
		$result = Get-AzDataLakeStoreItemAclEntry -Account $accountName -path "/"
		Assert-AreEqual $($currentCount+1) $result.Count
		
		# remove a specific permission with friendly remove
		Remove-AzDataLakeStoreItemAclEntry -Account $accountName -path "/" -AceType User -Id $aceUserId
		$result = Get-AzDataLakeStoreItemAclEntry -Account $accountName -path "/"
		Assert-AreEqual $($currentCount) $result.Count
		
		# set and get a specific permission with the ACE string
		Set-AzDataLakeStoreItemAclEntry -Account $accountName -path "/" -Acl $([string]::Format("user:{0}:rwx", $aceUserId))
		$result = Get-AzDataLakeStoreItemAclEntry -Account $accountName -path "/"
		Assert-AreEqual $($currentCount+1) $result.Count
		
		# remove a specific permission with the ACE string
		Remove-AzDataLakeStoreItemAclEntry -Account $accountName -path "/" -Acl $([string]::Format("user:{0}:---", $aceUserId))
		$result = Get-AzDataLakeStoreItemAclEntry -Account $accountName -path "/"
		Assert-AreEqual $($currentCount) $result.Count

		# Create file/folder for recursive Acl
		$result = New-AzDataLakeStoreItem -Account $accountName -path $folderToCreate -Folder
		Assert-NotNull $result "No value was returned on folder creation"
		
		#Recursive Acl Modify
		Set-AzDataLakeStoreItemAclEntry -Account $accountName -path "/" -AceType User -Permissions All -Id $aceUserId -Recurse
		$result = Get-AzDataLakeStoreItemAclEntry -Account $accountName -path "/"
		Assert-AreEqual $($currentCount+1) $result.Count

		# Export Acl
		#$targetFile = "./ScenarioTests/acloutput"
		#Export-AzDataLakeStoreChildItemProperties -Account $accountName -Path "/" -OutputPath $targetFile -GetAcl -IncludeFile
        #$result = Get-Item -Path $targetFile
		#Assert-NotNull $result "No file was created on export properties"
        #Remove-Item -Path $targetFile

		#Recursive Acl remove
		Remove-AzDataLakeStoreItemAclEntry -Account $accountName -path "/" -AceType User -Id $aceUserId -Recurse
		$result = Get-AzDataLakeStoreItemAclEntry -Account $accountName -path "/"
		Assert-AreEqual $($currentCount) $result.Count

		# Validate full ACL removal
		Remove-AzDataLakeStoreItemAcl -Account $accountName -Path "/" -Force -Default
		$result = Get-AzDataLakeStoreItemAclEntry -Account $accountName -path "/"
		Assert-AreEqual 4 $result.Count
		Remove-AzDataLakeStoreItemAcl -Account $accountName -Path "/" -Force
		$result = Get-AzDataLakeStoreItemAclEntry -Account $accountName -path "/"
		Assert-AreEqual 3 $result.Count

		# validate permissions
		$permission = Get-AzDataLakeStoreItemPermission -Account $accountName -path "/"
		Assert-AreEqual 770 $permission
		Set-AzDataLakeStoreItemPermission -Account $accountName -path "/" -Permission 777 | Out-Null
		$permission = Get-AzDataLakeStoreItemPermission -Account $accountName -path "/"
		Assert-AreEqual 777 $permission

		# Delete Data Lake account
		Assert-True {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
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
        $location,
		$fakeaccountName = "psfakedataLakeaccounttest"
    )

    if ([string]::IsNullOrEmpty($location))
    {
        $location = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
    }
	
	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName
		New-AzResourceGroup -Name $resourceGroupName -Location $location
		$accountCreated = New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
        
			[array]$accountGet = Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Store account not in succeeded state even after 30 min."
		}

		# attempt to recreate the already created account
		Assert-Throws {New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location}

		# attempt to update a non-existent account
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		Assert-Throws {Set-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $fakeaccountName -Tag $tagsToUpdate}

		# attempt to get a non-existent account
		Assert-Throws {Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $fakeaccountName}

		# Delete Data Lake account
		Assert-True {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Delete Data Lake account again should throw.
		Assert-Throws {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru}

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
	.SYNOPSIS
	Create a virtual network
#>
function CreateAndGetVirtualNetwork ($resourceGroupName, $vnetName, $location = "westcentralus")
{
	$subnetName = "Public"

	$addressPrefix = "10.0.0.0/24"
	$serviceEndpoint = "Microsoft.AzureActiveDirectory"

	$subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix $addressPrefix -ServiceEndpoint $serviceEndpoint
	$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

	$getVnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName

	return $getVnet
}

<#
.SYNOPSIS
Tests DataLakeStore deleted items operations (Enumerate, Restore).
#>
function Test-EnumerateAndRestoreDataLakeStoreDeletedItem
{
	param
    (
        $fileToCopy,
		$location
    )

    if ([string]::IsNullOrEmpty($location))
    {
        $location = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
    }

	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$accountName = Get-DataLakeStoreAccountName + "-c12" # testing accountname validation
		New-AzResourceGroup -Name $resourceGroupName -Location $location
		$accountCreated = New-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location
    
		Assert-AreEqual $accountName $accountCreated.Name
		Assert-AreEqual $location $accountCreated.Location
		Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountCreated.Type
		Assert-True {$accountCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if account exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$accountGet = Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName
			if ($accountGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $accountName $accountGet[0].Name
				Assert-AreEqual $location $accountGet[0].Location
				Assert-AreEqual "Microsoft.DataLakeStore/accounts" $accountGet[0].Type
				Assert-True {$accountGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "account not yet provisioned. current state: $($accountGet[0].ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Data Lake Store account is not in succeeded state even after 30 min."
		}

		# define all the files and folders
		$folderToCreate1 = "/adlfolderTest1"
		$folderToCreate2 = "/adlfolderTest2"
		$fileToCreate1 = "/adlfolderTest1/adlfile1"
		$fileToCreate2 = "/adlfolderTest2/adlfile2"

		# Create and get Empty folder
		$result = New-AzDataLakeStoreItem -Account $accountName -path $folderToCreate1 -Folder
		Assert-NotNull $result "No value was returned on folder creation"

		$result = New-AzDataLakeStoreItem -Account $accountName -path $folderToCreate2 -Folder
		Assert-NotNull $result "No value was returned on folder creation"
		
		# Create and get Empty File
		$result = New-AzDataLakeStoreItem -Account $accountName -path $fileToCreate1
		Assert-NotNull $result "No value was returned on empty file creation"
		$result = New-AzDataLakeStoreItem -Account $accountName -path $fileToCreate2
		Assert-NotNull $result "No value was returned on empty file creation"
		
	    # delete a file
		Assert-True {Remove-AzDataLakeStoreItem -Account $accountName -paths $fileToCreate1 -force -passthru } "Remove File Failed"
		Assert-Throws {Get-AzDataLakeStoreItem -Account $accountName -path $fileToCreate1}
		Assert-True {Remove-AzDataLakeStoreItem -Account $accountName -paths $fileToCreate2 -force -passthru } "Remove File Failed"
		Assert-Throws {Get-AzDataLakeStoreItem -Account $accountName -path $fileToCreate2}
		
		# search delete folder
		$out = Get-AzDataLakeStoreDeletedItem -Account $accountName -filter "adlfolderTest1" -Count 1000
		foreach($item in $out)
		{
            Restore-AzDataLakeStoreDeletedItem -Account $accountName -Path $item.TrashDirPath -Destination $item.OriginalPath -Type "file" -Force -Passthru
			Assert-True { Restore-AzDataLakeStoreDeletedItem -Account $accountName -Path $item.TrashDirPath -Destination $item.OriginalPath -Type "file" -Force -Passthru}
		}

		$out = Get-AzDataLakeStoreDeletedItem -Account $accountName -filter "adlfolderTest2" -Count 1000
		foreach($item in $out)
		{
			Assert-True { Restore-AzDataLakeStoreDeletedItem -Account $accountName $item -Force -Passthru}
		}
    
		# Delete Data Lake account
		Assert-True {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -PassThru} "Remove Account failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzDataLakeStoreAccount -ResourceGroupName $resourceGroupName -Name $accountName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}