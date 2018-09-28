# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Tests retrieving websites
.DESCRIPTION
SmokeTest
#>
function Test-GetWebApp
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$wname2 = Get-WebsiteName
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Shared"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$actual = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId
		
		# Get web app by name
		$result = Get-AzureRmWebApp -Name $wname

		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Create new web app
		$actual = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname2 -Location $location -AppServicePlan $whpName

		# Assert
		Assert-AreEqual $wname2 $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get web apps by subscription
		$result = Get-AzureRmWebApp

		# Assert
		Assert-True { $result.Count -ge 2 }

		# Get web apps by location
		$result = Get-AzureRmWebApp -Location $location
		
		# Assert
		Assert-True { $result.Count -ge 2 }
		
		# Get all web apps by resource group
		$result = Get-AzureRmWebApp -ResourceGroupName $rgname
		
		# Assert
		Assert-AreEqual 2 $result.Count

		# Get web apps by server farm
		$result = Get-AzureRmWebApp -AppServicePlan $serverFarm
		
		# Assert
		Assert-True { $result.Count -ge 2 }

	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $wname2 -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests retrieving website metrics
#>
function Test-GetWebAppMetrics
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Shared"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert
		Assert-AreEqual $wname $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId
		
		for($i = 0; $i -lt 10; $i++)
		{
			PingWebApp $webapp
		}

		$endTime = Get-Date
		$startTime = $endTime.AddHours(-3)

		$metricnames = @('CPU', 'Requests')
		
		# Get web app metrics
		$metrics = Get-AzureRmWebAppMetrics -ResourceGroupName $rgname -Name $wname -Metrics $metricnames -StartTime $startTime -EndTime $endTime -Granularity PT1M

		$actualMetricNames = $metrics | Select -Expand Name | Select -Expand Value 

		foreach ($i in $metricnames)
		{
			Assert-True { $actualMetricNames -contains $i}
		}

		# Get web app metrics via pipeline obj
		$metrics = $webapp | Get-AzureRmWebAppMetrics -Metrics $metricnames -StartTime $startTime -EndTime $endTime -Granularity PT1M

		$actualMetricNames = $metrics | Select -Expand Name | Select -Expand Value 

		foreach ($i in $metricnames)
		{
			Assert-True { $actualMetricNames -contains $i}
		}
	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Start stop restart web app
#>
function Test-StartStopRestartWebApp
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Shared"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Stop web app
		$webApp = $webApp | Stop-AzureRmWebApp

		Assert-AreEqual "Stopped" $webApp.State
		$ping = PingWebApp $webApp

		# Start web app
		$webApp = $webApp | Start-AzureRmWebApp

		Assert-AreEqual "Running" $webApp.State
		$ping = PingWebApp $webApp

		# Stop web app
		$webApp = Stop-AzureRmWebApp -ResourceGroupName $rgname -Name $wname

		Assert-AreEqual "Stopped" $webApp.State
		$ping = PingWebApp $webApp

		# Start web app
		$webApp = Start-AzureRmWebApp -ResourceGroupName $rgname -Name $wname

		Assert-AreEqual "Running" $webApp.State
		$ping = PingWebApp $webApp

		# Retart web app
		$webApp = Restart-AzureRmWebApp -ResourceGroupName $rgname -Name $wname

		Assert-AreEqual "Running" $webApp.State
		$ping = PingWebApp $webApp

		# Restart web app
		$webApp = $webApp | Restart-AzureRmWebApp

		Assert-AreEqual "Running" $webApp.State
		$ping = PingWebApp $webApp
	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests clone a website.
