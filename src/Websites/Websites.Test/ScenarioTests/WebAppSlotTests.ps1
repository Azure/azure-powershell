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
	$resourceType = "Microsoft.Web/sites"

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
		
		# Create new deployment slot
		$slot1 = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname1 -AppServicePlan $planName
		$appWithSlotName1 = "$appname/$slotname1"

		# Assert
		Assert-AreEqual $appWithSlotName1 $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		# Get deployment slot
		$slot1 = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname1

		# Assert
		Assert-AreEqual $appWithSlotName1 $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		# Get deployment slot via pipeline obj
		$slot1 = $webapp | Get-AzWebAppSlot -Slot $slotname1

		# Assert
		Assert-AreEqual $appWithSlotName1 $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		# Create new deployment slot 2
		$slot2 = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname2 -AppServicePlan $planName 
		$appWithSlotName2 = "$appname/$slotname2"

		# Assert
		Assert-AreEqual $appWithSlotName2 $slot2.Name
		Assert-AreEqual $serverFarm.Id $slot2.ServerFarmId

		# Get deployment slots
		$slots = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $appname 
		$slotNames = $slots | Select -expand Name

		# Assert
		Assert-AreEqual 2 $slots.Count
		Assert-True { $slotNames -contains $appWithSlotName1 }
		Assert-True { $slotNames -contains $appWithSlotName2 }
	}
	finally
	{
		# Cleanup
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname1 -Force
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname2 -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
	$resourceType = "Microsoft.Web/sites"

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName 
		
		# Assert
		Assert-AreEqual $appname $webApp.Name
		Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
		
		# Create new deployment slot
		$slot = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName 
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm.Id $slot.ServerFarmId

		# Stop web app
		$slot = $slot | Stop-AzWebAppSlot

		Assert-AreEqual "Stopped" $slot.State
		$ping = PingWebApp $slot

		# Start web app
		$slot = $slot | Start-AzWebAppSlot

		Assert-AreEqual "Running" $slot.State
		$ping = PingWebApp $slot

		# Stop web app
		$slot = Stop-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname

		Assert-AreEqual "Stopped" $slot.State
		$ping = PingWebApp $slot

		# Start web app
		$slot = Start-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname

		Assert-AreEqual "Running" $slot.State
		$ping = PingWebApp $slot

		# Retart web app
		$slot = Restart-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname

		Assert-AreEqual "Running" $slot.State
		$ping = PingWebApp $slot

		# Restart web app
		$slot = $slot | Restart-AzWebAppSlot

		Assert-AreEqual "Running" $slot.State
		$ping = PingWebApp $slot
	}
	finally
	{
		# Cleanup
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
	$resourceType = "Microsoft.Web/sites"

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

		# Clone web app to slot
		$slot = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName -SourceWebApp $webapp
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name

		# Get web app slot
		$slot = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname
		
		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
	}
	finally
	{
		# Cleanup
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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

		# Create deployment slot
		$slot1 = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		# Create new server Farm
		$serverFarm2 = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $destPlanName -Location  $destLocation -Tier $tier

		# Create web app 2
		$webapp2 = New-AzWebApp -ResourceGroupName $rgname -Name $destAppName -Location $destLocation -AppServicePlan $destPlanName
		
		# Assert
		Assert-AreEqual $destAppName $webapp2.Name
		Assert-AreEqual $serverFarm2.Id $webapp2.ServerFarmId

		# Clone web app to slot
		$slot2 = New-AzWebAppSlot -ResourceGroupName $rgname -Name $destAppName -Slot $slotname -AppServicePlan $planName -SourceWebApp $slot1
		$appWithSlotName2 = "$destAppName/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName2 $slot2.Name
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
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
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$actual =  New-AzWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName
		
		# Assert
		Assert-AreEqual $appname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get new web app
		$result = Get-AzWebApp -ResourceGroupName $rgname -Name $appname
		
		# Assert
		Assert-AreEqual $appname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId

		# Create deployment slot
		$job = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AsJob
		$job | Wait-Job
		$slot1 = $job | Receive-Job

		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId
	}
	finally
	{
		# Cleanup
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
	$planName = "travelproductionplan"
	$aseName = "asedemops"

	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
	try
	{
		#Setup
		$serverFarm = Get-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName
		
		# Create new web app
		$actual = New-AzWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName -AseName $aseName
		
		# Assert
		Assert-AreEqual $appname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get new web app
		$result = Get-AzWebApp -ResourceGroupName $rgname -Name $appname
		
		# Assert
		Assert-AreEqual $appname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId

		# Create deployment slot
		$slot1 = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName -AseName $aseName
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		# Get new web app slot
		$slot1 = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

	}
	finally
	{
		# Cleanup
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $appname -Force
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
	$numberOfWorkers = 2

	try
	{
		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm1 = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName1 -Location  $location -Tier $tier1
		$serverFarm2 = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName2 -Location  $location -Tier $tier2
		
		# Create new web app
		$webApp = New-AzWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName1 
		
		# Assert
		Assert-AreEqual $appname $webApp.Name
		Assert-AreEqual $serverFarm1.Id $webApp.ServerFarmId

		# Create deployment slot
		$slot = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName1
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm1.Id $slot.ServerFarmId
        Assert-Null $webApp.Identity
		
		# Change service plan & set properties
		$job = Set-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName2 -HttpsOnly $true -AsJob
		$job | Wait-Job
		$slot = $job | Receive-Job

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm2.Id $slot.ServerFarmId
        Assert-AreEqual $true $slot.HttpsOnly

		# Set config properties
		$slot.SiteConfig.HttpLoggingEnabled = $true
		$slot.SiteConfig.RequestTracingEnabled = $true

		$slot = $slot | Set-AzWebAppSlot

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm2.Id $slot.ServerFarmId
		Assert-AreEqual $true $slot.SiteConfig.HttpLoggingEnabled
		Assert-AreEqual $true $slot.SiteConfig.RequestTracingEnabled

		# set app settings and connection strings
		$appSettings = @{ "setting1" = "valueA"; "setting2" = "valueB"}
		$connectionStrings = @{ connstring1 = @{ Type="MySql"; Value="string value 1"}; connstring2 = @{ Type = "SQLAzure"; Value="string value 2"}}

		$slot = Set-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppSettings $appSettings -AssignIdentity $true

        # Assert
        Assert-NotNull  $slot.Identity
        Assert-AreEqual ($appSettings.Keys.Count) $slot.SiteConfig.AppSettings.Count

        $slot = Set-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppSettings $appSettings -ConnectionStrings $connectionStrings -numberofworkers $numberOfWorkers

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
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

		Assert-AreEqual $numberOfWorkers $slot.SiteConfig.NumberOfWorkers
	}
	finally
	{
		# Cleanup
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName1 -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName2 -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName 
		
		# Assert
		Assert-AreEqual $appname $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Create deployment slot
		$slot = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName
		$appWithSlotName = "$appname/$slotname"

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm.Id $slot.ServerFarmId

		# Remove web app via pipeline obj
		$slot | Remove-AzWebAppSlot -Force -AsJob | Wait-Job

		# Retrieve web app by name
		$slotNames = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $appname | Select -expand Name

		Assert-False { $slotNames -contains $appname }
	}
	finally
	{
		# Cleanup
		Remove-AzWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzResourceGroup -Name $rgname -Force
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
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Location  $location -Tier $tier
		
		# Create new web app
		$webapp = New-AzWebApp -ResourceGroupName $rgname -Name $appname -Location $location -AppServicePlan $planName 
		
		# Assert
		Assert-AreEqual $appname $webapp.Name
		Assert-AreEqual $serverFarm.Id $webapp.ServerFarmId

		# Create deployment slot
		$slot = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slotname -AppServicePlan $planName
		$appWithSlotName = "$appname/$slotname"
		$appWithSlotName2 = "{0}__{1}" -f $appname, $slotname
		$appWithSlotName3 = "{0}-{1}" -f $appname, $slotname

		# Assert
		Assert-AreEqual $appWithSlotName $slot.Name
		Assert-AreEqual $serverFarm.Id $slot.ServerFarmId

		# Get slot publishing profile
		[xml]$profile = Get-AzWebAppSlotPublishingProfile -ResourceGroupName $rgname -Name $appname -Slot $slotname -OutputFile $profileFileName
		$msDeployProfile = $profile.publishData.publishProfile | ? { $_.publishMethod -eq 'MSDeploy' } | Select -First 1
		$pass = $msDeployProfile.userPWD

		# Assert
		Assert-True { $msDeployProfile.msdeploySite -eq $appWithSlotName2 }

		# Reset slot publishing profile
		$newPass = $slot | Reset-AzWebAppSlotPublishingProfile 

		# Assert
		Assert-False { $pass -eq $newPass }

		# Get slot publishing profile via pipeline obj
		[xml]$profile = $slot | Get-AzWebAppSlotPublishingProfile -OutputFile $profileFileName -Format FileZilla3
		$fileZillaProfile = $profile.FileZilla3.Servers.Server

		# Assert
		Assert-True { $fileZillaProfile.Name -eq $appWithSlotName3 }

		# Get web app publishing profile without OutputFile
		[xml]$profile = Get-AzWebAppSlotPublishingProfile -ResourceGroupName $rgname -Name $appname -Slot $slotname

		# Assert
		Assert-NotNull $profile

	}
	finally
	{
		# Cleanup
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $appname  -Slot $slotname -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
}

<#
.SYNOPSIS
Tests managing slot config names for a web app
#>
function Test-ManageSlotSlotConfigName
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-Location
	$planName = Get-WebHostPlanName
	$tier = "Standard"

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

		$slotConfigNames = $webApp | Get-AzWebAppSlotConfigName

		# Make sure that None of the settings are currently marked as slot setting
		Assert-AreEqual 0 $slotConfigNames.AppSettingNames.Count
		Assert-AreEqual 0 $slotConfigNames.ConnectionStringNames.Count

		# Test - Mark all app settings as slot setting
		$appSettingNames = $webApp.SiteConfig.AppSettings | Select-Object -ExpandProperty Name

		Assert-NotNull $appSettingNames
		
		$webApp | Set-AzWebAppSlotConfigName -AppSettingNames $appSettingNames 
		$slotConfigNames = $webApp | Get-AzWebAppSlotConfigName
		Assert-AreEqual $webApp.SiteConfig.AppSettings.Count $slotConfigNames.AppSettingNames.Count
		Assert-AreEqual 0 $slotConfigNames.ConnectionStringNames.Count

		# Test- Clear slot app setting names
		$webApp | Set-AzWebAppSlotConfigName -RemoveAllAppSettingNames
		$slotConfigNames = $webApp | Get-AzWebAppSlotConfigName
		Assert-AreEqual 0 $slotConfigNames.AppSettingNames.Count
		Assert-AreEqual $webApp.SiteConfig.ConnectionStrings.Count $slotConfigNames.ConnectionStringNames.Count

		# Test - Clear slot connection string names
		Set-AzWebAppSlotConfigName -ResourceGroupName $rgname -Name $appname -RemoveAllConnectionStringNames
		$slotConfigNames = Get-AzWebAppSlotConfigName -ResourceGroupName $rgname -Name $appname
		Assert-AreEqual 0 $slotConfigNames.AppSettingNames.Count
		Assert-AreEqual 0 $slotConfigNames.ConnectionStringNames.Count
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}
}


