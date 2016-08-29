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
function Test-GetWebAppSlot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$slotname1 = "staging"
	$slotname2 = "testing"
	$location = Get-Location
	$planName = Get-WebHostPlanName
	$tier = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

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
		
		# Create new deployment slot
		$slot1 = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname1 -AppServicePlan $planName 
		$appWithSlotName1 = "$appname/$slotname1"

		# Assert
		Assert-AreEqual $appWithSlotName1 $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		# Get deployment slot
		$slot1 = Get-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname1

		# Assert
		Assert-AreEqual $appWithSlotName1 $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		# Get deployment slot via pipeline obj
		$slot1 = $webapp | Get-AzureRmWebAppSlot -Slot $slotname1

		# Assert
		Assert-AreEqual $appWithSlotName1 $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		# Create new deployment slot 2
		$slot2 = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname2 -AppServicePlan $planName 
		$appWithSlotName2 = "$appname/$slotname2"

		# Assert
		Assert-AreEqual $appWithSlotName2 $slot2.Name
		Assert-AreEqual $serverFarm.Id $slot2.ServerFarmId

		# Get deployment slots
		$slots = Get-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname 
		$slotNames = $slots | Select -expand Name

		# Assert
		Assert-AreEqual 2 $slots.Count
		Assert-True { $slotNames -contains $appWithSlotName1 }
		Assert-True { $slotNames -contains $appWithSlotName2 }
	}
    finally
	{
		# Cleanup
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname1 -Force
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname2 -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests retrieving website metrics
#>
function Test-GetWebAppSlotMetrics
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$slotname = "staging"
	$location = Get-Location
	$planName = Get-WebHostPlanName
	$tier = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

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
		
		# Create new deployment slot
		$slot = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName 
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm.Id $slot.ServerFarmId

		for($i = 0; $i -lt 10; $i++)
		{
			PingWebApp $slot
		}

		$endTime = Get-Date
		$startTime = $endTime.AddHours(-3)

		$metricnames = @('CPU', 'Requests')
		
		# Get web app metrics
		$metrics = Get-AzureRmWebAppSlotMetrics -ResourceGroupName $rgname -Name $appname -Slot $slotname -Metrics $metricnames -StartTime $startTime -EndTime $endTime -Granularity PT1M

		$actualMetricNames = $metrics | Select -Expand Name | Select -Expand Value 

		foreach ($i in $metricnames)
		{
			Assert-True { $actualMetricNames -contains $i}
		}

		# Get web app metrics via pipeline obj
		$metrics = $slot | Get-AzureRmWebAppSlotMetrics -Metrics $metricnames -StartTime $startTime -EndTime $endTime -Granularity PT1M

		$actualMetricNames = $metrics | Select -Expand Name | Select -Expand Value 

		foreach ($i in $metricnames)
		{
			Assert-True { $actualMetricNames -contains $i}
		}
	}
    finally
	{
		# Cleanup
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Start stop restart web app
#>
function Test-StartStopRestartWebAppSlot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$slotname = "staging"
	$location = Get-Location
	$planName = Get-WebHostPlanName
	$tier = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName 
		
		# Assert
		Assert-AreEqual $appname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Create new deployment slot
		$slot = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName 
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm.Id $slot.ServerFarmId

		# Stop web app
		$slot = $slot | Stop-AzureRmWebAppSlot

		Assert-AreEqual "Stopped" $slot.State
		$ping = PingWebApp $slot

		# Start web app
		$slot = $slot | Start-AzureRmWebAppSlot

		Assert-AreEqual "Running" $slot.State
		$ping = PingWebApp $slot

		# Stop web app
		$slot = Stop-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname

		Assert-AreEqual "Stopped" $slot.State
		$ping = PingWebApp $slot

		# Start web app
		$slot = Start-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname

		Assert-AreEqual "Running" $slot.State
		$ping = PingWebApp $slot

		# Retart web app
		$slot = Restart-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname

		Assert-AreEqual "Running" $slot.State
		$ping = PingWebApp $slot

		# Restart web app
		$slot = $slot | Restart-AzureRmWebAppSlot

		Assert-AreEqual "Running" $slot.State
		$ping = PingWebApp $slot
	}
    finally
	{
		# Cleanup
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests clone a web app to a slot.
#>
function Test-CloneWebAppToSlot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$slotname = "staging"
	$location = Get-Location
	$planName = Get-WebHostPlanName
	$tier = "Premium"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

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

		# Clone web app to slot
		$slot = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName -SourceWebApp $webapp
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name

		# Get web app slot
		$slot = Get-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname
		
		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
	}
    finally
	{
		# Cleanup
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests clone a web app slot.
#>
function Test-CloneWebAppSlot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-Location
	$planName = Get-WebHostPlanName
	$slotname = "staging"
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

		# Create deployment slot
		$slot1 = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		# Create new server Farm
		$serverFarm2 = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $destPlanName -Location  $destLocation -Tier $tier

		# Create web app 2
		$webapp2 = New-AzureRmWebApp -ResourceGroupName $rgname -Name $destAppName -Location $destLocation -AppServicePlan $destPlanName
		
		# Assert
		Assert-AreEqual $destAppName $webapp2.Name
		Assert-AreEqual $serverFarm2.Id $webapp2.ServerFarmId

		# Clone web app to slot
		$slot2 = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $destAppName -Slot $slotname -AppServicePlan $planName -SourceWebApp $slot1
		$appWithSlotName2 = "$destAppName/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName2 $slot2.Name
	}
    finally
	{
		# Cleanup
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force

		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $destAppName -Slot $slotname -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $destAppName -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $destPlanName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests creating a new web app slot.
#>
function Test-CreateNewWebAppSlot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-Location
	$slotname = "staging"
	$planName = Get-WebHostPlanName
	$tier = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$actual = New-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName 
		
		# Assert
		Assert-AreEqual $appname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get new web app
		$result = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $appname
		
		# Assert
		Assert-AreEqual $appname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId

		# Create deployment slot
		$slot1 = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId
	}
    finally
	{
		# Cleanup
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests creating a new web app slot on ASE.
#>
function Test-CreateNewWebAppSlotOnAse
{
	# Setup
	$rgname = "appdemorg"
	$appname = Get-WebsiteName
	$slotname = "staging"
	$location = "West US"
	$planName = "travel_production_plan"
	$aseName = "asedemo"

	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		$serverFarm = Get-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName
		
		# Create new web app
		$actual = New-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName -AseName $aseName
		
		# Assert
		Assert-AreEqual $appname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get new web app
		$result = Get-AzureRmWebApp -ResourceGroupName $rgname -Name $appname
		
		# Assert
		Assert-AreEqual $appname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId

		# Create deployment slot
		$slot1 = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName -AseName $aseName
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		# Get new web app slot
		$slot1 = Get-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

	}
    finally
	{
		# Cleanup
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Force
    }
}