#>
function Test-CloneNewWebApp
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-WebLocation
	$planName = Get-WebHostPlanName
	$tier = "Premium"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

	# Destination setup
	$destPlanName = Get-WebHostPlanName
	$destLocation = Get-SecondaryLocation
	$destAppName = Get-WebsiteName

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName 
		
		# Assert
		Assert-AreEqual $appname $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Get new web app
		$webapp = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $appname
		
		# Assert
		Assert-AreEqual $appname $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Create new server Farm
		$serverFarm2 = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $destPlanName -Location  $destLocation -Tier $tier

		# Clone web app
		$webapp2 = New-AzureRmWebApp -ResourceGroupName $rgname -Name $destAppName -Location $destLocation -AppServicePlan $destPlanName -SourceWebApp $webapp
		
		# Assert
		Assert-AreEqual $destAppName $webapp2.Name

		# Get new web app
		$webapp2 = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $destAppName
		
		# Assert
		Assert-AreEqual $destAppName $webapp2.Name
	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force

		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $destAppName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $destPlanName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests clone a website.
#>
function Test-CloneNewWebAppAndDeploymentSlots
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$slot1name = "staging"
	$slot2name = "testing"
	$location = Get-WebLocation
	$planName = Get-WebHostPlanName
	$tier = "Premium"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

	# Destination setup
	$destPlanName = Get-WebHostPlanName
	$destLocation = Get-SecondaryLocation
	$destAppName = Get-WebsiteName

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName 
		
		# Assert
		Assert-AreEqual $appname $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Get new web app
		$webapp = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $appname
		
		# Assert
		Assert-AreEqual $appname $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Create deployment slot 1
		$slot1 = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slot1name -AppServicePlan $planName
		$appWithSlotName = "$appname/$slot1name"

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		# Create deployment slot 2
		$slot2 = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slot2name -AppServicePlan $planName
		$appWithSlotName = "$appname/$slot2name"

		# Assert
		Assert-AreEqual $appWithSlotName $slot2.Name
		Assert-AreEqual $serverFarm.Id $slot2.ServerFarmId

		# Create new server Farm
		$serverFarm2 = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $destPlanName -Location  $destLocation -Tier $tier

		# Clone web app
		$webapp2 = New-AzureRmWebApp -ResourceGroupName $rgname -Name $destAppName -Location $destLocation -AppServicePlan $destPlanName -SourceWebApp $webapp -IncludeSourceWebAppSlots
		
		# Assert
		Assert-AreEqual $destAppName $webapp2.Name

		# Get new web app
		$webapp2 = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $destAppName
		
		# Assert
		Assert-AreEqual $destAppName $webapp2.Name

		# Get new web app slot1
		$slot1 = Get-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $destAppName -Slot $slot1name

		$appWithSlotName = "$destAppName/$slot1name"

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm2.Id $slot1.ServerFarmId

		# Get new web app slot1
		$slot2 = Get-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $destAppName -Slot $slot2name
		$appWithSlotName = "$destAppName/$slot2name"

		# Assert
		Assert-AreEqual $appWithSlotName $slot2.Name
		Assert-AreEqual $serverFarm2.Id $slot2.ServerFarmId
	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slot1name -Force
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slot2name -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force

		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $destAppName -Slot $slot1name -Force
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $destAppName -Slot $slot2name -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $destAppName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $destPlanName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests clone a website.
#>
function Test-CloneNewWebAppWithTrafficManager
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Premium"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

	# Destination setup
	$destAppServicePlanName = Get-WebHostPlanName
	$destLocation = Get-SecondaryLocation
	$destWebAppName = Get-WebsiteName
	$profileName = Get-TrafficManagerProfileName

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$actual = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get new web app
		$result = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $wname
		
		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId

		# Create new server Farm
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $destAppServicePlanName -Location  $destLocation -Tier $tier

		# Clone web app
		$actual = New-AzureRmWebApp -ResourceGroupName $rgname -Name $destWebAppName -Location $destLocation -AppServicePlan $destAppServicePlanName -SourceWebApp $result -TrafficManagerProfileName $profileName
		
		# Assert
		Assert-AreEqual $destWebAppName $actual.Name

		# Get new web app
		$result = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $destWebAppName
		
		# Assert
		Assert-AreEqual $destWebAppName $result.Name
	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force

		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $destWebAppName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $destAppServicePlanName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests creating a new website.
.DESCRIPTION
SmokeTest
#>
function Test-CreateNewWebApp
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "Shared"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$job = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get new web app
		$result = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $wname
		
		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId
	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests creating a new windows continer app.