<#
.SYNOPSIS
Tests regular web app slot swap
#>
function Test-WebAppRegularSlotSwap
{
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-Location
	$planName = Get-WebHostPlanName
	$tier = "Standard"
	$sourceSlotName = "staging"
	$destinationSlotName = "production"

	# Swap Web App slots
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

		# Create deployment slot
		$slot = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $sourceSlotName -AppServicePlan $planName
		$webApp = Switch-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -SourceSlotName $sourceSlotName -DestinationSlotName $destinationSlotName
	}
	finally
	{
		# Cleanup
		Remove-AzWebAppSlot -ResourceGroupName $rgname -Name $appname  -Slot $sourceSlotName -Force
		Remove-AzWebApp -ResourceGroupName $rgname -Name $appname -Force
		Remove-AzAppServicePlan -ResourceGroupName $rgname -Name  $planName -Force
		Remove-AzResourceGroup -Name $rgname -Force
	}
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
	$rgname = Get-ResourceGroupName
	$appname = Get-WebsiteName
	$location = Get-Location
	$planName = Get-WebHostPlanName
	$tier = "Standard"
	$sourceSlotName = "staging"
	$destinationSlotName = "production"
	$appSettingName = 'testappsetting'
	$originalSourceAppSettingValue = "staging"
	$originalDestinationAppSettingValue = "production"

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

		# Create deployment slot
		$slot = New-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $sourceSlotName -AppServicePlan $planName

		# set app settings
		$appSettings = @{ $appSettingName = $originalDestinationAppSettingValue }
		Set-AzWebApp -ResourceGroupName $rgname -Name $appname -AppSettings $appSettings

		$appSettings = @{ $appSettingName = $originalSourceAppSettingValue }
		Set-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $sourceSlotName -AppSettings $appSettings

		# Let's retrieve slot configs and make sure that it contains initial values as expected
		$destinationWebApp = Get-AzWebApp -ResourceGroupName $rgname -Name  $appname
		Validate-SlotSwapAppSetting $destinationWebApp $appSettingName $originalDestinationAppSettingValue
		
		$sourceWebApp = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $sourceSlotName
		Validate-SlotSwapAppSetting $sourceWebApp $appSettingName $originalSourceAppSettingValue

		# Let's apply slot config and make sure that app setting values have been swapped
		Switch-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -SourceSlotName $sourceSlotName -DestinationSlotName $destinationSlotName -SwapWithPreviewAction 'ApplySlotConfig'
		Wait-Seconds 30
		$sourceWebApp = Get-AzWebAppSlot -ResourceGroupName $rgname -Name  $appname -Slot $sourceSlotName
		Validate-SlotSwapAppSetting $sourceWebApp $appSettingName $originalSourceAppSettingValue

		# Let's finish the current slot swap operation (complete or reset)
		Switch-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -SourceSlotName $sourceSlotName -DestinationSlotName $destinationSlotName -SwapWithPreviewAction $swapWithPreviewAction
		Wait-Seconds 30
		$sourceWebApp = Get-AzWebAppSlot -ResourceGroupName $rgname -Name  $appname -Slot $sourceSlotName
		If ($swapWithPreviewAction -eq 'ResetSlotSwap') {
			Validate-SlotSwapAppSetting $sourceWebApp $appSettingName $originalSourceAppSettingValue
		} Else {
			Validate-SlotSwapAppSetting $sourceWebApp $appSettingName $originalDestinationAppSettingValue
		}
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $rgname -Force
	}

}