<#
.SYNOPSIS
Tests retrieving web app slots
#>
function Test-SetWebAppSlot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-Location
	$slotname = "staging"
	$planName1 = Get-WebHostPlanName
	$planName2 = Get-WebHostPlanName
	$tier1 = "Standard"
	$tier2 = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location
		$serverFarm1 = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName1 -Location  $location -Tier $tier1
		$serverFarm2 = New-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName2 -Location  $location -Tier $tier2
		
		# Create new web app
		$webApp = New-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName1 
		
		# Assert
		Assert-AreEqual $appname $webApp.Name
		Assert-AreEqual $serverFarm1.Id $webApp.ServerFarmId

		# Create deployment slot
		$slot = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName1
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm1.Id $slot.ServerFarmId
		
		# Change service plan
		$slot = Set-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName2

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm2.Id $slot.ServerFarmId

		# Set config properties
		$slot.SiteConfig.HttpLoggingEnabled = $true
		$slot.SiteConfig.RequestTracingEnabled = $true

		$slot = $slot | Set-AzureRmWebAppSlot

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm2.Id $slot.ServerFarmId
		Assert-AreEqual $true $slot.SiteConfig.HttpLoggingEnabled
		Assert-AreEqual $true $slot.SiteConfig.RequestTracingEnabled

		# set app settings and connection strings
		$appSettings = @{ "setting1" = "valueA"; "setting2" = "valueB"}
		$connectionStrings = @{ connstring1 = @{ Type="MySql"; Value="string value 1"}; connstring2 = @{ Type = "SQLAzure"; Value="string value 2"}}

		$slot = Set-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppSettings $appSettings -ConnectionStrings $connectionStrings

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $appSettings.Keys.Count $slot.SiteConfig.AppSettings.Count
		foreach($nvp in $slot.SiteConfig.AppSettings)
		{
			Assert-True { $appSettings.Keys -contains $nvp.Name }
			Assert-True { $appSettings[$nvp.Name] -match $nvp.Value }
		}

		Assert-AreEqual $connectionStrings.Keys.Count $slot.SiteConfig.ConnectionStrings.Count
		foreach($connStringInfo in $slot.SiteConfig.ConnectionStrings)
		{
			Assert-True { $connectionStrings.Keys -contains $connStringInfo.Name }
		}
	}
    finally
	{
		# Cleanup
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName1 -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName2 -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests remove a web app
#>
function Test-RemoveWebAppSlot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-Location
	$slotname = "staging"
	$planName = Get-WebHostPlanName
	$tier = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"

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

		# Create deployment slot
		$slot = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm.Id $slot.ServerFarmId

		# Remove web app via pipeline obj
		$slot | Remove-AzureRmWebAppSlot -Force

		# Retrieve web app by name
		$slotNames = Get-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname | Select -expand Name

		Assert-False { $slotNames -contains $appname }
	}
    finally
	{
		# Cleanup
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests remove a web app
#>
function Test-WebAppSlotPublishingProfile
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-Location
	$slotname = "staging"
	$planName = Get-WebHostPlanName
	$tier = "Standard"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	$profileFileName = "slotprofile.xml"

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

		# Create deployment slot
		$slot = New-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName
		$appWithSlotName = "$appname/$slotname"
		$appWithSlotName2 = "{0}__{1}" -f $appname, $slotname
		$appWithSlotName3 = "{0}-{1}" -f $appname, $slotname

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm.Id $slot.ServerFarmId

		# Get slot publishing profile
		[xml]$profile = Get-AzureRmWebAppSlotPublishingProfile -ResourceGroupName $rgname -Name $appname -Slot $slotname -OutputFile $profileFileName
		$msDeployProfile = $profile.publishData.publishProfile | ? { $_.publishMethod -eq 'MSDeploy' } | Select -First 1
		$pass = $msDeployProfile.userPWD

		# Assert
		Assert-True { $msDeployProfile.msdeploySite -eq $appWithSlotName2 }

		# Reset slot publishing profile
		$newPass = $slot | Reset-AzureRmWebAppSlotPublishingProfile 

		# Assert
		Assert-False { $pass -eq $newPass }

		# Get slot publishing profile via pipeline obj
		[xml]$profile = $slot | Get-AzureRmWebAppSlotPublishingProfile -OutputFile $profileFileName -Format FileZilla3
		$fileZillaProfile = $profile.FileZilla3.Servers.Server

		# Assert
		Assert-True { $fileZillaProfile.Name -eq $appWithSlotName3 }
	}
    finally
	{
		# Cleanup
		Remove-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname  -Slot $slotname -Force
		Remove-AzureRmWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzureRmAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests managing slot config names for a web app
#>
function Test-ManageSlotSlotConfigName
{
	$rgname = "Default-Web-EastAsia"
	$appname = "webappslottest"

	# Retrive Web App
	$webApp = Get-AzureRmWebApp -ResourceGroupName $rgname -Name  $appname
			
	$slotConfigNames = $webApp | Get-AzureRmWebAppSlotConfigName

	# Make sure that None of the settings are currently marked as slot setting
	Assert-AreEqual 0 $slotConfigNames.AppSettingNames.Count
	Assert-AreEqual 0 $slotConfigNames.ConnectionStringNames.Count

	# Test - Mark all app settings as slot setting
	$appSettingNames = $webApp.SiteConfig.AppSettings | Select-Object -ExpandProperty Name
	$webApp | Set-AzureRmWebAppSlotConfigName -AppSettingNames $appSettingNames 
	$slotConfigNames = $webApp | Get-AzureRmWebAppSlotConfigName
	Assert-AreEqual $webApp.SiteConfig.AppSettings.Count $slotConfigNames.AppSettingNames.Count
	Assert-AreEqual 0 $slotConfigNames.ConnectionStringNames.Count

	# Test- Mark all connection strings as slot setting
	$connectionStringNames = $webApp.SiteConfig.ConnectionStrings | Select-Object -ExpandProperty Name
	Set-AzureRmWebAppSlotConfigName -ResourceGroupName $rgname -Name $appname -ConnectionStringNames $connectionStringNames
	$slotConfigNames = Get-AzureRmWebAppSlotConfigName -ResourceGroupName $rgname -Name $appname
	Assert-AreEqual $webApp.SiteConfig.AppSettings.Count $slotConfigNames.AppSettingNames.Count
	Assert-AreEqual $webApp.SiteConfig.ConnectionStrings.Count $slotConfigNames.ConnectionStringNames.Count

	# Test- Clear slot app setting names
	$webApp | Set-AzureRmWebAppSlotConfigName -RemoveAllAppSettingNames
	$slotConfigNames = $webApp | Get-AzureRmWebAppSlotConfigName
	Assert-AreEqual 0 $slotConfigNames.AppSettingNames.Count
	Assert-AreEqual $webApp.SiteConfig.ConnectionStrings.Count $slotConfigNames.ConnectionStringNames.Count

	# Test - Clear slot connection string names
	Set-AzureRmWebAppSlotConfigName -ResourceGroupName $rgname -Name $appname -RemoveAllConnectionStringNames
	$slotConfigNames = Get-AzureRmWebAppSlotConfigName -ResourceGroupName $rgname -Name $appname
	Assert-AreEqual 0 $slotConfigNames.AppSettingNames.Count
	Assert-AreEqual 0 $slotConfigNames.ConnectionStringNames.Count
}


<#
.SYNOPSIS
Tests regular web app slot swap
#>
function Test-WebAppRegularSlotSwap
{
	$rgname = "Default-Web-EastAsia"
	$appname = "webappslottest"
	$sourceSlotName = "staging"
	$destinationSlotName = "production"

	# Swap Web App slots
	$webApp = Swap-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -SourceSlotName $sourceSlotName -DestinationSlotName $destinationSlotName
}

<#
.SYNOPSIS
Tests web app slot swap with preview: apply slot config followed by reset slot swap
#>
function Test-WebAppSwapWithPreviewResetSlotSwap
{
	Test-SlotSwapWithPreview 'ResetSlotSwap'
}

<#
.SYNOPSIS
Tests web app slot swap with preview: apply slot config followed by complete slot swap
#>
function Test-WebAppSwapWithPreviewCompleteSlotSwap
{
	Test-SlotSwapWithPreview 'CompleteSlotSwap'
}

<#
.SYNOPSIS
Test slot swap with preview feature
#>
function Test-SlotSwapWithPreview($swapWithPreviewAction)
{
	$rgname = "Default-Web-EastAsia"
	$appname = "webappslottest"
	$sourceSlotName = "staging"
	$destinationSlotName = "production"
	$appSettingName = 'testappsetting'
	$originalSourceAppSettingValue = "staging"
	$originalDestinationAppSettingValue = "production"

	# Let's retrieve slot configs and make sure that it contains initial values as expected
	$destinationWebApp = Get-AzureRmWebApp -ResourceGroupName $rgname -Name  $appname
	Validate-SlotSwapAppSetting $destinationWebApp $appSettingName $originalDestinationAppSettingValue
	
	$sourceWebApp = Get-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $sourceSlotName
	Validate-SlotSwapAppSetting $sourceWebApp $appSettingName $originalSourceAppSettingValue

	# Let's apply slot config and make sure that app setting values have been swapped
	Swap-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -SourceSlotName $sourceSlotName -DestinationSlotName $destinationSlotName -SwapWithPreviewAction 'ApplySlotConfig'
	Wait-Seconds 30
	$sourceWebApp = Get-AzureRmWebAppSlot -ResourceGroupName $rgname -Name  $appname -Slot $sourceSlotName
	Validate-SlotSwapAppSetting $sourceWebApp $appSettingName $originalDestinationAppSettingValue

	# Let's finish the current slot swap operation (complete or reset)
	Swap-AzureRmWebAppSlot -ResourceGroupName $rgname -Name $appname -SourceSlotName $sourceSlotName -DestinationSlotName $destinationSlotName -SwapWithPreviewAction $swapWithPreviewAction
	Wait-Seconds 30
	$sourceWebApp = Get-AzureRmWebAppSlot -ResourceGroupName $rgname -Name  $appname -Slot $sourceSlotName
	Validate-SlotSwapAppSetting $sourceWebApp $appSettingName $originalSourceAppSettingValue
}

<#
.SYNOPSIS
Validates slot app setting for slot swap tests
#>
function Validate-SlotSwapAppSetting($webApp, $appSettingName, $expectedValue)
{
	Assert-AreEqual $webApp.SiteConfig.AppSettings[0].Name $appSettingName
	Assert-AreEqual $webApp.SiteConfig.AppSettings[0].Value $expectedValue
}
