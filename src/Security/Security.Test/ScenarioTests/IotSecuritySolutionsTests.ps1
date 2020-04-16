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
Get IoT security solutions on a subscription
#>
function Get-AzureRmIotSecuritySolution-SubscriptionScope
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs

    $soltions = Get-AzIotSecuritySolution
	Validate-Solutions $soltions
}

<#
.SYNOPSIS
Get IoT security solutions on a resource group
#>
function Get-AzureRmIotSecuritySolution-ResourceGroupScope
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs

	$soltions = Get-AzIotSecuritySolution -ResourceGroupName $ResourceGroupName
	Validate-Solutions $soltions
}

<#
.SYNOPSIS
Get IoT security solution by resource group and name
#>
function Get-AzureRmIotSecuritySolution-ResourceGroupLevelResource
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs

	$soltion = Get-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName
	Validate-Solution $soltion
}

<#
.SYNOPSIS
Get IoT security solution by resource ID
#>
function Get-AzureRmIotSecuritySolution-ResourceId
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	$soltion = Set-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs

	$soltion = Get-AzIotSecuritySolution -ResourceId $soltion.Id
	Validate-Solution $soltion
}

<#
.SYNOPSIS
Set IoT security solution on a resource group and name
#>
function Set-AzureRmIotSecuritySolution-ResourceGroupLevelResource
{
    $Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	$soltion = Set-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs
	Validate-Solution $soltion
}

<#
.SYNOPSIS
Set IoT security solution on a resource Id
#>
function Set-AzureRmIotSecuritySolution-ResourceId
{
    $Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	$soltion = Set-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs
	$soltion = Set-AzIotSecuritySolution -ResourceId $soltion.Id -Location $Location -Workspace $Workspace -DisplayName $DisplayName -IotHub $IotHubs
	Validate-Solution $soltion
}

<#
.SYNOPSIS
Set IoT security solution on a InputObject
#>
function Set-AzureRmIotSecuritySolution-InputObject
{
    $Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	$soltion = Set-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs
	$soltion = Set-AzIotSecuritySolution -InputObject $soltion -Location $Location -Workspace $Workspace -DisplayName $DisplayName -IotHub $IotHubs
	Validate-Solution $soltion
}

<#
.SYNOPSIS
Delete IoT security solution on a resource group and Id
#>
function Remove-AzureRmIotSecuritySolution-ResourceGroupLevelResource
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs
	Remove-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName
}

<#
.SYNOPSIS
Delete IoT security solution on a resource Id
#>
function Remove-AzureRmIotSecuritySolution-ResourceId
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	$solution = Set-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs
	Remove-AzIotSecuritySolution -ResourceId $solution.Id
}

<#
.SYNOPSIS
Update IoT security solution by resource group and name
#>
function Update-AzureRmIotSecuritySolution-ResourceGroupLevelResource
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs

	$RecConfig = New-AzIotSecuritySolutionRecommendationConfigurationObject -RecommendationType "IoT_OpenPorts" -Status "Disabled"
	$RecommendationsConfiguration = @($RecConfig)

	$Query = 'where type != "microsoft.devices/iothubs" | where name contains "v2"'
	$QuerySubscriptions = @("075423e9-7d33-4166-8bdf-3920b04e3735")
	$UserDefinedResource = New-AzIotSecuritySolutionUserDefinedResourcesObject -Query $Query -QuerySubscriptionList $QuerySubscriptions
	
	$solution = Update-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -RecommendationsConfiguration $RecommendationsConfiguration -UserDefinedResource $UserDefinedResource
	Validate-Solution $solution	
}

<#
.SYNOPSIS
Update IoT security solutions by resource Id
#>
function Update-AzureRmIotSecuritySolution-ResourceId
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	$solution = Set-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs

	$RecConfig = New-AzIotSecuritySolutionRecommendationConfigurationObject -RecommendationType "IoT_OpenPorts" -Status "Disabled"
	$RecommendationsConfiguration = @($RecConfig)

	$Query = 'where type != "microsoft.devices/iothubs" | where name contains "v2"'
	$QuerySubscriptions = @("075423e9-7d33-4166-8bdf-3920b04e3735")
	$UserDefinedResource = New-AzIotSecuritySolutionUserDefinedResourcesObject -Query $Query -QuerySubscriptionList $QuerySubscriptions

	$solution = Update-AzIotSecuritySolution -ResourceId $solution.Id -RecommendationsConfiguration $RecommendationsConfiguration -UserDefinedResource $UserDefinedResources
	Validate-Solution $solution
}

<#
.SYNOPSIS
Update IoT security solutions by resource Id
#>
function Update-AzureRmIotSecuritySolution-InputObject
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = @("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	$solution = Set-AzIotSecuritySolution -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHub $IotHubs

	$RecConfig = New-AzIotSecuritySolutionRecommendationConfigurationObject -RecommendationType "IoT_OpenPorts" -Status "Disabled"
	$RecommendationsConfiguration = @($RecConfig)

	$Query = 'where type != "microsoft.devices/iothubs" | where name contains "v2"'
	$QuerySubscriptions = @("075423e9-7d33-4166-8bdf-3920b04e3735")
	$UserDefinedResource = New-AzIotSecuritySolutionUserDefinedResourcesObject -Query $Query -QuerySubscriptionList $QuerySubscriptions

	$solution = Update-AzIotSecuritySolution -InputObject $solution -RecommendationsConfiguration $RecommendationsConfiguration -UserDefinedResource $UserDefinedResources
	Validate-Solution $solution
}

<#
.SYNOPSIS
Validates a list of iot security solutions
#>
function Validate-Solutions
{
	param($solutions)

    Assert-True { $solutions.Count -gt 0 }

	Foreach($solution in $solutions)
	{
		Validate-Solution $solution
	}
}

<#
.SYNOPSIS
Validates a single contact
#>
function Validate-Solution
{
	param($soltion)

	Assert-NotNull $soltion
}