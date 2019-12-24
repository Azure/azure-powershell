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
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName 
		
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
		$metrics = Get-AzWebAppMetrics -ResourceGroupName $rgname -Name $wname -Metrics $metricnames -StartTime $startTime -EndTime $endTime -Granularity PT1M

		$actualMetricNames = $metrics | Select -Expand Name | Select -Expand Value 

		foreach ($i in $metricnames)
		{
			Assert-True { $actualMetricNames -contains $i}
		}

		# Get web app metrics via pipeline obj
		$metrics = $webapp | Get-AzWebAppMetrics -Metrics $metricnames -StartTime $startTime -EndTime $endTime -Granularity PT1M

		$actualMetricNames = $metrics | Select -Expand Name | Select -Expand Value 

		foreach ($i in $metricnames)
		{
			Assert-True { $actualMetricNames -contains $i}
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
		$ping = PingWebApp $webApp

		# Start web app
		$webApp = $webApp | Start-AzWebApp

		Assert-AreEqual "Running" $webApp.State
		$ping = PingWebApp $webApp

		# Stop web app
		$webApp = Stop-AzWebApp -ResourceGroupName $rgname -Name $wname

		Assert-AreEqual "Stopped" $webApp.State
		$ping = PingWebApp $webApp

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
	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier
		
		# Create new web app
		$job = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -AsJob
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
	$rgname = "appdemorg"
	$wname = Get-WebsiteName
	$location = "West US"
	$whpName = "travelproductionplan"
	$aseName = "asedemops"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		$serverFarm = Get-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName

		# Create new web app
		$job = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -AseName $aseName -AsJob
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
		
		# Change service plan & set site properties
		$job = Set-AzWebApp -ResourceGroupName $rgname -Name $webAppName -AppServicePlan $appServicePlanName2 -HttpsOnly $true -AsJob
		$job | Wait-Job
		$webApp = $job | Receive-Job

		# Assert
		Assert-AreEqual $webAppName $webApp.Name
		Assert-AreEqual $serverFarm2.Id $webApp.ServerFarmId
		Assert-AreEqual $true $webApp.HttpsOnly
		Assert-NotNull  $webApp.Identity

		# Set config properties
		$webapp.SiteConfig.HttpLoggingEnabled = $true
		$webapp.SiteConfig.RequestTracingEnabled = $true

		# Set site properties
		$webApp = $webApp | Set-AzWebApp

		# Assert
		Assert-AreEqual $webAppName $webApp.Name
		Assert-AreEqual $serverFarm2.Id $webApp.ServerFarmId
		Assert-AreEqual $true $webApp.SiteConfig.HttpLoggingEnabled
		Assert-AreEqual $true $webApp.SiteConfig.RequestTracingEnabled

		# set app settings and connection strings
		$appSettings = @{ "setting1" = "valueA"; "setting2" = "valueB"}
		$connectionStrings = @{ connstring1 = @{ Type="MySql"; Value="string value 1"}; connstring2 = @{ Type = "SQLAzure"; Value="string value 2"}}

        $webApp = Set-AzWebApp -ResourceGroupName $rgname -Name $webAppName -AppSettings $appSettings -ConnectionStrings $connectionStrings -NumberofWorkers $capacity

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

		Assert-AreEqual $capacity $webApp.SiteConfig.NumberOfWorkers

	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $webAppName -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $appServicePlanName1 -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $appServicePlanName2 -Force
		Remove-AzResourceGroup -Name $rgname -Force
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