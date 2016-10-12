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

		# Test to make sure the server doesn't exist
		#Assert-False {Test-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName}
		# Test it without specifying a resource group
		#Assert-False {Test-AzureRmAnalysisServicesServer -Name $serverName}

		$serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'S1' -Administrators 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net'
    
		Assert-AreEqual $serverName $serverCreated.Name
		Assert-AreEqual $location $serverCreated.Location
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverCreated.Type
		Assert-True {$serverCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if server exists
		for ($i = 0; $i -le 60; $i++)
		{
			[array]$serverGet = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
			if ($serverGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $serverName $serverGet[0].Name
				Assert-AreEqual $location $serverGet[0].Location
				Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverGet[0].Type
				Assert-True {$serverGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "server not yet provisioned. current state: $($serverGet[0].ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Analysis Services server is not in succeeded state even after 30 min."
		}

		# Test to make sure the server does exist
		Assert-True {Test-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName}
		# Test it without specifying a resource group
		Assert-True {Test-AzureRmAnalysisServicesServer -Name $serverName}

		# Updating server
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		$serverUpdated = Set-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Tags $tagsToUpdate
		Assert-NotNull $serverUpdated.Tags "Tags do not exists"
		Assert-NotNull $serverUpdated.Tags["TestTag"] "The updated tag 'TestTag' does not exist"

		$serverUpdated = Set-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Administrators 'aztest1@stabletest.ccsctp.net'
		Assert-NotNull $serverUpdated.AsAdministrators.Members "Server Administrators list i empty"
		Assert-AreEqual $serverUpdated.AsAdministrators.Members.Count 1
    
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
		Assert-Throws {Suspend-AzureRmAnalysisServicesServer} "Suspend Server must throw"
		Assert-True {Suspend-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName} "Suspend Server failed."

		# Suspend Analysis Servicesserver
		Assert-Throws {Resume-AzureRmAnalysisServicesServer} "Resume Server must throw"
		Assert-True {Resume-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName} "Resume Server failed."
		
		# Delete Analysis Servicesserver
		Assert-True {Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Force -PassThru} "Remove Server failed."

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
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
		$serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'S1' -Administrators 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net'
    
		Assert-AreEqual $serverName $serverCreated.Name
		Assert-AreEqual $location $serverCreated.Location
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverCreated.Type
		Assert-True {$serverCreated.Id -like "*$resourceGroupName*"}

		# In loop to check if server exists
		for ($i = 0; $i -le 60; $i++)
		{
        
			[array]$serverGet = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
			if ($serverGet[0].ProvisioningState -like "Succeeded")
			{
				Assert-AreEqual $serverName $serverGet[0].Name
				Assert-AreEqual $location $serverGet[0].Location
				Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverGet[0].Type
				Assert-True {$serverGet[0].Id -like "*$resourceGroupName*"}
				break
			}

			Write-Host "server not yet provisioned. current state: $($serverGet[0].ProvisioningState)"
			[Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
			Assert-False {$i -eq 60} " Analysis Services server not in succeeded state even after 30 min."
		}

		# attempt to recreate the already created server
		Assert-Throws {New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location}

		# attempt to update a non-existent server
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		Assert-Throws {Set-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $fakeserverName -Tags $tagsToUpdate}

		# attempt to get a non-existent server
		Assert-Throws {Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $fakeserverName}

		# Delete Analysis Servicesserver
		Assert-True {Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Force -PassThru} "Remove Account failed."

		# Delete Analysis Servicesserver again should throw.
		Assert-Throws {Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Force -PassThru}

		# Verify that it is gone by trying to get it again
		Assert-Throws {Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}