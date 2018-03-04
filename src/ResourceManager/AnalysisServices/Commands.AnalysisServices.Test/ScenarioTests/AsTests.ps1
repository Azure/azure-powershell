<#
.SYNOPSIS
Tests Analysis Services server lifecycle (Create, Update, Get, List, Delete).
#>
function Test-AnalysisServicesServer
{
	try
	{  
		# Creating server
		$location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$serverName = Get-AnalysisServicesServerName
		$backupBlobContainerUri = $env:AAS_DEFAULT_BACKUP_BLOB_CONTAINER_URI

		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		$serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'S1' -Administrator 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net'
    
		Assert-AreEqual $serverName $serverCreated.Name
		Assert-AreEqual $location $serverCreated.Location
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverCreated.Type
		Assert-AreEqual 2 $serverCreated.AsAdministrators.Count
		Assert-True {$serverCreated.Id -like "*$resourceGroupName*"}
		Assert-True {$serverCreated.ServerFullName -ne $null -and $serverCreated.ServerFullName.Contains("$serverName")}
	    Assert-AreEqual 1 $serverCreated.Sku.Capacity

		[array]$serverGet = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		$serverGetItem = $serverGet[0]

		Assert-True {$serverGetItem.ProvisioningState -like "Succeeded"}
		Assert-True {$serverGetItem.State -like "Succeeded"}
		
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
		Assert-AreEqual $serverUpdated.AsAdministrators.Count 2
		Assert-AreEqual 1 $serverUpdated.Sku.Capacity

		$serverUpdated = Set-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Administrator 'aztest1@stabletest.ccsctp.net' -PassThru
		Assert-NotNull $serverUpdated.AsAdministrators "Server Administrator list is empty"
		Assert-AreEqual $serverUpdated.AsAdministrators.Count 1
		Assert-AreEqual 1 $serverUpdated.Sku.Capacity

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
		# this is to ensure backward compatibility compatibility. The servie side would make change to differenciate state and provisioningState in future
		Assert-True {$serverGetItem.State -like "Paused"}
		Assert-True {$serverGetItem.ProvisioningState -like "Paused"}

		# Resume Analysis Servicesserver
		Resume-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		[array]$serverGet = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		$serverGetItem = $serverGet[0]
		Assert-True {$serverGetItem.ProvisioningState -like "Succeeded"}
		Assert-True {$serverGetItem.State -like "Succeeded"}
		
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
Tests scale up and down of Analysis Services server (B1 -> S2 -> S1).
#>
function Test-AnalysisServicesServerScaleUpDown
{
	try
	{  
		# Creating server
		$location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$serverName = Get-AnalysisServicesServerName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		$serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'B1' -Administrator 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net'
		Assert-AreEqual $serverName $serverCreated.Name
		Assert-AreEqual $location $serverCreated.Location
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverCreated.Type
		Assert-AreEqual B1 $serverCreated.Sku.Name
		Assert-True {$serverCreated.Id -like "*$resourceGroupName*"}
		Assert-True {$serverCreated.ServerFullName -ne $null -and $serverCreated.ServerFullName.Contains("$serverName")}
	    Assert-AreEqual 1 $serverCreated.Sku.Capacity

		# Check server was created successfully
		[array]$serverGet = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		$serverGetItem = $serverGet[0]

		Assert-True {$serverGetItem.ProvisioningState -like "Succeeded"}
		Assert-True {$serverGetItem.State -like "Succeeded"}
		
		Assert-AreEqual $serverName $serverGetItem.Name
		Assert-AreEqual $location $serverGetItem.Location
		Assert-AreEqual B1 $serverGetItem.Sku.Name
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverGetItem.Type
		Assert-True {$serverGetItem.Id -like "*$resourceGroupName*"}
		
		# Scale up B1 -> S2
		$serverUpdated = Set-AzureRmAnalysisServicesServer -Name $serverName -Sku S2 -PassThru
		Assert-AreEqual S2 $serverUpdated.Sku.Name

		# Scale down S2 -> S1
		$serverUpdated = Set-AzureRmAnalysisServicesServer -Name $serverName -Sku S1 -PassThru
		Assert-AreEqual S1 $serverUpdated.Sku.Name
		
		# Delete Analysis Servicesserver
		Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -PassThru
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
Tests firewall feature of Analysis Services server
#>
function Test-AnalysisServicesServerFirewall
{
	try
	{  
		# Creating server
		$location = Get-Location Microsoft.AnalysisServices 'servers' 'West US'
		$resourceGroupName = Get-ResourceGroupName
		$serverName = Get-AnalysisServicesServerName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
		$rule1 = New-AzureRmAnalysisServicesFirewallRule -FirewallRuleName abc1 -RangeStart 0.0.0.0 -RangeEnd 255.255.255.255
        $rule2 = New-AzureRmAnalysisServicesFirewallRule -FirewallRuleName abc2 -RangeStart 6.6.6.6 -RangeEnd 7.7.7.7
        $config = New-AzureRmAnalysisServicesFirewallConfig -FirewallRule $rule1, $rule2
		$serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'B1' -Administrator 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net' -FirewallConfig $config
		Assert-AreEqual 1 $serverCreated.Sku.Capacity
		Assert-AreEqual $serverName $serverCreated.Name
		Assert-AreEqual $location $serverCreated.Location
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverCreated.Type
		Assert-AreEqual B1 $serverCreated.Sku.Name
		Assert-True {$serverCreated.Id -like "*$resourceGroupName*"}
		Assert-True {$serverCreated.ServerFullName -ne $null -and $serverCreated.ServerFullName.Contains("$serverName")}
	    Assert-AreEqual $FALSE $serverCreated.FirewallConfig.EnablePowerBIService
		Assert-AreEqual 2 $serverCreated.FirewallConfig.FirewallRules.Count
		Assert-AreEqual 0.0.0.0 $serverCreated.FirewallConfig.FirewallRules[0].RangeStart
		Assert-AreEqual 255.255.255.255 $serverCreated.FirewallConfig.FirewallRules[0].RangeEnd
		Assert-AreEqual 6.6.6.6 $serverCreated.FirewallConfig.FirewallRules[1].RangeStart
		Assert-AreEqual 7.7.7.7 $serverCreated.FirewallConfig.FirewallRules[1].RangeEnd

		# Check server was created successfully
		[array]$serverGet = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		$serverGetItem = $serverGet[0]

		Assert-True {$serverGetItem.ProvisioningState -like "Succeeded"}
		Assert-True {$serverGetItem.State -like "Succeeded"}
		
		Assert-AreEqual $serverName $serverGetItem.Name
		Assert-AreEqual $location $serverGetItem.Location
		Assert-AreEqual B1 $serverGetItem.Sku.Name
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverGetItem.Type
		Assert-True {$serverGetItem.Id -like "*$resourceGroupName*"}	
	    Assert-AreEqual $FALSE $serverGetItem.FirewallConfig.EnablePowerBIService
		Assert-AreEqual 2 $serverGetItem.FirewallConfig.FirewallRules.Count
		
		$emptyConfig = @()
		$config = New-AzureRmAnalysisServicesFirewallConfig -EnablePowerBIService -FirewallRule $emptyConfig
		Set-AzureRmAnalysisServicesServer -Name $serverName -FirewallConfig $config
		[array]$serverGet = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		$serverGetItem = $serverGet[0]
	    Assert-AreEqual $TRUE $serverGetItem.FirewallConfig.EnablePowerBIService
		Assert-AreEqual 0 $serverGetItem.FirewallConfig.FirewallRules.Count
		Assert-AreEqual 1 $serverGetItem.Sku.Capacity

		# Delete Analysis Servicesserver
		Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -PassThru
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
Tests scale out and in of Analysis Services server (1 -> 2 -> 1).
#>
function Test-AnalysisServicesServerScaleOutIn
{
	try
	{  
		# Creating server
		$location = Get-Location Microsoft.AnalysisServices 'servers' 'West US'
		$resourceGroupName = Get-ResourceGroupName
		$serverName = Get-AnalysisServicesServerName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		$serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'S1' -ReadonlyReplicaCount 1 -DefaultConnectionMode 'Readonly' -Administrator 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net'
		Assert-AreEqual $serverName $serverCreated.Name
		Assert-AreEqual $location $serverCreated.Location
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverCreated.Type
		Assert-AreEqual S1 $serverCreated.Sku.Name
		Assert-AreEqual 2 $serverCreated.Sku.Capacity
		Assert-AreEqual "Readonly" $serverCreated.DefaultConnectionMode		
		Assert-True {$serverCreated.Id -like "*$resourceGroupName*"}
		Assert-True {$serverCreated.ServerFullName -ne $null -and $serverCreated.ServerFullName.Contains("$serverName")}
	
		# Check server was created successfully
		[array]$serverGet = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		$serverGetItem = $serverGet[0]

		Assert-True {$serverGetItem.ProvisioningState -like "Succeeded"}
		Assert-True {$serverGetItem.State -like "Succeeded"}
		
		Assert-AreEqual $serverName $serverGetItem.Name
		Assert-AreEqual $location $serverGetItem.Location
		Assert-AreEqual S1 $serverGetItem.Sku.Name
		Assert-AreEqual 2 $serverCreated.Sku.Capacity
		Assert-AreEqual "Readonly" $serverCreated.DefaultConnectionMode	
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverGetItem.Type
		Assert-True {$serverGetItem.Id -like "*$resourceGroupName*"}
		
		$tagsToUpdate = @{"TestTag" = "TestUpdate"}
		$serverUpdated = Set-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Tag $tagsToUpdate -PassThru
		Assert-AreEqual 2 $serverUpdated.Sku.Capacity

		#Scale in Capacity 2 -> 1
		$serverUpdated = Set-AzureRmAnalysisServicesServer -Name $serverName -ReadonlyReplicaCount 0 -PassThru
		Assert-AreEqual 1 $serverUpdated.Sku.Capacity
		Assert-AreEqual S1 $serverUpdated.Sku.Name
		
		# Delete Analysis Servicesserver
		Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -PassThru
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
Tests disable backup blob container
In order to run this test successfully, Following environment variables need to be set.
AAS_DEFAULT_BACKUP_BLOB_CONTAINER_URI e.x. value 'https://aassdk1.blob.core.windows.net/azsdktest?<serviceSasToken1>'
AAS_SECOND_BACKUP_BLOB_CONTAINER_URI e.x. value 'https://aassdk1.blob.core.windows.net/azsdktest2?<serviceSasToken2>'
#>
function Test-AnalysisServicesServerDisableBackup
{
	try
	{  
		# Creating server
		$location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$serverName = Get-AnalysisServicesServerName
		$backupBlobContainerUri = $env:AAS_DEFAULT_BACKUP_BLOB_CONTAINER_URI
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		$serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'B1' -Administrator 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net' -BackupBlobContainerUri $backupBlobContainerUri
		Assert-AreEqual $serverName $serverCreated.Name
		Assert-AreEqual $location $serverCreated.Location
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverCreated.Type
		Assert-AreEqual B1 $serverCreated.Sku.Name
		Assert-True {$backupBlobContainerUri.Contains($serverCreated.BackupBlobContainerUri)}
		Assert-True {$serverCreated.Id -like "*$resourceGroupName*"}
		Assert-True {$serverCreated.ServerFullName -ne $null -and $serverCreated.ServerFullName.Contains("$serverName")}
	
		# Check server was created successfully
		[array]$serverGet = Get-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName
		$serverGetItem = $serverGet[0]

		Assert-True {$serverGetItem.ProvisioningState -like "Succeeded"}
		Assert-True {$serverGetItem.State -like "Succeeded"}
		Assert-True {$backupBlobContainerUri.Contains($serverGetItem.BackupBlobContainerUri)}
		
		Assert-AreEqual $serverName $serverGetItem.Name
		Assert-AreEqual $location $serverGetItem.Location
		Assert-AreEqual B1 $serverGetItem.Sku.Name
		Assert-AreEqual "Microsoft.AnalysisServices/servers" $serverGetItem.Type
		Assert-True {$serverGetItem.Id -like "*$resourceGroupName*"}
		
		# Update backup container
		$backupBlobContainerUriToUpdate = $env:AAS_SECOND_BACKUP_BLOB_CONTAINER_URI
		$serverUpdated = Set-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -BackupBlobContainerUri "$backupBlobContainerUriToUpdate" -PassThru
		Assert-NotNull $serverUpdated.BackupBlobContainerUri "The backup blob container Uri is empty"
		Assert-True {$backupBlobContainerUriToUpdate.contains($serverUpdated.BackupBlobContainerUri)}
		Assert-AreEqual $serverUpdated.AsAdministrators.Count 2

		# Disable Backup
		$serverUpdated = Set-AzureRmAnalysisServicesServer -Name $serverName -DisableBackup -PassThru
		Assert-True {[string]::IsNullOrEmpty($serverUpdated.BackupBlobContainerUri)}
		
		# Delete Analysis Servicesserver
		Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -PassThru
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
		$fakeserverName = "psfakeservertest",
		$invalidSku = "INVALID"
	)
	
	try
	{
		# Creating Account
		$location = Get-Location
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

		# attempt to create a server with invalid Sku
		Assert-Throws {New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $fakeserverName -Location $location -Sku $invalidSku -Administrator 'aztest0@stabletest.ccsctp.net,aztest1@stabletest.ccsctp.net'}

		# attempt to scale a server to invalid Sku
		Assert-Throws {Set-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Sku $invalidSku}

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
Test log exporting from Azure Analysis Service server.
In order to run this test successfully, Following environment variables need to be set.
ASAZURE_TEST_ROLLOUT e.x. value 'aspaaswestusloop1.asazure-int.windows.net'
ASAZURE_TESTUSER_PWD e.x. value 'samplepwd'
#>
function Test-AnalysisServicesServerLogExport
{
    param
	(
		$rolloutEnvironment = $env:ASAZURE_TEST_ROLLOUT
	)
    try
    {
        $location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$serverName = Get-AnalysisServicesServerName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		$serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'S1' -Administrators $env:ASAZURE_TEST_ADMUSERS
		Assert-True {$serverCreated.ProvisioningState -like "Succeeded"}
		Assert-True {$serverCreated.State -like "Succeeded"}

		$secpasswd = ConvertTo-SecureString $env:ASAZURE_TESTUSER_PWD -AsPlainText -Force
		$admuser0 = $env:ASAZURE_TEST_ADMUSERS.Split(',')[0]
		$cred = New-Object System.Management.Automation.PSCredential ($admuser0, $secpasswd)
		$asAzureProfile = Login-AzureAsAccount -RolloutEnvironment $rolloutEnvironment -Credential $cred
		Assert-NotNull $asAzureProfile "Login-AzureAsAccount $rolloutEnvironment must not return null"

        $tempFile = [System.IO.Path]::GetTempFileName()
        Export-AzureAnalysisServicesInstanceLog -Instance $serverName -OutputPath $tempFile
        Assert-Exists $tempFile
        $logContent = [System.IO.File]::ReadAllText($tempFile)
        Assert-False { [string]::IsNullOrEmpty($logContent); }
    }
    finally
    {
        if (Test-Path $tempFile) {
            Remove-Item $tempFile
        }
        Invoke-HandledCmdlet -Command {Remove-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
    }
}

<#
.SYNOPSIS
Tests Analysis Services server Login and restart.
In order to run this test successfully, Following environment variables need to be set.
ASAZURE_TEST_ROLLOUT e.x. value 'aspaasnightly1.asazure-int.windows.net'
ASAZURE_TESTUSER_PWD e.x. value 'aztest0password'
ASAZURE_TEST_ADMUSERS e.x. value 'aztest0@asazure.ccsctp.net,aztest1@asazure.ccsctp.net'
#>
function Test-AnalysisServicesServerRestart
{
    param
	(
		$rolloutEnvironment = $env:ASAZURE_TEST_ROLLOUT
	)
	try
	{
		# Creating server
		$location = Get-Location
		$resourceGroupName = Get-ResourceGroupName
		$serverName = Get-AnalysisServicesServerName
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		$serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'S1' -Administrator $env:ASAZURE_TEST_ADMUSERS
		Assert-True {$serverCreated.ProvisioningState -like "Succeeded"}
		Assert-True {$serverCreated.State -like "Succeeded"}

		$asAzureProfile = Login-AzureAsAccount -RolloutEnvironment $rolloutEnvironment
		Assert-NotNull $asAzureProfile "Login-AzureAsAccount $rolloutEnvironment must not return null"

		$secpasswd = ConvertTo-SecureString $env:ASAZURE_TESTUSER_PWD -AsPlainText -Force
		$admuser0 = $env:ASAZURE_TEST_ADMUSERS.Split(',')[0]
		$cred = New-Object System.Management.Automation.PSCredential ($admuser0, $secpasswd)

		$asAzureProfile = Login-AzureAsAccount -RolloutEnvironment $rolloutEnvironment -Credential $cred
		Assert-NotNull $asAzureProfile "Login-AzureAsAccount $rolloutEnvironment must not return null"
		Assert-True { Restart-AzureAsInstance -Instance $serverName -PassThru }

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


<#
.SYNOPSIS
Tests Analysis Services server Login and synchronize single database.
In order to run this test successfully, Following environment variables need to be set.
ASAZURE_TEST_ROLLOUT e.x. value 'aspaaswestusloop1.asazure-int.windows.net'
ASAZURE_TESTUSER e.x. value 'aztest0@asazure.ccsctp.net'
ASAZURE_TESTUSER_PWD e.x. value 'samplepwd'
ASAZURE_TESTDATABASE e.x. value 'adventureworks'
#>
function Test-AnalysisServicesServerSynchronizeSingle
{
    param
	(
		$rolloutEnvironment = $env.ASAZURE_TEST_ROLLOUT
	)
	try
	{
		# Creating server
        $location = Get-Location
        $resourceGroupName = Get-ResourceGroupName
        $serverName = Get-AnalysisServicesServerName
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

        $serverCreated = New-AzureRmAnalysisServicesServer -ResourceGroupName $resourceGroupName -Name $serverName -Location $location -Sku 'S1' -Administrators $env.ASAZURE_TESTUSER
        Assert-True {$serverCreated.ProvisioningState -like "Succeeded"}
        Assert-True {$serverCreated.State -like "Succeeded"}

        $asAzureProfile = Login-AzureAsAccount -RolloutEnvironment $rolloutEnvironment
        Assert-NotNull $asAzureProfile "Login-AzureAsAccount $rolloutEnvironment must not return null"

        $secpasswd = ConvertTo-SecureString $env.ASAZURE_TESTUSER_PWD -AsPlainText -Force
        $cred = New-Object System.Management.Automation.PSCredential ($env.ASAZURE_TESTUSER, $secpasswd)

		Synchronize-AzureAsInstance -Instance $serverName -Database $env.ASAZURE_TESTDATABASE -PassThru
		
		Assert-NotNull $asAzureProfile "Login-AzureAsAccount $rolloutEnvironment must not return null"
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
Tests Analysis Services server Login with SPN. In order to run this test successfully:
1. Create one application with password, and create another application with certificate authentication.
2. Following environment variables need to be set.
ASAZURE_TEST_ROLLOUT e.x. value 'aspaaswestusloop1.asazure-int.windows.net'
ASAZURE_TESTAPP1_ID e.x. value 'xxxx-xxxx-xxxx-xxxx' ( must be created before test with password )
ASAZURE_TESTAPP1_PWD e.x. value 'yyyyyyyyyyyyyyyy' (password for application ASAZURE_TESTAPP_ID1)
ASAZURE_TESTAPP2_ID e.x. value 'aaaa-aaaa-aaaa-aaaa' ( must be created before test with certificate to authenticate )
ASAZURE_TESTAPP2_CERT_THUMBPRINT e.x. value 'bbbbbbbbbbbbbbbb' (certificate thumbprint for application ASAZURE_TESTAPP_ID2)
#>
function Test-AnalysisServicesServerLoginWithSPN
{
    param
	(
		$rolloutEnvironment = $env.ASAZURE_TEST_ROLLOUT
	)
	try
	{
		# login server with ASAZURE_TESTAPP1_ID and ASAZURE_TESTAPP1_PWD
		$SecurePassword = ConvertTo-SecureString -String $env.ASAZURE_TESTAPP1_PWD -AsPlainText -Force
		$Credential_SPN = New-Object -TypeName "System.Management.Automation.PSCredential" -ArgumentList $env.ASAZURE_TESTAPP1_ID, $SecurePassword
		$asAzureProfile = Login-AzureAsAccount -RolloutEnvironment $rolloutEnvironment -ServicePrincipal -Credential $Credential_SPN -TenantId "72f988bf-86f1-41af-91ab-2d7cd011db47"
		Assert-NotNull $asAzureProfile "Login-AzureAsAccount with Service Principal and password must not return null"
		$token = [Microsoft.Azure.Commands.AnalysisServices.Dataplane.AsAzureClientSession]::TokenCache.ReadItems()[0]
		Assert-NotNull $token "Login-AzureAsAccount with Service Principal and password must not return null"

		# login server with ASAZURE_TESTAPP2_ID and ASAZURE_TESTAPP2_CERT_THUMBPRINT
		$asAzureProfile = Login-AzureAsAccount -RolloutEnvironment $rolloutEnvironment -ServicePrincipal -ApplicationId $env.ASAZURE_TESTAPP1_ID -CertificateThumbprint $env.ASAZURE_TESTAPP2_CERT_THUMBPRINT -TenantId "72f988bf-86f1-41af-91ab-2d7cd011db47"
		Assert-NotNull $asAzureProfile "Login-AzureAsAccount with Service Principal and certificate thumbprint must not return null"
		$token = [Microsoft.Azure.Commands.AnalysisServices.Dataplane.AsAzureClientSession]::TokenCache.ReadItems()[0]
		Assert-NotNull $token "Login-AzureAsAccount with Service Principal and certificate thumbprint must not return null"
	}
	finally
	{

	}
}