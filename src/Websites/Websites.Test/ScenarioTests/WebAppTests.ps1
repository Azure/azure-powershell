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
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$actual = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId
		
		# Get web app by name
		$result = Get-AzWebApp -Name $wname

		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Create new web app
		$actual = New-AzWebApp -ResourceGroupName $rgname -Name $wname2 -Location $location -AppServicePlan $whpName

		# Assert
		Assert-AreEqual $wname2 $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get web apps by subscription
		$result = Get-AzWebApp

		# Assert
		Assert-True { $result.Count -ge 2 }

		# Get web apps by location
		$result = Get-AzWebApp -Location $location
		
		# Assert
		Assert-True { $result.Count -ge 2 }
		
		# Get all web apps by resource group
		$result = Get-AzWebApp -ResourceGroupName $rgname
		
		# Assert
		Assert-AreEqual 2 $result.Count

		# Get web apps by server farm
		$result = Get-AzWebApp -AppServicePlan $serverFarm
		
		# Assert
		Assert-True { $result.Count -ge 2 }

	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname2 -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert
		Assert-AreEqual $wname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Stop web app
		$webApp = $webApp | Stop-AzWebApp

		Assert-AreEqual "Stopped" $webApp.State
		# $ping = PingWebApp $webApp

		# Start web app
		$webApp = $webApp | Start-AzWebApp

		Assert-AreEqual "Running" $webApp.State
		$ping = PingWebApp $webApp

		# Stop web app
		$webApp = Stop-AzWebApp -ResourceGroupName $rgname -Name $wname

		Assert-AreEqual "Stopped" $webApp.State
		# $ping = PingWebApp $webApp

		# Start web app
		$webApp = Start-AzWebApp -ResourceGroupName $rgname -Name $wname

		Assert-AreEqual "Running" $webApp.State
		$ping = PingWebApp $webApp

		# Retart web app
		$webApp = Restart-AzWebApp -ResourceGroupName $rgname -Name $wname

		Assert-AreEqual "Running" $webApp.State
		$ping = PingWebApp $webApp

		# Restart web app
		$webApp = $webApp | Restart-AzWebApp

		Assert-AreEqual "Running" $webApp.State
		$ping = PingWebApp $webApp
	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName 
		
		# Assert
		Assert-AreEqual $appname $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Get new web app
		$webapp = Get-AzWebApp -ResourceGroupName $rgname -Name $appname
		
		# Assert
		Assert-AreEqual $appname $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Create new server Farm
		$serverFarm2 = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $destPlanName -Location  $destLocation -Tier $tier

		# Clone web app
		$webapp2 = New-AzWebApp -ResourceGroupName $rgname -Name $destAppName -Location $destLocation -AppServicePlan $destPlanName -SourceWebApp $webapp
		
		# Assert
		Assert-AreEqual $destAppName $webapp2.Name

		# Get new web app
		$webapp2 = Get-AzWebApp -ResourceGroupName $rgname -Name $destAppName
		
		# Assert
		Assert-AreEqual $destAppName $webapp2.Name
	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force

		Remove-AzWebApp -ResourceGroupName $rgname -Name $destAppName -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $destPlanName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName 
		
		# Assert
		Assert-AreEqual $appname $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Get new web app
		$webapp = Get-AzWebApp -ResourceGroupName $rgname -Name $appname
		
		# Assert
		Assert-AreEqual $appname $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Create deployment slot 1
		$slot1 = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slot1name -AppServicePlan $planName
		$appWithSlotName = "$appname/$slot1name"

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		# Create deployment slot 2
		$slot2 = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slot2name -AppServicePlan $planName
		$appWithSlotName = "$appname/$slot2name"

		# Assert
		Assert-AreEqual $appWithSlotName $slot2.Name
		Assert-AreEqual $serverFarm.Id $slot2.ServerFarmId

		# Create new server Farm
		$serverFarm2 = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $destPlanName -Location  $destLocation -Tier $tier

		# Clone web app
		$webapp2 = New-AzWebApp -ResourceGroupName $rgname -Name $destAppName -Location $destLocation -AppServicePlan $destPlanName -SourceWebApp $webapp -IncludeSourceWebAppSlots
		
		# Assert
		Assert-AreEqual $destAppName $webapp2.Name

		# Get new web app
		$webapp2 = Get-AzWebApp -ResourceGroupName $rgname -Name $destAppName
		
		# Assert
		Assert-AreEqual $destAppName $webapp2.Name

		# Get new web app slot1
		$slot1 = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $destAppName -Slot $slot1name

		$appWithSlotName = "$destAppName/$slot1name"

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm2.Id $slot1.ServerFarmId

		# Get new web app slot1
		$slot2 = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $destAppName -Slot $slot2name
		$appWithSlotName = "$destAppName/$slot2name"

		# Assert
		Assert-AreEqual $appWithSlotName $slot2.Name
		Assert-AreEqual $serverFarm2.Id $slot2.ServerFarmId
	}
	finally
	{
		# Cleanup
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slot1name -Force
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slot2name -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force

		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $destAppName -Slot $slot1name -Force
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $destAppName -Slot $slot2name -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $destAppName -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $destPlanName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$actual = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get new web app
		$result = Get-AzWebApp -ResourceGroupName $rgname -Name $wname
		
		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId

		# Create new server Farm
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $destAppServicePlanName -Location  $destLocation -Tier $tier

		# Clone web app
		$actual = New-AzWebApp -ResourceGroupName $rgname -Name $destWebAppName -Location $destLocation -AppServicePlan $destAppServicePlanName -SourceWebApp $result -TrafficManagerProfileName $profileName
		
		# Assert
		Assert-AreEqual $destWebAppName $actual.Name

		# Get new web app
		$result = Get-AzWebApp -ResourceGroupName $rgname -Name $destWebAppName
		
		# Assert
		Assert-AreEqual $destWebAppName $result.Name
	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force

		Remove-AzWebApp -ResourceGroupName $rgname -Name $destWebAppName -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $destAppServicePlanName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
	$tag= @{"TagKey" = "TagValue"}
	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$job = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -Tag $tag -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId
		Assert-AreEqual $tag.Keys $actual.Tags.Keys
                Assert-AreEqual $tag.Values $actual.Tags.Values

		# Get new web app
		$result = Get-AzWebApp -ResourceGroupName $rgname -Name $wname
		
		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId
	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
	$location = "East US 2"
	$whpName = Get-WebHostPlanName
	$tier = "PremiumV3"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
    $containerImageName = "psunittesting.azurecr.io/webapplication3:latest"
    $containerRegistryUrl = "https://psunittesting.azurecr.io"
    $containerRegistryUser ="psunittesting"
    $pass = "L/kYXsr5m2WtSMWSRxKOcwI0xPJrMmETWpY475GA2i+ACRA2WfC9"
    $containerRegistryPassword = ConvertTo-SecureString -String $pass -AsPlainText -Force
    $dockerPrefix = "DOCKER|" 


	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier -WorkerSize Small -HyperV
		
		# Create new web app
		$job = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -ContainerImageName $containerImageName -ContainerRegistryUrl $containerRegistryUrl -ContainerRegistryUser $containerRegistryUser -ContainerRegistryPassword $containerRegistryPassword -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get new web app
		$result = Get-AzWebApp -ResourceGroupName $rgname -Name $wname
		
		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId
        Assert-AreEqual $true $result.IsXenon
        Assert-AreEqual ($dockerPrefix + $containerImageName)  $result.SiteConfig.WindowsFxVersion

        $appSettings = @{
        "DOCKER_REGISTRY_SERVER_URL" = $containerRegistryUrl;
        "DOCKER_REGISTRY_SERVER_USERNAME" = $containerRegistryUser;
        "DOCKER_REGISTRY_SERVER_PASSWORD" = $pass;}

        foreach($nvp in $result.SiteConfig.AppSettings)
		{
			Assert-True { $appSettings.Keys -contains $nvp.Name }
			Assert-AreEqual $appSettings[$nvp.Name] $nvp.Value
		}

	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests changing registry credentials for a Windows Container app
.DESCRIPTION
SmokeTest
#>
function Test-SetWebAppHyperVCredentials
{
		# Setup
		$rgname = Get-ResourceGroupName
		$wname = Get-WebsiteName
		$location = "East US 2"
		$whpName = Get-WebHostPlanName
		$tier = "PremiumV3"
		$apiversion = "2015-08-01"
		$resourceType = "Microsoft.Web/sites"
		$containerImageName = "psunittesting.azurecr.io/webapplication3:latest"
		$containerRegistryUrl = "https://psunittesting.azurecr.io"
		$containerRegistryUser = "psunittesting"
		$pass = "L/kYXsr5m2WtSMWSRxKOcwI0xPJrMmETWpY475GA2i+ACRA2WfC9"
		$containerRegistryPassword = ConvertTo-SecureString -String $pass -AsPlainText -Force
		$dockerPrefix = "DOCKER|" 
	
	
		try
		{
			#Setup
			New-AzResourceGroup -Name $rgname -Location $location
			$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier -WorkerSize Small -HyperV
			
			# Create new web app
			$job = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -ContainerImageName $containerImageName -ContainerRegistryUrl $containerRegistryUrl -ContainerRegistryUser $containerRegistryUser -ContainerRegistryPassword $containerRegistryPassword -AsJob
			$job | Wait-Job
			$actual = $job | Receive-Job
			
			# Assert
			Assert-AreEqual $wname $actual.Name
			Assert-AreEqual $serverFarm.Id $actual.ServerFarmId
	
			# Get new web app
			$result = Get-AzWebApp -ResourceGroupName $rgname -Name $wname
			
			# Assert
			Assert-AreEqual $wname $result.Name
			Assert-AreEqual $serverFarm.Id $result.ServerFarmId
			Assert-AreEqual $true $result.IsXenon
			Assert-AreEqual ($dockerPrefix + $containerImageName)  $result.SiteConfig.WindowsFxVersion			

			$appSettings = @{
			"DOCKER_REGISTRY_SERVER_URL" = $containerRegistryUrl;
			"DOCKER_REGISTRY_SERVER_USERNAME" = $containerRegistryUser;
			"DOCKER_REGISTRY_SERVER_PASSWORD" = $pass;}
	
			foreach($nvp in $result.SiteConfig.AppSettings)
			{
				Assert-True { $appSettings.Keys -contains $nvp.Name }
				Assert-AreEqual $appSettings[$nvp.Name] $nvp.Value
			}

			$updatedContainerImageName = "microsoft/iis:latest"

			# Change the webapp's container image to a public image and remove the credentials
			$updateJob = Set-AzWebApp -ResourceGroupName $rgname -Name $wname -ContainerImageName $updatedContainerImageName -ContainerRegistryUrl '' -ContainerRegistryUser '' -ContainerRegistryPassword $null -AsJob
			$updateJob | Wait-Job
			$updated = $updateJob | Receive-Job

			# Get updated web app
			$updatedWebApp = Get-AzWebApp -ResourceGroupName $rgname -Name $wname

			# Assert that container image has been updated
			Assert-AreEqual ($dockerPrefix + $updatedContainerImageName)  $updatedWebApp.SiteConfig.WindowsFxVersion

			# Assert that registry credentials have been removed
			foreach($nvp in $updatedWebApp.SiteConfig.AppSettings)
			{
				Assert-False { $appSettings.Keys -contains $nvp.Name}
			}

			# Create a slot
			$slotName = "stagingslot"
			$slotJob = New-AzWebAppSlot -ResourceGroupName $rgname -AppServicePlan $whpName -Name $wname -slot $slotName -ContainerImageName $containerImageName -ContainerRegistryUrl $containerRegistryUrl -ContainerRegistryUser $containerRegistryUser -ContainerRegistryPassword $containerRegistryPassword -AsJob
			$slotJob | Wait-Job
			$actualSlot = $slotJob | Receive-Job

			# Assert
			$appWithSlotName = "$wname/$slotName"
			Assert-AreEqual $appWithSlotName $actualSlot.Name

			# Get deployment slot
			$slot = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotName

			# Assert app settings in slot
			foreach($nvp in $slot.SiteConfig.AppSettings)
			{
				Assert-True { $appSettings.Keys -contains $nvp.Name }
				Assert-AreEqual $appSettings[$nvp.Name] $nvp.Value
			}

			# Change the slot's  container image to a public image and remove the credentials
			$updateSlotJob = Set-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotName -ContainerImageName $updatedContainerImageName -ContainerRegistryUrl '' -ContainerRegistryUser '' -ContainerRegistryPassword $null -AsJob
			$updateSlotJob | Wait-Job
			$updatedSlot = $updateSlotJob | Receive-Job

			# Get updated slot
			$updatedWebAppSlot = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotName

			# Assert that container image has been updated
			Assert-AreEqual ($dockerPrefix + $updatedContainerImageName)  $updatedWebAppSlot.SiteConfig.WindowsFxVersion

			# Assert that registry credentials have been removed from the slot
			foreach($nvp in $updatedWebAppSlot.SiteConfig.AppSettings)
			{
				Assert-False { $appSettings.Keys -contains $nvp.Name}
			}

		}
		finally
		{
			# Cleanup
			Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force
			Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
			Remove-AzResourceGroup -Name $rgname -Force
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
	$location = 'East US 2'
	$whpName = Get-WebHostPlanName
	$tier = "PremiumV3"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
    $containerImageName = "psunittesting.azurecr.io/webapplication3:latest"
    $containerRegistryUrl = "https://psunittesting.azurecr.io"
    $containerRegistryUser = "psunittesting"
    $pass = "L/kYXsr5m2WtSMWSRxKOcwI0xPJrMmETWpY475GA2i+ACRA2WfC9"
    $containerRegistryPassword = ConvertTo-SecureString -String $pass -AsPlainText -Force
    $dockerPrefix = "DOCKER|"
 	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier -WorkerSize Small -HyperV

		# Create new web app
		$job = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -ContainerImageName $containerImageName -ContainerRegistryUrl $containerRegistryUrl -ContainerRegistryUser $containerRegistryUser -ContainerRegistryPassword $containerRegistryPassword -EnableContainerContinuousDeployment -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId
 		# Get new web app
		$result = Get-AzWebApp -ResourceGroupName $rgname -Name $wname

		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId
        Assert-AreEqual $true $result.IsXenon
        Assert-AreEqual ($dockerPrefix + $containerImageName)  $result.SiteConfig.WindowsFxVersion
         $appSettings = @{
        "DOCKER_REGISTRY_SERVER_URL" = $containerRegistryUrl;
        "DOCKER_REGISTRY_SERVER_USERNAME" = $containerRegistryUser;
        "DOCKER_REGISTRY_SERVER_PASSWORD" = $pass;
        "DOCKER_ENABLE_CI" = "true"}
         foreach($nvp in $webApp.SiteConfig.AppSettings)
		{
			Assert-True { $appSettings.Keys -contains $nvp.Name }
			Assert-True { $appSettings[$nvp.Name] -match $nvp.Value }
		}

         $ci_url = Get-AzWebAppContainerContinuousDeploymentUrl -ResourceGroupName $rgname -Name $wname

		 $expression = "https://" + $wname + ":(.*)@" + $wname + ".scm.azurewebsites.net/docker/hook"
		 $sanitizedCiUrl = { $ci_url -replace '$','' }

		 $matchResult = { $sanitizedCiUrl -match $expression }

		 Assert-AreEqual $true $matchResult
 	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}


<#
.SYNOPSIS
Tests setting and Azure Storage Account in a new Windows container app.
.DESCRIPTION
SmokeTest
#>
function Test-SetAzureStorageWebAppHyperV
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = 'East US 2'
	$whpName = Get-WebHostPlanName
	$tier = "PremiumV3"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
    $containerImageName = "psunittesting.azurecr.io/webapplication3:latest"
	$containerRegistryUrl = "https://psunittesting.azurecr.io"
	$containerRegistryUser = "psunittesting"
	$pass = "L/kYXsr5m2WtSMWSRxKOcwI0xPJrMmETWpY475GA2i+ACRA2WfC9"
    $containerRegistryPassword = ConvertTo-SecureString -String $pass -AsPlainText -Force
    $dockerPrefix = "DOCKER|" 
	$azureStorageAccountCustomId1 = "mystorageaccount"
	$azureStorageAccountType1 = "AzureFiles"
	$azureStorageAccountName1 = "myaccountname"
	$azureStorageAccountShareName1 = "myremoteshare"
	$azureStorageAccountAccessKey1 = "AnAccessKey"
	$azureStorageAccountMountPath1 = "/mymountpath"
	$azureStorageAccountCustomId2 = "mystorageaccount2"
	$azureStorageAccountType2 = "AzureFiles"
	$azureStorageAccountName2 = "myaccountname2"
	$azureStorageAccountShareName2 = "myremoteshare2"
	$azureStorageAccountAccessKey2 = "AnAccessKey2"
	$azureStorageAccountMountPath2 = "/mymountpath2"

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier -WorkerSize Small -HyperV
		
		# Create new web app
		$job = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -ContainerImageName $containerImageName -ContainerRegistryUrl $containerRegistryUrl -ContainerRegistryUser $containerRegistryUser -ContainerRegistryPassword $containerRegistryPassword -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get new web app
		$result = Get-AzWebApp -ResourceGroupName $rgname -Name $wname
		
		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId
        Assert-AreEqual $true $result.IsXenon
        Assert-AreEqual ($dockerPrefix + $containerImageName)  $result.SiteConfig.WindowsFxVersion

		$testStorageAccount1 = New-AzWebAppAzureStoragePath -Name $azureStorageAccountCustomId1 -Type $azureStorageAccountType1 -AccountName $azureStorageAccountName1 -ShareName $azureStorageAccountShareName1 -AccessKey $azureStorageAccountAccessKey1 -MountPath $azureStorageAccountMountPath1
		$testStorageAccount2 = New-AzWebAppAzureStoragePath -Name $azureStorageAccountCustomId2 -Type $azureStorageAccountType2 -AccountName $azureStorageAccountName2 -ShareName $azureStorageAccountShareName2 -AccessKey $azureStorageAccountAccessKey2 -MountPath $azureStorageAccountMountPath2

		Write-Debug "Created the new storage account paths"

		Write-Debug $testStorageAccount1.Name
		Write-Debug $testStorageAccount2.Name


		# set Azure Storage accounts
        $webApp = Set-AzWebApp -ResourceGroupName $rgname -Name $wname -AzureStoragePath $testStorageAccount1, $testStorageAccount2

		Write-Debug "Set the new storage account paths"


		# get the web app
		$result = Get-AzWebApp -ResourceGroupName $rgname -Name $wname
		$azureStorageAccounts = $result.AzureStoragePath

		# Assert
		Write-Debug $azureStorageAccounts[0].Name
		Assert-AreEqual $azureStorageAccounts[0].Name $azureStorageAccountCustomId1

		Write-Debug $azureStorageAccounts[0].Type
		Assert-AreEqual $azureStorageAccounts[0].Type $azureStorageAccountType1
		
		Write-Debug $azureStorageAccounts[0].AccountName
		Assert-AreEqual $azureStorageAccounts[0].AccountName $azureStorageAccountName1
		
		Write-Debug $azureStorageAccounts[0].ShareName
		Assert-AreEqual $azureStorageAccounts[0].ShareName $azureStorageAccountShareName1
		
		Write-Debug $azureStorageAccounts[0].AccessKey 
		Assert-AreEqual $azureStorageAccounts[0].AccessKey $azureStorageAccountAccessKey1
		
		Write-Debug $azureStorageAccounts[0].MountPath
		Assert-AreEqual $azureStorageAccounts[0].MountPath $azureStorageAccountMountPath1

		Write-Debug $azureStorageAccounts[1].Name
		Assert-AreEqual $azureStorageAccounts[1].Name $azureStorageAccountCustomId2

		Write-Debug $azureStorageAccounts[1].Type
		Assert-AreEqual $azureStorageAccounts[1].Type $azureStorageAccountType2

		Write-Debug $azureStorageAccounts[1].AccountName
		Assert-AreEqual $azureStorageAccounts[1].AccountName $azureStorageAccountName2

		Write-Debug $azureStorageAccounts[1].ShareName
		Assert-AreEqual $azureStorageAccounts[1].ShareName $azureStorageAccountShareName2

		Write-Debug $azureStorageAccounts[1].AccessKey
		Assert-AreEqual $azureStorageAccounts[1].AccessKey $azureStorageAccountAccessKey2

		Write-Debug $azureStorageAccounts[1].MountPath
		Assert-AreEqual $azureStorageAccounts[1].MountPath $azureStorageAccountMountPath2
	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
	$rgname = "RG-PS-UnitTesting"
	$wname = Get-WebsiteName
	$location = "Central US"
	$whpName = "ASP-PS-UnitTesting"
	$aseName = "ASE-PS-Unittesting"
	$resourceType = "Microsoft.Web/sites"
	$tag= @{"TagKey" = "TagValue"}
	try
	{
		#Setup
		$serverFarm = Get-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName

		# Create new web app
		$job = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -AseName $aseName -Tag $tag -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId
		Assert-AreEqual $tag.Keys $actual.Tags.Keys
        Assert-AreEqual $tag.Values $actual.Tags.Values

		# Get new web app
		$result = Get-AzWebApp -ResourceGroupName $rgname -Name $wname
		
		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId
	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $wname -Force
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
	$rgname1 = Get-ResourceGroupName
	$webAppName = Get-WebsiteName
	$location = Get-WebLocation
	$appServicePlanName1 = Get-WebHostPlanName
	$appServicePlanName2 = Get-WebHostPlanName
	$appServicePlanName3 = Get-WebHostPlanName
	$tier1 = "Shared"
	$tier2 = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	$capacity = 2
	$HN="custom.domain.com"

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm1 = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $appServicePlanName1 -Location  $location -Tier $tier1
		$serverFarm2 = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $appServicePlanName2 -Location  $location -Tier $tier2
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $webAppName -Location $location -AppServicePlan $appServicePlanName1 
		Write-Debug "DEBUG: Created the Web App"

		# Assert
		Assert-AreEqual $webAppName $webApp.Name
		Assert-AreEqual $serverFarm1.Id $webApp.ServerFarmId
		Assert-Null $webApp.Identity
		Assert-NotNull $webApp.SiteConfig.phpVersion
		Assert-AreEqual $false $webApp.HttpsOnly
		Assert-AreEqual "FtpsOnly" $webApp.SiteConfig.FtpsState
		
		# Change service plan & set site properties
		$job = Set-AzWebApp -ResourceGroupName $rgname -Name $webAppName -AppServicePlan $appServicePlanName2 -HttpsOnly $true -AlwaysOn $false -AsJob
		$job | Wait-Job
		$webApp = $job | Receive-Job

		Write-Debug "DEBUG: Changed service plan"

		# Assert
		Assert-AreEqual $webAppName $webApp.Name
		Assert-AreEqual $serverFarm2.Id $webApp.ServerFarmId
		Assert-AreEqual $true $webApp.HttpsOnly
		Assert-AreEqual $false $webapp.SiteConfig.AlwaysOn

		# Set config properties
		$webapp.SiteConfig.HttpLoggingEnabled = $true
		$webapp.SiteConfig.RequestTracingEnabled = $true
		$webapp.SiteConfig.FtpsState = "AllAllowed"
		$webApp.SiteConfig.MinTlsVersion = "1.0"
		$webApp.SiteConfig.HealthCheckPath = "/api/path"

		# Set site properties
		$webApp = $webApp | Set-AzWebApp

		Write-Debug "DEBUG: Changed site properties"

		# Assert
		Assert-AreEqual $webAppName $webApp.Name
		Assert-AreEqual $serverFarm2.Id $webApp.ServerFarmId
		Assert-AreEqual $true $webApp.SiteConfig.HttpLoggingEnabled
		Assert-AreEqual $true $webApp.SiteConfig.RequestTracingEnabled
		Assert-AreEqual $false $webApp.SiteConfig.AlwaysOn
		Assert-AreEqual "AllAllowed" $webApp.SiteConfig.FtpsState
		Assert-AreEqual "1.0" $webApp.SiteConfig.MinTlsVersion
		Assert-AreEqual "/api/path" $webApp.SiteConfig.HealthCheckPath
		 
		$appSettings = @{ "setting1" = "valueA"; "setting2" = "valueB"}
		$connectionStrings = @{ connstring1 = @{ Type="MySql"; Value="string value 1"}; connstring2 = @{ Type = "SQLAzure"; Value="string value 2"}}

        # set app settings and assign Identity
        $webApp = Set-AzWebApp -ResourceGroupName $rgname -Name $webAppName -AppSettings $appSettings -AssignIdentity $true -MinTlsVersion "1.2"

        # Assert
        Assert-NotNull  $webApp.Identity
        # AssignIdentity adds an appsetting to handle enabling / disabling AssignIdentity
        Assert-AreEqual ($appSettings.Keys.Count) $webApp.SiteConfig.AppSettings.Count
        Assert-NotNull  $webApp.Identity
		Assert-AreEqual "1.2" $webApp.SiteConfig.MinTlsVersion

        # set app settings and connection strings
		$webApp = Set-AzWebApp -ResourceGroupName $rgname -Name $webAppName -AppSettings $appSettings -ConnectionStrings $connectionStrings -NumberofWorkers $capacity -PhpVersion "off"

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
		Assert-AreEqual "1.2" $webApp.SiteConfig.MinTlsVersion

		# set Custom Host Name(s)- Failed Scenario
		$oldWebApp= Get-AzWebApp -ResourceGroupName $rgname -Name $webAppName
		$CurrentWebApp = Set-AzWebApp -ResourceGroupName $rgname -Name $webAppName -HostNames $HN
		#Assert
		$status
		foreach($oldHN in $oldWebApp.HostNames)
		{
		Assert-True { $CurrentWebApp.HostNames -contains $oldHN }
		}

		#Set-AzWebApp errors on operations for App Services not in the same resource group as the App Service Plan
		#setup
		## Create a Resource Group.
		New-AzResourceGroup -Name $rgname1 -Location $location

		## Create the App Service Plan in $rgname.
		$asp = New-AzAppServicePlan -Location $location -Tier Standard -NumberofWorkers 1 -WorkerSize Small -ResourceGroupName $rgname -Name $appServicePlanName3

		## Create a Web App in each Resource Group.
		$app1 = Get-WebsiteName
		$app2 = Get-WebsiteName

		New-AzWebApp -ResourceGroupName $rgname -Name $app1 -Location $location -AppServicePlan $asp.Id
		New-AzWebApp -ResourceGroupName $rgname1 -Name $app2 -Location $location -AppServicePlan $asp.Id

		## Get the two Web Apps.
		$wa1 = Get-AzWebApp -ResourceGroupName $rgname -Name $app1
		$wa2 = Get-AzWebApp -ResourceGroupName $rgname1 -Name $app2

		## Change a setting on the first Web App (which is in the same Resource Group as the App Service Plan).
		$currentWa1ClientAffinityEnabled=$wa1.ClientAffinityEnabled
		$wa1.ClientAffinityEnabled = !$wa1.ClientAffinityEnabled
		$wa1 | Set-AzWebApp

		#Assert
		Assert-AreNotEqual $currentWa1ClientAffinityEnabled $wa1.ClientAffinityEnabled
		## Change a setting on the first Web App (which is in the same Resource Group as the App Service Plan).
		$currentWa2ClientAffinityEnabled=$wa2.ClientAffinityEnabled
		$wa2.ClientAffinityEnabled = !$wa2.ClientAffinityEnabled
		$wa2 | Set-AzWebApp

		#Assert
		Assert-AreNotEqual $currentWa2ClientAffinityEnabled $wa2.ClientAffinityEnabled
	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $webAppName -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $appServicePlanName1 -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $appServicePlanName2 -Force
		Remove-AzResourceGroup -Name $rgname -Force
		Remove-AzResourceGroup -Name $rgname1 -Force
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
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzWebApp -ResourceGroupName $rgname -Name $appName -Location $location -AppServicePlan $planName
		
		# Assert
		Assert-AreEqual $appName $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Remove web app via pipeline obj
		$webapp | Remove-AzWebApp -Force -AsJob | Wait-Job

		# Retrieve web app by name
		# TODO: Temporarily changed the call below to use parentheses around the Get,
		# since an issue exists currently that causes the test to fail.
		# https://github.com/Azure/azure-powershell/issues/5174
		$webappNames = (Get-AzWebApp -ResourceGroupName $rgname) | Select -Property Name

		Assert-False { $webappNames -contains $appName }
	}
	finally
	{
		# Cleanup
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzWebApp -ResourceGroupName $rgname -Name $appName -Location $location -AppServicePlan $planName 
		
		# Assert
		Assert-AreEqual $appName $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Get web app publishing profile
		[xml]$profile = Get-AzWebAppPublishingProfile -ResourceGroupName $rgname -Name $appName -OutputFile $profileFileName
		$msDeployProfile = $profile.publishData.publishProfile | ? { $_.publishMethod -eq 'MSDeploy' } | Select -First 1
		$pass = $msDeployProfile.userPWD

		# Assert
		Assert-True { $msDeployProfile.msdeploySite -eq $appName }

		# Reset web app publishing profile
		$newPass = $webapp | Reset-AzWebAppPublishingProfile 

		# Assert
		Assert-False { $pass -eq $newPass }

		# Get web app publishing profile
		[xml]$profile = $webapp | Get-AzWebAppPublishingProfile -OutputFile $profileFileName -Format FileZilla3
		$fileZillaProfile = $profile.FileZilla3.Servers.Server

		# Assert
		Assert-True { $fileZillaProfile.Name -eq $appName }

		# Get web app publishing profile without OutputFile
		[xml]$profile = Get-AzWebAppPublishingProfile -ResourceGroupName $rgname -Name $appName

		# Assert
		Assert-NotNull $profile

	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $appName -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

# Keep existing test to ensure backwards compatibility with existing behavior
function Test-PublishAzureWebAppFromZip
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appName = Get-WebsiteName
	$location = Get-WebLocation
	$planName = Get-WebHostPlanName
	$tier = "Shared"

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzureRmWebApp -ResourceGroupName $rgname -Name $appName -Location $location -AppServicePlan $planName 
		
		$zipPath = Join-Path $ResourcesPath "nodejs-sample.zip"
		$publishedApp = Publish-AzWebApp -ResourceGroupName $rgname -Name $appName -ArchivePath $zipPath -Force

		Assert-NotNull $publishedApp
	}
	finally
	{
		# Cleanup
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

# Keep existing test to ensure backwards compatibility with existing behavior
function Test-PublishAzureWebAppFromWar
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appName = Get-WebsiteName
	$location = Get-WebLocation
	$planName = Get-WebHostPlanName
	$tier = "Shared"

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzureRmWebApp -ResourceGroupName $rgname -Name $appName -Location $location -AppServicePlan $planName 
		
		#Configuring jdk and web container
        # Set Java runtime to 1.8 | Tomcat. In order to deploy war, site should be configured to run with stack = TOMCAT 
		# or JBOSSEAP (only availble on Linux). In this test case, it creates Windows app. 
		$javaVersion="1.8"
        $javaContainer="TOMCAT"
        $javaContainerVersion="8.5"
        $PropertiesObject = @{javaVersion = $javaVersion;javaContainer = $javaContainer;javaContainerVersion = $javaContainerVersion}
        New-AzResource -PropertyObject $PropertiesObject -ResourceGroupName $rgname -ResourceType Microsoft.Web/sites/config -ResourceName "$appName/web" -ApiVersion 2018-02-01 -Force

		$warPath = Join-Path $ResourcesPath "HelloJava.war"
		$publishedApp = Publish-AzWebApp -ResourceGroupName $rgname -Name $appName -ArchivePath $warPath -Force

		Assert-NotNull $publishedApp
	}
	finally
	{
		# Cleanup
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

# New tests for PublishAzureWebApp to test deploying against newer Onedeploy endpoint
function Test-PublishAzureWebAppOnedeploy
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appName = Get-WebsiteName
	$location = Get-WebLocation
	$planName = Get-WebHostPlanName
	$tier = "Shared"

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzureRmWebApp -ResourceGroupName $rgname -Name $appName -Location $location -AppServicePlan $planName 
		
		#Configuring jdk and web container
        # Set Java runtime to 1.8 | Tomcat. In order to deploy war, site should be configured to run with stack = TOMCAT 
		# or JBOSSEAP (only availble on Linux). In this test case, it creates Windows app. 
		$javaVersion="1.8"
        $javaContainer="TOMCAT"
        $javaContainerVersion="8.5"
        $PropertiesObject = @{javaVersion = $javaVersion;javaContainer = $javaContainer;javaContainerVersion = $javaContainerVersion}
        New-AzResource -PropertyObject $PropertiesObject -ResourceGroupName $rgname -ResourceType Microsoft.Web/sites/config -ResourceName "$appName/web" -ApiVersion 2018-02-01 -Force

		$warPath = Join-Path $ResourcesPath "HelloJava.war"
		$publishedApp = Publish-AzWebApp -ResourceGroupName $rgname -Name $appName -ArchivePath $warPath -Type war -Clean $true -TargetPath /home/site/wwwroot/webapps/ROOT -Force

		Assert-NotNull $publishedApp
	}
	finally
	{
		# Cleanup
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
		$webapp = New-AzWebApp -Name $appName

		Assert-AreEqual $appName $webapp.Name
	}
	finally
	{
		Remove-AzResourceGroup $appName
	}
}

<#
.SYNOPSIS
Tests Tags are not overridden when calling Set-AzWebApp commandlet
#>
function Test-TagsNotRemovedBySetWebApp
{
	$rgname = "RG-PS-UnitTesting"
	$appname = "AppService-PS-UnitTesting" # this is an existing app with existing tags
	$slot = "testslot"
	$aspName = "ASP-PS-UnitTesting"
	$aspToMove = "ASP-PS-UnitTesting1"

	$getApp =  Get-AzWebApp -ResourceGroupName $rgname -Name $appname
	$getSlot = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slot
	Assert-notNull $getApp.Tags
	Assert-notNull $getSlot.Tags

	# Test - tags not removed after Set-AzWebApp
	$webApp = Set-AzWebApp -ResourceGroupName $rgname -Name $appname -HttpsOnly $true
	$slot = Set-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slot -HttpsOnly $true

	Assert-AreEqual $true $webApp.HttpsOnly
	Assert-AreEqual $true $slot.HttpsOnly

	Assert-notNull $webApp.Tags
	Assert-notNull $slot.Tags

	# Test - tags not removed after using Set-AzWebApp with WebApp parameter
	$webapp =  Set-AzWebApp  -WebApp $getApp
	Assert-notNull $webApp.Tags

	$webapp = Set-AzWebApp -Name $appname -ResourceGroupName $rgname -AppServicePlan $aspToMove
	# verify that App has been successfully moved to the new ASP
	$asp = Get-AzAppServicePlan -ResourceGroupName $rgname -Name $aspToMove
	Assert-AreEqual $webApp.ServerFarmId $asp.id
	# verify tags are not removed after ASP move
	Assert-notNull $webApp.Tags

	# Move it back to the original ASP
	$webApp = Set-AzWebApp -Name $appname -ResourceGroupName $rgname -AppServicePlan $aspName
	$asp = Get-AzAppServicePlan -ResourceGroupName $rgname -Name $aspName
	Assert-AreEqual $webApp.ServerFarmId $asp.id
	Assert-notNull $webApp.Tags
}
