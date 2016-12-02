<#
.SYNOPSIS
Tests Analysis Services server lifecycle (Create, Update, Get, List, Delete).
#>
function Test-AnalysisServicesServer
{
    param
	(
		$location = "West US"
	)
	
	try
	{
		# Creating server
		$resourceGroupName = Get-ResourceGroupName
		$serverName = Get-AnalysisServicesServerName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		$serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'S1' -Administrator 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net'
    
		Assert-AreEqual $serverName $serverCreated.Name
		Assert-AreEqual $location $serverCreated.Location
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverCreated.Type
		Assert-True {$serverCreated.Id -like "*$resourceGroupName*"}
		Assert-True {$serverCreated.ServerFullName -ne $null -and $serverCreated.ServerFullName.Contains("*$serverName*")}
	
		[array]$serverGet = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		$serverGetItem = $serverGet[0]
		Assert-True {$serverGetItem.ProvisioningState -like "Succeeded"}
		Assert-AreEqual $serverName $serverGetItem.Name
		Assert-AreEqual $location $serverGetItem.Location
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverGetItem.Type
		Assert-True {$serverGetItem.Id -like "*$resourceGroupName*"}

		# Test to make sure the server does exist
		Assert-True {Test-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName}
		# Test it without specifying a resource group
		Assert-True {Test-AzureRmAnalysisServicesServer -Name $serverName}

		# Updating server
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		$serverUpdated = Set-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Tag $tagsToUpdate -PassThru
		Assert-NotNull $serverUpdated.Tag "Tag do not exists"
		Assert-NotNull $serverUpdated.Tag["TestTag"] "The updated tag 'TestTag' does not exist"

		$serverUpdated = Set-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Administrator 'aztest1@stabletest.ccsctp.net' -PassThru
		Assert-NotNull $serverUpdated.AsAdministrators "Server Administrator list is empty"
		Assert-AreEqual $serverUpdated.AsAdministrators.Count 1
    
		Assert-AreEqual $serverName $serverUpdated.Name
		Assert-AreEqual $location $serverUpdated.Location
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverUpdated.Type
		Assert-True {$serverUpdated.Id -like "*$resourceGroupName*"}

		# List all servers in resource group
		[array]$serversInResourceGroup = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName
		Assert-True {$serversInResourceGroup.Count -ge 1}
    
		$found = 0
		for ($i = 0; $i -lt $serversInResourceGroup.Count; $i++)
		{
			if ($serversInResourceGroup[$i].Name -eq $serverName)
			{
				$found = 1
				Assert-AreEqual $location $serversInResourceGroup[$i].Location
				Assert-AreEqual "Microsoft.AnalysisServices/servers" $serversInResourceGroup[$i].Type
				Assert-True {$serversInResourceGroup[$i].Id -like "*$resourceGroupName*"}

				break
			}
		}
		Assert-True {$found -eq 1} "server created earlier is not found when listing all in resource group: $resourceGroupName."

		# List all Analysis Services servers in subscription
		[array]$serversInSubscription = Get-AzureRmAnalysisServicesServer
		Assert-True {$serversInSubscription.Count -ge 1}
		Assert-True {$serversInSubscription.Count -ge $serversInResourceGroup.Count}
    
		$found = 0
		for ($i = 0; $i -lt $serversInSubscription.Count; $i++)
		{
			if ($serversInSubscription[$i].Name -eq $serverName)
			{
				$found = 1
				Assert-AreEqual $location $serversInSubscription[$i].Location
				Assert-AreEqual "Microsoft.AnalysisServices/servers" $serversInSubscription[$i].Type
				Assert-True {$serversInSubscription[$i].Id -like "*$resourceGroupName*"}
    
				break
			}
		}
		Assert-True {$found -eq 1} "Account created earlier is not found when listing all in subscription."

		# Suspend Analysis Servicesserver
		Suspend-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		[array]$serverGet = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		$serverGetItem = $serverGet[0]
		Assert-True {$serverGetItem.ProvisioningState -like "Paused"}

		# Resume Analysis Servicesserver
		Resume-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		[array]$serverGet = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		$serverGetItem = $serverGet[0]
		Assert-True {$serverGetItem.ProvisioningState -like "Succeeded"}
		
		# Delete Analysis Servicesserver
		Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -PassThru

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}


<#
.SYNOPSIS
Tests Analysis Services server lifecycle  Failure scenarios (Create, Update, Get, Delete).
#>
function Test-NegativeAnalysisServicesServer
{
    param
	(
		$location = "West US",
		$fakeserverName = "psfakeservertest"
	)
	
	try
	{
		# Creating Account
		$resourceGroupName = Get-ResourceGroupName
		$serverName = Get-AnalysisServicesServerName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
		$serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'S1' -Administrator 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net'
    
		Assert-AreEqual $serverName $serverCreated.Name
		Assert-AreEqual $location $serverCreated.Location
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverCreated.Type
		Assert-True {$serverCreated.Id -like "*$resourceGroupName*"}
       
		# attempt to recreate the already created server
		Assert-Throws {New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location}

		# attempt to update a non-existent server
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		Assert-Throws {Set-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $fakeserverName -Tag $tagsToUpdate}

		# attempt to get a non-existent server
		Assert-Throws {Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $fakeserverName}

		# Delete Analysis Servicesserver
		Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -PassThru

		# Delete Analysis Servicesserver again should throw.
		Assert-Throws {Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -PassThru}

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests Analysis Services server Login and restart.
In order to run this test successfully, Following environment variables need to be set.
ASAZURE_TEST_ROLLOUT e.x. value 'aspaaswestusloop1.asazure-int.windows.net'
ASAZURE_TESTUSER_PWD e.x. value 'samplepwd'
#>
function Test-AnalysisServicesServerRestart
{
    param
	(
		$rolloutEnvironment = $env.ASAZURE_TEST_ROLLOUT,
		$location = "West US"
	)
	try
	{
		# Creating server
		$resourceGroupName = Get-ResourceGroupName
		$serverName = Get-AnalysisServicesServerName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		$serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'S1' -Administrators 'aztest0@aspaastestloop1.ccsctp.net,aztest1@aspaastestloop1.ccsctp.net'
		Assert-True {$serverCreated.ProvisioningState -like "Succeeded"}

		$asAzureProfile = Login-AzureAsAccount -RolloutEnvironment $rolloutEnvironment
		Assert-NotNull $asAzureProfile "Login-AzureAsAccount $rolloutEnvironment must not return null"

		$secpasswd = ConvertTo-SecureString $env.ASAZURE_TESTUSER_PWD -AsPlainText -Force
		$cred = New-Object System.Management.Automation.PSCredential ('aztest1@aspaastestloop1.ccsctp.net', $secpasswd)

		$asAzureProfile = Login-AzureAsAccount -RolloutEnvironment $rolloutEnvironment -Credential $cred
		Assert-NotNull $asAzureProfile "Login-AzureAsAccount $rolloutEnvironment must not return null"
		Restart-AzureAsInstance -Instance $serverName

		$asAzureProfile = Login-AzureAsAccount
		Assert-NotNull $asAzureProfile "Login-AzureAsAccount for empty rolloutname must not return null"

		$asAzureProfile = Login-AzureAsAccount -Credential $cred
		Assert-NotNull $asAzureProfile "Login-AzureAsAccount for empty rolloutname must not return null"

		$rolloutEnvironment = 'asazure-int.windows.net'
		$asAzureProfile = Login-AzureAsAccount $rolloutEnvironment
		Assert-NotNull $asAzureProfile "Login-AzureAsAccount $rolloutEnvironment must not return null"

		$rolloutEnvironment = 'asazure.windows.net'
		$asAzureProfile = Login-AzureAsAccount $rolloutEnvironment
		Assert-NotNull $asAzureProfile "Login-AzureAsAccount $rolloutEnvironment must not return null"
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}