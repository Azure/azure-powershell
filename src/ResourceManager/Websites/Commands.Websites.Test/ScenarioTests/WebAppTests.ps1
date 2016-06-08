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
#>
function Test-GetWebApp
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$wname2 = Get-WebsiteName
	$location = Get-Location
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
	$location = Get-Location
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
	$location = Get-Location
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
	$location = Get-Location
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
	$location = Get-Location
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
	$location = Get-Location
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
#>
function Test-CreateNewWebApp
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$location = Get-Location
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
Tests creating a new website on an ase
#>
function Test-CreateNewWebAppOnAse
{
	# Setup
	$rgname = "appdemorg"
	$wname = Get-WebsiteName
	$location = "West US"
	$whpName = "travel_production_plan"
	$aseName = "asedemo"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		$serverFarm = Get-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $whpName

		# Create new web app
		$actual = New-AzureRmWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -AseName $aseName
		
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
#>
function Test-SetWebApp
{
	# Setup
	$rgname = Get-ResourceGroupName
	$webAppName = Get-WebsiteName
	$location = Get-Location
	$appServicePlanName1 = Get-WebHostPlanName
	$appServicePlanName2 = Get-WebHostPlanName
	$tier1 = "Shared"
	$tier2 = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

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
		
		# Change service plan
		$webApp = Set-AzureRmWebApp -ResourceGroupName $rgname -Name $webAppName -AppServicePlan $appServicePlanName2

		# Assert
		Assert-AreEqual $webAppName $webApp.Name
		Assert-AreEqual $serverFarm2.Id $webApp.ServerFarmId

		# Set config properties
		$webapp.SiteConfig.HttpLoggingEnabled = $true
		$webapp.SiteConfig.RequestTracingEnabled = $true

		$webApp = $webApp | Set-AzureRmWebApp

		# Assert
		Assert-AreEqual $webAppName $webApp.Name
		Assert-AreEqual $serverFarm2.Id $webApp.ServerFarmId
		Assert-AreEqual $true $webApp.SiteConfig.HttpLoggingEnabled
		Assert-AreEqual $true $webApp.SiteConfig.RequestTracingEnabled

		# set app settings and connection strings
		$appSettings = @{ "setting1" = "valueA"; "setting2" = "valueB"}
		$connectionStrings = @{ connstring1 = @{ Type="MySql"; Value="string value 1"}; connstring2 = @{ Type = "SQLAzure"; Value="string value 2"}}

		$webApp = Set-AzureRmWebApp -ResourceGroupName $rgname -Name $webAppName -AppSettings $appSettings -ConnectionStrings $connectionStrings

		# Assert
		Assert-AreEqual $webAppName $webApp.Name
		Assert-AreEqual $appSettings.Keys.Count $webApp.SiteConfig.AppSettings.Count
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
#>
function Test-RemoveWebApp
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appName = Get-WebsiteName
	$location = Get-Location
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
		$webapp | Remove-AzureRmWebApp -Force

		# Retrieve web app by name
		$webappNames = Get-AzureRmWebApp -ResourceGroupName $rgname | Select -expand Name

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
	$location = Get-Location
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
	}
    finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}