.DESCRIPTION
SmokeTest
#>
function Test-CreateNewWebAppHyperV
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "PremiumContainer"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
    $containerImageName = "testcontainer.io/paltest/iis"
    $containerRegistryUrl = "https://testcontainer.azurecr.io"
    $ontainerRegistryUser = "testregistry"
    $pass = "7Dxo9p79Ins2K3ZU"
    $containerRegistryPassword = ConvertTo-SecureString -String $pass -AsPlainText -Force
    $dockerPrefix = "DOCKER|" 


	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier -WorkerSize Small -HyperV
		
		# Create new web app
		$job = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -ContainerImageName $containerImageName -ContainerRegistryUrl $containerRegistryUrl -ContainerRegistryUser $ontainerRegistryUser -ContainerRegistryPassword $containerRegistryPassword -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get new web app
		$result = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $wname
		
		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId
        Assert-AreEqual $true $result.IsXenon
        Assert-AreEqual ($dockerPrefix + $containerImageName)  $result.SiteConfig.WindowsFxVersion

        $appSettings = @{
        "DOCKER_REGISTRY_SERVER_URL" = $containerRegistryUrl;
        "DOCKER_REGISTRY_SERVER_USERNAME" = $ontainerRegistryUser;
        "DOCKER_REGISTRY_SERVER_PASSWORD" = $pass;}

        foreach($nvp in $webApp.SiteConfig.AppSettings)
		{
			Assert-True { $appSettings.Keys -contains $nvp.Name }
			Assert-True { $appSettings[$nvp.Name] -match $nvp.Value }
		}


	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests enagbling continuous deployment for container and getting continuous deployment url.
.DESCRIPTION
SmokeTest
#>
function Test-EnableContainerContinuousDeploymentAndGetUrl
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "PremiumContainer"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
    $containerImageName = "microsoft/iis"
    $containerRegistryUrl = "https://testcontainer.azurecr.io"
    $ontainerRegistryUser = "testregistry"
    $pass = "7Dxo9p79Ins2K3ZU"
    $containerRegistryPassword = ConvertTo-SecureString -String $pass -AsPlainText -Force
    $dockerPrefix = "DOCKER|"
 	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier -WorkerSize Small -HyperV

		# Create new web app
		$job = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -ContainerImageName $containerImageName -ContainerRegistryUrl $containerRegistryUrl -ContainerRegistryUser $ontainerRegistryUser -ContainerRegistryPassword $containerRegistryPassword -EnableContainerContinuousDeployment -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId
 		# Get new web app
		$result = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $wname

		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId
        Assert-AreEqual $true $result.IsXenon
        Assert-AreEqual ($dockerPrefix + $containerImageName)  $result.SiteConfig.WindowsFxVersion
         $appSettings = @{
        "DOCKER_REGISTRY_SERVER_URL" = $containerRegistryUrl;
        "DOCKER_REGISTRY_SERVER_USERNAME" = $ontainerRegistryUser;
        "DOCKER_REGISTRY_SERVER_PASSWORD" = $pass;
        "DOCKER_ENABLE_CI" = "true"}
         foreach($nvp in $webApp.SiteConfig.AppSettings)
		{
			Assert-True { $appSettings.Keys -contains $nvp.Name }
			Assert-True { $appSettings[$nvp.Name] -match $nvp.Value }
		}

         $ci_url = Get-AzureRmWebAppContainerContinuousDeploymentUrl -ResourceGroupName $rgname -Name $wname

		 $expression = "https://" + $wname + ":(.*)@" + $wname + ".scm.azurewebsites.net/docker/hook"
		 $sanitizedCiUrl = { $ci_url -replace '$','' }

		 $matchResult = { $sanitizedCiUrl -match $expression }

		 Assert-AreEqual $true $matchResult
 	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests issuing an EnterPsSession command to a Windows container web app.
