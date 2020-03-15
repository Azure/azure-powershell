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
function Get-AzureRmIotSecuritySolutions-SubscriptionScope
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = New-Object System.Collections.Generic.List[System.String]
	$IotHubs.Add("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHubs $IotHubs

    $soltions = Get-AzIotSecuritySolutions
	Validate-Solutions $soltions
}

<#
.SYNOPSIS
Get IoT security solutions on a resource group
#>
function Get-AzureRmIotSecuritySolutions-ResourceGroupScope
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = New-Object System.Collections.Generic.List[System.String]
	$IotHubs.Add("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHubs $IotHubs

	$soltions = Get-AzIotSecuritySolutions -ResourceGroupName $ResourceGroupName
	Validate-Solutions $soltions
}

<#
.SYNOPSIS
Get IoT security solution by resource group and name
#>
function Get-AzureRmIotSecuritySolutions-ResourceGroupLevelResource
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = New-Object System.Collections.Generic.List[System.String]
	$IotHubs.Add("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHubs $IotHubs

	$soltion = Get-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName
	Validate-Solution $soltion
}

<#
.SYNOPSIS
Get IoT security solution by resource ID
#>
function Get-AzureRmIotSecuritySolutions-ResourceId
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = New-Object System.Collections.Generic.List[System.String]
	$IotHubs.Add("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	$soltion = Set-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHubs $IotHubs

	$soltion = Get-AzIotSecuritySolutions -ResourceId $soltion.Id
	Validate-Solution $soltion
}

<#
.SYNOPSIS
Set IoT security solution on a resource group and name
#>
function Set-AzureRmIotSecuritySolutions-ResourceGroupLevelResource
{
    $Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = New-Object System.Collections.Generic.List[System.String]
	$IotHubs.Add("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");
	Write-Debug "IotHubs value: $IotHubs"
	$soltion = Set-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHubs $IotHubs
	Validate-Solution $soltion
}

<#
.SYNOPSIS
Set IoT security solution on a resource Id
#>
function Set-AzureRmIotSecuritySolutions-ResourceId
{
    $Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = New-Object System.Collections.Generic.List[System.String]
	$IotHubs.Add("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	$soltion = Set-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHubs $IotHubs
	$soltion = Set-AzIotSecuritySolutions -ResourceId $soltion.Id -Location $Location -Workspace $Workspace -DisplayName $DisplayName -IotHubs $IotHubs
	Validate-Solution $soltion
}

<#
.SYNOPSIS
Delete IoT security solution on a resource group and Id
#>
function Remove-AzureRmIotSecuritySolutions-ResourceGroupLevelResource
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = New-Object System.Collections.Generic.List[System.String]
	$IotHubs.Add("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHubs $IotHubs
	Remove-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName
}

<#
.SYNOPSIS
Delete IoT security solution on a resource Id
#>
function Remove-AzureRmIotSecuritySolutions-ResourceId
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = New-Object System.Collections.Generic.List[string]
	$IotHubs.Add("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	$solution = Set-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHubs $IotHubs
	Remove-AzIotSecuritySolutions -ResourceId $solution.Id
}

<#
.SYNOPSIS
Update IoT security solution by resource group and name
#>
function Update-AzureRmIotSecuritySolutions-ResourceGroupLevelResource
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = New-Object System.Collections.Generic.List[string]
	$IotHubs.Add("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	Set-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHubs $IotHubs

	$RecConfig = New-Object Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions.PSRecommendationConfiguration
	$RecConfig.RecommendationType = "IoT_OpenPorts"
	$RecConfig.Status = "Disabled"
	$RecommendationsConfiguration = New-Object System.Collections.Generic.List[Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions.PSRecommendationConfiguration] 
	$RecommendationsConfiguration.Add($RecConfig)
	$UserDefinedResources = New-Object Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions.PSUserDefinedResources
	$UserDefinedResources.Query = 'where type != "microsoft.devices/iothubs" | where name contains "v2"'
	$UserDefinedResources.QuerySubscriptions = New-Object System.Collections.Generic.List[string]
	$UserDefinedResources.QuerySubscriptions.Add("075423e9-7d33-4166-8bdf-3920b04e3735")

	$solution = Update-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName -RecommendationsConfiguration $RecommendationsConfiguration -UserDefinedResources $UserDefinedResources
	Validate-Solution $solution	
}

<#
.SYNOPSIS
Update IoT security solutions by resource Id
#>
function Update-AzureRmIotSecuritySolutions-ResourceId
{
	$Name = "MichalDemoHub"
	$ResourceGroupName = "MichalResourceGroup"
	$Location = "West US"
	$Workspace = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.OperationalInsights/workspaces/IoTHubWorkspace"
	$DisplayName = "MichalDemoHub"
	$Status = "Enabled"
	$IotHubs = New-Object System.Collections.Generic.List[string]
	$IotHubs.Add("/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub");

	$solution = Set-AzIotSecuritySolutions -Name $Name -ResourceGroupName $ResourceGroupName -Location $Location -Workspace $Workspace -DisplayName $DisplayName -Status $Status -IotHubs $IotHubs

	$RecConfig = New-Object Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions.PSRecommendationConfiguration
	$RecConfig.RecommendationType = "IoT_OpenPorts"
	$RecConfig.Status = "Disabled"
	$RecommendationsConfiguration = New-Object System.Collections.Generic.List[Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions.PSRecommendationConfiguration] 
	$RecommendationsConfiguration.Add($RecConfig)
	$UserDefinedResources = New-Object Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions.PSUserDefinedResources
	$UserDefinedResources.Query = 'where type != "microsoft.devices/iothubs" | where name contains "v2"'
	$UserDefinedResources.QuerySubscriptions = New-Object System.Collections.Generic.List[string]
	$UserDefinedResources.QuerySubscriptions.Add("075423e9-7d33-4166-8bdf-3920b04e3735")

	$solution = Update-AzIotSecuritySolutions -ResourceId $solution.Id -RecommendationsConfiguration $RecommendationsConfiguration -UserDefinedResources $UserDefinedResources
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