<#
.SYNOPSIS
Tests setting and Azure Storage Account in a new Windows container app. Currently the API fails when adding Azure Storage Accounts for slots. Will enable this test when the API is fixed.
.DESCRIPTION
SmokeTest
#>
function Test-SetAzureStorageWebAppHyperVSlot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$wname = Get-WebsiteName
	$slotname = "staging"
	$location = Get-WebLocation
	$whpName = Get-WebHostPlanName
	$tier = "PremiumContainer"
	$apiversion = "2015-08-01"
	$resourceType = "Microsoft.Web/sites"
    $containerImageName = "testcontainer.io/test/iis"
    $containerRegistryUrl = "https://testcontainer.azurecr.io"
    $ontainerRegistryUser = "testregistry"
    $pass = "7Dxo9p79Ins2K3ZU"
    $containerRegistryPassword = ConvertTo-SecureString -String $pass -AsPlainText -Force
    $dockerPrefix = "DOCKER|" 
	$azureStorageAccountCustomId1 = "mystorageaccount"
	$azureStorageAccountType1 = "AzureFiles"
	$azureStorageAccountName1 = "myaccountname.file.core.windows.net"
	$azureStorageAccountShareName1 = "myremoteshare"
	$azureStorageAccountAccessKey1 = "AnAccessKey"
	$azureStorageAccountMountPath1 = "C:\mymountpath"
	$azureStorageAccountCustomId2 = "mystorageaccount2"
	$azureStorageAccountType2 = "AzureFiles"
	$azureStorageAccountName2 = "myaccountname2.file.core.windows.net"
	$azureStorageAccountShareName2 = "myremoteshare2"
	$azureStorageAccountAccessKey2 = "AnAccessKey2"
	$azureStorageAccountMountPath2 = "C:\mymountpath2"

	try
	{
		###
		# Currently the API fails when adding Azure Storage Accounts for slots. Will enable this test when the API is fixed.
		###

		#Setup
		New-AzResourceGroup -Name $rgname -Location $location
		$serverFarm = New-AzAppServicePlan -ResourceGroupName $rgname -Name  $whpName -Location  $location -Tier $tier -WorkerSize Small -HyperV
		
		# Create new web app
		$job = New-AzWebApp -ResourceGroupName $rgname -Name $wname -Location $location -AppServicePlan $whpName -ContainerImageName $containerImageName -ContainerRegistryUrl $containerRegistryUrl -ContainerRegistryUser $ontainerRegistryUser -ContainerRegistryPassword $containerRegistryPassword -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

		# Get new web app
		$result = Get-AzWebApp -ResourceGroupName $rgname -Name $wname
		
		Write-Debug "Created the web app"

		# Assert
		Assert-AreEqual $wname $result.Name
		Assert-AreEqual $serverFarm.Id $result.ServerFarmId
        Assert-AreEqual $true $result.IsXenon
        Assert-AreEqual ($dockerPrefix + $containerImageName)  $result.SiteConfig.WindowsFxVersion

		# Create deployment slot
		$job = New-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotname -AsJob
		$job | Wait-Job
		$slot1 = $job | Receive-Job

		Write-Debug "Created the slot"

		$appWithSlotName = "$wname/$slotname"

		Write-Debug $appWithSlotName

		# Assert
		Assert-AreEqual $appWithSlotName $slot1.Name
		Assert-AreEqual $serverFarm.Id $slot1.ServerFarmId

		$testStorageAccount1 = New-AzWebAppAzureStoragePath -Name $azureStorageAccountCustomId1 -Type $azureStorageAccountType1 -AccountName $azureStorageAccountName1 -ShareName $azureStorageAccountShareName1 -AccessKey $azureStorageAccountAccessKey1 -MountPath $azureStorageAccountMountPath1
		$testStorageAccount2 = New-AzWebAppAzureStoragePath -Name $azureStorageAccountCustomId2 -Type $azureStorageAccountType2 -AccountName $azureStorageAccountName2 -ShareName $azureStorageAccountShareName2 -AccessKey $azureStorageAccountAccessKey2 -MountPath $azureStorageAccountMountPath2

		Write-Debug "Created the new storage account paths"

		Write-Debug $testStorageAccount1.Name
		Write-Debug $testStorageAccount2.Name


		# set Azure Storage accounts
        $webApp = Set-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotname -AzureStoragePath $testStorageAccount1, $testStorageAccount2

		Write-Debug "Set the new storage account paths"


		# get the web app
		$result = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $wname -Slot $slotname
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
Validates slot app setting for slot swap tests
#>
function Validate-SlotSwapAppSetting($webApp, $appSettingName, $expectedValue)
{
	Assert-AreEqual $appSettingName $webApp.SiteConfig.AppSettings[0].Name
	Assert-AreEqual $expectedValue $webApp.SiteConfig.AppSettings[0].Value
}