.DESCRIPTION
SmokeTest
#>
function Test-WindowsContainerCanIssueWebAppPSSession
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "PremiumContainer"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
    $containerImageName = "mcr.microsoft.com/azure-app-service/samples/aspnethelloworld:latest"
    $containerRegistryUrl = "https://mcr.microsoft.com"
	$containerRegistryUser = "testregistry"
    $pass = "7Dxo9p79Ins2K3ZU"
    $containerRegistryPassword = ConvertTo-SecureString -String $pass -AsPlainText -Force
	$dockerPrefix = "DOCKER|"

 	try
	{

		Write-Debug "Creating app service plan..."

		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier -WorkerSize Large -HyperV

		Write-Debug "App service plan created"

		Write-Debug "Creating web app plan..."

		# Create new web app
		$job = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -ContainerImageName $containerImageName -ContainerRegistryUrl $containerRegistryUrl -ContainerRegistryUser $containerRegistryUser -ContainerRegistryPassword $containerRegistryPassword -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		Write-Debug "Webapp created"

		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId
 		# Get new web app
		$result = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $wname

		Write-Debug "Webapp retrieved"

		Write-Debug "Validating web app properties..."

		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId
        Assert-AreEqual $true $result.IsXenon
        Assert-AreEqual ($dockerPrefix + $containerImageName)  $result.SiteConfig.WindowsFxVersion

		$actualAppSettings = @{}

		foreach ($kvp in $result.SiteConfig.AppSettings)
		{
			$actualAppSettings[$kvp.Name] = $kvp.Value
		}

		# Validate Appsettings

		$expectedAppSettings = @{}
		$expectedAppSettings["DOCKER_REGISTRY_SERVER_URL"] = $containerRegistryUrl;
		$expectedAppSettings["DOCKER_REGISTRY_SERVER_USERNAME"] = $containerRegistryUser;
		$expectedAppSettings["DOCKER_REGISTRY_SERVER_PASSWORD"] = $pass;

		foreach ($key in $expectedAppSettings.Keys)
		{
			Assert-True {$actualAppSettings.Keys -contains $key}
			Assert-AreEqual $actualAppSettings[$key] $expectedAppSettings[$key]
		}

		Write-Debug "Enabling Win-RM..."

		# Adding Appsetting: enabling WinRM
		$actualAppSettings["CONTAINER_WINRM_ENABLED"] = "1"
        $webApp = Set-AzureRmWebApp -ResourceGroupName $rgname -Name $wName -AppSettings $actualAppSettings

		# Validating that the client can at least issue the EnterPsSession command.
		# This will validate that this cmdlet will run succesfully in Cloud Shell.
		# If the current PsVersion is 5.1 or less (Windows PowerShell) and the current WSMAN settings will not allow the user
		# to connect (for example: invalid Trusted Hosts, Basic Auth not enabled) this command will issue a Warning instructing the user
		# to fix WSMAN settings. It will not attempt to run EnterPsSession.
		#
		# If the current version is 6.0 (PowerShell Core) this command will not attempt to validate WSMAN settings and 
		# just try to run EnterPsSession. EnterPsSession is available in Cloud Shell
		#
		# We need an real Windows Container app running to fully validate the returned PsSession object, which is not 
		# possible in 'Playback' mode.
		#
		# This assert at least verifies that the EnterPsSession command is attempted and that the behavior is the expected in
		# Windows PowerShell and PowerShell Core.
		New-AzureRmWebAppContainerPSSession -ResourceGroupName $rgname -Name $wname -WarningVariable wv -WarningAction SilentlyContinue -ErrorAction SilentlyContinue -Force
		

		if ((Get-WebsitesTestMode) -ne 'Playback') 
		{
			# Message for Recording mode
			$message = "Connecting to remote server $wname.azurewebsites.net failed with the following error message : The connection to the specified remote host was refused."
			$resultError = $Error[0] -like "*$($message)*"
			Write-Debug "Expected Message: $message"
		}
		else
		{
			# Two possible messages in Playback mode since the site will not exist.
			$messageDNS = "Connecting to remote server $wname.azurewebsites.net failed with the following error message : The WinRM client cannot process the request because the server name cannot be resolved"
			$messageUnavailable = "Connecting to remote server $wname.azurewebsites.net failed with the following error message : The WinRM client sent a request to an HTTP server and got a response saying the requested HTTP URL was not available."
			$resultError = ($Error[0] -like "*$($messageDNS)*") -or ($Error[0] -like "*$($messageUnavailable)*")
			Write-Debug "Expected Message 1: $messageDNS"
			Write-Debug "Expected Message 2: $messageUnavailable"
		}
		
		Write-Debug "Error: $Error[0]"
		Write-Debug "Warnings: $wv"
		
		Write-Debug "Printing PsVersion"
		foreach ($key in $PsVersionTable.Keys)
		{
			Write-Debug "$key"
			foreach($v in $PsVersionTable[$key])
			{
				Write-Debug "   $v"
			}
		}

		
		If(!$resultError)
		{
			Write-Output "expected error $($message), actual error $($Error[0])"
			Write-Output "Warnings: $wv"
		}
		Assert-True {$resultError}
 	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests that a PsSession can be established to a Windows Container App. It is expected to fail in Playback mode
.DESCRIPTION
SmokeTest
#>
function Test-WindowsContainerWebAppPSSessionOpened
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "PremiumContainer"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
    $containerImageName = "mcr.microsoft.com/azure-app-service/samples/aspnethelloworld:latest"
    $containerRegistryUrl = "https://mcr.microsoft.com"
	$containerRegistryUser = "testregistry"
    $pass = "7Dxo9p79Ins2K3ZU"
    $containerRegistryPassword = ConvertTo-SecureString -String $pass -AsPlainText -Force
	$dockerPrefix = "DOCKER|"

 	try
	{

		Write-Debug "Creating app service plan..."

		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier -WorkerSize Large -HyperV

		Write-Debug "App service plan created"

		Write-Debug "Creating web app plan..."

		# Create new web app
		$job = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -ContainerImageName $containerImageName -ContainerRegistryUrl $containerRegistryUrl -ContainerRegistryUser $containerRegistryUser -ContainerRegistryPassword $containerRegistryPassword -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		Write-Debug "Webapp created"

		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId
 		# Get new web app
		$result = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $wname

		Write-Debug "Webapp retrieved"

		Write-Debug "Validating web app properties..."

		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId
        Assert-AreEqual $true $result.IsXenon
        Assert-AreEqual ($dockerPrefix + $containerImageName)  $result.SiteConfig.WindowsFxVersion

		$actualAppSettings = @{}

		foreach ($kvp in $result.SiteConfig.AppSettings)
		{
			$actualAppSettings[$kvp.Name] = $kvp.Value
		}

		# Validate Appsettings

		$expectedAppSettings = @{}
		$expectedAppSettings["DOCKER_REGISTRY_SERVER_URL"] = $containerRegistryUrl;
		$expectedAppSettings["DOCKER_REGISTRY_SERVER_USERNAME"] = $containerRegistryUser;
		$expectedAppSettings["DOCKER_REGISTRY_SERVER_PASSWORD"] = $pass;

		foreach ($key in $expectedAppSettings.Keys)
		{
			Assert-True {$actualAppSettings.Keys -contains $key}
			Assert-AreEqual $actualAppSettings[$key] $expectedAppSettings[$key]
		}

		Write-Debug "Enabling Win-RM..."

		# Adding Appsetting: enabling WinRM
		$actualAppSettings["CONTAINER_WINRM_ENABLED"] = "1"
        $webApp = Set-AzureRmWebApp -ResourceGroupName $rgname -Name $wName -AppSettings $actualAppSettings

		$status = PingWebApp($webApp)
		Write-Debug "Just pinged the web app"
		Write-Debug "Status: $status"

		# Wait for the container app to return 200.
		# Windows Container apps return 503 when starting up. Usualy takes 8-9 minutes.
		# Timing out at 15 minutes

		$count=0
		while (($status -like "ServiceUnavailable") -and $count -le 15)
		{
			Wait-Seconds 60
		    $status = PingWebApp($webApp)
			Write-Debug $count
			$count++
		}

		# Asserting status of the last ping to the web app
		Assert-AreEqual $status "200"

		$ps_session = New-AzureRmWebAppContainerPSSession -ResourceGroupName $rgname -Name $wname -Force

		Write-Debug "After PSSession"

		Assert-AreEqual $ps_session.ComputerName $wname".azurewebsites.net"
		Assert-AreEqual $ps_session.State "Opened"
 	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests creating a new website on an ase
#>
function Test-CreateNewWebAppOnAse
{
	# Setup
	# Creating and provisioning an ASE currently takes 30 mins to an hour, hence this test requires that the ASE & ASP are already created 
	# before creating the app on the ASE
	$rgname = "appdemorg"
	$wname = Get-WebsiteName
	$location = "West US"
	$whpName = "travelproductionplan"
	$aseName = "asedemops"
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		$serverFarm = Get-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName

		# Create new web app
		$job = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -AseName $aseName -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get new web app
		$result = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $wname
		
		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId
	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Force
	}
}

<#
.SYNOPSIS
Tests retrieving websites
.DESCRIPTION
SmokeTest
#>
function Test-SetWebApp
{
	# Setup
	$rgname = Get-ResourceGroupName
	$webAppName = Get-WebsiteName
	$location = Get-WebLocation
	$appServicePlanName1 = Get-WebHostPlanName
	$appServicePlanName2 = Get-WebHostPlanName
	$tier1 = "Shared"
	$tier2 = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	$capacity = 2

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm1 = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $appServicePlanName1 -Location  $location -Tier $tier1
		$serverFarm2 = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $appServicePlanName2 -Location  $location -Tier $tier2
		
		# Create new web app
		$webApp = New-AzureRmWebApp -ResourceGroupName $rgname -Name $webAppName -Location $location -AppServicePlan $appServicePlanName1 
		
		# Assert
		Assert-AreEqual $webAppName $webApp.Name
		Assert-AreEqual $serverFarm1.Id $webApp.ServerFarmId
		Assert-Null $webApp.Identity
		Assert-NotNull $webApp.SiteConfig.phpVersion
		
		# Change service plan & set site properties
		$job = Set-AzureRmWebApp -ResourceGroupName $rgname -Name $webAppName -AppServicePlan $appServicePlanName2 -HttpsOnly $true -AsJob
		$job | Wait-Job
		$webApp = $job | Receive-Job

		# Assert
		Assert-AreEqual $webAppName $webApp.Name
		Assert-AreEqual $serverFarm2.Id $webApp.ServerFarmId
		Assert-AreEqual $true $webApp.HttpsOnly

		# Set config properties
		$webapp.SiteConfig.HttpLoggingEnabled = $true
		$webapp.SiteConfig.RequestTracingEnabled = $true

		# Set site properties
		$webApp = $webApp | Set-AzureRmWebApp

		# Assert
		Assert-AreEqual $webAppName $webApp.Name
		Assert-AreEqual $serverFarm2.Id $webApp.ServerFarmId
		Assert-AreEqual $true $webApp.SiteConfig.HttpLoggingEnabled
		Assert-AreEqual $true $webApp.SiteConfig.RequestTracingEnabled

		$appSettings = @{ "setting1" = "valueA"; "setting2" = "valueB"}
		$connectionStrings = @{ connstring1 = @{ Type="MySql"; Value="string value 1"}; connstring2 = @{ Type = "SQLAzure"; Value="string value 2"}}

        # set app settings and assign Identity
        $webApp = Set-AzureRmWebApp -ResourceGroupName $rgname -Name $webAppName -AppSettings $appSettings -AssignIdentity $true

        # Assert
        Assert-NotNull  $webApp.Identity
        # AssignIdentity adds an appsetting to handle enabling / disabling AssignIdentity
        Assert-AreEqual ($appSettings.Keys.Count) $webApp.SiteConfig.AppSettings.Count
        Assert-NotNull  $webApp.Identity

        # set app settings and connection strings
		$webApp = Set-AzureRmWebApp -ResourceGroupName $rgname -Name $webAppName -AppSettings $appSettings -ConnectionStrings $connectionStrings -NumberofWorkers $capacity -PhpVersion "off"

		# Assert
		Assert-AreEqual $webAppName $webApp.Name
        foreach($nvp in $webApp.SiteConfig.AppSettings)
		{
			Assert-True { $appSettings.Keys -contains $nvp.Name }
			Assert-True { $appSettings[$nvp.Name] -match $nvp.Value }
		}
		Assert-AreEqual $connectionStrings.Keys.Count $webApp.SiteConfig.ConnectionStrings.Count
		foreach($connStringInfo in $webApp.SiteConfig.ConnectionStrings)
		{
			Assert-True { $connectionStrings.Keys -contains $connStringInfo.Name }
		}

		Assert-AreEqual $capacity $webApp.SiteConfig.NumberOfWorkers
		Assert-AreEqual "" $webApp.SiteConfig.PhpVersion

	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $webAppName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $appServicePlanName1 -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $appServicePlanName2 -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests remove a web app
.DESCRIPTION
SmokeTest
#>
function Test-RemoveWebApp
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appName = Get-WebsiteName
	$location = Get-WebLocation
	$planName = Get-WebHostPlanName
	$tier = "Shared"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzureRmWebApp -ResourceGroupName $rgname -Name $appName -Location $location -AppServicePlan $planName
		
		# Assert
		Assert-AreEqual $appName $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Remove web app via pipeline obj
		$webapp | Remove-AzureRmWebApp -Force -AsJob | Wait-Job

		# Retrieve web app by name
		# TODO: Temporarily changed the call below to use parentheses around the Get,
		# since an issue exists currently that causes the test to fail.
		# https://github.com/Azure/azure-powershell/issues/5174
		$webappNames = (Get-AzureRmWebApp -ResourceGroupName $rgname) | Select -Property Name

		Assert-False { $webappNames -contains $appName }
	}
	finally
	{
		# Cleanup
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests remove a web app
#>
function Test-WebAppPublishingProfile
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appName = Get-WebsiteName
	$location = Get-WebLocation
	$planName = Get-WebHostPlanName
	$tier = "Shared"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	$profileFileName = "profile.xml"

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzureRmWebApp -ResourceGroupName $rgname -Name $appName -Location $location -AppServicePlan $planName 
		
		# Assert
		Assert-AreEqual $appName $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Get web app publishing profile
		[xml]$profile = Get-AzureRmWebAppPublishingProfile -ResourceGroupName $rgname -Name $appName -OutputFile $profileFileName
		$msDeployProfile = $profile.publishData.publishProfile | ? { $_.publishMethod -eq 'MSDeploy' } | Select -First 1
		$pass = $msDeployProfile.userPWD

		# Assert
		Assert-True { $msDeployProfile.msdeploySite -eq $appName }

		# Reset web app publishing profile
		$newPass = $webapp | Reset-AzureRmWebAppPublishingProfile 

		# Assert
		Assert-False { $pass -eq $newPass }

		# Get web app publishing profile
		[xml]$profile = $webapp | Get-AzureRmWebAppPublishingProfile -OutputFile $profileFileName -Format FileZilla3
		$fileZillaProfile = $profile.FileZilla3.Servers.Server

		# Assert
		Assert-True { $fileZillaProfile.Name -eq $appName }

		# Get web app publishing profile without OutputFile
		[xml]$profile = Get-AzureRmWebAppPublishingProfile -ResourceGroupName $rgname -Name $appName

		# Assert
		Assert-NotNull $profile

	}
	finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests creating a web app with a simple parameterset.
#>
function Test-CreateNewWebAppSimple
{
	$appName = Get-WebsiteName
	try
	{
		$webapp = New-AzureRmWebApp -Name $appName

		Assert-AreEqual $appName $webapp.Name
	}
	finally
	{
		Remove-AzureRmResourceGroup $appName
	}
}